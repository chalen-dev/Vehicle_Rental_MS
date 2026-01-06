namespace VRMS.Database.StoredProcedures.Fleet.VehicleFeature;

public static class SP_VehicleFeatures_Delete
{
    public static string Sql() => """
                                  CREATE PROCEDURE sp_vehicle_features_delete (
                                      IN p_feature_id INT
                                  )
                                  BEGIN
                                      DELETE FROM vehicle_features
                                      WHERE id = p_feature_id;
                                  END;
                                  """;
}