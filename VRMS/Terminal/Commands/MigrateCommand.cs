using VRMS.Database;

namespace VRMS.Terminal.Commands;

public class MigrateCommand : ICommand
{
    public string Name { get; } = "migrate";
    public void Execute()
    {
        CreateTables.Run(DB.ExecuteScalar, DB.ExecuteNonQuery);
        MessageBox.Show("Database migrated successfully.");
    }
}