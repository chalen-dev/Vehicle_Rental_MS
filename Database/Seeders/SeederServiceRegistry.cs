using Microsoft.Extensions.DependencyInjection;
using VRMS.Services.Account;
using VRMS.Services.Vehicle;

namespace VRMS.Database.Seeders;

public static class SeederServiceRegistry
{
    public static void Register(IServiceCollection services)
    {
        // Register all services required by seeders here
        services.AddSingleton<UserService>();
        services.AddSingleton<VehicleService>();

        // later:

    }
}