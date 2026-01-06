using MySql.Data.MySqlClient;
using System.Data;

namespace VRMS.Database
{
    public static class DB
    {
        private static string? _connectionString;

        public static void Initialize(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("Database connection string is missing.");

            var builder = new MySqlConnectionStringBuilder(connectionString);

            if (string.IsNullOrWhiteSpace(builder.Database))
                throw new InvalidOperationException("Database name is missing in connection string.");

            string databaseName = builder.Database;

            // Connect WITHOUT database
            builder.Database = string.Empty;

            using (var conn = new MySqlConnection(builder.ConnectionString))
            using (var cmd = new MySqlCommand(
                $"CREATE DATABASE IF NOT EXISTS `{databaseName}`;", conn))
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            // Restore database and save final connection string
            builder.Database = databaseName;
            _connectionString = builder.ConnectionString;
        }

        private static MySqlConnection GetConnection()
        {
            if (_connectionString == null)
                throw new InvalidOperationException("DB.Initialize() was not called.");

            return new MySqlConnection(_connectionString);
        }

        public static void ExecuteNonQuery(string sql)
        {
            using var conn = GetConnection();
            using var cmd = new MySqlCommand(sql, conn);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public static object? ExecuteScalar(string sql)
        {
            using var conn = GetConnection();
            using var cmd = new MySqlCommand(sql, conn);

            conn.Open();
            return cmd.ExecuteScalar();
        }

        public static DataTable ExecuteQuery(string sql)
        {
            using var conn = GetConnection();
            using var cmd = new MySqlCommand(sql, conn);
            using var adapter = new MySqlDataAdapter(cmd);

            var table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
