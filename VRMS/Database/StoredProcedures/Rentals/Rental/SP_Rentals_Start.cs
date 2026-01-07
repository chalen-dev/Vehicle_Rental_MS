namespace VRMS.Database.StoredProcedures.Rentals.Rental;

public static class SP_Rentals_Start
{
    public static string Sql() => """
                                  CREATE PROCEDURE sp_rentals_start (
                                      IN p_rental_id INT
                                  )
                                  BEGIN
                                      UPDATE rentals
                                      SET status = 'Active'
                                      WHERE id = p_rental_id;
                                  END;
                                  """;
}