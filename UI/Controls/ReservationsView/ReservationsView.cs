using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VRMS.DTOs.Reservation;
using VRMS.Enums;
using VRMS.Forms;
using VRMS.Models.Rentals;
using VRMS.Repositories.Accounts;
using VRMS.Repositories.Billing;
using VRMS.Repositories.Fleet;
using VRMS.Repositories.Rentals;
using VRMS.Repositories.Customers;
using VRMS.Services.Account;
using VRMS.Services.Customer;
using VRMS.Services.Fleet;
using VRMS.Services.Rental;
using VRMS.UI.Forms.Reservation;

namespace VRMS.Controls
{
    public partial class ReservationsView : UserControl
    {
        private readonly CustomerService _customerService;
        private readonly VehicleService _vehicleService;
        private readonly ReservationService _reservationService;

        private List<ReservationGridRow> _allRows = new();

        private static readonly string PlaceholderImagePath =
            Path.Combine("Assets", "img_placeholder.png");

        public ReservationsView()
        {
            InitializeComponent();

            // Repositories
            var customerRepo = new CustomerRepository();

            var vehicleRepo = new VehicleRepository();
            var categoryRepo = new VehicleCategoryRepository();
            var featureRepo = new VehicleFeatureRepository();
            var featureMapRepo = new VehicleFeatureMappingRepository();
            var imageRepo = new VehicleImageRepository();
            var maintenanceRepo = new MaintenanceRepository();

            var reservationRepo = new ReservationRepository();

            // Services
            var driversLicenseService = new DriversLicenseService();
            var customerAccountRepo = new CustomerAccountRepository();
            var customerAccountService = new CustomerAccountService(customerAccountRepo);

            _customerService = new CustomerService(driversLicenseService, customerAccountService);

            _vehicleService = new VehicleService(
                vehicleRepo,
                categoryRepo,
                featureRepo,
                featureMapRepo,
                imageRepo,
                maintenanceRepo,
                new RateConfigurationRepository()
            );

            _reservationService = new ReservationService(
                _customerService,
                _vehicleService,
                reservationRepo
            );

            // Events
            Load += ReservationsView_Load;
            dgvReservations.SelectionChanged += DgvReservations_SelectionChanged;
            txtSearch.TextChanged += (_, __) => ApplyFilters();
            cbStatusFilter.SelectedIndexChanged += (_, __) => ApplyFilters();
            btnViewDetails.Click += BtnViewDetails_Click;
        }

        private void ReservationsView_Load(object sender, EventArgs e)
        {
            ConfigureGrid();
            LoadStatusFilter();

            txtSearch.ForeColor = Color.Gray;
            txtSearch.Text = "Search reservations...";

            txtSearch.GotFocus += (_, __) =>
            {
                if (txtSearch.Text == "Search reservations...")
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.Black;
                }
            };

            txtSearch.LostFocus += (_, __) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = "Search reservations...";
                    txtSearch.ForeColor = Color.Gray;
                }
            };

            LoadReservations();
        }


        private void ConfigureGrid()
        {
            dgvReservations.AutoGenerateColumns = false;
            dgvReservations.ReadOnly = true;
            dgvReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservations.MultiSelect = false;
            dgvReservations.Columns.Clear();

            dgvReservations.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Reservation ID",
                DataPropertyName = "ReservationId",
                Width = 80
            });

            dgvReservations.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Customer",
                DataPropertyName = "CustomerName",
                Width = 200
            });

            dgvReservations.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Vehicle",
                DataPropertyName = "VehicleName",
                Width = 240
            });

            dgvReservations.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Start",
                DataPropertyName = "StartDate",
                DefaultCellStyle = { Format = "MMM dd, yyyy" },
                Width = 120
            });

            dgvReservations.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "End",
                DataPropertyName = "EndDate",
                DefaultCellStyle = { Format = "MMM dd, yyyy" },
                Width = 120
            });

            dgvReservations.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Status",
                DataPropertyName = "Status",
                Width = 100
            });

            // Optional: style status column
            dgvReservations.CellFormatting += DgvReservations_CellFormatting;
        }

        private void LoadStatusFilter()
        {
            // We'll show a "All" option by creating an array with an "All" sentinel
            var values = Enum.GetValues(typeof(ReservationStatus)).Cast<ReservationStatus>().ToList();
            // We'll treat null selection as "All"
            cbStatusFilter.Items.Clear();
            cbStatusFilter.Items.Add("All");
            foreach (var v in values)
                cbStatusFilter.Items.Add(v);
            cbStatusFilter.SelectedIndex = 0;
        }

        private void LoadReservations()
        {
            _allRows = _reservationService
                .GetAllForGrid(); // later if you promote it into the service

            ApplyFilters();
        }

        private void ApplyFilters()
        {
            IEnumerable<ReservationGridRow> filtered = _allRows;

            // status
            if (cbStatusFilter.SelectedIndex > 0)
            {
                var status = (ReservationStatus)cbStatusFilter.SelectedItem;
                filtered = filtered.Where(r => r.Status == status);
            }

            var search = txtSearch.Text.Trim();
            if (search == "Search reservations...")
                search = "";

            dgvReservations.DataSource = filtered.ToList();
            UpdateActionButtons();
        }

        private void DgvReservations_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvReservations.Columns[e.ColumnIndex].DataPropertyName != "Status")
                return;

            if (e.Value is not ReservationStatus status)
                return;

            e.CellStyle.Font = new Font(dgvReservations.Font, FontStyle.Bold);
            e.CellStyle.ForeColor = status switch
            {
                ReservationStatus.Pending => Color.Orange,
                ReservationStatus.Confirmed => Color.Green,
                ReservationStatus.Cancelled => Color.DarkGray,
                _ => e.CellStyle.ForeColor
            };
        }

        private void DgvReservations_SelectionChanged(object? sender, EventArgs e)
        {
            UpdateActionButtons();

            if (dgvReservations.SelectedRows.Count == 0)
            {
                lblDetailVehicle.Text = "Vehicle Name";
                lblDetailCustomer.Text = "Customer Name";
                lblDetailDates.Text = "Period: Select entry";
                lblDetailAmount.Text = "Price: ₱ 0.0";
                pbVehicle.Image = null;
                return;
            }

            if (dgvReservations.SelectedRows[0].DataBoundItem is not ReservationGridRow row)
                return;

            // load the details using services
            var reservation = _reservationService.GetReservationById(row.ReservationId);
            var vehicle = _vehicleService.GetVehicleById(reservation.VehicleId);
            var customer = _customerService.GetCustomerById(reservation.CustomerId);

            lblDetailVehicle.Text = $"{vehicle.Year} {vehicle.Make} {vehicle.Model}";
            lblDetailCustomer.Text = $"{customer.FirstName} {customer.LastName}";
            lblDetailDates.Text = $"From {reservation.StartDate:d} to {reservation.EndDate:d}";
            lblDetailAmount.Text = "Price: ₱ --"; // if you calculate price elsewhere, plug it here

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
                if (!File.Exists(imagePath))
                    return;
            }

            using var fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            pbVehicle.Image = Image.FromStream(fs);
        }

        private void UpdateActionButtons()
        {
            bool hasSelection = dgvReservations.SelectedRows.Count > 0;

            bool canCancel = false;
            if (hasSelection && dgvReservations.SelectedRows[0].DataBoundItem is ReservationGridRow row)
            {
                canCancel = row.Status == ReservationStatus.Pending || row.Status == ReservationStatus.Confirmed;
            }

            btnCancelReservation.Enabled = canCancel;
            btnViewDetails.Enabled = hasSelection;

            // style the cancel button
            if (btnCancelReservation.Enabled)
            {
                btnCancelReservation.BackColor = Color.FromArgb(231, 76, 60);
                btnCancelReservation.ForeColor = Color.White;
            }
            else
            {
                btnCancelReservation.BackColor = Color.LightGray;
                btnCancelReservation.ForeColor = Color.DarkGray;
            }
        }

        private bool _cancelInProgress = false;

        private void BtnCancelReservation_Click(object? sender, EventArgs e)
        {
            if (_cancelInProgress)
                return;

            if (dgvReservations.SelectedRows.Count == 0)
                return;

            if (dgvReservations.SelectedRows[0].DataBoundItem is not ReservationGridRow row)
                return;

            var result = MessageBox.Show(
                "Are you sure you want to cancel this reservation?",
                "Confirm Cancellation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            _cancelInProgress = true;
            btnCancelReservation.Enabled = false;

            try
            {
                try
                {
                    _reservationService.CancelReservation(row.ReservationId);
                    MessageBox.Show("Reservation cancelled.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Unable to cancel reservation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // reload grid
                LoadReservations();
            }
            finally
            {
                _cancelInProgress = false;
                UpdateActionButtons();
            }
        }

        private void BtnViewDetails_Click(object? sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count == 0)
                return;

            if (dgvReservations.SelectedRows[0].DataBoundItem is not ReservationGridRow row)
                return;

            // Option A: open a ReservationDetailsForm (if you have one)
            // Option B: show the same information already in side panel
            // For now, show a simple details dialog:
            using var msg = new Form { Width = 600, Height = 400, Text = $"Reservation #{row.ReservationId}" };
            var tb = new TextBox { Multiline = true, Dock = DockStyle.Fill, ReadOnly = true };
            tb.Text = $"Reservation ID: {row.ReservationId}\r\nCustomer: {row.CustomerName}\r\nVehicle: {row.VehicleName}\r\nPeriod: {row.StartDate:d} → {row.EndDate:d}\r\nStatus: {row.Status}";
            msg.Controls.Add(tb);
            msg.StartPosition = FormStartPosition.CenterParent;
            msg.ShowDialog(this);
        }
        private void BtnNewReservation_Click(object sender, EventArgs e)
        {
            using var form = new AddReservationForm(
            _customerService,
            _vehicleService
            );


            if (form.ShowDialog(FindForm()) == DialogResult.OK)
                LoadReservations();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            BtnCancelReservation_Click(sender, e);
        }
    }
    
    
}
