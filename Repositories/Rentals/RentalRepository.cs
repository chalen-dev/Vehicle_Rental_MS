using System.Data;
using VRMS.Database;
using VRMS.Enums;
using VRMS.Models.Rentals;

namespace VRMS.Repositories.Rentals;

public class RentalRepository
{
    // -------------------------------------------------
    // CREATE
    // -------------------------------------------------

    public int Create(
        int reservationId,
        DateTime pickupDate,
        DateTime expectedReturnDate,
        int startOdometer,
        FuelLevel startFuelLevel,
        RentalStatus status)
    {
        var table = DB.Query(
            "CALL sp_rentals_create(@rid,@pickup,@expected,@odo,@fuel,@status);",
            ("@rid", reservationId),
            ("@pickup", pickupDate),
            ("@expected", expectedReturnDate),
            ("@odo", startOdometer),
            ("@fuel", startFuelLevel.ToString()),
            ("@status", status.ToString())
        );

        return Convert.ToInt32(table.Rows[0]["rental_id"]);
    }

    public void MarkStarted(int rentalId)
    {
        DB.Execute(
            "CALL sp_rentals_start(@id);",
            ("@id", rentalId)
        );
    }

    // -------------------------------------------------
    // UPDATE
    // -------------------------------------------------

    public void Complete(
        int rentalId,
        DateTime actualReturnDate,
        int endOdometer,
        FuelLevel endFuelLevel)
    {
        DB.Execute(
            "CALL sp_rentals_complete(@id,@date,@odo,@fuel);",
            ("@id", rentalId),
            ("@date", actualReturnDate),
            ("@odo", endOdometer),
            ("@fuel", endFuelLevel.ToString())
        );
    }

    public void UpdateStatus(
        int rentalId,
        RentalStatus status)
    {
        DB.Execute(
            "CALL sp_rentals_update_status(@id,@status);",
            ("@id", rentalId),
            ("@status", status.ToString())
        );
    }

    // -------------------------------------------------
    // READ
    // -------------------------------------------------

    public Rental GetById(int rentalId)
    {
        var table = DB.Query(
            "CALL sp_rentals_get_by_id(@id);",
            ("@id", rentalId)
        );

        if (table.Rows.Count == 0)
            throw new InvalidOperationException(
                "Rental not found.");

        return Map(table.Rows[0]);
    }

    public Rental? GetByReservation(int reservationId)
    {
        var table = DB.Query(
            "CALL sp_rentals_get_by_reservation(@rid);",
            ("@rid", reservationId)
        );

        if (table.Rows.Count == 0)
            return null;

        return Map(table.Rows[0]);
    }
    
    public List<Rental> GetAll()
    {
        var rentals = new List<Rental>();

        var table = DB.Query(
            "CALL sp_rentals_get_all();");

        foreach (DataRow row in table.Rows)
        {
            rentals.Add(new Rental
            {
                Id = (int)row["id"],
                ReservationId = (int)row["reservation_id"],
                PickupDate = (DateTime)row["pickup_date"],
                ExpectedReturnDate = (DateTime)row["expected_return_date"],
                ActualReturnDate = row["actual_return_date"] as DateTime?,
                StartOdometer = (int)row["start_odometer"],
                EndOdometer = row["end_odometer"] as int?,
                Status = Enum.Parse<RentalStatus>(
                    row["status"].ToString()!)
            });
        }

        return rentals;
    }
    
    public List<(Rental rental, decimal? totalAmount)>
        GetByCustomer(int customerId)
    {
        var result = new List<(Rental, decimal?)>();

        var table = DB.Query(
            "CALL sp_rentals_get_by_customer(@cid);",
            ("@cid", customerId)
        );

        foreach (DataRow row in table.Rows)
        {
            var rental = Map(row);

            decimal? total =
                row["total_amount"] == DBNull.Value
                    ? null
                    : Convert.ToDecimal(row["total_amount"]);

            result.Add((rental, total));
        }

        return result;
    }



    // -------------------------------------------------
    // MAPPING
    // -------------------------------------------------

    private static Rental Map(DataRow row)
    {
        return new Rental
        {
            Id = Convert.ToInt32(row["id"]),
            ReservationId =
                Convert.ToInt32(row["reservation_id"]),
            PickupDate =
                Convert.ToDateTime(row["pickup_date"]),
            ExpectedReturnDate =
                Convert.ToDateTime(row["expected_return_date"]),
            ActualReturnDate =
                row["actual_return_date"] == DBNull.Value
                    ? null
                    : Convert.ToDateTime(row["actual_return_date"]),
            StartOdometer =
                Convert.ToInt32(row["start_odometer"]),
            EndOdometer =
                row["end_odometer"] == DBNull.Value
                    ? null
                    : Convert.ToInt32(row["end_odometer"]),
            StartFuelLevel =
                Enum.Parse<FuelLevel>(
                    row["start_fuel_level"].ToString()!, true),

            EndFuelLevel =
                row["end_fuel_level"] == DBNull.Value
                    ? null
                    : Enum.Parse<FuelLevel>(
                        row["end_fuel_level"].ToString()!, true),
            Status =
                Enum.Parse<RentalStatus>(
                    row["status"].ToString()!, true)
        };
    }
}
