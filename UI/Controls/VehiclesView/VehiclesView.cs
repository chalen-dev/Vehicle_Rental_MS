using System.ComponentModel;
using VRMS.DTOs.Vehicle;
using VRMS.Enums;
using VRMS.Forms;
using VRMS.Helpers;
using VRMS.Models.Fleet;
using VRMS.Services.Customer;
using VRMS.Services.Fleet;
using VRMS.Services.Rental;
using VRMS.UI.ApplicationService;
using VRMS.UI.Forms;
using VRMS.UI.Forms.Maintenance;

namespace VRMS.UI.Controls.VehiclesView
{
    public partial class VehiclesView : UserControl
    {
        private readonly VehicleService _vehicleService;
        private readonly DriversLicenseService _driversLicenseService;
        private readonly CustomerService _customerService;
        private readonly RentalService _rentalService;

        private VehicleAdvancedFilterDto? _advancedFilter;
        private SortDirection _currentSortDirection = SortDirection.Ascending;
        private string _currentSortColumn = "";

        // Enum for sort direction
        private enum SortDirection
        {
            Ascending,
            Descending
        }

        public VehiclesView()
        {
            InitializeComponent();

            _vehicleService = ApplicationServices.VehicleService;
            _driversLicenseService = ApplicationServices.DriversLicenseService;
            _customerService = ApplicationServices.CustomerService;
            _rentalService = ApplicationServices.RentalService;

            Load += VehiclesView_Load;
            dgvVehicles.SelectionChanged += DgvVehicles_SelectionChanged;
            dgvVehicles.ColumnHeaderMouseClick += DgvVehicles_ColumnHeaderMouseClick;

            flowLayoutPanelFeatures.AutoSize = true;
            flowLayoutPanelFeatures.WrapContents = true;

            cmbStatusFilter.SelectedIndexChanged += CmbStatusFilter_SelectedIndexChanged;
            cmbVehicleCategory.SelectedIndexChanged += CmbAdvancedFilter_SelectedIndexChanged;
            cmbFuelType.SelectedIndexChanged += CmbAdvancedFilter_SelectedIndexChanged;
            cmbTrasmissionType.SelectedIndexChanged += CmbAdvancedFilter_SelectedIndexChanged;
            cmbYear.SelectedIndexChanged += CmbAdvancedFilter_SelectedIndexChanged;
            txtSearch.TextChanged += (_, _) => ApplyFilters();

            btnUnderMaintenance.Click += btnUnderMaintenance_Click;
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;

            btnAddCategory.Click += btnAddCategory_Click;
        }

        private void DgvVehicles_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Only handle column header clicks (row index -1)
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                var column = dgvVehicles.Columns[e.ColumnIndex];
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
            foreach (DataGridViewColumn column in dgvVehicles.Columns)
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
            if (dgvVehicles.DataSource is List<Vehicle> vehicles && vehicles.Count > 0)
            {
                var sortedList = _currentSortDirection == SortDirection.Ascending
                    ? SortAscending(vehicles, _currentSortColumn)
                    : SortDescending(vehicles, _currentSortColumn);

                dgvVehicles.DataSource = null;
                dgvVehicles.DataSource = sortedList;

                // Maintain selection if possible
                if (dgvVehicles.SelectedRows.Count > 0 && dgvVehicles.Rows.Count > 0)
                {
                    dgvVehicles.Rows[0].Selected = true;
                }
            }
        }

        private List<Vehicle> SortAscending(List<Vehicle> vehicles, string propertyName)
        {
            return propertyName switch
            {
                "Make" => vehicles.OrderBy(v => v.Make).ToList(),
                "Model" => vehicles.OrderBy(v => v.Model).ToList(),
                "Year" => vehicles.OrderBy(v => v.Year).ToList(),
                "LicensePlate" => vehicles.OrderBy(v => v.LicensePlate).ToList(),
                "Transmission" => vehicles.OrderBy(v => v.Transmission.ToString()).ToList(),
                "FuelType" => vehicles.OrderBy(v => v.FuelType.ToString()).ToList(),
                "StatusDisplay" => vehicles.OrderBy(v => v.Status.ToString()).ToList(),
                "Odometer" => vehicles.OrderBy(v => v.Odometer).ToList(),
                _ => vehicles
            };
        }

        private List<Vehicle> SortDescending(List<Vehicle> vehicles, string propertyName)
        {
            return propertyName switch
            {
                "Make" => vehicles.OrderByDescending(v => v.Make).ToList(),
                "Model" => vehicles.OrderByDescending(v => v.Model).ToList(),
                "Year" => vehicles.OrderByDescending(v => v.Year).ToList(),
                "LicensePlate" => vehicles.OrderByDescending(v => v.LicensePlate).ToList(),
                "Transmission" => vehicles.OrderByDescending(v => v.Transmission.ToString()).ToList(),
                "FuelType" => vehicles.OrderByDescending(v => v.FuelType.ToString()).ToList(),
                "StatusDisplay" => vehicles.OrderByDescending(v => v.Status.ToString()).ToList(),
                "Odometer" => vehicles.OrderByDescending(v => v.Odometer).ToList(),
                _ => vehicles
            };
        }

        private void CmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void CmbAdvancedFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void VehiclesView_Load(object? sender, EventArgs e)
        {
            ConfigureGrid();
            LoadCategories();
            LoadFilterOptions();
            LoadVehicles();

            // Set default selections
            cmbStatusFilter.SelectedIndex = 0;
            cmbVehicleCategory.SelectedIndex = 0;
            cmbFuelType.SelectedIndex = 0;
            cmbTrasmissionType.SelectedIndex = 0;
            cmbYear.SelectedIndex = 0;
        }

        private void LoadFilterOptions()
        {
            // Status filter
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.AddRange(new object[]
            {
                "All Status",
                "Available",
                "Under Maintenance",
                "Rented",
                "Reserved",
                "Retired"
            });

            // Year filter - FIXED: Use RANGE, not sorting
            cmbYear.Items.Clear();
            cmbYear.Items.AddRange(new object[]
            {
                "All Years",
                "2015+",
                "2018+",
                "2020+",
                "2022+",
                "2024+"
            });

            // Fuel type
            cmbFuelType.Items.Clear();
            cmbFuelType.Items.AddRange(new object[]
            {
    "All Fuel Types",
    "Gasoline",
    "Diesel",
    "Electric",
    "Hybrid"
            });


            // Transmission
            cmbTrasmissionType.Items.Clear();
            cmbTrasmissionType.Items.AddRange(new object[]
            {
                "All Transmissions",
                "Automatic",
                "Manual"
            });
        }

        private void LoadCategories()
        {
            try
            {
                var categories = _vehicleService.GetAllCategories();
                cmbVehicleCategory.Items.Clear();
                cmbVehicleCategory.Items.Add("All Categories");

                foreach (var category in categories)
                {
                    cmbVehicleCategory.Items.Add(category.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load categories: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureGrid()
        {
            dgvVehicles.AutoGenerateColumns = false;
            dgvVehicles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehicles.MultiSelect = false;
            dgvVehicles.ReadOnly = true;
            dgvVehicles.Columns.Clear();

            // Add columns with proper DataPropertyName
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Make", DataPropertyName = "Make" });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Model", DataPropertyName = "Model" });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Year", DataPropertyName = "Year" });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Plate No.", DataPropertyName = "LicensePlate" });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Transmission", DataPropertyName = "Transmission" });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fuel", DataPropertyName = "FuelType" });
            dgvVehicles.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    HeaderText = "Status",
                    DataPropertyName = "StatusDisplay"
                });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Odometer", DataPropertyName = "Odometer" });
        }

        private void LoadVehicles()
        {
            ApplyFilters();
        }

        private VehicleStatus? GetSelectedStatus()
        {
            if (cmbStatusFilter.SelectedIndex <= 0)
                return null;

            return cmbStatusFilter.SelectedItem?.ToString() switch
            {
                "Available" => VehicleStatus.Available,
                "Under Maintenance" => VehicleStatus.UnderMaintenance,
                "Rented" => VehicleStatus.Rented,
                "Reserved" => VehicleStatus.Reserved,
                "Retired" => VehicleStatus.Retired,
                _ => null
            };
        }

        private void ApplyFilters()
        {
            var status = GetSelectedStatus();
            _advancedFilter = BuildAdvancedFilter();

            var vehicles = _vehicleService.SearchVehicles(
                status,
                txtSearch.Text,
                _advancedFilter
            );

            dgvVehicles.DataSource = null;
            dgvVehicles.DataSource = vehicles;

            lblVehicleCount.Text = $"Total: {vehicles.Count} vehicles";
            ClearVehiclePreview();

            // Apply any existing sort after loading data
            if (!string.IsNullOrEmpty(_currentSortColumn))
            {
                SortData();
            }
        }

        private VehicleAdvancedFilterDto? BuildAdvancedFilter()
        {
            var filter = new VehicleAdvancedFilterDto();

            // Category filter
            if (cmbVehicleCategory.SelectedIndex > 0 && cmbVehicleCategory.SelectedItem != null)
            {
                try
                {
                    var categoryName = cmbVehicleCategory.SelectedItem.ToString();
                    var categories = _vehicleService.GetAllCategories();
                    var category = categories.FirstOrDefault(c => c.Name == categoryName);

                    if (category != null)
                        filter.CategoryId = category.Id;
                }
                catch
                {
                    // Silently ignore category errors
                }
            }

            // Fuel filter
            if (cmbFuelType.SelectedIndex > 0 && cmbFuelType.SelectedItem != null)
            {
                filter.FuelType = cmbFuelType.SelectedItem.ToString() switch
                {
                    "Gasoline" => FuelType.Gasoline,
                    "Diesel" => FuelType.Diesel,
                    "Electric" => FuelType.Electric,
                    "Hybrid" => FuelType.Hybrid,
                    _ => null
                };

            }

            // Transmission filter
            if (cmbTrasmissionType.SelectedIndex > 0 && cmbTrasmissionType.SelectedItem != null)
            {
                filter.Transmission = cmbTrasmissionType.SelectedItem.ToString() switch
                {
                    "Automatic" => TransmissionType.Automatic,
                    "Manual" => TransmissionType.Manual,
                    _ => null
                };
            }

            // YEAR RANGE - FIXED: Convert UI options to YearFrom/YearTo
            if (cmbYear.SelectedIndex > 0 && cmbYear.SelectedItem != null)
            {
                filter.YearFrom = cmbYear.SelectedItem.ToString() switch
                {
                    "2015+" => 2015,
                    "2018+" => 2018,
                    "2020+" => 2020,
                    "2022+" => 2022,
                    "2024+" => 2024,
                    _ => null
                };

                filter.YearTo = null; // open-ended range
            }

            // Return null if no filters are set (to save performance)
            return filter.CategoryId != null || filter.FuelType != null ||
                   filter.Transmission != null || filter.YearFrom != null ||
                   filter.YearTo != null ? filter : null;
        }

        private void DgvVehicles_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvVehicles.SelectedRows.Count == 0 || dgvVehicles.SelectedRows[0].DataBoundItem is not Vehicle vehicle)
            {
                ClearVehiclePreview();
                return;
            }
            LoadVehiclePreview(vehicle);
        }

        private void LoadVehiclePreview(Vehicle vehicle)
        {
            lblMakeModel.Text = $"{vehicle.Make} {vehicle.Model}";
            lblPlateValue.Text = vehicle.LicensePlate;
            lblMileageValue.Text = $"{vehicle.Odometer:N0} km";
            lblYearColorValue.Text = $"{vehicle.Year}/{vehicle.Color}";
            lblDailyRateValue.Text = vehicle.FuelEfficiency.ToString("N2");

            try
            {
                var category = _vehicleService.GetCategoryById(vehicle.VehicleCategoryId);
                lblCategoryValue.Text = category.Name;
            }
            catch { lblCategoryValue.Text = "Unknown"; }

            lblStatusValue.Text = EnumComboHelper
                .ToComboItems<VehicleStatus>()
                .First(x => x.Value == vehicle.Status)
                .Display;

            lblStatusValue.ForeColor = GetStatusColor(vehicle.Status);

            LoadVehicleImage(vehicle.Id);
            LoadVehicleFeatures(vehicle.Id);
        }

        private Color GetStatusColor(VehicleStatus status) => status switch
        {
            VehicleStatus.Available => Color.FromArgb(46, 204, 113),
            VehicleStatus.Rented => Color.FromArgb(231, 76, 60),
            VehicleStatus.UnderMaintenance => Color.FromArgb(243, 156, 18),
            VehicleStatus.Reserved => Color.FromArgb(155, 89, 182),
            VehicleStatus.Retired => Color.FromArgb(150, 150, 150),
            _ => Color.Gray
        };

        private void LoadVehicleImage(int vehicleId)
        {
            try
            {
                var images = _vehicleService.GetVehicleImages(vehicleId);
                if (images == null || images.Count == 0)
                {
                    picVehiclePreview.Image = null;
                    return;
                }

                var fullPath =
                    Path.Combine(AppContext.BaseDirectory, "Storage", images[0].ImagePath);

                if (!File.Exists(fullPath))
                {
                    picVehiclePreview.Image = null;
                    return;
                }

                using var fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
                picVehiclePreview.Image = Image.FromStream(fs);
            }
            catch
            {
                picVehiclePreview.Image = null;
            }
        }


        private void LoadVehicleFeatures(int vehicleId)
        {
            flowLayoutPanelFeatures.Controls.Clear();
            try
            {
                var features = _vehicleService.GetVehicleFeatures(vehicleId);
                if (features == null || features.Count == 0)
                {
                    flowLayoutPanelFeatures.Controls.Add(new Label { Text = "No features", ForeColor = Color.Gray, AutoSize = true });
                    return;
                }
                foreach (var f in features) flowLayoutPanelFeatures.Controls.Add(CreateFeatureBadge(f.Name));
                lblFeaturesTitle.Text = $"Features ({features.Count})";
            }
            catch (Exception ex) { flowLayoutPanelFeatures.Controls.Add(new Label { Text = ex.Message, AutoSize = true }); }
        }

        private Control CreateFeatureBadge(string name)
        {
            var panel = new Panel { AutoSize = true, BackColor = Color.FromArgb(236, 240, 241), Padding = new Padding(6, 3, 6, 3), Margin = new Padding(2) };
            panel.Controls.Add(new Label { Text = $"✓ {name}", AutoSize = true });
            return panel;
        }

        private void ClearVehiclePreview()
        {
            picVehiclePreview.Image = null;
            lblMakeModel.Text = lblPlateValue.Text = lblMileageValue.Text = "—";
            flowLayoutPanelFeatures.Controls.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var form = new AddVehicleForm(_vehicleService) { StartPosition = FormStartPosition.CenterParent };
            if (form.ShowDialog(this) == DialogResult.OK) LoadVehicles();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvVehicles.SelectedRows.Count == 0 || dgvVehicles.SelectedRows[0].DataBoundItem is not Vehicle v) return;
            using var form = new EditVehicleForm(v.Id, _vehicleService) { StartPosition = FormStartPosition.CenterParent };
            if (form.ShowDialog(this) == DialogResult.OK) LoadVehicles();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            using var form = new AddCategoryForm(_vehicleService) { StartPosition = FormStartPosition.CenterParent };
            form.ShowDialog(this);
        }

        private void BtnRetire_Click(object sender, EventArgs e)
        {
            if (dgvVehicles.SelectedRows.Count == 0 ||
                dgvVehicles.SelectedRows[0].DataBoundItem is not Vehicle vehicle)
            {
                MessageBox.Show(
                    "Please select a vehicle to retire.",
                    "Retire Vehicle",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (vehicle.Status == VehicleStatus.Retired)
            {
                MessageBox.Show(
                    "This vehicle is already retired.",
                    "Retire Vehicle",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show(
                $"Are you sure you want to retire:\n\n" +
                $"{vehicle.Make} {vehicle.Model}\n" +
                $"Plate: {vehicle.LicensePlate}\n\n" +
                "This action is permanent.",
                "Confirm Retirement",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                _vehicleService.RetireVehicle(vehicle.Id);
                LoadVehicles();

                MessageBox.Show(
                    "Vehicle retired successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to retire vehicle:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnUnderMaintenance_Click(object sender, EventArgs e)
        {
            // 1. Ensure a vehicle is selected
            if (dgvVehicles.SelectedRows.Count == 0 ||
                dgvVehicles.SelectedRows[0].DataBoundItem is not Vehicle vehicle)
            {
                MessageBox.Show(
                    "Please select a vehicle first.",
                    "Maintenance",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // 2. Map Vehicle -> SimpleVehicleDto
            var vehicleDto = new VehicleDto
            {
                Id = vehicle.Id,
                Make = vehicle.Make,
                Model = vehicle.Model,
                LicensePlate = vehicle.LicensePlate,
                Status = vehicle.Status
            };

            // 3. Open Maintenance Form
            using var form = new MaintenanceForm(_vehicleService, vehicleDto)
            {
                StartPosition = FormStartPosition.CenterParent
            };

            var result = form.ShowDialog(this);

            // 4. If maintenance form updated vehicle status, persist it
            if (result == DialogResult.OK && form.IsVehicleStatusUpdated())
            {
                LoadVehicles();
            }
        }

        private void btnRetire_Click_1(object sender, EventArgs e)
        {

        }
    }
}