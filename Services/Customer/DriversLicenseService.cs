using System;
using System.IO;
using VRMS.Helpers;
using VRMS.Models.Customers;
using VRMS.Repositories.Customers;

namespace VRMS.Services.Customer;

/// <summary>
/// Provides business logic for driver's license management, including:
/// - Creation, update, and deletion of driver's license records
/// - Validation of license issue and expiry dates
/// - Storage and lifecycle management of license photos (front and back)
///
/// This service coordinates database persistence and file system storage
/// while enforcing validity rules.
/// </summary>
public class DriversLicenseService
{
    /// <summary>
    /// Folder name used for storing driver's license photos.
    /// </summary>
    private const string DriversLicensePhotoFolder = "DriversLicenses";

    /// <summary>
    /// Base filename for the front photo of a driver's license.
    /// </summary>
    private const string FrontPhotoFileName = "front";

    /// <summary>
    /// Base filename for the back photo of a driver's license.
    /// </summary>
    private const string BackPhotoFileName = "back";

    /// <summary>
    /// Driver's license repository for database persistence.
    /// </summary>
    private readonly DriversLicenseRepository _repo;

    /// <summary>
    /// Initializes the driver's license service.
    /// </summary>
    public DriversLicenseService()
    {
        _repo = new DriversLicenseRepository();
    }

    // ----------------------------
    // DRIVERS LICENSES
    // ----------------------------

    /// <summary>
    /// Creates a new driver's license record.
    ///
    /// Issue and expiry dates are validated before persistence.
    /// </summary>
    /// <param name="licenseNumber">License number</param>
    /// <param name="issueDate">Issue date</param>
    /// <param name="expiryDate">Expiry date</param>
    /// <param name="issuingCountry">Issuing country</param>
    /// <returns>Newly created license ID</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when expiry date is not after issue date
    /// </exception>
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

    /// <summary>
    /// Retrieves a driver's license by ID.
    /// </summary>
    public DriversLicense GetDriversLicenseById(int licenseId)
    {
        return _repo.GetById(licenseId);
    }

    /// <summary>
    /// Retrieves a driver's license by license number.
    /// </summary>
    public DriversLicense? GetDriversLicenseByNumber(string licenseNumber)
    {
        return _repo.GetByNumber(licenseNumber);
    }

    /// <summary>
    /// Updates an existing driver's license record.
    ///
    /// Issue and expiry dates are revalidated before update.
    /// </summary>
    public void UpdateDriversLicense(
        int licenseId,
        DateTime issueDate,
        DateTime expiryDate,
        string issuingCountry
    )
    {
        ValidateDates(issueDate, expiryDate);

        _repo.Update(
            licenseId,
            issueDate,
            expiryDate,
            issuingCountry
        );
    }

    /// <summary>
    /// Deletes a driver's license record.
    ///
    /// Note: Photo cleanup is handled separately.
    /// </summary>
    public void DeleteDriversLicense(int licenseId)
    {
        _repo.Delete(licenseId);
    }

    // ----------------------------
    // UPSERT-LIKE HELPER
    // ----------------------------

    /// <summary>
    /// Creates or updates a driver's license record and optionally
    /// stores front and back photos.
    ///
    /// This method behaves like an upsert:
    /// - Creates a new record when <paramref name="licenseId"/> is null
    /// - Updates an existing record otherwise
    /// </summary>
    /// <returns>The resolved driver's license ID</returns>
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

        if (frontPhotoStream != null &&
            !string.IsNullOrWhiteSpace(frontFileName))
        {
            SetFrontPhoto(
                resolvedId,
                frontPhotoStream,
                frontFileName
            );
        }

        if (backPhotoStream != null &&
            !string.IsNullOrWhiteSpace(backFileName))
        {
            SetBackPhoto(
                resolvedId,
                backPhotoStream,
                backFileName
            );
        }

        return resolvedId;
    }

    // ----------------------------
    // PHOTO MANAGEMENT
    // ----------------------------

    /// <summary>
    /// Stores or replaces the front photo of a driver's license.
    /// </summary>
    public void SetFrontPhoto(
        int licenseId,
        Stream photoStream,
        string originalFileName
    )
    {
        var relativePath =
            FileStorageHelper.SaveSingleFile(
                photoStream,
                originalFileName,
                Path.Combine(
                    DriversLicensePhotoFolder,
                    licenseId.ToString()
                ),
                FrontPhotoFileName
            );

        _repo.SetFrontPhoto(
            licenseId,
            relativePath
        );
    }


    /// <summary>
    /// Stores or replaces the back photo of a driver's license.
    /// </summary>
    public void SetBackPhoto(
        int licenseId,
        Stream photoStream,
        string originalFileName
    )
    {
        var relativePath =
            FileStorageHelper.SaveSingleFile(
                photoStream,
                originalFileName,
                Path.Combine(
                    DriversLicensePhotoFolder,
                    licenseId.ToString()
                ),
                BackPhotoFileName
            );

        _repo.SetBackPhoto(
            licenseId,
            relativePath
        );
    }


    /// <summary>
    /// Deletes all driver's license photos from the file system
    /// and resets stored paths in the database.
    /// </summary>
    public void DeleteDriversLicensePhotos(int licenseId)
    {
        FileStorageHelper.DeleteDirectory(
            Path.Combine(
                DriversLicensePhotoFolder,
                licenseId.ToString()
            )
        );

        _repo.ResetPhotos(licenseId);
    }

    // ----------------------------
    // HELPERS
    // ----------------------------

    /// <summary>
    /// Validates driver's license issue and expiry dates.
    /// </summary>
    private static void ValidateDates(
        DateTime issue,
        DateTime expiry)
    {
        if (expiry <= issue)
            throw new InvalidOperationException(
                "Expiry date must be after issue date.");
    }
}
