using VRMS.Database.StoredProcedures.Accounts;

namespace VRMS.Database.Migrations.StoredProcedures;

public static class M_1001_CreateUserProcedures
{
    public static string Create() => $"""
                                      {SP_Users_Create.Sql()}
                                      {SP_Users_GetById.Sql()}
                                      {SP_Users_GetByUsername.Sql()}
                                      {SP_Users_Authenticate.Sql()}
                                      {SP_Users_Deactivate.Sql()}
                                      {SP_Users_UpdatePassword.Sql()}
                                      {SP_Users_UpdateProfile.Sql()}
                                      """;

    public static string Drop() => """
                                   DROP PROCEDURE IF EXISTS sp_users_create;
                                   DROP PROCEDURE IF EXISTS sp_users_get_by_id;
                                   DROP PROCEDURE IF EXISTS sp_users_get_by_username;
                                   DROP PROCEDURE IF EXISTS sp_users_authenticate;
                                   DROP PROCEDURE IF EXISTS sp_users_deactivate;
                                   DROP PROCEDURE IF EXISTS sp_users_update_password;
                                   DROP PROCEDURE IF EXISTS sp_users_update_profile;
                                   """;
}