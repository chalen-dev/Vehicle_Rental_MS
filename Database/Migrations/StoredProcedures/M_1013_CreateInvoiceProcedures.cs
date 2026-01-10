using VRMS.Database.StoredProcedureImplementations.Billing.Invoice;

namespace VRMS.Database.Migrations;

public static class M_1013_CreateInvoiceProcedures
{
    public static string Create() => $"""
                                      {SP_Invoices_Create.Sql()}
                                      {SP_Invoices_GetById.Sql()}
                                      {SP_Invoices_GetByRental.Sql()}
                                      {SP_Invoices_Finalize.Sql()}
                                      {SP_Invoices_MarkPaid.Sql()}
                                      """;

    public static string Drop() => """
                                   DROP PROCEDURE IF EXISTS sp_invoices_create;
                                   DROP PROCEDURE IF EXISTS sp_invoices_get_by_id;
                                   DROP PROCEDURE IF EXISTS sp_invoices_get_by_rental;
                                   DROP PROCEDURE IF EXISTS sp_invoices_finalize;
                                   DROP PROCEDURE IF EXISTS sp_invoices_mark_paid;
                                   """;
}