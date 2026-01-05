using VRMS.Enums;

namespace VRMS.Models.Rentals;

public class VehicleInspection
{
    public int Id { get; set; }
    public int RentalId { get; set; }
    public InspectionType InspectionType { get; set; }

    public string Notes { get; set; } = string.Empty;
    public string FuelLevel { get; set; } = string.Empty;
    public string Cleanliness { get; set; } = string.Empty;
}