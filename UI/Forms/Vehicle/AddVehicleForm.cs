using System;
using System.Windows.Forms;
using VRMS.Models.Fleet;
using VRMS.Enums;
using VRMS.Services.Vehicle;
using VRMS.UI.Forms;

namespace VRMS.Forms
{
    public partial class AddVehicleForm : Form
    {
        private readonly VehicleService _vehicleService = new();

        public AddVehicleForm()
        {
            InitializeComponent();

            Load += AddVehicleForm_Load;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (_, __) => Close();
            btnAddImage.Click += BtnSelectImage_Click;
            btnAddCategory.Click += BtnAddCategory_Click;
        }

        // =========================
        // FORM LOAD
        // =========================

        private void AddVehicleForm_Load(object sender, EventArgs e)
        {
            cbTransmission.DataSource = Enum.GetValues(typeof(TransmissionType));
            cbFuel.DataSource = Enum.GetValues(typeof(FuelType));

            cbStatus.DataSource = new[] { VehicleStatus.Available };
            cbStatus.SelectedItem = VehicleStatus.Available;

            LoadCategories();
        }

        private void LoadCategories()
        {
            cbCategory.DataSource = null;
            cbCategory.DataSource = _vehicleService.GetAllCategories();
            cbCategory.DisplayMember = "Name";
            cbCategory.ValueMember = "Id";
        }

        // =========================
        // SAVE VEHICLE
        // =========================

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                ValidateForm();

                var vehicle = new Vehicle
                {
                    // ✅ REQUIRED
                    VehicleCode = $"VEH-{DateTime.UtcNow:yyyyMMddHHmmss}",

                    Make = txtMake.Text.Trim(),
                    Model = txtModel.Text.Trim(),
                    Year = (int)numYear.Value,
                    Color = txtColor.Text.Trim(),
                    LicensePlate = txtPlate.Text.Trim(),
                    VIN = txtVIN.Text.Trim(),

                    Transmission = (TransmissionType)cbTransmission.SelectedItem!,
                    FuelType = (FuelType)cbFuel.SelectedItem!,
                    SeatingCapacity = (int)numSeats.Value,
                    Odometer = (int)numMileage.Value,

                    VehicleCategoryId = (int)cbCategory.SelectedValue
                };

                int vehicleId = _vehicleService.CreateVehicle(vehicle);

                // Optional images
                foreach (var item in lstImages.Items)
                {
                    _vehicleService.AddVehicleImage(vehicleId, item.ToString()!);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Add Vehicle Failed",
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
            if (string.IsNullOrWhiteSpace(txtMake.Text))
                throw new InvalidOperationException("Make is required.");

            if (string.IsNullOrWhiteSpace(txtModel.Text))
                throw new InvalidOperationException("Model is required.");

            if (string.IsNullOrWhiteSpace(txtPlate.Text))
                throw new InvalidOperationException("License Plate is required.");

            if (string.IsNullOrWhiteSpace(txtVIN.Text))
                throw new InvalidOperationException("VIN is required.");

            if (txtVIN.Text.Length < 8)
                throw new InvalidOperationException("VIN is too short.");

            if (numMileage.Value < 0)
                throw new InvalidOperationException("Mileage cannot be negative.");

            if (cbCategory.SelectedItem == null)
                throw new InvalidOperationException("Category is required.");
        }

        // =========================
        // IMAGE HANDLING
        // =========================

        private void BtnSelectImage_Click(object? sender, EventArgs e)
        {
            using OpenFileDialog dlg = new()
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png",
                Title = "Select Vehicle Image"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                picVehicleImage.ImageLocation = dlg.FileName;
                lstImages.Items.Add(dlg.FileName);
            }
        }

        // =========================
        // ADD CATEGORY
        // =========================

        private void BtnAddCategory_Click(object? sender, EventArgs e)
        {
            using var form = new AddCategoryForm(_vehicleService)
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadCategories();
            }
        }
    }
}
