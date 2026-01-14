namespace VRMS.Database.SPImplementations.Damages.DamageReport;

public static class SP_DamageReports_GetApprovedByRental
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_damage_reports_get_approved_by_rental;

                                  CREATE PROCEDURE sp_damage_reports_get_approved_by_rental (
                                      IN p_rental_id INT
                                  )
                                  BEGIN
                                      SELECT
                                          dr.id AS id,
                                          d.description AS description,
                                          d.estimated_cost AS estimated_cost
                                      FROM damage_reports dr
                                      INNER JOIN damages d
                                          ON d.id = dr.damage_id
                                      INNER JOIN vehicle_inspections vi
                                          ON vi.id = dr.vehicle_inspection_id
                                      WHERE
                                          vi.rental_id = p_rental_id
                                          AND dr.approved = TRUE
                                      ORDER BY dr.id;
                                  END;
                                  """;
}