namespace VRMS.Database.Migrations.Tables;

public static class M_0017_CreateMaintenanceRecordsTable
{
    public static string Create() => """
                                     CREATE TABLE IF NOT EXISTS maintenance_records (
                                         id INT AUTO_INCREMENT PRIMARY KEY,
                                         vehicle_id INT NOT NULL,

                                         title VARCHAR(255) NOT NULL,
                                         description TEXT NOT NULL,

                                         type INT NOT NULL,
                                         status INT NOT NULL,

                                         start_date DATE NOT NULL,
                                         end_date DATE NULL,

                                         cost DECIMAL(10,2) NOT NULL,
                                         performed_by VARCHAR(255) NULL,

                                         created_at DATETIME NOT NULL,
                                         updated_at DATETIME NOT NULL,

                                         CONSTRAINT fk_maintenance_vehicle
                                             FOREIGN KEY (vehicle_id)
                                             REFERENCES vehicles(id)
                                             ON DELETE RESTRICT
                                     ) ENGINE=InnoDB;
                                     """;

    
    public static string Drop() => """
                                   DROP TABLE IF EXISTS maintenance_records;
                                   """;
}