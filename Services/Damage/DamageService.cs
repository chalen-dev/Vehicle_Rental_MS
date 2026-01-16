using System;
using System.Collections.Generic;
using System.IO;
using VRMS.DTOs.Damage;
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
        private const string DamagePhotoFileName = "damage";

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

        // ----------------------------
        // DAMAGE CATALOG
        // ----------------------------

        public int CreateDamage(
            DamageType damageType,
            string description,
            decimal estimatedCost)
        {
            if (!Enum.IsDefined(typeof(DamageType), damageType))
                throw new InvalidOperationException("Invalid damage type.");

            if (string.IsNullOrWhiteSpace(description))
                throw new InvalidOperationException(
                    "Damage description is required.");

            if (estimatedCost < 0)
                throw new InvalidOperationException(
                    "Estimated cost cannot be negative.");

            return _damageRepo.Create(
                damageType,
                description,
                estimatedCost);
        }

        public void UpdateDamage(
            int damageId,
            DamageType damageType,
            string description,
            decimal estimatedCost)
        {
            if (!Enum.IsDefined(typeof(DamageType), damageType))
                throw new InvalidOperationException("Invalid damage type.");

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
                description,
                estimatedCost);
        }

        public void DeleteDamage(int damageId)
        {
            _damageRepo.Delete(damageId);
        }

        public Models.Damages.Damage GetDamageById(int damageId)
            => _damageRepo.GetById(damageId);

        public List<Models.Damages.Damage> GetAllDamages()
            => _damageRepo.GetAll();

        // ----------------------------
        // DAMAGE REPORTS
        // ----------------------------

        public int CreateDamageReport(
            int vehicleInspectionId,
            int damageId)
        {
            _damageRepo.GetById(damageId);

            return _reportRepo.Create(
                vehicleInspectionId,
                damageId);
        }

        public void ApproveDamageReport(int damageReportId)
        {
            var report =
                _reportRepo.GetById(damageReportId);

            if (report.Approved)
                throw new InvalidOperationException(
                    "Damage report is already approved.");

            _reportRepo.Approve(
                damageReportId);
        }

        public DamageReport GetDamageReportById(int damageReportId)
        {
            var report =
                _reportRepo.GetById(damageReportId);

            report.PhotoPath =
                ResolvePhoto(report.PhotoPath);

            return report;
        }

        public List<DamageReport> GetDamageReportsByInspection(
            int vehicleInspectionId)
        {
            var list =
                _reportRepo.GetByInspection(
                    vehicleInspectionId);

            foreach (var r in list)
                r.PhotoPath =
                    ResolvePhoto(r.PhotoPath);

            return list;
        }

        // ----------------------------
        // READ-ONLY VEHICLE INFO (NEW)
        // ----------------------------

        public InspectionVehicleInfoDto
            GetVehicleInfoByInspection(int inspectionId)
        {
            return _damageRepo.GetVehicleInfoByInspection(
                inspectionId);
        }

        // ----------------------------
        // DAMAGE REPORT PHOTOS
        // ----------------------------

        public void SetDamageReportPhoto(
            int damageReportId,
            Stream photoStream,
            string originalFileName)
        {
            var relativePath =
                FileStorageHelper.SaveSingleFile(
                    photoStream,
                    originalFileName,
                    Path.Combine(
                        DamagePhotoFolder,
                        damageReportId.ToString()
                    ),
                    DamagePhotoFileName,
                    clearDirectoryFirst: true
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

            _reportRepo.ResetPhoto(
                damageReportId);
        }

        // ----------------------------
        // HELPERS
        // ----------------------------

        private static string ResolvePhoto(string? path)
            => string.IsNullOrWhiteSpace(path)
                ? DefaultDamagePhotoPath
                : path;
    }
}
