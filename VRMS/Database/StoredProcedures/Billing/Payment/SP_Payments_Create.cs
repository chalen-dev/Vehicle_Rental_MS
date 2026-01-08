namespace VRMS.Database.StoredProcedures.Billing.Payment;

public static class SP_Payments_Create
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_payments_create;

                                  CREATE PROCEDURE sp_payments_create (
                                      IN p_invoice_id INT,
                                      IN p_amount DECIMAL(10,2),
                                      IN p_payment_method ENUM('Cash','Card','Online'),
                                      IN p_payment_date DATETIME
                                  )
                                  BEGIN
                                      INSERT INTO payments (
                                          invoice_id,
                                          amount,
                                          payment_method,
                                          payment_date
                                      )
                                      VALUES (
                                          p_invoice_id,
                                          p_amount,
                                          p_payment_method,
                                          p_payment_date
                                      );

                                      SELECT LAST_INSERT_ID() AS payment_id;
                                  END;
                                  """;
}