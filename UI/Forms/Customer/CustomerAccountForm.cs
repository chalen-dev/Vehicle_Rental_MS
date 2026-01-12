using System;
using System.Windows.Forms;

namespace VRMS.UI.Forms.Customers
{
    public partial class CustomerAccountForm : Form
    {
        public CustomerAccountForm()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            // Configure DGV columns
            dgvCustomerAccounts.Columns.Clear();

            // Add sample columns (customize based on your needs)
            dgvCustomerAccounts.Columns.Add("CustomerId", "ID");
            dgvCustomerAccounts.Columns.Add("CustomerName", "Customer Name");
            dgvCustomerAccounts.Columns.Add("Username", "Username");
            dgvCustomerAccounts.Columns.Add("AccountStatus", "Status");
            dgvCustomerAccounts.Columns.Add("LastLogin", "Last Login");

            // Adjust column widths
            dgvCustomerAccounts.Columns["CustomerId"].Width = 60;
            dgvCustomerAccounts.Columns["CustomerName"].Width = 150;
            dgvCustomerAccounts.Columns["Username"].Width = 100;
            dgvCustomerAccounts.Columns["AccountStatus"].Width = 80;
            dgvCustomerAccounts.Columns["LastLogin"].Width = 120;

            // Load data (you'll replace this with your actual data loading)
            LoadCustomerAccounts();
        }

        private void LoadCustomerAccounts()
        {
            // TODO: Load actual customer account data from your database
            // For demonstration, adding sample data
            dgvCustomerAccounts.Rows.Add(1, "John Smith", "john.smith", "Active", "2024-01-15 14:30");
            dgvCustomerAccounts.Rows.Add(2, "Jane Doe", "jane.doe", "Disabled", "2024-01-10 09:15");
            dgvCustomerAccounts.Rows.Add(3, "Robert Johnson", "r.johnson", "Active", "2024-01-20 16:45");
        }

        private void dgvCustomerAccounts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomerAccounts.SelectedRows.Count > 0)
            {
                var selectedRow = dgvCustomerAccounts.SelectedRows[0];

                // Update form fields based on selected customer
                txtUsername.Text = selectedRow.Cells["Username"].Value?.ToString() ?? "";

                // Update account status
                string status = selectedRow.Cells["AccountStatus"].Value?.ToString() ?? "";
                chkAccountEnabled.Checked = status == "Active";
                lblAccountState.Text = $"Login Account: {(status == "Active" ? "Active" : "Disabled")}";

                // Enable/disable buttons based on status
                btnCreate.Enabled = string.IsNullOrEmpty(txtUsername.Text);
                btnResetPassword.Enabled = !string.IsNullOrEmpty(txtUsername.Text);
                btnDisable.Enabled = !string.IsNullOrEmpty(txtUsername.Text) && status == "Active";
            }
        }

        private void splitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            // The DGV automatically resizes with the split panel
            // You can add additional logic here if needed
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            // TODO: Implement create account logic
            MessageBox.Show("Create account functionality to be implemented");
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            // TODO: Implement reset password logic
            MessageBox.Show("Reset password functionality to be implemented");
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            // TODO: Implement disable account logic
            MessageBox.Show("Disable account functionality to be implemented");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}