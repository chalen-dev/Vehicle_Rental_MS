using VRMS.Enums;
using VRMS.Models.Billing;
using VRMS.Repositories.Billing;
using VRMS.Repositories.Damages;
using VRMS.Repositories.Rentals;
using VRMS.Services.Fleet;
using VRMS.Services.Rental;

namespace VRMS.Services.Billing;

/// <summary>
/// Provides authoritative billing logic for rentals, including
/// invoice creation, pricing enforcement, damage charges, and payments.
///
/// This service is the single source of truth for:
/// - Invoice lifecycle management
/// - Final rental pricing calculations
/// - Damage charge application
/// - Payment processing and invoice locking
/// </summary>
public class BillingService
{
    /// <summary>Rental data access</summary>
    private readonly RentalRepository _rentalRepo;

    /// <summary>Reservation business logic</summary>
    private readonly ReservationService _reservationService;

    /// <summary>Vehicle lookup and metadata access</summary>
    private readonly VehicleService _vehicleService;

    /// <summary>Rate and pricing calculation logic</summary>
    private readonly RateService _rateService;

    /// <summary>Invoice persistence</summary>
    private readonly InvoiceRepository _invoiceRepo;

    /// <summary>Payment persistence</summary>
    private readonly PaymentRepository _paymentRepo;

    /// <summary>Invoice line item persistence</summary>
    private readonly InvoiceLineItemRepository _lineItemRepo;

    /// <summary>Damage report persistence</summary>
    private readonly DamageReportRepository _damageReportRepo;

    /// <summary>
    /// Initializes the billing service with all required dependencies.
    /// </summary>
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

    /// <summary>
    /// Retrieves an existing invoice for a rental or creates a new one if none exists.
    /// </summary>
    /// <param name="rentalId">Rental ID</param>
    /// <returns>The existing or newly created <see cref="Invoice"/></returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the rental is not active or a paid invoice already exists
    /// </exception>
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


    // ---------------- PRICING ENFORCEMENT ----------------

    /// <summary>
    /// Finalizes an invoice by calculating all authoritative charges.
    ///
    /// This method is FINAL and AUTHORITATIVE:
    /// - Base rental cost
    /// - Late penalties
    /// - Mileage overages
    /// - Approved damage charges
    ///
    /// Once finalized, the total amount is locked unless unpaid.
    /// </summary>
    /// <param name="rentalId">Rental ID</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown when rental state or invoice state is invalid
    /// </exception>
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

        if (invoice.Status == InvoiceStatus.Paid)
            throw new InvalidOperationException(
                "Paid invoices cannot be modified.");

        var reservation =
            _reservationService.GetReservationById(
                rental.ReservationId);

        var vehicle =
            _vehicleService.GetVehicleById(
                reservation.VehicleId);

        EnsureInvoiceEditable(invoice.Id);

        // -------- BASE RENTAL CHARGE --------
        var baseRental =
            _rateService.CalculateRentalCost(
                rental.PickupDate,
                rental.ActualReturnDate.Value,
                vehicle.VehicleCategoryId);

        _lineItemRepo.Create(
            invoice.Id,
            "Base rental charge",
            baseRental);

        // -------- LATE RETURN PENALTY --------
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

        // -------- DAMAGE CHARGES --------
        var approvedDamages =
            _damageReportRepo.GetApprovedByRental(rentalId);

        foreach (var d in approvedDamages)
        {
            _lineItemRepo.Create(
                invoice.Id,
                $"Damage: {d.Description} (Report #{d.DamageReportId})",
                d.EstimatedCost);
        }

        // -------- FINAL TOTAL CALCULATION --------
        var items =
            _lineItemRepo.GetByInvoice(invoice.Id);

        decimal total = 0m;
        foreach (var item in items)
            total += item.Amount;

        _invoiceRepo.FinalizeTotal(
            invoice.Id,
            total);
    }

    /// <summary>
    /// Retrieves an invoice by its ID.
    /// </summary>
    public Invoice GetInvoiceById(int invoiceId)
        => _invoiceRepo.GetById(invoiceId);

    /// <summary>
    /// Retrieves an invoice by rental ID, if one exists.
    /// </summary>
    public Invoice? GetInvoiceByRental(int rentalId)
        => _invoiceRepo.GetByRental(rentalId);

    // ---------------- PAYMENTS ----------------

    /// <summary>
    /// Adds a payment to an invoice.
    ///
    /// Automatically marks the invoice as paid when the balance reaches zero.
    /// </summary>
    /// <param name="invoiceId">Invoice ID</param>
    /// <param name="amount">Payment amount</param>
    /// <param name="method">Payment method</param>
    /// <param name="date">Payment date</param>
    /// <returns>The created payment ID</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when payment rules are violated
    /// </exception>
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

        // AUTO-LOCK ON FULL PAYMENT
        if (GetInvoiceBalance(invoiceId) == 0m)
            _invoiceRepo.MarkPaid(invoiceId);

        return paymentId;
    }

    /// <summary>
    /// Retrieves all payments made against an invoice.
    /// </summary>
    public List<Payment> GetPaymentsByInvoice(int invoiceId)
        => _paymentRepo.GetByInvoice(invoiceId);

    // ---------------- BALANCE ----------------

    /// <summary>
    /// Calculates the outstanding balance for an invoice.
    /// </summary>
    /// <param name="invoiceId">Invoice ID</param>
    /// <returns>Remaining unpaid balance</returns>
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
    
    public Invoice CreateInitialCharges(
        int rentalId,
        decimal initialRentalFee,
        decimal securityDeposit)
    {
        // Ensure rental is active (GetOrCreateInvoice already checks)
        var invoice = GetOrCreateInvoice(rentalId);

        // Prevent modifying a paid invoice
        if (invoice.Status == InvoiceStatus.Paid)
            throw new InvalidOperationException("Cannot add charges to a paid invoice.");

        // Add line items
        if (initialRentalFee > 0m)
            _lineItemRepo.Create(invoice.Id, "Initial rental fee", initialRentalFee);

        if (securityDeposit > 0m)
            _lineItemRepo.Create(invoice.Id, "Security deposit", securityDeposit);

        // Recompute total from line items and set on invoice
        var items = _lineItemRepo.GetByInvoice(invoice.Id);
        decimal total = 0m;
        foreach (var it in items) total += it.Amount;

        _invoiceRepo.FinalizeTotal(invoice.Id, total);

        // Return fresh invoice object
        return _invoiceRepo.GetById(invoice.Id);
    }


    /// <summary>
    /// Ensures that an invoice is editable.
    /// </summary>
    /// <param name="invoiceId">Invoice ID</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the invoice is already paid
    /// </exception>
    private void EnsureInvoiceEditable(int invoiceId)
    {
        var invoice = _invoiceRepo.GetById(invoiceId);

        if (invoice.Status == InvoiceStatus.Paid)
            throw new InvalidOperationException(
                "Cannot modify a paid invoice.");
    }
}
