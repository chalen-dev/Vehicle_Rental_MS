using System.Reflection;
using VRMS.Database.Exceptions;
using VRMS.Database.Migrations.Tables;

namespace VRMS.Database.Executors;

public static class DropExecutor
{
    public static void Execute(
        Action<string> executeRawSql,
        bool strictMode = true
    )
    {
        var assembly = Assembly.GetAssembly(typeof(M_0001_CreateSchemaInfoTable))
            ?? throw new InvalidOperationException(
                "Failed to locate tables assembly.");

        var tableTypes = assembly
            .GetTypes()
            .Where(t =>
                t.IsClass &&
                t.IsAbstract &&
                t.IsSealed &&
                t.Name.StartsWith("M_") &&
                t.GetMethod(
                    "Drop",
                    BindingFlags.Public | BindingFlags.Static
                ) != null
            )
            .OrderByDescending(t => t.Name)
            .ToList();

        foreach (var type in tableTypes)
        {
            string sql = string.Empty;

            try
            {
                sql = ExecuteMethod(type, executeRawSql);
                Console.WriteLine($"[OK] {type.Name}");
            }
            catch (Exception ex)
            {
                HandleError(type, ex, strictMode, "drop", sql);
            }
        }
    }

    // -------------------------------------------------
    // INTERNAL
    // -------------------------------------------------

    private static string ExecuteMethod(
        Type tableType,
        Action<string> executeRawSql
    )
    {
        var method = tableType.GetMethod(
            "Drop",
            BindingFlags.Public | BindingFlags.Static
        ) ?? throw new InvalidOperationException(
            $"Drop() not found on {tableType.Name}"
        );

        var sql = method.Invoke(null, null) as string
            ?? throw new InvalidOperationException(
                $"Drop() on {tableType.Name} did not return SQL"
            );

        executeRawSql(sql);
        return sql;
    }

    private static void HandleError(
        Type type,
        Exception ex,
        bool strictMode,
        string action,
        string sql
    )
    {
        var root = ex is TargetInvocationException tie &&
                   tie.InnerException != null
            ? tie.InnerException
            : ex;

        Console.WriteLine($"[ERROR] {type.Name} ({action})");
        Console.WriteLine($"        {root.GetType().Name}: {root.Message}");

        if (strictMode)
        {
            throw new SchemaExecutionException(
                type.Name,
                action,
                sql,
                root
            );
        }
    }
}
