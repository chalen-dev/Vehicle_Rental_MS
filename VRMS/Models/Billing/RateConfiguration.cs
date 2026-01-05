namespace VRMS.Models.Billing;

public class RateConfiguration
{
    public int Id { get; set; }
    public int VehicleCategoryId { get; set; }

    public decimal DailyRate { get; set; }
    public decimal WeeklyRate { get; set; }
    public decimal MonthlyRate { get; set; }
    public decimal HourlyRate { get; set; }
}