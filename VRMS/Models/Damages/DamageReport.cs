namespace VRMS.Models.Damages;

public class DamageReport
{
    public int Id { get; set; }
    public int VehicleInspectionId { get; set; }
    public int DamageId { get; set; }

    public string PhotoPath { get; set; } = string.Empty;
    public bool Approved { get; set; }
}