namespace VRMS.Database.SPImplementations.Rentals.Rental;

public static class SP_Rentals_GetOverlapping
{
    public static string Sql() => """
                                  CREATE PROCEDURE sp_rentals_get_overlapping (
                                      IN p_vehicle_id INT,
                                      IN p_start DATETIME,
                                      IN p_end DATETIME
                                  )
                                  BEGIN
                                      SELECT *
                                      FROM rentals
                                      WHERE
                                          vehicle_id = p_vehicle_id
                                          AND status IN ('Active', 'Late')
                                          AND p_start < COALESCE(actual_return_date, expected_return_date)
                                          AND p_end > pickup_date;
                                  END;
                                  """;
}