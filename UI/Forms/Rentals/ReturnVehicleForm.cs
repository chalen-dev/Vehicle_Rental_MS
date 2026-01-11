using System;
using System.Windows.Forms;
using VRMS.Enums;
using VRMS.Models.Rentals;
using VRMS.Services.Customer;
using VRMS.Services.Fleet;
using VRMS.Services.Rental;

namespace VRMS.Forms
{
    public partial class ReturnVehicleForm : Form
    {
        private readonly int _rentalId;
        private readonly RentalService _rentalService;
        private readonly ReservationService _reservationService;
        private readonly VehicleService _vehicleService;
        private readonly CustomerService _customerService;
        private Rental _rental = null!;

        public ReturnVehicleForm(
            int rentalId,
            RentalService rentalService,
            ReservationService reservationService,
            VehicleService vehicleService,
            CustomerService customerService)
        {
            InitializeComponent();

            _rentalId = rentalId;
            _rentalService = rentalService;
            _reservationService = reservationService;
            _vehicleService = vehicleService;
            _customerService = customerService;

            Load += ReturnVehicleForm_Load;

            btnConfirms.Click += btnConfirm_Click;
            btnCancels.Click += btnCancel_Click;
            btnAddDamage.Click += BtnAddDamage_Click;
        }

        
        private void ReturnVehicleForm_Load(object? sender, EventArgs e)
        {
            _rental = _rentalService.GetRentalById(_rentalId);

            var reservation =
                _reservationService.GetReservationById(_rental.ReservationId);

            var vehicle =
                _vehicleService.GetVehicleById(reservation.VehicleId);

            var customer =
                _customerService.GetCustomerById(reservation.CustomerId);

            lblRentalId.Text = $"Rental #: {_rental.Id}";
            lblVehicleInfo.Text =
                $"Vehicle: {vehicle.Year} {vehicle.Make} {vehicle.Model}";
            lblCustomerInfo.Text =
                $"Customer: {customer.FirstName} {customer.LastName}";

            dtReturns.Value = DateTime.Now;
            txtOdometers.Text = _rental.StartOdometer.ToString();
            cbFuels.SelectedIndex = (int)_rental.StartFuelLevel;

            numLateFee.Value = 0;
            numDamages.Value = 0;
            lblTotalValue.Text = "₱ 0.00";

            ConfigureDamageGrid();
        }

        
        private void ConfigureDamageGrid()
        {
            dgvDamages.AutoGenerateColumns = false;
            dgvDamages.Columns.Clear();

            dgvDamages.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Description",
                DataPropertyName = "Description"
            });

            dgvDamages.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Estimated Cost",
                DataPropertyName = "EstimatedCost",
                DefaultCellStyle = { Format = "₱ #,##0.00" }
            });
        }

        private bool ValidateInput(out int endOdometer, out FuelLevel fuelLevel)
        {
            endOdometer = 0;
            fuelLevel = FuelLevel.Empty;

            if (!int.TryParse(txtOdometers.Text, out endOdometer))
            {
                MessageBox.Show("Invalid odometer value.", "Validation Error");
                return false;
            }

            if (endOdometer <= _rental.StartOdometer)
            {
                MessageBox.Show(
                    "End odometer must be greater than start odometer.",
                    "Validation Error");
                return false;
            }

            if (cbFuels.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Please select fuel level.",
                    "Validation Error");
                return false;
            }

            fuelLevel = (FuelLevel)cbFuels.SelectedIndex;
            return true;
        }
        
        private void btnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void BtnAddDamage_Click(object? sender, EventArgs e)
        {
            MessageBox.Show(
                "Damage entry will be implemented next.",
                "Not Implemented",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        
        private void btnConfirm_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput(out var endOdometer, out var fuelLevel))
                return;

            try
            {
                _rentalService.CompleteRental(
                    rentalId: _rentalId,
                    actualReturnDate: dtReturns.Value,
                    endOdometer: endOdometer,
                    endFuelLevel: fuelLevel
                );

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Return Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

    }
}