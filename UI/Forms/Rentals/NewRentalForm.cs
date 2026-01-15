using VRMS.Enums;
using VRMS.Models.Fleet;
using VRMS.Services.Billing;
using VRMS.Services.Customer;
using VRMS.Services.Fleet;
using VRMS.Services.Rental;
using VRMS.UI.Forms.Payments;
using VRMS.UI.Forms.Select;

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
        private readonly RentalService _rentalService;
        private readonly RateService _rateService;
        private readonly BillingService _billingService;

        public NewRentalForm(
            CustomerService customerService,
            VehicleService vehicleService,
            RentalService rentalService,
            BillingService billingService,
            RateService rateService)

        {
            InitializeComponent();

            _customerService = customerService;
            _vehicleService = vehicleService;
            _rentalService = rentalService;
            _billingService = billingService;
            _rateService = rateService;

            // Date changes
            dtPickup.ValueChanged += (_, __) =>
            {
                dtReturn.MinDate = dtPickup.Value;

                if (dtReturn.Value < dtReturn.MinDate)
                    dtReturn.Value = dtReturn.MinDate;

                RecalculateTotal();
                UpdateSaveButtonState();
            };


            dtReturn.ValueChanged += (_, __) =>
            {
                RecalculateTotal();
                UpdateSaveButtonState();
            };



            // Form lifecycle
            Load += NewRentalForm_Load;
            btnCancel.Click += (_, __) => Close();
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
            errLabel.Text = string.Empty;
            errLabel.Visible = false;
            
            StyleCancelButton();
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
            errLabel.Visible = false;
            errLabel.Text = string.Empty;
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
                // ---------------- VALIDATION ---------------- 

                if (_selectedCustomer == null)
                    throw new InvalidOperationException("Please select a customer.");

                if (_selectedVehicle == null)
                    throw new InvalidOperationException("Please select a vehicle.");

                if (!int.TryParse(txtOdometer.Text, out int odometer))
                    throw new InvalidOperationException("Invalid odometer value.");

                if (odometer < _selectedVehicle.Odometer)
                    throw new InvalidOperationException(
                        $"Odometer cannot be less than {_selectedVehicle.Odometer}");
                
                // ---------- CHECK FOR MAINTENANCE CONFLICT (fast fail, before accepting payment) ----------
                if (_vehicleService.HasOverlappingMaintenance(_selectedVehicle.Id, dtPickup.Value.Date, dtReturn.Value.Date))
                {
                    MessageBox.Show(
                        "This vehicle has scheduled or in-progress maintenance that overlaps your requested rental period. Please choose another vehicle or adjust dates.",
                        "Maintenance Conflict",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // ---------------- PRICING ONLY (NO DB) ----------------

                decimal baseRental =
                    _rateService.CalculateRentalCost(
                        dtPickup.Value,
                        dtReturn.Value,
                        _selectedVehicle.VehicleCategoryId);

                var category =
                    _vehicleService.GetCategoryById(
                        _selectedVehicle.VehicleCategoryId);

                decimal securityDeposit =
                    category?.SecurityDeposit ?? 0m;
                
                // ---------- CHECK FOR RENTAL DATE OVERLAP ----------
                var overlappingRentals =
                    _vehicleService.GetOverlappingRentalsForVehicle(
                        _selectedVehicle.Id,
                        dtPickup.Value.Date,
                        dtReturn.Value.Date);

                if (overlappingRentals.Count > 0)
                {
                    var r = overlappingRentals[0];

                    var overlapEnd =
                        r.ActualReturnDate ?? r.ExpectedReturnDate;

                    MessageBox.Show(
                        $"This vehicle is already rented from " +
                        $"{r.PickupDate:yyyy-MM-dd} to {overlapEnd:yyyy-MM-dd}.\n\n" +
                        $"Please choose another vehicle or adjust the dates.",
                        "Rental Conflict",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                // ---------------- PAYMENT UI ----------------

                using var paymentForm =
                    new RentalDownPayment(
                        $"{_selectedCustomer.FirstName} {_selectedCustomer.LastName}",
                        $"{_selectedVehicle.Make} {_selectedVehicle.Model}",
                        baseRental,
                        securityDeposit);

                if (paymentForm.ShowDialog() != DialogResult.OK)
                    return; // ✅ NOTHING CREATED

                if (paymentForm.SelectedPaymentMethod == null)
                    throw new InvalidOperationException("Payment method not selected.");

                // ---------------- COMMIT (NOW AND ONLY NOW) ----------------

                int rentalId =
                    _rentalService.StartWalkInRental(
                        _selectedCustomer.Id,
                        _selectedVehicle.Id,
                        dtPickup.Value,
                        dtReturn.Value,
                        (FuelLevel)cbFuel.SelectedValue);

                var invoice =
                    _billingService.CreateInitialCharges(
                        rentalId,
                        baseRental,
                        securityDeposit);

                if (paymentForm.PaidAmount != securityDeposit)
                {
                    MessageBox.Show(
                        $"Deposit must be exactly ₱{securityDeposit:N2}.",
                        "Payment Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                
                _billingService.AddPayment(
                    invoice.Id,
                    paymentForm.PaidAmount,
                    paymentForm.SelectedPaymentMethod.Value,
                    PaymentType.Deposit,
                    DateTime.UtcNow);

                // ---------------- SUCCESS ----------------

                MessageBox.Show(
                    "Rental successfully created.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
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
        
        private bool IsFormValid()
        {
            // 1. Customer
            if (_selectedCustomer == null)
                return false;

            // 2. Vehicle
            if (_selectedVehicle == null)
                return false;

            // 3. Dates
            if (dtReturn.Value <= dtPickup.Value)
                return false;

            // 4. Odometer
            if (string.IsNullOrWhiteSpace(txtOdometer.Text))
                return false;

            if (!int.TryParse(txtOdometer.Text, out int odometer))
                return false;

            if (odometer < _selectedVehicle.Odometer)
                return false;

            return true;
        }
        
        private bool UpdateDateAvailabilityUI()
        {
            errLabel.Visible = false;
            errLabel.Text = string.Empty;

            if (_selectedVehicle == null)
                return false;

            if (dtReturn.Value <= dtPickup.Value)
                return false;

            bool available =
                _vehicleService.AreRentalDatesAvailable(
                    _selectedVehicle.Id,
                    dtPickup.Value.Date,
                    dtReturn.Value.Date);

            if (!available)
            {
                errLabel.Text = "Selected dates overlap with an existing rental.";
                errLabel.ForeColor = Color.FromArgb(231, 76, 60); // red
                errLabel.Visible = true;
                return false;
            }

            errLabel.Text = "Rental dates are available.";
            errLabel.ForeColor = Color.FromArgb(46, 204, 113); // green
            errLabel.Visible = true;

            return true;
        }




        private void UpdateSaveButtonState()
        {
            bool formValid = IsFormValid();
            bool datesValid = UpdateDateAvailabilityUI();

            btnSave.Enabled = formValid && datesValid;

            btnSave.BackColor = btnSave.Enabled
                ? Color.FromArgb(46, 204, 113)
                : Color.FromArgb(189, 195, 199);
        }
        
        private void StyleCancelButton()
        {
            // Base color
            var normal = Color.FromArgb(231, 76, 60);   // red
            var hover = Color.FromArgb(241, 96, 80);    // lighter red
            var pressed = Color.FromArgb(192, 57, 43);  // darker red
            var disabled = Color.FromArgb(189, 195, 199);

            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;

            btnCancel.BackColor = normal;
            btnCancel.ForeColor = Color.White;

            btnCancel.FlatAppearance.MouseOverBackColor = hover;
            btnCancel.FlatAppearance.MouseDownBackColor = pressed;

            btnCancel.EnabledChanged += (_, __) =>
            {
                btnCancel.BackColor = btnCancel.Enabled ? normal : disabled;
            };
        }


        


    }
}
