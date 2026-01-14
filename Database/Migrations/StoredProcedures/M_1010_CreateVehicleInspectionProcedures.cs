using VRMS.Database.SPImplementations.Damages.VehicleInspection;

namespace VRMS.Database.Migrations;

public static class M_1010_CreateVehicleInspectionProcedures
{
    public static string Create() => $"""
                                      {SP_VehicleInspections_Create.Sql()}
                                      {SP_VehicleInspections_GetById.Sql()}
                                      {SP_VehicleInspections_GetByRental.Sql()}
                                      """;

    public static string Drop() => """
                                   DROP PROCEDURE IF EXISTS sp_vehicle_inspections_create;
                                   DROP PROCEDURE IF EXISTS sp_vehicle_inspections_get_by_id;
                                   DROP PROCEDURE IF EXISTS sp_vehicle_inspections_get_by_rental;
                                   """;
}