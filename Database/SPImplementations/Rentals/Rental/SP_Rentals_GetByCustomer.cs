namespace VRMS.Database.SPImplementations.Rentals.Rental;

public static class SP_Rentals_GetByCustomer
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_rentals_get_by_customer;

                                  CREATE PROCEDURE sp_rentals_get_by_customer (
                                      IN p_customer_id INT
                                  )
                                  BEGIN
                                      SELECT
                                          r.id,
                                          r.reservation_id,
                                          r.pickup_date,
                                          r.expected_return_date,
                                          r.actual_return_date,
                                          r.start_odometer,
                                          r.end_odometer,
                                          r.start_fuel_level,
                                          r.end_fuel_level,
                                          r.status,
                                          i.total_amount
                                      FROM rentals r
                                      INNER JOIN reservations res
                                          ON res.id = r.reservation_id
                                      LEFT JOIN invoices i
                                          ON i.rental_id = r.id
                                      WHERE res.customer_id = p_customer_id
                                      ORDER BY r.pickup_date DESC;
                                  END;
                                  """;
}