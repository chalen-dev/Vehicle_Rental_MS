namespace VRMS.Database.SPImplementations.Accounts;

public static class SP_Users_GetPage
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_users_get_page;

                                  CREATE PROCEDURE sp_users_get_page (
                                      IN p_offset INT,
                                      IN p_limit INT
                                  )
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
                                      ORDER BY username
                                      LIMIT p_limit OFFSET p_offset;
                                  END;
                                  """;
}