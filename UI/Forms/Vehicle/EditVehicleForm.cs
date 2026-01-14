using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VRMS.Enums;
using VRMS.Models.Fleet;
using VRMS.Services.Fleet;

namespace VRMS.Forms
{
    public partial class EditVehicleForm : Form
    {
        private readonly int _vehicleId;
        private readonly VehicleService _vehicleService;

        private Vehicle _vehicle = null!;
        private bool _isLoaded;

        // ORIGINAL VALUES (for change detection)
        private decimal _originalFuelEfficiency;
        private int _originalCargoCapacity;
        private HashSet<int> _originalFeatureIds = new();

        // =========================
        // SAVE BUTTON COLORS
        // =========================
        private readonly Color _saveEnabledColor =
            Color.FromArgb(46, 204, 113);
        private readonly Color _saveDisabledColor =
            Color.FromArgb(189, 195, 199);
        private readonly Color _saveDisabledTextColor =
            Color.FromArgb(120, 120, 120);

        private readonly Color _errorBackColor =
            Color.FromArgb(255, 235, 238);
        private readonly Color _normalBackColor =
            Color.White;

        // =========================
        // CONSTRUCTOR
        // =========================
        public EditVehicleForm(int vehicleId, VehicleService vehicleService)
        {
            InitializeComponent();

            _vehicleId = vehicleId;
            _vehicleService = vehicleService;

            HookEvents();
            Load += EditVehicleForm_Load;
        }

        // =========================
        // EVENT WIRING
        // =========================
        private void HookEvents()
        {
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (_, __) => Close();
           
            btnSelectImage.Click += BtnSelectImage_Click;
            btnRemoveImage.Click += BtnRemoveImage_Click;
            lstImages.SelectedIndexChanged += LstImages_SelectedIndexChanged;

            txtColor.TextChanged += (_, __) => UpdateSaveButtonState();
            numMileage.ValueChanged += (_, __) => UpdateSaveButtonState();
            txtFuelEfficiency.TextChanged += (_, __) => UpdateSaveButtonState();
            numCargoCapacity.ValueChanged += (_, __) => UpdateSaveButtonState();
            cbStatus.SelectedIndexChanged += (_, __) => UpdateSaveButtonState();
            cbCategory.SelectedIndexChanged += (_, __) => UpdateSaveButtonState();

            chkAC.CheckedChanged += (_, __) => UpdateSaveButtonState();
            chkGPS.CheckedChanged += (_, __) => UpdateSaveButtonState();
            chkBluetooth.CheckedChanged += (_, __) => UpdateSaveButtonState();
            chkChildSeat.CheckedChanged += (_, __) => UpdateSaveButtonState();
            chkInsuranceIncluded.CheckedChanged += (_, __) => UpdateSaveButtonState();
        }

        // =========================
        // LOAD VEHICLE
        // =========================
        private void EditVehicleForm_Load(object? sender, EventArgs e)
        {
            try
            {
                _vehicle = _vehicleService.GetVehicleFull(_vehicleId);

                ConfigureEnums();
                LoadCategories();
                PopulateForm();
                LoadFeatures();
                LoadVehicleImages();

                LockImmutableFields();

                _isLoaded = true;
                UpdateSaveButtonState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error Loading Vehicle",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Close();
            }
        }

        // =========================
        // CONFIGURATION
        // =========================
        private void ConfigureEnums()
        {
            cbTransmission.DataSource =
                Enum.GetValues(typeof(TransmissionType));
            cbFuel.DataSource =
                Enum.GetValues(typeof(FuelType));
            cbStatus.DataSource =
                Enum.GetValues(typeof(VehicleStatus));
        }

        private void LoadCategories()
        {
            try
            {
                var categories = _vehicleService.GetAllCategories();
                cbCategory.DataSource = categories;
                cbCategory.DisplayMember = "Name";
                cbCategory.ValueMember = "Id";

                // Set the current vehicle's category
                if (_vehicle != null && _vehicle.VehicleCategoryId > 0)
                {
                    cbCategory.SelectedValue = _vehicle.VehicleCategoryId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error loading categories: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void PopulateForm()
        {
            txtMake.Text = _vehicle.Make;
            txtModel.Text = _vehicle.Model;
            numYear.Value = _vehicle.Year;
            txtPlate.Text = _vehicle.LicensePlate;
            txtVIN.Text = _vehicle.VIN;

            txtColor.Text = _vehicle.Color;
            numMileage.Value = _vehicle.Odometer;
            numSeats.Value = _vehicle.SeatingCapacity;

            txtFuelEfficiency.Text = _vehicle.FuelEfficiency.ToString("0.##");
            numCargoCapacity.Value = _vehicle.CargoCapacity;

            cbTransmission.SelectedItem = _vehicle.Transmission;
            cbFuel.SelectedItem = _vehicle.FuelType;
            cbStatus.SelectedItem = _vehicle.Status;

            _originalFuelEfficiency = _vehicle.FuelEfficiency;
            _originalCargoCapacity = _vehicle.CargoCapacity;
        }

        private void LockImmutableFields()
        {
            txtMake.ReadOnly = true;
            txtModel.ReadOnly = true;
            numYear.Enabled = false;
            txtPlate.ReadOnly = true;
            txtVIN.ReadOnly = true;

            cbTransmission.Enabled = false;
            cbFuel.Enabled = false;
            numSeats.Enabled = false;
        }

        // =========================
        // FEATURES - FIXED VERSION
        // =========================
        private void LoadFeatures()
        {
            try
            {
                var features = _vehicleService.GetVehicleFeatures(_vehicleId);
                _originalFeatureIds = features.Select(f => f.Id).ToHashSet();

                // Reset all checkboxes first
                chkAC.Checked = false;
                chkGPS.Checked = false;
                chkBluetooth.Checked = false;
                chkChildSeat.Checked = false;
                chkInsuranceIncluded.Checked = false;

                // Set checkboxes based on exact feature names from your database
                foreach (var feature in features)
                {
                    switch (feature.Name)
                    {
                        case "Air Conditioning":
                            chkAC.Checked = true;
                            break;
                        case "GPS Navigation":
                            chkGPS.Checked = true;
                            break;
                        case "Bluetooth":  // Fixed: This is the exact name in your database
                            chkBluetooth.Checked = true;
                            break;
                        case "Child Seat Availability":
                            chkChildSeat.Checked = true;
                            break;
                        case "Insurance Coverage Included":
                            chkInsuranceIncluded.Checked = true;
                            break;
                        default:
                            // Handle any other features that might exist
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error loading features: {ex.Message}",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private HashSet<int> GetSelectedFeatureIds()
        {
            var all = _vehicleService.GetAllFeatures();
            var selected = new HashSet<int>();

            // Find features by their exact names from your database
            foreach (var feature in all)
            {
                if (chkAC.Checked && feature.Name == "Air Conditioning")
                {
                    selected.Add(feature.Id);
                }
                if (chkGPS.Checked && feature.Name == "GPS Navigation")
                {
                    selected.Add(feature.Id);
                }
                if (chkBluetooth.Checked && feature.Name == "Bluetooth")  // Fixed: Exact name match
                {
                    selected.Add(feature.Id);
                }
                if (chkChildSeat.Checked && feature.Name == "Child Seat Availability")
                {
                    selected.Add(feature.Id);
                }
                if (chkInsuranceIncluded.Checked && feature.Name == "Insurance Coverage Included")
                {
                    selected.Add(feature.Id);
                }
            }

            return selected;
        }

        private bool FeaturesChanged()
        {
            return !_originalFeatureIds
                .SetEquals(GetSelectedFeatureIds());
        }

        // =========================
        // IMAGES
        // =========================
        private void LoadVehicleImages()
        {
            try
            {
                var images = _vehicleService.GetVehicleImages(_vehicleId);
                lstImages.Items.Clear();

                foreach (var image in images)
                {
                    lstImages.Items.Add(new ImageListItem
                    {
                        Id = image.Id,
                        FileName = System.IO.Path.GetFileName(image.ImagePath),
                        FullPath = System.IO.Path.Combine(
                            AppContext.BaseDirectory,
                            "Storage",
                            image.ImagePath)
                    });
                }

                if (lstImages.Items.Count > 0)
                {
                    lstImages.SelectedIndex = 0;
                }
                else
                {
                    picVehicle.Image = null;
                    lblImageStatus.Text = "No images available";
                }
            }
            catch (Exception ex)
            {
                lblImageStatus.Text = $"Error loading images: {ex.Message}";
            }
        }

        private void LstImages_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (lstImages.SelectedItem is ImageListItem item)
            {
                try
                {
                    if (System.IO.File.Exists(item.FullPath))
                    {
                        picVehicle.Image = Image.FromFile(item.FullPath);
                        lblImageStatus.Text = $"Image: {item.FileName}";
                    }
                }
                catch (Exception ex)
                {
                    picVehicle.Image = null;
                    lblImageStatus.Text = $"Error loading image: {ex.Message}";
                }
            }
        }

        private void BtnSelectImage_Click(object? sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                dialog.Title = "Select Vehicle Image";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var stream = dialog.OpenFile())
                        {
                            _vehicleService.AddVehicleImage(
                                _vehicleId,
                                stream,
                                dialog.FileName);
                        }

                        LoadVehicleImages();
                        MessageBox.Show("Image added successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error adding image: {ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnRemoveImage_Click(object? sender, EventArgs e)
        {
            if (lstImages.SelectedItem is ImageListItem item)
            {
                var result = MessageBox.Show(
                    $"Are you sure you want to remove '{item.FileName}'?",
                    "Confirm Removal",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _vehicleService.RemoveVehicleImage(item.Id);
                        LoadVehicleImages();
                        MessageBox.Show("Image removed successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error removing image: {ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an image to remove.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // =========================
        // CATEGORIES
        // =========================
        private void BtnAddCategory_Click(object? sender, EventArgs e)
        {
            using (var dialog = new SimpleInputDialog("Add New Category", "Category Name:"))
            {
                if (dialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.InputText))
                {
                    try
                    {
                        int newCategoryId = _vehicleService.CreateCategory(
                            dialog.InputText.Trim(),
                            null,
                            0m
                        );

                        // Refresh categories
                        LoadCategories();

                        // Select the newly created category
                        cbCategory.SelectedValue = newCategoryId;

                        MessageBox.Show("Category added successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error adding category: {ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // =========================
        // SAVE
        // =========================
        private void BtnSave_Click(object? sender, EventArgs e)
        {
            ResetErrorStyles();

            var errors = ValidateFormDetailed();
            if (errors.Count > 0)
            {
                ShowValidationErrors(errors);
                return;
            }

            if (!HasChanges())
            {
                MessageBox.Show(
                    "No changes were made.\n\nNothing to save.",
                    "Nothing to Save",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Get the selected category ID
                int selectedCategoryId = cbCategory.SelectedValue != null ?
                    (int)cbCategory.SelectedValue : _vehicle.VehicleCategoryId;

                _vehicleService.UpdateVehicle(
                    vehicleId: _vehicleId,
                    color: txtColor.Text.Trim(),
                    newOdometer: (int)numMileage.Value,
                    fuelEfficiency: decimal.Parse(txtFuelEfficiency.Text),
                    cargoCapacity: (int)numCargoCapacity.Value,
                    categoryId: selectedCategoryId
                );

                var newStatus = (VehicleStatus)cbStatus.SelectedItem!;

                if (newStatus != _vehicle.Status)
                    _vehicleService.UpdateVehicleStatus(_vehicleId, newStatus);

                var newFeatures = GetSelectedFeatureIds();

                // Remove features that are no longer selected
                foreach (var id in _originalFeatureIds.Except(newFeatures))
                    _vehicleService.RemoveFeatureFromVehicle(_vehicleId, id);

                // Add newly selected features
                foreach (var id in newFeatures.Except(_originalFeatureIds))
                    _vehicleService.AddFeatureToVehicle(_vehicleId, id);

                DialogResult = DialogResult.OK;
                Close();
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

        // =========================
        // VALIDATION
        // =========================
        private List<(Control control, string label, string message)>
            ValidateFormDetailed()
        {
            var errors =
                new List<(Control, string, string)>();

            if (string.IsNullOrWhiteSpace(txtColor.Text))
                errors.Add((txtColor, "Color", "Required"));

            if (numMileage.Value < _vehicle.Odometer)
                errors.Add((numMileage, "Mileage",
                    $"Must be ≥ {_vehicle.Odometer}"));

            if (!decimal.TryParse(txtFuelEfficiency.Text, out var eff) || eff <= 0)
                errors.Add((txtFuelEfficiency,
                    "Fuel Efficiency", "Must be > 0"));

            if (numCargoCapacity.Value <= 0)
                errors.Add((numCargoCapacity,
                    "Cargo Capacity", "Must be > 0"));

            return errors;
        }

        private void ShowValidationErrors(
            List<(Control control, string label, string message)> errors)
        {
            foreach (var e in errors)
                e.control.BackColor = _errorBackColor;

            errors[0].control.Focus();

            MessageBox.Show(
                "Fix the following:\n\n" +
                string.Join("\n",
                    errors.Select(e =>
                        $"• {e.label}: {e.message}")),
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private void ResetErrorStyles()
        {
            txtColor.BackColor = _normalBackColor;
            numMileage.BackColor = _normalBackColor;
            txtFuelEfficiency.BackColor = _normalBackColor;
            numCargoCapacity.BackColor = _normalBackColor;
        }

        // =========================
        // CHANGE + SAVE STATE
        // =========================
        private bool HasChanges()
        {
            if (!_isLoaded) return false;

            // Get current category ID from combobox
            int currentCategoryId = cbCategory.SelectedValue != null ?
                (int)cbCategory.SelectedValue : 0;

            return
                txtColor.Text.Trim() != _vehicle.Color ||
                numMileage.Value != _vehicle.Odometer ||
                decimal.Parse(txtFuelEfficiency.Text) != _originalFuelEfficiency ||
                numCargoCapacity.Value != _originalCargoCapacity ||
                currentCategoryId != _vehicle.VehicleCategoryId ||
                (VehicleStatus)cbStatus.SelectedItem! != _vehicle.Status ||
                FeaturesChanged();
        }

        private void UpdateSaveButtonState()
        {
            if (!_isLoaded)
            {
                SetSaveDisabled();
                return;
            }

            bool isValid =
                !string.IsNullOrWhiteSpace(txtColor.Text) &&
                numMileage.Value >= _vehicle.Odometer &&
                decimal.TryParse(txtFuelEfficiency.Text, out var eff) && eff > 0 &&
                numCargoCapacity.Value > 0;

            if (isValid && HasChanges())
                SetSaveEnabled();
            else
                SetSaveDisabled();
        }

        private void SetSaveEnabled()
        {
            btnSave.Enabled = true;
            btnSave.BackColor = _saveEnabledColor;
            btnSave.ForeColor = Color.White;
            btnSave.Cursor = Cursors.Hand;
        }

        private void SetSaveDisabled()
        {
            btnSave.Enabled = false;
            btnSave.BackColor = _saveDisabledColor;
            btnSave.ForeColor = _saveDisabledTextColor;
            btnSave.Cursor = Cursors.Default;
        }

        // =========================
        // HELPER CLASSES
        // =========================
        private class ImageListItem
        {
            public int Id { get; set; }
            public string FileName { get; set; } = string.Empty;
            public string FullPath { get; set; } = string.Empty;

            public override string ToString() => FileName;
        }
    }

    // =========================
    // SIMPLE INPUT DIALOG
    // =========================
    public class SimpleInputDialog : Form
    {
        public string InputText => txtInput.Text;

        private TextBox txtInput;
        private Button btnOK;
        private Button btnCancel;

        public SimpleInputDialog(string title, string prompt)
        {
            InitializeComponents(title, prompt);
        }

        private void InitializeComponents(string title, string prompt)
        {
            this.Text = title;
            this.Size = new Size(400, 180);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var lblPrompt = new Label
            {
                Text = prompt,
                Location = new Point(20, 20),
                Size = new Size(350, 25),
                Font = new Font("Segoe UI", 10F)
            };

            txtInput = new TextBox
            {
                Location = new Point(20, 50),
                Size = new Size(340, 30),
                Font = new Font("Segoe UI", 10F)
            };

            btnOK = new Button
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Location = new Point(180, 90),
                Size = new Size(80, 30),
                Font = new Font("Segoe UI", 9F)
            };

            btnCancel = new Button
            {
                Text = "Cancel",
                DialogResult = DialogResult.Cancel,
                Location = new Point(280, 90),
                Size = new Size(80, 30),
                Font = new Font("Segoe UI", 9F)
            };

            this.Controls.AddRange(new Control[] { lblPrompt, txtInput, btnOK, btnCancel });
            this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;
        }
    }
}