using System;
using System.Drawing;
using System.Windows.Forms;
using VRMS.Enums;
using VRMS.Forms;
using VRMS.Models.Rentals;

// =========================
// REPOSITORIES
// =========================
using VRMS.Repositories.Customers;
using VRMS.Repositories.Fleet;
using VRMS.Repositories.Rentals;
using VRMS.Repositories.Billing;
using VRMS.Repositories.Damages;

// =========================
// SERVICES
// =========================
using VRMS.Services.Customer;
using VRMS.Services.Fleet;
using VRMS.Services.Rental;
using VRMS.Services.Billing;
using VRMS.UI.Forms.Rentals;

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

        private List<RentalGridRow> _allRows = new();
        
        private static readonly string PlaceholderImagePath =
            Path.Combine("Assets", "img_placeholder.png");

        // =========================
        // CONSTRUCTOR
        // =========================

        public RentalsView()
        {
            InitializeComponent();

            // =========================
            // REPOSITORIES
            // =========================

            var customerRepo = new CustomerRepository();

            var vehicleRepo = new VehicleRepository();
            var categoryRepo = new VehicleCategoryRepository();
            var featureRepo = new VehicleFeatureRepository();
            var featureMapRepo = new VehicleFeatureMappingRepository();
            var imageRepo = new VehicleImageRepository();
            var maintenanceRepo = new MaintenanceRepository();

            var reservationRepo = new ReservationRepository();
            var rentalRepo = new RentalRepository();

            var invoiceRepo = new InvoiceRepository();
            var invoiceLineItemRepo = new InvoiceLineItemRepository();
            var paymentRepo = new PaymentRepository();
            var damageRepo = new DamageReportRepository();
            var rateConfigRepo = new RateConfigurationRepository();

            // =========================
            // SERVICES
            // =========================

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

            var rateService = new RateService(rateConfigRepo);

            var billingService = new BillingService(
                rentalRepo,
                _reservationService,
                _vehicleService,
                rateService,
                invoiceRepo,
                invoiceLineItemRepo,
                paymentRepo,
                damageRepo
            );

            _rentalService = new RentalService(
                _reservationService,
                _vehicleService,
                rentalRepo,
                billingService
            );

            // =========================
            // EVENTS
            // =========================

            Load += RentalsView_Load;
            dgvRentals.SelectionChanged += DgvRentals_SelectionChanged;
        }

        // =========================
        // LOAD
        // =========================

        private void RentalsView_Load(object sender, EventArgs e)
        {
            ConfigureGrid();
            LoadStatusFilter();
            LoadRentals();
            txtSearch.TextChanged += (_, __) => ApplyFilters();
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
                DataPropertyName = "RentalId",
                Width = 80
            });
            
            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Customer",
                DataPropertyName = "CustomerName",
                Width = 180
            });

            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Pickup Date",
                DataPropertyName = "PickupDate",
                DefaultCellStyle = { Format = "MMM dd, yyyy" },
                Width = 140
            });

            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Expected Return",
                DataPropertyName = "ExpectedReturnDate",
                DefaultCellStyle = { Format = "MMM dd, yyyy" },
                Width = 140
            });

            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Status",
                DataPropertyName = "Status",
                Width = 100
            });

            dgvRentals.CellFormatting -= DgvRentals_CellFormatting;
            dgvRentals.CellFormatting += DgvRentals_CellFormatting;
        }

        private void LoadRentals()
        {
            var rentals = _rentalService.GetAllRentals();

            _allRows = rentals.Select(r =>
            {
                var reservation =
                    _reservationService.GetReservationById(r.ReservationId);

                var customer =
                    _customerService.GetCustomerById(reservation.CustomerId);

                return new RentalGridRow
                {
                    RentalId = r.Id,
                    PickupDate = r.PickupDate,
                    ExpectedReturnDate = r.ExpectedReturnDate,
                    Status = r.Status,
                    CustomerName = $"{customer.FirstName} {customer.LastName}"
                };
            }).ToList();

            ApplyFilters();
        }
        
        private void LoadStatusFilter()
        {
            cbStatusFilter.Items.Clear();
            cbStatusFilter.Items.Add("All");

            foreach (var status in Enum.GetValues(typeof(RentalStatus)))
                cbStatusFilter.Items.Add(status);

            cbStatusFilter.SelectedIndex = 0;

            cbStatusFilter.SelectedIndexChanged += (_, __) => ApplyFilters();
        }
        
        private void LoadVehicleImage(int vehicleId)
        {
            // Dispose previous image (avoid memory + file locks)
            if (pbVehicle.Image != null)
            {
                pbVehicle.Image.Dispose();
                pbVehicle.Image = null;
            }

            string? imagePath = null;

            var images = _vehicleService.GetVehicleImages(vehicleId);

            if (images.Count > 0)
            {
                var candidate = Path.Combine(
                    AppContext.BaseDirectory,
                    "Storage",
                    images[0].ImagePath);

                if (File.Exists(candidate))
                    imagePath = candidate;
            }

            // Fallback to placeholder
            if (imagePath == null)
            {
                var placeholder = Path.Combine(
                    AppContext.BaseDirectory,
                    PlaceholderImagePath);

                if (!File.Exists(placeholder))
                    return; // silent fail (safe)

                imagePath = placeholder;
            }

            // Load without locking the file
            using var fs = new FileStream(
                imagePath,
                FileMode.Open,
                FileAccess.Read,
                FileShare.ReadWrite);

            pbVehicle.Image = Image.FromStream(fs);
        }



        // =========================
        // SELECTION
        // =========================

        private void DgvRentals_SelectionChanged(object? sender, EventArgs e)
        {
            UpdateActionButtons();

            if (dgvRentals.SelectedRows.Count == 0)
            {
                lblDetailVehicle.Text = "Vehicle";
                lblDetailCustomer.Text = "Customer";
                lblDetailDates.Text = "Period";
                lblDetailAmount.Text = "Total: ₱ --";
                pbVehicle.Image = null;
                return;
            }

            if (dgvRentals.SelectedRows[0].DataBoundItem is not RentalGridRow row)
                return;

            var rental =
                _rentalService.GetRentalById(row.RentalId);

            var reservation =
                _reservationService.GetReservationById(
                    rental.ReservationId);

            var vehicle =
                _vehicleService.GetVehicleById(
                    reservation.VehicleId);

            var customer =
                _customerService.GetCustomerById(
                    reservation.CustomerId);

            lblDetailVehicle.Text =
                $"{vehicle.Year} {vehicle.Make} {vehicle.Model}";

            lblDetailCustomer.Text =
                $"{customer.FirstName} {customer.LastName}";

            lblDetailDates.Text =
                $"From {rental.PickupDate:d} to {rental.ExpectedReturnDate:d}";

            lblDetailAmount.Text = "Total: ₱ --";

            LoadVehicleImage(vehicle.Id);
        }

        // =========================
        // BUTTON STATE LOGIC
        // =========================

        private void UpdateActionButtons()
        {
            bool hasRows = dgvRentals.Rows.Count > 0;
            bool hasSelection = dgvRentals.SelectedRows.Count > 0;

            bool canView = hasRows && hasSelection;

            bool canReturn =
                canView &&
                dgvRentals.SelectedRows[0].DataBoundItem is RentalGridRow row &&
                row.Status == RentalStatus.Active;

            // View Details
            btnViewDetails.Enabled = canView;
            btnViewDetails.BackColor = canView
                ? Color.FromArgb(52, 152, 219)
                : Color.LightGray;
            btnViewDetails.ForeColor = canView
                ? Color.White
                : Color.DarkGray;
            btnViewDetails.Cursor = canView
                ? Cursors.Hand
                : Cursors.Default;

            // Return Vehicle
            btnReturn.Enabled = canReturn;
            btnReturn.BackColor = canReturn
                ? Color.FromArgb(241, 196, 15)
                : Color.LightGray;
            btnReturn.ForeColor = canReturn
                ? Color.White
                : Color.DarkGray;
            btnReturn.Cursor = canReturn
                ? Cursors.Hand
                : Cursors.Default;
        }

        // =========================
        // BUTTONS
        // =========================

        private void BtnNewRental_Click(object sender, EventArgs e)
        {
            using var form = new NewRentalForm(
                _customerService,
                _vehicleService,
                _reservationService,
                _rentalService
            );

            if (form.ShowDialog(FindForm()) == DialogResult.OK)
                LoadRentals();
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            if (!btnReturn.Enabled)
                return;

            if (dgvRentals.SelectedRows.Count == 0)
                return;

            if (dgvRentals.SelectedRows[0].DataBoundItem is not RentalGridRow row)
                return;

            var rental = _rentalService.GetRentalById(row.RentalId);

            using var form = new ReturnVehicleForm(
                rental.Id,
                _rentalService,
                _reservationService,
                _vehicleService,
                _customerService
            );


            if (form.ShowDialog(FindForm()) == DialogResult.OK)
                LoadRentals();
        }   


        private void BtnViewDetails_Click(object sender, EventArgs e)
        {
            using var form = new RentalDetailsForm();
            form.ShowDialog(this);
        }

        // =========================
        // STATUS COLOR CODING
        // =========================

        private void DgvRentals_CellFormatting(
            object? sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRentals.Columns[e.ColumnIndex].DataPropertyName != "Status")
                return;

            if (e.Value is not RentalStatus status)
                return;

            e.CellStyle.Font = new Font(
                dgvRentals.Font,
                FontStyle.Bold);

            e.CellStyle.ForeColor = status switch
            {
                RentalStatus.Active => Color.Green,
                RentalStatus.Late => Color.OrangeRed,
                RentalStatus.Completed => Color.Gray,
                _ => e.CellStyle.ForeColor
            };
        }
        
        private void ApplyFilters()
        {
            IEnumerable<RentalGridRow> filtered = _allRows;

            // Status filter
            if (cbStatusFilter.SelectedItem is RentalStatus status)
            {
                filtered = filtered.Where(r => r.Status == status);
            }

            // Search by customer name
            var search = txtSearch.Text.Trim();

            if (!string.IsNullOrWhiteSpace(search))
            {
                filtered = filtered.Where(r =>
                    r.CustomerName.Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            dgvRentals.DataSource = filtered.ToList();
            UpdateActionButtons();
        }

    }
}
