namespace VRMS.Database.Migrations;

public static class M_0018_CreateVehicleFeatureMappingsTable
{
    public static string Create() => """
                                     CREATE TABLE IF NOT EXISTS vehicle_feature_mappings (
                                         vehicle_id INT NOT NULL,
                                         feature_id INT NOT NULL,

                                         PRIMARY KEY (vehicle_id, feature_id),

                                         CONSTRAINT fk_vfm_vehicle
                                             FOREIGN KEY (vehicle_id)
                                             REFERENCES vehicles(id)
                                             ON DELETE CASCADE,

                                         CONSTRAINT fk_vfm_feature
                                             FOREIGN KEY (feature_id)
                                             REFERENCES vehicle_features(id)
                                             ON DELETE CASCADE
                                     ) ENGINE=InnoDB;
                                     """;

    public static string Drop() => """
                                   DROP TABLE IF EXISTS vehicle_feature_mappings;
                                   """;
}