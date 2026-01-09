using System;
using System.Collections.Generic;
using System.Data;
using VRMS.Database;
using VRMS.Enums;
using VRMS.Models.Rentals;

namespace VRMS.Services;

public class ReservationService
{
    private readonly CustomerService _customerService;
    private readonly VehicleService _vehicleService;

    public ReservationService(
        CustomerService customerService,
        VehicleService vehicleService)
    {
        _customerService = customerService;
        _vehicleService = vehicleService;
    }

    // -------------------------------------------------
    // CREATE
    // -------------------------------------------------

    public int CreateReservation(
        int customerId,
        int vehicleId,
        DateTime startDate,
        DateTime endDate)
    {
        if (startDate >= endDate)
            throw new InvalidOperationException("Start date must be before end date.");

        // Customer eligibility
        _customerService.EnsureCustomerCanRent(customerId, startDate);

        // Vehicle eligibility
        var vehicle = _vehicleService.GetVehicleById(vehicleId);

        if (vehicle.Status != VehicleStatus.Available)
            throw new InvalidOperationException("Vehicle is not available for reservation.");

        // Overlap check
        EnsureNoOverlap(vehicleId, startDate, endDate);

        var table = DB.ExecuteQuery($"""
            CALL sp_reservations_create(
                {customerId},
                {vehicleId},
                '{startDate:yyyy-MM-dd HH:mm:ss}',
                '{endDate:yyyy-MM-dd HH:mm:ss}',
                '{ReservationStatus.Pending}'
            );
        """);

        return Convert.ToInt32(table.Rows[0]["reservation_id"]);
    }

    // -------------------------------------------------
    // CONFIRM / CANCEL
    // -------------------------------------------------

    public void ConfirmReservation(int reservationId)
    {
        var reservation = GetReservationById(reservationId);

        EnsureStatusTransition(reservation.Status, ReservationStatus.Confirmed);

        // Re-check overlap before confirming
        EnsureNoOverlap(
            reservation.VehicleId,
            reservation.StartDate,
            reservation.EndDate,
            reservation.Id
        );

        // Lock vehicle
        _vehicleService.UpdateVehicleStatus(
            reservation.VehicleId,
            VehicleStatus.Reserved
        );

        UpdateReservationStatus(reservationId, ReservationStatus.Confirmed);
    }

    public void CancelReservation(int reservationId)
    {
        var reservation = GetReservationById(reservationId);

        EnsureStatusTransition(reservation.Status, ReservationStatus.Cancelled);

        DB.ExecuteNonQuery(
            $"CALL sp_reservations_cancel({reservationId});"
        );

        // Release vehicle only if no other active reservations exist
        if (reservation.Status == ReservationStatus.Confirmed)
        {
            if (!HasActiveReservations(reservation.VehicleId, reservationId))
            {
                _vehicleService.UpdateVehicleStatus(
                    reservation.VehicleId,
                    VehicleStatus.Available
                );
            }
        }
    }

    // -------------------------------------------------
    // READ
    // -------------------------------------------------

    public Reservation GetReservationById(int reservationId)
    {
        var table = DB.ExecuteQuery(
            $"CALL sp_reservations_get_by_id({reservationId});"
        );

        if (table.Rows.Count == 0)
            throw new InvalidOperationException("Reservation not found.");

        return MapReservation(table.Rows[0]);
    }

    public List<Reservation> GetReservationsByCustomer(int customerId)
    {
        var table = DB.ExecuteQuery(
            $"CALL sp_reservations_get_by_customer({customerId});"
        );

        return MapReservations(table);
    }

    public List<Reservation> GetReservationsByVehicle(int vehicleId)
    {
        var table = DB.ExecuteQuery(
            $"CALL sp_reservations_get_by_vehicle({vehicleId});"
        );

        return MapReservations(table);
    }

    // -------------------------------------------------
    // INTERNAL HELPERS
    // -------------------------------------------------

    private void UpdateReservationStatus(int reservationId, ReservationStatus status)
    {
        DB.ExecuteNonQuery($"""
            CALL sp_reservations_update_status(
                {reservationId},
                '{status}'
            );
        """);
    }

    private void EnsureStatusTransition(
        ReservationStatus current,
        ReservationStatus next)
    {
        bool valid = current switch
        {
            ReservationStatus.Pending =>
                next is ReservationStatus.Confirmed
                    or ReservationStatus.Cancelled,

            ReservationStatus.Confirmed =>
                next is ReservationStatus.Cancelled,

            ReservationStatus.Cancelled => false,

            _ => false
        };

        if (!valid)
            throw new InvalidOperationException(
                $"Illegal reservation status transition: {current} → {next}"
            );
    }

    private void EnsureNoOverlap(
        int vehicleId,
        DateTime start,
        DateTime end,
        int? ignoreReservationId = null)
    {
        var reservations = GetReservationsByVehicle(vehicleId);

        foreach (var r in reservations)
        {
            if (ignoreReservationId.HasValue && r.Id == ignoreReservationId.Value)
                continue;

            if (r.Status == ReservationStatus.Cancelled)
                continue;

            bool overlaps =
                start < r.EndDate &&
                end > r.StartDate;

            if (overlaps)
                throw new InvalidOperationException(
                    "Reservation overlaps with an existing reservation."
                );
        }
    }

    private bool HasActiveReservations(int vehicleId, int excludingReservationId)
    {
        var reservations = GetReservationsByVehicle(vehicleId);

        foreach (var r in reservations)
        {
            if (r.Id == excludingReservationId)
                continue;

            if (r.Status is ReservationStatus.Pending or ReservationStatus.Confirmed)
                return true;
        }

        return false;
    }

    private static Reservation MapReservation(DataRow row)
    {
        return new Reservation
        {
            Id = Convert.ToInt32(row["id"]),
            CustomerId = Convert.ToInt32(row["customer_id"]),
            VehicleId = Convert.ToInt32(row["vehicle_id"]),
            StartDate = Convert.ToDateTime(row["start_date"]),
            EndDate = Convert.ToDateTime(row["end_date"]),
            Status = Enum.Parse<ReservationStatus>(
                row["status"].ToString()!, true)
        };
    }

    private static List<Reservation> MapReservations(DataTable table)
    {
        var list = new List<Reservation>();

        foreach (DataRow row in table.Rows)
            list.Add(MapReservation(row));

        return list;
    }
}
