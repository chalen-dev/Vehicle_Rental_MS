namespace VRMS.Database.SPImplementations.Customers.EmergencyContactPhoneNumber;

public static class SP_EmergencyContactPhoneNumbers_Create
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_emergency_contact_phone_numbers_create;
                                  
                                  CREATE PROCEDURE sp_emergency_contact_phone_numbers_create (
                                      IN p_emergency_contact_id INT,
                                      IN p_phone_number VARCHAR(30),
                                      IN p_is_primary BOOLEAN
                                  )
                                  BEGIN
                                      -- If this number is marked primary, unset others first
                                      IF p_is_primary = TRUE THEN
                                          UPDATE emergency_contact_phone_numbers
                                          SET is_primary = FALSE
                                          WHERE emergency_contact_id = p_emergency_contact_id;
                                      END IF;
                                  
                                      INSERT INTO emergency_contact_phone_numbers (
                                          emergency_contact_id,
                                          phone_number,
                                          is_primary
                                      )
                                      VALUES (
                                          p_emergency_contact_id,
                                          p_phone_number,
                                          p_is_primary
                                      );
                                  
                                      SELECT LAST_INSERT_ID() AS phone_number_id;
                                  END;
                                  
                                  """;
}
