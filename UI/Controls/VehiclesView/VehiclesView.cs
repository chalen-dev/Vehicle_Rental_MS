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

        public VehiclesView()
        {
            InitializeComponent();

            _vehicleService = ApplicationServices.VehicleService;
            _driversLicenseService = ApplicationServices.DriversLicenseService;
            _customerService = ApplicationServices.CustomerService;
            _rentalService = ApplicationServices.RentalService;

            Load += VehiclesView_Load;
            dgvVehicles.SelectionChanged += DgvVehicles_SelectionChanged;

            flowLayoutPanelFeatures.AutoSize = true;
            flowLayoutPanelFeatures.WrapContents = true;

            cmbStatusFilter.SelectedIndexChanged += CmbStatusFilter_SelectedIndexChanged;
            cmbAdvancedFilter.SelectedIndexChanged += CmbAdvancedFilter_SelectedIndexChanged;
            txtSearch.TextChanged += (_, _) => ApplyFilters();
            
            btnUnderMaintenance.Click += btnUnderMaintenance_Click;
        }


        private void CmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void CmbAdvancedFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAdvancedFilter.SelectedItem != null)
            {
                var selectedFilter = cmbAdvancedFilter.SelectedItem.ToString();
                ApplyAdvancedFilter(selectedFilter);
            }
        }

        private void ApplyAdvancedFilter(string filter)
        {
            // Implement advanced filtering based on the selected filter
            switch (filter)
            {
                case "Advanced Filters":
                    // Reset to all vehicles
                    ApplyFilters();
                    break;
                case "By Location":
                    ShowLocationFilterDialog();
                    break;
                case "By Year":
                    ShowYearFilterDialog();
                    break;
                case "By Price Range":
                    ShowPriceRangeFilterDialog();
                    break;
                case "By Category":
                    ShowCategoryFilterDialog();
                    break;
                case "By Fuel Type":
                    ShowFuelTypeFilterDialog();
                    break;
                case "By Transmission":
                    ShowTransmissionFilterDialog();
                    break;
            }
        }

        private void ShowLocationFilterDialog()
        {
            MessageBox.Show("Location filter - Implement location selection dialog", "Filter by Location",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowYearFilterDialog()
        {
            MessageBox.Show("Year filter - Implement year range selection", "Filter by Year",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowPriceRangeFilterDialog()
        {
            MessageBox.Show("Price range filter - Implement price range selection", "Filter by Price Range",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowCategoryFilterDialog()
        {
            try
            {
                var categories = _vehicleService.GetAllCategories();
                if (categories.Count == 0)
                {
                    MessageBox.Show("No categories available", "Filter by Category",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                MessageBox.Show($"Select from {categories.Count} categories - Implement category selection",
                    "Filter by Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowFuelTypeFilterDialog()
        {
            MessageBox.Show("Fuel type filter - Implement fuel type selection", "Filter by Fuel Type",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowTransmissionFilterDialog()
        {
            MessageBox.Show("Transmission filter - Implement transmission type selection", "Filter by Transmission",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        private void VehiclesView_Load(object? sender, EventArgs e)
        {
            ConfigureGrid();
            LoadVehicles();

            // Set default selections
            cmbStatusFilter.SelectedIndex = 0;
            cmbAdvancedFilter.SelectedIndex = 0;
        }

        private void ConfigureGrid()
        {
            dgvVehicles.AutoGenerateColumns = false;
            dgvVehicles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehicles.MultiSelect = false;
            dgvVehicles.ReadOnly = true;
            dgvVehicles.Columns.Clear();

            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Make", DataPropertyName = "Make" });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Model", DataPropertyName = "Model" });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Year", DataPropertyName = "Year" });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Plate No.", DataPropertyName = "LicensePlate" });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Transmission", DataPropertyName = "Transmission" });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fuel", DataPropertyName = "FuelType" });
            dgvVehicles.Columns.Add(
                new DataGridViewTextBoxColumn {
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
            return cmbStatusFilter.SelectedIndex switch
            {
                0 => null, // All Vehicles
                1 => VehicleStatus.Available,
                2 => VehicleStatus.UnderMaintenance,
                3 => VehicleStatus.Rented,
                4 => VehicleStatus.Reserved,
                5 => VehicleStatus.Retired,
                _ => null
            };
        }

        private void ApplyFilters()
        {
            var status = GetSelectedStatus();
            var vehicles = _vehicleService.SearchVehicles(
                status,
                txtSearch.Text
            );

            dgvVehicles.DataSource = null;
            dgvVehicles.DataSource = vehicles;

            lblVehicleCount.Text = $"Total: {vehicles.Count} vehicles";
            ClearVehiclePreview();
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
                var updatedStatus = form.GetUpdatedVehicleStatus();

                _vehicleService.UpdateVehicleStatus(
                    vehicle.Id,
                    (VehicleStatus)updatedStatus
                );

                LoadVehicles();
            }
        }



    }
}