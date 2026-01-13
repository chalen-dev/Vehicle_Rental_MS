using VRMS.Enums;

namespace VRMS.DTOs.Rental;

public class RentalHistoryRowDto
{
    public int RentalId { get; set; }
    public DateTime PickupDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public int DurationDays { get; set; }
    public RentalStatus Status { get; set; }
    public decimal? TotalAmount { get; set; }
}