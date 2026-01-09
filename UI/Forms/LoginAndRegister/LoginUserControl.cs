using System;
using System.Windows.Forms;
using VRMS.Services.Account;
using VRMS.Models.Accounts;

namespace VRMS.Controls
{
    public partial class LoginUserControl : UserControl
    {
        public event EventHandler? GoToRegisterRequest;
        public event EventHandler? LoginSuccess;
        public event EventHandler? ExitApplication;

        private readonly UserService _userService = new();

        // ✅ Store logged-in user
        public User? LoggedInUser { get; private set; }

        public LoginUserControl()
        {
            InitializeComponent();
            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
            txtUsername.KeyDown += TextBox_KeyDown;
            txtPassword.KeyDown += TextBox_KeyDown;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            PerformLogin();
        }

        private void btnGoToRegister_Click(object sender, EventArgs e)
        {
            GoToRegisterRequest?.Invoke(this, EventArgs.Empty);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ExitApplication?.Invoke(this, EventArgs.Empty);
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformLogin();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void PerformLogin()
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Please enter both username and password.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                var user = _userService.Authenticate(username, password);

                if (!user.IsActive)
                {
                    MessageBox.Show(
                        "This account is inactive.",
                        "Access Denied",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // ✅ Save user
                LoggedInUser = user;

                txtPassword.Clear();

                // ✅ EventHandler signature is correct
                LoginSuccess?.Invoke(this, EventArgs.Empty);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Login error: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        public void FocusUsername()
        {
            txtUsername.Focus();
            txtUsername.SelectAll();
        }
    }
}
