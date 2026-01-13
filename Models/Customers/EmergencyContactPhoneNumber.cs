namespace VRMS.Models.Customers;

public class EmergencyContactPhoneNumber
{
    public int Id { get; set; }

    public int EmergencyContactId { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;

    public bool IsPrimary { get; set; }
}