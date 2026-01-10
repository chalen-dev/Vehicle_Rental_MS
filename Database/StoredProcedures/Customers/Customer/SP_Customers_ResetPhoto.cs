namespace VRMS.Database.StoredProcedures.Customers.Customer;

public static class SP_Customers_ResetPhoto
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_customers_reset_photo;

                                  CREATE PROCEDURE sp_customers_reset_photo (
                                      IN p_customer_id INT
                                  )
                                  BEGIN
                                      UPDATE customers
                                      SET photo_path = 'Assets/profile_img.png'
                                      WHERE id = p_customer_id;
                                  END;
                                  """;
}