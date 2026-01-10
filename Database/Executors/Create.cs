using System.Data;
using VRMS.Database.Migrations.Tables;

namespace VRMS.Database.Executors;

public static class Create
{
    public static void Run(
        Func<string, DataTable> queryRaw,
        Action<string> executeRawSql
    )
    {
        Console.WriteLine("\n[INFO] Running migrations.\n");

        // Ensure schema_info exists
        executeRawSql(M_0001_CreateSchemaInfoTable.Create());

        // Check if schema already initialized
        var table = queryRaw(
            M_0001_CreateSchemaInfoTable.CheckInitialized()
        );

        if (table.Rows.Count > 0 &&
            table.Rows[0][0] is bool initialized &&
            initialized)
        {
            return;
        }

        // Execute all table creates
        CreateExecutor.Execute(executeRawSql);

        // Mark schema as initialized
        executeRawSql(
            M_0001_CreateSchemaInfoTable.InsertInitial()
        );
    }
}