using System;
using System.Windows.Forms;

// 🔒 ALIAS THE MODEL TYPE (NO AMBIGUITY POSSIBLE)
using CustomerModel = VRMS.Models.Customers.Customer;

namespace VRMS.UI.Forms.Customers
{
    public partial class CustomerAccountForm : Form
    {
        private readonly CustomerModel _customer;

        // =====================================================
        // CONSTRUCTOR
        // =====================================================

        public CustomerAccountForm(CustomerModel customer)
        {
            InitializeComponent();
            _customer = customer;

            InitializeDataGridView();
            LoadCustomerAccount();
        }

        // =====================================================
        // DATAGRIDVIEW SETUP
        // =====================================================

        private void InitializeDataGridView()
        {
            dgvCustomerAccounts.Columns.Clear();
            dgvCustomerAccounts.AutoGenerateColumns = false;
            dgvCustomerAccounts.MultiSelect = false;
            dgvCustomerAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomerAccounts.ReadOnly = true;
            dgvCustomerAccounts.AllowUserToAddRows = false;

            dgvCustomerAccounts.Columns.Add("CustomerId", "ID");
            dgvCustomerAccounts.Columns.Add("CustomerName", "Customer Name");
            dgvCustomerAccounts.Columns.Add("Username", "Username");
            dgvCustomerAccounts.Columns.Add("AccountStatus", "Status");
            dgvCustomerAccounts.Columns.Add("LastLogin", "Last Login");

            dgvCustomerAccounts.Columns["CustomerId"].Width = 60;
            dgvCustomerAccounts.Columns["CustomerName"].Width = 160;
            dgvCustomerAccounts.Columns["Username"].Width = 120;
            dgvCustomerAccounts.Columns["AccountStatus"].Width = 80;
            dgvCustomerAccounts.Columns["LastLogin"].Width = 130;

            dgvCustomerAccounts.SelectionChanged += dgvCustomerAccounts_SelectionChanged;
        }

        // =====================================================
        // LOAD ACCOUNT (SINGLE CUSTOMER)
        // =====================================================

        private void LoadCustomerAccount()
        {
            dgvCustomerAccounts.Rows.Clear();

            // TEMP LOGIC (replace with service later)
            bool hasAccount = !string.IsNullOrWhiteSpace(_customer.Email);

            if (hasAccount)
            {
                dgvCustomerAccounts.Rows.Add(
                    _customer.Id,
                    $"{_customer.FirstName} {_customer.LastName}",
                    _customer.Email,
                    "Active",
                    "—"
                );

                dgvCustomerAccounts.Rows[0].Selected = true;
            }

            UpdateFormState(hasAccount);
        }

        // =====================================================
        // FORM STATE
        // =====================================================

        private void UpdateFormState(bool hasAccount)
        {
            txtUsername.Text = hasAccount ? _customer.Email : "";
            chkAccountEnabled.Checked = hasAccount;

            lblAccountState.Text = hasAccount
                ? "Login Account: Active"
                : "Login Account: Not Created";

            btnCreate.Enabled = !hasAccount;
            btnResetPassword.Enabled = hasAccount;
            btnDisable.Enabled = hasAccount;
        }

        // =====================================================
        // DGV EVENTS
        // =====================================================

        private void dgvCustomerAccounts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomerAccounts.SelectedRows.Count == 0)
                return;

            var row = dgvCustomerAccounts.SelectedRows[0];

            txtUsername.Text = row.Cells["Username"].Value?.ToString() ?? "";

            string status = row.Cells["AccountStatus"].Value?.ToString() ?? "Disabled";
            bool isActive = status == "Active";

            chkAccountEnabled.Checked = isActive;
            lblAccountState.Text =
                $"Login Account: {(isActive ? "Active" : "Disabled")}";

            btnCreate.Enabled = false;
            btnResetPassword.Enabled = true;
            btnDisable.Enabled = isActive;
        }

        // =====================================================
        // BUTTON ACTIONS
        // =====================================================

        private void btnCreate_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Create account logic to be implemented",
                "Create Account",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Reset password logic to be implemented",
                "Reset Password",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Disable this customer account?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            chkAccountEnabled.Checked = false;
            lblAccountState.Text = "Login Account: Disabled";
            btnDisable.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void splitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            // optional layout logic
        }
    }
}
