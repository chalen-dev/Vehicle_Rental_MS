using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VRMS.Enums;
using VRMS.Models.Customers;
using VRMS.Services.Customer;

namespace VRMS.Controls
{
    public partial class CustomersView : UserControl
    {
        private readonly DriversLicenseService _driversLicenseService;
        private readonly CustomerService _customerService;

        private Customer? _selectedCustomer;

        public CustomersView()
        {
            InitializeComponent();

            _driversLicenseService = new DriversLicenseService();
            _customerService = new CustomerService(_driversLicenseService);

            InitializeCustomerTypeCombo();
            HookEvents();
            LoadCustomers();
            
        }

        // =====================================================
        // INIT
        // =====================================================

        private void InitializeCustomerTypeCombo()
        {
            cbCustomerType.DataSource = new List<CustomerType>
            {
                CustomerType.Individual,
                CustomerType.Corporate
            };

            cbCustomerType.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void HookEvents()
        {
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            btnClear.Click += (_, _) => ClearForm();
            btnManageAccount.Click += BtnManageAccount_Click;

            dgvCustomers.SelectionChanged += DgvCustomers_SelectionChanged;
            dtpDOB.ValueChanged += (_, _) => UpdateAgeLabel();
        }

        // =====================================================
        // LOAD / GRID
        // =====================================================

        private void LoadCustomers()
        {
            var customers = _customerService.GetAllCustomers();

            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.DataSource = customers;

            if (dgvCustomers.Columns.Count == 0)
            {
                dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Name",
                    DataPropertyName = "LastName",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });

                dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Phone",
                    DataPropertyName = "Phone",
                    Width = 120
                });
            }
        }

        private void DgvCustomers_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
                return;

            _selectedCustomer =
                dgvCustomers.SelectedRows[0].DataBoundItem as Customer;

            if (_selectedCustomer == null)
                return;

            PopulateForm(_selectedCustomer);
        }

        // =====================================================
        // SAVE / DELETE
        // =====================================================

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                if (_selectedCustomer == null)
                {
                    CreateCustomer();
                }
                else
                {
                    UpdateCustomer();
                }

                LoadCustomers();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (_selectedCustomer == null)
                return;

            var confirm = MessageBox.Show(
                "Delete this customer?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes)
                return;

            _customerService.DeleteCustomer(_selectedCustomer.Id);
            LoadCustomers();
            ClearForm();
        }

        // =====================================================
        // CREATE / UPDATE
        // =====================================================

        private void CreateCustomer()
        {
            int licenseId = _driversLicenseService.CreateDriversLicense(
                txtLicenseNum.Text,
                dtpIssueDate.Value.Date,
                dtpExpiryDate.Value.Date,
                txtLicenseState.Text
            );

            _customerService.CreateCustomer(
                txtFirstName.Text,
                txtLastName.Text,
                txtEmail.Text,
                txtPhone.Text,
                dtpDOB.Value.Date,
                (CustomerType)cbCustomerType.SelectedItem!,
                licenseId
            );
        }

        private void UpdateCustomer()
        {
            _customerService.UpdateCustomer(
                _selectedCustomer!.Id,
                txtFirstName.Text,
                txtLastName.Text,
                txtEmail.Text,
                txtPhone.Text,
                (CustomerType)cbCustomerType.SelectedItem!,
                _selectedCustomer.PhotoPath
            );
        }

        // =====================================================
        // FORM
        // =====================================================

        private void PopulateForm(Customer c)
        {
            txtFirstName.Text = c.FirstName;
            txtLastName.Text = c.LastName;
            txtEmail.Text = c.Email;
            txtPhone.Text = c.Phone;
            dtpDOB.Value = c.DateOfBirth;

            cbCustomerType.SelectedItem = c.CustomerType;

            var license = _driversLicenseService.GetDriversLicenseById(c.DriversLicenseId);
            txtLicenseNum.Text = license.LicenseNumber;
            txtLicenseState.Text = license.IssuingCountry;
            dtpIssueDate.Value = license.IssueDate;
            dtpExpiryDate.Value = license.ExpiryDate;

            UpdateAgeLabel();
        }

        private void ClearForm()
        {
            _selectedCustomer = null;

            foreach (var tb in Controls.OfType<TextBox>())
                tb.Clear();

            cbCustomerType.SelectedIndex = 0;

            dtpDOB.Value = DateTime.Today.AddYears(-21);
            dtpIssueDate.Value = DateTime.Today;
            dtpExpiryDate.Value = DateTime.Today.AddYears(5);

            picCustomerPhoto.Image = null;
            dgvCustomers.ClearSelection();
        }

        // =====================================================
        // HELPERS
        // =====================================================

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
                return Fail("First name required");

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
                return Fail("Last name required");

            if (GetAge() < 21)
                return Fail("Customer must be at least 21");

            if (dtpExpiryDate.Value <= DateTime.Today)
                return Fail("License is expired");

            return true;
        }

        private bool Fail(string msg)
        {
            MessageBox.Show(msg, "Validation Error");
            return false;
        }

        private void UpdateAgeLabel()
        {
            lblAgeCheck.Text = $"Age: {GetAge()}";
            lblAgeCheck.ForeColor = GetAge() >= 21 ? Color.Green : Color.Red;
        }

        private int GetAge()
        {
            var dob = dtpDOB.Value.Date;
            var today = DateTime.Today;

            int age = today.Year - dob.Year;
            if (dob > today.AddYears(-age)) age--;
            return age;
        }

        private void BtnManageAccount_Click(object? sender, EventArgs e)
        {
            if (_selectedCustomer == null)
                return;

            MessageBox.Show(
                "Account management comes later (UserService)",
                "Info"
            );
        }
    }
}
