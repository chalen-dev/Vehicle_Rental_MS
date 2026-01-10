using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VRMS.Enums;
using VRMS.Models.Customers;
using VRMS.Services.Customer;
using VRMS.UI.Forms.Customer;
using VRMS.Forms;

namespace VRMS.Controls
{
    public partial class CustomersView : UserControl
    {
        private readonly DriversLicenseService _driversLicenseService;
        private readonly CustomerService _customerService;

        private Customer? _selectedCustomer;
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
            UpdateSaveButtonState();
        }

        // =====================================================
        // INIT
        // =====================================================

        private void InitializeCustomerTypeCombo()
        {
            cbCustomerType.DataSource = new List<CustomerCategory>
            {
                CustomerCategory.Individual,
                CustomerCategory.Corporate
            };

            cbCustomerType.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void HookEvents()
        {
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            btnClear.Click += (_, _) => ClearForm();

            btnManageAccount.Click += BtnManageAccount_Click;
            btnEmergencyContacts.Click += BtnEmergencyContacts_Click;

            dgvCustomers.SelectionChanged += DgvCustomers_SelectionChanged;
            dtpDOB.ValueChanged += (_, _) => UpdateAgeLabel();

            btnCaptureLicense.Click += BtnCaptureLicense_Click;
            btnCheckDrivingRecord.Click += BtnCheckDrivingRecord_Click;

            btnCamera.Click += BtnProfileCamera_Click;
            btnUploadPhoto.Click += BtnBrowseProfilePhoto_Click;

            txtFirstName.TextChanged += (_, _) => UpdateSaveButtonState();
            txtLastName.TextChanged += (_, _) => UpdateSaveButtonState();
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
                    HeaderText = "First Name",
                    DataPropertyName = "FirstName",
                    Width = 140
                });

                dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Last Name",
                    DataPropertyName = "LastName",
                    Width = 140
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
        // CREATE / UPDATE  (MATCHES SERVICE EXACTLY)
        // =====================================================

        private void CreateCustomer()
        {
            int licenseId = _driversLicenseService.CreateDriversLicense(
                txtLicenseNum.Text.Trim(),
                dtpIssueDate.Value.Date,
                dtpExpiryDate.Value.Date,
                txtLicenseState.Text.Trim()
            );

            int customerId = _customerService.CreateCustomer(
                txtFirstName.Text.Trim(),
                txtLastName.Text.Trim(),
                txtEmail.Text.Trim(),
                txtPhone.Text.Trim(),
                txtAddress.Text.Trim(),
                dtpDOB.Value.Date,
                (CustomerCategory)cbCustomerType.SelectedItem!,
                chkLoyalty.Checked,
                chkBlacklist.Checked,
                licenseId
            );

            SaveProfilePhoto(customerId);
        }

        private void UpdateCustomer()
        {
            _customerService.UpdateCustomer(
                _selectedCustomer!.Id,
                txtFirstName.Text.Trim(),
                txtLastName.Text.Trim(),
                txtEmail.Text.Trim(),
                txtPhone.Text.Trim(),
                txtAddress.Text.Trim(),
                (CustomerCategory)cbCustomerType.SelectedItem!,
                chkLoyalty.Checked,
                chkBlacklist.Checked
            );

            SaveProfilePhoto(_selectedCustomer.Id);
        }

        // =====================================================
        // PROFILE PHOTO
        // =====================================================

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

        private void SaveProfilePhoto(int customerId)
        {
            if (_profilePreviewImage == null)
                return;

            using var ms = new MemoryStream();
            _profilePreviewImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Position = 0;

            _customerService.SetCustomerPhoto(customerId, ms, "profile.jpg");
        }

        private void LoadProfilePhoto(string relativePath)
        {
            picCustomerPhoto.Image?.Dispose();

            var fullPath = Path.Combine("Storage", relativePath);
            if (!File.Exists(fullPath))
            {
                picCustomerPhoto.Image = null;
                return;
            }

            using var fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
            picCustomerPhoto.Image = Image.FromStream(fs);
        }

        // =====================================================
        // CLEAR / POPULATE
        // =====================================================

        private void ClearForm()
        {
            _selectedCustomer = null;
            btnEmergencyContacts.Enabled = false;

            ClearTextBoxes(this);

            cbCustomerType.SelectedIndex = 0;
            chkLoyalty.Checked = false;
            chkBlacklist.Checked = false;

            dtpDOB.Value = DateTime.Today.AddYears(-21);
            dtpIssueDate.Value = DateTime.Today;
            dtpExpiryDate.Value = DateTime.Today.AddYears(5);

            picCustomerPhoto.Image = null;
            _profilePreviewImage = null;

            lblAgeCheck.Text = "Age:";
            lblAgeCheck.ForeColor = Color.DimGray;

            dgvCustomers.ClearSelection();
            UpdateSaveButtonState();
        }

        private void PopulateForm(Customer c)
        {
            txtFirstName.Text = c.FirstName;
            txtLastName.Text = c.LastName;
            txtEmail.Text = c.Email;
            txtPhone.Text = c.Phone;
            txtAddress.Text = c.Address;

            dtpDOB.Value = c.DateOfBirth;
            cbCustomerType.SelectedItem = c.Category;
            chkLoyalty.Checked = c.IsFrequent;
            chkBlacklist.Checked = c.IsBlacklisted;

            UpdateAgeLabel();
            LoadProfilePhoto(c.PhotoPath);
        }

        private void ClearTextBoxes(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox tb)
                    tb.Clear();
                else
                    ClearTextBoxes(c);
            }
        }

        // =====================================================
        // VALIDATION
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

        private void UpdateSaveButtonState()
        {
            btnSave.Enabled =
                !string.IsNullOrWhiteSpace(txtFirstName.Text) &&
                !string.IsNullOrWhiteSpace(txtLastName.Text);
        }

        private void UpdateAgeLabel()
        {
            lblAgeCheck.Text = $"Age: {GetAge()}";
            lblAgeCheck.ForeColor =
                GetAge() >= 21 ? Color.Green : Color.Red;
        }

        private int GetAge()
        {
            var dob = dtpDOB.Value.Date;
            var today = DateTime.Today;

            int age = today.Year - dob.Year;
            if (dob > today.AddYears(-age)) age--;
            return age;
        }

        // =====================================================
        // MISC
        // =====================================================

        private void BtnManageAccount_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Account management comes later.", "Info");
        }

        private void BtnCaptureLicense_Click(object? sender, EventArgs e)
        {
            using var form = new DriverLicenseCaptureForm();
            if (form.ShowDialog() == DialogResult.OK)
                btnCaptureLicense.BackColor = Color.FromArgb(46, 204, 113);
        }

        private void BtnCheckDrivingRecord_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("No external driving record system connected.", "Info");
        }

        private void BtnEmergencyContacts_Click(object? sender, EventArgs e)
        {
            if (_selectedCustomer == null)
                return;

            using var form = new EmergencyContactsForm(
                _selectedCustomer.Id,
                $"{_selectedCustomer.FirstName} {_selectedCustomer.LastName}"
            );

            form.ShowDialog();
        }
    }
}
