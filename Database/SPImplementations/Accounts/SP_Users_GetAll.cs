namespace VRMS.Database.SPImplementations.Accounts;

public static class SP_Users_GetAll
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_users_get_all;

                                  CREATE PROCEDURE sp_users_get_all ()
                                  BEGIN
                                      SELECT
                                          id,
                                          username,
                                          full_name,
                                          email,
                                          phone,
                                          password_hash,
                                          role,
                                          is_active,
                                          photo_path
                                      FROM users
                                      ORDER BY username;
                                  END;
                                  """;
}