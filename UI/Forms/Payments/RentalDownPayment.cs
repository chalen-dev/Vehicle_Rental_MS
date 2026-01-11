using System;
using System.Windows.Forms;

namespace VRMS.Forms.Payments
{
    public partial class RentalDownPayment : Form
    {
        private readonly string _customerName;
        private readonly string _vehicleName;
        private readonly decimal _totalAmount;

        // ✅ Constructor used by NewRentalForm
        public RentalDownPayment(
            string customerName,
            string vehicleName,
            decimal totalAmount)
        {
            InitializeComponent();

            _customerName = customerName;
            _vehicleName = vehicleName;
            _totalAmount = totalAmount;

            Load += RentalDownPayment_Load;

            btnProcess.Click += BtnProcess_Click;
            btnCancel.Click += (_, __) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };
        }

        // ✅ Keep parameterless constructor for designer safety
        public RentalDownPayment()
        {
            InitializeComponent();
        }

        // -------------------------------
        // LOAD DATA INTO UI
        // -------------------------------
        private void RentalDownPayment_Load(object? sender, EventArgs e)
        {
            // Rental summary
            lblCustomerName.Text = $"Customer: {_customerName}";
            lblVehicleDetails.Text = $"Vehicle: {_vehicleName}";
            lblRentalID.Text = "Rental ID: (Pending)";
            lblReturnDate.Text = "Return Date: (Pending)";

            // Initial cost breakdown (temporary logic)
            decimal securityDeposit = 0m;     // TODO: configure later
            decimal initialRentalFee = _totalAmount;

            lblFirstInstallment.Text =
                $"Initial Rental Fee: ₱{initialRentalFee:N2}";

            lblSecurityDeposit.Text =
                $"Security Deposit: ₱{securityDeposit:N2}";

            lblTotalInitialPayment.Text =
                $"TOTAL DUE: ₱{(initialRentalFee + securityDeposit):N2}";
        }

        // -------------------------------
        // CONFIRM PAYMENT
        // -------------------------------
        private void BtnProcess_Click(object? sender, EventArgs e)
        {
            if (cbPaymentMethod.SelectedItem == null)
            {
                MessageBox.Show(
                    "Please select a payment method.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtAmountPaid.Text, out var amountPaid) ||
                amountPaid <= 0)
            {
                MessageBox.Show(
                    "Please enter a valid payment amount.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // TODO: Integrate BillingService.AddPayment()

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
