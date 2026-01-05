namespace VRMS.Models.Damages;

public class Damage
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal EstimatedCost { get; set; }
}