using System;
using System.Windows.Forms;

namespace VRMS.Controls
{
    public partial class LoginUserControl : UserControl
    {
        public event EventHandler GoToRegisterRequest;
        public event EventHandler LoginSuccess;
        public event EventHandler ExitApplication;

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

        // Clean event triggers using expression-bodied members
        private void btnLogin_Click(object sender, EventArgs e) => PerformLogin();
        private void btnGoToRegister_Click(object sender, EventArgs e) => GoToRegisterRequest?.Invoke(this, EventArgs.Empty);
        private void btnExit_Click(object sender, EventArgs e) => ExitApplication?.Invoke(this, EventArgs.Empty);

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformLogin();
                e.Handled = e.SuppressKeyPress = true;
            }
        }

        private void PerformLogin()
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text;

            // 1. Validation
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Please enter both username and password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (string.IsNullOrEmpty(user)) txtUsername.Focus(); else txtPassword.Focus();
                return;
            }

            try
            {
                // 2. Hard-coded Credential Check
                bool loginSuccess = (user == "lee" && pass == "123456");

                if (loginSuccess)
                {
                    txtPassword.Clear();
                    LoginSuccess?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.SelectAll();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ClearForm()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        public void FocusUsername()
        {
            txtUsername.Focus();
            txtUsername.SelectAll();
        }
    }
}