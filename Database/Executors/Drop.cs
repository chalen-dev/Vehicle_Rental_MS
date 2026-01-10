using VRMS.Database.Migrations.Tables;

namespace VRMS.Database.Executors;

public static class Drop
{
    public static void Run(Action<string> executeRawSql)
    {
        Console.WriteLine("\n[INFO] Dropping tables and stored procedures.\n");

        DropExecutor.Execute(executeRawSql);

        // Finally drop schema_info itself
        executeRawSql(M_0001_CreateSchemaInfoTable.Drop());
    }
}