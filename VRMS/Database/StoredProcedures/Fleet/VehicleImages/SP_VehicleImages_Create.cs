namespace VRMS.Database.StoredProcedures.Fleet.VehicleImages;

public static class SP_VehicleImages_Create
{
    public static string Sql() => """
                                  CREATE PROCEDURE sp_vehicle_images_create (
                                      IN p_vehicle_id INT,
                                      IN p_image_path VARCHAR(255)
                                  )
                                  BEGIN
                                      INSERT INTO vehicle_images (vehicle_id, image_path)
                                      VALUES (p_vehicle_id, p_image_path);
                                  END;
                                  """;
}