using System.Reflection;
using VRMS.Database.Exceptions;
using VRMS.Database.Migrations.Tables;

namespace VRMS.Database.Executors;

public static class CreateExecutor
{
    public static void Execute(
        Action<string> executeRawSql,
        bool strictMode = true
    )
    {
        var assembly = Assembly.GetAssembly(
            typeof(M_0001_CreateSchemaInfoTable)
        ) ?? throw new InvalidOperationException(
            "Failed to locate tables assembly.");

        var tableTypes = assembly
            .GetTypes()
            .Where(t =>
                t.IsClass &&
                t.IsAbstract &&
                t.IsSealed &&
                t.Name.StartsWith("M_") &&
                t.GetMethod(
                    "Create",
                    BindingFlags.Public | BindingFlags.Static
                ) != null
            )
            .OrderBy(t => t.Name)
            .ToList();

        foreach (var type in tableTypes)
        {
            string sql = string.Empty;

            try
            {
                sql = ExecuteCreate(type, executeRawSql);
                Console.WriteLine($"[OK] {type.Name}");
            }
            catch (Exception ex)
            {
                HandleError(type, ex, strictMode, "create", sql);
            }
        }
    }

    // -------------------------------------------------
    // INTERNAL
    // -------------------------------------------------

    private static string ExecuteCreate(
        Type tableType,
        Action<string> executeRawSql
    )
    {
        var method = tableType.GetMethod(
            "Create",
            BindingFlags.Public | BindingFlags.Static
        ) ?? throw new InvalidOperationException(
            $"Create() not found on {tableType.Name}"
        );

        var result = method.Invoke(null, null)
            ?? throw new InvalidOperationException(
                $"Create() on {tableType.Name} returned null"
            );

        if (result is string singleSql)
        {
            executeRawSql(singleSql);
            return singleSql;
        }

        if (result is IEnumerable<string> multipleSql)
        {
            string last = string.Empty;

            foreach (var sql in multipleSql)
            {
                last = sql;
                executeRawSql(sql);
            }

            return last;
        }

        throw new InvalidOperationException(
            $"Create() on {tableType.Name} must return string or IEnumerable<string>"
        );
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
