using VRMS.Enums;
using VRMS.Forms.Payments;
using VRMS.Models.Fleet;
using VRMS.Services.Customer;
using VRMS.Services.Fleet;
using VRMS.Services.Rental;

namespace VRMS.UI.Forms.Rentals
{
    public partial class NewRentalForm : Form
    {
        private readonly CustomerService _customerService;
        private readonly VehicleService _vehicleService;
        private readonly ReservationService _reservationService;
        private readonly RentalService _rentalService;

        public NewRentalForm(
            CustomerService customerService,
            VehicleService vehicleService,
            ReservationService reservationService,
            RentalService rentalService)
        {
            InitializeComponent();

            _customerService = customerService;
            _vehicleService = vehicleService;
            _reservationService = reservationService;
            _rentalService = rentalService;
            
            cbVehicle.SelectedIndexChanged += CbVehicle_SelectedIndexChanged;

            Load += NewRentalForm_Load;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += (_, __) => Close();
        }

        // -------------------------------
        // LOAD DATA
        // -------------------------------
        private void NewRentalForm_Load(object? sender, EventArgs e)
        {
            LoadCustomers();
            LoadVehicles();
            LoadFuelLevels();
        }

        private void LoadCustomers()
        {
            cbCustomer.DataSource = null;
            cbCustomer.DataSource = _customerService.GetAllCustomers();
            cbCustomer.DisplayMember = "FullName"; // or build manually
            cbCustomer.ValueMember = "Id";
        }

        private void LoadVehicles()
        {
            cbVehicle.DataSource = null;
            cbVehicle.DataSource =
                _vehicleService
                    .GetAllVehicles()
                    .FindAll(v => v.Status == VehicleStatus.Available);

            cbVehicle.DisplayMember = "DisplayName";
            cbVehicle.ValueMember = "Id";

            // Make sure something is selected so SelectedIndexChanged fires / UI shows an odometer
            if (cbVehicle.Items.Count > 0 && cbVehicle.SelectedIndex == -1)
                cbVehicle.SelectedIndex = 0;

            // Populate odometer for the currently selected vehicle
            UpdateOdometerFromSelectedVehicle();
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
        
        private void CbVehicle_SelectedIndexChanged(object? sender, EventArgs e)
        {
            UpdateOdometerFromSelectedVehicle();
        }

        private void UpdateOdometerFromSelectedVehicle()
        {
            // Ensure user can't type into the odometer field
            txtOdometer.ReadOnly = true;
            txtOdometer.TabStop = false;

            if (cbVehicle.SelectedItem is Vehicle v)
            {
                txtOdometer.Text = v.Odometer.ToString();
            }
            else
            {
                txtOdometer.Text = string.Empty;
            }
        }


        // -------------------------------
        // SAVE / NEXT STEP
        // -------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbCustomer.SelectedItem is not Models.Customers.Customer customer)
                    throw new InvalidOperationException(
                        "Please select a customer.");

                if (cbVehicle.SelectedItem is not Vehicle vehicle)
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
                    $"{customer.FirstName} {customer.LastName}";

                string vehicleName =
                    $"{vehicle.Make} {vehicle.Model} ({vehicle.LicensePlate})";

                // TODO: Replace with RateService
                decimal estimatedTotal = 0m;

                lblTotal.Text =
                    $"Total: ₱{estimatedTotal:N2}";

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
                            customer.Id,
                            vehicle.Id,
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
    }
}
