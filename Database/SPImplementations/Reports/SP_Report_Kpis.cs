namespace VRMS.Database.SPImplementations.Reports;

public static class SP_Report_Kpis
{
    public static string Sql() => """
    DROP PROCEDURE IF EXISTS sp_report_kpis;

    CREATE PROCEDURE sp_report_kpis(
        IN p_from DATE,
        IN p_to DATE
    )
    BEGIN
        SELECT
            -- ============================
            -- VEHICLES
            -- ============================
            (SELECT COUNT(*)
             FROM vehicles)
                AS total_vehicles,

            -- ============================
            -- RENTALS COUNT (DATE FILTERED)
            -- ============================
            (SELECT COUNT(*)
             FROM rentals r
             WHERE DATE(r.pickup_date)
                   BETWEEN p_from AND p_to)
                AS total_rentals,

            -- ============================
            -- TOTAL RENTAL DAYS (OVERLAP)
            -- ============================
            COALESCE(
                (SELECT SUM(
                    GREATEST(
                        0,
                        DATEDIFF(
                            COALESCE(r.actual_return_date, p_to),
                            r.pickup_date
                        )
                    )
                )
                 FROM rentals r
                 WHERE r.pickup_date <= p_to
                   AND COALESCE(r.actual_return_date, p_to) >= p_from),
                0
            ) AS total_rental_days,

            -- ============================
            -- TOTAL REVENUE
            -- ============================
            COALESCE(
                (SELECT SUM(i.total_amount)
                 FROM invoices i
                 WHERE DATE(i.generated_date)
                       BETWEEN p_from AND p_to),
                0
            ) AS total_revenue,

            -- ============================
            -- AVERAGE RENTAL DURATION
            -- ============================
            COALESCE(
                (SELECT AVG(
                    DATEDIFF(
                        COALESCE(r.actual_return_date, p_to),
                        r.pickup_date
                    )
                )
                 FROM rentals r
                 WHERE DATE(r.pickup_date)
                       BETWEEN p_from AND p_to),
                0
            ) AS avg_rental_duration,

            -- ============================
            -- FLEET UTILIZATION (%)
            -- ============================
            ROUND(
                COALESCE(
                    (SELECT SUM(
                        GREATEST(
                            0,
                            DATEDIFF(
                                COALESCE(r.actual_return_date, p_to),
                                r.pickup_date
                            )
                        )
                    )
                     FROM rentals r
                     WHERE r.pickup_date <= p_to
                       AND COALESCE(r.actual_return_date, p_to) >= p_from),
                    0
                )
                / (
                    (SELECT COUNT(*) FROM vehicles)
                    * (DATEDIFF(p_to, p_from) + 1)
                ) * 100,
                2
            ) AS fleet_utilization_percent,

            -- ============================
            -- DAMAGE INCIDENTS
            -- NOTE:
            -- damages table has NO date column yet
            -- so we safely count all records
            -- ============================
            (SELECT COUNT(*)
             FROM damages)
                AS damage_incident_count;
    END;
    """;
}
