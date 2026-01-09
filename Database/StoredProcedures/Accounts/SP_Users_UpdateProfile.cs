namespace VRMS.Database.StoredProcedures.Accounts;

public static class SP_Users_UpdateProfile
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_users_update_profile;

                                  CREATE PROCEDURE sp_users_update_profile (
                                      IN p_user_id INT,
                                      IN p_username VARCHAR(50),
                                      IN p_role VARCHAR(50),
                                      IN p_is_active BOOLEAN
                                  )
                                  BEGIN
                                      UPDATE users
                                      SET
                                          username = p_username,
                                          role = p_role,
                                          is_active = p_is_active
                                      WHERE id = p_user_id;
                                  END;
                                  """;
}