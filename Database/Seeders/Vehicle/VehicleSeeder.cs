using System.IO;
using VRMS.Enums;
using VRMS.Services.Fleet;

namespace VRMS.Database.Seeders.Vehicle;

public class VehicleSeeder : ISeeder
{
    public string Name => nameof(VehicleSeeder);

    private readonly VehicleService _vehicleService;

    public VehicleSeeder(VehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }

    public void Run()
    {
        // Categories
        var sedan   = EnsureCategory("Sedan", "Passenger sedan");
        var suv     = EnsureCategory("SUV", "Sport utility vehicle");
        var mpv     = EnsureCategory("MPV", "Multi-purpose vehicle");
        var van     = EnsureCategory("Van", "Passenger / cargo van");
        var pickup  = EnsureCategory("Pickup", "Utility pickup truck");

        // Features
        var ac   = EnsureFeature("Air Conditioning");
        var gps  = EnsureFeature("GPS");
        var cam  = EnsureFeature("Reverse Camera");

        SeedVehicle(new Models.Fleet.Vehicle
        {
            VehicleCode = "PH-001",
            Make = "Toyota",
            Model = "Vios",
            Year = 2022,
            Color = "White",
            LicensePlate = "ABC-1001",
            VIN = "VIN-PH-001",
            Transmission = TransmissionType.Automatic,
            FuelType = FuelType.Gasoline,
            SeatingCapacity = 5,
            Odometer = 0,
            FuelEfficiency = 17.0m,
            CargoCapacity = 400,
            VehicleCategoryId = sedan
        }, "vios_white.jpg",ac, gps);

        SeedVehicle(new Models.Fleet.Vehicle
        {
            VehicleCode = "PH-002",
            Make = "Toyota",
            Model = "Innova",
            Year = 2021,
            Color = "Black",
            LicensePlate = "ABC-1002",
            VIN = "VIN-PH-002",
            Transmission = TransmissionType.Automatic,
            FuelType = FuelType.Diesel,
            SeatingCapacity = 7,
            Odometer = 0,
            FuelEfficiency = 12.5m,
            CargoCapacity = 550,
            VehicleCategoryId = mpv
        }, "innova_black.jpg",ac, gps);

        SeedVehicle(new Models.Fleet.Vehicle
        {
            VehicleCode = "PH-003",
            Make = "Mitsubishi",
            Model = "Mirage",
            Year = 2022,
            Color = "Red",
            LicensePlate = "ABC-1003",
            VIN = "VIN-PH-003",
            Transmission = TransmissionType.Automatic,
            FuelType = FuelType.Gasoline,
            SeatingCapacity = 5,
            Odometer = 0,
            FuelEfficiency = 22.0m,
            CargoCapacity = 300,
            VehicleCategoryId = sedan
        }, "red_mirage_sedan.jpg",ac);

        SeedVehicle(new Models.Fleet.Vehicle
        {
            VehicleCode = "PH-004",
            Make = "Toyota",
            Model = "Hiace",
            Year = 2020,
            Color = "White",
            LicensePlate = "ABC-1004",
            VIN = "VIN-PH-004",
            Transmission = TransmissionType.Manual,
            FuelType = FuelType.Diesel,
            SeatingCapacity = 15,
            Odometer = 0,
            FuelEfficiency = 9.5m,
            CargoCapacity = 900,
            VehicleCategoryId = van
        }, "white_toyota_hiace.jpg",ac);

        SeedVehicle(new Models.Fleet.Vehicle
        {
            VehicleCode = "PH-005",
            Make = "Nissan",
            Model = "Urvan",
            Year = 2019,
            Color = "White",
            LicensePlate = "ABC-1005",
            VIN = "VIN-PH-005",
            Transmission = TransmissionType.Manual,
            FuelType = FuelType.Diesel,
            SeatingCapacity = 15,
            Odometer = 0,
            FuelEfficiency = 9.0m,
            CargoCapacity = 900,
            VehicleCategoryId = van
        }, "white_nissan_urvan.jpg",ac);

        SeedVehicle(new Models.Fleet.Vehicle
        {
            VehicleCode = "PH-006",
            Make = "Toyota",
            Model = "Fortuner",
            Year = 2022,
            Color = "Black",
            LicensePlate = "ABC-1006",
            VIN = "VIN-PH-006",
            Transmission = TransmissionType.Automatic,
            FuelType = FuelType.Diesel,
            SeatingCapacity = 7,
            Odometer = 0,
            FuelEfficiency = 11.0m,
            CargoCapacity = 600,
            VehicleCategoryId = suv
        }, "black_toyota_fortuner.jpg",ac, gps, cam);

        SeedVehicle(new Models.Fleet.Vehicle
        {
            VehicleCode = "PH-007",
            Make = "Mitsubishi",
            Model = "Montero Sport",
            Year = 2021,
            Color = "Silver",
            LicensePlate = "ABC-1007",
            VIN = "VIN-PH-007",
            Transmission = TransmissionType.Automatic,
            FuelType = FuelType.Diesel,
            SeatingCapacity = 7,
            Odometer = 0,
            FuelEfficiency = 11.5m,
            CargoCapacity = 600,
            VehicleCategoryId = suv
        }, "silver_montero_sport.jpg",ac, gps, cam);

        SeedVehicle(new Models.Fleet.Vehicle
        {
            VehicleCode = "PH-008",
            Make = "Suzuki",
            Model = "Ertiga",
            Year = 2022,
            Color = "Red",
            LicensePlate = "ABC-1008",
            VIN = "VIN-PH-008",
            Transmission = TransmissionType.Automatic,
            FuelType = FuelType.Gasoline,
            SeatingCapacity = 7,
            Odometer = 0,
            FuelEfficiency = 14.0m,
            CargoCapacity = 500,
            VehicleCategoryId = mpv
        }, "red_suzuki_ertiga.jpg",ac);

        SeedVehicle(new Models.Fleet.Vehicle
        {
            VehicleCode = "PH-009",
            Make = "Toyota",
            Model = "Avanza",
            Year = 2021,
            Color = "Blue",
            LicensePlate = "ABC-1009",
            VIN = "VIN-PH-009",
            Transmission = TransmissionType.Automatic,
            FuelType = FuelType.Gasoline,
            SeatingCapacity = 7,
            Odometer = 0,
            FuelEfficiency = 13.5m,
            CargoCapacity = 500,
            VehicleCategoryId = mpv
        }, "blue_toyota_avanza.jpg",ac);

        SeedVehicle(new Models.Fleet.Vehicle
        {
            VehicleCode = "PH-010",
            Make = "Isuzu",
            Model = "D-Max",
            Year = 2022,
            Color = "White",
            LicensePlate = "ABC-1010",
            VIN = "VIN-PH-010",
            Transmission = TransmissionType.Manual,
            FuelType = FuelType.Diesel,
            SeatingCapacity = 5,
            Odometer = 0,
            FuelEfficiency = 12.0m,
            CargoCapacity = 1000,
            VehicleCategoryId = pickup
        }, "white_isuzu_dmax.jpg",ac);
    }

    // -------------------------------------------------
    // HELPERS
    // -------------------------------------------------

    private int EnsureCategory(string name, string description)
    {
        return _vehicleService
                   .GetAllCategories()
                   .FirstOrDefault(c =>
                       c.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                   ?.Id
               ?? _vehicleService.CreateCategory(name, description);
    }

    private int EnsureFeature(string name)
    {
        return _vehicleService
                   .GetAllFeatures()
                   .FirstOrDefault(f =>
                       f.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                   ?.Id
               ?? _vehicleService.CreateFeature(name);
    }

    private void SeedVehicle(
        Models.Fleet.Vehicle vehicle,
        string imageFileName,
        params int[] features)
    {
        var existing = _vehicleService
            .GetAllVehicles()
            .FirstOrDefault(v => v.VehicleCode == vehicle.VehicleCode);

        var vehicleId = existing?.Id
                        ?? _vehicleService.CreateVehicle(vehicle);

        foreach (var featureId in features)
            _vehicleService.AddFeatureToVehicle(vehicleId, featureId);

        AddImageIfExists(vehicleId, imageFileName);
    }

    private static string GetImageBasePath()
    {
        return Path.Combine(
            AppContext.BaseDirectory,
            "Assets",
            "Seed",
            "Vehicles"
        );
    }

    private void AddImageIfExists(
        int vehicleId,
        string imageFileName)
    {
        var basePath = GetImageBasePath();
        var fullPath = Path.Combine(basePath, imageFileName);

        if (!File.Exists(fullPath))
        {
            Console.WriteLine(
                $"      [WARN] Image not found: {imageFileName}");
            return;
        }

        using var stream = File.OpenRead(fullPath);

        _vehicleService.AddVehicleImage(
            vehicleId,
            stream,
            imageFileName
        );

        Console.WriteLine(
            $"      Seeded image: {imageFileName}");
    }
}
