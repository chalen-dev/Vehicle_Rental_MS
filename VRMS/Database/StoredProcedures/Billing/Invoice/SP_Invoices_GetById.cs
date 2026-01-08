namespace VRMS.Database.StoredProcedures.Billing.Invoice;

public static class SP_Invoices_GetById
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_invoices_get_by_id;

                                  CREATE PROCEDURE sp_invoices_get_by_id (
                                      IN p_invoice_id INT
                                  )
                                  BEGIN
                                      SELECT
                                          id,
                                          rental_id,
                                          total_amount,
                                          generated_date
                                      FROM invoices
                                      WHERE id = p_invoice_id;
                                  END;
                                  """;
}