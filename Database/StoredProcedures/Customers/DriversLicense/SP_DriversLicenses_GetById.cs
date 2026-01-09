namespace VRMS.Database.StoredProcedures.Customers.DriversLicense;

public static class SP_DriversLicenses_GetById
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_drivers_licenses_get_by_id;

                                  CREATE PROCEDURE sp_drivers_licenses_get_by_id (
                                      IN p_license_id INT
                                  )
                                  BEGIN
                                      SELECT
                                      id,
                                      license_number,
                                      issue_date,
                                      expiry_date,
                                      issuing_country,
                                      photo_path
                                      FROM drivers_licenses
                                      WHERE id = p_license_id;
                                  END;
                                  """;
}