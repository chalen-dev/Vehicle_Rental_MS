namespace VRMS.Database.StoredProcedures.Customers.DriversLicense;

public static class SP_DriversLicenses_Create
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_drivers_licenses_create;

                                  CREATE PROCEDURE sp_drivers_licenses_create (
                                      IN p_license_number VARCHAR(50),
                                      IN p_issue_date DATE,
                                      IN p_expiry_date DATE,
                                      IN p_issuing_country VARCHAR(50),
                                      IN p_photo_path VARCHAR(255)
                                  )
                                  BEGIN
                                      INSERT INTO drivers_licenses (
                                          license_number,
                                          issue_date,
                                          expiry_date,
                                          issuing_country,
                                          photo_path
                                      )
                                      VALUES (
                                          p_license_number,
                                          p_issue_date,
                                          p_expiry_date,
                                          p_issuing_country,
                                          p_photo_path
                                      );
                                  
                                      SELECT LAST_INSERT_ID() AS drivers_license_id;
                                  END;
                                  """;
}