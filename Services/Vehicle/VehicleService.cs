using VRMS.Enums;
using VRMS.Models.Fleet;
using VRMS.Repositories.Fleet;

namespace VRMS.Services.Fleet;

public class VehicleService
{
    private static readonly string StorageRoot =
    Path.Combine(AppContext.BaseDirectory, "Storage");
    private const string VehicleImageFolder = "Vehicles";

    private readonly VehicleRepository _vehicleRepo;
    private readonly VehicleCategoryRepository _categoryRepo;
    private readonly VehicleFeatureRepository _featureRepo;
    private readonly VehicleFeatureMappingRepository _featureMapRepo;
    private readonly VehicleImageRepository _imageRepo;
    private readonly MaintenanceRepository _maintenanceRepo;

    public VehicleService(
        VehicleRepository vehicleRepo,
        VehicleCategoryRepository categoryRepo,
        VehicleFeatureRepository featureRepo,
        VehicleFeatureMappingRepository featureMapRepo,
        VehicleImageRepository imageRepo,
        MaintenanceRepository maintenanceRepo)
    {
        _vehicleRepo = vehicleRepo;
        _categoryRepo = categoryRepo;
        _featureRepo = featureRepo;
        _featureMapRepo = featureMapRepo;
        _imageRepo = imageRepo;
        _maintenanceRepo = maintenanceRepo;
    }

    // -------------------------------------------------
    // VEHICLES
    // -------------------------------------------------

    public int CreateVehicle(Vehicle vehicle)
    {
        vehicle.Status = VehicleStatus.Available;
        return _vehicleRepo.Create(vehicle);
    }

    public Vehicle GetVehicleById(int vehicleId)
        => _vehicleRepo.GetById(vehicleId);

    public List<Vehicle> GetAllVehicles()
        => _vehicleRepo.GetAll();

    public void UpdateVehicle(
        int vehicleId,
        string color,
        int newOdometer,
        decimal fuelEfficiency,
        int cargoCapacity,
        int categoryId)
    {
        var vehicle = _vehicleRepo.GetById(vehicleId);
        EnsureNotRetired(vehicle);

        if (newOdometer < vehicle.Odometer)
            throw new InvalidOperationException(
                "Odometer cannot decrease.");

        _vehicleRepo.UpdateDetails(
            vehicleId,
            color,
            newOdometer,
            fuelEfficiency,
            cargoCapacity,
            categoryId);
    }

    public void UpdateVehicleStatus(
        int vehicleId,
        VehicleStatus newStatus)
    {
        var vehicle = _vehicleRepo.GetById(vehicleId);
        EnsureValidStatusTransition(vehicle.Status, newStatus);
        _vehicleRepo.UpdateStatus(vehicleId, newStatus);
    }

    public void RetireVehicle(int vehicleId)
    {
        var vehicle = _vehicleRepo.GetById(vehicleId);
        if (vehicle.Status == VehicleStatus.Retired)
            return;

        _vehicleRepo.Retire(vehicleId);
    }

    public void UpdateVehicleOdometer(
        int vehicleId,
        int newOdometer)
    {
        var vehicle = _vehicleRepo.GetById(vehicleId);
        EnsureNotRetired(vehicle);

        if (newOdometer < vehicle.Odometer)
            throw new InvalidOperationException(
                "Odometer cannot decrease.");

        _vehicleRepo.UpdateDetails(
            vehicleId,
            vehicle.Color,
            newOdometer,
            vehicle.FuelEfficiency,
            vehicle.CargoCapacity,
            vehicle.VehicleCategoryId);
    }
    
    public Vehicle GetVehicleFull(int vehicleId)
    {
        return _vehicleRepo.GetFullById(vehicleId);
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
        var vehicle = _vehicleRepo.GetById(vehicleId);
        EnsureNotRetired(vehicle);

        var maintenanceId =
            _maintenanceRepo.Create(
                vehicleId,
                description,
                cost,
                startDate);

        _vehicleRepo.UpdateStatus(
            vehicleId,
            VehicleStatus.UnderMaintenance);

        return maintenanceId;
    }

    public void CloseMaintenance(
        int maintenanceRecordId,
        DateTime endDate,
        VehicleStatus postMaintenanceStatus)
    {
        var record =
            _maintenanceRepo.GetById(
                maintenanceRecordId);

        _maintenanceRepo.Close(
            maintenanceRecordId,
            endDate);

        UpdateVehicleStatus(
            record.VehicleId,
            postMaintenanceStatus);
    }

    public List<MaintenanceRecord> GetMaintenanceByVehicle(
        int vehicleId)
        => _maintenanceRepo.GetByVehicle(vehicleId);

    public MaintenanceRecord GetMaintenanceById(
        int maintenanceId)
        => _maintenanceRepo.GetById(maintenanceId);

    // -------------------------------------------------
    // CATEGORIES
    // -------------------------------------------------

    public int CreateCategory(
        string name,
        string? description)
        => _categoryRepo.Create(name, description);

    public void UpdateCategory(
        int categoryId,
        string name,
        string? description)
        => _categoryRepo.Update(
            categoryId,
            name,
            description);

    public void DeleteCategory(int categoryId)
        => _categoryRepo.Delete(categoryId);

    public List<VehicleCategory> GetAllCategories()
        => _categoryRepo.GetAll();

    public VehicleCategory GetCategoryById(
        int categoryId)
        => _categoryRepo.GetById(categoryId);

    // -------------------------------------------------
    // FEATURES
    // -------------------------------------------------

    public int CreateFeature(string name)
        => _featureRepo.Create(name);

    public void UpdateFeature(
        int featureId,
        string name)
        => _featureRepo.Update(featureId, name);

    public void DeleteFeature(int featureId)
        => _featureRepo.Delete(featureId);

    public List<VehicleFeature> GetAllFeatures()
        => _featureRepo.GetAll();

    public VehicleFeature GetFeatureById(
        int featureId)
        => _featureRepo.GetById(featureId);

    // -------------------------------------------------
    // FEATURE MAPPINGS
    // -------------------------------------------------

    public void AddFeatureToVehicle(
        int vehicleId,
        int featureId)
    {
        EnsureNotRetired(
            _vehicleRepo.GetById(vehicleId));

        _featureMapRepo.Add(
            vehicleId,
            featureId);
    }

    public void RemoveFeatureFromVehicle(
        int vehicleId,
        int featureId)
        => _featureMapRepo.Remove(
            vehicleId,
            featureId);

    public List<VehicleFeature> GetVehicleFeatures(
        int vehicleId)
        => _featureMapRepo.GetByVehicle(
            vehicleId);

    // -------------------------------------------------
    // VEHICLE IMAGES
    // -------------------------------------------------

    public void AddVehicleImage(
        int vehicleId,
        Stream imageStream,
        string originalFileName)
    {
        EnsureNotRetired(
            _vehicleRepo.GetById(vehicleId));

        var extension =
            Path.GetExtension(originalFileName);

        if (string.IsNullOrWhiteSpace(extension))
            throw new InvalidOperationException(
                "Invalid vehicle image file.");

        var directory =
            GetVehicleImageDirectory(vehicleId);

        Directory.CreateDirectory(directory);

        var fileName =
            $"{Guid.NewGuid()}{extension}";

        var relativePath =
            Path.Combine(
                VehicleImageFolder,
                vehicleId.ToString(),
                fileName);

        using var fs =
            new FileStream(
                Path.Combine(StorageRoot, relativePath),
                FileMode.Create,
                FileAccess.Write);

        imageStream.CopyTo(fs);

        _imageRepo.Create(
            vehicleId,
            relativePath);
    }

    public void RemoveVehicleImage(int imageId)
    {
        var image =
            _imageRepo.GetById(imageId);

        var fullPath =
            Path.Combine(
                StorageRoot,
                image.ImagePath);

        if (File.Exists(fullPath))
            File.Delete(fullPath);

        _imageRepo.Delete(imageId);
    }

    public List<VehicleImage> GetVehicleImages(
        int vehicleId)
        => _imageRepo.GetByVehicle(vehicleId);

    // -------------------------------------------------
    // INTERNAL RULES
    // -------------------------------------------------

    private static void EnsureNotRetired(
        Vehicle vehicle)
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

    private static string GetVehicleImageDirectory(
        int vehicleId)
        => Path.Combine(
            StorageRoot,
            VehicleImageFolder,
            vehicleId.ToString());
}
