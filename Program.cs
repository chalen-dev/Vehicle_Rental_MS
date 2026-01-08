using System;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using VRMS.Database;
using VRMS.Database.Executors;
using VRMS.Forms;
using VRMS.Terminal;

namespace VRMS
{
    internal static class Program
    {
        // Global session info (used by MainForm)
        public static string CurrentUsername { get; set; } = "Guest";
        public static string CurrentUserRole { get; set; } = "User";

        [STAThread]
        static void Main(string[] args)
        {
            // ----------------------------
            // Load configuration
            // ----------------------------
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var connectionString = config.GetConnectionString("Default");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    "Connection string 'Default' is missing in appsettings.json");
            }

            // ----------------------------
            // Initialize database
            // ----------------------------
            DB.Initialize(connectionString);

            // ----------------------------
            // Handle terminal commands
            // ----------------------------
            if (CommandDispatcher.TryExecute(args, out var result))
            {
                ApplicationConfiguration.Initialize();

                using var context = new ApplicationContext();

                Task.Run(() =>
                {
                    MessageBox.Show(
                        result!.Message,
                        result.Success ? "Success" : "Error",
                        MessageBoxButtons.OK,
                        result.Success
                            ? MessageBoxIcon.Information
                            : MessageBoxIcon.Error
                    );

                    context.ExitThread();
                });

                Application.Run(context);
                return;
            }

            //Uncomment for testing (Migration testing)
            //Drop.Run(DB.ExecuteNonQuery);
            //Create.Run(DB.ExecuteScalar, DB.ExecuteNonQuery);
            //return;

            // ----------------------------
            // Start WinForms UI
            // ----------------------------
            ApplicationConfiguration.Initialize();

            // IMPORTANT: Welcome is in namespace VRMS
            Application.Run(new Welcome());
        }
    }
}