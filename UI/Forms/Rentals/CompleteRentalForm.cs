using VRMS.Enums;
using System.Linq;
using VRMS.Forms;
using VRMS.Models.Rentals;
using VRMS.Services.Billing;
using VRMS.Services.Customer;
using VRMS.Services.Fleet;
using VRMS.Services.Rental;
using VRMS.UI.ApplicationService;

namespace VRMS.UI.Forms.Rentals
{
    public partial class CompleteRentalForm : Form
    {
        private readonly int _rentalId;
        private readonly RentalService _rentalService;
        private readonly VehicleService _vehicleService;
        private readonly CustomerService _customerService;
        private readonly RateService _rateService;
        private readonly BillingService _billingService;

        private Rental _rental = null!;

        // UI-only billing preview (NOT authoritative)
        private decimal _baseRentalAmount = 0m;
        private decimal _lateFees = 0m;
        private decimal _damageFees = 0m;

        public CompleteRentalForm(
            int rentalId,
            RentalService rentalService,
            VehicleService vehicleService,
            CustomerService customerService,
            RateService rateService,
            BillingService billingService)
        {
            InitializeComponent();

            _rentalId = rentalId;
            _rentalService = rentalService;
            _vehicleService = vehicleService;
            _customerService = customerService;
            _rateService = rateService;
            _billingService = billingService;

            Load += ReturnVehicleForm_Load;
            numOdometer.ValueChanged += NumOdometer_ValueChanged;
            dtReturns.ValueChanged += DtReturns_ValueChanged;

            // ADD THIS: Enable double-click to open damage details
            dgvDamages.CellDoubleClick += (_, __) =>
                btnViewDamageDetails_Click(_, __);
        }

        // =====================================================
        // FORM LOAD
        // =====================================================
        private void ReturnVehicleForm_Load(object? sender, EventArgs e)
        {
            _rental = _rentalService.GetRentalById(_rentalId);
            var vehicle = _vehicleService.GetVehicleById(_rental.VehicleId);

            Models.Customers.Customer? customer = null;

            if (_rental.CustomerId.HasValue)
            {
                customer =
                    _customerService.GetCustomerById(_rental.CustomerId.Value);
            }

            lblRentalId.Text = $"Rental #: {_rental.Id}";
            lblVehicleInfo.Text = $"Vehicle: {vehicle.Year} {vehicle.Make} {vehicle.Model}";
            lblCustomerInfo.Text = customer == null
                ? "Customer: Walk-in"
                : $"Customer: {customer.FirstName} {customer.LastName}";

            dtReturns.Value = DateTime.Now;

            // Odometer rules
            numOdometer.Minimum = _rental.StartOdometer + 1;
            numOdometer.Maximum = 10_000_000;
            numOdometer.Value = _rental.StartOdometer + 1;

            // Fuel
            cbFuels.SelectedIndex = (int)_rental.StartFuelLevel;

            // Billing preview starts at ZERO
            _baseRentalAmount = 0m;
            _lateFees = 0m;
            _damageFees = 0m;

            DtReturns_ValueChanged(null, EventArgs.Empty);

            ConfigureDamageGrid();
            UpdateBillingUI();
            LoadDamages();
        }

        // =====================================================
        // ODOMETER VALIDATION
        // =====================================================
        private void NumOdometer_ValueChanged(object? sender, EventArgs e)
        {
            if (numOdometer.Value <= _rental.StartOdometer)
            {
                numOdometer.Value = _rental.StartOdometer + 1;
            }
        }

        // =====================================================
        // DAMAGE GRID - FIXED VERSION
        // =====================================================
        private void ConfigureDamageGrid()
        {
            dgvDamages.AutoGenerateColumns = false;
            dgvDamages.Columns.Clear();
            dgvDamages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDamages.MultiSelect = false;
            dgvDamages.ReadOnly = true;

            // HIDDEN: DamageReportId (CRITICAL FOR BUTTON TO WORK)
            dgvDamages.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DamageId",
                Visible = false
            });

            dgvDamages.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Description",
                HeaderText = "Description",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvDamages.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EstimatedCost",
                HeaderText = "Estimated Cost",
                DefaultCellStyle = { Format = "₱ #,##0.00" },
                Width = 150
            });
        }

        // =====================================================
        // BILLING PREVIEW (UI ONLY)
        // =====================================================
        private void UpdateBillingUI()
        {
            decimal subtotal = _baseRentalAmount + _lateFees + _damageFees;

            lblBaseRentalValue.Text = $"₱ {_baseRentalAmount:N2}";
            lblLateFeesValue.Text = $"₱ {_lateFees:N2}";
            lblDamageFeesValue.Text = $"₱ {_damageFees:N2}";
            lblSubtotalValue.Text = $"₱ {subtotal:N2}";
            lblTotalValue.Text = $"₱ {subtotal:N2}";
        }

        // =====================================================
        // QUICK CALCULATIONS (DISABLED FOR NOW)
        // =====================================================
        private void BtnCalculateLateFees_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Late fee preview not implemented yet.",
                "Info",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BtnCalculateDamage_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Damage preview not implemented yet.",
                "Info",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // =====================================================
        // ADD DAMAGE (LINKED)
        // =====================================================
        private void BtnAddDamage_Click(object? sender, EventArgs e)
        {
            using (var form = new AddDamageForm(
                       _rentalId,
                       _rentalService,
                       _vehicleService,
                       ApplicationServices.DamageService))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadDamages(); // refresh grid after adding
                }
            }
        }



        // =====================================================
        // COMPLETE RETURN (AUTHORITATIVE)
        // =====================================================
        private void btnCompleteReturn_Click(object sender, EventArgs e)
        {
            if (cbFuels.SelectedIndex < 0)
            {
                MessageBox.Show("Please select fuel level.");
                return;
            }

            try
            {
                // Ensure invoice exists (NO state change)
                _billingService.GetOrCreateInvoice(_rentalId);

                // Show payment form FIRST
                using (var paymentForm = new PaymentForm(_rentalId))
                {
                    if (paymentForm.ShowDialog(this) != DialogResult.OK)
                        return; // DO NOTHING if payment cancelled
                }

                // NOW finalize rental (AUTHORITATIVE)
                _rentalService.CompleteRental(
                    rentalId: _rentalId,
                    actualReturnDate: dtReturns.Value,
                    endOdometer: (int)numOdometer.Value,
                    endFuelLevel: (FuelLevel)cbFuels.SelectedIndex
                );

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Return Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // CANCEL
        // =====================================================
        private void btnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // =====================================================
        // LOAD DAMAGES - FIXED VERSION
        // =====================================================
        private void LoadDamages()
        {
            dgvDamages.Rows.Clear();
            _damageFees = 0m;

            var damages =
                ApplicationServices.DamageService
                    .GetDamagesByRental(_rentalId);

            foreach (var damage in damages)
            {
                dgvDamages.Rows.Add(
                    damage.Id,                 // Hidden DamageId
                    damage.Description,
                    damage.EstimatedCost
                );

                _damageFees += damage.EstimatedCost;
            }

            UpdateBillingUI();
        }



      
        private void DtReturns_ValueChanged(object? sender, EventArgs e)
        {
            try
            {
                var vehicle =
                    _vehicleService.GetVehicleById(_rental.VehicleId);

                _lateFees =
                    _rateService.CalculateLatePenalty(
                        _rental.ExpectedReturnDate,
                        dtReturns.Value,
                        vehicle.VehicleCategoryId);

                UpdateBillingUI();
            }
            catch
            {
                _lateFees = 0m;
                UpdateBillingUI();
            }
        }

        // =====================================================
        // VIEW DAMAGE DETAILS - FIXED VERSION (NOW WORKS!)
        // =====================================================
        private void btnViewDamageDetails_Click(object sender, EventArgs e)
        {
            if (dgvDamages.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select a damage record first.",
                    "No Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int damageId =
                Convert.ToInt32(
                    dgvDamages.CurrentRow.Cells["DamageId"].Value);

            using (var form =
                   new VRMS.UI.Forms.Damages.DamageReportDetails(
                       damageId,
                       ApplicationServices.DamageService))
            {
                form.ShowDialog(this);
            }

            LoadDamages();
        }

    }
}