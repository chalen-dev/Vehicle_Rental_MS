using VRMS.Database;
using VRMS.Database.Exceptions;
using VRMS.Database.Executors;

namespace VRMS.Terminal.Commands;

public class DropCommand : ICommand
{
    public string Name => "drop";
    public CommandResult Execute()
    {
        try
        {
            Drop.Run(DB.ExecuteRaw);
            return new CommandResult(true, "Database tables dropped successfully.");
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
