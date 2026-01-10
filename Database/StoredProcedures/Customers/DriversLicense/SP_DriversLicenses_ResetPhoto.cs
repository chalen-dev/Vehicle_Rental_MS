namespace VRMS.Database.StoredProcedures.Customers.DriversLicense;

public static class SP_DriversLicenses_ResetPhoto
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_drivers_licenses_reset_photo;

                                  CREATE PROCEDURE sp_drivers_licenses_reset_photo (
                                      IN p_license_id INT
                                  )
                                  BEGIN
                                      UPDATE drivers_licenses
                                      SET photo_path = 'Assets/img_placeholder.png'
                                      WHERE id = p_license_id;
                                  END;
                                  """;
}