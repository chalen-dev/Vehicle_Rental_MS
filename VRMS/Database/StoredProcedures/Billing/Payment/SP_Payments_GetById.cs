namespace VRMS.Database.StoredProcedures.Billing.Payment;

public static class SP_Payments_GetById
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_payments_get_by_id;

                                  CREATE PROCEDURE sp_payments_get_by_id (
                                      IN p_payment_id INT
                                  )
                                  BEGIN
                                      SELECT
                                          id,
                                          invoice_id,
                                          amount,
                                          payment_method,
                                          payment_date
                                      FROM payments
                                      WHERE id = p_payment_id;
                                  END;
                                  """;
}