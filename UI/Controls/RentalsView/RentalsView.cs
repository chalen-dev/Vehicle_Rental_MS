using System;
using System.Windows.Forms;
using VRMS.Forms;
using VRMS.Models.Rentals;

// Repositories
using VRMS.Repositories.Rentals;
using VRMS.Repositories.Customers;
using VRMS.Repositories.Fleet;


// Services
using VRMS.Services.Customer;
using VRMS.Services.Fleet;
using VRMS.Services.Rental;

namespace VRMS.Controls
{
    public partial class RentalsView : UserControl
    {
        // =========================
        // SERVICES
        // =========================

        private readonly CustomerService _customerService;
        private readonly VehicleService _vehicleService;
        private readonly ReservationService _reservationService;
        private readonly RentalService _rentalService;

        // =========================
        // CONSTRUCTOR
        // =========================

        public RentalsView()
        {
            InitializeComponent();

            // -----------------------------
            // REPOSITORIES
            // -----------------------------

            var customerRepo = new CustomerRepository();
            var vehicleRepo = new VehicleRepository();
            var categoryRepo = new VehicleCategoryRepository();
            var featureRepo = new VehicleFeatureRepository();
            var featureMapRepo = new VehicleFeatureMappingRepository();
            var imageRepo = new VehicleImageRepository();
            var maintenanceRepo = new MaintenanceRepository();
            var reservationRepo = new ReservationRepository();
            var rentalRepo = new RentalRepository();

            // -----------------------------
            // SERVICES
            // -----------------------------

            var driversLicenseService = new DriversLicenseService();

            _customerService = new CustomerService(driversLicenseService);

            _vehicleService = new VehicleService(
                vehicleRepo,
                categoryRepo,
                featureRepo,
                featureMapRepo,
                imageRepo,
                maintenanceRepo
            );

            _reservationService = new ReservationService(
                _customerService,
                _vehicleService,
                reservationRepo
            );

            _rentalService = new RentalService(
                _reservationService,
                _vehicleService,
                rentalRepo
            );

            // -----------------------------
            // EVENTS
            // -----------------------------

            Load += RentalsView_Load;
            dgvRentals.SelectionChanged += DgvRentals_SelectionChanged;
        }

        // =========================
        // LOAD
        // =========================

        private void RentalsView_Load(object sender, EventArgs e)
        {
            ConfigureGrid();
            LoadRentals();
        }

        private void ConfigureGrid()
        {
            dgvRentals.AutoGenerateColumns = false;
            dgvRentals.ReadOnly = true;
            dgvRentals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRentals.MultiSelect = false;
            dgvRentals.Columns.Clear();

            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Rental ID",
                DataPropertyName = "Id"
            });

            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Pickup Date",
                DataPropertyName = "PickupDate"
            });

            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Expected Return",
                DataPropertyName = "ExpectedReturnDate"
            });

            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Status",
                DataPropertyName = "Status"
            });
        }

        private void LoadRentals()
        {
            try
            {
                // TEMP: until GetAllRentals() exists
                dgvRentals.DataSource = null;
                dgvRentals.DataSource = Array.Empty<Rental>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Load Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================
        // SELECTION
        // =========================

        private void DgvRentals_SelectionChanged(object? sender, EventArgs e)
        {
            bool hasSelection = dgvRentals.SelectedRows.Count > 0;

            btnReturn.Enabled = hasSelection;
            btnViewDetails.Enabled = hasSelection;

            if (!hasSelection)
                return;

            if (dgvRentals.SelectedRows[0].DataBoundItem is not Rental rental)
                return;

            lblDetailVehicle.Text = $"Rental #{rental.Id}";
            lblDetailCustomer.Text = "Customer: (loaded later)";
            lblDetailDates.Text =
                $"From {rental.PickupDate:d} to {rental.ExpectedReturnDate:d}";
            lblDetailAmount.Text = "Total: ₱ --";

            pbVehicle.Image = null; // vehicle image later
        }

        // =========================
        // BUTTONS
        // =========================

        private void BtnNewRental_Click(object sender, EventArgs e)
        {
            using var form = new NewRentalForm(
                _customerService,
                _vehicleService
            );

            if (form.ShowDialog(this) == DialogResult.OK)
                LoadRentals();
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            if (dgvRentals.SelectedRows.Count == 0)
                return;

            using var form = new ReturnVehicleForm();
            form.ShowDialog(this);
        }

        private void BtnViewDetails_Click(object sender, EventArgs e)
        {
            using var form = new RentalDetailsForm();
            form.ShowDialog(this);
        }
    }
}
