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
    // ----------------------------
    // DRIVERS LICENSES
    // ----------------------------

    public int CreateDriversLicense(
        string licenseNumber,
        DateTime issueDate,
        DateTime expiryDate,
        string issuingCountry
    )
    {
        if (expiryDate <= issueDate)
            throw new InvalidOperationException("Expiry date must be after issue date.");

        var table = DB.ExecuteQuery($"""
            CALL sp_drivers_licenses_create(
                '{Sql.Esc(licenseNumber)}',
                '{issueDate:yyyy-MM-dd}',
                '{expiryDate:yyyy-MM-dd}',
                '{Sql.Esc(issuingCountry)}'
            );
        """);

        return Convert.ToInt32(table.Rows[0]["drivers_license_id"]);
    }

    public DriversLicense GetDriversLicenseById(int licenseId)
    {
        var table = DB.ExecuteQuery(
            $"CALL sp_drivers_licenses_get_by_id({licenseId});"
        );

        if (table.Rows.Count == 0)
            throw new InvalidOperationException("Drivers license not found.");

        return MapDriversLicense(table.Rows[0]);
    }

    public DriversLicense? GetDriversLicenseByNumber(string licenseNumber)
    {
        var table = DB.ExecuteQuery(
            $"CALL sp_drivers_licenses_get_by_number('{Sql.Esc(licenseNumber)}');"
        );

        if (table.Rows.Count == 0)
            return null;

        return MapDriversLicense(table.Rows[0]);
    }

    public void UpdateDriversLicense(int licenseId, DateTime issueDate, DateTime expiryDate, string issuingCountry)
    {
        if (expiryDate <= issueDate)
            throw new InvalidOperationException("Expiry date must be after issue date.");

        DB.ExecuteNonQuery($"""
            CALL sp_drivers_licenses_update(
                {licenseId},
                '{issueDate:yyyy-MM-dd}',
                '{expiryDate:yyyy-MM-dd}',
                '{Sql.Esc(issuingCountry)}'
            );
        """);
    }

    public void DeleteDriversLicense(int licenseId)
    {
        // Note: database has RESTRICT on customers referencing licenses.
        DB.ExecuteNonQuery($"CALL sp_drivers_licenses_delete({licenseId});");
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
        int driversLicenseId
    )
    {
        // Ensure license exists
        var license = GetDriversLicenseById(driversLicenseId);

        // Domain: you may allow creation even if license expired, but typically disallowed.
        if (license.ExpiryDate < DateTime.UtcNow.Date)
            throw new InvalidOperationException("Drivers license is expired.");

        var table = DB.ExecuteQuery($"""
            CALL sp_customers_create(
                '{Sql.Esc(firstName)}',
                '{Sql.Esc(lastName)}',
                '{Sql.Esc(email)}',
                '{Sql.Esc(phone)}',
                '{dateOfBirth:yyyy-MM-dd}',
                '{customerType}',
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
        CustomerType customerType
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
                '{customerType}'
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
        // Policy note: DB may prevent deletion if FK constraints exist (e.g., rentals). Service callers should confirm policy.
        DB.ExecuteNonQuery($"CALL sp_customers_delete({customerId});");
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

        var license = GetDriversLicenseById(customer.DriversLicenseId);

        if (license.ExpiryDate < asOfDate.Date)
            throw new InvalidOperationException("Customer's driver's license is expired.");
    }

    // ----------------------------
    // MAPPING HELPERS
    // ----------------------------

    private static DriversLicense MapDriversLicense(DataRow row)
    {
        return new DriversLicense
        {
            Id = Convert.ToInt32(row["id"]),
            LicenseNumber = row["license_number"].ToString()!,
            IssueDate = Convert.ToDateTime(row["issue_date"]),
            ExpiryDate = Convert.ToDateTime(row["expiry_date"]),
            IssuingCountry = row["issuing_country"].ToString()!
        };
    }

    private static Customer MapCustomer(DataRow row)
    {
        return new Customer
        {
            Id = Convert.ToInt32(row["id"]),
            FirstName = row["first_name"].ToString()!,
            LastName = row["last_name"].ToString()!,
            Email = row["email"].ToString()!,
            Phone = row["phone"].ToString()!,
            DateOfBirth = Convert.ToDateTime(row["date_of_birth"]),
            CustomerType = Enum.Parse<CustomerType>(row["customer_type"].ToString()!, true),
            DriversLicenseId = Convert.ToInt32(row["drivers_license_id"])
        };
    }
}
