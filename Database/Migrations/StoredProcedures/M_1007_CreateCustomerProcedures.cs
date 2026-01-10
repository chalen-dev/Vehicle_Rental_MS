using VRMS.Database.StoredProcedureImplementations.Customers.Customer;

namespace VRMS.Database.Migrations.StoredProcedures;

public static class M_1007_CreateCustomerProcedures
{
    public static string Create() => $"""
                                      {SP_Customers_Create.Sql()}
                                      {SP_Customers_GetById.Sql()}
                                      {SP_Customers_GetAll.Sql()}
                                      {SP_Customers_Update.Sql()}
                                      {SP_Customers_Delete.Sql()}
                                      {SP_Customers_SetPhoto.Sql()}
                                      {SP_Customers_ResetPhoto.Sql()}
                                      {SP_Customers_Update_No_Photo.Sql()}
                                      """;

    public static string Drop() => """
                                   DROP PROCEDURE IF EXISTS sp_customers_create;
                                   DROP PROCEDURE IF EXISTS sp_customers_get_by_id;
                                   DROP PROCEDURE IF EXISTS sp_customers_get_all;
                                   DROP PROCEDURE IF EXISTS sp_customers_update;
                                   DROP PROCEDURE IF EXISTS sp_customers_delete;
                                   DROP PROCEDURE IF EXISTS sp_customers_set_photo;
                                   DROP PROCEDURE IF EXISTS sp_customers_reset_photo;
                                   DROP PROCEDURE IF EXISTS sp_customers_update_no_photo;
                                   """;
}