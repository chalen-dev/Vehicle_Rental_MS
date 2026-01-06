using VRMS.Database;

namespace VRMS.Terminal.Commands;

public class DropCommand : ICommand
{
    public string Name => "drop";

    public void Execute()
    {
        DropTables.Run(DB.ExecuteNonQuery);
        MessageBox.Show("Tables dropped successfully.");
    }
}