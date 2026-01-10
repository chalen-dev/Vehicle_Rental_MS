using VRMS.Enums;
using VRMS.Models.Billing;
using VRMS.Repositories.Billing;
using VRMS.Services.Rental;

namespace VRMS.Services.Billing;

public class BillingService
{
    private readonly RentalService _rentalService;
    private readonly InvoiceRepository _invoiceRepo;
    private readonly PaymentRepository _paymentRepo;

    public BillingService(
        RentalService rentalService,
        InvoiceRepository invoiceRepo,
        PaymentRepository paymentRepo)
    {
        _rentalService = rentalService;
        _invoiceRepo = invoiceRepo;
        _paymentRepo = paymentRepo;
    }

    // ---------------- INVOICES ----------------

    public Invoice GetOrCreateInvoice(int rentalId)
    {
        var rental = _rentalService.GetRentalById(rentalId);

        if (rental.Status != RentalStatus.Active)
            throw new InvalidOperationException(
                "Invoice can only be created for active rentals.");

        var existing = _invoiceRepo.GetByRental(rentalId);
        if (existing != null)
            return existing;

        var id = _invoiceRepo.Create(
            rentalId,
            0m,
            DateTime.UtcNow);

        return _invoiceRepo.GetById(id);
    }
    
    public void FinalizeInvoice(int rentalId, decimal finalTotal)
    {
        if (finalTotal < 0)
            throw new InvalidOperationException(
                "Invoice total cannot be negative.");

        var rental = _rentalService.GetRentalById(rentalId);

        if (rental.Status is not (RentalStatus.Completed or RentalStatus.Late))
            throw new InvalidOperationException(
                "Invoice can only be finalized for completed rentals.");

        var invoice = _invoiceRepo.GetByRental(rentalId)
                      ?? throw new InvalidOperationException(
                          "Invoice does not exist.");

        if (invoice.TotalAmount != 0)
            throw new InvalidOperationException(
                "Invoice has already been finalized.");

        _invoiceRepo.FinalizeTotal(invoice.Id, finalTotal);
    }



    public Invoice GetInvoiceById(int invoiceId)
        => _invoiceRepo.GetById(invoiceId);

    public Invoice? GetInvoiceByRental(int rentalId)
        => _invoiceRepo.GetByRental(rentalId);

    // ---------------- PAYMENTS ----------------

    public int AddPayment(
        int invoiceId,
        decimal amount,
        PaymentMethod method,
        DateTime date)
    {
        if (amount <= 0)
            throw new InvalidOperationException(
                "Payment amount must be greater than zero.");

        var balance = GetInvoiceBalance(invoiceId);
        if (amount > balance)
            throw new InvalidOperationException(
                "Payment exceeds outstanding balance.");

        return _paymentRepo.Create(
            invoiceId,
            amount,
            method,
            date);
    }

    public List<Payment> GetPaymentsByInvoice(int invoiceId)
        => _paymentRepo.GetByInvoice(invoiceId);

    // ---------------- BALANCE ----------------

    public decimal GetInvoiceBalance(int invoiceId)
    {
        var invoice = _invoiceRepo.GetById(invoiceId);
        var payments =
            _paymentRepo.GetByInvoice(invoiceId);

        decimal paid = 0m;
        foreach (var p in payments)
            paid += p.Amount;

        return invoice.TotalAmount - paid;
    }
}
