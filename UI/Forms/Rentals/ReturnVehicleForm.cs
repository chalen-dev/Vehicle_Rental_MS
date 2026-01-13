using System;
using System.Windows.Forms;
using VRMS.Enums;
using VRMS.Models.Billing;
using VRMS.Models.Customers;
using VRMS.Models.Rentals;
using VRMS.Services.Billing;
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
        private readonly BillingService _billingService;
        private Invoice _invoice = null!;

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
            numOdometer.ValueChanged += NumOdometer_ValueChanged;
        }

        private void ReturnVehicleForm_Load(object? sender, EventArgs e)
        {
            _rental = _rentalService.GetRentalById(_rentalId);

            var vehicle = _vehicleService.GetVehicleById(_rental.VehicleId);
            Customer? customer = null;

            if (_rental.ReservationId.HasValue)
            {
                var reservation =
                    _reservationService.GetReservationById(_rental.ReservationId.Value);

                customer =
                    _customerService.GetCustomerById(reservation.CustomerId);
            }

            lblRentalId.Text = $"Rental #: {_rental.Id}";
            lblVehicleInfo.Text = $"Vehicle: {vehicle.Year} {vehicle.Make} {vehicle.Model}";
            lblCustomerInfo.Text =
                customer == null
                    ? "Customer: Walk-in"
                    : $"Customer: {customer.FirstName} {customer.LastName}";

            dtReturns.Value = DateTime.Now;

            
            numOdometer.Minimum = _rental.StartOdometer + 1;
            numOdometer.Maximum = 10_000_000;
            numOdometer.Value = _rental.StartOdometer + 1;
            numOdometer.Increment = 1;

            cbFuels.SelectedIndex = (int)_rental.StartFuelLevel;

            numLateFee.Value = 0;
            numDamages.Value = 0;
            lblTotalValue.Text = "₱ 0.00";

            ConfigureDamageGrid();
        }

        private void NumOdometer_ValueChanged(object? sender, EventArgs e)
        {
            if (_rental == null) return;

            var minAllowed = _rental.StartOdometer + 1;
            if (numOdometer.Value < minAllowed)
            {
                numOdometer.Value = minAllowed;
            }
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
            endOdometer = (int)numOdometer.Value;
            fuelLevel = FuelLevel.Empty;

            if (endOdometer <= _rental.StartOdometer)
            {
                MessageBox.Show(
                    "End odometer must be greater than the starting odometer.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (cbFuels.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Please select fuel level.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            fuelLevel = (FuelLevel)cbFuels.SelectedIndex;
            return true;
        }

        private void btnCompleteReturn_Click(object sender, EventArgs e)
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

                // 🔽 NEW: open payment settlement
                using (var paymentForm = new PaymentForm(_rentalId))
                {
                    var result = paymentForm.ShowDialog(this);

                    if (result != DialogResult.OK)
                        return;
                }

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
    }
}
