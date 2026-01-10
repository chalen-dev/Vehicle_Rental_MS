using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VRMS.Enums;
using VRMS.Models.Customers;
using VRMS.Services.Customer;
using VRMS.UI.Forms.Customer;
using VRMS.Forms; // ✅ CameraForm

namespace VRMS.Controls
{
    public partial class CustomersView : UserControl
    {
        private readonly DriversLicenseService _driversLicenseService;
        private readonly CustomerService _customerService;

        private Customer? _selectedCustomer;

        // UI-only profile image preview
        private Image? _profilePreviewImage;

        public CustomersView()
        {
            InitializeComponent();

            _driversLicenseService = new DriversLicenseService();
            _customerService = new CustomerService(_driversLicenseService);

            InitializeCustomerTypeCombo();
            HookEvents();
            LoadCustomers();

            btnEmergencyContacts.Enabled = false;
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
            btnClear.Click += BtnClear_Click;
            btnManageAccount.Click += BtnManageAccount_Click;

            btnEmergencyContacts.Click += BtnEmergencyContacts_Click;

            dgvCustomers.SelectionChanged += DgvCustomers_SelectionChanged;
            dtpDOB.ValueChanged += (_, _) => UpdateAgeLabel();

            btnCaptureLicense.Click += BtnCaptureLicense_Click;
            btnCheckDrivingRecord.Click += BtnCheckDrivingRecord_Click;

            // Camera buttons
            btnCamera.Click += BtnProfileCamera_Click;
            btnUploadPhoto.Click += BtnBrowseProfilePhoto_Click;
        }

        // =====================================================
        // GRID
        // =====================================================

        private void LoadCustomers()
        {
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.DataSource = _customerService.GetAllCustomers();

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
            {
                btnEmergencyContacts.Enabled = false;
                return;
            }

            _selectedCustomer =
                dgvCustomers.SelectedRows[0].DataBoundItem as Customer;

            if (_selectedCustomer != null)
            {
                PopulateForm(_selectedCustomer);
                btnEmergencyContacts.Enabled = true;
            }
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
                    CreateCustomer();
                else
                    UpdateCustomer();

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

            if (MessageBox.Show(
                "Delete this customer?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            ) != DialogResult.Yes)
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
                (CustomerType)cbCustomerType.SelectedItem!
            );
        }

        // =====================================================
        // EMERGENCY CONTACT NAVIGATION
        // =====================================================

        private void BtnEmergencyContacts_Click(object? sender, EventArgs e)
        {
            if (_selectedCustomer == null)
            {
                MessageBox.Show(
                    "Please select a customer first.",
                    "No Customer Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string fullName =
                $"{_selectedCustomer.FirstName} {_selectedCustomer.LastName}";

            using var form = new EmergencyContactsForm(
                _selectedCustomer.Id,
                fullName
            );

            form.ShowDialog();
        }

        // =====================================================
        // CAMERA ACTIONS
        // =====================================================

        // ✅ DRIVER'S LICENSE CAMERA
        private void BtnCaptureLicense_Click(object? sender, EventArgs e)
        {
            using var form = new DriverLicenseCaptureForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                btnCaptureLicense.BackColor = Color.FromArgb(46, 204, 113);
            }
        }

        // ✅ PROFILE PHOTO CAMERA (USES CameraForm)
        private void BtnProfileCamera_Click(object? sender, EventArgs e)
        {
            using var cameraForm = new CameraForm("Capture Profile Photo");

            if (cameraForm.ShowDialog() == DialogResult.OK &&
                cameraForm.HasCapturedImage)
            {
                _profilePreviewImage?.Dispose();

                _profilePreviewImage =
                    (Image)cameraForm.CapturedImage.Clone();

                picCustomerPhoto.Image = _profilePreviewImage;

                MessageBox.Show(
                    "Profile photo captured successfully (preview only).",
                    "Camera",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void BtnBrowseProfilePhoto_Click(object? sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _profilePreviewImage?.Dispose();
                _profilePreviewImage = Image.FromFile(dialog.FileName);
                picCustomerPhoto.Image = _profilePreviewImage;
            }
        }

        private void BtnCheckDrivingRecord_Click(object? sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "No external driving record system connected.\n\nIs the customer cleared to rent?",
                "Driving Record Verification",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
                MessageBox.Show("✔ Driving Record: Cleared");
            else if (result == DialogResult.No)
                MessageBox.Show("❌ Driving Record: Not Cleared");
        }

        // =====================================================
        // CLEAR / NEW
        // =====================================================

        private void BtnClear_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            _selectedCustomer = null;
            btnEmergencyContacts.Enabled = false;

            ClearTextBoxes(this);

            cbCustomerType.SelectedIndex = 0;
            dtpDOB.Value = DateTime.Today.AddYears(-21);
            dtpIssueDate.Value = DateTime.Today;
            dtpExpiryDate.Value = DateTime.Today.AddYears(5);

            picCustomerPhoto.Image = null;
            _profilePreviewImage = null;

            btnCaptureLicense.BackColor = SystemColors.Control;

            lblAgeCheck.Text = "Age:";
            lblAgeCheck.ForeColor = Color.DimGray;

            dgvCustomers.ClearSelection();
        }

        private void ClearTextBoxes(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextBox tb)
                    tb.Clear();
                else
                    ClearTextBoxes(control);
            }
        }

        // =====================================================
        // HELPERS
        // =====================================================

        private void PopulateForm(Customer c)
        {
            txtFirstName.Text = c.FirstName;
            txtLastName.Text = c.LastName;
            txtEmail.Text = c.Email;
            txtPhone.Text = c.Phone;
            dtpDOB.Value = c.DateOfBirth;
            cbCustomerType.SelectedItem = c.CustomerType;

            UpdateAgeLabel();
        }

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
            MessageBox.Show(
                "Account management comes later.",
                "Info",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
