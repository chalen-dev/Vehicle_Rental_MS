using System;
using System.IO;
using System.Linq;
using VRMS.Enums;
using VRMS.Services.Customer;

namespace VRMS.Database.Seeders.Customer;

public class CustomerSeeder : ISeeder
{
    public string Name => nameof(CustomerSeeder);

    private readonly CustomerService _customerService;
    private readonly DriversLicenseService _licenseService;

    public CustomerSeeder(
        CustomerService customerService,
        DriversLicenseService licenseService)
    {
        _customerService = customerService;
        _licenseService  = licenseService;
    }

    public void Run()
    {
        // -------------------------------------------------
        // DRIVER LICENSES
        // -------------------------------------------------

        var licenseLee = EnsureLicense(
            "DL-PH-0001",
            new DateTime(2018, 5, 1),
            new DateTime(2028, 12, 31)
        );

        var licenseDustin = EnsureLicense(
            "DL-PH-0002",
            new DateTime(2019, 6, 15),
            new DateTime(2027, 6, 30)
        );

        var licenseChael = EnsureLicense(
            "DL-PH-0100",
            new DateTime(2020, 1, 1),
            new DateTime(2030, 1, 1)
        );

        var licenseCorp = EnsureLicense(
            "DL-PH-0003",
            new DateTime(2026, 11, 15),
            new DateTime(2027, 6, 30)
        );

        // -------------------------------------------------
        // CUSTOMERS
        // -------------------------------------------------

        SeedCustomer(
            "Lee",
            "Singson",
            "leesingson@email.com",
            "09171234567",
            "Quezon City, Metro Manila",
            new DateTime(1992, 4, 12),
            CustomerCategory.Individual,
            true,
            false,
            licenseLee
        );

        SeedCustomer(
            "Dustin",
            "Angway",
            "dustin.angway@email.com",
            "09179876543",
            "Cebu City, Cebu",
            new DateTime(1995, 9, 3),
            CustomerCategory.Individual,
            true,
            false,
            licenseDustin
        );

        SeedCustomer(
            "Chael",
            "Lusaya",
            "chael@gmail.com",
            "02812345671",
            "Makati City, Metro Manila",
            new DateTime(2005, 1, 1),
            CustomerCategory.Corporate,
            true,
            false,
            licenseChael
        );

        SeedCustomer(
            "ACME",
            "Logistics Inc.",
            "fleet@acmelogistics.com",
            "0281234567",
            "Makati City, Metro Manila",
            new DateTime(2005, 1, 1),
            CustomerCategory.Corporate,
            true,
            false,
            licenseCorp
        );

        // -------------------------------------------------
        // MORE SEEDED CUSTOMERS
        // -------------------------------------------------

        SeedCustomer(
            "Maria",
            "Santos",
            "maria.santos@email.com",
            "09175550111",
            "Pasig City, Metro Manila",
            new DateTime(1993, 2, 14),
            CustomerCategory.Individual,
            false,
            false,
            EnsureLicense(
                "DL-PH-0101",
                new DateTime(2017, 3, 10),
                new DateTime(2027, 3, 10)
            )
        );

        SeedCustomer(
            "Joshua",
            "Reyes",
            "joshua.reyes@email.com",
            "09178881234",
            "Taguig City, Metro Manila",
            new DateTime(1990, 11, 5),
            CustomerCategory.Individual,
            true,
            false,
            EnsureLicense(
                "DL-PH-0102",
                new DateTime(2016, 8, 20),
                new DateTime(2026, 8, 20)
            )
        );

        SeedCustomer(
            "TechNova",
            "Solutions Inc.",
            "admin@technova.com",
            "0289001122",
            "BGC, Taguig City",
            new DateTime(2012, 6, 1),
            CustomerCategory.Corporate,
            true,
            false,
            EnsureLicense(
                "DL-PH-0103",
                new DateTime(2021, 1, 1),
                new DateTime(2028, 1, 1)
            )
        );

        SeedCustomer(
            "GreenLine",
            "Transport Corp.",
            "fleet@greenline.com",
            "0289556677",
            "Quezon City, Metro Manila",
            new DateTime(2010, 9, 15),
            CustomerCategory.Corporate,
            false,
            false,
            EnsureLicense(
                "DL-PH-0104",
                new DateTime(2020, 5, 5),
                new DateTime(2030, 5, 5)
            )
        );
    }

    // -------------------------------------------------
    // HELPERS
    // -------------------------------------------------

    private int EnsureLicense(
        string licenseNumber,
        DateTime issueDate,
        DateTime expiryDate,
        string issuingCountry = "PH"
    )
    {
        var existing =
            _licenseService.GetDriversLicenseByNumber(licenseNumber);

        var licenseId =
            existing?.Id
            ?? _licenseService.CreateDriversLicense(
                licenseNumber,
                issueDate,
                expiryDate,
                issuingCountry
            );

        AddLicensePlaceholders(licenseId);

        return licenseId;
    }

    private void SeedCustomer(
        string firstName,
        string lastName,
        string email,
        string phone,
        string address,
        DateTime dob,
        CustomerCategory category,
        bool frequent,
        bool blacklisted,
        int licenseId
    )
    {
        var existing = _customerService
            .GetAllCustomers()
            .FirstOrDefault(c =>
                c.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

        var customerId = existing?.Id
                         ?? _customerService.CreateCustomer(
                                firstName,
                                lastName,
                                email,
                                phone,
                                address,
                                dob,
                                category,
                                frequent,
                                blacklisted,
                                licenseId
                            );

        AddCustomerProfile(customerId);
    }

    private static string GetSeedAssetPath(string fileName)
    {
        return Path.Combine(
            AppContext.BaseDirectory,
            "Assets",
            "Seed",
            fileName
        );
    }

    private void AddCustomerProfile(int customerId)
    {
        var profilePath = GetSeedAssetPath("profile_img.png");

        if (!File.Exists(profilePath))
        {
            Console.WriteLine("      [WARN] profile_img.png missing.");
            return;
        }

        using var stream = File.OpenRead(profilePath);

        _customerService.SetCustomerPhoto(
            customerId,
            stream,
            "profile_img.png"
        );
    }

    private void AddLicensePlaceholders(int licenseId)
    {
        var placeholderPath = GetSeedAssetPath("img_placeholder.png");

        if (!File.Exists(placeholderPath))
        {
            Console.WriteLine("      [WARN] img_placeholder.png missing.");
            return;
        }

        using var front = File.OpenRead(placeholderPath);
        using var back  = File.OpenRead(placeholderPath);

        _licenseService.SetFrontPhoto(
            licenseId,
            front,
            "img_placeholder.png"
        );

        _licenseService.SetBackPhoto(
            licenseId,
            back,
            "img_placeholder.png"
        );
    }
}
