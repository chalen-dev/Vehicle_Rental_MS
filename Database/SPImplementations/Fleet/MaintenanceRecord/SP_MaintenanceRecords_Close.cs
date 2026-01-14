namespace VRMS.Database.SPImplementations.Fleet.MaintenanceRecord;

public static class SP_MaintenanceRecords_Close
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_maintenance_records_close;
                                  
                                  CREATE PROCEDURE sp_maintenance_records_close (
                                      IN p_maintenance_record_id INT,
                                      IN p_end_date DATE,
                                      IN p_status INT
                                  )
                                  BEGIN
                                      UPDATE maintenance_records
                                      SET
                                          end_date = p_end_date,
                                          status = p_status,
                                          updated_at = NOW()
                                      WHERE id = p_maintenance_record_id;
                                  END;
                                  
                                  """;
}