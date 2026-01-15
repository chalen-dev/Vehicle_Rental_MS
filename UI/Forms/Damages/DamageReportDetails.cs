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

        private readonly int _damageId;
        private readonly DamageService _damageService;

        private DamageReport _report = null!;
        private Damage _damage = null!;

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
                // DAMAGE
                // ----------------------------
                _damage =
                    _damageService.GetDamageById(_damageId);

                // ----------------------------
                // DAMAGE REPORTS (PHOTOS)
                // ----------------------------
                var reports =
                    _damageService.GetReportsByDamage(_damageId);

                if (reports.Count == 0)
                    throw new InvalidOperationException(
                        "No damage reports found for this damage.");

                // TEMPORARY: use the FIRST report
                _report = reports[0];


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

                LoadAllPhotos(reports);
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
        
        private void LoadAllPhotos(List<DamageReport> reports)
        {
            // 1. Clear existing images
            foreach (Control c in flowLayoutPanelImages.Controls)
            {
                if (c is PictureBox pb && pb.Image != null)
                {
                    pb.Image.Dispose();
                }
            }

            flowLayoutPanelImages.Controls.Clear();

            // 2. Add one PictureBox per valid photo
            foreach (var report in reports)
            {
                if (string.IsNullOrWhiteSpace(report.PhotoPath))
                    continue; // IMPORTANT: skips the empty one

                string fullPath =
                    Path.Combine(
                        AppContext.BaseDirectory,
                        "Storage",
                        report.PhotoPath
                    );

                if (!File.Exists(fullPath))
                    continue;

                var pb = new PictureBox
                {
                    Width = 240,
                    Height = 180,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(5),
                    Cursor = Cursors.Hand
                };

                // Safe image loading (NO FILE LOCK)
                using (var temp = Image.FromFile(fullPath))
                {
                    pb.Image = new Bitmap(temp);
                }

                // Optional: click to open full image
                pb.Click += (_, __) =>
                {
                    using var viewer = new Form
                    {
                        Text = "Damage Photo",
                        Width = 800,
                        Height = 600
                    };

                    var img = new PictureBox
                    {
                        Dock = DockStyle.Fill,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Image = new Bitmap(pb.Image)
                    };

                    viewer.Controls.Add(img);
                    viewer.ShowDialog();
                };

                flowLayoutPanelImages.Controls.Add(pb);
            }
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
