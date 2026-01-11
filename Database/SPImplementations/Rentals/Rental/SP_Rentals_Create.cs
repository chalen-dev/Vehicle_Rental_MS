public static class SP_Rentals_Create
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_rentals_create;

                                  CREATE PROCEDURE sp_rentals_create (
                                      IN p_reservation_id INT,
                                      IN p_pickup_date DATETIME,
                                      IN p_expected_return_date DATETIME,
                                      IN p_start_odometer INT,
                                      IN p_start_fuel_level VARCHAR(50),
                                      IN p_status VARCHAR(50)
                                  )
                                  BEGIN
                                      INSERT INTO rentals (
                                          reservation_id,
                                          pickup_date,
                                          expected_return_date,
                                          start_odometer,
                                          start_fuel_level,
                                          status
                                      )
                                      VALUES (
                                          p_reservation_id,
                                          p_pickup_date,
                                          p_expected_return_date,
                                          p_start_odometer,
                                          p_start_fuel_level,
                                          p_status
                                      );

                                      SELECT LAST_INSERT_ID() AS rental_id;
                                  END;
                                  """;
}