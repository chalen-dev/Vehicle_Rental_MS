namespace VRMS.Database.StoredProcedures.Rentals.Rental;

public static class SP_Rentals_UpdateStatus
{
    public static string Sql() => """
                                  CREATE PROCEDURE sp_rentals_update_status (
                                      IN p_rental_id INT,
                                      IN p_status ENUM('Active','Completed','Cancelled')
                                  )
                                  BEGIN
                                      UPDATE rentals
                                      SET status = p_status
                                      WHERE id = p_rental_id;
                                  END;
                                  """;
}