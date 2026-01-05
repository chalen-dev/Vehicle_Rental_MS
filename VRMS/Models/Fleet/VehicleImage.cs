namespace VRMS.Models.Fleet;

public class VehicleImage
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public string ImagePath { get; set; } = string.Empty;
}