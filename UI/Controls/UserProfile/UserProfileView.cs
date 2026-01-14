using System;
using System.Drawing;
using System.Windows.Forms;
using VRMS.Models.Accounts;
using VRMS.Services.Account;
using VRMS.UI.ApplicationService;

namespace VRMS.Controls.UserProfile
{
    public partial class UserProfileView : UserControl
    {
        // For rounded corners - you can remove if not needed
        private const int BorderRadius = 10;

        private readonly UserService _userService;
        private readonly int _userId;

        private User? _originalUser;
        
        public UserProfileView(int userId)
            : this(
                ApplicationServices.UserService,
                userId)
        {
        }

        public UserProfileView(UserService userService, int userId)
        {
            _userService = userService;
            _userId = userId;

            InitializeComponent();
            SetupView();
            LoadUserData();
        }

        private void SetupView()
        {
            // Set initial values and styling
            txtUsername.BackColor = Color.FromArgb(245, 245, 245);
            txtUsername.ForeColor = Color.FromArgb(100, 100, 100);

            // Add placeholder text hints
            txtFullName.PlaceholderText = "Enter your full name";
            txtEmail.PlaceholderText = "example@email.com";
            txtPhone.PlaceholderText = "+1234567890";

            // Subscribe to events
            btnSave.Click += BtnSave_Click;
            btnChangePassword.Click += BtnChangePassword_Click;
            picProfile.Click += PicProfile_Click;

            // ADDED: Subscribe to the edit photo button click
            btnEditPhoto.Click += BtnEditPhoto_Click;

            // Text change validation
            txtFullName.TextChanged += ValidateFields;
            txtEmail.TextChanged += ValidateFields;
            txtPhone.TextChanged += ValidateFields;
        }

        private void LoadUserData()
        {
            _originalUser = _userService.GetById(_userId);

            lblProfileName.Text = _originalUser.Username;
            lblProfileRole.Text = _originalUser.Role.ToString();

            txtUsername.Text = _originalUser.Username;
            txtFullName.Text = _originalUser.FullName ?? "";
            txtEmail.Text = _originalUser.Email ?? "";
            txtPhone.Text = _originalUser.Phone ?? "";

            var fullPhotoPath = Path.Combine(
                AppContext.BaseDirectory,
                "Storage",
                _originalUser.PhotoPath
            );

            if (File.Exists(fullPhotoPath))
            {
                using var fs = new FileStream(fullPhotoPath, FileMode.Open, FileAccess.Read);
                picProfile.Image = Image.FromStream(fs);
            }

            btnSave.Enabled = false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                _userService.UpdateSelfProfile(
                    _userId,
                    txtFullName.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtPhone.Text.Trim()
                );

                MessageBox.Show(
                    "Profile updated successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Refresh baseline
                LoadUserData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            if (!ValidatePasswordFields())
                return;

            try
            {
                _userService.ChangePassword(
                    _userId,
                    txtCurrentPassword.Text,
                    txtNewPassword.Text
                );

                MessageBox.Show(
                    "Password changed successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearPasswordFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void PicProfile_Click(object? sender, EventArgs e)
        {
            OpenProfilePictureDialog();
        }

        // ADDED: New method for handling edit photo button click
        private void BtnEditPhoto_Click(object? sender, EventArgs e)
        {
            OpenProfilePictureDialog();
        }

        // ADDED: Extracted common logic for opening profile picture dialog
        private void OpenProfilePictureDialog()
        {
            using var dialog = new OpenFileDialog
            {
                Title = "Select Profile Picture",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Multiselect = false
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using var stream = File.OpenRead(dialog.FileName);

                _userService.SetUserPhoto(
                    _userId,
                    stream,
                    Path.GetFileName(dialog.FileName)
                );

                // Reload user + image
                LoadUserData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Profile Photo Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Full name is required", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email is required", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        private bool ValidatePasswordFields()
        {
            if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text))
            {
                MessageBox.Show("Current password is required", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCurrentPassword.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                MessageBox.Show("New password is required", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return false;
            }

            if (txtNewPassword.Text.Length < 6)
            {
                MessageBox.Show("New password must be at least 6 characters", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return false;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("New password and confirmation do not match", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void ValidateFields(object sender, EventArgs e)
        {
            bool hasChanges = HasProfileChanges();
            btnSave.Enabled = hasChanges;
            btnSave.BackColor = hasChanges ? Color.FromArgb(46, 204, 113) : Color.FromArgb(189, 195, 199);
        }

        private bool HasProfileChanges()
        {
            if (_originalUser == null)
                return false;

            return
                txtFullName.Text != (_originalUser.FullName ?? "") ||
                txtEmail.Text != (_originalUser.Email ?? "") ||
                txtPhone.Text != (_originalUser.Phone ?? "");
        }


        private void ClearPasswordFields()
        {
            txtCurrentPassword.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
        }
        
    }
}