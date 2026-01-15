namespace VRMS.Database.SPImplementations.Billing.RateConfiguration;

public static class SP_RateConfigurations_GetById
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_rate_configurations_get_by_id;

                                  CREATE PROCEDURE sp_rate_configurations_get_by_id (
                                      IN p_rate_configuration_id INT
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
                                      WHERE id = p_rate_configuration_id;
                                  END;
                                  """;
}