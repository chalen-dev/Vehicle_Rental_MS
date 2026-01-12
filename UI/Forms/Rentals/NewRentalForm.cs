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

            dtPickup.ValueChanged += (_, __) => RecalculateTotal();
            dtReturn.ValueChanged += (_, __) => RecalculateTotal();

            Load += NewRentalForm_Load;
            btnCancel.Click += (_, __) => Close();
        }

        // -------------------------------
        // LOAD DATA
        // -------------------------------
        private void NewRentalForm_Load(object? sender, EventArgs e)
        {
            LoadFuelLevels();
            UpdateSaveButtonState();
            _isLoaded = true;
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
        // CUSTOMER SELECTION
        // -------------------------------
        private void btnSelectCustomer_Click(object sender, EventArgs e)
        {
            // TODO: Implement customer selection dialog
            // For now, we'll use a mock example

            // Example: Show a dialog to select customer
            // using var customerSelectForm = new CustomerSelectionForm(_customerService);
            // if (customerSelectForm.ShowDialog() == DialogResult.OK)
            // {
            //     _selectedCustomer = customerSelectForm.SelectedCustomer;
            //     UpdateCustomerDisplay();
            // }

            // Mock implementation - replace with actual dialog
            var customers = _customerService.GetAllCustomers();
            if (customers.Count > 0)
            {
                _selectedCustomer = customers[0]; // Select first customer for demo
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
                lblSelectedCustomer.Text = $"{_selectedCustomer.FullName}";
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
        // VEHICLE SELECTION
        // -------------------------------
        private void btnSelectVehicle_Click(object sender, EventArgs e)
        {
            // TODO: Implement vehicle selection dialog
            // For now, we'll use a mock example

            // Example: Show a dialog to select available vehicle
            // var availableVehicles = _vehicleService.GetAllVehicles()
            //     .FindAll(v => v.Status == VehicleStatus.Available);
            // using var vehicleSelectForm = new VehicleSelectionForm(availableVehicles);
            // if (vehicleSelectForm.ShowDialog() == DialogResult.OK)
            // {
            //     _selectedVehicle = vehicleSelectForm.SelectedVehicle;
            //     UpdateVehicleDisplay();
            // }

            // Mock implementation - replace with actual dialog
            var vehicles = _vehicleService.GetAllVehicles()
                .FindAll(v => v.Status == VehicleStatus.Available);
            if (vehicles.Count > 0)
            {
                _selectedVehicle = vehicles[0]; // Select first vehicle for demo
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
                lblSelectedVehicle.Text = $"{_selectedVehicle.Make} {_selectedVehicle.Model} ({_selectedVehicle.LicensePlate})";
                lblSelectedVehicle.ForeColor = Color.FromArgb(44, 62, 80);
                btnClearVehicle.Visible = true;

                // Update odometer
                txtOdometer.Text = _selectedVehicle.Odometer.ToString();
            }
            else
            {
                lblSelectedVehicle.Text = "Not selected...";
                lblSelectedVehicle.ForeColor = Color.Gray;
                btnClearVehicle.Visible = false;

                // Clear odometer
                txtOdometer.Text = string.Empty;
            }

            UpdateSaveButtonState();
            RecalculateTotal();
        }

        // -------------------------------
        // TOTAL CALCULATION
        // -------------------------------
        private void RecalculateTotal()
        {
            if (!_isLoaded)
                return;

            if (_selectedVehicle == null)
            {
                lblTotal.Text = "Total: ₱0.00";
                _lastCalculatedTotal = 0m;
                return;
            }

            if (dtReturn.Value <= dtPickup.Value)
            {
                lblTotal.Text = "Total: ₱0.00";
                _lastCalculatedTotal = 0m;
                return;
            }

            decimal baseRental =
                _rateService.CalculateRentalCost(
                    dtPickup.Value,
                    dtReturn.Value,
                    _selectedVehicle.VehicleCategoryId);

            var category =
                _vehicleService.GetCategoryById(
                    _selectedVehicle.VehicleCategoryId);

            decimal totalDueToday =
                baseRental + (category?.SecurityDeposit ?? 0m);

            _lastCalculatedTotal = totalDueToday;

            lblTotal.Text =
                $"Total: ₱{totalDueToday:N2}";
        }

        // -------------------------------
        // SAVE / NEXT STEP
        // -------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedCustomer == null)
                    throw new InvalidOperationException(
                        "Please select a customer.");

                if (_selectedVehicle == null)
                    throw new InvalidOperationException(
                        "Please select a vehicle.");

                if (!int.TryParse(txtOdometer.Text, out int odometer))
                    throw new InvalidOperationException(
                        "Invalid odometer value.");

                if (dtReturn.Value.Date <= dtPickup.Value.Date)
                    throw new InvalidOperationException(
                        "Return date must be after pickup date.");

                // UI-friendly strings
                string customerName =
                    $"{_selectedCustomer.FirstName} {_selectedCustomer.LastName}";

                string vehicleName =
                    $"{_selectedVehicle.Make} {_selectedVehicle.Model} ({_selectedVehicle.LicensePlate})";

                decimal estimatedTotal = _lastCalculatedTotal;

                using var paymentForm =
                    new RentalDownPayment(
                        customerName,
                        vehicleName,
                        estimatedTotal);

                if (paymentForm.ShowDialog() == DialogResult.OK)
                {
                    // Create reservation (Pending)
                    int reservationId =
                        _reservationService.CreateReservation(
                            _selectedCustomer.Id,
                            _selectedVehicle.Id,
                            dtPickup.Value.Date,
                            dtReturn.Value.Date
                        );

                    // Confirm reservation
                    _reservationService.ConfirmReservation(reservationId);

                    // Get selected fuel level
                    FuelLevel startFuelLevel =
                        (FuelLevel)cbFuel.SelectedValue;

                    // Start rental
                    int rentalId =
                        _rentalService.StartRental(
                            reservationId,
                            dtPickup.Value,
                            startFuelLevel
                        );

                    MessageBox.Show(
                        "Rental successfully created.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Cannot Proceed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // -------------------------------
        // HELPER METHODS
        // -------------------------------
        private void UpdateSaveButtonState()
        {
            btnSave.Enabled = (_selectedCustomer != null && _selectedVehicle != null);
        }
    }
}