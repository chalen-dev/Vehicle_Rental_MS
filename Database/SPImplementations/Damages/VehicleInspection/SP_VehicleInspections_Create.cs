namespace VRMS.Database.SPImplementations.Damages.VehicleInspection;

public static class SP_VehicleInspections_Create
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_vehicle_inspections_create;

                                  CREATE PROCEDURE sp_vehicle_inspections_create (
                                      IN p_rental_id INT,
                                      IN p_inspection_type VARCHAR(50),
                                      IN p_notes TEXT,
                                      IN p_fuel_level VARCHAR(20),
                                      IN p_cleanliness VARCHAR(20)
                                  )
                                  BEGIN
                                      INSERT INTO vehicle_inspections (
                                          rental_id,
                                          inspection_type,
                                          notes,
                                          fuel_level,
                                          cleanliness
                                      )
                                      VALUES (
                                          p_rental_id,
                                          p_inspection_type,
                                          p_notes,
                                          p_fuel_level,
                                          p_cleanliness
                                      );

                                      SELECT LAST_INSERT_ID() AS inspection_id;
                                  END;
                                  """;
}