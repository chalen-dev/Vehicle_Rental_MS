using System;
using System.Windows.Forms;
using VRMS.Services.Fleet;
using VRMS.Services.Billing;
using VRMS.Repositories.Fleet;
using VRMS.Repositories.Billing;
using VRMS.Models.Fleet;
using VRMS.UI.Forms.Select;

namespace VRMS.UI.Forms.Rentals
{
    public partial class CustomerRentalForm : Form
    {
        private readonly VehicleService _vehicleService;
        private readonly RateService _rateService;

        private Vehicle? _selectedVehicle;

        public CustomerRentalForm()
        {
            InitializeComponent();

            // ---------------- SERVICES ----------------
            _vehicleService = new VehicleService(
                new VehicleRepository(),
                new VehicleCategoryRepository(),
                new VehicleFeatureRepository(),
                new VehicleFeatureMappingRepository(),
                new VehicleImageRepository(),
                new MaintenanceRepository(),
                new RateConfigurationRepository()
            );

            _rateService = new RateService(
                new RateConfigurationRepository()
            );

            InitializeState();

            // ⚠️ DO NOT re-wire btnSelectVehicle here
            // Designer already wires it
            btnClearVehicle.Click += btnClearVehicle_Click;

            dtPickup.ValueChanged += (_, __) => Recalculate();
            dtReturn.ValueChanged += (_, __) => Recalculate();
        }

        // =========================
        // INITIAL UI STATE
        // =========================
        private void InitializeState()
        {
            lblSelectedVehicle.Text = "Not selected...";
            lblVehicleInfo.Text = string.Empty;
            lblVehiclePrice.Text = string.Empty;

            btnClearVehicle.Visible = false;
            btnSave.Enabled = false;

            lblDailyRate.Visible = false;
            lblDays.Visible = false;
            lblTotalDays.Visible = false;
            lblDuration.Visible = false;

            lblTotal.Text = "Total: ₱0.00";

            dtPickup.Value = DateTime.Today;
            dtReturn.Value = DateTime.Today.AddDays(1);
        }

        // =========================
        // STEP 1 — SELECT VEHICLE
        // =========================
        private void btnSelectVehicle_Click(object sender, EventArgs e)
        {
            using (var selectVehicleForm = new SelectVehicleForm(_vehicleService))
            {
                selectVehicleForm.StartPosition = FormStartPosition.CenterParent;

                var result = selectVehicleForm.ShowDialog(this);

                if (result != DialogResult.OK)
                    return;

                _selectedVehicle = selectVehicleForm.SelectedVehicle;

                if (_selectedVehicle != null)
                {
                    ApplySelectedVehicle(_selectedVehicle);
                }
            }
        }

        private void btnClearVehicle_Click(object sender, EventArgs e)
        {
            _selectedVehicle = null;
            InitializeState();
        }

        // =========================
        // AFTER VEHICLE SELECTION
        // =========================
        private void ApplySelectedVehicle(Vehicle vehicle)
        {
            lblSelectedVehicle.Text =
                $"{vehicle.Make} {vehicle.Model} ({vehicle.LicensePlate})";

            lblVehicleInfo.Text =
                $"{vehicle.Make} {vehicle.Model}";

            btnClearVehicle.Visible = true;

            lblDailyRate.Visible = true;
            lblDays.Visible = true;
            lblTotalDays.Visible = true;
            lblDuration.Visible = true;

            Recalculate();
        }

        // =========================
        // STEP 2 — CALCULATE TOTAL
        // =========================
        private void Recalculate()
        {
            if (_selectedVehicle == null)
            {
                lblTotal.Text = "Total: ₱0.00";
                btnSave.Enabled = false;
                return;
            }

            if (dtReturn.Value <= dtPickup.Value)
            {
                btnSave.Enabled = false;
                return;
            }

            try
            {
                decimal total = _rateService.CalculateRentalCost(
                    dtPickup.Value,
                    dtReturn.Value,
                    _selectedVehicle.VehicleCategoryId
                );

                int days = (int)Math.Ceiling(
                    (dtReturn.Value.Date - dtPickup.Value.Date).TotalDays
                );

                lblTotalDays.Text = days.ToString();
                lblDuration.Text = $"{days} day(s)";
                lblTotal.Text = $"Total: ₱ {total:N2}";

                btnSave.Enabled = true;
            }
            catch
            {
                btnSave.Enabled = false;
            }
        }
    }
}
