using System.Data;
using VRMS.Database;
using VRMS.Enums;
using VRMS.Models.Billing;

namespace VRMS.Repositories.Billing;

public class InvoiceRepository
{
    public int Create(
        int rentalId,
        decimal totalAmount,
        DateTime generatedDate)
    {
        var table = DB.Query(
            "CALL sp_invoices_create(@rid,@total,@gen);",
            ("@rid", rentalId),
            ("@total", totalAmount),
            ("@gen", generatedDate)
        );

        return Convert.ToInt32(
            table.Rows[0]["invoice_id"]);
    }

    public Invoice GetById(int id)
    {
        var table = DB.Query(
            "CALL sp_invoices_get_by_id(@id);",
            ("@id", id)
        );

        if (table.Rows.Count == 0)
            throw new InvalidOperationException(
                "Invoice not found.");

        return Map(table.Rows[0]);
    }

    public Invoice? GetByRental(int rentalId)
    {
        var table = DB.Query(
            "CALL sp_invoices_get_by_rental(@rid);",
            ("@rid", rentalId)
        );

        if (table.Rows.Count == 0)
            return null;

        return Map(table.Rows[0]);
    }
    public void FinalizeTotal(int invoiceId, decimal totalAmount)
    {
        DB.Execute(
            "CALL sp_invoices_finalize(@id,@total);",
            ("@id", invoiceId),
            ("@total", totalAmount)
        );
    }
    
    public void MarkPaid(int invoiceId)
    {
        DB.Execute(
            "CALL sp_invoices_mark_paid(@id);",
            ("@id", invoiceId)
        );
    }

    // ---------------- MAPPING ----------------

    private static Invoice Map(DataRow row)
    {
        return new Invoice
        {
            Id = Convert.ToInt32(row["id"]),
            RentalId = Convert.ToInt32(row["rental_id"]),
            TotalAmount =
                Convert.ToDecimal(row["total_amount"]),
            GeneratedDate =
                Convert.ToDateTime(row["generated_date"]),
            Status =
                Enum.Parse<InvoiceStatus>(
                    row["status"].ToString()!, true)
        };
    }
}