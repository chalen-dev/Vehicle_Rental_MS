using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VRMS.DTOs.Rental;
using VRMS.Enums;
using VRMS.Forms;
using VRMS.Models.Customers;
using VRMS.Repositories.Accounts;
using VRMS.Repositories.Billing;
using VRMS.Repositories.Damages;
using VRMS.Repositories.Fleet;
using VRMS.Repositories.Inspections;
using VRMS.Repositories.Rentals;
using VRMS.Services.Account;
using VRMS.Services.Billing;
using VRMS.Services.Customer;
using VRMS.Services.Fleet;
using VRMS.Services.Rental;
using VRMS.UI.Forms.Customer;
using VRMS.UI.Forms.Customers;
using VRMS.UI.Services;
using VRMS.UI.State;
using VRMS.UI.Validation;

namespace VRMS.Controls
{
    public partial class CustomersView : UserControl
    {
        private readonly DriversLicenseService _driversLicenseService;
        private readonly CustomerService _customerService;
        private readonly RentalService _rentalService;
        private readonly CustomerAccountService _customerAccountService;
        private readonly CustomerImageService _imageService = new();

        private readonly CustomerFormState _state = new();

        private List<Customer> _allCustomers = new();

        public CustomersView()
        {
            InitializeComponent();

            splitContainer1.FixedPanel = FixedPanel.Panel2;
            splitContainer1.IsSplitterFixed = false;
            splitContainer1.Panel1MinSize = 300;
            splitContainer1.Panel2MinSize = 450;
            splitContainer1.SplitterDistance = 400;

            _driversLicenseService = ApplicationServices.DriversLicenseService;
            _customerAccountService = ApplicationServices.CustomerAccountService;
            _customerService = ApplicationServices.CustomerService;
            _rentalService = ApplicationServices.RentalService;

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
                FillWeight = 30
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Last Name",
                DataPropertyName = "LastName",
                FillWeight = 30
            });
            
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Email",
                DataPropertyName = "Email",
                FillWeight = 30
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Type",
                DataPropertyName = "CategoryDisplay",
                FillWeight = 20
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Phone",
                DataPropertyName = "Phone",
                FillWeight = 20
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

            _state.SelectedCustomer =
                dgvCustomers.SelectedRows[0].DataBoundItem as Customer;

            if (_state.SelectedCustomer == null)
                return;

            PopulateForm(_state.SelectedCustomer);
            LoadRentalHistory(_state.SelectedCustomer.Id);
            btnEmergencyContacts.Enabled = true;
        }

        
        private void LoadRentalHistory(int customerId)
        {
            dgvRentalHistory.SuspendLayout();

            dgvRentalHistory.AutoGenerateColumns = false;
            dgvRentalHistory.Columns.Clear();
            dgvRentalHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // ---- DEFINE COLUMNS FIRST ----

            dgvRentalHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Rental #",
                DataPropertyName = nameof(RentalHistoryRowDto.RentalId),
                Width = 80
            });

            dgvRentalHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Pickup",
                DataPropertyName = nameof(RentalHistoryRowDto.PickupDate)
            });

            dgvRentalHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Return",
                DataPropertyName = nameof(RentalHistoryRowDto.ReturnDate)
            });

            dgvRentalHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Days",
                DataPropertyName = nameof(RentalHistoryRowDto.DurationDays),
                Width = 60
            });

            dgvRentalHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Status",
                DataPropertyName = nameof(RentalHistoryRowDto.Status)
            });

            dgvRentalHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Total",
                DataPropertyName = nameof(RentalHistoryRowDto.TotalAmount),
                DefaultCellStyle = { Format = "₱#,##0.00" }
            });

            // ---- DATA SOURCE LAST ----

            var data = _rentalService.GetRentalHistoryForCustomer(customerId)
                       ?? new List<RentalHistoryRowDto>();

            dgvRentalHistory.DataSource = data;

            dgvRentalHistory.ResumeLayout();
            
            /*
            MessageBox.Show(
                $"Rental history rows: {data.Count}",
                "Debug");
                */
        }



        // =====================================================
        // SAVE / DELETE / CLEAR
        // =====================================================

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerFormValidator.ValidateBasicInfo(
                    txtFirstName.Text,
                    txtLastName.Text,
                    dtpDOB.Value,
                    dtpIssueDate.Value,
                    dtpExpiryDate.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validation Error");
                return;
            }

            try
            {
                int? updatedId = null;

                if (_state.SelectedCustomer == null)
                    CreateCustomer();
                else
                {
                    updatedId = _state.SelectedCustomer.Id;
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
            if (_state.SelectedCustomer == null)
                return;

            if (MessageBox.Show("Delete this customer?",
                "Confirm", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            _customerService.DeleteCustomer(_state.SelectedCustomer.Id);
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

            if (_state.ProfileImage != null)
            {
                using var ms = _imageService.ImageToStream(_state.ProfileImage);
                _customerService.SetCustomerPhoto(customerId, ms, "profile.jpg");
            }
        }

        private void UpdateCustomer()
        {
            _driversLicenseService.SaveDriversLicense(
                _state.SelectedCustomer!.DriversLicenseId,
                txtLicenseNum.Text.Trim(),
                dtpIssueDate.Value.Date,
                dtpExpiryDate.Value.Date,
                txtLicenseState.Text.Trim(),
                _state.LicenseFrontStream, "front.jpg",
                _state.LicenseBackStream, "back.jpg"
            );

            _customerService.UpdateCustomer(
                _state.SelectedCustomer.Id,
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

            if (_state.ProfileImage != null)
            {
                using var ms = _imageService.ImageToStream(_state.ProfileImage);
                _customerService.SetCustomerPhoto(
                    _state.SelectedCustomer.Id,
                    ms,
                    "profile.jpg");
            }
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

            _state.License =
                _driversLicenseService.GetDriversLicenseById(c.DriversLicenseId);

            if (_state.License != null)
            {
                txtLicenseNum.Text = _state.License.LicenseNumber;
                dtpIssueDate.Value = _state.License.IssueDate;
                dtpExpiryDate.Value = _state.License.ExpiryDate;
                txtLicenseState.Text = _state.License.IssuingCountry;

                _imageService.SetPictureBoxImage(
                    picLicenseFront,
                    _state.License.FrontPhotoPath);

                _imageService.SetPictureBoxImage(
                    picLicenseBack,
                    _state.License.BackPhotoPath);

            }

            picCustomerPhoto.Image = _imageService.LoadImage(c.PhotoPath);
            UpdateAgeLabel();
        }

        private void ClearForm()
        {
            _state.Reset();

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
                _state.ProfileImage = Image.FromFile(dialog.FileName);
                picCustomerPhoto.Image = _state.ProfileImage;
            }
        }

        private void BtnProfileCamera_Click(object sender, EventArgs e)
        {
            using var form = new CameraForm("Capture Profile Photo");
            if (form.ShowDialog() == DialogResult.OK)
            {
                _state.ProfileImage = (Image)form.CapturedImage.Clone();
                picCustomerPhoto.Image = _state.ProfileImage;
            }
        }

        // =====================================================
        // OTHER BUTTONS
        // =====================================================

        private void BtnCaptureLicense_Click(object sender, EventArgs e)
        {
            if (_state.SelectedCustomer == null)
                return;

            using var form = new DriverLicenseCaptureForm();
            if (form.ShowDialog() != DialogResult.OK)
                return;

            _state.LicenseFrontStream = form.GetFrontImageStream();
            _state.LicenseBackStream = form.GetBackImageStream();

            _driversLicenseService.SaveDriversLicense(
                _state.SelectedCustomer.DriversLicenseId,
                txtLicenseNum.Text.Trim(),
                dtpIssueDate.Value.Date,
                dtpExpiryDate.Value.Date,
                txtLicenseState.Text.Trim(),
                _state.LicenseFrontStream, "front.jpg",
                _state.LicenseBackStream, "back.jpg"
            );

            _state.License =
                _driversLicenseService.GetDriversLicenseById(
                    _state.SelectedCustomer.DriversLicenseId);

            _imageService.SetPictureBoxImage(
                picLicenseFront,
                _state.License.FrontPhotoPath);

            _imageService.SetPictureBoxImage(
                picLicenseBack,
                _state.License.BackPhotoPath);
        }

        private void BtnCheckDrivingRecord_Click(object sender, EventArgs e)
        {
            if (_state.SelectedCustomer == null)
                return;

            using var dialog = new DrivingRecordVerificationDialog();
            dialog.ShowDialog(this);
        }

        private void BtnEmergencyContacts_Click(object sender, EventArgs e)
        {
            if (_state.SelectedCustomer == null)
                return;

            using var form = new EmergencyContactsForm(
                _state.SelectedCustomer.Id,
                $"{_state.SelectedCustomer.FirstName} {_state.SelectedCustomer.LastName}");
            form.ShowDialog();
        }

        private void UpdateSaveButtonState()
        {
            btnSave.Enabled =
                !string.IsNullOrWhiteSpace(txtFirstName.Text) &&
                !string.IsNullOrWhiteSpace(txtLastName.Text);
        }

        private void UpdateAgeLabel()
        {
            int age = DateTime.Today.Year - dtpDOB.Value.Year;
            if (dtpDOB.Value.Date > DateTime.Today.AddYears(-age))
                age--;

            lblAgeCheck.Text = $"Age: {age}";
            lblAgeCheck.ForeColor = age >= 21 ? Color.Green : Color.Red;
        }

        private void btnManageAccount_Click(object sender, EventArgs e)
        {
            if (_state.SelectedCustomer == null)
            {
                MessageBox.Show("Please select a customer first.");
                return;
            }

            using var form = new CustomerAccountForm(
                _state.SelectedCustomer,
                _customerAccountService
            );
            form.ShowDialog(this);
        }
    }
}