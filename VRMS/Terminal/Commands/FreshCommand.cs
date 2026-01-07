using VRMS.Database;

namespace VRMS.Terminal.Commands;

public class FreshCommand : ICommand
{
    public string Name => "fresh";

    public CommandResult Execute()
    {
        try
        {
            Drop.Run(DB.ExecuteNonQuery);
            Create.Run(DB.ExecuteScalar, DB.ExecuteNonQuery);
            return new CommandResult(true, "Database migrated fresh successfully.");
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