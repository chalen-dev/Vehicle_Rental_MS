using VRMS.Database.SPImplementations.Fleet.Vehicle;

namespace VRMS.Database.Migrations.StoredProcedures;

public static class M_1003_CreateVehicleProcedures
{
    public static string Create() => $"""
                                      {SP_Vehicles_Create.Sql()}
                                      {SP_Vehicles_GetById.Sql()}
                                      {SP_Vehicles_GetFull.Sql()}
                                      {SP_Vehicles_GetAll.Sql()}
                                      {SP_Vehicles_Search.Sql()}
                                      {SP_Vehicles_Update.Sql()}
                                      {SP_Vehicles_UpdateStatus.Sql()}
                                      {SP_Vehicles_Retire.Sql()}
                                      {SP_Vehicles_UpdateOdometer.Sql()}
                                      """;

    public static string Drop() => """
                                   DROP PROCEDURE IF EXISTS sp_vehicles_create;
                                   DROP PROCEDURE IF EXISTS sp_vehicles_get_by_id;
                                   DROP PROCEDURE IF EXISTS sp_vehicles_get_full;
                                   DROP PROCEDURE IF EXISTS sp_vehicles_get_all;
                                   DROP PROCEDURE IF EXISTS sp_vehicles_search;
                                   DROP PROCEDURE IF EXISTS sp_vehicles_update;
                                   DROP PROCEDURE IF EXISTS sp_vehicles_update_status;
                                   DROP PROCEDURE IF EXISTS sp_vehicles_retire;
                                   DROP PROCEDURE IF EXISTS sp_vehicles_update_odometer;
                                   """;
}