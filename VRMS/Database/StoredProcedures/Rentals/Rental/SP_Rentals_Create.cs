namespace VRMS.Database.StoredProcedures.Rentals.Rental;

public static class SP_Rentals_Create
{
    public static string Sql() => """
                                  CREATE PROCEDURE sp_rentals_create (
                                      IN p_reservation_id INT,
                                      IN p_pickup_date DATETIME,
                                      IN p_expected_return_date DATETIME,
                                      IN p_start_odometer INT,
                                      IN p_status ENUM('Active','Completed','Cancelled')
                                  )
                                  BEGIN
                                      INSERT INTO rentals (
                                          reservation_id,
                                          pickup_date,
                                          expected_return_date,
                                          start_odometer,
                                          status
                                      )
                                      VALUES (
                                          p_reservation_id,
                                          p_pickup_date,
                                          p_expected_return_date,
                                          p_start_odometer,
                                          p_status
                                      );

                                      SELECT LAST_INSERT_ID() AS rental_id;
                                  END;
                                  """;
}