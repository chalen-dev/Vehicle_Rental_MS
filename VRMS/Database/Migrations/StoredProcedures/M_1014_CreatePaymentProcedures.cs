using VRMS.Database.StoredProcedures.Billing.Payment;

namespace VRMS.Database.Migrations;

public static class M_1014_CreatePaymentProcedures
{
    public static string Create() => $"""
                                      {SP_Payments_Create.Sql()}
                                      {SP_Payments_GetById.Sql()}
                                      {SP_Payments_GetByInvoice.Sql()}
                                      """;

    public static string Drop() => """
                                   DROP PROCEDURE IF EXISTS sp_payments_create;
                                   DROP PROCEDURE IF EXISTS sp_payments_get_by_id;
                                   DROP PROCEDURE IF EXISTS sp_payments_get_by_invoice;
                                   """;
}