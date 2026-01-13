namespace VRMS.Database.SPImplementations.Rentals.Rental;

public static class SP_Rentals_Delete
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_rentals_delete;

                                  CREATE PROCEDURE sp_rentals_delete (
                                      IN p_rental_id INT
                                  )
                                  BEGIN
                                      DELETE FROM rentals
                                      WHERE id = p_rental_id;
                                  END;
                                  """;
}