using VRMS.Enums;

namespace VRMS.Models.Rentals;

public class Reservation
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int VehicleId { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public ReservationStatus Status { get; set; } = ReservationStatus.Pending;
}