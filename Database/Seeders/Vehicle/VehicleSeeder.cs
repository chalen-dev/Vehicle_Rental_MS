using VRMS.Enums;
using VRMS.Services.Vehicle;

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
        }, ac, gps);

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
        }, ac, gps);

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
        }, ac);

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
        }, ac);

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
        }, ac);

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
        }, ac, gps, cam);

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
        }, ac, gps, cam);

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
        }, ac);

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
        }, ac);

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
        }, ac);
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

    private void SeedVehicle(Models.Fleet.Vehicle vehicle, params int[] features)
    {
        var existing = _vehicleService
            .GetAllVehicles()
            .FirstOrDefault(v => v.VehicleCode == vehicle.VehicleCode);

        var vehicleId = existing?.Id
                        ?? _vehicleService.CreateVehicle(vehicle);

        foreach (var featureId in features)
            _vehicleService.AddFeatureToVehicle(vehicleId, featureId);
    }
}
