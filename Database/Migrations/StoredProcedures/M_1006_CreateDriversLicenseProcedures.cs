using VRMS.Database.StoredProcedures.Customers.DriversLicense;

namespace VRMS.Database.Migrations.StoredProcedures;

public static class M_1006_CreateDriversLicenseProcedures
{
    public static string Create() => $"""
                                      {SP_DriversLicenses_Create.Sql()}
                                      {SP_DriversLicenses_GetById.Sql()}
                                      {SP_DriversLicenses_GetByNumber.Sql()}
                                      {SP_DriversLicenses_Update.Sql()}
                                      {SP_DriversLicenses_Delete.Sql()}
                                      {SP_DriversLicenses_SetPhoto.Sql()}
                                      {SP_DriversLicenses_ResetPhoto.Sql()}
                                      """;

    public static string Drop() => """
                                   DROP PROCEDURE IF EXISTS sp_drivers_licenses_create;
                                   DROP PROCEDURE IF EXISTS sp_drivers_licenses_get_by_id;
                                   DROP PROCEDURE IF EXISTS sp_drivers_licenses_get_by_number;
                                   DROP PROCEDURE IF EXISTS sp_drivers_licenses_update;
                                   DROP PROCEDURE IF EXISTS sp_drivers_licenses_delete;
                                   DROP PROCEDURE IF EXISTS sp_drivers_licenses_set_photo;
                                   DROP PROCEDURE IF EXISTS sp_drivers_licenses_reset_photo;
                                   """;
}