using VRMS.Enums;
using System.Linq;
using VRMS.Forms;
using VRMS.Models.Rentals;
using VRMS.Services.Customer;
using VRMS.Services.Fleet;
using VRMS.Services.Rental;

namespace VRMS.UI.Forms.Rentals
{
    public partial class CompleteRentalForm : Form
    {
        private readonly int _rentalId;
        private readonly RentalService _rentalService;
        private readonly ReservationService _reservationService;
        private readonly VehicleService _vehicleService;
        private readonly CustomerService _customerService;

        private Rental _rental = null!;

        // UI-only billing preview (NOT authoritative)
        private decimal _baseRentalAmount = 0m;
        private decimal _lateFees = 0m;
        private decimal _damageFees = 0m;

        public CompleteRentalForm(
            int rentalId,
            RentalService rentalService,
            ReservationService reservationService,
            VehicleService vehicleService,
            CustomerService customerService)
        {
            InitializeComponent();

            _rentalId = rentalId;
            _rentalService = rentalService;
            _reservationService = reservationService;
            _vehicleService = vehicleService;
            _customerService = customerService;

            Load += ReturnVehicleForm_Load;
            numOdometer.ValueChanged += NumOdometer_ValueChanged;
        }

        // =====================================================
        // FORM LOAD
        // =====================================================
        private void ReturnVehicleForm_Load(object? sender, EventArgs e)
        {
            _rental = _rentalService.GetRentalById(_rentalId);
            var vehicle = _vehicleService.GetVehicleById(_rental.VehicleId);

            Models.Customers.Customer? customer = null;
            if (_rental.ReservationId.HasValue)
            {
                var reservation =
                    _reservationService.GetReservationById(_rental.ReservationId.Value);

                customer =
                    _customerService.GetCustomerById(reservation.CustomerId);
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
        // DAMAGE GRID
        // =====================================================
        private void ConfigureDamageGrid()
        {
            dgvDamages.AutoGenerateColumns = false;
            dgvDamages.Columns.Clear();

            dgvDamages.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Description",
                HeaderText = "Description"
            });

            dgvDamages.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EstimatedCost",
                HeaderText = "Estimated Cost",
                DefaultCellStyle = { Format = "₱ #,##0.00" }
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
            try
            {
                // Ensure return inspection exists
                int inspectionId =
                    _rentalService.CreateOrGetReturnInspection(_rentalId);

                using (var form = new AddDamageForm(inspectionId))
                {
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        // Immediately reload damages and update preview
                        LoadDamages();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Cannot Add Damage",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // INSPECTION CHECKLIST (LINKED)
        // =====================================================
        private void BtnInspectionChecklist_Click(object sender, EventArgs e)
        {
            using (var form = new InspectionChecklistForm(_rentalId, _rentalService))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    // Reload damages & preview (inspection changes might affect billing later)
                    LoadDamages();
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
                _rentalService.CompleteRental(
                    rentalId: _rentalId,
                    actualReturnDate: dtReturns.Value,
                    endOdometer: (int)numOdometer.Value,
                    endFuelLevel: (FuelLevel)cbFuels.SelectedIndex
                );

                using (var paymentForm = new PaymentForm(_rentalId))
                {
                    if (paymentForm.ShowDialog(this) != DialogResult.OK)
                        return;
                }

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
        // 
        private void btnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        
        private void LoadDamages()
        {
            try
            {
                // Ensure return inspection exists
                int inspectionId = _rentalService.CreateOrGetReturnInspection(_rentalId);

                var damages = _rentalService.GetDamagesByInspectionId(inspectionId);

                dgvDamages.Rows.Clear();

                foreach (var d in damages)
                {
                    // Add a row using the columns you defined in ConfigureDamageGrid
                    dgvDamages.Rows.Add(d.Description, d.EstimatedCost);
                }

                // Update UI-only damage fees preview
                _damageFees = damages.Sum(x => x.EstimatedCost);
                UpdateBillingUI();
            }
            catch (Exception ex)
            {
                // Non-fatal: show message but keep form open
                MessageBox.Show(
                    ex.Message,
                    "Cannot load damages",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

    }
}
