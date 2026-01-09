using System;
using System.Collections.Generic;
using System.Data;
using VRMS.Database;
using VRMS.Helpers.SqlEscape;
using VRMS.Enums;
using VRMS.Models.Billing;

namespace VRMS.Services;

public class BillingService
{
    private readonly RentalService _rentalService;

    public BillingService(RentalService rentalService)
    {
        _rentalService = rentalService;
    }

    // -------------------------------------------------
    // INVOICES
    // -------------------------------------------------

    public int GenerateInvoiceForRental(int rentalId, decimal totalAmount)
    {
        var rental = _rentalService.GetRentalById(rentalId);

        if (rental.Status is not (RentalStatus.Completed or RentalStatus.Late))
            throw new InvalidOperationException("Invoice can only be generated for completed or late rentals.");

        // Ensure only one invoice per rental
        var existing = GetInvoiceByRental(rentalId);
        if (existing != null)
            throw new InvalidOperationException("Invoice already exists for this rental.");

        var table = DB.ExecuteQuery($"""
            CALL sp_invoices_create(
                {rentalId},
                {totalAmount},
                '{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}'
            );
        """);

        return Convert.ToInt32(table.Rows[0]["invoice_id"]);
    }

    public Invoice GetInvoiceById(int invoiceId)
    {
        var table = DB.ExecuteQuery(
            $"CALL sp_invoices_get_by_id({invoiceId});"
        );

        if (table.Rows.Count == 0)
            throw new InvalidOperationException("Invoice not found.");

        return MapInvoice(table.Rows[0]);
    }

    public Invoice? GetInvoiceByRental(int rentalId)
    {
        var table = DB.ExecuteQuery(
            $"CALL sp_invoices_get_by_rental({rentalId});"
        );

        if (table.Rows.Count == 0)
            return null;

        return MapInvoice(table.Rows[0]);
    }

    // -------------------------------------------------
    // PAYMENTS
    // -------------------------------------------------

    public int AddPayment(
        int invoiceId,
        decimal amount,
        PaymentMethod paymentMethod,
        DateTime paymentDate)
    {
        if (amount <= 0)
            throw new InvalidOperationException("Payment amount must be greater than zero.");

        var invoice = GetInvoiceById(invoiceId);
        var balance = GetInvoiceBalance(invoiceId);

        if (amount > balance)
            throw new InvalidOperationException("Payment exceeds outstanding invoice balance.");

        var table = DB.ExecuteQuery($"""
            CALL sp_payments_create(
                {invoiceId},
                {amount},
                '{paymentMethod}',
                '{paymentDate:yyyy-MM-dd HH:mm:ss}'
            );
        """);

        return Convert.ToInt32(table.Rows[0]["payment_id"]);
    }

    public Payment GetPaymentById(int paymentId)
    {
        var table = DB.ExecuteQuery(
            $"CALL sp_payments_get_by_id({paymentId});"
        );

        if (table.Rows.Count == 0)
            throw new InvalidOperationException("Payment not found.");

        return MapPayment(table.Rows[0]);
    }

    public List<Payment> GetPaymentsByInvoice(int invoiceId)
    {
        var table = DB.ExecuteQuery(
            $"CALL sp_payments_get_by_invoice({invoiceId});"
        );

        var list = new List<Payment>();
        foreach (DataRow row in table.Rows)
            list.Add(MapPayment(row));

        return list;
    }

    // -------------------------------------------------
    // BALANCE
    // -------------------------------------------------

    public decimal GetInvoiceBalance(int invoiceId)
    {
        var invoice = GetInvoiceById(invoiceId);
        var payments = GetPaymentsByInvoice(invoiceId);

        decimal paid = 0m;
        foreach (var p in payments)
            paid += p.Amount;

        return invoice.TotalAmount - paid;
    }

    // -------------------------------------------------
    // RATE CONFIGURATIONS (ADMIN)
    // -------------------------------------------------

    public int CreateRateConfiguration(
        int vehicleCategoryId,
        decimal dailyRate,
        decimal weeklyRate,
        decimal monthlyRate,
        decimal hourlyRate)
    {
        ValidateRates(dailyRate, weeklyRate, monthlyRate, hourlyRate);

        var table = DB.ExecuteQuery($"""
            CALL sp_rate_configurations_create(
                {vehicleCategoryId},
                {dailyRate},
                {weeklyRate},
                {monthlyRate},
                {hourlyRate}
            );
        """);

        return Convert.ToInt32(table.Rows[0]["rate_configuration_id"]);
    }

    public void UpdateRateConfiguration(
        int rateConfigurationId,
        decimal dailyRate,
        decimal weeklyRate,
        decimal monthlyRate,
        decimal hourlyRate)
    {
        ValidateRates(dailyRate, weeklyRate, monthlyRate, hourlyRate);

        DB.ExecuteNonQuery($"""
            CALL sp_rate_configurations_update(
                {rateConfigurationId},
                {dailyRate},
                {weeklyRate},
                {monthlyRate},
                {hourlyRate}
            );
        """);
    }

    public void DeleteRateConfiguration(int rateConfigurationId)
    {
        DB.ExecuteNonQuery(
            $"CALL sp_rate_configurations_delete({rateConfigurationId});"
        );
    }

    public RateConfiguration GetRateConfigurationById(int rateConfigurationId)
    {
        var table = DB.ExecuteQuery(
            $"CALL sp_rate_configurations_get_by_id({rateConfigurationId});"
        );

        if (table.Rows.Count == 0)
            throw new InvalidOperationException("Rate configuration not found.");

        return MapRateConfiguration(table.Rows[0]);
    }

    public RateConfiguration GetRateConfigurationByCategory(int vehicleCategoryId)
    {
        var table = DB.ExecuteQuery(
            $"CALL sp_rate_configurations_get_by_category({vehicleCategoryId});"
        );

        if (table.Rows.Count == 0)
            throw new InvalidOperationException("Rate configuration not found for category.");

        return MapRateConfiguration(table.Rows[0]);
    }

    // -------------------------------------------------
    // VALIDATION
    // -------------------------------------------------

    private static void ValidateRates(
        decimal daily,
        decimal weekly,
        decimal monthly,
        decimal hourly)
    {
        if (daily < 0 || weekly < 0 || monthly < 0 || hourly < 0)
            throw new InvalidOperationException("Rates cannot be negative.");
    }

    // -------------------------------------------------
    // MAPPING
    // -------------------------------------------------

    private static Invoice MapInvoice(DataRow row)
    {
        return new Invoice
        {
            Id = Convert.ToInt32(row["id"]),
            RentalId = Convert.ToInt32(row["rental_id"]),
            TotalAmount = Convert.ToDecimal(row["total_amount"]),
            GeneratedDate = Convert.ToDateTime(row["generated_date"])
        };
    }

    private static Payment MapPayment(DataRow row)
    {
        return new Payment
        {
            Id = Convert.ToInt32(row["id"]),
            InvoiceId = Convert.ToInt32(row["invoice_id"]),
            Amount = Convert.ToDecimal(row["amount"]),
            PaymentMethod = Enum.Parse<PaymentMethod>(
                row["payment_method"].ToString()!, true),
            PaymentDate = Convert.ToDateTime(row["payment_date"])
        };
    }

    private static RateConfiguration MapRateConfiguration(DataRow row)
    {
        return new RateConfiguration
        {
            Id = Convert.ToInt32(row["id"]),
            VehicleCategoryId = Convert.ToInt32(row["vehicle_category_id"]),
            DailyRate = Convert.ToDecimal(row["daily_rate"]),
            WeeklyRate = Convert.ToDecimal(row["weekly_rate"]),
            MonthlyRate = Convert.ToDecimal(row["monthly_rate"]),
            HourlyRate = Convert.ToDecimal(row["hourly_rate"])
        };
    }
}
