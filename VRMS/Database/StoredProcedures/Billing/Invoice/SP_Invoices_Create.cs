namespace VRMS.Database.StoredProcedures.Billing.Invoice;

public static class SP_Invoices_Create
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_invoices_create;

                                  CREATE PROCEDURE sp_invoices_create (
                                      IN p_rental_id INT,
                                      IN p_total_amount DECIMAL(10,2),
                                      IN p_generated_date DATETIME
                                  )
                                  BEGIN
                                      INSERT INTO invoices (
                                          rental_id,
                                          total_amount,
                                          generated_date
                                      )
                                      VALUES (
                                          p_rental_id,
                                          p_total_amount,
                                          p_generated_date
                                      );

                                      SELECT LAST_INSERT_ID() AS invoice_id;
                                  END;
                                  """;
}