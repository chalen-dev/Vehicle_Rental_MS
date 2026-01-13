using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VRMS.DTOs.Rental;
using VRMS.Enums;
using VRMS.Forms;
using VRMS.Models.Rentals;
using VRMS.Repositories.Accounts;
using VRMS.Repositories.Billing;
using VRMS.Repositories.Customers;
using VRMS.Repositories.Damages;
using VRMS.Repositories.Fleet;
using VRMS.Repositories.Rentals;
using VRMS.Repositories.Inspections; // Added
using VRMS.Services.Account;
using VRMS.Services.Billing;
using VRMS.Services.Customer;
using VRMS.Services.Fleet;
using VRMS.Services.Rental;
using VRMS.UI.Forms.Rentals;

namespace VRMS.Controls
{
    public partial class RentalsView : UserControl
    {
        private readonly CustomerService _customerService;
        private readonly VehicleService _vehicleService;
        private readonly ReservationService _reservationService;
        private readonly RentalService _rentalService;
        private readonly RateService _rateService;
        private readonly BillingService _billingService;

        private List<RentalGridRow> _allRows = new();
        private readonly ToolTip _toolTip = new ToolTip();
        private static readonly string PlaceholderImagePath = Path.Combine("Assets", "img_placeholder.png");

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
            var damageReportRepo = new DamageReportRepository(); // This is the 'damageRepo' parameter
            var rateConfigRepo = new RateConfigurationRepository();

            // NEW REPOSITORIES REQUIRED BY RENTALSERVICE
            var inspectionRepo = new VehicleInspectionRepository();
            var damageRepo = new DamageRepository();

            // =========================
            // SERVICES
            // =========================
            var driversLicenseService = new DriversLicenseService();
            var customerAccountRepo = new CustomerAccountRepository();
            var customerAccountService = new CustomerAccountService(customerAccountRepo);

            _customerService = new CustomerService(driversLicenseService, customerAccountService);

            _vehicleService = new VehicleService(
                vehicleRepo, categoryRepo, featureRepo,
                featureMapRepo, imageRepo, maintenanceRepo, rateConfigRepo);

            _reservationService = new ReservationService(_customerService, _vehicleService, reservationRepo);
            _rateService = new RateService(rateConfigRepo);

            _billingService = new BillingService(
                rentalRepo, _reservationService, _vehicleService, _rateService,
                invoiceRepo, invoiceLineItemRepo, paymentRepo, damageReportRepo);

            // UPDATED CONSTRUCTOR CALL
            _rentalService = new RentalService(
                _reservationService,
                _vehicleService,
                rentalRepo,
                _billingService,
                inspectionRepo,
                damageRepo,
                damageReportRepo
            );

            // =========================
            // EVENTS
            // =========================
            Load += RentalsView_Load;
            dgvRentals.SelectionChanged += DgvRentals_SelectionChanged;
        }

        private void RentalsView_Load(object sender, EventArgs e)
        {
            ConfigureGrid();
            LoadStatusFilter();
            LoadRentals();
            txtSearch.TextChanged += (_, __) => ApplyFilters();
            _toolTip.InitialDelay = 500;
            _toolTip.ReshowDelay = 100;
            _toolTip.AutoPopDelay = 5000;
            _toolTip.ShowAlways = true;
        }

        private void ConfigureGrid()
        {
            dgvRentals.AutoGenerateColumns = false;
            dgvRentals.ReadOnly = true;
            dgvRentals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRentals.MultiSelect = false;
            dgvRentals.Columns.Clear();

            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Rental ID", DataPropertyName = "RentalId", Width = 80 });
            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Customer", DataPropertyName = "CustomerName", Width = 180 });
            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Pickup Date", DataPropertyName = "PickupDate", DefaultCellStyle = { Format = "MMM dd, yyyy" }, Width = 140 });
            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Expected Return", DataPropertyName = "ExpectedReturnDate", DefaultCellStyle = { Format = "MMM dd, yyyy" }, Width = 140 });
            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Status", DataPropertyName = "Status", Width = 100 });

            dgvRentals.CellFormatting += DgvRentals_CellFormatting;
        }

        private void LoadRentals()
        {
            var rentals = _rentalService.GetAllRentals();
            _allRows = rentals.Select(r =>
            {
                var reservation = _reservationService.GetReservationById(r.ReservationId);
                var customer = _customerService.GetCustomerById(reservation.CustomerId);
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
            cbStatusFilter.DataSource = Enum.GetValues(typeof(RentalStatus));
            cbStatusFilter.SelectedItem = RentalStatus.All;
            cbStatusFilter.SelectedIndexChanged += (_, __) => ApplyFilters();
        }

        private void ApplyFilters()
        {
            IEnumerable<RentalGridRow> filtered = _allRows;
            var selectedStatus = (RentalStatus)cbStatusFilter.SelectedItem;
            if (selectedStatus != RentalStatus.All)
                filtered = filtered.Where(r => r.Status == selectedStatus);

            var search = txtSearch.Text.Trim();
            if (!string.IsNullOrWhiteSpace(search))
                filtered = filtered.Where(r => r.CustomerName.Contains(search, StringComparison.OrdinalIgnoreCase));

            dgvRentals.DataSource = filtered.ToList();
            UpdateActionButtons();
        }

        private void BtnNewRental_Click(object sender, EventArgs e)
        {
            using var form =
                new NewRentalForm(
                    _customerService,
                    _vehicleService,
                    _reservationService,
                    _rentalService,
                    _billingService,
                    _rateService);

            if (form.ShowDialog(FindForm()) == DialogResult.OK)
                LoadRentals();
        }


        private bool _returnInProgress = false;

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            if (_returnInProgress || !btnReturn.Enabled || dgvRentals.SelectedRows.Count == 0) return;
            if (dgvRentals.SelectedRows[0].DataBoundItem is not RentalGridRow row) return;

            _returnInProgress = true;
            btnReturn.Enabled = false;

            try
            {
                using var form = new ReturnVehicleForm(row.RentalId, _rentalService, _reservationService, _vehicleService, _customerService);
                if (form.ShowDialog(FindForm()) == DialogResult.OK)
                    LoadRentals();
            }
            finally
            {
                _returnInProgress = false;
                UpdateActionButtons();
            }
        }

        private void BtnViewDetails_Click(object sender, EventArgs e)
        {
            using var form = new RentalDetailsForm();
            form.ShowDialog(this);
        }

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

            if (dgvRentals.SelectedRows[0].DataBoundItem is not RentalGridRow row) return;

            var rental = _rentalService.GetRentalById(row.RentalId);
            var reservation = _reservationService.GetReservationById(rental.ReservationId);
            var vehicle = _vehicleService.GetVehicleById(reservation.VehicleId);
            var customer = _customerService.GetCustomerById(reservation.CustomerId);

            lblDetailVehicle.Text = $"{vehicle.Year} {vehicle.Make} {vehicle.Model}";
            lblDetailCustomer.Text = $"{customer.FirstName} {customer.LastName}";
            lblDetailDates.Text = $"From {rental.PickupDate:d} to {rental.ExpectedReturnDate:d}";
            lblDetailAmount.Text = "Total: ₱ --";

            LoadVehicleImage(vehicle.Id);
        }

        private void LoadVehicleImage(int vehicleId)
        {
            if (pbVehicle.Image != null)
            {
                pbVehicle.Image.Dispose();
                pbVehicle.Image = null;
            }

            var images = _vehicleService.GetVehicleImages(vehicleId);
            string? imagePath = images.Count > 0
                ? Path.Combine(AppContext.BaseDirectory, "Storage", images[0].ImagePath)
                : null;

            if (imagePath == null || !File.Exists(imagePath))
            {
                imagePath = Path.Combine(AppContext.BaseDirectory, PlaceholderImagePath);
                if (!File.Exists(imagePath)) return;
            }

            using var fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            pbVehicle.Image = Image.FromStream(fs);
        }

        private void UpdateActionButtons()
        {
            bool hasSelection = dgvRentals.SelectedRows.Count > 0;
            bool canReturn = hasSelection && dgvRentals.SelectedRows[0].DataBoundItem is RentalGridRow row &&
                             (row.Status == RentalStatus.Active || row.Status == RentalStatus.Late);

            btnViewDetails.Enabled = hasSelection;
            SetReturnButtonState(canReturn);
        }

        private void DgvRentals_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRentals.Columns[e.ColumnIndex].DataPropertyName != "Status" || e.Value is not RentalStatus status) return;

            e.CellStyle.Font = new Font(dgvRentals.Font, FontStyle.Bold);
            e.CellStyle.ForeColor = status switch
            {
                RentalStatus.Active => Color.Green,
                RentalStatus.Late => Color.OrangeRed,
                RentalStatus.Completed => Color.Gray,
                RentalStatus.Cancelled => Color.DarkGray,
                _ => e.CellStyle.ForeColor
            };
        }

        private void SetReturnButtonState(bool enabled)
        {
            btnReturn.Enabled = enabled;
            if (enabled)
            {
                btnReturn.BackColor = Color.FromArgb(255, 193, 7);
                btnReturn.ForeColor = Color.Black;
            }
            else
            {
                btnReturn.BackColor = Color.LightGray;
                btnReturn.ForeColor = Color.DarkGray;
            }
        }
    }
}