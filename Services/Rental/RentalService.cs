using System.Data;
using VRMS.Database;
using VRMS.Enums;
using VRMS.Services.Vehicle;

namespace VRMS.Services.Rental;

public class RentalService
{
    private readonly ReservationService _reservationService;
    private readonly VehicleService _vehicleService;

    public RentalService(
        ReservationService reservationService,
        VehicleService vehicleService)
    {
        _reservationService = reservationService;
        _vehicleService = vehicleService;
    }

    // -------------------------------------------------
    // START RENTAL (PICKUP)
    // -------------------------------------------------

    public int StartRental(int reservationId, DateTime pickupDate)
    {
        var reservation = _reservationService.GetReservationById(reservationId);

        if (reservation.Status != ReservationStatus.Confirmed)
            throw new InvalidOperationException(
                "Reservation must be confirmed before starting a rental.");

        if (pickupDate < reservation.StartDate)
            throw new InvalidOperationException(
                "Pickup date cannot be before reservation start date.");

        var existing = GetRentalByReservation(reservationId);
        if (existing != null)
            throw new InvalidOperationException(
                "A rental already exists for this reservation.");

        var vehicle = _vehicleService.GetVehicleById(reservation.VehicleId);

        if (vehicle.Status != VehicleStatus.Reserved)
            throw new InvalidOperationException(
                "Vehicle must be reserved before starting rental.");

        var table = DB.Query(
            "CALL sp_rentals_create(@reservationId, @pickup, @expectedReturn, @startOdo, @status);",
            ("@reservationId", reservationId),
            ("@pickup", pickupDate),
            ("@expectedReturn", reservation.EndDate),
            ("@startOdo", vehicle.Odometer),
            ("@status", RentalStatus.Active.ToString())
        );

        int rentalId = Convert.ToInt32(table.Rows[0]["rental_id"]);

        DB.Execute(
            "CALL sp_rentals_start(@id);",
            ("@id", rentalId)
        );

        _vehicleService.UpdateVehicleStatus(
            reservation.VehicleId,
            VehicleStatus.Rented
        );

        return rentalId;
    }

    // -------------------------------------------------
    // COMPLETE RENTAL (RETURN)
    // -------------------------------------------------

    public void CompleteRental(
        int rentalId,
        DateTime actualReturnDate,
        int endOdometer)
    {
        var rental = GetRentalById(rentalId);

        if (rental.Status != RentalStatus.Active)
            throw new InvalidOperationException(
                "Only active rentals can be completed.");

        if (actualReturnDate < rental.PickupDate)
            throw new InvalidOperationException(
                "Return date cannot be before pickup date.");

        if (endOdometer <= rental.StartOdometer)
            throw new InvalidOperationException(
                "End odometer must be greater than start odometer.");

        DB.Execute(
            "CALL sp_rentals_complete(@id, @returnDate, @endOdo);",
            ("@id", rentalId),
            ("@returnDate", actualReturnDate),
            ("@endOdo", endOdometer)
        );

        bool isLate = actualReturnDate > rental.ExpectedReturnDate;

        if (isLate)
        {
            DB.Execute(
                "CALL sp_rentals_update_status(@id, @status);",
                ("@id", rentalId),
                ("@status", RentalStatus.Late.ToString())
            );
        }

        var reservation = _reservationService.GetReservationById(
            rental.ReservationId);

        var vehicle = _vehicleService.GetVehicleById(
            reservation.VehicleId);

        _vehicleService.UpdateVehicle(
            vehicleId: reservation.VehicleId,
            color: vehicle.Color,
            newOdometer: endOdometer,
            fuelEfficiency: vehicle.FuelEfficiency,
            cargoCapacity: vehicle.CargoCapacity,
            categoryId: vehicle.VehicleCategoryId
        );

        _vehicleService.UpdateVehicleStatus(
            reservation.VehicleId,
            VehicleStatus.Available
        );
    }

    // -------------------------------------------------
    // READ
    // -------------------------------------------------

    public Models.Rentals.Rental GetRentalById(int rentalId)
    {
        var table = DB.Query(
            "CALL sp_rentals_get_by_id(@id);",
            ("@id", rentalId)
        );

        if (table.Rows.Count == 0)
            throw new InvalidOperationException("Rental not found.");

        return MapRental(table.Rows[0]);
    }

    public Models.Rentals.Rental? GetRentalByReservation(int reservationId)
    {
        var table = DB.Query(
            "CALL sp_rentals_get_by_reservation(@reservationId);",
            ("@reservationId", reservationId)
        );

        if (table.Rows.Count == 0)
            return null;

        return MapRental(table.Rows[0]);
    }

    // -------------------------------------------------
    // MAPPING
    // -------------------------------------------------

    private static Models.Rentals.Rental MapRental(DataRow row)
    {
        return new Models.Rentals.Rental
        {
            Id = Convert.ToInt32(row["id"]),
            ReservationId = Convert.ToInt32(row["reservation_id"]),
            PickupDate = Convert.ToDateTime(row["pickup_date"]),
            ExpectedReturnDate = Convert.ToDateTime(row["expected_return_date"]),
            ActualReturnDate = row["actual_return_date"] == DBNull.Value
                ? null
                : Convert.ToDateTime(row["actual_return_date"]),
            StartOdometer = Convert.ToInt32(row["start_odometer"]),
            EndOdometer = row["end_odometer"] == DBNull.Value
                ? null
                : Convert.ToInt32(row["end_odometer"]),
            Status = Enum.Parse<RentalStatus>(
                row["status"].ToString()!, true)
        };
    }
}
