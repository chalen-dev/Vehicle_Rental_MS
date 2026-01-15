using System;
using VRMS.Database.Seeders;
using VRMS.Repositories.Billing;
using VRMS.Services.Fleet;

namespace VRMS.Database.Seeders.Billing;

public class RateSeeder : ISeeder
{
    public string Name => nameof(RateSeeder);

    private readonly RateConfigurationRepository _rateRepo;
    private readonly VehicleService _vehicleService;

    public RateSeeder(
        RateConfigurationRepository rateRepo,
        VehicleService vehicleService)
    {
        _rateRepo = rateRepo;
        _vehicleService = vehicleService;
    }

    public void Run()
    {
        var categories = _vehicleService.GetAllCategories();

        foreach (var category in categories)
        {
            // Safe idempotent seed
            if (RateExists(category.Id))
            {
                Console.WriteLine(
                    $"    [SKIP] Rates already exist for {category.Name}");
                continue;
            }

            var rates = GetDefaults(category.Name);

            _rateRepo.Create(
                category.Id,
                rates.Daily,
                rates.Weekly,
                rates.Monthly,
                rates.IncludedMileage,
                rates.ExcessMileage
            );

            Console.WriteLine(
                $"    Seeded rates for {category.Name}");
        }
    }

    // --------------------------------------
    // HELPERS
    // --------------------------------------

    private bool RateExists(int categoryId)
    {
        try
        {
            _rateRepo.GetByCategory(categoryId);
            return true;
        }
        catch
        {
            return false;
        }
    }

    private static RateDefaults GetDefaults(string categoryName)
    {
        return categoryName.ToLower() switch
        {
            var s when s.Contains("sedan") => new RateDefaults
            {
                Daily = 2000m,
                Weekly = 13000m,
                Monthly = 50000m,
                IncludedMileage = 100m,
                ExcessMileage = 8m
            },

            var s when s.Contains("mpv") => new RateDefaults
            {
                Daily = 3000m,
                Weekly = 19500m,
                Monthly = 72000m,
                IncludedMileage = 100m,
                ExcessMileage = 9m
            },

            var s when s.Contains("suv") => new RateDefaults
            {
                Daily = 3500m,
                Weekly = 22750m,
                Monthly = 87500m,
                IncludedMileage = 100m,
                ExcessMileage = 10m
            },

            var s when s.Contains("van") => new RateDefaults
            {
                Daily = 4000m,
                Weekly = 26000m,
                Monthly = 100000m,
                IncludedMileage = 120m,
                ExcessMileage = 12m
            },

            var s when s.Contains("pickup") => new RateDefaults
            {
                Daily = 3800m,
                Weekly = 24700m,
                Monthly = 95000m,
                IncludedMileage = 120m,
                ExcessMileage = 11m
            },

            _ => new RateDefaults
            {
                Daily = 2200m,
                Weekly = 14000m,
                Monthly = 55000m,
                IncludedMileage = 100m,
                ExcessMileage = 8m
            }
        };
    }

    private sealed class RateDefaults
    {
        public decimal Daily { get; init; }
        public decimal Weekly { get; init; }
        public decimal Monthly { get; init; }
        public decimal IncludedMileage { get; init; }
        public decimal ExcessMileage { get; init; }
    }
}
