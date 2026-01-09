using System;
using System.Windows.Forms;
using VRMS.Models.Fleet;
using VRMS.Enums;
using VRMS.Services.Vehicle;

namespace VRMS.Forms
{
    public partial class EditVehicleForm : Form
    {
        private readonly int _vehicleId;
        private readonly VehicleService _vehicleService = new();
        private Vehicle _vehicle = null!;

        // =========================
        // CONSTRUCTOR
        // =========================

        public EditVehicleForm(int vehicleId)
        {
            InitializeComponent();
            _vehicleId = vehicleId;

            Load += EditVehicleForm_Load;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (_, __) => Close();
        }

        // =========================
        // LOAD VEHICLE
        // =========================

        private void EditVehicleForm_Load(object sender, EventArgs e)
        {
            try
            {
                _vehicle = _vehicleService.GetVehicleFull(_vehicleId);
                PopulateForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                Close();
            }
        }

        private void PopulateForm()
        {
            // Identity (read-only)
            txtMake.Text = _vehicle.Make;
            txtModel.Text = _vehicle.Model;
            numYear.Value = _vehicle.Year;
            txtPlate.Text = _vehicle.LicensePlate;
            txtVIN.Text = _vehicle.VIN;

            // Editable
            txtColor.Text = _vehicle.Color;
            numMileage.Value = _vehicle.Odometer;

            // Enums
            cbTransmission.DataSource = Enum.GetValues(typeof(TransmissionType));
            cbFuel.DataSource = Enum.GetValues(typeof(FuelType));
            cbStatus.DataSource = Enum.GetValues(typeof(VehicleStatus));

            cbTransmission.SelectedItem = _vehicle.Transmission;
            cbFuel.SelectedItem = _vehicle.FuelType;
            cbStatus.SelectedItem = _vehicle.Status;

            numSeats.Value = _vehicle.SeatingCapacity;

            // 🔒 Lock immutable fields
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
        // SAVE CHANGES
        // =========================

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                ValidateForm();

                _vehicleService.UpdateVehicle(
                    vehicleId: _vehicleId,
                    color: txtColor.Text.Trim(),
                    newOdometer: (int)numMileage.Value,
                    categoryId: _vehicle.VehicleCategoryId
                );

                var newStatus = (VehicleStatus)cbStatus.SelectedItem!;
                if (newStatus != _vehicle.Status)
                {
                    _vehicleService.UpdateVehicleStatus(_vehicleId, newStatus);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Save Failed",
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
            if (string.IsNullOrWhiteSpace(txtColor.Text))
                throw new InvalidOperationException("Color is required.");

            if (numMileage.Value < _vehicle.Odometer)
                throw new InvalidOperationException(
                    "Odometer value cannot be less than the current reading."
                );
        }
    }
}
