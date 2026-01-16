using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VRMS.DTOs.Damage;
using VRMS.DTOs.Rental;
using VRMS.Enums;
using VRMS.Services.Damage;
using VRMS.Services.Fleet;
using VRMS.Services.Rental;

namespace VRMS.Forms
{
    public partial class AddDamageForm : Form
    {
        // =========================
        // STATE
        // =========================

        private readonly int _rentalId;

        private readonly RentalService _rentalService;
        private readonly VehicleService _vehicleService;
        private readonly DamageService _damageService;

        private readonly List<string> _selectedPhotos = new();

        // =========================
        // CONSTRUCTOR
        // =========================

        public AddDamageForm(
            int rentalId,
            RentalService rentalService,
            VehicleService vehicleService,
            DamageService damageService)
        {
            InitializeComponent();

            _rentalId = rentalId;
            _rentalService = rentalService;
            _vehicleService = vehicleService;
            _damageService = damageService;

            // EVENTS
            Load += AddDamageForm_Load;
            btnAddPhoto.Click += btnAddPhoto_Click;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += (_, __) => Close();
        }

        // =========================
        // LOAD
        // =========================

        private void AddDamageForm_Load(object? sender, EventArgs e)
        {
            // Populate damage types
            cbDamageType.DataSource =
                Enum.GetValues(typeof(DamageType));

            rbSeverityMinor.Checked = true;

            // READ-ONLY vehicle info
            txtVehicleModel.ReadOnly = true;
            txtPlateNumber.ReadOnly = true;
            txtRentalNumber.ReadOnly = true;

            txtVehicleModel.BackColor = Color.WhiteSmoke;
            txtPlateNumber.BackColor = Color.WhiteSmoke;
            txtRentalNumber.BackColor = Color.WhiteSmoke;

            // Auto-load vehicle info
            LoadVehicleInfo();

            UpdatePhotoPlaceholder();
        }

        // =========================
        // VEHICLE INFO (AUTO-FETCH)
        // =========================

        private void LoadVehicleInfo()
        {
            try
            {
                RentalVehicleInfoDto info =
                    _damageService.GetVehicleInfoByRental(_rentalId);

                txtVehicleModel.Text = info.VehicleModel;
                txtPlateNumber.Text = info.PlateNumber;
                txtRentalNumber.Text = info.RentalNumber.ToString();

                lblHeaderSubtitle.Text =
                    $"{info.VehicleModel} • Plate {info.PlateNumber} • Rental #{info.RentalNumber}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Vehicle Information Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Close();
            }
        }



        // =========================
        // PHOTO UPLOAD
        // =========================

        private void btnAddPhoto_Click(object? sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Title = "Select Damage Photo",
                Filter = "Image Files|*.jpg;*.jpeg;*.png",
                Multiselect = true
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            foreach (string file in dialog.FileNames)
            {
                if (_selectedPhotos.Contains(file))
                    continue;

                _selectedPhotos.Add(file);
                AddPhotoPreview(file);
            }

            UpdatePhotoPlaceholder();
        }

        private void AddPhotoPreview(string filePath)
        {
            var pb = new PictureBox
            {
                Width = 50,
                Height = 50,
                SizeMode = PictureBoxSizeMode.Zoom,
                Margin = new Padding(5),
                Image = Image.FromFile(filePath),
                Cursor = Cursors.Hand,
                Tag = filePath
            };

            pb.Click += (_, __) =>
            {
                if (MessageBox.Show(
                        "Remove this photo?",
                        "Confirm",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    flpEvidence.Controls.Remove(pb);
                    _selectedPhotos.Remove(filePath);
                    pb.Image.Dispose();
                    pb.Dispose();
                    UpdatePhotoPlaceholder();
                }
            };

            flpEvidence.Controls.Add(pb);
        }

        private void UpdatePhotoPlaceholder()
        {
            lblNoPhotos.Visible =
                _selectedPhotos.Count == 0;
        }
        
        private DamageSeverity GetSelectedSeverity()
        {
            if (rbSeverityMinor.Checked)
                return DamageSeverity.Minor;

            if (rbSeverityMajor.Checked)
                return DamageSeverity.Major;

            if (rbSeverityCritical.Checked)
                return DamageSeverity.Critical;

            // This should never happen, but we guard anyway
            throw new InvalidOperationException(
                "Please select a damage severity.");
        }
        
        // =========================
        // SAVE DAMAGE REPORT
        // =========================

        private void btnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                ValidateForm();

                // ----------------------------
                // CREATE DAMAGE (CATALOG)
                // ----------------------------

                DamageType damageType =
                    (DamageType)cbDamageType.SelectedItem!;

                DamageSeverity severity =
                    GetSelectedSeverity();

                int damageId =
                    _damageService.CreateDamage(
                        _rentalId,
                        damageType,
                        severity,
                        txtDescription.Text.Trim(),
                        numEstimatedCost.Value
                    );



                // ----------------------------
                // SAVE ALL PHOTOS (ONE REPORT PER PHOTO)
                // ----------------------------
                foreach (var photoPath in _selectedPhotos)
                {
                    int photoReportId =
                        _damageService.CreateDamageReport(damageId);

                    using var stream =
                        File.OpenRead(photoPath);

                    _damageService.SetDamageReportPhoto(
                        photoReportId,
                        stream,
                        Path.GetFileName(photoPath)
                    );
                }

                MessageBox.Show(
                    "Damage report added successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Cannot Save Damage Report",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================
        // VALIDATION
        // =========================

        private void ValidateForm()
        {
            if (cbDamageType.SelectedItem == null)
                throw new InvalidOperationException(
                    "Please select a damage type.");

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
                throw new InvalidOperationException(
                    "Please provide a description of the damage.");

            if (numEstimatedCost.Value < 0)
                throw new InvalidOperationException(
                    "Estimated cost cannot be negative.");
        }
    }
}
