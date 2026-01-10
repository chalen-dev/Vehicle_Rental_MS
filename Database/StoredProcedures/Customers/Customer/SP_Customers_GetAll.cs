namespace VRMS.Database.StoredProcedures.Customers.Customer;

public static class SP_Customers_GetAll
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_customers_get_all;

                                  CREATE PROCEDURE sp_customers_get_all ()
                                  BEGIN
                                      SELECT
                                          id,
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
                                      FROM customers
                                      ORDER BY last_name, first_name;
                                  END;
                                  """;
}