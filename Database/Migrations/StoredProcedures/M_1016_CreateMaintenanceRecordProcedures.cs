using VRMS.Database.SPImplementations.Fleet.MaintenanceRecord;

namespace VRMS.Database.Migrations;

public static class M_1016_CreateMaintenanceRecordProcedures
{
    public static string Create() => $"""
                                      {SP_MaintenanceRecords_Create.Sql()}
                                      {SP_MaintenanceRecords_GetById.Sql()}
                                      {SP_MaintenanceRecords_GetByVehicle.Sql()}
                                      {SP_MaintenanceRecords_Close.Sql()}
                                      {SP_MaintenanceRecords_GetOverlapping.Sql()}
                                      """;

    public static string Drop() => """
                                   DROP PROCEDURE IF EXISTS sp_maintenance_records_create;
                                   DROP PROCEDURE IF EXISTS sp_maintenance_records_get_by_id;
                                   DROP PROCEDURE IF EXISTS sp_maintenance_records_get_by_vehicle;
                                   DROP PROCEDURE IF EXISTS sp_maintenance_records_close;
                                   DROP PROCEDURE IF EXISTS sp_maintenance_records_get_overlapping;
                                   """;
}