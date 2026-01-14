namespace VRMS.Database.SPImplementations.Damages.VehicleInspection;

public static class SP_VehicleInspections_GetById
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_vehicle_inspections_get_by_id;

                                  CREATE PROCEDURE sp_vehicle_inspections_get_by_id (
                                      IN p_inspection_id INT
                                  )
                                  BEGIN
                                      SELECT
                                          id,
                                          rental_id,
                                          inspection_type,
                                          notes,
                                          fuel_level,
                                          cleanliness
                                      FROM vehicle_inspections
                                      WHERE id = p_inspection_id;
                                  END;
                                  """;
}