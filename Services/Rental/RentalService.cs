using VRMS.Enums;
using VRMS.Repositories.Rentals;
using VRMS.Services.Billing;
using VRMS.Services.Fleet;

namespace VRMS.Services.Rental;

/// <summary>
/// Provides business logic for rental lifecycle management, including:
/// - Starting rentals from confirmed reservations
/// - Completing rentals and handling returns
/// - Enforcing vehicle state transitions
/// - Triggering final billing upon rental completion
///
/// This service orchestrates reservations, vehicles, and billing
/// while enforcing strict state validation.
/// </summary>
public class RentalService
{
    /// <summary>
    /// Reservation service used for reservation validation and lookup.
    /// </summary>
    private readonly ReservationService _reservationService;

    /// <summary>
    /// Vehicle service used for vehicle state and metadata management.
    /// </summary>
    private readonly VehicleService _vehicleService;

    /// <summary>
    /// Rental repository for persistence.
    /// </summary>
    private readonly RentalRepository _rentalRepo;

    /// <summary>
    /// Billing service responsible for final invoice calculation.
    /// </summary>
    private readonly BillingService _billingService;

    /// <summary>
    /// Initializes the rental service with required dependencies.
    /// </summary>
    public RentalService(
        ReservationService reservationService,
        VehicleService vehicleService,
        RentalRepository rentalRepo,
        BillingService billingService)
    {
        _reservationService = reservationService;
        _vehicleService = vehicleService;
        _rentalRepo = rentalRepo;
        _billingService = billingService;
    }

    // -------------------------------------------------
    // START RENTAL (PICKUP)
    // -------------------------------------------------

    /// <summary>
    /// Starts a rental based on a confirmed reservation.
    /// 
    /// This marks the vehicle as rented and creates an active rental record.
    /// </summary>
    /// <param name="reservationId">Reservation ID</param>
    /// <param name="pickupDate">Actual pickup date and time</param>
    /// <param name="startFuelLevel">Initial fuel level</param>
    /// <returns>Newly created rental ID</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when reservation or vehicle state is invalid
    /// </exception>
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
    // COMPLETE RENTAL (RETURN)
    // -------------------------------------------------

    /// <summary>
    /// Completes an active rental.
    ///
    /// This operation:
    /// - Validates return date and odometer
    /// - Updates rental status (completed or late)
    /// - Updates vehicle odometer and availability
    /// - Triggers final invoice calculation
    /// </summary>
    /// <param name="rentalId">Rental ID</param>
    /// <param name="actualReturnDate">Actual return date and time</param>
    /// <param name="endOdometer">Odometer reading at return</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown when rental state or input data is invalid
    /// </exception>
    public void CompleteRental(
        int rentalId,
        DateTime actualReturnDate,
        int endOdometer,
        FuelLevel endFuelLevel)
    {
        var rental =
            _rentalRepo.GetById(rentalId);

        if (rental.Status != RentalStatus.Active)
            throw new InvalidOperationException(
                "Only active rentals can be completed.");

        if (actualReturnDate < rental.PickupDate)
            throw new InvalidOperationException(
                "Return date cannot be before pickup date.");

        if (endOdometer <= rental.StartOdometer)
            throw new InvalidOperationException(
                "End odometer must be greater than start odometer.");

        _rentalRepo.Complete(
            rentalId,
            actualReturnDate,
            endOdometer,
            endFuelLevel);

        if (actualReturnDate > rental.ExpectedReturnDate)
        {
            _rentalRepo.UpdateStatus(
                rentalId,
                RentalStatus.Late);
        }

        var reservation =
            _reservationService.GetReservationById(
                rental.ReservationId);

        var vehicle =
            _vehicleService.GetVehicleById(
                reservation.VehicleId);

        _vehicleService.UpdateVehicle(
            vehicleId: reservation.VehicleId,
            color: vehicle.Color,
            newOdometer: endOdometer,
            fuelEfficiency: vehicle.FuelEfficiency,
            cargoCapacity: vehicle.CargoCapacity,
            categoryId: vehicle.VehicleCategoryId);

        _vehicleService.UpdateVehicleStatus(
            reservation.VehicleId,
            VehicleStatus.Available);

        _billingService.FinalizeInvoice(rentalId);
    }


    // -------------------------------------------------
    // READ
    // -------------------------------------------------

    /// <summary>
    /// Retrieves a rental by ID.
    /// </summary>
    public Models.Rentals.Rental GetRentalById(int rentalId)
        => _rentalRepo.GetById(rentalId);
    
    public IReadOnlyList<Models.Rentals.Rental> GetAllRentals()
    {
        return _rentalRepo.GetAll();
    }

    /// <summary>
    /// Retrieves a rental associated with a reservation, if any.
    /// </summary>
    public Models.Rentals.Rental? GetRentalByReservation(
        int reservationId)
        => _rentalRepo.GetByReservation(reservationId);
}
