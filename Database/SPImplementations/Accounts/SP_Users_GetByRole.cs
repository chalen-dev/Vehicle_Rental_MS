namespace VRMS.Database.SPImplementations.Accounts;

public static class SP_Users_GetByRole
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_users_get_by_role;

                                  CREATE PROCEDURE sp_users_get_by_role (
                                      IN p_role VARCHAR(50)
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
                                      WHERE role = p_role
                                      ORDER BY username;
                                  END;
                                  """;
}