using VRMS.Models.Billing;
using VRMS.Repositories.Billing;

namespace VRMS.Services.Billing;

/// <summary>
/// Provides authoritative rate and pricing calculations for rentals.
///
/// This service is responsible for:
/// - Base rental cost calculation (cheapest-rate logic)
/// - Late return penalties
/// - Mileage overage charges
///
/// All calculations performed here are FINAL and must not be overridden
/// by UI or repository layers.
/// </summary>
public class RateService
{
    /// <summary>
    /// Repository for retrieving rate configurations by vehicle category.
    /// </summary>
    private readonly RateConfigurationRepository _rateRepo;

    /// <summary>
    /// Initializes the rate service with its required repository.
    /// </summary>
    /// <param name="rateRepo">Rate configuration repository</param>
    public RateService(RateConfigurationRepository rateRepo)
    {
        _rateRepo = rateRepo;
    }

    // ---------------- BASE RENTAL ----------------

    /// <summary>
    /// Calculates the base rental cost for a rental period.
    ///
    /// Uses the cheapest combination of hourly, daily, weekly,
    /// and monthly rates based on the total rental duration.
    /// </summary>
    /// <param name="pickup">Pickup date and time</param>
    /// <param name="returnDate">Actual return date and time</param>
    /// <param name="vehicleCategoryId">Vehicle category identifier</param>
    /// <returns>Total base rental cost</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the return date is before the pickup date
    /// </exception>
    public decimal CalculateRentalCost(
        DateTime pickup,
        DateTime returnDate,
        int vehicleCategoryId)
    {
        if (returnDate < pickup)
            throw new InvalidOperationException(
                "Return date cannot be before pickup date.");

        var rate =
            _rateRepo.GetByCategory(vehicleCategoryId);

        return CalculateCheapest(
            pickup,
            returnDate,
            rate);
    }

    // ---------------- LATE PENALTY ----------------

    /// <summary>
    /// Calculates the late return penalty for a rental.
    ///
    /// Late time is rounded up to the nearest whole hour.
    /// No penalty is applied if the vehicle is returned on or before
    /// the expected return date.
    /// </summary>
    /// <param name="expectedReturn">Expected return date and time</param>
    /// <param name="actualReturn">Actual return date and time</param>
    /// <param name="vehicleCategoryId">Vehicle category identifier</param>
    /// <returns>Late return penalty amount</returns>
    public decimal CalculateLatePenalty(
        DateTime expectedReturn,
        DateTime actualReturn,
        int vehicleCategoryId)
    {
        if (actualReturn <= expectedReturn)
            return 0m;

        var rate =
            _rateRepo.GetByCategory(vehicleCategoryId);

        var lateDays =
            Math.Ceiling(
                (actualReturn - expectedReturn).TotalDays);

        return decimal.Round(
            (decimal)lateDays * rate.DailyRate,
            2);
    }

    // ---------------- MILEAGE OVERAGE ----------------

    /// <summary>
    /// Calculates mileage overage charges for a rental.
    ///
    /// Mileage allowance is calculated per rental day and compared
    /// against the actual distance traveled.
    /// </summary>
    /// <param name="startOdometer">Odometer reading at pickup</param>
    /// <param name="endOdometer">Odometer reading at return</param>
    /// <param name="pickup">Pickup date and time</param>
    /// <param name="returnDate">Return date and time</param>
    /// <param name="vehicleCategoryId">Vehicle category identifier</param>
    /// <returns>Mileage overage charge</returns>
    public decimal CalculateMileageOverage(
        int startOdometer,
        int endOdometer,
        DateTime pickup,
        DateTime returnDate,
        int vehicleCategoryId)
    {
        if (endOdometer <= startOdometer)
            return 0m;

        var rate =
            _rateRepo.GetByCategory(vehicleCategoryId);

        // Rental duration rounded up to full days
        var days =
            Math.Ceiling(
                (returnDate - pickup).TotalDays);

        var included =
            (decimal)days * rate.IncludedMileagePerDay;

        var actual =
            endOdometer - startOdometer;

        var excess =
            Math.Max(0m, actual - included);

        return decimal.Round(
            excess * rate.ExcessMileageRate,
            2);
    }

    // ---------------- INTERNAL ----------------

    /// <summary>
    /// Calculates the cheapest possible rental cost using
    /// hourly, daily, weekly, and monthly rates.
    ///
    /// This method enforces optimal pricing by selecting
    /// the minimum cost combination.
    /// </summary>
    /// <param name="start">Rental start date and time</param>
    /// <param name="end">Rental end date and time</param>
    /// <param name="rate">Rate configuration</param>
    /// <returns>Cheapest calculated rental cost</returns>
    private static decimal CalculateCheapest(
        DateTime start,
        DateTime end,
        RateConfiguration rate)
    {
        var totalDays =
            Math.Ceiling((end - start).TotalDays);

        if (totalDays <= 0)
            totalDays = 1; // minimum 1 day ALWAYS

        var weeks =
            Math.Floor(totalDays / 7d);

        var months =
            Math.Floor(totalDays / 30d);

        decimal best = decimal.MaxValue;

        // Daily pricing
        best = Math.Min(best,
            (decimal)totalDays * rate.DailyRate);

        // Weekly pricing + remaining days
        best = Math.Min(best,
            (decimal)weeks * rate.WeeklyRate +
            (decimal)(totalDays % 7d) * rate.DailyRate);

        // Monthly pricing + remaining weeks + days
        best = Math.Min(best,
            (decimal)months * rate.MonthlyRate +
            (decimal)Math.Floor((totalDays % 30d) / 7d)
            * rate.WeeklyRate +
            (decimal)((totalDays % 30d) % 7d)
            * rate.DailyRate);

        return decimal.Round(best, 2);
    }


}
