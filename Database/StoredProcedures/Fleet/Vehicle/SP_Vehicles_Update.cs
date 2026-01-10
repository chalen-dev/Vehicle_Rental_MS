namespace VRMS.Database.StoredProcedures.Fleet.Vehicle;

public static class SP_Vehicles_Update
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_vehicles_update;

                                  CREATE PROCEDURE sp_vehicles_update (
                                      IN p_vehicle_id INT,
                                      IN p_color VARCHAR(30),
                                      IN p_odometer INT,
                                      IN p_fuel_efficiency DECIMAL(5,2),
                                      IN p_cargo_capacity INT,
                                      IN p_vehicle_category_id INT
                                  )
                                  BEGIN
                                      UPDATE vehicles
                                      SET
                                          color = p_color,
                                          odometer = p_odometer,
                                          fuel_efficiency = p_fuel_efficiency,
                                          cargo_capacity = p_cargo_capacity,
                                          vehicle_category_id = p_vehicle_category_id
                                      WHERE id = p_vehicle_id;
                                  END;
                                  """;
}