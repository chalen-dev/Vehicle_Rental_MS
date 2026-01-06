using System;
using System.Windows.Forms;

namespace VRMS.Forms
{
    public partial class PaymentForm : Form
    {
        public PaymentForm()
        {
            InitializeComponent();
        }

        // Common UI events placeholders
        private void btnProcess_Click(object sender, EventArgs e) { }
        private void btnCancel_Click(object sender, EventArgs e) { }
        private void txtAmountPaid_TextChanged(object sender, EventArgs e) { }
    }
}