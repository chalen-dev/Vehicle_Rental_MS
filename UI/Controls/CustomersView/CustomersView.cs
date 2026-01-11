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

        private List<Customer> _allCustomers = new();

        private Customer? _selectedCustomer;
        private DriversLicense? _currentLicense;

        private Image? _profilePreviewImage;
        private MemoryStream? _licenseFrontStream;
        private MemoryStream? _licenseBackStream;

        public CustomersView()
        {
            InitializeComponent();

            // Allow table to expand
            splitContainer1.FixedPanel = FixedPanel.Panel2; 
            splitContainer1.IsSplitterFixed = false;

            // Safety limits
            splitContainer1.Panel1MinSize = 300;
            splitContainer1.Panel2MinSize = 450;

            // Initial size
            splitContainer1.SplitterDistance = 400;

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
            dgvCustomers.SelectionChanged += DgvCustomers_SelectionChanged;
            txtSearch.TextChanged += TxtSearch_TextChanged;

            dtpDOB.ValueChanged += (_, _) => UpdateAgeLabel();
            txtFirstName.TextChanged += (_, _) => UpdateSaveButtonState();
            txtLastName.TextChanged += (_, _) => UpdateSaveButtonState();

            btnClear.Click += BtnClear_Click;
        }

        // =====================================================
        // GRID + SEARCH
        // =====================================================

        private void LoadCustomers()
        {
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.Columns.Clear();

            _allCustomers = _customerService.GetAllCustomers();
            dgvCustomers.DataSource = new List<Customer>(_allCustomers);

            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "First Name",
                DataPropertyName = "FirstName",
                FillWeight = 35
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Last Name",
                DataPropertyName = "LastName",
                FillWeight = 35
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Phone",
                DataPropertyName = "Phone",
                FillWeight = 30
            });
        }


        private void TxtSearch_TextChanged(object? sender, EventArgs e)
        {
            var keyword = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                dgvCustomers.DataSource = new List<Customer>(_allCustomers);
                return;
            }

            var filtered = _allCustomers.FindAll(c =>
                (!string.IsNullOrWhiteSpace(c.FirstName) &&
                 c.FirstName.ToLower().Contains(keyword)) ||

                (!string.IsNullOrWhiteSpace(c.LastName) &&
                 c.LastName.ToLower().Contains(keyword)) ||

                (!string.IsNullOrWhiteSpace(c.Phone) &&
                 c.Phone.ToLower().Contains(keyword)) ||

                (!string.IsNullOrWhiteSpace(c.Email) &&
                 c.Email.ToLower().Contains(keyword))
            );

            dgvCustomers.DataSource = filtered;
        }

        private void ReselectCustomer(int customerId)
        {
            foreach (DataGridViewRow row in dgvCustomers.Rows)
            {
                if (row.DataBoundItem is Customer c && c.Id == customerId)
                {
                    row.Selected = true;
                    dgvCustomers.CurrentCell = row.Cells[0];
                    return;
                }
            }
        }

        private void DgvCustomers_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
                return;

            _selectedCustomer =
                dgvCustomers.SelectedRows[0].DataBoundItem as Customer;

            if (_selectedCustomer != null)
            {
                PopulateForm(_selectedCustomer);
                btnEmergencyContacts.Enabled = true;
            }
        }

        // =====================================================
        // SAVE / DELETE / CLEAR
        // =====================================================

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                int? updatedId = null;

                if (_selectedCustomer == null)
                    CreateCustomer();
                else
                {
                    updatedId = _selectedCustomer.Id;
                    UpdateCustomer();
                }

                LoadCustomers();

                if (updatedId.HasValue)
                    ReselectCustomer(updatedId.Value);
                else
                    ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedCustomer == null)
                return;

            if (MessageBox.Show("Delete this customer?",
                "Confirm", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            _customerService.DeleteCustomer(_selectedCustomer.Id);
            LoadCustomers();
            ClearForm();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        // =====================================================
        // CREATE / UPDATE
        // =====================================================

        private void CreateCustomer()
        {
            int licenseId = _driversLicenseService.SaveDriversLicense(
                null,
                txtLicenseNum.Text.Trim(),
                dtpIssueDate.Value.Date,
                dtpExpiryDate.Value.Date,
                txtLicenseState.Text.Trim(),
                null, null, null, null
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
            _driversLicenseService.SaveDriversLicense(
                _selectedCustomer!.DriversLicenseId,
                txtLicenseNum.Text.Trim(),
                dtpIssueDate.Value.Date,
                dtpExpiryDate.Value.Date,
                txtLicenseState.Text.Trim(),
                _licenseFrontStream, "front.jpg",
                _licenseBackStream, "back.jpg"
            );

            _customerService.UpdateCustomer(
                _selectedCustomer.Id,
                txtFirstName.Text.Trim(),
                txtLastName.Text.Trim(),
                txtEmail.Text.Trim(),
                txtPhone.Text.Trim(),
                txtAddress.Text.Trim(),
                dtpDOB.Value.Date,
                (CustomerCategory)cbCustomerType.SelectedItem!,
                chkLoyalty.Checked,
                chkBlacklist.Checked
            );

            SaveProfilePhoto(_selectedCustomer.Id);
        }

        // =====================================================
        // POPULATE / CLEAR
        // =====================================================

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

            _currentLicense =
                _driversLicenseService.GetDriversLicenseById(c.DriversLicenseId);

            if (_currentLicense != null)
            {
                txtLicenseNum.Text = _currentLicense.LicenseNumber;
                dtpIssueDate.Value = _currentLicense.IssueDate;
                dtpExpiryDate.Value = _currentLicense.ExpiryDate;
                txtLicenseState.Text = _currentLicense.IssuingCountry;

                LoadLicenseImages(_currentLicense);
            }

            LoadProfilePhoto(c.PhotoPath);
            UpdateAgeLabel();
        }

        private void ClearForm()
        {
            _selectedCustomer = null;
            _currentLicense = null;

            ClearTextBoxes(this);

            cbCustomerType.SelectedIndex = 0;
            chkLoyalty.Checked = false;
            chkBlacklist.Checked = false;

            dtpDOB.Value = DateTime.Today.AddYears(-21);
            dtpIssueDate.Value = DateTime.Today;
            dtpExpiryDate.Value = DateTime.Today.AddYears(5);

            picCustomerPhoto.Image = null;
            picLicenseFront.Image = null;
            picLicenseBack.Image = null;

            _profilePreviewImage = null;
            _licenseFrontStream = null;
            _licenseBackStream = null;

            dgvCustomers.ClearSelection();
            btnEmergencyContacts.Enabled = false;

            UpdateSaveButtonState();
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
        // PHOTOS
        // =====================================================

        private void BtnBrowseProfilePhoto_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.png;*.jpeg"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _profilePreviewImage = Image.FromFile(dialog.FileName);
                picCustomerPhoto.Image = _profilePreviewImage;
            }
        }

        private void BtnProfileCamera_Click(object sender, EventArgs e)
        {
            using var form = new CameraForm("Capture Profile Photo");
            if (form.ShowDialog() == DialogResult.OK)
            {
                _profilePreviewImage = (Image)form.CapturedImage.Clone();
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
            picCustomerPhoto.Image = null;

            if (string.IsNullOrWhiteSpace(relativePath) ||
                relativePath.StartsWith("Assets/", StringComparison.OrdinalIgnoreCase))
                return;

            var fullPath = Path.Combine("Storage", relativePath);
            if (!File.Exists(fullPath))
                return;

            using var fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
            using var img = Image.FromStream(fs);
            picCustomerPhoto.Image = new Bitmap(img);
        }

        // =====================================================
        // LICENSE IMAGES
        // =====================================================

        private void LoadLicenseImages(DriversLicense license)
        {
            LoadImage(picLicenseFront, license.FrontPhotoPath);
            LoadImage(picLicenseBack, license.BackPhotoPath);
        }

        private void LoadImage(PictureBox pb, string relativePath)
        {
            pb.Image = null;

            if (string.IsNullOrWhiteSpace(relativePath) ||
                relativePath.StartsWith("Assets/", StringComparison.OrdinalIgnoreCase))
                return;

            var fullPath = Path.Combine("Storage", relativePath);
            if (!File.Exists(fullPath))
                return;

            using var fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
            using var img = Image.FromStream(fs);
            pb.Image = new Bitmap(img);
        }

        // =====================================================
        // OTHER BUTTONS
        // =====================================================

        private void BtnCaptureLicense_Click(object sender, EventArgs e)
        {
            if (_selectedCustomer == null)
                return;

            using var form = new DriverLicenseCaptureForm();
            if (form.ShowDialog() != DialogResult.OK)
                return;

            _licenseFrontStream = form.GetFrontImageStream();
            _licenseBackStream = form.GetBackImageStream();

            _driversLicenseService.SaveDriversLicense(
                _selectedCustomer.DriversLicenseId,
                txtLicenseNum.Text.Trim(),
                dtpIssueDate.Value.Date,
                dtpExpiryDate.Value.Date,
                txtLicenseState.Text.Trim(),
                _licenseFrontStream, "front.jpg",
                _licenseBackStream, "back.jpg"
            );

            _currentLicense =
                _driversLicenseService.GetDriversLicenseById(
                    _selectedCustomer.DriversLicenseId);

            LoadLicenseImages(_currentLicense);
        }

        private void BtnCheckDrivingRecord_Click(object sender, EventArgs e)
        {
            if (_selectedCustomer == null)
                return;

            using var dialog = new DrivingRecordVerificationDialog();
            dialog.ShowDialog(this);
        }

        private void BtnEmergencyContacts_Click(object sender, EventArgs e)
        {
            if (_selectedCustomer == null)
                return;

            using var form = new EmergencyContactsForm(
                _selectedCustomer.Id,
                $"{_selectedCustomer.FirstName} {_selectedCustomer.LastName}");
            form.ShowDialog();
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

            if (dtpExpiryDate.Value <= dtpIssueDate.Value)
                return Fail("License expiry must be after issue date");

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
    }
}
