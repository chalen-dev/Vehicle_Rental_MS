namespace VRMS.Database.StoredProcedures.Rentals.Rental;

public static class SP_Rentals_Complete
{
    public static string Sql() => """
                                  CREATE PROCEDURE sp_rentals_complete (
                                      IN p_rental_id INT,
                                      IN p_actual_return_date DATETIME,
                                      IN p_end_odometer INT
                                  )
                                  BEGIN
                                      UPDATE rentals
                                      SET
                                          actual_return_date = p_actual_return_date,
                                          end_odometer = p_end_odometer,
                                          status = 'Completed'
                                      WHERE id = p_rental_id;
                                  END;
                                  """;
}