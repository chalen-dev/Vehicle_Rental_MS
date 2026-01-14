namespace VRMS.Database.SPImplementations.Fleet.MaintenanceRecord;

public static class SP_MaintenanceRecords_Create
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_maintenance_records_create;
                                  
                                  CREATE PROCEDURE sp_maintenance_records_create (
                                      IN p_vehicle_id INT,
                                      IN p_title VARCHAR(255),
                                      IN p_description TEXT,
                                      IN p_type INT,
                                      IN p_status INT,
                                      IN p_start_date DATE,
                                      IN p_cost DECIMAL(10,2),
                                      IN p_performed_by VARCHAR(255)
                                  )
                                  BEGIN
                                      INSERT INTO maintenance_records (
                                          vehicle_id,
                                          title,
                                          description,
                                          type,
                                          status,
                                          start_date,
                                          cost,
                                          performed_by,
                                          created_at,
                                          updated_at
                                      )
                                      VALUES (
                                          p_vehicle_id,
                                          p_title,
                                          p_description,
                                          p_type,
                                          p_status,
                                          p_start_date,
                                          p_cost,
                                          p_performed_by,
                                          NOW(),
                                          NOW()
                                      );
                                  
                                      SELECT LAST_INSERT_ID() AS maintenance_record_id;
                                  END;
                                  
                                  """;
}