namespace VRMS.Database.SPImplementations.Damages.DamageReport;

public static class SP_DamageReports_GetById
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_damage_reports_get_by_id;

                                  CREATE PROCEDURE sp_damage_reports_get_by_id (
                                      IN p_damage_report_id INT
                                  )
                                  BEGIN
                                      SELECT
                                          id,
                                          damage_id,
                                          photo_path,
                                          approved
                                      FROM damage_reports
                                      WHERE id = p_damage_report_id;
                                  
                                  END;
                                  """;
}