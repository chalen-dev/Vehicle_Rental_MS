namespace VRMS.Database.StoredProcedureImplementations.Customers.Customer;

public static class SP_Customers_Update_No_Photo
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_customers_update_no_photo;

                                  CREATE PROCEDURE sp_customers_update_no_photo (
                                      IN p_customer_id INT,
                                      IN p_first_name VARCHAR(50),
                                      IN p_last_name VARCHAR(50),
                                      IN p_email VARCHAR(100),
                                      IN p_phone VARCHAR(30),
                                      IN p_address VARCHAR(255),
                                      IN p_date_of_birth DATE,
                                      IN p_customer_category VARCHAR(50),
                                      IN p_is_frequent BOOLEAN,
                                      IN p_is_blacklisted BOOLEAN
                                  )
                                  BEGIN
                                      UPDATE customers
                                      SET
                                          first_name = p_first_name,
                                          last_name = p_last_name,
                                          email = p_email,
                                          phone = p_phone,
                                          address = p_address,
                                          date_of_birth = p_date_of_birth,
                                          customer_category = p_customer_category,
                                          is_frequent = p_is_frequent,
                                          is_blacklisted = p_is_blacklisted
                                      WHERE id = p_customer_id;
                                  END;
                                  """;
}