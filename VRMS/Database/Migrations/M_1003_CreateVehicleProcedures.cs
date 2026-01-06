using VRMS.Database.StoredProcedures.Fleet.Vehicle;

namespace VRMS.Database.Migrations;

public static class M_0020_CreateVehicleProcedures
{
    public static string Create() => $"""
                                      DROP PROCEDURE IF EXISTS sp_vehicles_create;
                                      DROP PROCEDURE IF EXISTS sp_vehicles_get_by_id;
                                      DROP PROCEDURE IF EXISTS sp_vehicles_get_full;
                                      DROP PROCEDURE IF EXISTS sp_vehicles_get_all;
                                      DROP PROCEDURE IF EXISTS sp_vehicles_update;
                                      DROP PROCEDURE IF EXISTS sp_vehicles_update_status;
                                      DROP PROCEDURE IF EXISTS sp_vehicles_retire;

                                      {SP_Vehicles_Create.Sql()}
                                      {SP_Vehicles_GetById.Sql()}
                                      {SP_Vehicles_GetFull.Sql()}
                                      {SP_Vehicles_GetAll.Sql()}
                                      {SP_Vehicles_Update.Sql()}
                                      {SP_Vehicles_UpdateStatus.Sql()}
                                      {SP_Vehicles_Retire.Sql()}
                                      """;

    public static string Drop() => """
                                   DROP PROCEDURE IF EXISTS sp_vehicles_create;
                                   DROP PROCEDURE IF EXISTS sp_vehicles_get_by_id;
                                   DROP PROCEDURE IF EXISTS sp_vehicles_get_full;
                                   DROP PROCEDURE IF EXISTS sp_vehicles_get_all;
                                   DROP PROCEDURE IF EXISTS sp_vehicles_update;
                                   DROP PROCEDURE IF EXISTS sp_vehicles_update_status;
                                   DROP PROCEDURE IF EXISTS sp_vehicles_retire;
                                   """;
}