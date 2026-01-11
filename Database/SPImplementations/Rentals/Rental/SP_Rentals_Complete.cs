public static class SP_Rentals_Complete
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_rentals_complete;

                                  CREATE PROCEDURE sp_rentals_complete (
                                      IN p_rental_id INT,
                                      IN p_actual_return_date DATETIME,
                                      IN p_end_odometer INT,
                                      IN p_end_fuel_level VARCHAR(50)
                                  )
                                  BEGIN
                                      UPDATE rentals
                                      SET
                                          actual_return_date = p_actual_return_date,
                                          end_odometer = p_end_odometer,
                                          end_fuel_level = p_end_fuel_level,
                                          status = 'Completed'
                                      WHERE id = p_rental_id;
                                  END;
                                  """;
}