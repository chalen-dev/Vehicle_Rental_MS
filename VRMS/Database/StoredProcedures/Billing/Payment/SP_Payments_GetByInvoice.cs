namespace VRMS.Database.StoredProcedures.Billing.Payment;

public static class SP_Payments_GetByInvoice
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_payments_get_by_invoice;

                                  CREATE PROCEDURE sp_payments_get_by_invoice (
                                      IN p_invoice_id INT
                                  )
                                  BEGIN
                                      SELECT
                                          id,
                                          invoice_id,
                                          amount,
                                          payment_method,
                                          payment_date
                                      FROM payments
                                      WHERE invoice_id = p_invoice_id
                                      ORDER BY payment_date DESC;
                                  END;
                                  """;
}