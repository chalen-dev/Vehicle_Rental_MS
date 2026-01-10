namespace VRMS.Database.StoredProcedures.Fleet.Vehicle;

public static class SP_Vehicles_UpdateOdometer
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_vehicles_update_odometer;

                                  CREATE PROCEDURE sp_vehicles_update_odometer (
                                      IN p_vehicle_id INT,
                                      IN p_odometer INT
                                  )
                                  BEGIN
                                      UPDATE vehicles
                                      SET odometer = p_odometer
                                      WHERE id = p_vehicle_id;
                                  END;
                                  """;
}