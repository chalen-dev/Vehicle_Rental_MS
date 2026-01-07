using VRMS.Database;

namespace VRMS.Terminal.Commands;

public class MigrateCommand : ICommand
{
    public string Name => "migrate";

    public CommandResult Execute()
    {
        try
        {
            Create.Run(DB.ExecuteScalar, DB.ExecuteNonQuery);
            return new CommandResult(true, "Database migrated successfully.");
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