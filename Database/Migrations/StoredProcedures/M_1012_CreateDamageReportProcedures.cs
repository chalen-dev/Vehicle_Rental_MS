using VRMS.Database.StoredProcedureImplementations.Damages.DamageReport;

namespace VRMS.Database.Migrations;

public static class M_1012_CreateDamageReportProcedures
{
    public static string Create() => $"""
                                      {SP_DamageReports_Create.Sql()}
                                      {SP_DamageReports_GetById.Sql()}
                                      {SP_DamageReports_GetByInspection.Sql()}
                                      {SP_DamageReports_Approve.Sql()}
                                      {SP_DamageReports_SetPhoto.Sql()}
                                      {SP_DamageReports_ResetPhoto.Sql()}
                                      {SP_DamageReports_GetApprovedByRental.Sql()}
                                      """;

    public static string Drop() => """
                                   DROP PROCEDURE IF EXISTS sp_damage_reports_create;
                                   DROP PROCEDURE IF EXISTS sp_damage_reports_get_by_id;
                                   DROP PROCEDURE IF EXISTS sp_damage_reports_get_by_inspection;
                                   DROP PROCEDURE IF EXISTS sp_damage_reports_approve;
                                   DROP PROCEDURE IF EXISTS sp_damage_reports_set_photo;
                                   DROP PROCEDURE IF EXISTS sp_damage_reports_reset_photo;
                                   DROP PROCEDURE IF EXISTS sp_damage_reports_get_approved_by_rental;
                                   """;
}