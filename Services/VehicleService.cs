using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using VRMS.Database;
using VRMS.Enums;
using VRMS.Models.Fleet;

namespace VRMS.Services;

public class VehicleService
{
    private const string StorageRoot = "Storage";

    // ----------------------------
    // VEHICLE
    // ----------------------------

    public int CreateVehicle(
        string vehicleCode,
        string make,
        string model,
        int year,
        string color,
        string licensePlate,
        string vin,
        TransmissionType transmission,
        FuelType fuelType,
        VehicleStatus status,
        int seatingCapacity,
        int odometer,
        int vehicleCategoryId
    )
    {
        var result = DB.ExecuteScalar($"""
            CALL sp_vehicles_create(
                '{vehicleCode}',
                '{make}',
                '{model}',
                {year},
                '{color}',
                '{licensePlate}',
                '{vin}',
                '{transmission}',
                '{fuelType}',
                '{status}',
                {seatingCapacity},
                {odometer},
                {vehicleCategoryId}
            );
        """);

        return Convert.ToInt32(result);
    }

    public Vehicle? GetById(int id)
    {
        var table = DB.ExecuteQuery($"CALL sp_vehicles_get_by_id({id});");
        if (table.Rows.Count == 0)
            return null;

        return MapVehicle(table.Rows[0]);
    }

    public List<Vehicle> GetAll()
    {
        var table = DB.ExecuteQuery("CALL sp_vehicles_get_all();");
        var list = new List<Vehicle>();

        foreach (DataRow row in table.Rows)
            list.Add(MapVehicle(row));

        return list;
    }

    public void UpdateStatus(int id, VehicleStatus status)
    {
        DB.ExecuteNonQuery($"""
            CALL sp_vehicles_update_status(
                {id},
                '{status}'
            );
        """);
    }

    public void Retire(int id)
    {
        DB.ExecuteNonQuery($"CALL sp_vehicles_retire({id});");
    }

    // ----------------------------
    // IMAGES (Storage-aware)
    // ----------------------------

    public int AddImage(int vehicleId, string sourceFilePath)
    {
        var fileName = Path.GetFileName(sourceFilePath);
        var relativePath = $"vehicle/{vehicleId}/{fileName}";
        var fullPath = Path.Combine(StorageRoot, relativePath);

        Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);
        File.Copy(sourceFilePath, fullPath, overwrite: true);

        var result = DB.ExecuteScalar($"""
            CALL sp_vehicle_images_create(
                {vehicleId},
                '{relativePath}'
            );
        """);

        return Convert.ToInt32(result);
    }

    public List<VehicleImage> GetImages(int vehicleId)
    {
        var table = DB.ExecuteQuery($"CALL sp_vehicle_images_get_by_vehicle({vehicleId});");
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

    public void DeleteImage(int imageId, string imagePath)
    {
        var fullPath = Path.Combine(StorageRoot, imagePath);
        if (File.Exists(fullPath))
            File.Delete(fullPath);

        DB.ExecuteNonQuery($"CALL sp_vehicle_images_delete({imageId});");
    }

    // ----------------------------
    // MAPPING
    // ----------------------------

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
}
