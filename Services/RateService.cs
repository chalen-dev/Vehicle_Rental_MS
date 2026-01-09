using System;
using VRMS.Models.Billing;

namespace VRMS.Services;

public class RateService
{
    private readonly RentalService _rentalService;
    private readonly ReservationService _reservationService;
    private readonly VehicleService _vehicleService;
    private readonly BillingService _billingService;

    public RateService(
        RentalService rentalService,
        ReservationService reservationService,
        VehicleService vehicleService,
        BillingService billingService)
    {
        _rentalService = rentalService;
        _reservationService = reservationService;
        _vehicleService = vehicleService;
        _billingService = billingService;
    }

    // -------------------------------------------------
    // PUBLIC API
    // -------------------------------------------------

    public decimal CalculateRentalCost(int rentalId)
    {
        var rental = _rentalService.GetRentalById(rentalId);

        var endDate = rental.ActualReturnDate ?? rental.ExpectedReturnDate;
        if (endDate < rental.PickupDate)
            throw new InvalidOperationException("Invalid rental duration.");

        var reservation = _reservationService.GetReservationById(rental.ReservationId);
        var vehicle = _vehicleService.GetVehicleById(reservation.VehicleId);

        var rate = _billingService.GetRateConfigurationByCategory(
            vehicle.VehicleCategoryId
        );

        return CalculateCheapestCost(
            rental.PickupDate,
            endDate,
            rate
        );
    }

    // -------------------------------------------------
    // PRICING ALGORITHM
    // -------------------------------------------------

    private static decimal CalculateCheapestCost(
        DateTime start,
        DateTime end,
        RateConfiguration rate)
    {
        var totalHours = (decimal)(end - start).TotalHours;
        if (totalHours <= 0)
            return 0m;

        // Round UP hours
        totalHours = Math.Ceiling(totalHours);

        var days = Math.Ceiling(totalHours / 24m);
        var weeks = Math.Floor(days / 7m);
        var months = Math.Floor(days / 30m);

        decimal best = decimal.MaxValue;

        // Hourly only
        best = Math.Min(best, totalHours * rate.HourlyRate);

        // Daily only
        best = Math.Min(best, days * rate.DailyRate);

        // Weekly + daily
        best = Math.Min(
            best,
            weeks * rate.WeeklyRate +
            (days % 7m) * rate.DailyRate
        );

        // Monthly + weekly + daily
        best = Math.Min(
            best,
            months * rate.MonthlyRate +
            ((days % 30m) / 7m) * rate.WeeklyRate +
            ((days % 30m) % 7m) * rate.DailyRate
        );

        return decimal.Round(best, 2);
    }
}
