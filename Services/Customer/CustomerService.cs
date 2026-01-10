using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using VRMS.Database;
using VRMS.Enums;

namespace VRMS.Services.Customer
{
    public class CustomerService
    {
        private const string StorageRoot = "Storage";
        private const string DefaultCustomerPhotoPath = "Assets/profile_img.png";
        private const string CustomerPhotoFolder = "Customers";
        private const string CustomerPhotoFileName = "profile";

        private readonly DriversLicenseService _driversLicenseService;

        public CustomerService(DriversLicenseService driversLicenseService)
        {
            _driversLicenseService = driversLicenseService;
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

            var table = DB.Query(
                "CALL sp_customers_create(@first,@last,@email,@phone, @address,@dob,@category,@isFrequent,@isBlacklisted,@photo,@licenseId);",
                ("@first", firstName),
                ("@last", lastName),
                ("@email", email),
                ("@phone", phone),
                ("@address", address),
                ("@dob", dateOfBirth),
                ("@category", category.ToString()),
                ("@isFrequent", isFrequent),
                ("@isBlacklisted", isBlacklisted),
                ("@photo", DefaultCustomerPhotoPath),
                ("@licenseId", driversLicenseId)
            );

            return Convert.ToInt32(table.Rows[0]["customer_id"]);
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
            DB.Execute(
                "CALL sp_customers_update(@id,@first,@last,@email,@phone,@address,@dob,@category,@isFrequent,@isBlacklisted,@photo);",
                ("@id", customerId),
                ("@first", firstName),
                ("@last", lastName),
                ("@email", email),
                ("@phone", phone),
                ("@address", address),
                ("@dob", dateOfBirth),
                ("@category", category.ToString()),
                ("@isFrequent", isFrequent),
                ("@isBlacklisted", isBlacklisted),
                ("@photo", DefaultCustomerPhotoPath)
            );
        }

        // =====================================================
        // READ
        // =====================================================

        public Models.Customers.Customer GetCustomerById(int customerId)
        {
            var table = DB.Query(
                "CALL sp_customers_get_by_id(@id);",
                ("@id", customerId)
            );

            if (table.Rows.Count == 0)
                throw new InvalidOperationException("Customer not found.");

            return MapCustomer(table.Rows[0]);
        }

        public List<Models.Customers.Customer> GetAllCustomers()
        {
            var table = DB.Query("CALL sp_customers_get_all();");

            var list = new List<Models.Customers.Customer>();
            foreach (DataRow row in table.Rows)
                list.Add(MapCustomer(row));

            return list;
        }

        // =====================================================
        // DELETE
        // =====================================================

        public void DeleteCustomer(int customerId)
        {
            var directory = GetCustomerPhotoDirectory(customerId);

            if (Directory.Exists(directory))
                Directory.Delete(directory, true);

            DB.Execute(
                "CALL sp_customers_delete(@id);",
                ("@id", customerId)
            );
        }

        // =====================================================
        // CUSTOMER PHOTO
        // =====================================================

        public void SetCustomerPhoto(
            int customerId,
            Stream photoStream,
            string originalFileName
        )
        {
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

            DB.Execute(
                "CALL sp_customers_set_photo(@id,@path);",
                ("@id", customerId),
                ("@path", relativePath)
            );
        }

        public void DeleteCustomerPhoto(int customerId)
        {
            var directory = GetCustomerPhotoDirectory(customerId);

            if (Directory.Exists(directory))
                Directory.Delete(directory, true);

            DB.Execute(
                "CALL sp_customers_reset_photo(@id);",
                ("@id", customerId)
            );
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
        // MAPPING
        // =====================================================

        private static Models.Customers.Customer MapCustomer(DataRow row)
        {
            var photoPath = row["photo_path"] == DBNull.Value
                ? DefaultCustomerPhotoPath
                : row["photo_path"].ToString();

            if (string.IsNullOrWhiteSpace(photoPath))
                photoPath = DefaultCustomerPhotoPath;

            return new Models.Customers.Customer
            {
                Id = Convert.ToInt32(row["id"]),
                FirstName = row["first_name"].ToString()!,
                LastName = row["last_name"].ToString()!,
                Email = row["email"].ToString()!,
                Phone = row["phone"].ToString()!,
                Address = row["address"].ToString()!,
                DateOfBirth = Convert.ToDateTime(row["date_of_birth"]),

                Category = Enum.Parse<CustomerCategory>(
                    row["customer_category"].ToString()!, true),

                IsFrequent = Convert.ToBoolean(row["is_frequent"]),
                IsBlacklisted = Convert.ToBoolean(row["is_blacklisted"]),

                PhotoPath = photoPath,
                DriversLicenseId = Convert.ToInt32(row["drivers_license_id"])
            };
        }

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
