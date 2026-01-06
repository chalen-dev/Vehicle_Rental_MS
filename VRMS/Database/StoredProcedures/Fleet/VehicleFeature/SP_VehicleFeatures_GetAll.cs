namespace VRMS.Database.StoredProcedures.Fleet.VehicleFeature;

public static class SP_VehicleFeatures_GetAll
{
    public static string Sql() => """
                                  CREATE PROCEDURE sp_vehicle_features_get_all ()
                                  BEGIN
                                      SELECT
                                          id,
                                          name
                                      FROM vehicle_features
                                      ORDER BY name;
                                  END;
                                  """;
}