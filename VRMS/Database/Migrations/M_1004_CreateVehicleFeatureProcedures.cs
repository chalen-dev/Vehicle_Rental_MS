using VRMS.Database.StoredProcedures.Fleet.VehicleFeature;

namespace VRMS.Database.Migrations;

public static class M_1004_CreateVehicleFeatureProcedures
{
    public static string Create() => $"""
                                      DROP PROCEDURE IF EXISTS sp_vehicle_features_create;
                                      DROP PROCEDURE IF EXISTS sp_vehicle_features_get_by_id;
                                      DROP PROCEDURE IF EXISTS sp_vehicle_features_get_all;
                                      DROP PROCEDURE IF EXISTS sp_vehicle_features_update;
                                      DROP PROCEDURE IF EXISTS sp_vehicle_features_delete;

                                      {SP_VehicleFeatures_Create.Sql()}
                                      {SP_VehicleFeatures_GetById.Sql()}
                                      {SP_VehicleFeatures_GetAll.Sql()}
                                      {SP_VehicleFeatures_Update.Sql()}
                                      {SP_VehicleFeatures_Delete.Sql()}
                                      """;

    public static string Drop() => """
                                   DROP PROCEDURE IF EXISTS sp_vehicle_features_create;
                                   DROP PROCEDURE IF EXISTS sp_vehicle_features_get_by_id;
                                   DROP PROCEDURE IF EXISTS sp_vehicle_features_get_all;
                                   DROP PROCEDURE IF EXISTS sp_vehicle_features_update;
                                   DROP PROCEDURE IF EXISTS sp_vehicle_features_delete;
                                   """;
}