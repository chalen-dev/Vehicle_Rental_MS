using VRMS.DTOs;
using VRMS.DTOs.Damage;
using VRMS.DTOs.Rental;
using VRMS.Enums;
using VRMS.Repositories.Damages;
using VRMS.Repositories.Inspections;
using VRMS.Repositories.Rentals;
using VRMS.Services.Billing;
using VRMS.Services.Fleet;

namespace VRMS.Services.Rental;

/// <summary>
/// Provides business logic for rental lifecycle management, including:
/// - Starting rentals from confirmed reservations
/// - Completing rentals and handling returns
/// - Enforcing vehicle state transitions
/// - Managing return inspections and damages
/// - Triggering final billing upon rental completion
///
/// This service orchestrates reservations, vehicles, inspections,
/// damages, and billing while enforcing strict state validation.
/// </summary>
public class RentalService
{
    // -------------------------------------------------
    // DEPENDENCIES
    // -------------------------------------------------

    private readonly ReservationService _reservationService;
    private readonly VehicleService _vehicleService;
    private readonly RentalRepository _rentalRepo;
    private readonly BillingService _billingService;

    private readonly VehicleInspectionRepository _inspectionRepo;
    private readonly DamageRepository _damageRepo;
    private readonly DamageReportRepository _damageReportRepo;

    // -------------------------------------------------
    // CONSTRUCTOR
    // -------------------------------------------------

    public RentalService(
        ReservationService reservationService,
        VehicleService vehicleService,
        RentalRepository rentalRepo,
        BillingService billingService,
        VehicleInspectionRepository inspectionRepo,
        DamageRepository damageRepo,
        DamageReportRepository damageReportRepo)
    {
        _reservationService = reservationService;
        _vehicleService = vehicleService;
        _rentalRepo = rentalRepo;
        _billingService = billingService;

        _inspectionRepo = inspectionRepo;
        _damageRepo = damageRepo;
        _damageReportRepo = damageReportRepo;
    }


    // -------------------------------------------------
    // START RENTAL (PICKUP)
    // -------------------------------------------------

    public int StartRental(
        int reservationId,
        DateTime pickupDate,
        FuelLevel startFuelLevel)
    {
        var reservation =
            _reservationService.GetReservationById(reservationId);

        if (reservation.Status != ReservationStatus.Confirmed)
            throw new InvalidOperationException(
                "Reservation must be confirmed before starting a rental.");

        if (pickupDate < reservation.StartDate)
            throw new InvalidOperationException(
                "Pickup date cannot be before reservation start date.");

        if (_rentalRepo.GetByReservation(reservationId) != null)
            throw new InvalidOperationException(
                "A rental already exists for this reservation.");

        var vehicle =
            _vehicleService.GetVehicleById(reservation.VehicleId);

        if (vehicle.Status != VehicleStatus.Reserved)
            throw new InvalidOperationException(
                "Vehicle must be reserved before starting rental.");

        var rentalId =
            _rentalRepo.Create(
                reservationId,
                pickupDate,
                reservation.EndDate,
                vehicle.Odometer,
                startFuelLevel,
                RentalStatus.Active);

        _rentalRepo.MarkStarted(rentalId);

        _vehicleService.UpdateVehicleStatus(
            reservation.VehicleId,
            VehicleStatus.Rented);

        return rentalId;
    }

    // -------------------------------------------------
    // RETURN INSPECTION
    // -------------------------------------------------

    /// <summary>
    /// Creates or retrieves a RETURN inspection for a rental.
    /// Ensures only one return inspection exists per rental.
    /// </summary>
    public int CreateOrGetReturnInspection(int rentalId)
    {
        var inspection =
            _inspectionRepo.GetByRental(
                rentalId,
                InspectionType.Return);

        if (inspection != null)
            return inspection.Id;

        return _inspectionRepo.Create(
            rentalId,
            InspectionType.Return,
            notes: "Return inspection",
            fuelLevel: string.Empty,
            cleanliness: string.Empty
        );
    }

    /// <summary>
    /// Retrieves damages linked to a specific vehicle inspection.
    /// Used by ReturnVehicleForm for damage listing.
    /// </summary>
    public IReadOnlyList<DamageDto> GetDamagesByInspectionId(
        int vehicleInspectionId)
    {
        var reports =
            _damageReportRepo.GetByInspection(vehicleInspectionId);

        var result = new List<DamageDto>();

        foreach (var report in reports)
        {
            var damage =
                _damageRepo.GetById(report.DamageId);

            result.Add(new DamageDto
            {
                Description = damage.Description,
                EstimatedCost = damage.EstimatedCost
            });
        }

        return result;
    }

    // -------------------------------------------------
    // COMPLETE RENTAL (RETURN)
    // -------------------------------------------------

    public void CompleteRental(
        int rentalId,
        DateTime actualReturnDate,
        int endOdometer,
        FuelLevel endFuelLevel)
    {
        // ---------------- VALIDATION ----------------

        var rental = _rentalRepo.GetById(rentalId);

        if (rental.Status != RentalStatus.Active)
            throw new InvalidOperationException(
                "Only active rentals can be returned.");

        if (actualReturnDate < rental.PickupDate)
            throw new InvalidOperationException(
                "Return date cannot be before pickup date.");

        if (endOdometer <= rental.StartOdometer)
            throw new InvalidOperationException(
                "End odometer must be greater than start odometer.");

        // ---------------- INVOICE (MUST EXIST FIRST) ----------------

        _billingService.GetOrCreateInvoice(rentalId);

        // ---------------- PERSIST RETURN DATA ----------------

        _rentalRepo.Complete(
            rentalId,
            actualReturnDate,
            endOdometer,
            endFuelLevel);

        // ---------------- STATUS TRANSITION ----------------

        _rentalRepo.UpdateStatus(
            rentalId,
            actualReturnDate > rental.ExpectedReturnDate
                ? RentalStatus.Late
                : RentalStatus.Completed);

        // ---------------- VEHICLE UPDATE ----------------

        var reservation =
            _reservationService.GetReservationById(
                rental.ReservationId);

        var vehicle =
            _vehicleService.GetVehicleById(
                reservation.VehicleId);

        _vehicleService.UpdateVehicle(
            vehicle.Id,
            vehicle.Color,
            endOdometer,
            vehicle.FuelEfficiency,
            vehicle.CargoCapacity,
            vehicle.VehicleCategoryId);

        _vehicleService.UpdateVehicleStatus(
            vehicle.Id,
            VehicleStatus.Available);

        // ---------------- FINALIZE BILLING ----------------

        _billingService.FinalizeInvoice(rentalId);
    }

    // -------------------------------------------------
    // READ
    // -------------------------------------------------

    public Models.Rentals.Rental GetRentalById(int rentalId)
        => _rentalRepo.GetById(rentalId);

    public IReadOnlyList<Models.Rentals.Rental> GetAllRentals()
        => _rentalRepo.GetAll();

    public Models.Rentals.Rental? GetRentalByReservation(
        int reservationId)
        => _rentalRepo.GetByReservation(reservationId);
    
    public IReadOnlyList<RentalHistoryRowDto>
        GetRentalHistoryForCustomer(int customerId)
    {
        var rentals = _rentalRepo.GetByCustomer(customerId);

        return rentals.Select(x => new RentalHistoryRowDto
        {
            RentalId = x.rental.Id,
            PickupDate = x.rental.PickupDate,
            ReturnDate = x.rental.ActualReturnDate,
            DurationDays =
                (int)((x.rental.ActualReturnDate
                       ?? x.rental.ExpectedReturnDate)
                      - x.rental.PickupDate).TotalDays,
            Status = x.rental.Status,
            TotalAmount = x.totalAmount
        }).ToList();
    }

}