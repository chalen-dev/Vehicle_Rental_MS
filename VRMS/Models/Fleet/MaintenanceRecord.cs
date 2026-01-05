namespace VRMS.Models.Fleet;

public class MaintenanceRecord
{
    public int Id { get; set; }
    public int VehicleId { get; set; }

    public string Description { get; set; } = string.Empty;
    public decimal Cost { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}