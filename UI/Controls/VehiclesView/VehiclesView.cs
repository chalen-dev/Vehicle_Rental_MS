using System;
using System.Windows.Forms;
using VRMS.Enums;
using VRMS.Forms;
using VRMS.Models.Fleet;


using VRMS.Services.Vehicle;
using VRMS.Services.Customer;
using VRMS.Services.Rental;

namespace VRMS.Controls
{
    public partial class VehiclesView : UserControl
    {
        // =========================
        // SERVICES
        // =========================

        private readonly VehicleService _vehicleService;
        private readonly DriversLicenseService _driversLicenseService;
        private readonly CustomerService _customerService;
        private readonly ReservationService _reservationService;
        private readonly RentalService _rentalService;

        // =========================
        // CONSTRUCTOR
        // =========================

        public VehiclesView()
        {
            InitializeComponent();

            // 🔹 Base services
            _vehicleService = new VehicleService();
            _driversLicenseService = new DriversLicenseService();

            // 🔹 Depends on DriversLicenseService
            _customerService = new CustomerService(_driversLicenseService);

            // 🔹 Depends on Customer + Vehicle
            _reservationService = new ReservationService(
                _customerService,
                _vehicleService
            );

            // 🔹 Depends on Reservation + Vehicle
            _rentalService = new RentalService(
                _reservationService,
                _vehicleService
            );

            Load += VehiclesView_Load;
        }

        // =========================
        // LOAD
        // =========================

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

            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Make",
                DataPropertyName = "Make"
            });

            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Model",
                DataPropertyName = "Model"
            });

            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Year",
                DataPropertyName = "Year"
            });

            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Plate No.",
                DataPropertyName = "LicensePlate"
            });

            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Transmission",
                DataPropertyName = "Transmission"
            });

            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Fuel",
                DataPropertyName = "FuelType"
            });

            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Status",
                DataPropertyName = "Status"
            });

            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Odometer",
                DataPropertyName = "Odometer"
            });
        }

        private void LoadVehicles()
        {
            try
            {
                dgvVehicles.DataSource = null;
                dgvVehicles.DataSource = _vehicleService.GetAllVehicles();
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
        // ADD VEHICLE
        // =========================

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var addForm = new AddVehicleForm
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (addForm.ShowDialog(this) == DialogResult.OK)
            {
                LoadVehicles();
            }
        }

        // =========================
        // EDIT VEHICLE
        // =========================

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvVehicles.SelectedRows.Count == 0)
                return;

            if (dgvVehicles.SelectedRows[0].DataBoundItem is not Vehicle vehicle)
                return;

            using var editForm = new EditVehicleForm(vehicle.Id)
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (editForm.ShowDialog(this) == DialogResult.OK)
            {
                LoadVehicles();
            }
        }
    }
}
