using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VRMS.Models.Damages;
using VRMS.Services.Damage;
using VRMS.UI.ApplicationService;
using VRMS.UI.Config.Support;

namespace VRMS.UI.Forms.Damages
{
    public partial class DamageReportDetails : Form
    {
        // =====================================================
        // STATE
        // =====================================================

        private readonly int _damageId;
        private readonly DamageService _damageService;

        private Damage _damage = null!;
        private DamageReport _report = null!;

        private bool _editMode;

        // =====================================================
        // CONSTRUCTOR
        // =====================================================

        public DamageReportDetails(
            int damageId,
            DamageService damageService)
        {
            InitializeComponent();

            _damageId = damageId;
            _damageService = damageService;

            Load += DamageReportDetails_Load;
            btnEdit.Click += BtnEdit_Click;
            btnSave.Click += BtnSave_Click;
            btnClose.Click += (_, __) => Close();

            // DELETE BUTTON (button1 in designer)
            button1.Click += BtnDelete_Click;
        }

        // =====================================================
        // LOAD
        // =====================================================

        private void DamageReportDetails_Load(object? sender, EventArgs e)
        {
            LoadData();
            SetEditMode(false);
        }

        // =====================================================
        // LOAD DATA
        // =====================================================

        private void LoadData()
        {
            try
            {
                _damage = _damageService.GetDamageById(_damageId);

                var reports =
                    _damageService.GetReportsByDamage(_damageId);

                if (reports.Count == 0)
                    throw new InvalidOperationException(
                        "No damage reports found.");

                _report = reports[0];

                // -----------------------------
                // REPORT INFO
                // -----------------------------
                txtReportId.Text = _report.Id.ToString();

                txtReportedBy.Text =
                    Session.CurrentUser != null
                        ? (!string.IsNullOrWhiteSpace(Session.CurrentUser.FullName)
                            ? Session.CurrentUser.FullName
                            : Session.CurrentUser.Username)
                        : "System";

                dtpReportDate.Value = DateTime.Now;
                txtLocation.Text = "Return Inspection";

                // -----------------------------
                // VEHICLE INFO (READ-ONLY)
                // -----------------------------
                var vehicleInfo =
                    _damageService.GetVehicleInfoByDamage(_damage.Id);

                var rental =
                    ApplicationServices.RentalService
                        .GetRentalById(vehicleInfo.RentalNumber);

                var vehicle =
                    ApplicationServices.VehicleService
                        .GetVehicleById(rental.VehicleId);

                txtVIN.Text = vehicle.VIN;
                txtLicensePlate.Text = vehicle.LicensePlate;
                txtVehicleMake.Text = vehicle.Make;
                txtVehicleModel.Text = vehicle.Model;
                txtVehicleColor.Text = vehicle.Color;

                // -----------------------------
                // DAMAGE DETAILS
                // -----------------------------
                txtDamageDescription.Text = _damage.Description;
                txtDamageType.Text = _damage.DamageType.ToString();
                txtSeverity.Text = CalculateSeverity(_damage.EstimatedCost);
                txtRepairCost.Text = _damage.EstimatedCost.ToString("0.00");

                LoadAllPhotos(reports);

                // DELETE DISABLED IF APPROVED
                button1.Enabled = !_report.Approved;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Load Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Close();
            }
        }

        // =====================================================
        // PHOTOS (SAFE)
        // =====================================================

        private void LoadAllPhotos(
            System.Collections.Generic.List<DamageReport> reports)
        {
            flowLayoutPanelImages.Controls.Clear();

            foreach (var report in reports)
            {
                if (string.IsNullOrWhiteSpace(report.PhotoPath))
                    continue;

                var fullPath =
                    Path.Combine(
                        AppContext.BaseDirectory,
                        "Storage",
                        report.PhotoPath);

                if (!File.Exists(fullPath))
                    continue;

                var pb = new PictureBox
                {
                    Width = 240,
                    Height = 180,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(5)
                };

                using (var fs = new FileStream(
                           fullPath,
                           FileMode.Open,
                           FileAccess.Read,
                           FileShare.ReadWrite))
                {
                    pb.Image = Image.FromStream(fs);
                }

                flowLayoutPanelImages.Controls.Add(pb);
            }
        }

        // =====================================================
        // EDIT MODE
        // =====================================================

        private void SetEditMode(bool enabled)
        {
            _editMode = enabled;

            txtDamageDescription.ReadOnly = !enabled;
            txtRepairCost.ReadOnly = !enabled;

            btnSave.Enabled = enabled;
            btnEdit.Enabled = !enabled;
        }

        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (_report.Approved)
            {
                MessageBox.Show(
                    "Approved reports cannot be edited.",
                    "Edit Blocked",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            SetEditMode(true);
        }

        // =====================================================
        // SAVE (DAMAGE UPDATE)
        // =====================================================

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!decimal.TryParse(txtRepairCost.Text, out var cost))
                    throw new InvalidOperationException(
                        "Invalid repair cost.");

                _damageService.UpdateDamage(
                    _damage.Id,
                    _damage.DamageType,
                    _damage.Severity,
                    txtDamageDescription.Text.Trim(),
                    cost);

                MessageBox.Show(
                    "Damage updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                SetEditMode(false);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Save Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // DELETE REPORT
        // =====================================================

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (_report.Approved)
            {
                MessageBox.Show(
                    "Approved reports cannot be deleted.",
                    "Delete Blocked",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var confirm =
                MessageBox.Show(
                    "Delete this damage report?\nThis cannot be undone.",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                _damageService.DeleteDamageReport(_report.Id);

                MessageBox.Show(
                    "Damage report deleted.",
                    "Deleted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Delete Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // SEVERITY (DERIVED)
        // =====================================================

        private static string CalculateSeverity(decimal cost)
        {
            if (cost <= 1000m) return "Minor";
            if (cost <= 5000m) return "Moderate";
            return "Severe";
        }
    }
}
