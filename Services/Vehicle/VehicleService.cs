using VRMS.Enums;
using VRMS.Models.Billing;
using VRMS.Models.Fleet;
using VRMS.Repositories.Billing;
using VRMS.Repositories.Fleet;
using VRMS.Repositories.Rentals;

namespace VRMS.Services.Fleet;

/// <summary>
/// Provides business logic for fleet management, including:
/// - Vehicle lifecycle and status transitions
/// - Maintenance tracking
/// - Vehicle categories and features
/// - Vehicle image storage and management
///
/// This service enforces strict vehicle state rules and
/// coordinates database persistence with file system storage.
/// </summary>
public class VehicleService
{
    /// <summary>
    /// Root directory for persistent file storage.
    /// </summary>
    private static readonly string StorageRoot =
        Path.Combine(AppContext.BaseDirectory, "Storage");

    /// <summary>
    /// Folder name used for storing vehicle images.
    /// </summary>
    private const string VehicleImageFolder = "Vehicles";

    /// <summary>Vehicle repository</summary>
    private readonly VehicleRepository _vehicleRepo;

    /// <summary>Vehicle category repository</summary>
    private readonly VehicleCategoryRepository _categoryRepo;

    /// <summary>Vehicle feature repository</summary>
    private readonly VehicleFeatureRepository _featureRepo;

    /// <summary>Vehicle-feature mapping repository</summary>
    private readonly VehicleFeatureMappingRepository _featureMapRepo;

    /// <summary>Vehicle image repository</summary>
    private readonly VehicleImageRepository _imageRepo;

    /// <summary>Maintenance record repository</summary>
    private readonly MaintenanceRepository _maintenanceRepo;

    /// <summary>Rate configuration repository</summary>
    private readonly RateConfigurationRepository _rateRepo;
    
    private readonly RentalRepository _rentalRepo;
    
    

    /// <summary>
    /// Initializes the vehicle service with required repositories.
    /// </summary>
    public VehicleService(
        VehicleRepository vehicleRepo,
        VehicleCategoryRepository categoryRepo,
        VehicleFeatureRepository featureRepo,
        VehicleFeatureMappingRepository featureMapRepo,
        VehicleImageRepository imageRepo,
        MaintenanceRepository maintenanceRepo,
        RateConfigurationRepository rateRepo,
        RentalRepository rentalRepo) 
    {
        _vehicleRepo = vehicleRepo;
        _categoryRepo = categoryRepo;
        _featureRepo = featureRepo;
        _featureMapRepo = featureMapRepo;
        _imageRepo = imageRepo;
        _maintenanceRepo = maintenanceRepo;
        _rateRepo = rateRepo;
        _rentalRepo = rentalRepo; 
    }

    // -------------------------------------------------
    // VEHICLES
    // -------------------------------------------------

    /// <summary>
    /// Creates a new vehicle.
    ///
    /// Newly created vehicles are always marked as Available.
    /// </summary>
    public int CreateVehicle(Vehicle vehicle)
    {
        vehicle.Status = VehicleStatus.Available;
        return _vehicleRepo.Create(vehicle);
    }

    /// <summary>
    /// Retrieves a vehicle by ID.
    /// </summary>
    public Vehicle GetVehicleById(int vehicleId)
        => _vehicleRepo.GetById(vehicleId);

    /// <summary>
    /// Retrieves all vehicles.
    /// </summary>
    public List<Vehicle> GetAllVehicles()
        => _vehicleRepo.GetAll();

    /// <summary>
    /// Updates vehicle details.
    ///
    /// Odometer values may only increase and
    /// retired vehicles cannot be modified.
    /// </summary>
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

    /// <summary>
    /// Updates the status of a vehicle.
    ///
    /// Status transitions are validated against
    /// the vehicle lifecycle state machine.
    /// </summary>
    public void UpdateVehicleStatus(
        int vehicleId,
        VehicleStatus newStatus)
    {
        var vehicle = _vehicleRepo.GetById(vehicleId);
        EnsureValidStatusTransition(vehicle.Status, newStatus);
        _vehicleRepo.UpdateStatus(vehicleId, newStatus);
    }

    /// <summary>
    /// Retires a vehicle permanently.
    ///
    /// Retired vehicles cannot be modified or reused.
    /// </summary>
    public void RetireVehicle(int vehicleId)
    {
        var vehicle = _vehicleRepo.GetById(vehicleId);

        if (vehicle.Status == VehicleStatus.Retired)
            return;

        _vehicleRepo.Retire(vehicleId);
    }

    /// <summary>
    /// Updates only the vehicle odometer.
    /// </summary>
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

    /// <summary>
    /// Retrieves a vehicle with all related data
    /// (features, images, category, etc.).
    /// </summary>
    public Vehicle GetVehicleFull(int vehicleId)
    {
        return _vehicleRepo.GetFullById(vehicleId);
    }

    public List<Vehicle> SearchVehicles(
        VehicleStatus? status,
        string? search)
    {
        return _vehicleRepo.Search(status, search);
    }

    // -------------------------------------------------
    // MAINTENANCE
    // -------------------------------------------------

    /// <summary>
    /// Starts a maintenance record and places the vehicle
    /// into UnderMaintenance status.
    /// </summary>
    public int StartMaintenance(MaintenanceRecord record)
    {
        var vehicle = _vehicleRepo.GetById(record.VehicleId);
        EnsureNotRetired(vehicle);
        

        EnsureNoRentalOverlap(
            record.VehicleId,
            record.StartDate,
            record.EndDate);


        var id = _maintenanceRepo.Create(record);

        _vehicleRepo.UpdateStatus(
            record.VehicleId,
            VehicleStatus.UnderMaintenance);

        return id;
    }




    /// <summary>
    /// Closes a maintenance record and transitions the vehicle
    /// to a post-maintenance status.
    /// </summary>
    public void CloseMaintenance(
        int maintenanceRecordId,
        DateTime endDate,
        MaintenanceStatus status,
        VehicleStatus vehicleStatus)
    {
        var record = _maintenanceRepo.GetById(maintenanceRecordId);

        _maintenanceRepo.Close(
            maintenanceRecordId,
            endDate,
            status);

        UpdateVehicleStatus(
            record.VehicleId,
            vehicleStatus);
    }


    /// <summary>
    /// Retrieves maintenance records for a vehicle.
    /// </summary>
    public List<MaintenanceRecord> GetMaintenanceByVehicle(
        int vehicleId)
        => _maintenanceRepo.GetByVehicle(vehicleId);

    /// <summary>
    /// Retrieves a maintenance record by ID.
    /// </summary>
    public MaintenanceRecord GetMaintenanceById(
        int maintenanceId)
        => _maintenanceRepo.GetById(maintenanceId);
    
    /// <summary>
    /// Returns list of overlapping rentals for a vehicle in [start,end].
    /// Uses rental repo stored proc that already respects 'Active'/'Late' statuses.
    /// </summary>
    public List<Models.Rentals.Rental> GetOverlappingRentalsForVehicle(int vehicleId, DateTime start, DateTime? end)
    {
        var effectiveEnd = end ?? start.AddYears(10);
        return _rentalRepo.GetOverlappingRentals(vehicleId, start, effectiveEnd);
    }

    /// <summary>
    /// Returns true if there is any Scheduled or InProgress maintenance overlapping [start,end].
    /// </summary>
    public bool HasOverlappingMaintenance(int vehicleId, DateTime start, DateTime end)
    {
        var overlaps = _maintenanceRepo.GetOverlapping(vehicleId, start, end);
        return overlaps != null && overlaps.Count > 0;
    }

    // -------------------------------------------------
    // CATEGORIES
    // -------------------------------------------------

    /// <summary>
    /// Creates a vehicle category.
    /// </summary>
    public int CreateCategory(
        string name,
        string? description,
        decimal securityDeposit)
        => _categoryRepo.Create(name, description, securityDeposit);

    /// <summary>
    /// Updates a vehicle category.
    /// </summary>
    public void UpdateCategory(
        int categoryId,
        string name,
        string? description,
        decimal securityDeposit)
        => _categoryRepo.Update(
            categoryId,
            name,
            description,
            securityDeposit);

    /// <summary>
    /// Deletes a vehicle category.
    /// </summary>
    public void DeleteCategory(int categoryId)
        => _categoryRepo.Delete(categoryId);

    /// <summary>
    /// Retrieves all vehicle categories.
    /// </summary>
    public List<VehicleCategory> GetAllCategories()
        => _categoryRepo.GetAll();

    /// <summary>
    /// Retrieves a vehicle category by ID.
    /// </summary>
    public VehicleCategory GetCategoryById(
        int categoryId)
        => _categoryRepo.GetById(categoryId);

    /// <summary>
    /// Updates only the security deposit of a vehicle category.
    /// </summary>
    public void UpdateCategorySecurityDeposit(
        int categoryId,
        decimal securityDeposit)
    {
        if (securityDeposit < 0)
            throw new InvalidOperationException(
                "Security deposit cannot be negative.");

        var category = _categoryRepo.GetById(categoryId);

        _categoryRepo.Update(
            categoryId,
            category.Name,
            category.Description,
            securityDeposit);
    }

    // -------------------------------------------------
    // CATEGORY RATES
    // -------------------------------------------------

    public RateConfiguration? GetCategoryRates(int categoryId)
    {
        try
        {
            return _rateRepo.GetByCategory(categoryId);
        }
        catch (InvalidOperationException)
        {
            return null; // No rates configured yet
        }
    }

    public void UpsertCategoryRates(
        int categoryId,
        decimal daily,
        decimal weekly,
        decimal monthly,
        decimal hourly,
        decimal includedMileagePerDay,
        decimal excessMileageRate)
    {
        if (daily < 0 || weekly < 0 || monthly < 0 || hourly < 0)
            throw new InvalidOperationException(
                "Rates cannot be negative.");

        if (includedMileagePerDay < 0 || excessMileageRate < 0)
            throw new InvalidOperationException(
                "Mileage values cannot be negative.");

        try
        {
            // Try update first
            var existing =
                _rateRepo.GetByCategory(categoryId);

            _rateRepo.Update(
                existing.Id,
                daily,
                weekly,
                monthly,
                hourly,
                includedMileagePerDay,
                excessMileageRate);
        }
        catch (InvalidOperationException)
        {
            // No existing rate → create
            _rateRepo.Create(
                categoryId,
                daily,
                weekly,
                monthly,
                hourly,
                includedMileagePerDay,
                excessMileageRate);
        }
    }

    // -------------------------------------------------
    // FEATURES
    // -------------------------------------------------

    /// <summary>
    /// Creates a vehicle feature.
    /// </summary>
    public int CreateFeature(string name)
        => _featureRepo.Create(name);

    /// <summary>
    /// Updates a vehicle feature.
    /// </summary>
    public void UpdateFeature(
        int featureId,
        string name)
        => _featureRepo.Update(featureId, name);

    /// <summary>
    /// Deletes a vehicle feature.
    /// </summary>
    public void DeleteFeature(int featureId)
        => _featureRepo.Delete(featureId);

    /// <summary>
    /// Retrieves all vehicle features.
    /// </summary>
    public List<VehicleFeature> GetAllFeatures()
        => _featureRepo.GetAll();

    /// <summary>
    /// Retrieves a vehicle feature by ID.
    /// </summary>
    public VehicleFeature GetFeatureById(
        int featureId)
        => _featureRepo.GetById(featureId);

    // -------------------------------------------------
    // FEATURE MAPPINGS
    // -------------------------------------------------

    /// <summary>
    /// Adds a feature to a vehicle.
    /// </summary>
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

    /// <summary>
    /// Removes a feature from a vehicle.
    /// </summary>
    public void RemoveFeatureFromVehicle(
        int vehicleId,
        int featureId)
        => _featureMapRepo.Remove(
            vehicleId,
            featureId);

    /// <summary>
    /// Retrieves all features associated with a vehicle.
    /// </summary>
    public List<VehicleFeature> GetVehicleFeatures(
        int vehicleId)
        => _featureMapRepo.GetByVehicle(
            vehicleId);

    // -------------------------------------------------
    // VEHICLE IMAGES
    // -------------------------------------------------

    /// <summary>
    /// Adds an image to a vehicle.
    ///
    /// Images are stored in the file system and
    /// tracked in the database.
    /// </summary>
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

    /// <summary>
    /// Removes a vehicle image.
    ///
    /// Deletes both the file and database record.
    /// </summary>
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

    /// <summary>
    /// Retrieves all images associated with a vehicle.
    /// </summary>
    public List<VehicleImage> GetVehicleImages(
        int vehicleId)
        => _imageRepo.GetByVehicle(vehicleId);

    // -------------------------------------------------
    // INTERNAL RULES
    // -------------------------------------------------

    /// <summary>
    /// Ensures a vehicle is not retired.
    /// </summary>
    private static void EnsureNotRetired(
        Vehicle vehicle)
    {
        if (vehicle.Status == VehicleStatus.Retired)
            throw new InvalidOperationException(
                "Retired vehicles cannot be modified.");
    }

    /// <summary>
    /// Validates legal vehicle status transitions.
    /// </summary>
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
                    or VehicleStatus.Rented        // ✅ WALK-IN RENTAL
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


    /// <summary>
    /// Resolves the directory for storing vehicle images.
    /// </summary>
    private static string GetVehicleImageDirectory(
        int vehicleId)
        => Path.Combine(
            StorageRoot,
            VehicleImageFolder,
            vehicleId.ToString());
    
    private void EnsureNoRentalOverlap(
        int vehicleId,
        DateTime start,
        DateTime? end)
    {
        var effectiveEnd =
            end ?? start.AddYears(10); // open-ended maintenance

        var rentals =
            _rentalRepo.GetOverlappingRentals(
                vehicleId,
                start,
                effectiveEnd);

        if (rentals.Count == 0)
            return;

        var r = rentals[0];

        var rentalEnd =
            r.ActualReturnDate ?? r.ExpectedReturnDate;

        throw new InvalidOperationException(
            $"Cannot schedule maintenance. Vehicle is rented from " +
            $"{r.PickupDate:yyyy-MM-dd} to {rentalEnd:yyyy-MM-dd}.");
    }

}