namespace VRMS.Database.StoredProcedures.Fleet.VehicleFeature;

public static class SP_VehicleFeatures_GetById
{
    public static string Sql() => """
                                  CREATE PROCEDURE sp_vehicle_features_get_by_id (
                                      IN p_feature_id INT
                                  )
                                  BEGIN
                                      SELECT
                                          id,
                                          name
                                      FROM vehicle_features
                                      WHERE id = p_feature_id;
                                  END;
                                  """;
}