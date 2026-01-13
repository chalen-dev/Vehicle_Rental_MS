using System.Data;
using VRMS.Database;
using VRMS.Enums;
using VRMS.Models.Fleet;

namespace VRMS.Repositories.Fleet;

public class VehicleRepository
{
    public int Create(Vehicle v)
    {
        var table = DB.Query(
            "CALL sp_vehicles_create(@code,@make,@model,@year,@color,@plate,@vin,@trans,@fuel,@status,@seat,@odo,@eff,@cargo,@cat);",
            ("@code", v.VehicleCode),
            ("@make", v.Make),
            ("@model", v.Model),
            ("@year", v.Year),
            ("@color", v.Color),
            ("@plate", v.LicensePlate),
            ("@vin", v.VIN),
            ("@trans", v.Transmission.ToString()),
            ("@fuel", v.FuelType.ToString()),
            ("@status", v.Status.ToString()),
            ("@seat", v.SeatingCapacity),
            ("@odo", v.Odometer),
            ("@eff", v.FuelEfficiency),
            ("@cargo", v.CargoCapacity),
            ("@cat", v.VehicleCategoryId)
        );

        return Convert.ToInt32(table.Rows[0]["vehicle_id"]);
    }

    public Vehicle GetById(int id)
    {
        var table = DB.Query(
            "CALL sp_vehicles_get_by_id(@id);",
            ("@id", id)
        );

        if (table.Rows.Count == 0)
            throw new InvalidOperationException("Vehicle not found.");

        return Map(table.Rows[0]);
    }

    public List<Vehicle> GetAll()
        => MapList(DB.Query("CALL sp_vehicles_get_all();"));

    public void UpdateStatus(int id, VehicleStatus status)
    {
        DB.Execute(
            "CALL sp_vehicles_update_status(@id,@status);",
            ("@id", id),
            ("@status", status.ToString())
        );
    }

    public void UpdateDetails(
        int id,
        string color,
        int odometer,
        decimal efficiency,
        int cargo,
        int categoryId)
    {
        DB.Execute(
            "CALL sp_vehicles_update(@id,@color,@odo,@eff,@cargo,@cat);",
            ("@id", id),
            ("@color", color),
            ("@odo", odometer),
            ("@eff", efficiency),
            ("@cargo", cargo),
            ("@cat", categoryId)
        );
    }
    
    public void Retire(int id)
    {
        DB.Execute(
            "CALL sp_vehicles_retire(@id);",
            ("@id", id)
        );
    }
    
    public Vehicle GetFullById(int id)
    {
        var table = DB.Query(
            "CALL sp_vehicles_get_full(@id);",
            ("@id", id)
        );

        if (table.Rows.Count == 0)
            throw new InvalidOperationException("Vehicle not found.");

        return Map(table.Rows[0]);
    }
    
    public List<Vehicle> Search(
        VehicleStatus? status,
        string? search)
    {
        var table = DB.Query(
            "CALL sp_vehicles_search(@status,@search);",
            ("@status", status?.ToString()),
            ("@search", string.IsNullOrWhiteSpace(search) ? null : search)
        );

        return MapList(table);
    }


    // ---------- mapping ----------

    private static Vehicle Map(DataRow r) => new()
    {
        Id = Convert.ToInt32(r["id"]),
        VehicleCode = r["vehicle_code"].ToString()!,
        Make = r["make"].ToString()!,
        Model = r["model"].ToString()!,
        Year = Convert.ToInt32(r["year"]),
        Color = r["color"].ToString()!,
        LicensePlate = r["license_plate"].ToString()!,
        VIN = r["vin"].ToString()!,
        Transmission = Enum.Parse<TransmissionType>(r["transmission"].ToString()!),
        FuelType = Enum.Parse<FuelType>(r["fuel_type"].ToString()!),
        Status = Enum.Parse<VehicleStatus>(r["status"].ToString()!),
        SeatingCapacity = Convert.ToInt32(r["seating_capacity"]),
        Odometer = Convert.ToInt32(r["odometer"]),
        FuelEfficiency = Convert.ToDecimal(r["fuel_efficiency"]),
        CargoCapacity = Convert.ToInt32(r["cargo_capacity"]),
        VehicleCategoryId = Convert.ToInt32(r["vehicle_category_id"])
    };

    private static List<Vehicle> MapList(DataTable t)
    {
        var list = new List<Vehicle>();
        foreach (DataRow r in t.Rows)
            list.Add(Map(r));
        return list;
    }
}
