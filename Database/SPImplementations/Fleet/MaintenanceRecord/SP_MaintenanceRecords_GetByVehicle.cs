namespace VRMS.Database.SPImplementations.Fleet.MaintenanceRecord;

public static class SP_MaintenanceRecords_GetByVehicle
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_maintenance_records_get_by_vehicle;

                                  CREATE PROCEDURE sp_maintenance_records_get_by_vehicle (
                                      IN p_vehicle_id INT
                                  )
                                  BEGIN
                                      SELECT
                                          id,
                                          vehicle_id,
                                          title,
                                          description,
                                          type,
                                          status,
                                          start_date,
                                          end_date,
                                          cost,
                                          performed_by,
                                          created_at,
                                          updated_at
                                      FROM maintenance_records
                                      WHERE vehicle_id = p_vehicle_id
                                      ORDER BY start_date DESC;
                                  END;
                                  """;
}