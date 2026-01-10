using Microsoft.Extensions.DependencyInjection;
using VRMS.Services.Account;
using VRMS.Services.Vehicle;

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