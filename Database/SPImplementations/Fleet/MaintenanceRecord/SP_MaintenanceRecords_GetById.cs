namespace VRMS.Database.SPImplementations.Fleet.MaintenanceRecord;

public static class SP_MaintenanceRecords_GetById
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_maintenance_records_get_by_id;

                                  CREATE PROCEDURE sp_maintenance_records_get_by_id (
                                      IN p_maintenance_record_id INT
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
                                      WHERE id = p_maintenance_record_id;
                                  
                                  END;
                                  """;
}