using VRMS.Enums;

namespace VRMS.DTOs.Vehicle;

public class VehicleDto
{
    public int Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public string LicensePlate { get; set; }
    public VehicleStatus Status { get; set; }
}