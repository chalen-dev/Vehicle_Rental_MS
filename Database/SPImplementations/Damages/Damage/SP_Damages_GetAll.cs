namespace VRMS.Database.SPImplementations.Damages.Damage;

public static class SP_Damages_GetAll
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_damages_get_all;

                                  CREATE PROCEDURE sp_damages_get_all ()
                                  BEGIN
                                      SELECT
                                          id,
                                          rental_id,
                                          damage_type,
                                          description,
                                          estimated_cost
                                      FROM damages
                                      WHERE id = p_damage_id;
                                  END;
                                  """;
}