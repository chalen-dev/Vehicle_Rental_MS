namespace VRMS.Database.StoredProcedures.Fleet.VehicleImages;

public static class SP_VehicleImages_GetByVehicleId
{
    public static string Sql() => """
                                  CREATE PROCEDURE sp_vehicle_images_get_by_vehicle_id (
                                      IN p_vehicle_id INT
                                  )
                                  BEGIN
                                      SELECT
                                          id,
                                          vehicle_id,
                                          image_path
                                      FROM vehicle_images
                                      WHERE vehicle_id = p_vehicle_id;
                                  END;
                                  """;
}