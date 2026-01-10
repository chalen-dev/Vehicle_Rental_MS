using MySql.Data.MySqlClient;
using System.Data;

namespace VRMS.Database
{
    public static class DB
    {
        private static string? _connectionString;
        private static string? _databaseName;

        public static string DatabaseName =>
            _databaseName ?? throw new InvalidOperationException("DB.Initialize() was not called.");

        // -------------------------------------------------
        // INITIALIZATION
        // -------------------------------------------------

        public static void Initialize(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("Database connection string is missing.");

            var builder = new MySqlConnectionStringBuilder(connectionString);

            if (string.IsNullOrWhiteSpace(builder.Database))
                throw new InvalidOperationException("Database name is missing in connection string.");

            _databaseName = builder.Database;

            // Connect WITHOUT database first
            builder.Database = string.Empty;

            using (var conn = new MySqlConnection(builder.ConnectionString))
            using (var cmd = new MySqlCommand(
                $"CREATE DATABASE IF NOT EXISTS `{_databaseName}`;", conn))
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            // Restore database
            builder.Database = _databaseName;
            _connectionString = builder.ConnectionString;
        }

        private static MySqlConnection GetConnection()
        {
            if (_connectionString == null)
                throw new InvalidOperationException("DB.Initialize() was not called.");

            return new MySqlConnection(_connectionString);
        }

        // -------------------------------------------------
        // SAFE EXECUTION (DEFAULT)
        // -------------------------------------------------

        public static DataTable Query(
            string sql,
            params (string name, object? value)[] parameters
        )
        {
            using var conn = GetConnection();
            using var cmd = CreateCommand(conn, sql, parameters);
            using var adapter = new MySqlDataAdapter(cmd);

            var table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public static void Execute(
            string sql,
            params (string name, object? value)[] parameters
        )
        {
            using var conn = GetConnection();
            using var cmd = CreateCommand(conn, sql, parameters);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public static object? Scalar(
            string sql,
            params (string name, object? value)[] parameters
        )
        {
            using var conn = GetConnection();
            using var cmd = CreateCommand(conn, sql, parameters);

            conn.Open();
            return cmd.ExecuteScalar();
        }

        // -------------------------------------------------
        // UNSAFE ESCAPE HATCH (MIGRATIONS ONLY)
        // -------------------------------------------------

        /// <summary>
        /// ⚠️ USE ONLY FOR STATIC SQL (migrations, bootstrap).
        /// NEVER use with user input.
        /// </summary>
        public static void ExecuteRaw(string sql)
        {
            using var conn = GetConnection();
            using var cmd = new MySqlCommand(sql, conn);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public static DataTable QueryRaw(string sql)
        {
            using var conn = GetConnection();
            using var cmd = new MySqlCommand(sql, conn);
            using var adapter = new MySqlDataAdapter(cmd);

            var table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        // -------------------------------------------------
        // INTERNAL
        // -------------------------------------------------

        private static MySqlCommand CreateCommand(
            MySqlConnection conn,
            string sql,
            (string name, object? value)[] parameters
        )
        {
            var cmd = new MySqlCommand(sql, conn);

            foreach (var (name, value) in parameters)
                cmd.Parameters.AddWithValue(name, value ?? DBNull.Value);

            return cmd;
        }
    }
}
