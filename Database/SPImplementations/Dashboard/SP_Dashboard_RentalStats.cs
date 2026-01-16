namespace VRMS.Database.SPImplementations.Dashboard;

public static class SP_Dashboard_RentalStats
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_dashboard_rental_stats;

                                  CREATE PROCEDURE sp_dashboard_rental_stats()
                                  BEGIN
                                      SELECT
                                          -- Active rentals: not yet returned
                                          SUM(
                                              actual_return_date IS NULL
                                              AND status = 'Active'
                                          ) AS active_rentals,

                                          -- Overdue rentals: past expected return date and not yet returned
                                          SUM(
                                              actual_return_date IS NULL
                                              AND status = 'Active'
                                              AND expected_return_date < NOW()
                                          ) AS overdue_rentals
                                      FROM rentals;
                                  END;
                                  
                                  
                                  """;
}