using VRMS.Enums;
using VRMS.Repositories.Billing;
using VRMS.UI.ApplicationService;

namespace VRMS.UI.Forms.Payments
{
    public partial class ReservationFee : Form
    {
        private int _reservationId;
        private decimal _requiredFee;

        private readonly PaymentRepository _paymentRepo;

        public ReservationFee()
        {
            InitializeComponent();

            _paymentRepo = ApplicationServices.PaymentRepository;

            SetupEventHandlers();

            cbPaymentMethod.SelectedIndex = 0;
        }

        private void SetupEventHandlers()
        {
            btnConfirm.Click += BtnConfirm_Click;
            btnCancel.Click += BtnCancel_Click;
            txtAmountPaid.KeyPress += TxtAmountPaid_KeyPress;
        }

        public void SetReservationDetails(
            string customerName,
            string vehicleInfo,
            string reservationId,
            decimal estimatedTotal,
            decimal reservationFee)
        {
            _reservationId = int.Parse(reservationId);
            _requiredFee = reservationFee;

            lblCustomerInfo.Text = $"Customer: {customerName}";
            lblVehicleInfo.Text = $"Vehicle: {vehicleInfo}";
            lblReservationID.Text = $"Reservation ID: {reservationId}";
            lblEstimatedTotal.Text = $"Estimated Rental Cost: ₱{estimatedTotal:N2}";
            lblReservationFee.Text = $"RESERVATION FEE: ₱{reservationFee:N2}";
            txtAmountPaid.Text = reservationFee.ToString("N2");
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtAmountPaid.Text, out var amount))
            {
                MessageBox.Show("Invalid amount.");
                return;
            }

            if (amount != _requiredFee)
            {
                MessageBox.Show(
                    $"Reservation fee must be exactly ₱{_requiredFee:N2}",
                    "Invalid Amount",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var method = Enum.Parse<PaymentMethod>(
                cbPaymentMethod.SelectedItem!.ToString()!.Replace(" ", ""),
                true);

            _paymentRepo.Create(
                invoiceId: null,
                reservationId: _reservationId,
                amount: amount,
                method: method,
                paymentType: PaymentType.Reservation,
                date: DateTime.UtcNow
            );

            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void TxtAmountPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' &&
                txtAmountPaid.Text.Contains('.'))
            {
                e.Handled = true;
            }
        }
    }
}
