
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
            int rentalId,
            DamageType damageType,
            string description,
            decimal estimatedCost)
        {
            if (rentalId <= 0)
                throw new InvalidOperationException("Invalid rental.");

            if (!Enum.IsDefined(typeof(DamageType), damageType))
                throw new InvalidOperationException("Invalid damage type.");

            if (string.IsNullOrWhiteSpace(description))
                throw new InvalidOperationException(
                    "Damage description is required.");

            if (estimatedCost < 0)
                throw new InvalidOperationException(
                    "Estimated cost cannot be negative.");

            return _damageRepo.Create(
                rentalId,
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

        public int CreateDamageReport(int damageId)
        {
            _damageRepo.GetById(damageId);

            return _reportRepo.Create(damageId);
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
        
        public List<Models.Damages.Damage> GetDamagesByRental(int rentalId)
        {
            if (rentalId <= 0)
                throw new InvalidOperationException("Invalid rental.");

            return _damageRepo.GetByRental(rentalId);
        }
        
        public List<DamageReport> GetReportsByDamage(int damageId)
        {
            if (damageId <= 0)
                throw new InvalidOperationException("Invalid damage.");

            return _reportRepo.GetByDamage(damageId);
        }
        // ----------------------------
        // DAMAGE REPORT PHOTOS
        // ----------------------------

        public void SetDamageReportPhoto(
            int damageReportId,
            Stream photoStream,
            string originalFileName)
        {
            var report =
                _reportRepo.GetById(damageReportId);

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
