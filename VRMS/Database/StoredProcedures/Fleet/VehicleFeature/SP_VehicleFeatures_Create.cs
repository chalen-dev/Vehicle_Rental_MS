namespace VRMS.Database.StoredProcedures.Fleet.VehicleFeature;

public static class SP_VehicleFeatures_Create
{
    public static string Sql() => """
                                  CREATE PROCEDURE sp_vehicle_features_create (
                                      IN p_name VARCHAR(50)
                                  )
                                  BEGIN
                                      INSERT INTO vehicle_features (name)
                                      VALUES (p_name);

                                      SELECT LAST_INSERT_ID() AS feature_id;
                                  END;
                                  """;
}