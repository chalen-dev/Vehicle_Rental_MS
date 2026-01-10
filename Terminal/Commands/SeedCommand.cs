using Microsoft.Extensions.DependencyInjection;
using VRMS.Database.Seeders;
using VRMS.Services.Account;
using VRMS.Services.Vehicle;

namespace VRMS.Terminal.Commands;

public class SeedCommand : ICommand
{
    public string Name => "seed";

    public CommandResult Execute(string[] args)
    {
        try
        {
            Console.WriteLine("\n[INFO] Running seeders.\n");
            
            var services = new ServiceCollection();
            SeederServiceRegistry.Register(services);

            var provider = services.BuildServiceProvider();
            SeederRunner.RunAll(provider);

            return new CommandResult(
                true,
                "Database seeded successfully."
            );
        }
        catch (Exception ex)
        {
            return new CommandResult(
                false,
                $"Seeding failed:\n{ex.Message}"
            );
        }
    }
}