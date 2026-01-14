using System;
using System.Windows.Forms;
using VRMS.Enums;
using VRMS.Models.Billing;
using VRMS.Services.Billing;
using VRMS.UI.ApplicationService;

namespace VRMS.Forms
{
    public partial class PaymentForm : Form
    {
        private readonly int _rentalId;
        private readonly BillingService _billingService;
        private Invoice _invoice = null!;
        public PaymentForm(int rentalId)
        {
            InitializeComponent();

            _rentalId = rentalId;
            _billingService = ApplicationServices.BillingService;

            Load += PaymentForm_Load;
            btnProcess.Click += BtnProcess_Click;
            btnCancel.Click += (_, __) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };
        }

        
        private void PaymentForm_Load(object? sender, EventArgs e)
        {
            _invoice =
                _billingService.GetInvoiceByRental(_rentalId)
                ?? throw new InvalidOperationException("Invoice not found.");

            var balance =
                _billingService.GetInvoiceBalance(_invoice.Id);

            lblGrandTotal.Text = $"TOTAL DUE: ₱{balance:N2}";
        }


        // Common UI events placeholders
        private void BtnProcess_Click(object sender, EventArgs e)
        {
            if (cbPaymentMethod.SelectedItem == null)
            {
                MessageBox.Show("Select payment method.");
                return;
            }

            if (!decimal.TryParse(txtAmountPaid.Text, out var amount) || amount <= 0)
            {
                MessageBox.Show("Invalid amount.");
                return;
            }

            if (!Enum.TryParse<PaymentMethod>(
                    cbPaymentMethod.SelectedItem.ToString(),
                    true,
                    out var method))
            {
                MessageBox.Show("Invalid payment method.");
                return;
            }

            try
            {
                _billingService.AddPayment(
                    invoiceId: _invoice.Id,
                    amount: amount,
                    method: method,
                    paymentType: PaymentType.Final,
                    date: DateTime.Now
                );

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Payment Failed");
            }
        }


        private void btnCancel_Click(object sender, EventArgs e) { }
        private void txtAmountPaid_TextChanged(object sender, EventArgs e) { }
    }
}