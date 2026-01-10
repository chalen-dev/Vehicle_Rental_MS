using VRMS.Enums;

namespace VRMS.Database.StoredProcedureImplementations.Billing.Invoice;

public static class SP_Invoices_MarkPaid
{
    public static string Sql() => $"""
                                  DROP PROCEDURE IF EXISTS sp_invoices_mark_paid;

                                  CREATE PROCEDURE sp_invoices_mark_paid (
                                      IN p_invoice_id INT
                                  )
                                  BEGIN
                                      UPDATE invoices
                                      SET status = {InvoiceStatus.Paid}
                                      WHERE id = p_invoice_id;
                                  END;
                                  """;
}