namespace VRMS.Database.SPImplementations.Damages.VehicleInspection;

public static class SP_VehicleInspections_Update
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_vehicle_inspections_update;

                                  CREATE PROCEDURE sp_vehicle_inspections_update (
                                      IN p_inspection_id INT,
                                      IN p_notes TEXT,
                                      IN p_fuel_level VARCHAR(20),
                                      IN p_cleanliness VARCHAR(20)
                                  )
                                  BEGIN
                                      UPDATE vehicle_inspections
                                      SET
                                          notes = p_notes,
                                          fuel_level = p_fuel_level,
                                          cleanliness = p_cleanliness
                                      WHERE id = p_inspection_id;
                                  END;
                                  """;
}