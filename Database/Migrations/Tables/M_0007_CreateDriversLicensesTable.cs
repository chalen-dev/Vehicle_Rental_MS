namespace VRMS.Database.Migrations.Tables;

public static class M_0007_CreateDriversLicensesTable
{
    public static string Create() => """
                                     CREATE TABLE IF NOT EXISTS drivers_licenses (
                                         id INT AUTO_INCREMENT PRIMARY KEY,
                                         license_number VARCHAR(50) NOT NULL UNIQUE,
                                         issue_date DATE NOT NULL,
                                         expiry_date DATE NOT NULL,
                                         issuing_country VARCHAR(50) NOT NULL,
                                         photo_path VARCHAR(255) NULL
                                     );
                                     """;
    
    public static string Drop() => """
                                   DROP TABLE IF EXISTS drivers_licenses;
                                   """;
}