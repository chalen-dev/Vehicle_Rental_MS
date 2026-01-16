using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VRMS.Enums;
using VRMS.Models.Billing;
using VRMS.Services.Rental;
using VRMS.Services.Customer;
using VRMS.Services.Fleet;
using VRMS.UI.ApplicationService;

namespace VRMS.UI.Controls.History
{
    public partial class History : UserControl
    {
        private readonly RentalService _rentalService;
        private readonly CustomerService _customerService;
        private readonly VehicleService _vehicleService;
        private Invoice? _selectedInvoice;
        private Payment? _lastPayment;

        private static readonly string PlaceholderImagePath =
            Path.Combine(AppContext.BaseDirectory, "Assets", "img_placeholder.png");

        // 🔒 CRITICAL STATE GUARDS
        private bool _suspendSelectionEvents;
        private int? _lastSelectedRentalId;

        public History()
        {
            InitializeComponent();

            _rentalService = ApplicationServices.RentalService;
            _customerService = ApplicationServices.CustomerService;
            _vehicleService = ApplicationServices.VehicleService;

            Load += History_Load;
            dgvRentals.SelectionChanged += DgvRentals_SelectionChanged;

            btnViewReceipt.Click += BtnViewReceipt_Click;
            btnRefund.Click += BtnRefund_Click;
        }

        // =====================================================
        // LOAD
        // =====================================================

        private void History_Load(object sender, EventArgs e)
        {
            ConfigureRentalsGrid();
            LoadRentals();
            ResetDetails();
        }

        // =====================================================
        // GRID SETUP
        // =====================================================

        private void ConfigureRentalsGrid()
        {
            dgvRentals.AutoGenerateColumns = false;
            dgvRentals.Columns.Clear();
            dgvRentals.ReadOnly = true;
            dgvRentals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRentals.MultiSelect = false;

            dgvRentals.Columns.Add("Id", "ID");
            dgvRentals.Columns.Add("Vehicle", "Vehicle");
            dgvRentals.Columns.Add("Dates", "Dates");
            dgvRentals.Columns.Add("Status", "Status");
            dgvRentals.Columns.Add("Amount", "Amount");
            dgvRentals.Columns.Add("Odometer", "Odometer");

            dgvRentals.Columns["Id"].Width = 60;
            dgvRentals.Columns["Status"].Width = 100;

            dgvRentals.CellFormatting += DgvRentals_CellFormatting;
        }

        // =====================================================
        // LOAD DATA
        // =====================================================

        private void LoadRentals()
        {
            dgvRentals.Rows.Clear();

            var rentals = _rentalService
                .GetAllRentals()
                .OrderByDescending(r => r.PickupDate)
                .ToList();

            foreach (var r in rentals)
            {
                var vehicle = _vehicleService.GetVehicleById(r.VehicleId);

                dgvRentals.Rows.Add(
                    r.Id,
                    $"{vehicle.Make} {vehicle.Model}",
                    $"{r.PickupDate:MMM dd, yyyy} → {r.ExpectedReturnDate:MMM dd, yyyy}",
                    r.Status.ToString(),
                    "—",
                    r.EndOdometer?.ToString() ?? "-"
                );
            }

            lblSummary.Text = $"Total Rentals: {rentals.Count}";
        }

        // =====================================================
        // STATUS STYLING
        // =====================================================

        private void DgvRentals_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRentals.Columns[e.ColumnIndex].Name != "Status")
                return;

            if (e.Value is not string status)
                return;

            e.CellStyle.Font = new Font(dgvRentals.Font, FontStyle.Bold);

            e.CellStyle.ForeColor = status switch
            {
                nameof(RentalStatus.Active) => Color.Green,
                nameof(RentalStatus.Late) => Color.OrangeRed,
                nameof(RentalStatus.Completed) => Color.Gray,
                nameof(RentalStatus.Cancelled) => Color.DarkGray,
                _ => e.CellStyle.ForeColor
            };
        }

        // =====================================================
        // SELECTION → DETAILS (SAFE)
        // =====================================================

        private void DgvRentals_SelectionChanged(object sender, EventArgs e)
        {
            // 🔥 HARD GUARDS (NON-NEGOTIABLE)
            if (_suspendSelectionEvents)
                return;

            if (!IsHandleCreated || IsDisposed || !Visible)
                return;

            if (dgvRentals.SelectedRows.Count == 0)
            {
                ResetDetails();
                _lastSelectedRentalId = null;
                return;
            }

            int rentalId =
                Convert.ToInt32(
                    dgvRentals.SelectedRows[0].Cells["Id"].Value);

            // 🔒 Prevent re-entering same selection
            if (_lastSelectedRentalId == rentalId)
                return;

            _lastSelectedRentalId = rentalId;

            var rental = _rentalService.GetRentalById(rentalId);
            var billingService = ApplicationServices.BillingService;

            // Load invoice (may be null)
            _selectedInvoice = billingService.GetInvoiceByRental(rentalId);

            _lastPayment = null;

            if (_selectedInvoice != null)
            {
                var payments =
                    billingService.GetPaymentsByInvoice(_selectedInvoice.Id);

                // Get the most recent NON-refund payment
                _lastPayment = payments
                    .Where(p => p.PaymentType != PaymentType.Refund)
                    .OrderByDescending(p => p.PaymentDate)
                    .FirstOrDefault();
            }

            var vehicle = _vehicleService.GetVehicleById(rental.VehicleId);

            string customerName = "Walk-in";
            if (rental.CustomerId.HasValue)
            {
                var customer =
                    _customerService.GetCustomerById(rental.CustomerId.Value);
                customerName = $"{customer.FirstName} {customer.LastName}";
            }

            lblReservationIdValue.Text = rental.Id.ToString();
            lblStatusValue.Text = rental.Status.ToString();
            lblDatesValue.Text = $"{rental.PickupDate:d} → {rental.ExpectedReturnDate:d}";
            lblCustomerValue.Text = customerName;
            lblVehicleName.Text = $"{vehicle.Make} {vehicle.Model}";
            lblAmountValue.Text = "—";
            lblPaymentValue.Text = "—";
            lblCreatedValue.Text = rental.PickupDate.ToString("yyyy-MM-dd");

            LoadVehicleImage(vehicle.Id);

            panelNoSelection.Visible = false;
            panelDetailsContent.Visible = true;

            btnViewReceipt.Enabled = true;
            btnRefund.Enabled =
                _selectedInvoice != null &&
                _lastPayment != null &&
                _selectedInvoice.TotalAmount > 0m;
        }

        // =====================================================
        // VEHICLE IMAGE (SAFE)
        // =====================================================

        private void LoadVehicleImage(int vehicleId)
        {
            if (picVehicle.Image != null)
            {
                var old = picVehicle.Image;
                picVehicle.Image = null;
                old.Dispose();
            }

            var images = _vehicleService.GetVehicleImages(vehicleId);

            string imagePath =
                images.Count > 0
                    ? Path.Combine(AppContext.BaseDirectory, "Storage", images[0].ImagePath)
                    : PlaceholderImagePath;

            if (!File.Exists(imagePath))
                return;

            using var fs =
                new FileStream(imagePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var temp = Image.FromStream(fs);
            picVehicle.Image = new Bitmap(temp); // CLONE
        }

        // =====================================================
        // BUTTONS (CRASH-PROOF)
        // =====================================================

        private void BtnViewReceipt_Click(object sender, EventArgs e)
        {
            if (dgvRentals.SelectedRows.Count == 0)
                return;

            int rentalId =
                Convert.ToInt32(
                    dgvRentals.SelectedRows[0].Cells["Id"].Value);

            _suspendSelectionEvents = true;

            try
            {
                using (var form =
                       new VRMS.UI.Forms.Receipts.ReceiptForm(rentalId))
                {
                    form.ShowDialog(this); // ✅ NOT FindForm()
                }
            }
            finally
            {
                dgvRentals.ClearSelection();
                ResetDetails();

                // Delay re-enabling until UI stabilizes
                BeginInvoke(new Action(() =>
                {
                    _suspendSelectionEvents = false;
                    _lastSelectedRentalId = null;
                }));
            }
        }

        private void BtnRefund_Click(object sender, EventArgs e)
        {
            if (_selectedInvoice == null || _lastPayment == null)
            {
                MessageBox.Show(
                    "No refundable payment found.",
                    "Refund",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var rentalId =
                Convert.ToInt32(dgvRentals.SelectedRows[0].Cells["Id"].Value);

            var rental =
                _rentalService.GetRentalById(rentalId);

            var vehicle =
                _vehicleService.GetVehicleById(rental.VehicleId);

            string customerName = "Walk-in";
            if (rental.CustomerId.HasValue)
            {
                var customer =
                    _customerService.GetCustomerById(rental.CustomerId.Value);
                customerName = $"{customer.FirstName} {customer.LastName}";
            }

            using var form = new VRMS.UI.Forms.Payments.RefundForm(
                transactionId: _lastPayment.Id,
                customer: customerName,
                vehicle: $"{vehicle.Make} {vehicle.Model}",
                originalAmount: _lastPayment.Amount,
                paymentMethod: _lastPayment.PaymentMethod.ToString(),
                transactionDate: _lastPayment.PaymentDate
            );

            if (form.ShowDialog(FindForm()) != DialogResult.OK)
                return;

            try
            {
                ApplicationServices.BillingService.IssueRefund(
                    invoiceId: _selectedInvoice.Id,
                    amount: _lastPayment.Amount,
                    method: _lastPayment.PaymentMethod,
                    date: DateTime.UtcNow
                );

                MessageBox.Show(
                    "Refund issued successfully.",
                    "Refund",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadRentals();
                ResetDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Refund Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =====================================================
        // RESET
        // =====================================================

        private void ResetDetails()
        {
            panelDetailsContent.Visible = false;
            panelNoSelection.Visible = true;
        }
    }
}
