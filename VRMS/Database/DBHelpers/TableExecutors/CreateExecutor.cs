using System;
using System.Reflection;
using VRMS.Database.Migrations;
using VRMS.Database.Migrations.Tables;

namespace VRMS.Database.DBHelpers.TableExecutors;

public static class CreateExecutor
{
    public static void Execute(
        Action<string> executeNonQuery,
        bool strictMode = true
    )
    {
        var assembly = Assembly.GetAssembly(typeof(M_0001_CreateSchemaInfoTable))
            ?? throw new InvalidOperationException("Failed to locate tables assembly.");

        var tableTypes = assembly
            .GetTypes()
            .Where(t =>
                t.IsClass &&
                t.IsAbstract &&
                t.IsSealed &&
                t.Name.StartsWith("M_") &&
                t.GetMethod("Create", BindingFlags.Public | BindingFlags.Static) != null
            )
            .OrderBy(t => t.Name) // ascending
            .ToList();

        foreach (var type in tableTypes)
        {
            string sql = string.Empty;

            try
            {
                sql = ExecuteMethod(type, "Create", executeNonQuery);
                Console.WriteLine($"[OK] {type.Name}");
            }
            catch (Exception ex)
            {
                HandleError(type, ex, strictMode, "create", sql);
            }
        }
    }

    private static string ExecuteMethod(
        Type tableType,
        string methodName,
        Action<string> executeNonQuery
    )
    {
        var method = tableType.GetMethod(
            methodName,
            BindingFlags.Public | BindingFlags.Static
        ) ?? throw new InvalidOperationException(
            $"{methodName}() not found on {tableType.Name}"
        );

        var result = method.Invoke(null, null)
                     ?? throw new InvalidOperationException(
                         $"{methodName}() on {tableType.Name} returned null"
                     );

        if (result is string singleSql)
        {
            // Tables (and legacy SPs)
            executeNonQuery(singleSql);
            return singleSql;
        }

        if (result is IEnumerable<string> multipleSql)
        {
            // Stored procedures (MySql.Data safe path)
            string last = string.Empty;

            foreach (var sql in multipleSql)
            {
                last = sql;
                executeNonQuery(sql);
            }

            return last;
        }

        throw new InvalidOperationException(
            $"{methodName}() on {tableType.Name} must return string or IEnumerable<string>"
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
        var root = ex is TargetInvocationException tie && tie.InnerException != null
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
