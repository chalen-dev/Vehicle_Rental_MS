namespace VRMS.Database.StoredProcedures.Fleet.VehicleFeature;

public static class SP_VehicleFeatures_Update
{
    public static string Sql() => """
                                  CREATE PROCEDURE sp_vehicle_features_update (
                                      IN p_feature_id INT,
                                      IN p_name VARCHAR(50)
                                  )
                                  BEGIN
                                      UPDATE vehicle_features
                                      SET name = p_name
                                      WHERE id = p_feature_id;
                                  END;
                                  """;
}