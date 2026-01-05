using VRMS.Enums;

namespace VRMS.Models.Rentals;

public class Rental
{
    public int Id { get; set; }
    public int ReservationId { get; set; }

    public DateTime PickupDate { get; set; }
    public DateTime ExpectedReturnDate { get; set; }
    public DateTime? ActualReturnDate { get; set; }

    public int StartOdometer { get; set; }
    public int? EndOdometer { get; set; }

    public RentalStatus Status { get; set; } = RentalStatus.Active;
}