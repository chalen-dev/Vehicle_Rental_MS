using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VRMS.Services.Damage;

namespace VRMS.Forms
{
    public partial class AddDamageForm : Form
    {
        // =========================
        // TEMP STATE (UI ONLY)
        // =========================

        private readonly DamageService _damageService;

        private readonly int _vehicleInspectionId; // passed by caller
        private readonly List<string> _selectedPhotos = new();

        // =========================
        // CONSTRUCTOR
        // =========================

        public AddDamageForm(int vehicleInspectionId)
        {
            InitializeComponent();

            _vehicleInspectionId = vehicleInspectionId;
            _damageService = new DamageService(); // TEMP (matches your current service)

            // EVENTS
            Load += AddDamageForm_Load;
            btnAddPhoto.Click += btnAddPhoto_Click;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += (_, __) => Close();
        }

        // =========================
        // LOAD
        // =========================

        private void AddDamageForm_Load(object sender, EventArgs e)
        {
            // Default selections
            if (cbDamageType.Items.Count > 0)
                cbDamageType.SelectedIndex = 0;

            rbSeverityMinor.Checked = true;

            UpdatePhotoPlaceholder();
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

            foreach (var file in dialog.FileNames)
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
            lblNoPhotos.Visible = _selectedPhotos.Count == 0;
        }

        // =========================
        // SAVE DAMAGE REPORT
        // =========================

        private void btnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                ValidateForm();

                // ---------------------------------
                // TEMP DAMAGE CREATION (CATALOG)
                // ---------------------------------
                int damageId = _damageService.CreateDamage(
                    description: $"{cbDamageType.Text} - {txtDescription.Text.Trim()}",
                    estimatedCost: numEstimatedCost.Value
                );

                // ---------------------------------
                // DAMAGE REPORT CREATION
                // ---------------------------------
                int reportId = _damageService.CreateDamageReport(
                    _vehicleInspectionId,
                    damageId
                );

                // ---------------------------------
                // SAVE PHOTOS (TEMP: FIRST PHOTO ONLY)
                // ---------------------------------
                if (_selectedPhotos.Count > 0)
                {
                    using var stream =
                        File.OpenRead(_selectedPhotos[0]);

                    _damageService.SetDamageReportPhoto(
                        reportId,
                        stream,
                        Path.GetFileName(_selectedPhotos[0])
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
