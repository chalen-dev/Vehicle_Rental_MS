using Microsoft.Extensions.Configuration;
using VRMS.Database;
using VRMS.Terminal;

namespace VRMS;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        
        // Configure Database
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .Build();
        
        //Get Connection String
        var connectionString = config.GetConnectionString("Default");
    
        //Validate Connection String
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new InvalidOperationException(
                "Connection string 'Default' is missing in appsettings.json");

        DB.Initialize(connectionString);
        
        //Run Project Commands
        if (CommandDispatcher.TryExecute(args))
            return;
        
        ApplicationConfiguration.Initialize();
    }
}