namespace VRMS.Database.SPImplementations.Customers.EmergencyContactPhoneNumber;

public static class SP_EmergencyContactPhoneNumbers_Update
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_emergency_contact_phone_numbers_update;
                                  
                                  CREATE PROCEDURE sp_emergency_contact_phone_numbers_update (
                                      IN p_phone_number_id INT,
                                      IN p_phone_number VARCHAR(30),
                                      IN p_is_primary BOOLEAN
                                  )
                                  BEGIN
                                      DECLARE v_contact_id INT;
                                  
                                      -- Get owning contact
                                      SELECT emergency_contact_id
                                      INTO v_contact_id
                                      FROM emergency_contact_phone_numbers
                                      WHERE id = p_phone_number_id;
                                  
                                      -- If promoting to primary, demote others first
                                      IF p_is_primary = TRUE THEN
                                          UPDATE emergency_contact_phone_numbers
                                          SET is_primary = FALSE
                                          WHERE emergency_contact_id = v_contact_id;
                                      END IF;
                                  
                                      UPDATE emergency_contact_phone_numbers
                                      SET
                                          phone_number = p_phone_number,
                                          is_primary   = p_is_primary
                                      WHERE id = p_phone_number_id;
                                  END;
                                  """;
}