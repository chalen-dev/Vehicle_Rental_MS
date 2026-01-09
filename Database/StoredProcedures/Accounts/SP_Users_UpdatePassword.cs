namespace VRMS.Database.StoredProcedures.Accounts;

public static class SP_Users_UpdatePassword
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_users_update_password;

                                  CREATE PROCEDURE sp_users_update_password (
                                      IN p_user_id INT,
                                      IN p_password_hash VARCHAR(255)
                                  )
                                  BEGIN
                                      UPDATE users
                                      SET password_hash = p_password_hash
                                      WHERE id = p_user_id
                                        AND is_active = TRUE;
                                  END;
                                  """;
}