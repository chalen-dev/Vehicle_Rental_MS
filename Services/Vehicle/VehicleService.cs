using System.Data;
using VRMS.Database;
using VRMS.Enums;
using VRMS.Models.Fleet;

namespace VRMS.Services.Vehicle;

public class VehicleService
{
    private const string StorageRoot = "Storage";
    private const string VehicleImageFolder = "Vehicles";

    // -------------------------------------------------
    // VEHICLES
    // -------------------------------------------------

    public int CreateVehicle(Models.Fleet.Vehicle vehicle)
    {
        var table = DB.Query(
            "CALL sp_vehicles_create(@code,@make,@model,@year,@color,@plate,@vin,@trans,@fuel,@status,@seat,@odo,@eff,@cargo,@cat);",
            ("@code", vehicle.VehicleCode),
            ("@make", vehicle.Make),
            ("@model", vehicle.Model),
            ("@year", vehicle.Year),
            ("@color", vehicle.Color),
            ("@plate", vehicle.LicensePlate),
            ("@vin", vehicle.VIN),
            ("@trans", vehicle.Transmission.ToString()),
            ("@fuel", vehicle.FuelType.ToString()),
            ("@status", VehicleStatus.Available.ToString()),
            ("@seat", vehicle.SeatingCapacity),
            ("@odo", vehicle.Odometer),
            ("@eff", vehicle.FuelEfficiency),
            ("@cargo", vehicle.CargoCapacity),
            ("@cat", vehicle.VehicleCategoryId)
        );

        return Convert.ToInt32(table.Rows[0]["vehicle_id"]);
    }

    public List<Models.Fleet.Vehicle> GetAllVehicles()
    {
        return MapVehicles(DB.Query("CALL sp_vehicles_get_all();"));
    }

    public Models.Fleet.Vehicle GetVehicleById(int vehicleId)
    {
        var table = DB.Query(
            "CALL sp_vehicles_get_by_id(@id);",
            ("@id", vehicleId)
        );

        if (table.Rows.Count == 0)
            throw new InvalidOperationException("Vehicle not found.");

        return MapVehicle(table.Rows[0]);
    }

    public Models.Fleet.Vehicle GetVehicleFull(int vehicleId)
    {
        var table = DB.Query(
            "CALL sp_vehicles_get_full(@id);",
            ("@id", vehicleId)
        );

        if (table.Rows.Count == 0)
            throw new InvalidOperationException("Vehicle not found.");

        return MapVehicle(table.Rows[0]);
    }

    public void UpdateVehicle(
        int vehicleId,
        string color,
        int newOdometer,
        decimal fuelEfficiency,
        int cargoCapacity,
        int categoryId)
    {
        var vehicle = GetVehicleById(vehicleId);
        EnsureNotRetired(vehicle);

        if (newOdometer < vehicle.Odometer)
            throw new InvalidOperationException("Odometer cannot decrease.");

        DB.Execute(
            "CALL sp_vehicles_update(@id,@color,@odo,@eff,@cargo,@cat);",
            ("@id", vehicleId),
            ("@color", color),
            ("@odo", newOdometer),
            ("@eff", fuelEfficiency),
            ("@cargo", cargoCapacity),
            ("@cat", categoryId)
        );
    }

    public void UpdateVehicleStatus(int vehicleId, VehicleStatus newStatus)
    {
        var vehicle = GetVehicleById(vehicleId);
        EnsureValidStatusTransition(vehicle.Status, newStatus);

        DB.Execute(
            "CALL sp_vehicles_update_status(@id,@status);",
            ("@id", vehicleId),
            ("@status", newStatus.ToString())
        );
    }

    public void RetireVehicle(int vehicleId)
    {
        var vehicle = GetVehicleById(vehicleId);
        if (vehicle.Status == VehicleStatus.Retired)
            return;

        DB.Execute(
            "CALL sp_vehicles_retire(@id);",
            ("@id", vehicleId)
        );
    }

    public void UpdateVehicleOdometer(int vehicleId, int newOdometer)
    {
        var vehicle = GetVehicleById(vehicleId);
        EnsureNotRetired(vehicle);

        if (newOdometer < vehicle.Odometer)
            throw new InvalidOperationException("Odometer cannot decrease.");

        DB.Execute(
            "CALL sp_vehicles_update_odometer(@id,@odo);",
            ("@id", vehicleId),
            ("@odo", newOdometer)
        );
    }

    // -------------------------------------------------
    // MAINTENANCE
    // -------------------------------------------------

    public int StartMaintenance(
        int vehicleId,
        string description,
        decimal cost,
        DateTime startDate)
    {
        EnsureNotRetired(GetVehicleById(vehicleId));

        var table = DB.Query(
            "CALL sp_maintenance_records_create(@vid,@desc,@cost,@start);",
            ("@vid", vehicleId),
            ("@desc", description),
            ("@cost", cost),
            ("@start", startDate)
        );

        UpdateVehicleStatus(vehicleId, VehicleStatus.UnderMaintenance);
        return Convert.ToInt32(table.Rows[0]["maintenance_record_id"]);
    }

    public void CloseMaintenance(
        int maintenanceRecordId,
        DateTime endDate,
        VehicleStatus postMaintenanceStatus)
    {
        var record = GetMaintenanceById(maintenanceRecordId);

        DB.Execute(
            "CALL sp_maintenance_records_close(@id,@end);",
            ("@id", maintenanceRecordId),
            ("@end", endDate)
        );

        UpdateVehicleStatus(record.VehicleId, postMaintenanceStatus);
    }

    public List<MaintenanceRecord> GetMaintenanceByVehicle(int vehicleId)
    {
        var table = DB.Query(
            "CALL sp_maintenance_records_get_by_vehicle(@id);",
            ("@id", vehicleId)
        );

        var list = new List<MaintenanceRecord>();
        foreach (DataRow row in table.Rows)
            list.Add(MapMaintenance(row));

        return list;
    }

    public MaintenanceRecord GetMaintenanceById(int maintenanceId)
    {
        var table = DB.Query(
            "CALL sp_maintenance_records_get_by_id(@id);",
            ("@id", maintenanceId)
        );

        if (table.Rows.Count == 0)
            throw new InvalidOperationException("Maintenance record not found.");

        return MapMaintenance(table.Rows[0]);
    }

    // -------------------------------------------------
    // CATEGORIES
    // -------------------------------------------------

    public int CreateCategory(string name, string? description)
    {
        var table = DB.Query(
            "CALL sp_vehicle_categories_create(@name,@desc);",
            ("@name", name),
            ("@desc", description)
        );

        return Convert.ToInt32(table.Rows[0]["category_id"]);
    }

    public void UpdateCategory(int categoryId, string name, string? description)
    {
        DB.Execute(
            "CALL sp_vehicle_categories_update(@id,@name,@desc);",
            ("@id", categoryId),
            ("@name", name),
            ("@desc", description)
        );
    }

    public void DeleteCategory(int categoryId)
    {
        DB.Execute(
            "CALL sp_vehicle_categories_delete(@id);",
            ("@id", categoryId)
        );
    }

    public List<VehicleCategory> GetAllCategories()
    {
        var table = DB.Query("CALL sp_vehicle_categories_get_all();");

        var list = new List<VehicleCategory>();
        foreach (DataRow row in table.Rows)
        {
            list.Add(new VehicleCategory
            {
                Id = Convert.ToInt32(row["id"]),
                Name = row["name"].ToString()!,
                Description = row["description"] as string
            });
        }

        return list;
    }

    public VehicleCategory GetCategoryById(int categoryId)
    {
        var table = DB.Query(
            "CALL sp_vehicle_categories_get_by_id(@id);",
            ("@id", categoryId)
        );

        if (table.Rows.Count == 0)
            throw new InvalidOperationException("Category not found.");

        var row = table.Rows[0];
        return new VehicleCategory
        {
            Id = Convert.ToInt32(row["id"]),
            Name = row["name"].ToString()!,
            Description = row["description"] as string
        };
    }

    // -------------------------------------------------
    // FEATURES
    // -------------------------------------------------

    public int CreateFeature(string name)
    {
        var table = DB.Query(
            "CALL sp_vehicle_features_create(@name);",
            ("@name", name)
        );

        return Convert.ToInt32(table.Rows[0]["feature_id"]);
    }

    public void UpdateFeature(int featureId, string name)
    {
        DB.Execute(
            "CALL sp_vehicle_features_update(@id,@name);",
            ("@id", featureId),
            ("@name", name)
        );
    }

    public void DeleteFeature(int featureId)
    {
        DB.Execute(
            "CALL sp_vehicle_features_delete(@id);",
            ("@id", featureId)
        );
    }

    public List<VehicleFeature> GetAllFeatures()
    {
        var table = DB.Query("CALL sp_vehicle_features_get_all();");

        var list = new List<VehicleFeature>();
        foreach (DataRow row in table.Rows)
            list.Add(new VehicleFeature
            {
                Id = Convert.ToInt32(row["id"]),
                Name = row["name"].ToString()!
            });

        return list;
    }

    public VehicleFeature GetFeatureById(int featureId)
    {
        var table = DB.Query(
            "CALL sp_vehicle_features_get_by_id(@id);",
            ("@id", featureId)
        );

        if (table.Rows.Count == 0)
            throw new InvalidOperationException("Feature not found.");

        var row = table.Rows[0];
        return new VehicleFeature
        {
            Id = Convert.ToInt32(row["id"]),
            Name = row["name"].ToString()!
        };
    }

    // -------------------------------------------------
    // FEATURE MAPPINGS
    // -------------------------------------------------

    public void AddFeatureToVehicle(int vehicleId, int featureId)
    {
        EnsureNotRetired(GetVehicleById(vehicleId));

        DB.Execute(
            "CALL sp_vehicle_feature_mappings_add(@vid,@fid);",
            ("@vid", vehicleId),
            ("@fid", featureId)
        );
    }

    public void RemoveFeatureFromVehicle(int vehicleId, int featureId)
    {
        DB.Execute(
            "CALL sp_vehicle_feature_mappings_remove(@vid,@fid);",
            ("@vid", vehicleId),
            ("@fid", featureId)
        );
    }

    public List<VehicleFeature> GetVehicleFeatures(int vehicleId)
    {
        var table = DB.Query(
            "CALL sp_vehicle_feature_mappings_get_by_vehicle(@id);",
            ("@id", vehicleId)
        );

        var list = new List<VehicleFeature>();
        foreach (DataRow row in table.Rows)
            list.Add(new VehicleFeature
            {
                Id = Convert.ToInt32(row["feature_id"]),
                Name = row["feature_name"].ToString()!
            });

        return list;
    }

    // -------------------------------------------------
    // VEHICLE IMAGES
    // -------------------------------------------------

    public void AddVehicleImage(
        int vehicleId,
        Stream imageStream,
        string originalFileName)
    {
        EnsureNotRetired(GetVehicleById(vehicleId));

        var extension = Path.GetExtension(originalFileName);
        if (string.IsNullOrWhiteSpace(extension))
            throw new InvalidOperationException("Invalid vehicle image file.");

        var directory = GetVehicleImageDirectory(vehicleId);
        Directory.CreateDirectory(directory);

        var fileName = $"{Guid.NewGuid()}{extension}";
        var relativePath = Path.Combine(
            VehicleImageFolder,
            vehicleId.ToString(),
            fileName
        );

        using var fs = new FileStream(
            Path.Combine(StorageRoot, relativePath),
            FileMode.Create,
            FileAccess.Write);

        imageStream.CopyTo(fs);

        DB.Execute(
            "CALL sp_vehicle_images_create(@vid,@path);",
            ("@vid", vehicleId),
            ("@path", relativePath)
        );
    }

    public void RemoveVehicleImage(int imageId)
    {
        var table = DB.Query(
            "CALL sp_vehicle_images_get_by_id(@id);",
            ("@id", imageId)
        );

        if (table.Rows.Count == 0)
            return;

        var imagePath = table.Rows[0]["image_path"].ToString()!;
        var fullPath = Path.Combine(StorageRoot, imagePath);

        if (File.Exists(fullPath))
            File.Delete(fullPath);

        DB.Execute(
            "CALL sp_vehicle_images_delete(@id);",
            ("@id", imageId)
        );
    }

    public List<VehicleImage> GetVehicleImages(int vehicleId)
    {
        var table = DB.Query(
            "CALL sp_vehicle_images_get_by_vehicle_id(@id);",
            ("@id", vehicleId)
        );

        var list = new List<VehicleImage>();
        foreach (DataRow row in table.Rows)
            list.Add(new VehicleImage
            {
                Id = Convert.ToInt32(row["id"]),
                VehicleId = Convert.ToInt32(row["vehicle_id"]),
                ImagePath = row["image_path"].ToString()!
            });

        return list;
    }

    // -------------------------------------------------
    // INTERNAL HELPERS
    // -------------------------------------------------

    private static void EnsureNotRetired(Models.Fleet.Vehicle vehicle)
    {
        if (vehicle.Status == VehicleStatus.Retired)
            throw new InvalidOperationException(
                "Retired vehicles cannot be modified.");
    }

    private static void EnsureValidStatusTransition(
        VehicleStatus current,
        VehicleStatus next)
    {
        if (current == VehicleStatus.Retired)
            throw new InvalidOperationException(
                "Retired vehicle cannot change status.");

        bool valid = current switch
        {
            VehicleStatus.Available =>
                next is VehicleStatus.Reserved
                    or VehicleStatus.UnderMaintenance
                    or VehicleStatus.OutOfService,

            VehicleStatus.Reserved =>
                next is VehicleStatus.Rented
                    or VehicleStatus.Available,

            VehicleStatus.Rented =>
                next is VehicleStatus.UnderMaintenance
                    or VehicleStatus.Available,

            VehicleStatus.UnderMaintenance =>
                next is VehicleStatus.Available
                    or VehicleStatus.OutOfService,

            VehicleStatus.OutOfService =>
                next is VehicleStatus.UnderMaintenance
                    or VehicleStatus.Retired,

            _ => false
        };

        if (!valid)
            throw new InvalidOperationException(
                $"Illegal vehicle status transition: {current} → {next}");
    }

    // -------------------------------------------------
    // MAPPING
    // -------------------------------------------------

    private static Models.Fleet.Vehicle MapVehicle(DataRow row)
    {
        return new Models.Fleet.Vehicle
        {
            Id = Convert.ToInt32(row["id"]),
            VehicleCode = row["vehicle_code"].ToString()!,
            Make = row["make"].ToString()!,
            Model = row["model"].ToString()!,
            Year = Convert.ToInt32(row["year"]),
            Color = row["color"].ToString()!,
            LicensePlate = row["license_plate"].ToString()!,
            VIN = row["vin"].ToString()!,
            Transmission = Enum.Parse<TransmissionType>(
                row["transmission"].ToString()!),
            FuelType = Enum.Parse<FuelType>(
                row["fuel_type"].ToString()!),
            Status = Enum.Parse<VehicleStatus>(
                row["status"].ToString()!),
            SeatingCapacity = Convert.ToInt32(
                row["seating_capacity"]),
            Odometer = Convert.ToInt32(row["odometer"]),
            FuelEfficiency = Convert.ToDecimal(
                row["fuel_efficiency"]),
            CargoCapacity = Convert.ToInt32(
                row["cargo_capacity"]),
            VehicleCategoryId = Convert.ToInt32(
                row["vehicle_category_id"])
        };
    }

    private static List<Models.Fleet.Vehicle> MapVehicles(
        DataTable table)
    {
        var list = new List<Models.Fleet.Vehicle>();
        foreach (DataRow row in table.Rows)
            list.Add(MapVehicle(row));
        return list;
    }

    private static MaintenanceRecord MapMaintenance(
        DataRow row)
    {
        return new MaintenanceRecord
        {
            Id = Convert.ToInt32(row["id"]),
            VehicleId = Convert.ToInt32(row["vehicle_id"]),
            Description = row["description"].ToString()!,
            Cost = Convert.ToDecimal(row["cost"]),
            StartDate = Convert.ToDateTime(
                row["start_date"]),
            EndDate = row["end_date"] == DBNull.Value
                ? null
                : Convert.ToDateTime(row["end_date"])
        };
    }

    private static string GetVehicleImageDirectory(
        int vehicleId)
    {
        return Path.Combine(
            StorageRoot,
            VehicleImageFolder,
            vehicleId.ToString()
        );
    }
}
