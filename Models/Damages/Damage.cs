using VRMS.Enums;

namespace VRMS.Models.Damages;

public class Damage
{
    public int Id { get; set; }
    
    public int RentalId { get; set; }
    
    public DamageType DamageType { get; set; }
    public string Description { get; set; } = null!;
    public decimal EstimatedCost { get; set; }
}