using Microsoft.Extensions.DependencyInjection;
using VRMS.Repositories.Billing;
using VRMS.Repositories.Rentals;
using VRMS.Services.Account;
using VRMS.Services.Billing;
using VRMS.Services.Customer;
using VRMS.Services.Fleet;
using VRMS.Services.Rental;

namespace VRMS.Database.Seeders;

public static class SeederRunner
{
    public static void RunAll(IServiceProvider services, bool strictMode = true)
    {
        Console.WriteLine("\n[INFO] Running seeders.\n");
        var seeders = new ISeeder[]
        {
            //Seeder List
            new Users.UserSeeder(
                services.GetRequiredService<UserService>()
            ),
            new Vehicle.VehicleSeeder(
                services.GetRequiredService<VehicleService>()
            ),
            new Billing.RateSeeder(
                services.GetRequiredService<RateConfigurationRepository>(),
                services.GetRequiredService<VehicleService>()
            ),
            new Customer.CustomerSeeder(
                services.GetRequiredService<CustomerService>(),
                services.GetRequiredService<DriversLicenseService>()
            ),
            new Rentals.RentalSeeder(
            services.GetRequiredService<RentalRepository>(),
            services.GetRequiredService<VehicleService>(),
            services.GetRequiredService<CustomerService>(),
            services.GetRequiredService<BillingService>()
            )

        };

        foreach (var seeder in seeders)
        {
            try
            {
                seeder.Run();
                Console.WriteLine($"[OK] {seeder.Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] {seeder.Name}");
                Console.WriteLine($"        {ex.GetType().Name}: {ex.Message}");

                if (strictMode)
                    throw;
            }
        }
    }
}