using System;
using System.IO;
using VRMS.Models.Customers;
using VRMS.Repositories.Customers;

namespace VRMS.Services.Customer;

public class DriversLicenseService
{
    private static readonly string StorageRoot =
    Path.Combine(AppContext.BaseDirectory, "Storage");
    private const string DriversLicensePhotoFolder = "DriversLicenses";
    private const string FrontPhotoFileName = "front";
    private const string BackPhotoFileName  = "back";

    private readonly DriversLicenseRepository _repo;

    public DriversLicenseService()
    {
        _repo = new DriversLicenseRepository();
    }

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
        ValidateDates(issueDate, expiryDate);

        return _repo.Create(
            licenseNumber,
            issueDate,
            expiryDate,
            issuingCountry
        );
    }

    public DriversLicense GetDriversLicenseById(int licenseId)
    {
        return _repo.GetById(licenseId);
    }

    public DriversLicense? GetDriversLicenseByNumber(string licenseNumber)
    {
        return _repo.GetByNumber(licenseNumber);
    }

    public void UpdateDriversLicense(
        int licenseId,
        DateTime issueDate,
        DateTime expiryDate,
        string issuingCountry
    )
    {
        ValidateDates(issueDate, expiryDate);
        _repo.Update(licenseId, issueDate, expiryDate, issuingCountry);
    }

    public void DeleteDriversLicense(int licenseId)
    {
        _repo.Delete(licenseId);
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
        Stream? frontPhotoStream,
        string? frontFileName,
        Stream? backPhotoStream,
        string? backFileName
    )
    {
        int resolvedId;

        if (licenseId == null)
        {
            resolvedId = CreateDriversLicense(
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
            resolvedId = licenseId.Value;
        }

        if (frontPhotoStream != null && !string.IsNullOrWhiteSpace(frontFileName))
            SetFrontPhoto(resolvedId, frontPhotoStream, frontFileName);

        if (backPhotoStream != null && !string.IsNullOrWhiteSpace(backFileName))
            SetBackPhoto(resolvedId, backPhotoStream, backFileName);

        return resolvedId;
    }

    // ----------------------------
    // PHOTO MANAGEMENT
    // ----------------------------
    public void SetFrontPhoto(
        int licenseId,
        Stream photoStream,
        string originalFileName
    )
    {
        var path = SavePhoto(
            licenseId,
            photoStream,
            originalFileName,
            FrontPhotoFileName
        );

        _repo.SetFrontPhoto(licenseId, path);
    }

    public void SetBackPhoto(
        int licenseId,
        Stream photoStream,
        string originalFileName
    )
    {
        var path = SavePhoto(
            licenseId,
            photoStream,
            originalFileName,
            BackPhotoFileName
        );

        _repo.SetBackPhoto(licenseId, path);
    }

    public void DeleteDriversLicensePhotos(int licenseId)
    {
        var directory = GetDriversLicensePhotoDirectory(licenseId);

        if (Directory.Exists(directory))
            Directory.Delete(directory, true);

        _repo.ResetPhotos(licenseId);
    }

    // ----------------------------
    // HELPERS
    // ----------------------------
    private static void ValidateDates(DateTime issue, DateTime expiry)
    {
        if (expiry <= issue)
            throw new InvalidOperationException(
                "Expiry date must be after issue date.");
    }

    private static string SavePhoto(
        int licenseId,
        Stream photoStream,
        string originalFileName,
        string fileName
    )
    {
        if (photoStream.CanSeek)
            photoStream.Position = 0;   // 🔥 THIS IS THE FIX

        var extension = Path.GetExtension(originalFileName);
        if (string.IsNullOrWhiteSpace(extension))
            throw new InvalidOperationException("Invalid license photo file.");

        var directory = GetDriversLicensePhotoDirectory(licenseId);
        Directory.CreateDirectory(directory);

        var relativePath = Path.Combine(
            DriversLicensePhotoFolder,
            licenseId.ToString(),
            $"{fileName}{extension}"
        );

        var fullPath = Path.Combine(StorageRoot, relativePath);

        using var fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
        photoStream.CopyTo(fs);

        return relativePath;
    }

    private static string GetDriversLicensePhotoDirectory(int licenseId)
    {
        return Path.Combine(
            StorageRoot,
            DriversLicensePhotoFolder,
            licenseId.ToString()
        );
    }
}
