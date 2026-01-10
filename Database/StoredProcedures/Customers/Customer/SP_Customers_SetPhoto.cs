namespace VRMS.Database.StoredProcedures.Customers.Customer;

public static class SP_Customers_SetPhoto
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_customers_set_photo;

                                  CREATE PROCEDURE sp_customers_set_photo (
                                      IN p_customer_id INT,
                                      IN p_photo_path VARCHAR(255)
                                  )
                                  BEGIN
                                      UPDATE customers
                                      SET photo_path = p_photo_path
                                      WHERE id = p_customer_id;
                                  END;
                                  """;
}