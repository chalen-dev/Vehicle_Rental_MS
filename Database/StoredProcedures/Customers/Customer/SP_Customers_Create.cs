namespace VRMS.Database.StoredProcedures.Customers.Customer;

public static class SP_Customers_Create
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_customers_create;

                                  CREATE PROCEDURE sp_customers_create (
                                      IN p_first_name VARCHAR(50),
                                      IN p_last_name VARCHAR(50),
                                      IN p_email VARCHAR(100),
                                      IN p_phone VARCHAR(30),
                                      IN p_address VARCHAR(255),
                                      IN p_date_of_birth DATE,
                                      IN p_customer_category VARCHAR(50),
                                      IN p_is_frequent BOOLEAN,
                                      IN p_is_blacklisted BOOLEAN,
                                      IN p_photo_path VARCHAR(255),
                                      IN p_drivers_license_id INT
                                  )
                                  BEGIN
                                      INSERT INTO customers (
                                          first_name,
                                          last_name,
                                          email,
                                          phone,
                                          address,
                                          date_of_birth,
                                          customer_category,
                                          is_frequent,
                                          is_blacklisted,
                                          photo_path,
                                          drivers_license_id
                                      )
                                      VALUES (
                                          p_first_name,
                                          p_last_name,
                                          p_email,
                                          p_phone,
                                          p_address,
                                          p_date_of_birth,
                                          p_customer_category,
                                          p_is_frequent,
                                          p_is_blacklisted,
                                          p_photo_path,
                                          p_drivers_license_id
                                      );

                                      SELECT LAST_INSERT_ID() AS customer_id;
                                  END;
                                  """;
}