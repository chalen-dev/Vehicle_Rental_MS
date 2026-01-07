namespace VRMS.Database.StoredProcedures.Fleet.VehicleImages;

public static class SP_VehicleImages_Delete
{
    public static string Sql() => """
                                  CREATE PROCEDURE sp_vehicle_images_delete (
                                      IN p_id INT
                                  )
                                  BEGIN
                                      DELETE FROM vehicle_images
                                      WHERE id = p_id;
                                  END;
                                  """;
}