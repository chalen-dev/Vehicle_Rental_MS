using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VRMS.Models.Damages;
using VRMS.Services.Damage;

namespace VRMS.UI.Forms.Damages
{
    public partial class DamageReportDetails : Form
    {
        // =====================================================
        // STATE
        // =====================================================

        private readonly int _damageReportId;
        private readonly DamageService _damageService;

        private DamageReport _report = null!;
        private Damage _damage = null!;

        private bool _editMode;

        // =====================================================
        // CONSTRUCTOR
        // =====================================================

        public DamageReportDetails(
            int damageReportId,
            DamageService damageService)
        {
            InitializeComponent();

            _damageReportId = damageReportId;
            _damageService = damageService;

            Load += DamageReportDetails_Load;
            btnEdit.Click += BtnEdit_Click;
            btnSave.Click += BtnSave_Click;
            btnClose.Click += (_, __) => Close();
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
                // ----------------------------
                // DAMAGE REPORT
                // ----------------------------
                _report =
                    _damageService.GetDamageReportById(
                        _damageReportId);

                // ----------------------------
                // DAMAGE
                // ----------------------------
                _damage =
                    _damageService.GetDamageById(
                        _report.DamageId);

                // ----------------------------
                // REPORT INFO (PLACEHOLDERS)
                // ----------------------------
                txtReportId.Text = _report.Id.ToString();
                txtReportedBy.Text = "System";
                dtpReportDate.Value = DateTime.Now;
                txtLocation.Text = "N/A";
                

                // ----------------------------
                // VEHICLE INFO (VIA DAMAGE → RENTAL)
                // ----------------------------
                var vehicle =
                    _damageService.GetVehicleInfoByDamage(
                        _damage.Id);

                txtVIN.Text = "N/A";
                txtLicensePlate.Text = vehicle.PlateNumber;

                // vehicle_model already contains "Make Model"
                txtVehicleMake.Text = vehicle.VehicleModel;
                txtVehicleModel.Text = vehicle.VehicleModel;

                txtVehicleColor.Text = "N/A";


                // ----------------------------
                // DAMAGE DETAILS
                // ----------------------------
                txtDamageDescription.Text = _damage.Description;
                txtDamageType.Text = _damage.DamageType.ToString();
                txtSeverity.Text = "N/A";
                txtRepairCost.Text = _damage.EstimatedCost.ToString("₱#,##0.00");
                txtRepairNotes.Text = string.Empty;

                // ----------------------------
                // STATUS (ONLY WHAT DB SUPPORTS)
                // ----------------------------
                cbStatus.Items.Clear();
                cbStatus.Items.Add("Pending");
                cbStatus.Items.Add("Approved");

                cbStatus.SelectedIndex =
                    _report.Approved ? 1 : 0;

                // ----------------------------
                // PHOTO
                // ----------------------------
                LoadPhoto(_report.PhotoPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Failed to Load Damage Report",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Close();
            }
        }

        // =====================================================
        // PHOTO LOADING (SAFE)
        // =====================================================

        private void LoadPhoto(string relativePath)
        {
            pbDamageImage1.Image?.Dispose();
            pbDamageImage1.Image = null;

            if (string.IsNullOrWhiteSpace(relativePath))
                return;

            // MUST match FileStorageHelper.StorageRoot
            string fullPath =
                Path.Combine(
                    AppContext.BaseDirectory,
                    "Storage",
                    relativePath
                );

            if (!File.Exists(fullPath))
                return;

            // Load safely without locking the file
            using var temp = Image.FromFile(fullPath);
            pbDamageImage1.Image = new Bitmap(temp);
        }




        // =====================================================
        // EDIT MODE
        // =====================================================

        private void SetEditMode(bool enabled)
        {
            _editMode = enabled;

            cbStatus.Enabled = enabled;
            btnSave.Enabled = enabled;
            btnEdit.Enabled = !enabled;
        }

        // =====================================================
        // EDIT
        // =====================================================

        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            SetEditMode(true);
        }

        // =====================================================
        // SAVE (APPROVAL ONLY)
        // =====================================================

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                bool approveSelected =
                    cbStatus.SelectedItem?.ToString() == "Approved";

                // DB only supports approving ONCE
                if (approveSelected && !_report.Approved)
                {
                    _damageService.ApproveDamageReport(
                        _report.Id);
                }

                MessageBox.Show(
                    "Damage report updated successfully.",
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
    }
}
