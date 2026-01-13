namespace VRMS.Database.SPImplementations.Fleet.Vehicle;

public static class SP_Vehicles_Search
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_vehicles_search;

                                  CREATE PROCEDURE sp_vehicles_search (
                                      IN p_status VARCHAR(50),
                                      IN p_search VARCHAR(100)
                                  )
                                  BEGIN
                                      SELECT *
                                      FROM vehicles
                                      WHERE
                                          (p_status IS NULL OR status = p_status)
                                      AND (
                                          p_search IS NULL
                                          OR make LIKE CONCAT('%', p_search, '%')
                                          OR model LIKE CONCAT('%', p_search, '%')
                                          OR license_plate LIKE CONCAT('%', p_search, '%')
                                          OR vehicle_code LIKE CONCAT('%', p_search, '%')
                                      )
                                      ORDER BY make, model, year DESC;
                                  END;
                                  """;
}