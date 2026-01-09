using System;
using System.Collections.Generic;
using System.Data;
using VRMS.Database;
using VRMS.Enums;
using VRMS.Helpers.SqlEscape;
using VRMS.Models.Fleet;

namespace VRMS.Services;

public class VehicleService
{
    // -------------------------------------------------
    // VEHICLES
    // -------------------------------------------------

    public int CreateVehicle(Vehicle vehicle)
    {
        var table = DB.ExecuteQuery($"""
            CALL sp_vehicles_create(
                '{Sql.Esc(vehicle.VehicleCode)}',
                '{Sql.Esc(vehicle.Make)}',
                '{Sql.Esc(vehicle.Model)}',
                {vehicle.Year},
                '{Sql.Esc(vehicle.Color)}',
                '{Sql.Esc(vehicle.LicensePlate)}',
                '{Sql.Esc(vehicle.VIN)}',
                '{vehicle.Transmission}',
                '{vehicle.FuelType}',
                '{VehicleStatus.Available}',
                {vehicle.SeatingCapacity},
                {vehicle.Odometer},
                {vehicle.VehicleCategoryId}
            );
        """);

        return Convert.ToInt32(table.Rows[0]["vehicle_id"]);
    }

    public List<Vehicle> GetAllVehicles()
    {
        var table = DB.ExecuteQuery("CALL sp_vehicles_get_all();");
        return MapVehicles(table);
    }

    public Vehicle GetVehicleById(int vehicleId)
    {
        var table = DB.ExecuteQuery($"CALL sp_vehicles_get_by_id({vehicleId});");

        if (table.Rows.Count == 0)
            throw new InvalidOperationException("Vehicle not found.");

        return MapVehicle(table.Rows[0]);
    }

    public Vehicle GetVehicleFull(int vehicleId)
    {
        var table = DB.ExecuteQuery($"CALL sp_vehicles_get_full({vehicleId});");

        if (table.Rows.Count == 0)
            throw new InvalidOperationException("Vehicle not found.");

        return MapVehicle(table.Rows[0]);
    }

    public void UpdateVehicle(int vehicleId, string color, int newOdometer, int categoryId)
    {
        var vehicle = GetVehicleById(vehicleId);

        EnsureNotRetired(vehicle);

        if (newOdometer < vehicle.Odometer)
            throw new InvalidOperationException("Odometer cannot decrease.");

        DB.ExecuteNonQuery($"""
            CALL sp_vehicles_update(
                {vehicleId},
                '{Sql.Esc(color)}',
                {newOdometer},
                {categoryId}
            );
        """);
    }

    public void UpdateVehicleStatus(int vehicleId, VehicleStatus newStatus)
    {
        var vehicle = GetVehicleById(vehicleId);

        EnsureValidStatusTransition(vehicle.Status, newStatus);

        DB.ExecuteNonQuery($"""
            CALL sp_vehicles_update_status(
                {vehicleId},
                '{newStatus}'
            );
        """);
    }

    public void RetireVehicle(int vehicleId)
    {
        var vehicle = GetVehicleById(vehicleId);

        if (vehicle.Status == VehicleStatus.Retired)
            return;

        DB.ExecuteNonQuery($"CALL sp_vehicles_retire({vehicleId});");
    }

    // -------------------------------------------------
    // MAINTENANCE
    // -------------------------------------------------

    public int StartMaintenance(
        int vehicleId,
        string description,
        decimal cost,
        DateTime startDate
    )
    {
        var vehicle = GetVehicleById(vehicleId);
        EnsureNotRetired(vehicle);

        var table = DB.ExecuteQuery($"""
            CALL sp_maintenance_records_create(
                {vehicleId},
                '{Sql.Esc(description)}',
                {cost},
                '{startDate:yyyy-MM-dd}'
            );
        """);

        UpdateVehicleStatus(vehicleId, VehicleStatus.UnderMaintenance);

        return Convert.ToInt32(table.Rows[0]["maintenance_record_id"]);
    }

    public void CloseMaintenance(
        int maintenanceRecordId,
        DateTime endDate,
        VehicleStatus postMaintenanceStatus
    )
    {
        var record = GetMaintenanceById(maintenanceRecordId);

        DB.ExecuteNonQuery($"""
            CALL sp_maintenance_records_close(
                {maintenanceRecordId},
                '{endDate:yyyy-MM-dd}'
            );
        """);

        UpdateVehicleStatus(record.VehicleId, postMaintenanceStatus);
    }

    public List<MaintenanceRecord> GetMaintenanceByVehicle(int vehicleId)
    {
        var table = DB.ExecuteQuery(
            $"CALL sp_maintenance_records_get_by_vehicle({vehicleId});"
        );

        var list = new List<MaintenanceRecord>();

        foreach (DataRow row in table.Rows)
            list.Add(MapMaintenance(row));

        return list;
    }

    public MaintenanceRecord GetMaintenanceById(int maintenanceId)
    {
        var table = DB.ExecuteQuery(
            $"CALL sp_maintenance_records_get_by_id({maintenanceId});"
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
        var table = DB.ExecuteQuery($"""
            CALL sp_vehicle_categories_create(
                '{Sql.Esc(name)}',
                {(description == null ? "NULL" : $"'{Sql.Esc(description)}'")}
            );
        """);

        return Convert.ToInt32(table.Rows[0]["category_id"]);
    }

    public void UpdateCategory(int categoryId, string name, string? description)
    {
        DB.ExecuteNonQuery($"""
            CALL sp_vehicle_categories_update(
                {categoryId},
                '{Sql.Esc(name)}',
                {(description == null ? "NULL" : $"'{Sql.Esc(description)}'")}
            );
        """);
    }

    public void DeleteCategory(int categoryId)
    {
        DB.ExecuteNonQuery($"CALL sp_vehicle_categories_delete({categoryId});");
    }

    public List<VehicleCategory> GetAllCategories()
    {
        var table = DB.ExecuteQuery("CALL sp_vehicle_categories_get_all();");

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
        var table = DB.ExecuteQuery(
            $"CALL sp_vehicle_categories_get_by_id({categoryId});"
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
        var table = DB.ExecuteQuery(
            $"CALL sp_vehicle_features_create('{Sql.Esc(name)}');"
        );

        return Convert.ToInt32(table.Rows[0]["feature_id"]);
    }

    public void UpdateFeature(int featureId, string name)
    {
        DB.ExecuteNonQuery(
            $"CALL sp_vehicle_features_update({featureId}, '{Sql.Esc(name)}');"
        );
    }

    public void DeleteFeature(int featureId)
    {
        DB.ExecuteNonQuery($"CALL sp_vehicle_features_delete({featureId});");
    }

    public List<VehicleFeature> GetAllFeatures()
    {
        var table = DB.ExecuteQuery("CALL sp_vehicle_features_get_all();");

        var list = new List<VehicleFeature>();
        foreach (DataRow row in table.Rows)
        {
            list.Add(new VehicleFeature
            {
                Id = Convert.ToInt32(row["id"]),
                Name = row["name"].ToString()!
            });
        }
        return list;
    }

    public VehicleFeature GetFeatureById(int featureId)
    {
        var table = DB.ExecuteQuery(
            $"CALL sp_vehicle_features_get_by_id({featureId});"
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

        DB.ExecuteNonQuery(
            $"CALL sp_vehicle_feature_mappings_add({vehicleId}, {featureId});"
        );
    }

    public void RemoveFeatureFromVehicle(int vehicleId, int featureId)
    {
        DB.ExecuteNonQuery(
            $"CALL sp_vehicle_feature_mappings_remove({vehicleId}, {featureId});"
        );
    }

    public List<VehicleFeature> GetVehicleFeatures(int vehicleId)
    {
        var table = DB.ExecuteQuery(
            $"CALL sp_vehicle_feature_mappings_get_by_vehicle({vehicleId});"
        );

        var list = new List<VehicleFeature>();
        foreach (DataRow row in table.Rows)
        {
            list.Add(new VehicleFeature
            {
                Id = Convert.ToInt32(row["feature_id"]),
                Name = row["feature_name"].ToString()!
            });
        }
        return list;
    }

    // -------------------------------------------------
    // VEHICLE IMAGES
    // -------------------------------------------------

    public void AddVehicleImage(int vehicleId, string imagePath)
    {
        EnsureNotRetired(GetVehicleById(vehicleId));

        DB.ExecuteNonQuery($"""
            CALL sp_vehicle_images_create(
                {vehicleId},
                '{Sql.Esc(imagePath)}'
            );
        """);
    }

    public void RemoveVehicleImage(int imageId)
    {
        DB.ExecuteNonQuery($"CALL sp_vehicle_images_delete({imageId});");
    }

    public List<VehicleImage> GetVehicleImages(int vehicleId)
    {
        var table = DB.ExecuteQuery(
            $"CALL sp_vehicle_images_get_by_vehicle_id({vehicleId});"
        );

        var list = new List<VehicleImage>();
        foreach (DataRow row in table.Rows)
        {
            list.Add(new VehicleImage
            {
                Id = Convert.ToInt32(row["id"]),
                VehicleId = Convert.ToInt32(row["vehicle_id"]),
                ImagePath = row["image_path"].ToString()!
            });
        }
        return list;
    }

    // -------------------------------------------------
    // INTERNAL HELPERS
    // -------------------------------------------------

    private static void EnsureNotRetired(Vehicle vehicle)
    {
        if (vehicle.Status == VehicleStatus.Retired)
            throw new InvalidOperationException("Retired vehicles cannot be modified.");
    }

    private static void EnsureValidStatusTransition(
        VehicleStatus current,
        VehicleStatus next)
    {
        if (current == VehicleStatus.Retired)
            throw new InvalidOperationException("Retired vehicle cannot change status.");

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

    private static Vehicle MapVehicle(DataRow row)
    {
        return new Vehicle
        {
            Id = Convert.ToInt32(row["id"]),
            VehicleCode = row["vehicle_code"].ToString()!,
            Make = row["make"].ToString()!,
            Model = row["model"].ToString()!,
            Year = Convert.ToInt32(row["year"]),
            Color = row["color"].ToString()!,
            LicensePlate = row["license_plate"].ToString()!,
            VIN = row["vin"].ToString()!,
            Transmission = Enum.Parse<TransmissionType>(row["transmission"].ToString()!),
            FuelType = Enum.Parse<FuelType>(row["fuel_type"].ToString()!),
            Status = Enum.Parse<VehicleStatus>(row["status"].ToString()!),
            SeatingCapacity = Convert.ToInt32(row["seating_capacity"]),
            Odometer = Convert.ToInt32(row["odometer"]),
            VehicleCategoryId = Convert.ToInt32(row["vehicle_category_id"])
        };
    }

    private static List<Vehicle> MapVehicles(DataTable table)
    {
        var list = new List<Vehicle>();
        foreach (DataRow row in table.Rows)
            list.Add(MapVehicle(row));
        return list;
    }

    private static MaintenanceRecord MapMaintenance(DataRow row)
    {
        return new MaintenanceRecord
        {
            Id = Convert.ToInt32(row["id"]),
            VehicleId = Convert.ToInt32(row["vehicle_id"]),
            Description = row["description"].ToString()!,
            Cost = Convert.ToDecimal(row["cost"]),
            StartDate = Convert.ToDateTime(row["start_date"]),
            EndDate = row["end_date"] == DBNull.Value
                ? null
                : Convert.ToDateTime(row["end_date"])
        };
    }
}
