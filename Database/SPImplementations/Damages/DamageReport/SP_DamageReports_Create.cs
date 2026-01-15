namespace VRMS.Database.SPImplementations.Damages.DamageReport;

public static class SP_DamageReports_Create
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_damage_reports_create;

                                  CREATE PROCEDURE sp_damage_reports_create (
                                      IN p_damage_id INT
                                  )
                                  BEGIN
                                      INSERT INTO damage_reports (
                                          damage_id,
                                          approved
                                      )
                                      VALUES (
                                          p_damage_id,
                                          FALSE
                                      );

                                      SELECT LAST_INSERT_ID() AS damage_report_id;
                                  END;
                                  """;

}