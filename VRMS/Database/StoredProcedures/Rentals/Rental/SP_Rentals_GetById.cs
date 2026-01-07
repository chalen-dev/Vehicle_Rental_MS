namespace VRMS.Database.StoredProcedures.Rentals.Rental;

public static class SP_Rentals_GetById
{
    public static string Sql() => """
                                  CREATE PROCEDURE sp_rentals_get_by_id (
                                      IN p_rental_id INT
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
                                          status
                                      FROM rentals
                                      WHERE id = p_rental_id;
                                  END;
                                  """;
}