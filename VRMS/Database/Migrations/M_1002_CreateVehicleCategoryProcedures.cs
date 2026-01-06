using VRMS.Database.StoredProcedures.Fleet;
using VRMS.Database.StoredProcedures.Fleet.VehicleCategories;

namespace VRMS.Database.Tables;

public static class M_0019_CreateVehicleCategoryProcedures
{
    public static string Create() => $"""
                                      DROP PROCEDURE IF EXISTS sp_vehicle_categories_create;
                                      DROP PROCEDURE IF EXISTS sp_vehicle_categories_get_by_id;
                                      DROP PROCEDURE IF EXISTS sp_vehicle_categories_get_all;
                                      DROP PROCEDURE IF EXISTS sp_vehicle_categories_update;
                                      DROP PROCEDURE IF EXISTS sp_vehicle_categories_delete;

                                      {SP_VehicleCategories_Create.Sql()}
                                      {SP_VehicleCategories_GetById.Sql()}
                                      {SP_VehicleCategories_GetAll.Sql()}
                                      {SP_VehicleCategories_Update.Sql()}
                                      {SP_VehicleCategories_Delete.Sql()}
                                      """;

    public static string Drop() => """
                                   DROP PROCEDURE IF EXISTS sp_vehicle_categories_create;
                                   DROP PROCEDURE IF EXISTS sp_vehicle_categories_get_by_id;
                                   DROP PROCEDURE IF EXISTS sp_vehicle_categories_get_all;
                                   DROP PROCEDURE IF EXISTS sp_vehicle_categories_update;
                                   DROP PROCEDURE IF EXISTS sp_vehicle_categories_delete;
                                   """;
}