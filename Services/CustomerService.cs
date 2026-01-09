using System.IO;
using System;
using System.Collections.Generic;
using System.Data;
using VRMS.Database;
using VRMS.Enums;
using VRMS.Helpers.SqlEscape;
using VRMS.Models.Customers;

namespace VRMS.Services;

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


    // ----------------------------
    // CUSTOMERS
    // ----------------------------

    public int CreateCustomer(
        string firstName,
        string lastName,
        string email,
        string phone,
        DateTime dateOfBirth,
        CustomerType customerType,
        int driversLicenseId,
        string? photoPath = null
    )
    {
        var license = _driversLicenseService.GetDriversLicenseById(driversLicenseId);

        if (license.ExpiryDate < DateTime.UtcNow.Date)
            throw new InvalidOperationException("Drivers license is expired.");

        var resolvedPhotoPath = photoPath ?? DefaultCustomerPhotoPath;

        var table = DB.ExecuteQuery($"""
                                         CALL sp_customers_create(
                                             '{Sql.Esc(firstName)}',
                                             '{Sql.Esc(lastName)}',
                                             '{Sql.Esc(email)}',
                                             '{Sql.Esc(phone)}',
                                             '{dateOfBirth:yyyy-MM-dd}',
                                             '{customerType}',
                                             '{Sql.Esc(resolvedPhotoPath)}',
                                             {driversLicenseId}
                                         );
                                     """);

        return Convert.ToInt32(table.Rows[0]["customer_id"]);
    }


    public void UpdateCustomer(
        int customerId,
        string firstName,
        string lastName,
        string email,
        string phone,
        CustomerType customerType,
        string? photoPath
    )
    {
        // If changing to Blacklisted, that's allowed here. Consumers should use ChangeCustomerType explicitly if desired.
        DB.ExecuteNonQuery($"""
                                CALL sp_customers_update(
                                    {customerId},
                                    '{Sql.Esc(firstName)}',
                                    '{Sql.Esc(lastName)}',
                                    '{Sql.Esc(email)}',
                                    '{Sql.Esc(phone)}',
                                    '{customerType}',
                                    {(photoPath is null ? "NULL" : $"'{Sql.Esc(photoPath)}'")}
                                );
                            """);
    }

    public Customer GetCustomerById(int customerId)
    {
        var table = DB.ExecuteQuery(
            $"CALL sp_customers_get_by_id({customerId});"
        );

        if (table.Rows.Count == 0)
            throw new InvalidOperationException("Customer not found.");

        return MapCustomer(table.Rows[0]);
    }

    public List<Customer> GetAllCustomers()
    {
        var table = DB.ExecuteQuery("CALL sp_customers_get_all();");

        var list = new List<Customer>();
        foreach (DataRow row in table.Rows)
            list.Add(MapCustomer(row));

        return list;
    }

    public void DeleteCustomer(int customerId)
    {
        var directory = GetCustomerPhotoDirectory(customerId);

        if (Directory.Exists(directory))
            Directory.Delete(directory, true);

        DB.ExecuteNonQuery($"CALL sp_customers_delete({customerId});");
    }
    
    public void SetCustomerPhoto(
        int customerId,
        Stream photoStream,
        string originalFileName
    )
    {
        // Ensure customer exists
        var customer = GetCustomerById(customerId);

        var extension = Path.GetExtension(originalFileName);
        if (string.IsNullOrWhiteSpace(extension))
            throw new InvalidOperationException("Invalid photo file.");

        var directory = GetCustomerPhotoDirectory(customerId);
        Directory.CreateDirectory(directory);

        // Delete existing photos (enforce 1 image only)
        foreach (var file in Directory.GetFiles(directory))
            File.Delete(file);

        var relativePath = Path.Combine(
            CustomerPhotoFolder,
            customerId.ToString(),
            $"{CustomerPhotoFileName}{extension}"
        );

        var fullPath = Path.Combine(StorageRoot, relativePath);

        using (var fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
        {
            photoStream.CopyTo(fs);
        }

        // Persist photo path in DB
        DB.ExecuteNonQuery($"""
                                CALL sp_customers_update(
                                    {customerId},
                                    '{Sql.Esc(customer.FirstName)}',
                                    '{Sql.Esc(customer.LastName)}',
                                    '{Sql.Esc(customer.Email)}',
                                    '{Sql.Esc(customer.Phone)}',
                                    '{customer.CustomerType}',
                                    '{Sql.Esc(relativePath)}'
                                );
                            """);
    }
    
    public void DeleteCustomerPhoto(int customerId)
    {
        var customer = GetCustomerById(customerId);

        var directory = GetCustomerPhotoDirectory(customerId);

        if (Directory.Exists(directory))
        {
            foreach (var file in Directory.GetFiles(directory))
                File.Delete(file);

            Directory.Delete(directory);
        }

        // Remove path from DB (NULL for now — defaults later)
        DB.ExecuteNonQuery($"""
                                CALL sp_customers_update(
                                    {customerId},
                                    '{Sql.Esc(customer.FirstName)}',
                                    '{Sql.Esc(customer.LastName)}',
                                    '{Sql.Esc(customer.Email)}',
                                    '{Sql.Esc(customer.Phone)}',
                                    '{customer.CustomerType}',
                                    '{Sql.Esc(DefaultCustomerPhotoPath)}'
                                );
                            """);

    }


    // ----------------------------
    // ELIGIBILITY GUARDS
    // ----------------------------

    /// <summary>
    /// Throws if customer is not eligible to rent at the given date.
    /// Checks blacklisting and driver's license expiry.
    /// Age checks (e.g., minimum age) should be enforced in RentalService.
    /// </summary>
    public void EnsureCustomerCanRent(int customerId, DateTime asOfDate)
    {
        var customer = GetCustomerById(customerId);

        if (customer.CustomerType == CustomerType.Blacklisted)
            throw new InvalidOperationException("Customer is blacklisted and cannot rent.");

        var license = _driversLicenseService.GetDriversLicenseById(customer.DriversLicenseId);

        if (license.ExpiryDate < asOfDate.Date)
            throw new InvalidOperationException("Customer's driver's license is expired.");
    }

    // ----------------------------
    // MAPPING HELPERS
    // ----------------------------

    


    private static Customer MapCustomer(DataRow row)
    {
        var photoPath = row["photo_path"] == DBNull.Value
            ? DefaultCustomerPhotoPath
            : row["photo_path"].ToString();

        if (string.IsNullOrWhiteSpace(photoPath))
            photoPath = DefaultCustomerPhotoPath;

        return new Customer
        {
            Id = Convert.ToInt32(row["id"]),
            FirstName = row["first_name"].ToString()!,
            LastName = row["last_name"].ToString()!,
            Email = row["email"].ToString()!,
            Phone = row["phone"].ToString()!,
            DateOfBirth = Convert.ToDateTime(row["date_of_birth"]),
            CustomerType = Enum.Parse<CustomerType>(row["customer_type"].ToString()!, true),
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
