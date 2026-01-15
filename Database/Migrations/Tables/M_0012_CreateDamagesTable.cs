using VRMS.Database.DBHelpers.EnumHelper;
using VRMS.Enums;

namespace VRMS.Database.Migrations.Tables;

public static class M_0012_CreateDamagesTable
{
    public static string Create() => $"""
                                      CREATE TABLE IF NOT EXISTS damages (
                                          id INT AUTO_INCREMENT PRIMARY KEY,

                                          -- DAMAGE BELONGS TO A RENTAL
                                          rental_id INT NOT NULL,

                                          damage_type {Tbl.ToEnum<DamageType>()} NOT NULL,
                                          description TEXT NOT NULL,

                                          estimated_cost DECIMAL(10,2) NOT NULL DEFAULT 0.00,

                                          CONSTRAINT fk_damages_rental
                                              FOREIGN KEY (rental_id)
                                              REFERENCES rentals(id)
                                              ON DELETE CASCADE
                                      ) ENGINE=InnoDB;
                                      """;


    public static string Drop() => """
                                   DROP TABLE IF EXISTS damages;
                                   """;
}

