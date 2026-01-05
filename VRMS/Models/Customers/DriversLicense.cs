namespace VRMS.Models.Customers;

public class DriversLicense
{
    public int Id { get; set; }
    public string LicenseNumber { get; set; } = string.Empty;
    public DateTime IssueDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string IssuingCountry { get; set; } = string.Empty;
}