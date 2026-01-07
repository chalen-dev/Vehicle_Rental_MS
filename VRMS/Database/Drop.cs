using VRMS.Database.DBHelpers.TableExecutors;
using VRMS.Database.Migrations;
using VRMS.Database.Migrations.Tables;

namespace VRMS.Database;

public static class Drop
{
    public static void Run(Action<string> executeNonQuery)
    {
        Console.WriteLine("\n[INFO] Dropping tables.\n");
        // Drop all tables in reverse order
        DropExecutor.Execute(executeNonQuery);

        // Finally drop schema_info itself
        executeNonQuery(M_0001_CreateSchemaInfoTable.Drop());
    }
}