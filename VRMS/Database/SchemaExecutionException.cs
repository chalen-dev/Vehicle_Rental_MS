namespace VRMS.Database;

public sealed class SchemaExecutionException : Exception
{
    public string TableName { get; }
    public string Action { get; }
    public string Sql { get; }

    public SchemaExecutionException(
        string tableName,
        string action,
        string sql,
        Exception innerException
    ) : base(
        $"Schema {action} failed at {tableName}: {innerException.Message}",
        innerException
    )
    {
        TableName = tableName;
        Action = action;
        Sql = sql;
    }
}