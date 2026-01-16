namespace VRMS.Database.SPImplementations.Dashboard;

public static class SP_Dashboard_FleetStats
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_dashboard_fleet_stats;

                                  CREATE PROCEDURE sp_dashboard_fleet_stats()
                                  BEGIN
                                      SELECT
                                          COUNT(*) AS total_vehicles,

                                          SUM(
                                              LOWER(status) = 'available'
                                          ) AS available_vehicles,

                                          SUM(
                                              LOWER(status) IN ('undermaintenance', 'maintenance')
                                          ) AS under_maintenance_vehicles

                                      FROM vehicles
                                      WHERE LOWER(status) != 'retired';
                                  END;
                                  
                                  """;
}