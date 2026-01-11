namespace VRMS.Database.SPImplementations.Rentals.Rental;

public static class SP_Rentals_GetAll
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_rentals_get_all;

                                  CREATE PROCEDURE sp_rentals_get_all ()
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
                                      ORDER BY pickup_date DESC;
                                  END;
                                  """;
}