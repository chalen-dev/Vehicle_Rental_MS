namespace VRMS.Database.SPImplementations.Billing.RateConfiguration;

public static class SP_RateConfigurations_Update
{
    public static string Sql() => """
                                  DROP PROCEDURE IF EXISTS sp_rate_configurations_update;

                                  CREATE PROCEDURE sp_rate_configurations_update (
                                      IN p_rate_configuration_id INT,
                                      IN p_daily_rate DECIMAL(10,2),
                                      IN p_weekly_rate DECIMAL(10,2),
                                      IN p_monthly_rate DECIMAL(10,2),
                                      IN p_included_mileage_per_day DECIMAL(10,2),
                                      IN p_excess_mileage_rate DECIMAL(10,2)
                                  )
                                  BEGIN
                                      UPDATE rate_configurations
                                      SET
                                          daily_rate = p_daily_rate,
                                          weekly_rate = p_weekly_rate,
                                          monthly_rate = p_monthly_rate,
                                          included_mileage_per_day = p_included_mileage_per_day,
                                          excess_mileage_rate = p_excess_mileage_rate
                                      WHERE id = p_rate_configuration_id;
                                  END;
                                  """;
}