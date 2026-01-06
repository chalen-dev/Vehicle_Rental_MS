using VRMS.Database.StoredProcedures.Accounts;

namespace VRMS.Database.Tables;

public static class M_0018_CreateUserProcedures
{
    public static string Create() => $"""
                                      DROP PROCEDURE IF EXISTS sp_users_create;
                                      DROP PROCEDURE IF EXISTS sp_users_get_by_id;
                                      DROP PROCEDURE IF EXISTS sp_users_get_by_username;
                                      DROP PROCEDURE IF EXISTS sp_users_authenticate;
                                      DROP PROCEDURE IF EXISTS sp_users_deactivate;

                                      {SP_Users_Create.Sql()}
                                      {SP_Users_GetById.Sql()}
                                      {SP_Users_GetByUsername.Sql()}
                                      {SP_Users_Authenticate.Sql()}
                                      {SP_Users_Deactivate.Sql()}
                                      """;

    public static string Drop() => """
                                   DROP PROCEDURE IF EXISTS sp_users_create;
                                   DROP PROCEDURE IF EXISTS sp_users_get_by_id;
                                   DROP PROCEDURE IF EXISTS sp_users_get_by_username;
                                   DROP PROCEDURE IF EXISTS sp_users_authenticate;
                                   DROP PROCEDURE IF EXISTS sp_users_deactivate;
                                   """;
}