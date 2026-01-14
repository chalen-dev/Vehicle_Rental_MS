namespace VRMS.Database.SPImplementations.Fleet.MaintenanceRecord;

public static class SP_MaintenanceRecords_GetOverlapping
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_maintenance_records_get_overlapping;

                                  CREATE PROCEDURE sp_maintenance_records_get_overlapping (
                                      IN p_vehicle_id INT,
                                      IN p_start DATE,
                                      IN p_end DATE
                                  )
                                  BEGIN
                                      /* returns maintenance records that are Scheduled or InProgress
                                         and whose date range overlaps [p_start, p_end) */
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
                                        AND status IN (0,1) -- 0 = Scheduled, 1 = InProgress (enum ints)
                                        AND p_start < COALESCE(end_date, p_start)
                                        AND p_end > start_date;
                                  END;
                                  """;
}