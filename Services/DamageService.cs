using System;
using System.Collections.Generic;
using System.Data;
using VRMS.Database;
using VRMS.Helpers.SqlEscape;
using VRMS.Models.Damages;

namespace VRMS.Services;

public class DamageService
{
    // -------------------------------------------------
    // DAMAGE CATALOG (ADMIN)
    // -------------------------------------------------

    public int CreateDamage(string description, decimal estimatedCost)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new InvalidOperationException("Damage description is required.");

        if (estimatedCost < 0)
            throw new InvalidOperationException("Estimated cost cannot be negative.");

        var table = DB.ExecuteQuery($"""
            CALL sp_damages_create(
                '{Sql.Esc(description)}',
                {estimatedCost}
            );
        """);

        return Convert.ToInt32(table.Rows[0]["damage_id"]);
    }

    public void UpdateDamage(int damageId, string description, decimal estimatedCost)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new InvalidOperationException("Damage description is required.");

        if (estimatedCost < 0)
            throw new InvalidOperationException("Estimated cost cannot be negative.");

        DB.ExecuteNonQuery($"""
            CALL sp_damages_update(
                {damageId},
                '{Sql.Esc(description)}',
                {estimatedCost}
            );
        """);
    }

    public void DeleteDamage(int damageId)
    {
        // DB enforces RESTRICT if referenced by reports
        DB.ExecuteNonQuery($"CALL sp_damages_delete({damageId});");
    }

    public Damage GetDamageById(int damageId)
    {
        var table = DB.ExecuteQuery(
            $"CALL sp_damages_get_by_id({damageId});"
        );

        if (table.Rows.Count == 0)
            throw new InvalidOperationException("Damage not found.");

        return MapDamage(table.Rows[0]);
    }

    // -------------------------------------------------
    // DAMAGE REPORTS
    // -------------------------------------------------

    public int CreateDamageReport(
        int vehicleInspectionId,
        int damageId,
        string photoPath)
    {
        if (string.IsNullOrWhiteSpace(photoPath))
            throw new InvalidOperationException("Photo path is required.");

        // Ensure damage exists
        GetDamageById(damageId);

        var table = DB.ExecuteQuery($"""
            CALL sp_damage_reports_create(
                {vehicleInspectionId},
                {damageId},
                '{Sql.Esc(photoPath)}'
            );
        """);

        return Convert.ToInt32(table.Rows[0]["damage_report_id"]);
    }

    public void ApproveDamageReport(int damageReportId)
    {
        var report = GetDamageReportById(damageReportId);

        if (report.Approved)
            throw new InvalidOperationException("Damage report is already approved.");

        DB.ExecuteNonQuery(
            $"CALL sp_damage_reports_approve({damageReportId});"
        );
    }

    public DamageReport GetDamageReportById(int damageReportId)
    {
        var table = DB.ExecuteQuery(
            $"CALL sp_damage_reports_get_by_id({damageReportId});"
        );

        if (table.Rows.Count == 0)
            throw new InvalidOperationException("Damage report not found.");

        return MapDamageReport(table.Rows[0]);
    }

    public List<DamageReport> GetDamageReportsByInspection(int vehicleInspectionId)
    {
        var table = DB.ExecuteQuery(
            $"CALL sp_damage_reports_get_by_inspection({vehicleInspectionId});"
        );

        var list = new List<DamageReport>();
        foreach (DataRow row in table.Rows)
            list.Add(MapDamageReport(row));

        return list;
    }

    // -------------------------------------------------
    // MAPPING
    // -------------------------------------------------

    private static Damage MapDamage(DataRow row)
    {
        return new Damage
        {
            Id = Convert.ToInt32(row["id"]),
            Description = row["description"].ToString()!,
            EstimatedCost = Convert.ToDecimal(row["estimated_cost"])
        };
    }

    private static DamageReport MapDamageReport(DataRow row)
    {
        return new DamageReport
        {
            Id = Convert.ToInt32(row["id"]),
            VehicleInspectionId = Convert.ToInt32(row["vehicle_inspection_id"]),
            DamageId = Convert.ToInt32(row["damage_id"]),
            PhotoPath = row["photo_path"].ToString()!,
            Approved = Convert.ToBoolean(row["approved"])
        };
    }
}
