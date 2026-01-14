using VRMS.Enums;

namespace VRMS.Models.Fleet;

public class MaintenanceRecord
{
    public int Id { get; set; }
    public int VehicleId { get; set; }

    // Core details
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // Classification
    public MaintenanceType Type { get; set; }
    public MaintenanceStatus Status { get; set; }

    // Timeline
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    // Cost & responsibility
    public decimal Cost { get; set; }
    public string PerformedBy { get; set; } = string.Empty;

    // Audit
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
