using VRMS.Enums;

namespace VRMS.Models.Fleet;

public class Vehicle
{
    public int Id { get; set; }
    public string VehicleCode { get; set; } = string.Empty;
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public string Color { get; set; } = string.Empty;
    public string LicensePlate { get; set; } = string.Empty;
    public string VIN { get; set; } = string.Empty;

    public TransmissionType Transmission { get; set; }
    public FuelType FuelType { get; set; }
    public int SeatingCapacity { get; set; }
    public int Odometer { get; set; }

    public VehicleStatus Status { get; set; } = VehicleStatus.Available;
    public int VehicleCategoryId { get; set; }
}