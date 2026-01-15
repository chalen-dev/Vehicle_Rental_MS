namespace VRMS.Database.Migrations.Tables;

public static class M_0016_CreateRateConfigurationsTable
{
    public static string Create() => """
                                     CREATE TABLE IF NOT EXISTS rate_configurations (
                                         id INT AUTO_INCREMENT PRIMARY KEY,
                                         vehicle_category_id INT NOT NULL UNIQUE,
                                         daily_rate DECIMAL(10,2) NOT NULL,
                                         weekly_rate DECIMAL(10,2) NOT NULL,
                                         monthly_rate DECIMAL(10,2) NOT NULL,
                                         included_mileage_per_day DECIMAL(10,2) NOT NULL,
                                         excess_mileage_rate DECIMAL(10,2) NOT NULL,

                                         CONSTRAINT fk_rates_category
                                             FOREIGN KEY (vehicle_category_id)
                                             REFERENCES vehicle_categories(id)
                                             ON DELETE RESTRICT
                                     ) ENGINE=InnoDB;
                                     """;
    
    public static string Drop() => """
                                   DROP TABLE IF EXISTS rate_configurations;
                                   """;
}