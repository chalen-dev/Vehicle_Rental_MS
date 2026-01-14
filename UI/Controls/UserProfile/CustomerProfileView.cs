using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VRMS.Models.Customers;
using VRMS.Services.Customer;
using VRMS.Services.Account;
using VRMS.UI.ApplicationService;
using VRMS.UI.Services;

namespace VRMS.UI.Controls.UserProfile
{
    public partial class CustomerProfileView : UserControl
    {
        private readonly CustomerService _customerService;
        private readonly CustomerAccountService _accountService;
        private readonly CustomerImageService _imageService = new();

        private Customer? _originalCustomer;
        
        public CustomerProfileView(int customerId)
            : this(
                ApplicationServices.CustomerService,
                ApplicationServices.CustomerAccountService,
                customerId)
        {
        }

        public CustomerProfileView(
            CustomerService customerService,
            CustomerAccountService accountService,
            int customerId)
        {
            _customerService = customerService;
            _accountService = accountService;

            InitializeComponent();
            WireEvents();
            LoadCustomer(customerId);
        }

        // =====================================================
        // LOAD CUSTOMER
        // =====================================================
        private void LoadCustomer(int customerId)
        {
            _originalCustomer = _customerService.GetCustomerById(customerId);

            lblProfileName.Text =
                $"{_originalCustomer.FirstName} {_originalCustomer.LastName}";
            lblProfileRole.Text = "(Customer)";

            txtUsername.Text = _originalCustomer.Email; // customer login
            txtFullName.Text =
                $"{_originalCustomer.FirstName} {_originalCustomer.LastName}";
            txtEmail.Text = _originalCustomer.Email;
            txtPhone.Text = _originalCustomer.Phone;

            // ✅ CORRECT IMAGE LOAD (same as admin/agent)
            picProfile.Image =
                _imageService.LoadImage(_originalCustomer.PhotoPath);

            btnSave.Enabled = false;
        }

        // =====================================================
        // EVENTS
        // =====================================================
        private void WireEvents()
        {
            btnSave.Click += BtnSave_Click;
            btnChangePassword.Click += BtnChangePassword_Click;
            btnEditPhoto.Click += BtnEditPhoto_Click;

            txtFullName.TextChanged += (_, __) => DetectChanges();
            txtEmail.TextChanged += (_, __) => DetectChanges();
            txtPhone.TextChanged += (_, __) => DetectChanges();
        }

        // =====================================================
        // SAVE PROFILE (NO SERVICE CHANGES)
        // =====================================================
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (_originalCustomer == null)
                return;

            var names = txtFullName.Text.Trim().Split(' ', 2);
            string firstName = names[0];
            string lastName = names.Length > 1 ? names[1] : "";

            try
            {
                _customerService.UpdateCustomer(
                    _originalCustomer.Id,
                    firstName,
                    lastName,
                    txtEmail.Text.Trim(),
                    txtPhone.Text.Trim(),
                    _originalCustomer.Address,
                    _originalCustomer.DateOfBirth,
                    _originalCustomer.Category,
                    _originalCustomer.IsFrequent,
                    _originalCustomer.IsBlacklisted
                );

                MessageBox.Show(
                    "Profile updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadCustomer(_originalCustomer.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Update Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =====================================================
        // PASSWORD CHANGE (UNCHANGED FEATURE)
        // =====================================================
        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text) ||
                string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                MessageBox.Show("Please fill all password fields.");
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            try
            {
                var account =
                    _accountService.GetByCustomerId(_originalCustomer!.Id);

                if (account == null)
                {
                    MessageBox.Show("No account found.");
                    return;
                }

                _accountService.ResetPassword(
                    account.Id,
                    txtNewPassword.Text
                );

                MessageBox.Show(
                    "Password updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                txtCurrentPassword.Clear();
                txtNewPassword.Clear();
                txtConfirmPassword.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Password Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =====================================================
        // PROFILE PHOTO (FIXED — SAME AS ADMIN)
        // =====================================================
        private void BtnEditPhoto_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "Images|*.jpg;*.jpeg;*.png",
                Title = "Select Profile Picture"
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using var stream = File.OpenRead(dialog.FileName);

                // ✅ USE SERVICE (STORAGE + DB CONSISTENT)
                _customerService.SetCustomerPhoto(
                    _originalCustomer!.Id,
                    stream,
                    Path.GetFileName(dialog.FileName)
                );

                LoadCustomer(_originalCustomer.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Photo Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =====================================================
        // CHANGE DETECTION
        // =====================================================
        private void DetectChanges()
        {
            if (_originalCustomer == null)
            {
                btnSave.Enabled = false;
                return;
            }

            bool changed =
                txtFullName.Text.Trim() !=
                    $"{_originalCustomer.FirstName} {_originalCustomer.LastName}" ||
                txtEmail.Text.Trim() != _originalCustomer.Email ||
                txtPhone.Text.Trim() != _originalCustomer.Phone;

            btnSave.Enabled = changed;
        }
    }
}
