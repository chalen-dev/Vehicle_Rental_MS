using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using VRMS.Database;
using VRMS.Enums;
using VRMS.Helpers;
using VRMS.Repositories.Customers;
using VRMS.Services.Account;

namespace VRMS.Services.Customer
{
    /// <summary>
    /// Provides business logic for customer management, including:
    /// - Customer creation, update, and deletion
    /// - Driver's license validation
    /// - Eligibility enforcement for rentals
    /// - Customer photo storage and lifecycle management
    ///
    /// This service coordinates database persistence and file system
    /// storage while enforcing business rules.
    /// </summary>
    public class CustomerService
    {

        /// <summary>
        /// Default customer profile image path.
        /// </summary>
        private const string DefaultCustomerPhotoPath = "Assets/profile_img.png";

        /// <summary>
        /// Folder name used for storing customer photos.
        /// </summary>
        private const string CustomerPhotoFolder = "Customers";

        /// <summary>
        /// Base filename used for customer profile photos.
        /// </summary>
        private const string CustomerPhotoFileName = "profile";

        /// <summary>
        /// Driver's license service used for license validation.
        /// </summary>
        private readonly DriversLicenseService _driversLicenseService;

        /// <summary>
        /// Customer repository for database persistence.
        /// </summary>
        private readonly CustomerRepository _repo;
        
        private readonly CustomerAccountService _customerAccountService;

        /// <summary>
        /// Initializes the customer service.
        /// </summary>
        /// <param name="driversLicenseService">
        /// Service responsible for driver's license validation
        /// </param>
        public CustomerService(
            DriversLicenseService driversLicenseService,
            CustomerAccountService customerAccountService)
        {
            _driversLicenseService = driversLicenseService;
            _customerAccountService = customerAccountService;
            _repo = new CustomerRepository();
        }

        // =====================================================
        // CREATE  (MASTER)
        // =====================================================

        /// <summary>
        /// Creates a new customer record.
        ///
        /// Driver's license validity is verified before creation.
        /// Newly created customers receive a default profile photo.
        /// </summary>
        /// <param name="firstName">Customer first name</param>
        /// <param name="lastName">Customer last name</param>
        /// <param name="email">Email address</param>
        /// <param name="phone">Phone number</param>
        /// <param name="address">Residential address</param>
        /// <param name="dateOfBirth">Date of birth</param>
        /// <param name="category">Customer category</param>
        /// <param name="isFrequent">Frequent renter flag</param>
        /// <param name="isBlacklisted">Blacklist flag</param>
        /// <param name="driversLicenseId">Driver's license ID</param>
        /// <returns>Newly created customer ID</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the driver's license is expired
        /// </exception>
        public int CreateCustomer(
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            DateTime dateOfBirth,
            CustomerCategory category,
            bool isFrequent,
            bool isBlacklisted,
            int driversLicenseId
        )
        {
            var license =
                _driversLicenseService.GetDriversLicenseById(driversLicenseId);

            if (license.ExpiryDate < DateTime.UtcNow.Date)
                throw new InvalidOperationException(
                    "Driver's license is expired.");

            return _repo.Create(
                firstName,
                lastName,
                email,
                phone,
                address,
                dateOfBirth,
                category,
                isFrequent,
                isBlacklisted,
                DefaultCustomerPhotoPath,
                driversLicenseId
            );
        }

        // =====================================================
        // UPDATE  (MASTER)
        // =====================================================

        /// <summary>
        /// Updates an existing customer's information without modifying
        /// the stored profile photo.
        /// </summary>
        public void UpdateCustomer(
            int customerId,
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            DateTime dateOfBirth,
            CustomerCategory category,
            bool isFrequent,
            bool isBlacklisted
        )
        {
            _repo.UpdateWithoutPhoto(
                customerId,
                firstName,
                lastName,
                email,
                phone,
                address,
                dateOfBirth,
                category,
                isFrequent,
                isBlacklisted
            );
        }

        // =====================================================
        // READ
        // =====================================================

        /// <summary>
        /// Retrieves a customer by ID.
        /// </summary>
        public Models.Customers.Customer GetCustomerById(int customerId)
        {
            return _repo.GetById(customerId);
        }

        /// <summary>
        /// Retrieves all customers.
        /// </summary>
        public List<Models.Customers.Customer> GetAllCustomers()
        {
            return _repo.GetAll();
        }

        // =====================================================
        // DELETE
        // =====================================================

        /// <summary>
        /// Deletes a customer and removes all associated
        /// profile photo files from the file system.
        /// </summary>
        public void DeleteCustomer(int customerId)
        {
            if (HasLoginAccount(customerId))
                throw new InvalidOperationException(
                    "Customer has a user account. Delete the user account first.");

            FileStorageHelper.DeleteDirectory(
                Path.Combine(
                    CustomerPhotoFolder,
                    customerId.ToString()
                )
            );

            _repo.Delete(customerId);
        }


        // =====================================================
        // CUSTOMER PHOTO (FILE SYSTEM + DB)
        // =====================================================

        /// <summary>
        /// Sets or replaces a customer's profile photo.
        ///
        /// Existing photos are deleted before saving the new one.
        /// Both file system storage and database path are updated.
        /// </summary>
        /// <param name="customerId">Customer ID</param>
        /// <param name="photoStream">Image stream</param>
        /// <param name="originalFileName">Original filename (for extension)</param>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the file extension is invalid
        /// </exception>
        public void SetCustomerPhoto(
            int customerId,
            Stream photoStream,
            string originalFileName
        )
        {
            var relativePath =
                FileStorageHelper.SaveSingleFile(
                    photoStream,
                    originalFileName,
                    Path.Combine(
                        CustomerPhotoFolder,
                        customerId.ToString()
                    ),
                    CustomerPhotoFileName,
                    clearDirectoryFirst: true
                );

            _repo.SetPhoto(customerId, relativePath);
        }


        /// <summary>
        /// Deletes a customer's profile photo and resets it
        /// to the default image.
        /// </summary>
        public void DeleteCustomerPhoto(int customerId)
        {
            FileStorageHelper.DeleteDirectory(
                Path.Combine(
                    CustomerPhotoFolder,
                    customerId.ToString()
                )
            );

            _repo.ResetPhoto(customerId);
        }


        // =====================================================
        // ELIGIBILITY
        // =====================================================

        /// <summary>
        /// Ensures a customer is eligible to rent a vehicle.
        ///
        /// Validates blacklist status and driver's license expiry.
        /// </summary>
        /// <param name="customerId">Customer ID</param>
        /// <param name="asOfDate">Date of eligibility check</param>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the customer is blacklisted or license is expired
        /// </exception>
        public void EnsureCustomerCanRent(int customerId, DateTime asOfDate)
        {
            var customer = GetCustomerById(customerId);

            if (customer.IsBlacklisted)
                throw new InvalidOperationException(
                    "Customer is blacklisted.");

            var license =
                _driversLicenseService.GetDriversLicenseById(
                    customer.DriversLicenseId);

            if (license.ExpiryDate < asOfDate.Date)
                throw new InvalidOperationException(
                    "Driver's license expired.");
        }
        
        // =====================================================
        // LOGIN ACCOUNT (READ-ONLY)
        // =====================================================

        public bool HasLoginAccount(int customerId)
        {
            return _customerAccountService
                       .GetAccountStatus(customerId)
                   != AccountStatus.NotCreated;
        }

        public AccountStatus GetAccountStatus(int customerId)
        {
            return _customerAccountService
                .GetAccountStatus(customerId);
        }
        
    }
}
