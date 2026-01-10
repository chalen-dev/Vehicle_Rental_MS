using System.Data;
using VRMS.Database;
using VRMS.Models.Damages;

namespace VRMS.Services.Damage;

public class DamageService
{
    private const string DefaultDamagePhotoPath = "Assets/img_placeholder.png";

    // -------------------------------------------------
    // DAMAGE CATALOG (ADMIN)
    // -------------------------------------------------

    public int CreateDamage(string description, decimal estimatedCost)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new InvalidOperationException("Damage description is required.");

        if (estimatedCost < 0)
            throw new InvalidOperationException("Estimated cost cannot be negative.");

        var table = DB.Query(
            "CALL sp_damages_create(@desc, @cost);",
            ("@desc", description),
            ("@cost", estimatedCost)
        );

        return Convert.ToInt32(table.Rows[0]["damage_id"]);
    }

    public void UpdateDamage(int damageId, string description, decimal estimatedCost)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new InvalidOperationException("Damage description is required.");

        if (estimatedCost < 0)
            throw new InvalidOperationException("Estimated cost cannot be negative.");

        DB.Execute(
            "CALL sp_damages_update(@id, @desc, @cost);",
            ("@id", damageId),
            ("@desc", description),
            ("@cost", estimatedCost)
        );
    }

    public void DeleteDamage(int damageId)
    {
        // DB enforces RESTRICT if referenced by reports
        DB.Execute(
            "CALL sp_damages_delete(@id);",
            ("@id", damageId)
        );
    }

    public Models.Damages.Damage GetDamageById(int damageId)
    {
        var table = DB.Query(
            "CALL sp_damages_get_by_id(@id);",
            ("@id", damageId)
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
        int damageId
    )
    {
        // Ensure damage exists
        GetDamageById(damageId);

        var table = DB.Query(
            "CALL sp_damage_reports_create(@inspectionId, @damageId, @photo);",
            ("@inspectionId", vehicleInspectionId),
            ("@damageId", damageId),
            ("@photo", DefaultDamagePhotoPath)
        );

        return Convert.ToInt32(table.Rows[0]["damage_report_id"]);
    }

    public void ApproveDamageReport(int damageReportId)
    {
        var report = GetDamageReportById(damageReportId);

        if (report.Approved)
            throw new InvalidOperationException("Damage report is already approved.");

        DB.Execute(
            "CALL sp_damage_reports_approve(@id);",
            ("@id", damageReportId)
        );
    }

    public DamageReport GetDamageReportById(int damageReportId)
    {
        var table = DB.Query(
            "CALL sp_damage_reports_get_by_id(@id);",
            ("@id", damageReportId)
        );

        if (table.Rows.Count == 0)
            throw new InvalidOperationException("Damage report not found.");

        return MapDamageReport(table.Rows[0]);
    }

    public List<DamageReport> GetDamageReportsByInspection(int vehicleInspectionId)
    {
        var table = DB.Query(
            "CALL sp_damage_reports_get_by_inspection(@inspectionId);",
            ("@inspectionId", vehicleInspectionId)
        );

        var list = new List<DamageReport>();
        foreach (DataRow row in table.Rows)
            list.Add(MapDamageReport(row));

        return list;
    }

    public void SetDamageReportPhoto(
        int damageReportId,
        string photoPath
    )
    {
        DB.Execute(
            "CALL sp_damage_reports_set_photo(@id, @path);",
            ("@id", damageReportId),
            ("@path", photoPath)
        );
    }

    public void DeleteDamageReportPhoto(int damageReportId)
    {
        DB.Execute(
            "CALL sp_damage_reports_reset_photo(@id);",
            ("@id", damageReportId)
        );
    }

    // -------------------------------------------------
    // MAPPING
    // -------------------------------------------------

    private static Models.Damages.Damage MapDamage(DataRow row)
    {
        return new Models.Damages.Damage
        {
            Id = Convert.ToInt32(row["id"]),
            Description = row["description"].ToString()!,
            EstimatedCost = Convert.ToDecimal(row["estimated_cost"])
        };
    }

    private static DamageReport MapDamageReport(DataRow row)
    {
        var photoPath = row["photo_path"] == DBNull.Value
            ? DefaultDamagePhotoPath
            : row["photo_path"].ToString();

        if (string.IsNullOrWhiteSpace(photoPath))
            photoPath = DefaultDamagePhotoPath;

        return new DamageReport
        {
            Id = Convert.ToInt32(row["id"]),
            VehicleInspectionId = Convert.ToInt32(row["vehicle_inspection_id"]),
            DamageId = Convert.ToInt32(row["damage_id"]),
            PhotoPath = photoPath!,
            Approved = Convert.ToBoolean(row["approved"])
        };
    }
}
