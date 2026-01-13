using VRMS.Models.Customers;

namespace VRMS.UI.Config.State;

public class CustomerFormState
{
    public Customer? SelectedCustomer { get; set; }
    public DriversLicense? License { get; set; }

    public Image? ProfileImage { get; set; }
    public MemoryStream? LicenseFrontStream { get; set; }
    public MemoryStream? LicenseBackStream { get; set; }

    public void Reset()
    {
        SelectedCustomer = null;
        License = null;
        ProfileImage = null;
        LicenseFrontStream = null;
        LicenseBackStream = null;
    }
}