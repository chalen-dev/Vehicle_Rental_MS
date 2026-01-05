using VRMS.Enums;

namespace VRMS.Models.Customers;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }

    public CustomerType CustomerType { get; set; }
    public int DriversLicenseId { get; set; }
}