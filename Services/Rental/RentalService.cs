using VRMS.DTOs;
using VRMS.DTOs.Damage;
using VRMS.DTOs.Rental;
using VRMS.Enums;
using VRMS.Repositories.Damages;
using VRMS.Repositories.Inspections;
using VRMS.Repositories.Rentals;
using VRMS.Services.Billing;
using VRMS.Services.Customer;
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
    private readonly CustomerService _customerService;

    private readonly VehicleInspectionRepository _inspectionRepo;
    private readonly DamageRepository _damageRepo;
    private readonly DamageReportRepository _damageReportRepo;

    // -------------------------------------------------
    // CONSTRUCTOR
    // -------------------------------------------------

    public RentalService(
        ReservationService reservationService,
        VehicleService vehicleService,
        CustomerService customerService,   
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
        _customerService = customerService;
        _inspectionRepo = inspectionRepo;
        _damageRepo = damageRepo;
        _damageReportRepo = damageReportRepo;
    }
    
    public int StartRentalFromReservation(
        int reservationId,
        DateTime pickupDate,
        FuelLevel startFuelLevel)
    {
        var reservation =
            _reservationService.GetReservationById(reservationId);

        if (reservation.Status != ReservationStatus.Confirmed)
            throw new InvalidOperationException(
                "Reservation must be confirmed before starting rental.");


        if (_rentalRepo.GetByReservation(reservationId) != null)
            throw new InvalidOperationException("A rental already exists for this reservation.");

        var vehicle =
            _vehicleService.GetVehicleById(reservation.VehicleId);
        
        if (_vehicleService.HasOverlappingMaintenance(vehicle.Id, pickupDate, reservation.EndDate))
            throw new InvalidOperationException("Vehicle has scheduled or in-progress maintenance that overlaps the reservation period.");

        if (vehicle.Status != VehicleStatus.Reserved)
            throw new InvalidOperationException("Vehicle must be reserved.");

        var rentalId =
            _rentalRepo.Create(
                reservationId: reservation.Id,
                customerId: reservation.CustomerId,   
                vehicleId: vehicle.Id,
                pickupDate: pickupDate,
                expectedReturnDate: reservation.EndDate,
                startOdometer: vehicle.Odometer,
                startFuelLevel: startFuelLevel,
                status: RentalStatus.Active);

        _rentalRepo.MarkStarted(rentalId);
        _vehicleService.UpdateVehicleStatus(vehicle.Id, VehicleStatus.Rented);
        _reservationService
            .MarkReservationAsRented(reservation.Id);

        return rentalId;
    }



    
    public int StartWalkInRental(
        int customerId,
        int vehicleId,
        DateTime pickupDate,
        DateTime expectedReturnDate,
        FuelLevel startFuelLevel)
    {
        // Validate customer eligibility
        _customerService.EnsureCustomerCanRent(customerId, pickupDate);

        var vehicle = _vehicleService.GetVehicleById(vehicleId);

        // PROACTIVE: do not allow new rental when vehicle has scheduled/in-progress maintenance overlapping this rental.
        if (_vehicleService.HasOverlappingMaintenance(vehicleId, pickupDate, expectedReturnDate))
            throw new InvalidOperationException("Vehicle has scheduled or in-progress maintenance that overlaps the requested rental period.");

        // Existing status guard
        if (vehicle.Status != VehicleStatus.Available)
            throw new InvalidOperationException("Vehicle not available.");

        // WALK-IN RENTAL: NO reservation, BUT customer IS KNOWN
        var rentalId =
            _rentalRepo.Create(
                reservationId: null,          // NO reservation
                customerId: customerId,       // THIS IS THE FIX
                vehicleId: vehicleId,
                pickupDate: pickupDate,
                expectedReturnDate: expectedReturnDate,
                startOdometer: vehicle.Odometer,
                startFuelLevel: startFuelLevel,
                status: RentalStatus.Active);

        _rentalRepo.MarkStarted(rentalId);
        _vehicleService.UpdateVehicleStatus(vehicleId, VehicleStatus.Rented);

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
    /// Retrieves a vehicle inspection by id (thin wrapper).
    /// </summary>
    public Models.Damages.VehicleInspection GetInspectionById(int inspectionId)
        => _inspectionRepo.GetById(inspectionId);

    /// <summary>
    /// Persist updates to a return inspection (notes, fuel level, cleanliness).
    /// Thin wrapper to repository, used by the UI.
    /// </summary>
    public void UpdateReturnInspection(
        int inspectionId,
        string notes,
        string fuelLevel,
        string cleanliness)
    {
        // Basic validation (defensive)
        if (inspectionId <= 0)
            throw new InvalidOperationException("Invalid inspection id.");

        _inspectionRepo.Update(inspectionId, notes ?? string.Empty, fuelLevel ?? string.Empty, cleanliness ?? string.Empty);
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
    
    public void CancelRental(int rentalId)
    {
        _rentalRepo.UpdateStatus(
            rentalId,
            RentalStatus.Cancelled
        );
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

        var vehicle =
            _vehicleService.GetVehicleById(
                rental.VehicleId);


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