using System.Data;
using VRMS.Database;
using VRMS.Enums;
using VRMS.Models.Fleet;

namespace VRMS.Repositories.Fleet;

public class MaintenanceRepository
{
    public int Create(MaintenanceRecord record)
    {
        var table = DB.Query(
            "CALL sp_maintenance_records_create(" +
            "@vid,@title,@desc,@type,@status,@start,@cost,@by);",
            ("@vid", record.VehicleId),
            ("@title", record.Title),
            ("@desc", record.Description),
            ("@type", (int)record.Type),
            ("@status", (int)record.Status),
            ("@start", record.StartDate),
            ("@cost", record.Cost),
            ("@by", record.PerformedBy)
        );

        return Convert.ToInt32(table.Rows[0]["maintenance_record_id"]);
    }


    public void Close(int id, DateTime end, MaintenanceStatus status)
    {
        DB.Execute(
            "CALL sp_maintenance_records_close(@id,@end,@status);",
            ("@id", id),
            ("@end", end),
            ("@status", (int)status)
        );
    }


    public MaintenanceRecord GetById(int id)
    {
        var table = DB.Query(
            "CALL sp_maintenance_records_get_by_id(@id);",
            ("@id", id)
        );

        if (table.Rows.Count == 0)
            throw new InvalidOperationException("Maintenance record not found.");

        return Map(table.Rows[0]);
    }

    public List<MaintenanceRecord> GetByVehicle(int vehicleId)
    {
        var table = DB.Query(
            "CALL sp_maintenance_records_get_by_vehicle(@id);",
            ("@id", vehicleId)
        );

        var list = new List<MaintenanceRecord>();
        foreach (DataRow r in table.Rows)
            list.Add(Map(r));

        return list;
    }
    
    public List<MaintenanceRecord> GetOverlapping(int vehicleId, DateTime start, DateTime end)
    {
        var table = DB.Query(
            "CALL sp_maintenance_records_get_overlapping(@vid,@start,@end);",
            ("@vid", vehicleId),
            ("@start", start.Date),
            ("@end", end.Date)
        );

        var list = new List<MaintenanceRecord>();
        foreach (DataRow r in table.Rows)
            list.Add(Map(r));

        return list;
    }


    private static MaintenanceRecord Map(DataRow r) => new()
    {
        Id = Convert.ToInt32(r["id"]),
        VehicleId = Convert.ToInt32(r["vehicle_id"]),
        Title = r["title"].ToString()!,
        Description = r["description"].ToString()!,
        Type = (MaintenanceType)Convert.ToInt32(r["type"]),
        Status = (MaintenanceStatus)Convert.ToInt32(r["status"]),
        StartDate = Convert.ToDateTime(r["start_date"]),
        EndDate = r["end_date"] == DBNull.Value ? null : Convert.ToDateTime(r["end_date"]),
        Cost = Convert.ToDecimal(r["cost"]),
        PerformedBy = r["performed_by"].ToString() ?? "",
        CreatedAt = Convert.ToDateTime(r["created_at"]),
        UpdatedAt = Convert.ToDateTime(r["updated_at"])
    };

}