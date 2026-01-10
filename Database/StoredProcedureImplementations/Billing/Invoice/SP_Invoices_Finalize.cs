namespace VRMS.Database.StoredProcedureImplementations.Billing.Invoice;

public static class SP_Invoices_Finalize
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_invoices_finalize;

                                  CREATE PROCEDURE sp_invoices_finalize (
                                      IN p_invoice_id INT,
                                      IN p_total_amount DECIMAL(10,2)
                                  )
                                  BEGIN
                                      IF p_total_amount < 0 THEN
                                          SIGNAL SQLSTATE '45000'
                                              SET MESSAGE_TEXT = 'Invoice total cannot be negative';
                                      END IF;

                                      UPDATE invoices
                                      SET total_amount = p_total_amount
                                      WHERE id = p_invoice_id
                                        AND total_amount = 0;
                                  END;
                                  """;
}