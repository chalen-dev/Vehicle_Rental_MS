namespace VRMS.Database.SPImplementations.Accounts;

public static class SP_Users_GetAllActive
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_users_get_all_active;

                                  CREATE PROCEDURE sp_users_get_all_active ()
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
                                      WHERE is_active = TRUE
                                      ORDER BY username;
                                  END;
                                  """;
}