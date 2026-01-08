namespace VRMS.Database.StoredProcedures.Billing.Invoice;

public static class SP_Invoices_GetByRental
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_invoices_get_by_rental;

                                  CREATE PROCEDURE sp_invoices_get_by_rental (
                                      IN p_rental_id INT
                                  )
                                  BEGIN
                                      SELECT
                                          id,
                                          rental_id,
                                          total_amount,
                                          generated_date
                                      FROM invoices
                                      WHERE rental_id = p_rental_id
                                      ORDER BY generated_date DESC;
                                  END;
                                  """;
}