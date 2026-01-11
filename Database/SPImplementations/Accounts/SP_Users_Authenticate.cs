namespace VRMS.Database.SPImplementations.Accounts;

public static class SP_Users_Authenticate
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_users_authenticate;

                                  CREATE PROCEDURE sp_users_authenticate (
                                      IN p_username VARCHAR(50)
                                  )
                                  BEGIN
                                      SELECT
                                          id,
                                          username,
                                          password_hash,
                                          role,
                                          is_active,
                                          photo_path
                                      FROM users
                                      WHERE username = p_username
                                        AND is_active = TRUE;
                                  END;
                                  """;
}