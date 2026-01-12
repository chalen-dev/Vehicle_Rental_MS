using VRMS.Enums;
using VRMS.Forms.Payments;
using VRMS.Models.Fleet;
using VRMS.Services.Billing;
using VRMS.Services.Customer;
using VRMS.Services.Fleet;
using VRMS.Services.Rental;

namespace VRMS.UI.Forms.Rentals
{
    public partial class NewRentalForm : Form
    {
        private bool _isLoaded = false;
        private decimal _lastCalculatedTotal = 0m;
        private Models.Customers.Customer _selectedCustomer = null;
        private Vehicle _selectedVehicle = null;

        private readonly CustomerService _customerService;
        private readonly VehicleService _vehicleService;
        private readonly ReservationService _reservationService;
        private readonly RentalService _rentalService;
        private readonly RateService _rateService;

        public NewRentalForm(
            CustomerService customerService,
            VehicleService vehicleService,
            ReservationService reservationService,
            RentalService rentalService,
            RateService rateService)
        {
            InitializeComponent();

            _customerService = customerService;
            _vehicleService = vehicleService;
            _reservationService = reservationService;
            _rentalService = rentalService;
            _rateService = rateService;

            // Date changes
            dtPickup.ValueChanged += (_, __) => RecalculateTotal();
            dtReturn.ValueChanged += (_, __) => RecalculateTotal();

            // Form lifecycle
            Load += NewRentalForm_Load;
            btnCancel.Click += (_, __) => Close();

            // 🚫 DO NOT manually wire buttons here
            // Designer already wires:
            // btnSelectCustomer_Click
            // btnClearCustomer_Click
            // btnSelectVehicle_Click
            // btnClearVehicle_Click
            // btnSave_Click
        }

        // -------------------------------
        // LOAD
        // -------------------------------
        private void NewRentalForm_Load(object? sender, EventArgs e)
        {
            LoadFuelLevels();
            UpdateSaveButtonState();
            _isLoaded = true;

            dtPickup.Value = DateTime.Today;
            dtReturn.Value = DateTime.Today.AddDays(1);
        }

        private void LoadFuelLevels()
        {
            cbFuel.DataSource =
                Enum.GetValues(typeof(FuelLevel))
                    .Cast<FuelLevel>()
                    .Select(f => new
                    {
                        Value = f,
                        Text = VRMS.Helpers.FuelLevelHelper.ToDisplay(f)
                    })
                    .ToList();

            cbFuel.DisplayMember = "Text";
            cbFuel.ValueMember = "Value";
            cbFuel.SelectedValue = FuelLevel.Full;
        }

        // -------------------------------
        // CUSTOMER
        // -------------------------------
        private void btnSelectCustomer_Click(object sender, EventArgs e)
        {
            using var form = new SelectCustomerForm(_customerService);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _selectedCustomer = form.SelectedCustomer;
                UpdateCustomerDisplay();
            }
        }

        private void btnClearCustomer_Click(object sender, EventArgs e)
        {
            _selectedCustomer = null;
            UpdateCustomerDisplay();
            RecalculateTotal();
        }

        private void UpdateCustomerDisplay()
        {
            if (_selectedCustomer != null)
            {
                lblSelectedCustomer.Text =
                    $"{_selectedCustomer.FirstName} {_selectedCustomer.LastName}";
                lblSelectedCustomer.ForeColor = Color.FromArgb(44, 62, 80);
                btnClearCustomer.Visible = true;
            }
            else
            {
                lblSelectedCustomer.Text = "Not selected...";
                lblSelectedCustomer.ForeColor = Color.Gray;
                btnClearCustomer.Visible = false;
            }

            UpdateSaveButtonState();
        }

        // -------------------------------
        // VEHICLE
        // -------------------------------
        private void btnSelectVehicle_Click(object sender, EventArgs e)
        {
            using var form = new SelectVehicleForm(_vehicleService);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _selectedVehicle = form.SelectedVehicle;
                UpdateVehicleDisplay();
            }
        }

        private void btnClearVehicle_Click(object sender, EventArgs e)
        {
            _selectedVehicle = null;
            UpdateVehicleDisplay();
            RecalculateTotal();
        }

        private void UpdateVehicleDisplay()
        {
            if (_selectedVehicle != null)
            {
                lblSelectedVehicle.Text =
                    $"{_selectedVehicle.Make} {_selectedVehicle.Model} ({_selectedVehicle.LicensePlate})";
                lblSelectedVehicle.ForeColor = Color.FromArgb(44, 62, 80);
                btnClearVehicle.Visible = true;

                txtOdometer.Text = _selectedVehicle.Odometer.ToString();
                txtOdometer.ReadOnly = true;
            }
            else
            {
                lblSelectedVehicle.Text = "Not selected...";
                lblSelectedVehicle.ForeColor = Color.Gray;
                btnClearVehicle.Visible = false;

                txtOdometer.Text = string.Empty;
                txtOdometer.ReadOnly = true;
            }

            UpdateSaveButtonState();
            RecalculateTotal();
        }

        // -------------------------------
        // TOTAL
        // -------------------------------
        private void RecalculateTotal()
        {
            if (!_isLoaded || _selectedVehicle == null ||
                dtReturn.Value <= dtPickup.Value)
            {
                lblTotal.Text = "Total: ₱0.00";
                _lastCalculatedTotal = 0m;
                return;
            }

            try
            {
                decimal baseRental =
                    _rateService.CalculateRentalCost(
                        dtPickup.Value,
                        dtReturn.Value,
                        _selectedVehicle.VehicleCategoryId);

                var category =
                    _vehicleService.GetCategoryById(
                        _selectedVehicle.VehicleCategoryId);

                _lastCalculatedTotal =
                    baseRental + (category?.SecurityDeposit ?? 0m);

                lblTotal.Text = $"Total: ₱{_lastCalculatedTotal:N2}";
            }
            catch
            {
                lblTotal.Text = "Total: ₱0.00";
                _lastCalculatedTotal = 0m;
            }
        }

        // -------------------------------
        // SAVE
        // -------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedCustomer == null)
                    throw new InvalidOperationException("Please select a customer.");

                if (_selectedVehicle == null)
                    throw new InvalidOperationException("Please select a vehicle.");

                if (!int.TryParse(txtOdometer.Text, out int odometer))
                    throw new InvalidOperationException("Invalid odometer value.");

                if (odometer < _selectedVehicle.Odometer)
                    throw new InvalidOperationException(
                        $"Odometer cannot be less than {_selectedVehicle.Odometer}");

                using var paymentForm =
                    new RentalDownPayment(
                        $"{_selectedCustomer.FirstName} {_selectedCustomer.LastName}",
                        $"{_selectedVehicle.Make} {_selectedVehicle.Model}",
                        _lastCalculatedTotal);

                if (paymentForm.ShowDialog() != DialogResult.OK)
                    return;

                int reservationId =
                    _reservationService.CreateReservation(
                        _selectedCustomer.Id,
                        _selectedVehicle.Id,
                        dtPickup.Value.Date,
                        dtReturn.Value.Date);

                _reservationService.ConfirmReservation(reservationId);

                _rentalService.StartRental(
                    reservationId,
                    dtPickup.Value,
                    (FuelLevel)cbFuel.SelectedValue);

                MessageBox.Show("Rental successfully created.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Cannot Proceed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void UpdateSaveButtonState()
        {
            btnSave.Enabled =
                _selectedCustomer != null &&
                _selectedVehicle != null;
        }
    }
}
