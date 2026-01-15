namespace VRMS.Database.SPImplementations.Billing.RateConfiguration;

public static class SP_RateConfigurations_GetByCategory
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_rate_configurations_get_by_category;

                                  CREATE PROCEDURE sp_rate_configurations_get_by_category (
                                      IN p_vehicle_category_id INT
                                  )
                                  BEGIN
                                      SELECT
                                          id,
                                          vehicle_category_id,
                                          daily_rate,
                                          weekly_rate,
                                          monthly_rate,
                                          included_mileage_per_day,
                                          excess_mileage_rate
                                      FROM rate_configurations
                                      WHERE vehicle_category_id = p_vehicle_category_id;
                                  END;
                                  """;
}