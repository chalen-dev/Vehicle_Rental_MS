using Microsoft.Extensions.DependencyInjection;
using VRMS.Database;
using VRMS.Database.Exceptions;
using VRMS.Database.Executors;
using VRMS.Database.Seeders;
using VRMS.Services.Account;

namespace VRMS.Terminal.Commands;

public class FreshCommand : ICommand
{
    public string Name => "fresh";

    public CommandResult Execute(string[] args)
    {
        try
        {
            //Drop and Migrate
            Drop.Run(DB.ExecuteRaw);
            Create.Run(DB.QueryRaw, DB.ExecuteRaw);

            //Register services for seeder use
            var services = new ServiceCollection();
            SeederServiceRegistry.Register(services);

            //Run seeders
            var provider = services.BuildServiceProvider();
            SeederRunner.RunAll(provider);

            return new CommandResult(
                true,
                "Database migrated and seeded successfully."
            );
        }
        catch (SchemaExecutionException ex)
        {
            return new CommandResult(
                false,
                $"""
                 Migration failed.

                 Table: {ex.TableName}
                 Action: {ex.Action}

                 Error:
                 {ex.InnerException?.Message}

                 SQL:
                 {ex.Sql}
                 """
            );
        }
        catch (Exception ex)
        {
            return new CommandResult(
                false,
                $"Fresh failed:\n{ex.Message}"
            );
        }
    }
}