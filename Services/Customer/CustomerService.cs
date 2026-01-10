using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using VRMS.Database;
using VRMS.Enums;
using VRMS.Repositories.Customers;

namespace VRMS.Services.Customer
{
    public class CustomerService
    {
        private static readonly string StorageRoot =
    Path.Combine(AppContext.BaseDirectory, "Storage");
        private const string DefaultCustomerPhotoPath = "Assets/profile_img.png";
        private const string CustomerPhotoFolder = "Customers";
        private const string CustomerPhotoFileName = "profile";

        private readonly DriversLicenseService _driversLicenseService;
        private readonly CustomerRepository _repo;

        public CustomerService(DriversLicenseService driversLicenseService)
        {
            _driversLicenseService = driversLicenseService;
            _repo = new CustomerRepository();
        }

        // =====================================================
        // CREATE  (MASTER)
        // =====================================================
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
            var license = _driversLicenseService.GetDriversLicenseById(driversLicenseId);

            if (license.ExpiryDate < DateTime.UtcNow.Date)
                throw new InvalidOperationException("Driver's license is expired.");

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
            // FETCH EXISTING CUSTOMER FIRST
            var existingCustomer = _repo.GetById(customerId);

            _repo.Update(
                customerId,
                firstName,
                lastName,
                email,
                phone,
                address,
                dateOfBirth,
                category,
                isFrequent,
                isBlacklisted,
                existingCustomer.PhotoPath // ✅ PRESERVE PHOTO
            );
        }

        // =====================================================
        // READ
        // =====================================================
        public Models.Customers.Customer GetCustomerById(int customerId)
        {
            return _repo.GetById(customerId);
        }

        public List<Models.Customers.Customer> GetAllCustomers()
        {
            return _repo.GetAll();
        }

        // =====================================================
        // DELETE
        // =====================================================
        public void DeleteCustomer(int customerId)
        {
            var directory = GetCustomerPhotoDirectory(customerId);

            if (Directory.Exists(directory))
                Directory.Delete(directory, true);

            _repo.Delete(customerId);
        }

        // =====================================================
        // CUSTOMER PHOTO (file system + DB)
        // =====================================================
        public void SetCustomerPhoto(
            int customerId,
            Stream photoStream,
            string originalFileName
        )
        {
            if (photoStream.CanSeek)
                photoStream.Position = 0; // 🔥 REQUIRED

            var extension = Path.GetExtension(originalFileName);
            if (string.IsNullOrWhiteSpace(extension))
                throw new InvalidOperationException("Invalid photo file.");

            var directory = GetCustomerPhotoDirectory(customerId);
            Directory.CreateDirectory(directory);

            foreach (var file in Directory.GetFiles(directory))
                File.Delete(file);

            var relativePath = Path.Combine(
                CustomerPhotoFolder,
                customerId.ToString(),
                $"{CustomerPhotoFileName}{extension}"
            );

            var fullPath = Path.Combine(StorageRoot, relativePath);

            using var fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
            photoStream.CopyTo(fs);

            _repo.SetPhoto(customerId, relativePath);
        }


        public void DeleteCustomerPhoto(int customerId)
        {
            var directory = GetCustomerPhotoDirectory(customerId);

            if (Directory.Exists(directory))
                Directory.Delete(directory, true);

            _repo.ResetPhoto(customerId);
        }

        // =====================================================
        // ELIGIBILITY
        // =====================================================
        public void EnsureCustomerCanRent(int customerId, DateTime asOfDate)
        {
            var customer = GetCustomerById(customerId);

            if (customer.IsBlacklisted)
                throw new InvalidOperationException("Customer is blacklisted.");

            var license = _driversLicenseService.GetDriversLicenseById(
                customer.DriversLicenseId);

            if (license.ExpiryDate < asOfDate.Date)
                throw new InvalidOperationException("Driver's license expired.");
        }

        // =====================================================
        // MAPPING HELPERS
        // =====================================================
        private static string GetCustomerPhotoDirectory(int customerId)
        {
            return Path.Combine(
                StorageRoot,
                CustomerPhotoFolder,
                customerId.ToString()
            );
        }
    }
}
