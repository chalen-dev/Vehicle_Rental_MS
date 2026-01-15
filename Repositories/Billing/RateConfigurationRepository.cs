using System.Data;
using VRMS.Database;
using VRMS.Models.Billing;

namespace VRMS.Repositories.Billing;

public class RateConfigurationRepository
{
    // ---------------- CREATE ----------------

    public int Create(
        int vehicleCategoryId,
        decimal daily,
        decimal weekly,
        decimal monthly,
        decimal includedMileagePerDay,
        decimal excessMileageRate)
    {
        var table = DB.Query(
            "CALL sp_rate_configurations_create(@cat,@daily,@weekly,@monthly,@included,@excess);",
            ("@cat", vehicleCategoryId),
            ("@daily", daily),
            ("@weekly", weekly),
            ("@monthly", monthly),
            ("@included", includedMileagePerDay),
            ("@excess", excessMileageRate)
        );

        return Convert.ToInt32(
            table.Rows[0]["rate_configuration_id"]);
    }

    // ---------------- READ ----------------

    public RateConfiguration GetByCategory(int categoryId)
    {
        var table = DB.Query(
            "CALL sp_rate_configurations_get_by_category(@cat);",
            ("@cat", categoryId)
        );

        if (table.Rows.Count == 0)
            throw new InvalidOperationException(
                "Rate configuration not found for category.");

        return Map(table.Rows[0]);
    }

    // ---------------- UPDATE ----------------

    public void Update(
        int id,
        decimal daily,
        decimal weekly,
        decimal monthly,
        decimal includedMileagePerDay,
        decimal excessMileageRate)
    {
        DB.Execute(
            "CALL sp_rate_configurations_update(@id,@daily,@weekly,@monthly,@included,@excess);",
            ("@id", id),
            ("@daily", daily),
            ("@weekly", weekly),
            ("@monthly", monthly),
            ("@included", includedMileagePerDay),
            ("@excess", excessMileageRate)
        );
    }

    // ---------------- MAPPING ----------------

    private static RateConfiguration Map(DataRow row)
    {
        return new RateConfiguration
        {
            Id = Convert.ToInt32(row["id"]),
            VehicleCategoryId =
                Convert.ToInt32(row["vehicle_category_id"]),

            DailyRate = Convert.ToDecimal(row["daily_rate"]),
            WeeklyRate = Convert.ToDecimal(row["weekly_rate"]),
            MonthlyRate = Convert.ToDecimal(row["monthly_rate"]),
            IncludedMileagePerDay =
                Convert.ToDecimal(row["included_mileage_per_day"]),
            ExcessMileageRate =
                Convert.ToDecimal(row["excess_mileage_rate"])
        };
    }
}
