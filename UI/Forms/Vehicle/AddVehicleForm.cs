using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VRMS.Enums;
using VRMS.Models.Fleet;
using VRMS.Repositories.Fleet;
using VRMS.Services.Fleet;
using VRMS.UI.Forms;

namespace VRMS.Forms
{
    public partial class AddVehicleForm : Form
    {
        private readonly VehicleService _vehicleService;

        // =========================
        // SAVE BUTTON COLORS
        // =========================
        private readonly Color _saveEnabledColor =
            Color.FromArgb(46, 204, 113); // green
        private readonly Color _saveDisabledColor =
            Color.FromArgb(189, 195, 199); // gray
        private readonly Color _saveDisabledTextColor =
            Color.FromArgb(120, 120, 120);

        private readonly Color _errorBackColor =
            Color.FromArgb(255, 235, 238);
        private readonly Color _normalBackColor =
            Color.White;

        public AddVehicleForm(VehicleService vehicleService)
        {
            InitializeComponent();
            _vehicleService = vehicleService;

            HookEvents();
            Load += AddVehicleForm_Load;
        }

        // =========================
        // EVENT WIRING
        // =========================
        private void HookEvents()
        {
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (_, __) => Close();
            btnAddImage.Click += BtnSelectImage_Click;
            btnRemoveImage.Click += BtnRemoveImage_Click;
            

            lstImages.SelectedIndexChanged += LstImages_SelectedIndexChanged;

            txtMake.TextChanged += ValidateFormState;
            txtModel.TextChanged += ValidateFormState;
            txtPlate.TextChanged += ValidateFormState;
            txtVIN.TextChanged += ValidateFormState;
            txtColor.TextChanged += ValidateFormState;
            numMileage.ValueChanged += ValidateFormState;
            txtFuelEfficiency.TextChanged += ValidateFormState;
            numCargoCapacity.ValueChanged += ValidateFormState;
            cbCategory.SelectedIndexChanged += ValidateFormState;
            cbTransmission.SelectedIndexChanged += ValidateFormState;
            cbFuel.SelectedIndexChanged += ValidateFormState;
            numSeats.ValueChanged += ValidateFormState;
            numYear.ValueChanged += ValidateFormState;

            // Feature checkboxes
            chkAC.CheckedChanged += ValidateFormState;
            chkGPS.CheckedChanged += ValidateFormState;
            chkBluetooth.CheckedChanged += ValidateFormState;
            chkChildSeat.CheckedChanged += ValidateFormState;
            chkInsuranceIncluded.CheckedChanged += ValidateFormState;
        }

        // =========================
        // FORM LOAD
        // =========================
        private void AddVehicleForm_Load(object? sender, EventArgs e)
        {
            try
            {
                // Configure enum dropdowns
                cbTransmission.DataSource =
                    Enum.GetValues(typeof(TransmissionType));

                cbFuel.DataSource =
                    Enum.GetValues(typeof(FuelType));

                // New vehicles are always Available
                cbStatus.DataSource =
                    new[] { VehicleStatus.Available };
                cbStatus.SelectedItem = VehicleStatus.Available;

                // Set default values
                numYear.Value = DateTime.Now.Year;
                numSeats.Value = 4;
                numMileage.Value = 0;
                numCargoCapacity.Value = 100;
                txtFuelEfficiency.Text = "15.0";

                LoadCategories();
                UpdateSaveButtonState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error loading form: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadCategories()
        {
            try
            {
                var categories = _vehicleService.GetAllCategories();
                cbCategory.DataSource = categories;
                cbCategory.DisplayMember = "Name";
                cbCategory.ValueMember = "Id";

                if (categories.Count > 0)
                    cbCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error loading categories: {ex.Message}",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // =========================
        // SAVE VEHICLE
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

            try
            {
                decimal fuelEfficiency =
                    decimal.Parse(txtFuelEfficiency.Text);

                var vehicle = new Vehicle
                {
                    VehicleCode =
                        $"VEH-{DateTime.UtcNow:yyyyMMddHHmmss}",
                    Make = txtMake.Text.Trim(),
                    Model = txtModel.Text.Trim(),
                    Year = (int)numYear.Value,
                    Color = txtColor.Text.Trim(),
                    LicensePlate = txtPlate.Text.Trim().ToUpper(),
                    VIN = txtVIN.Text.Trim().ToUpper(),

                    Transmission =
                        (TransmissionType)cbTransmission.SelectedItem!,
                    FuelType =
                        (FuelType)cbFuel.SelectedItem!,
                    SeatingCapacity = (int)numSeats.Value,
                    Odometer = (int)numMileage.Value,

                    FuelEfficiency = fuelEfficiency,
                    CargoCapacity = (int)numCargoCapacity.Value,
                    VehicleCategoryId =
                        (int)cbCategory.SelectedValue
                };

                // -------------------------
                // CREATE VEHICLE
                // -------------------------
                int vehicleId =
                    _vehicleService.CreateVehicle(vehicle);

                // -------------------------
                // SAVE IMAGES
                // -------------------------
                foreach (string path in lstImages.Items)
                {
                    if (File.Exists(path))
                    {
                        using var stream = File.OpenRead(path);
                        _vehicleService.AddVehicleImage(
                            vehicleId,
                            stream,
                            Path.GetFileName(path));
                    }
                }

                // -------------------------
                // SAVE FEATURES
                // -------------------------
                var allFeatures = _vehicleService.GetAllFeatures();

                // Create a helper function to add features
                void AddFeatureIfChecked(CheckBox checkBox, string featureName)
                {
                    if (checkBox.Checked)
                    {
                        // Try exact match first
                        var feature = allFeatures.FirstOrDefault(f =>
                            f.Name.Equals(featureName, StringComparison.OrdinalIgnoreCase));

                        // If not found, try partial match
                        if (feature == null)
                        {
                            feature = allFeatures.FirstOrDefault(f =>
                                f.Name.Contains(featureName, StringComparison.OrdinalIgnoreCase));
                        }

                        if (feature != null)
                        {
                            _vehicleService.AddFeatureToVehicle(vehicleId, feature.Id);
                        }
                        else
                        {
                            Console.WriteLine($"Warning: Feature '{featureName}' not found in system");
                        }
                    }
                }

                // Add features based on checkboxes
                AddFeatureIfChecked(chkAC, "Air Conditioning");
                AddFeatureIfChecked(chkGPS, "GPS Navigation");
                AddFeatureIfChecked(chkBluetooth, "Bluetooth"); // Fixed: matches your database
                AddFeatureIfChecked(chkChildSeat, "Child Seat Availability");
                AddFeatureIfChecked(chkInsuranceIncluded, "Insurance Coverage Included");

                // Show success message
                MessageBox.Show(
                    "Vehicle added successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error adding vehicle: {ex.Message}",
                    "Add Vehicle Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // VALIDATION
        // =========================
        private System.Collections.Generic.List<(Control control, string label, string message)>
            ValidateFormDetailed()
        {
            var errors =
                new System.Collections.Generic.List<(Control, string, string)>();

            // Required fields
            if (string.IsNullOrWhiteSpace(txtMake.Text))
                errors.Add((txtMake, "Make", "Required"));

            if (string.IsNullOrWhiteSpace(txtModel.Text))
                errors.Add((txtModel, "Model", "Required"));

            if (string.IsNullOrWhiteSpace(txtPlate.Text))
                errors.Add((txtPlate, "License Plate", "Required"));

            if (string.IsNullOrWhiteSpace(txtVIN.Text))
                errors.Add((txtVIN, "VIN", "Required"));

            if (string.IsNullOrWhiteSpace(txtColor.Text))
                errors.Add((txtColor, "Color", "Required"));

            // Field-specific validation
            if (txtVIN.Text.Trim().Length < 8)
                errors.Add((txtVIN, "VIN", "Must be at least 8 characters"));

            if (numMileage.Value < 0)
                errors.Add((numMileage, "Mileage", "Cannot be negative"));

            if (!decimal.TryParse(txtFuelEfficiency.Text, out var eff) || eff <= 0)
                errors.Add((txtFuelEfficiency, "Fuel Efficiency", "Must be > 0 (km/L)"));

            if (numCargoCapacity.Value <= 0)
                errors.Add((numCargoCapacity, "Cargo Capacity", "Must be > 0"));

            if (numSeats.Value < 2)
                errors.Add((numSeats, "Seats", "Must be ≥ 2"));

            if (numYear.Value < 1990 || numYear.Value > DateTime.Now.Year + 1)
                errors.Add((numYear, "Year", $"Must be between 1990 and {DateTime.Now.Year + 1}"));

            if (cbCategory.SelectedItem == null)
                errors.Add((cbCategory, "Category", "Required"));

            return errors;
        }

        private void ShowValidationErrors(
            System.Collections.Generic.List<(Control control, string label, string message)> errors)
        {
            foreach (var e in errors)
                e.control.BackColor = _errorBackColor;

            if (errors.Count > 0)
                errors[0].control.Focus();

            MessageBox.Show(
                "Please fix the following errors:\n\n" +
                string.Join("\n",
                    errors.Select(e =>
                        $"• {e.label}: {e.message}")),
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private void ResetErrorStyles()
        {
            txtMake.BackColor = _normalBackColor;
            txtModel.BackColor = _normalBackColor;
            txtPlate.BackColor = _normalBackColor;
            txtVIN.BackColor = _normalBackColor;
            txtColor.BackColor = _normalBackColor;
            numMileage.BackColor = _normalBackColor;
            txtFuelEfficiency.BackColor = _normalBackColor;
            numCargoCapacity.BackColor = _normalBackColor;
            numSeats.BackColor = _normalBackColor;
            numYear.BackColor = _normalBackColor;
            cbCategory.BackColor = _normalBackColor;
        }

        private void ValidateFormState(object? sender, EventArgs e)
        {
            UpdateSaveButtonState();
        }

        private void UpdateSaveButtonState()
        {
            bool isValid =
                !string.IsNullOrWhiteSpace(txtMake.Text) &&
                !string.IsNullOrWhiteSpace(txtModel.Text) &&
                !string.IsNullOrWhiteSpace(txtPlate.Text) &&
                !string.IsNullOrWhiteSpace(txtVIN.Text) &&
                !string.IsNullOrWhiteSpace(txtColor.Text) &&
                !string.IsNullOrWhiteSpace(txtFuelEfficiency.Text) &&
                cbCategory.SelectedItem != null &&
                decimal.TryParse(txtFuelEfficiency.Text, out var eff) && eff > 0 &&
                numMileage.Value >= 0 &&
                numCargoCapacity.Value > 0 &&
                numSeats.Value >= 2 &&
                numYear.Value >= 1990 && numYear.Value <= DateTime.Now.Year + 1;

            btnSave.Enabled = isValid;

            if (isValid)
            {
                btnSave.BackColor = _saveEnabledColor;
                btnSave.ForeColor = Color.White;
                btnSave.Cursor = Cursors.Hand;
            }
            else
            {
                btnSave.BackColor = _saveDisabledColor;
                btnSave.ForeColor = _saveDisabledTextColor;
                btnSave.Cursor = Cursors.Default;
            }
        }

        // =========================
        // IMAGE HANDLING
        // =========================
        private void BtnSelectImage_Click(object? sender, EventArgs e)
        {
            using OpenFileDialog dlg = new()
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Select Vehicle Images",
                Multiselect = true,
                CheckFileExists = true
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in dlg.FileNames)
                {
                    if (!lstImages.Items.Contains(file) && File.Exists(file))
                    {
                        lstImages.Items.Add(file);
                    }
                }

                // Update image preview
                if (lstImages.Items.Count > 0)
                    lstImages.SelectedIndex = 0;
            }
        }

        private void LstImages_SelectedIndexChanged(
            object? sender, EventArgs e)
        {
            if (lstImages.SelectedItem is string path &&
                File.Exists(path))
            {
                try
                {
                    // Load image without locking the file
                    using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        picVehicleImage.Image = Image.FromStream(stream);
                    }
                }
                catch
                {
                    picVehicleImage.Image = null;
                }
            }
            else
            {
                picVehicleImage.Image = null;
            }
        }

        private void BtnRemoveImage_Click(
            object? sender, EventArgs e)
        {
            if (lstImages.SelectedItem == null)
                return;

            int index = lstImages.SelectedIndex;
            lstImages.Items.RemoveAt(index);

            // Update preview
            if (lstImages.Items.Count > 0)
            {
                int newIndex = Math.Min(index, lstImages.Items.Count - 1);
                lstImages.SelectedIndex = newIndex;
            }
            else
            {
                picVehicleImage.Image = null;
            }
        }

        // =========================
        // ADD CATEGORY
        // =========================
        private void BtnAddCategory_Click(
            object? sender, EventArgs e)
        {
            using var form =
                new AddCategoryForm(_vehicleService)
                {
                    StartPosition =
                        FormStartPosition.CenterParent
                };

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadCategories();
                MessageBox.Show(
                    "Category added successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}