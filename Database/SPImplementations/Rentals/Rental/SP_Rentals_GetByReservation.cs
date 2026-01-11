namespace VRMS.Database.SPImplementations.Rentals.Rental;

public static class SP_Rentals_GetByReservation
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_rentals_get_by_reservation;

                                  CREATE PROCEDURE sp_rentals_get_by_reservation (
                                      IN p_reservation_id INT
                                  )
                                  BEGIN
                                      SELECT
                                          id,
                                          reservation_id,
                                          pickup_date,
                                          expected_return_date,
                                          actual_return_date,
                                          start_odometer,
                                          end_odometer,
                                          start_fuel_level,
                                          end_fuel_level,
                                          status
                                      FROM rentals
                                      WHERE reservation_id = p_reservation_id;
                                  END;
                                  """;
}