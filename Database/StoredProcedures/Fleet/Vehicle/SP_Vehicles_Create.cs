namespace VRMS.Database.StoredProcedures.Fleet.Vehicle;

public static class SP_Vehicles_Create
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_vehicles_create;

                                  CREATE PROCEDURE sp_vehicles_create (
                                      IN p_vehicle_code VARCHAR(50),
                                      IN p_make VARCHAR(50),
                                      IN p_model VARCHAR(50),
                                      IN p_year INT,
                                      IN p_color VARCHAR(30),
                                      IN p_license_plate VARCHAR(20),
                                      IN p_vin VARCHAR(50),
                                      IN p_transmission VARCHAR(50),
                                      IN p_fuel_type VARCHAR(50),
                                      IN p_status VARCHAR(50),
                                      IN p_seating_capacity INT,
                                      IN p_odometer INT,
                                      IN p_fuel_efficiency DECIMAL(5,2),
                                      IN p_cargo_capacity INT,
                                      IN p_vehicle_category_id INT
                                  )
                                  BEGIN
                                      INSERT INTO vehicles (
                                          vehicle_code,
                                          make,
                                          model,
                                          year,
                                          color,
                                          license_plate,
                                          vin,
                                          transmission,
                                          fuel_type,
                                          status,
                                          seating_capacity,
                                          odometer,
                                          fuel_efficiency,
                                          cargo_capacity,
                                          vehicle_category_id
                                      )
                                      VALUES (
                                          p_vehicle_code,
                                          p_make,
                                          p_model,
                                          p_year,
                                          p_color,
                                          p_license_plate,
                                          p_vin,
                                          p_transmission,
                                          p_fuel_type,
                                          p_status,
                                          p_seating_capacity,
                                          p_odometer,
                                          p_fuel_efficiency,
                                          p_cargo_capacity,
                                          p_vehicle_category_id
                                      );

                                      SELECT LAST_INSERT_ID() AS vehicle_id;
                                  END;
                                  """;
}
