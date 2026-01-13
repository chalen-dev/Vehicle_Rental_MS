namespace VRMS.Database.SPImplementations.Customers.EmergencyContactPhoneNumber;

public static class SP_EmergencyContactPhoneNumbers_GetByEmergencyContactId
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_emergency_contact_phone_numbers_get_by_contact_id;

                                  CREATE PROCEDURE sp_emergency_contact_phone_numbers_get_by_contact_id (
                                      IN p_emergency_contact_id INT
                                  )
                                  BEGIN
                                      SELECT
                                          id,
                                          emergency_contact_id,
                                          phone_number,
                                          is_primary
                                      FROM emergency_contact_phone_numbers
                                      WHERE emergency_contact_id = p_emergency_contact_id;
                                  END;
                                  """;
}