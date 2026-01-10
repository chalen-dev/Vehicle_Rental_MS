using VRMS.Enums;
using VRMS.Models.Billing;
using VRMS.Repositories.Billing;
using VRMS.Repositories.Damages;
using VRMS.Repositories.Rentals;
using VRMS.Services.Fleet;
using VRMS.Services.Rental;

namespace VRMS.Services.Billing;

public class BillingService
{
    private readonly RentalRepository _rentalRepo;
    private readonly ReservationService _reservationService;
    private readonly VehicleService _vehicleService;
    private readonly RateService _rateService;
    private readonly InvoiceRepository _invoiceRepo;
    private readonly PaymentRepository _paymentRepo;
    private readonly InvoiceLineItemRepository _lineItemRepo;
    private readonly DamageReportRepository _damageReportRepo;

    public BillingService(
        RentalRepository rentalRepo,
        ReservationService reservationService,
        VehicleService vehicleService,
        RateService rateService,
        InvoiceRepository invoiceRepo,
        InvoiceLineItemRepository lineItemRepo,
        PaymentRepository paymentRepo,
        DamageReportRepository damageReportRepo)
    {
        _rentalRepo = rentalRepo;
        _reservationService = reservationService;
        _vehicleService = vehicleService;
        _rateService = rateService;
        _invoiceRepo = invoiceRepo;
        _lineItemRepo = lineItemRepo;
        _paymentRepo = paymentRepo;
        _damageReportRepo = damageReportRepo;
    }

    // ---------------- INVOICES ----------------

    public Invoice GetOrCreateInvoice(int rentalId)
    {
        var rental = _rentalRepo.GetById(rentalId);

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

    // PRICING ENFORCEMENT (FINAL, AUTHORITATIVE)
    public void FinalizeInvoice(int rentalId)
    {
        var rental = _rentalRepo.GetById(rentalId);

        if (rental.Status is not (RentalStatus.Completed or RentalStatus.Late))
            throw new InvalidOperationException(
                "Invoice can only be finalized for completed rentals.");

        if (rental.ActualReturnDate == null)
            throw new InvalidOperationException(
                "Rental has no return date.");

        var invoice =
            _invoiceRepo.GetByRental(rentalId)
            ?? throw new InvalidOperationException(
                "Invoice does not exist.");

        var reservation =
            _reservationService.GetReservationById(
                rental.ReservationId);

        var vehicle =
            _vehicleService.GetVehicleById(
                reservation.VehicleId);

        // -------- BASE RENTAL --------
        var baseRental =
            _rateService.CalculateRentalCost(
                rental.PickupDate,
                rental.ActualReturnDate.Value,
                vehicle.VehicleCategoryId);

        _lineItemRepo.Create(
            invoice.Id,
            "Base rental charge",
            baseRental);

        // -------- LATE PENALTY --------
        var latePenalty =
            _rateService.CalculateLatePenalty(
                rental.ExpectedReturnDate,
                rental.ActualReturnDate.Value,
                vehicle.VehicleCategoryId);

        if (latePenalty > 0)
            _lineItemRepo.Create(
                invoice.Id,
                "Late return penalty",
                latePenalty);

        // -------- MILEAGE OVERAGE --------
        var mileageCharge =
            _rateService.CalculateMileageOverage(
                rental.StartOdometer,
                rental.EndOdometer!.Value,
                rental.PickupDate,
                rental.ActualReturnDate.Value,
                vehicle.VehicleCategoryId);

        if (mileageCharge > 0)
            _lineItemRepo.Create(
                invoice.Id,
                "Mileage overage charge",
                mileageCharge);
        
        // ---------------- DAMAGE CHARGES ----------------
        var approvedDamages =
            _damageReportRepo.GetApprovedByRental(rentalId);

        foreach (var d in approvedDamages)
        {
            _lineItemRepo.Create(
                invoice.Id,
                $"Damage: {d.Description} (Report #{d.DamageReportId})",
                d.EstimatedCost);
        }
        
        if (invoice.Status == InvoiceStatus.Paid)
            throw new InvalidOperationException(
                "Invoice is already paid.");
        
        // -------- FINAL TOTAL --------
        var items =
            _lineItemRepo.GetByInvoice(invoice.Id);

        decimal total = 0m;
        foreach (var item in items)
            total += item.Amount;

        _invoiceRepo.FinalizeTotal(
            invoice.Id,
            total);
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

        var invoice =
            _invoiceRepo.GetById(invoiceId);

        if (invoice.Status == InvoiceStatus.Paid)
            throw new InvalidOperationException(
                "Invoice is already paid.");

        var balance = GetInvoiceBalance(invoiceId);
        if (amount > balance)
            throw new InvalidOperationException(
                "Payment exceeds outstanding balance.");

        var paymentId =
            _paymentRepo.Create(
                invoiceId,
                amount,
                method,
                date);

        //  AUTO-MARK PAID
        if (GetInvoiceBalance(invoiceId) == 0m)
            _invoiceRepo.MarkPaid(invoiceId);

        return paymentId;
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
