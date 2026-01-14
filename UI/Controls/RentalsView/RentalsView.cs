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
using VRMS.UI.ApplicationService;
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

            _customerService = ApplicationServices.CustomerService;
            _vehicleService = ApplicationServices.VehicleService;
            _reservationService = ApplicationServices.ReservationService;
            _rentalService = ApplicationServices.RentalService;
            _rateService = ApplicationServices.RateService;
            _billingService = ApplicationServices.BillingService;

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
                string customerName = "Walk-in";

                if (r.ReservationId.HasValue)
                {
                    var reservation =
                        _reservationService.GetReservationById(r.ReservationId.Value);

                    var customer =
                        _customerService.GetCustomerById(reservation.CustomerId);

                    customerName = $"{customer.FirstName} {customer.LastName}";
                }
                else if (r.CustomerId.HasValue)
                {
                    var customer =
                        _customerService.GetCustomerById(r.CustomerId.Value);

                    customerName = $"{customer.FirstName} {customer.LastName}";
                }


                return new RentalGridRow
                {
                    RentalId = r.Id,
                    PickupDate = r.PickupDate,
                    ExpectedReturnDate = r.ExpectedReturnDate,
                    Status = r.Status,
                    CustomerName = customerName
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
                using var form = new CompleteRentalForm(row.RentalId, _rentalService, _reservationService, _vehicleService, _customerService);
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

            var vehicle =
                _vehicleService.GetVehicleById(rental.VehicleId);

            string customerName = "Walk-in";

            if (rental.ReservationId.HasValue)
            {
                var reservation =
                    _reservationService.GetReservationById(rental.ReservationId.Value);

                var customer =
                    _customerService.GetCustomerById(reservation.CustomerId);

                customerName = $"{customer.FirstName} {customer.LastName}";
            }
            else if (rental.CustomerId.HasValue)
            {
                var customer =
                    _customerService.GetCustomerById(rental.CustomerId.Value);

                customerName = $"{customer.FirstName} {customer.LastName}";
            }


            lblDetailVehicle.Text = $"{vehicle.Year} {vehicle.Make} {vehicle.Model}";
            lblDetailCustomer.Text = customerName;
            lblDetailDates.Text =
                $"From {rental.PickupDate:d} to {rental.ExpectedReturnDate:d}";
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