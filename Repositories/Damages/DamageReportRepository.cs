using System;
using System.Collections.Generic;
using System.Data;
using VRMS.Database;
using VRMS.Models.Damages;

namespace VRMS.Repositories.Damages;

public class DamageReportRepository
{

    // ----------------------------
    // DAMAGE REPORTS
    // ----------------------------

    public int Create(int damageId)
    {
        var table = DB.Query(
            "CALL sp_damage_reports_create(@damageId);",
            ("@damageId", damageId)
        );

        return Convert.ToInt32(table.Rows[0]["damage_report_id"]);
    }


    public void Approve(int damageReportId)
    {
        DB.Execute(
            "CALL sp_damage_reports_approve(@id);",
            ("@id", damageReportId)
        );
    }

    public DamageReport GetById(int damageReportId)
    {
        var table = DB.Query(
            "CALL sp_damage_reports_get_by_id(@id);",
            ("@id", damageReportId)
        );

        if (table.Rows.Count == 0)
            throw new InvalidOperationException("Damage report not found.");

        return Map(table.Rows[0]);
    }

    public void SetPhoto(int damageReportId, string photoPath)
    {
        DB.Execute(
            "CALL sp_damage_reports_set_photo(@id, @path);",
            ("@id", damageReportId),
            ("@path", photoPath)
        );
    }

    public void ResetPhoto(int damageReportId)
    {
        DB.Execute(
            "CALL sp_damage_reports_reset_photo(@id);",
            ("@id", damageReportId)
        );
    }

    private static DamageReport Map(DataRow row)
    {
        string? photoPath =
            row["photo_path"] == DBNull.Value
                ? null
                : row["photo_path"].ToString();

        return new DamageReport
        {
            Id = Convert.ToInt32(row["id"]),
            DamageId = Convert.ToInt32(row["damage_id"]),
            PhotoPath = photoPath ?? string.Empty,
            Approved = Convert.ToBoolean(row["approved"])
        };

    }
    
    // ----------------------------
    // BILLING SUPPORT
    // ----------------------------
    // Returns approved damages for a rental, with cost info
    public List<(int DamageReportId, string Description, decimal EstimatedCost)>
        GetApprovedByRental(int rentalId)
    {
        var table = DB.Query(
            "CALL sp_damage_reports_get_approved_by_rental(@rid);",
            ("@rid", rentalId)
        );

        var list =
            new List<(int, string, decimal)>();

        foreach (DataRow row in table.Rows)
        {
            list.Add((
                Convert.ToInt32(row["id"]),
                row["description"].ToString()!,
                Convert.ToDecimal(row["estimated_cost"])
            ));
        }

        return list;
    }
    
    public List<DamageReport> GetByDamage(int damageId)
    {
        var table = DB.Query(
            """
            SELECT
                id,
                damage_id,
                photo_path,
                approved
            FROM damage_reports
            WHERE damage_id = @did
            ORDER BY id;
            """,
            ("@did", damageId)
        );
    
        var list = new List<DamageReport>();
        foreach (DataRow row in table.Rows)
            list.Add(Map(row));
    
        return list;
    }
}
