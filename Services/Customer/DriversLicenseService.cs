using System.Data;
using VRMS.Database;
using VRMS.Models.Customers;

namespace VRMS.Services.Customer;

public class DriversLicenseService
{
    private const string StorageRoot = "Storage";

    private const string DefaultDriversLicensePhotoPath = "Assets/img_placeholder.png";
    private const string DriversLicensePhotoFolder = "DriversLicenses";
    private const string DriversLicensePhotoFileName = "license";

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
            throw new InvalidOperationException(
                "Expiry date must be after issue date.");

        var table = DB.Query(
            "CALL sp_drivers_licenses_create(@number, @issue, @expiry, @country, @photo);",
            ("@number", licenseNumber),
            ("@issue", issueDate),
            ("@expiry", expiryDate),
            ("@country", issuingCountry),
            ("@photo", DefaultDriversLicensePhotoPath)
        );

        return Convert.ToInt32(table.Rows[0]["drivers_license_id"]);
    }

    public DriversLicense GetDriversLicenseById(int licenseId)
    {
        var table = DB.Query(
            "CALL sp_drivers_licenses_get_by_id(@id);",
            ("@id", licenseId)
        );

        if (table.Rows.Count == 0)
            throw new InvalidOperationException("Drivers license not found.");

        return MapDriversLicense(table.Rows[0]);
    }

    public DriversLicense? GetDriversLicenseByNumber(string licenseNumber)
    {
        var table = DB.Query(
            "CALL sp_drivers_licenses_get_by_number(@number);",
            ("@number", licenseNumber)
        );

        if (table.Rows.Count == 0)
            return null;

        return MapDriversLicense(table.Rows[0]);
    }

    public void UpdateDriversLicense(
        int licenseId,
        DateTime issueDate,
        DateTime expiryDate,
        string issuingCountry
    )
    {
        if (expiryDate <= issueDate)
            throw new InvalidOperationException(
                "Expiry date must be after issue date.");

        DB.Execute(
            "CALL sp_drivers_licenses_update(@id, @issue, @expiry, @country);",
            ("@id", licenseId),
            ("@issue", issueDate),
            ("@expiry", expiryDate),
            ("@country", issuingCountry)
        );
    }

    // ----------------------------
    // UPSERT-LIKE HELPER
    // ----------------------------

    public int SaveDriversLicense(
        int? licenseId,
        string licenseNumber,
        DateTime issueDate,
        DateTime expiryDate,
        string issuingCountry,
        Stream? photoStream,
        string? originalFileName
    )
    {
        int resolvedLicenseId;

        if (licenseId == null)
        {
            resolvedLicenseId = CreateDriversLicense(
                licenseNumber,
                issueDate,
                expiryDate,
                issuingCountry
            );
        }
        else
        {
            UpdateDriversLicense(
                licenseId.Value,
                issueDate,
                expiryDate,
                issuingCountry
            );

            resolvedLicenseId = licenseId.Value;
        }

        if (photoStream != null && !string.IsNullOrWhiteSpace(originalFileName))
        {
            SetDriversLicensePhoto(
                resolvedLicenseId,
                photoStream,
                originalFileName
            );
        }

        return resolvedLicenseId;
    }

    public void DeleteDriversLicense(int licenseId)
    {
        // DB has RESTRICT on customers referencing licenses
        DB.Execute(
            "CALL sp_drivers_licenses_delete(@id);",
            ("@id", licenseId)
        );
    }

    // ----------------------------
    // PHOTO MANAGEMENT
    // ----------------------------

    public void SetDriversLicensePhoto(
        int licenseId,
        Stream photoStream,
        string originalFileName
    )
    {
        var extension = Path.GetExtension(originalFileName);
        if (string.IsNullOrWhiteSpace(extension))
            throw new InvalidOperationException(
                "Invalid license photo file.");

        var directory = GetDriversLicensePhotoDirectory(licenseId);
        Directory.CreateDirectory(directory);

        foreach (var file in Directory.GetFiles(directory))
            File.Delete(file);

        var relativePath = Path.Combine(
            DriversLicensePhotoFolder,
            licenseId.ToString(),
            $"{DriversLicensePhotoFileName}{extension}"
        );

        var fullPath = Path.Combine(StorageRoot, relativePath);

        using var fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
        photoStream.CopyTo(fs);

        DB.Execute(
            "CALL sp_drivers_licenses_set_photo(@id, @path);",
            ("@id", licenseId),
            ("@path", relativePath)
        );
    }

    public void DeleteDriversLicensePhoto(int licenseId)
    {
        var directory = GetDriversLicensePhotoDirectory(licenseId);

        if (Directory.Exists(directory))
            Directory.Delete(directory, true);

        DB.Execute(
            "CALL sp_drivers_licenses_reset_photo(@id);",
            ("@id", licenseId)
        );
    }

    // ----------------------------
    // HELPERS
    // ----------------------------

    private static string GetDriversLicensePhotoDirectory(int licenseId)
    {
        return Path.Combine(
            StorageRoot,
            DriversLicensePhotoFolder,
            licenseId.ToString()
        );
    }

    private static DriversLicense MapDriversLicense(DataRow row)
    {
        var photoPath = row["photo_path"] == DBNull.Value
            ? DefaultDriversLicensePhotoPath
            : row["photo_path"].ToString();

        if (string.IsNullOrWhiteSpace(photoPath))
            photoPath = DefaultDriversLicensePhotoPath;

        return new DriversLicense
        {
            Id = Convert.ToInt32(row["id"]),
            LicenseNumber = row["license_number"].ToString()!,
            IssueDate = Convert.ToDateTime(row["issue_date"]),
            ExpiryDate = Convert.ToDateTime(row["expiry_date"]),
            IssuingCountry = row["issuing_country"].ToString()!,
            PhotoPath = photoPath
        };
    }
}
