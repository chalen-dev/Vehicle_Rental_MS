using VRMS.Models.Customers;
using VRMS.Services.Customer;

namespace VRMS.UI.ApplicationService
{
    /// <summary>
    /// Coordinates customer-related UI workflows.
    /// This class orchestrates multiple domain services but
    /// contains NO business rules and NO UI logic.
    /// </summary>
    public class CustomerApplicationService
    {
        private readonly CustomerService _customerService;
        private readonly DriversLicenseService _driversLicenseService;

        public CustomerApplicationService(
            CustomerService customerService,
            DriversLicenseService driversLicenseService)
        {
            _customerService = customerService;
            _driversLicenseService = driversLicenseService;
        }

        // =====================================================
        // CREATE WORKFLOW
        // =====================================================

        public int CreateCustomer(
            Customer customer,
            DriversLicense license,
            MemoryStream? profilePhoto)
        {
            int licenseId = _driversLicenseService.SaveDriversLicense(
                null,
                license.LicenseNumber,
                license.IssueDate,
                license.ExpiryDate,
                license.IssuingCountry,
                null, null, null, null
            );

            int customerId = _customerService.CreateCustomer(
                customer.FirstName,
                customer.LastName,
                customer.Email,
                customer.Phone,
                customer.Address,
                customer.DateOfBirth,
                customer.Category,
                customer.IsFrequent,
                customer.IsBlacklisted,
                licenseId
            );

            if (profilePhoto != null)
            {
                _customerService.SetCustomerPhoto(
                    customerId,
                    profilePhoto,
                    "profile.jpg");
            }

            return customerId;
        }

        // =====================================================
        // UPDATE WORKFLOW
        // =====================================================

        public void UpdateCustomer(
            Customer customer,
            DriversLicense license,
            MemoryStream? licenseFront,
            MemoryStream? licenseBack,
            MemoryStream? profilePhoto)
        {
            _driversLicenseService.SaveDriversLicense(
                customer.DriversLicenseId,
                license.LicenseNumber,
                license.IssueDate,
                license.ExpiryDate,
                license.IssuingCountry,
                licenseFront, "front.jpg",
                licenseBack, "back.jpg"
            );

            _customerService.UpdateCustomer(
                customer.Id,
                customer.FirstName,
                customer.LastName,
                customer.Email,
                customer.Phone,
                customer.Address,
                customer.DateOfBirth,
                customer.Category,
                customer.IsFrequent,
                customer.IsBlacklisted
            );

            if (profilePhoto != null)
            {
                _customerService.SetCustomerPhoto(
                    customer.Id,
                    profilePhoto,
                    "profile.jpg");
            }
        }
    }
}
