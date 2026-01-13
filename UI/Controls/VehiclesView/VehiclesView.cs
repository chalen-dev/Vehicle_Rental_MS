using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VRMS.Enums;
using VRMS.Forms;
using VRMS.Models.Fleet;
using VRMS.Repositories.Accounts;
using VRMS.Repositories.Billing;
using VRMS.Repositories.Fleet;
using VRMS.Repositories.Rentals;
using VRMS.Repositories.Inspections; // Added
using VRMS.Repositories.Damages;     // Added
using VRMS.Services.Account;
using VRMS.Services.Customer;
using VRMS.Services.Fleet;
using VRMS.Services.Rental;
using VRMS.UI.Forms;

namespace VRMS.Controls
{
    public partial class VehiclesView : UserControl
    {
        private readonly VehicleService _vehicleService;
        private readonly DriversLicenseService _driversLicenseService;
        private readonly CustomerService _customerService;
        private readonly ReservationService _reservationService;
        private readonly RentalService _rentalService;
        private readonly VehicleImageRepository _vehicleImageRepo;
        private VehicleStatus? _statusFilter = null;

        public VehiclesView()
        {
            InitializeComponent();

            // -------------------------
            // Repositories
            // -------------------------
            var vehicleRepo = new VehicleRepository();
            var categoryRepo = new VehicleCategoryRepository();
            var featureRepo = new VehicleFeatureRepository();
            var featureMapRepo = new VehicleFeatureMappingRepository();
            var imageRepo = new VehicleImageRepository();
            var maintenanceRepo = new MaintenanceRepository();
            var reservationRepo = new ReservationRepository();
            var rentalRepo = new RentalRepository();
            var rateConfigRepo = new RateConfigurationRepository();

            // NEW REPOSITORIES FOR RENTALSERVICE
            var inspectionRepo = new VehicleInspectionRepository();
            var damageRepo = new DamageRepository();
            var damageReportRepo = new DamageReportRepository();

            _vehicleImageRepo = imageRepo;

            // -------------------------
            // Services
            // -------------------------
            _vehicleService = new VehicleService(
                vehicleRepo, categoryRepo, featureRepo,
                featureMapRepo, imageRepo, maintenanceRepo, rateConfigRepo);

            _driversLicenseService = new DriversLicenseService();
            var customerAccountRepo = new CustomerAccountRepository();
            var customerAccountService = new CustomerAccountService(customerAccountRepo);

            _customerService = new CustomerService(_driversLicenseService, customerAccountService);

            _reservationService = new ReservationService(_customerService, _vehicleService, reservationRepo);

            // UPDATED WITH ALL 7 ARGUMENTS
            _rentalService = new RentalService(
                _reservationService,
                _vehicleService,
                rentalRepo,
                null,               // BillingService
                inspectionRepo,     // Added
                damageRepo,         // Added
                damageReportRepo    // Added
            );

            Load += VehiclesView_Load;
            dgvVehicles.SelectionChanged += DgvVehicles_SelectionChanged;

            flowLayoutPanelFeatures.AutoSize = true;
            flowLayoutPanelFeatures.WrapContents = true;
            
            // -------------------------
            // FILTER WIRING
            // -------------------------

            btnAll.Click += (_, _) => SetStatusFilter(null);
            btnAvailable.Click += (_, _) => SetStatusFilter(VehicleStatus.Available);
            btnRented.Click += (_, _) => SetStatusFilter(VehicleStatus.Rented);
            btnMaintenance.Click += (_, _) => SetStatusFilter(VehicleStatus.UnderMaintenance);
            btnReserved.Click += (_, _) => SetStatusFilter(VehicleStatus.Reserved);

            // Live search
            txtSearch.TextChanged += (_, _) => ApplyFilters();
        }

        private void VehiclesView_Load(object? sender, EventArgs e)
        {
            ConfigureGrid();
            LoadVehicles();
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
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Status", DataPropertyName = "Status" });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Odometer", DataPropertyName = "Odometer" });
        }

        private void LoadVehicles()
        {
            ApplyFilters();
        }
        
        private void SetStatusFilter(VehicleStatus? status)
        {
            _statusFilter = status;
            ApplyFilters();
        }
        
        private void ApplyFilters()
        {
            var vehicles = _vehicleService.SearchVehicles(
                _statusFilter,
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

            lblStatusValue.Text = vehicle.Status.ToString();
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
            _ => Color.Gray
        };

        private void LoadVehicleImage(int vehicleId)
        {
            try
            {
                var images = _vehicleImageRepo.GetByVehicle(vehicleId);
                if (images == null || images.Count == 0) { picVehiclePreview.Image = null; return; }

                var fullPath = Path.Combine(AppContext.BaseDirectory, "Storage", images[0].ImagePath);
                if (!File.Exists(fullPath)) { picVehiclePreview.Image = null; return; }

                using var fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
                picVehiclePreview.Image = Image.FromStream(fs);
            }
            catch { picVehiclePreview.Image = null; }
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
    }
}