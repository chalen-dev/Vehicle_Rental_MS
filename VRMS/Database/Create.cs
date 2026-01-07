using VRMS.Database.DBHelpers;
using VRMS.Database.DBHelpers.TableExecutors;
using VRMS.Database.Migrations;
using VRMS.Database.Migrations.Tables;

namespace VRMS.Database;

public static class Create
{
    public static void Run(
        Func<string, object?> executeScalar,
        Action<string> executeNonQuery)
    {
        Console.WriteLine("\n[INFO] Creating tables.\n");
        
        // Ensure schema_info exists
        executeNonQuery(M_0001_CreateSchemaInfoTable.Create());

        // Check if schema already initialized
        var result = executeScalar(M_0001_CreateSchemaInfoTable.CheckInitialized());

        if (result is bool initialized && initialized)
            return;

        // Auto-execute all table creates in order
        CreateExecutor.Execute(executeNonQuery);

        // Mark schema as initialized
        executeNonQuery(M_0001_CreateSchemaInfoTable.InsertInitial());
    }
}