using System;
using System.Collections.Generic;
using System.IO;
using VRMS.DTOs.Damage;
using VRMS.DTOs.Rental;
using VRMS.Enums;
using VRMS.Helpers;
using VRMS.Models.Damages;
using VRMS.Repositories.Damages;

namespace VRMS.Services.Damage
{
    public class DamageService
    {
        // ----------------------------
        // CONSTANTS
        // ----------------------------

        private const string DamagePhotoFolder = "Damages";

        private const string DefaultDamagePhotoPath =
            "Assets/img_placeholder.png";

        // ----------------------------
        // REPOSITORIES
        // ----------------------------

        private readonly DamageRepository _damageRepo;
        private readonly DamageReportRepository _reportRepo;

        // ----------------------------
        // INIT
        // ----------------------------

        public DamageService()
        {
            _damageRepo = new DamageRepository();
            _reportRepo = new DamageReportRepository();
        }

        // =====================================================
        // DAMAGE (CRUD)
        // =====================================================

        public int CreateDamage(
            int rentalId,
            DamageType damageType,
            DamageSeverity severity,
            string description,
            decimal estimatedCost)
        {
            if (rentalId <= 0)
                throw new InvalidOperationException("Invalid rental.");

            if (!Enum.IsDefined(typeof(DamageType), damageType))
                throw new InvalidOperationException("Invalid damage type.");

            if (!Enum.IsDefined(typeof(DamageSeverity), severity))
                throw new InvalidOperationException("Invalid damage severity.");

            if (string.IsNullOrWhiteSpace(description))
                throw new InvalidOperationException(
                    "Damage description is required.");

            if (estimatedCost < 0)
                throw new InvalidOperationException(
                    "Estimated cost cannot be negative.");

            return _damageRepo.Create(
                rentalId,
                damageType,
                severity,
                description,
                estimatedCost);
        }

        public void UpdateDamage(
            int damageId,
            DamageType damageType,
            DamageSeverity severity,
            string description,
            decimal estimatedCost)
        {
            if (!Enum.IsDefined(typeof(DamageType), damageType))
                throw new InvalidOperationException("Invalid damage type.");

            if (!Enum.IsDefined(typeof(DamageSeverity), severity))
                throw new InvalidOperationException("Invalid damage severity.");

            if (string.IsNullOrWhiteSpace(description))
                throw new InvalidOperationException(
                    "Damage description is required.");

            if (estimatedCost < 0)
                throw new InvalidOperationException(
                    "Estimated cost cannot be negative.");

            _damageRepo.GetById(damageId);

            _damageRepo.Update(
                damageId,
                damageType,
                severity,
                description,
                estimatedCost);
        }

        public void DeleteDamage(int damageId)
        {
            _damageRepo.Delete(damageId);
        }

        public Models.Damages.Damage GetDamageById(int damageId)
            => _damageRepo.GetById(damageId);

        public List<Models.Damages.Damage> GetDamagesByRental(int rentalId)
        {
            if (rentalId <= 0)
                throw new InvalidOperationException("Invalid rental.");

            return _damageRepo.GetByRental(rentalId);
        }

        // =====================================================
        // DAMAGE REPORTS
        // =====================================================

        public int CreateDamageReport(int damageId)
        {
            _damageRepo.GetById(damageId);
            return _reportRepo.Create(damageId);
        }

        public void ApproveDamageReport(int damageReportId)
        {
            var report = _reportRepo.GetById(damageReportId);

            if (report.Approved)
                throw new InvalidOperationException(
                    "Damage report is already approved.");

            _reportRepo.Approve(damageReportId);
        }

        public void DeleteDamageReport(int damageReportId)
        {
            var report = _reportRepo.GetById(damageReportId);

            if (report.Approved)
                throw new InvalidOperationException(
                    "Approved damage reports cannot be deleted.");

            // Delete stored photos (safe even if folder doesn't exist)
            FileStorageHelper.DeleteDirectory(
                Path.Combine(
                    DamagePhotoFolder,
                    report.DamageId.ToString()
                )
            );

            _reportRepo.Delete(damageReportId);
        }

        public DamageReport GetDamageReportById(int damageReportId)
        {
            var report = _reportRepo.GetById(damageReportId);

            report.PhotoPath =
                ResolvePhoto(report.PhotoPath);

            return report;
        }

        public List<DamageReport> GetReportsByDamage(int damageId)
        {
            if (damageId <= 0)
                throw new InvalidOperationException("Invalid damage.");

            return _reportRepo.GetByDamage(damageId);
        }

        // =====================================================
        // VEHICLE INFO (READ-ONLY)
        // =====================================================

        public RentalVehicleInfoDto GetVehicleInfoByDamage(int damageId)
        {
            return _damageRepo.GetVehicleInfoByDamage(damageId);
        }

        public RentalVehicleInfoDto GetVehicleInfoByRental(int rentalId)
        {
            if (rentalId <= 0)
                throw new InvalidOperationException("Invalid rental.");

            return _damageRepo.GetVehicleInfoByRental(rentalId);
        }

        // =====================================================
        // DAMAGE REPORT PHOTOS
        // =====================================================

        public void SetDamageReportPhoto(
            int damageReportId,
            Stream photoStream,
            string originalFileName)
        {
            var report = _reportRepo.GetById(damageReportId);

            var relativePath =
                FileStorageHelper.SaveWithGeneratedName(
                    photoStream,
                    originalFileName,
                    Path.Combine(
                        DamagePhotoFolder,
                        report.DamageId.ToString()
                    )
                );

            _reportRepo.SetPhoto(
                damageReportId,
                relativePath);
        }

        public void DeleteDamageReportPhoto(int damageReportId)
        {
            FileStorageHelper.DeleteDirectory(
                Path.Combine(
                    DamagePhotoFolder,
                    damageReportId.ToString()
                )
            );

            _reportRepo.ResetPhoto(damageReportId);
        }

        // =====================================================
        // HELPERS
        // =====================================================

        private static string ResolvePhoto(string? path)
            => string.IsNullOrWhiteSpace(path)
                ? DefaultDamagePhotoPath
                : path;
    }
}
