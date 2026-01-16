using VRMS.DTOs.Rental;
using VRMS.Enums;
using VRMS.Forms;
using VRMS.Services.Billing;
using VRMS.Services.Customer;
using VRMS.Services.Fleet;
using VRMS.Services.Rental;
using VRMS.UI.ApplicationService;
using VRMS.UI.Forms.Rentals;

namespace VRMS.UI.Controls.RentalsView
{
    public partial class RentalsView : UserControl
    {
        private readonly CustomerService _customerService;
        private readonly VehicleService _vehicleService;
        private readonly RentalService _rentalService;
        private readonly RateService _rateService;
        private readonly BillingService _billingService;

        private List<RentalGridRow> _allRows = new();
        private readonly ToolTip _toolTip = new ToolTip();
        private static readonly string PlaceholderImagePath = Path.Combine("Assets", "img_placeholder.png");

        // Sorting variables
        private SortDirection _currentSortDirection = SortDirection.Ascending;
        private string _currentSortColumn = "";

        // Enum for sort direction
        private enum SortDirection
        {
            Ascending,
            Descending
        }

        public RentalsView()
        {
            InitializeComponent();

            _customerService = ApplicationServices.CustomerService;
            _vehicleService = ApplicationServices.VehicleService;
            _rentalService = ApplicationServices.RentalService;
            _rateService = ApplicationServices.RateService;
            _billingService = ApplicationServices.BillingService;

            Load += RentalsView_Load;
            dgvRentals.SelectionChanged += DgvRentals_SelectionChanged;
            dgvRentals.ColumnHeaderMouseClick += DgvRentals_ColumnHeaderMouseClick;
        }

        private void DgvRentals_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Only handle column header clicks (row index -1)
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                var column = dgvRentals.Columns[e.ColumnIndex];
                var columnName = column.DataPropertyName;

                // Toggle sort direction if clicking the same column
                if (_currentSortColumn == columnName)
                {
                    _currentSortDirection = _currentSortDirection == SortDirection.Ascending
                        ? SortDirection.Descending
                        : SortDirection.Ascending;
                }
                else
                {
                    // New column, default to ascending
                    _currentSortColumn = columnName;
                    _currentSortDirection = SortDirection.Ascending;
                }

                // Update sort indicators in column headers
                UpdateSortIndicators(column);

                // Apply the sort
                SortData();
            }
        }

        private void UpdateSortIndicators(DataGridViewColumn sortedColumn)
        {
            // Clear all sort indicators
            foreach (DataGridViewColumn column in dgvRentals.Columns)
            {
                column.HeaderCell.SortGlyphDirection = SortOrder.None;
            }

            // Set sort indicator for the current sorted column
            sortedColumn.HeaderCell.SortGlyphDirection = _currentSortDirection == SortDirection.Ascending
                ? SortOrder.Ascending
                : SortOrder.Descending;
        }

        private void SortData()
        {
            if (dgvRentals.DataSource is List<RentalGridRow> rows && rows.Count > 0)
            {
                var sortedList = _currentSortDirection == SortDirection.Ascending
                    ? SortAscending(rows, _currentSortColumn)
                    : SortDescending(rows, _currentSortColumn);

                dgvRentals.DataSource = null;
                dgvRentals.DataSource = sortedList;

                // Maintain selection if possible
                if (dgvRentals.SelectedRows.Count > 0 && dgvRentals.Rows.Count > 0)
                {
                    dgvRentals.Rows[0].Selected = true;
                }

                // Reapply cell formatting
                dgvRentals.Refresh();
            }
        }

        private List<RentalGridRow> SortAscending(List<RentalGridRow> rows, string propertyName)
        {
            return propertyName switch
            {
                "RentalId" => rows.OrderBy(r => r.RentalId).ToList(),
                "CustomerName" => rows.OrderBy(r => r.CustomerName).ToList(),
                "PickupDate" => rows.OrderBy(r => r.PickupDate).ToList(),
                "ExpectedReturnDate" => rows.OrderBy(r => r.ExpectedReturnDate).ToList(),
                "Status" => rows.OrderBy(r => r.Status.ToString()).ToList(),
                _ => rows
            };
        }

        private List<RentalGridRow> SortDescending(List<RentalGridRow> rows, string propertyName)
        {
            return propertyName switch
            {
                "RentalId" => rows.OrderByDescending(r => r.RentalId).ToList(),
                "CustomerName" => rows.OrderByDescending(r => r.CustomerName).ToList(),
                "PickupDate" => rows.OrderByDescending(r => r.PickupDate).ToList(),
                "ExpectedReturnDate" => rows.OrderByDescending(r => r.ExpectedReturnDate).ToList(),
                "Status" => rows.OrderByDescending(r => r.Status.ToString()).ToList(),
                _ => rows
            };
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

                if (r.CustomerId.HasValue)
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

            // Apply any existing sort after loading data
            if (!string.IsNullOrEmpty(_currentSortColumn))
            {
                SortData();
            }
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
                filtered = filtered.Where(r => r.CustomerName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                                              r.RentalId.ToString().Contains(search));

            dgvRentals.DataSource = filtered.ToList();

            // Apply any existing sort after filtering
            if (!string.IsNullOrEmpty(_currentSortColumn))
            {
                SortData();
            }

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
                using var form = new CompleteRentalForm(
                    row.RentalId,
                    _rentalService,
                    _vehicleService,
                    _customerService,
                    _rateService,
                    _billingService
                );

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
            if (dgvRentals.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a rental first.");
                return;
            }

            if (dgvRentals.SelectedRows[0].DataBoundItem is not RentalGridRow row)
            {
                MessageBox.Show("Invalid selection.");
                return;
            }

            using var form = new RentalDetailsForm(row.RentalId);
            form.ShowDialog(this);
        }

        private void DgvRentals_SelectionChanged(object? sender, EventArgs e)
        {
            UpdateActionButtons();

            // =========================
            // NO SELECTION
            // =========================
            if (dgvRentals.SelectedRows.Count == 0)
            {
                lblDetailVehicle.Text = "Vehicle";
                lblDetailCustomer.Text = "Customer";
                lblDetailDates.Text = "Period";
                lblDetailAmount.Text = "Total: ₱ --";
                pbVehicle.Image = null;
                return;
            }

            // =========================
            // GET SELECTED ROW
            // =========================
            if (dgvRentals.SelectedRows[0].DataBoundItem is not RentalGridRow row)
                return;

            // =========================
            // LOAD CORE ENTITIES
            // =========================
            var rental = _rentalService.GetRentalById(row.RentalId);
            var vehicle = _vehicleService.GetVehicleById(rental.VehicleId);

            // =========================
            // CUSTOMER NAME
            // =========================
            string customerName = "Walk-in";

            if (rental.CustomerId.HasValue)
            {
                var customer =
                    _customerService.GetCustomerById(rental.CustomerId.Value);

                customerName = $"{customer.FirstName} {customer.LastName}";
            }

            // =========================
            // BASIC UI FIELDS
            // =========================
            lblDetailVehicle.Text = $"{vehicle.Year} {vehicle.Make} {vehicle.Model}";
            lblDetailCustomer.Text = customerName;
            lblDetailDates.Text =
                $"From {rental.PickupDate:d} to {rental.ExpectedReturnDate:d}";

            // =========================
            // TOTAL CALCULATION
            // =========================
            try
            {
                decimal baseRental =
                    _rateService.CalculateRentalCost(
                        rental.PickupDate,
                        rental.ExpectedReturnDate,
                        vehicle.VehicleCategoryId);

                lblDetailAmount.Text = $"Total: ₱ {baseRental:N2}";
            }
            catch
            {
                lblDetailAmount.Text = "Total: ₱ --";
            }

            // =========================
            // IMAGE
            // =========================
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

    // RentalGridRow class (if not already defined elsewhere)
    public class RentalGridRow
    {
        public int RentalId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public DateTime PickupDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public RentalStatus Status { get; set; }
    }
}