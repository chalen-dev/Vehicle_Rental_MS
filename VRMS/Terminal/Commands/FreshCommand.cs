using VRMS.Database;

namespace VRMS.Terminal.Commands;

public class FreshCommand : ICommand
{
    public string Name => "fresh";

    public void Execute()
    {
        DropTables.Run(DB.ExecuteNonQuery);
        CreateTables.Run(DB.ExecuteScalar, DB.ExecuteNonQuery);
        MessageBox.Show("Database migrated fresh successfully.");
    }
}