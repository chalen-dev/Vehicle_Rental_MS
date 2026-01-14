using VRMS.Database;
using VRMS.Database.Exceptions;
using VRMS.Database.Executors;
using VRMS.Helpers;

namespace VRMS.Terminal.Commands;

public class DropCommand : ICommand
{
    public string Name => "drop";

    public CommandResult Execute(string[] args)
    {
        try
        {
            Drop.Run(DB.ExecuteRaw);

            // ✅ Clean runtime Storage directory (bin/.../Storage)
            StorageCleaner.EmptyRuntimeStorage(".gitignore");

            return new CommandResult(
                true,
                "Database tables dropped and runtime storage cleaned successfully."
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
    }
}