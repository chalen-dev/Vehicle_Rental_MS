using VRMS.Enums;

namespace VRMS.UI.Forms.Payments
{
    public partial class RentalDownPayment : Form
    {
        private readonly string _customerName;
        private readonly string _vehicleName;
        private readonly decimal _initialRentalFee;
        private readonly decimal _securityDeposit;
        
        public decimal PaidAmount { get; private set; }
        public PaymentMethod? SelectedPaymentMethod { get; private set; }
        public int? InvoiceId { get; private set; } // optional, only if you want to display it


        // ✅ Constructor used by NewRentalForm
        public RentalDownPayment(
            string customerName,
            string vehicleName,
            decimal initialRentalFee,
            decimal securityDeposit)
        {
            InitializeComponent();

            _customerName = customerName;
            _vehicleName = vehicleName;
            _initialRentalFee = initialRentalFee;
            _securityDeposit = securityDeposit;

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
            lblCustomerName.Text = $"Customer: {_customerName}";
            lblVehicleDetails.Text = $"Vehicle: {_vehicleName}";
            lblRentalID.Text = "Rental ID: (Pending)";
            lblReturnDate.Text = "Return Date: (Pending)";

            lblFirstInstallment.Text =
                $"Initial Rental Fee: ₱{_initialRentalFee:N2}";

            lblTotalInitialPayment.Text =
                $"SECURITY DEPOSIT DUE: ₱{_securityDeposit:N2}";

            cbPaymentMethod.DataSource =
                Enum.GetValues(typeof(PaymentMethod))
                    .Cast<PaymentMethod>()
                    .ToList();

            cbPaymentMethod.SelectedItem = PaymentMethod.Cash;
            
            txtAmountPaid.Text = _securityDeposit.ToString("N2");
            txtAmountPaid.ReadOnly = true;
            txtAmountPaid.TabStop = false;
            txtAmountPaid.Text = _securityDeposit.ToString("N2");
        }



        // -------------------------------
        // CONFIRM PAYMENT
        // -------------------------------
        private void BtnProcess_Click(object? sender, EventArgs e)
        {
            if (cbPaymentMethod.SelectedItem is not PaymentMethod method)
            {
                MessageBox.Show(
                    "Please select a payment method.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var amountPaid = _securityDeposit;

            PaidAmount = amountPaid;
            SelectedPaymentMethod = method;

            DialogResult = DialogResult.OK;
            Close();
        }






    }
}
