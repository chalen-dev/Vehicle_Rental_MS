namespace VRMS.DTOs.Rental
{
    public class RentalVehicleInfoDto
    {
        public int RentalNumber { get; set; }
        public string VehicleModel { get; set; } = string.Empty;
        public string PlateNumber { get; set; } = string.Empty;
    }
}
