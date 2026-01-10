using System;
using System.Collections.Generic;
using System.Data;
using VRMS.Database;
using VRMS.Enums;
using VRMS.Models.Customers;

namespace VRMS.Repositories.Customers
{
    public class CustomerRepository
    {
        private const string DefaultCustomerPhotoPath = "Assets/profile_img.png";

        // =====================================================
        // CREATE
        // =====================================================
        public int Create(
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            DateTime dateOfBirth,
            CustomerCategory category,
            bool isFrequent,
            bool isBlacklisted,
            string photoPath,
            int driversLicenseId
        )
        {
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
                ("@photo", photoPath),
                ("@licenseId", driversLicenseId)
            );

            return Convert.ToInt32(table.Rows[0]["customer_id"]);
        }

        // =====================================================
        // UPDATE
        // =====================================================
        public void Update(
            int customerId,
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            DateTime dateOfBirth,
            CustomerCategory category,
            bool isFrequent,
            bool isBlacklisted,
            string photoPath
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
                ("@photo", photoPath)
            );
        }
        
        // =====================================================
        // UPDATE (NO PHOTO)
        // =====================================================
        public void UpdateWithoutPhoto(
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
                "CALL sp_customers_update_no_photo(@id,@first,@last,@email,@phone,@address,@dob,@category,@isFrequent,@isBlacklisted);",
                ("@id", customerId),
                ("@first", firstName),
                ("@last", lastName),
                ("@email", email),
                ("@phone", phone),
                ("@address", address),
                ("@dob", dateOfBirth),
                ("@category", category.ToString()),
                ("@isFrequent", isFrequent),
                ("@isBlacklisted", isBlacklisted)
            );
        }


        // =====================================================
        // READ
        // =====================================================
        public Models.Customers.Customer GetById(int customerId)
        {
            var table = DB.Query(
                "CALL sp_customers_get_by_id(@id);",
                ("@id", customerId)
            );

            if (table.Rows.Count == 0)
                throw new InvalidOperationException("Customer not found.");

            return MapCustomer(table.Rows[0]);
        }

        public List<Models.Customers.Customer> GetAll()
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
        public void Delete(int customerId)
        {
            DB.Execute(
                "CALL sp_customers_delete(@id);",
                ("@id", customerId)
            );
        }

        // =====================================================
        // PHOTO (DB PART)
        // =====================================================
        public void SetPhoto(int customerId, string photoPath)
        {
            DB.Execute(
                "CALL sp_customers_set_photo(@id,@path);",
                ("@id", customerId),
                ("@path", photoPath)
            );
        }

        public void ResetPhoto(int customerId)
        {
            DB.Execute(
                "CALL sp_customers_reset_photo(@id);",
                ("@id", customerId)
            );
        }

        // =====================================================
        // MAPPING (keeps same mapping as original service)
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
    }
}
