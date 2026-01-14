using System;
using System.Windows.Forms;
using VRMS.Enums;
using VRMS.Services.Account;
using VRMS.Models.Accounts;
using VRMS.UI.ApplicationService;

namespace VRMS.Controls
{
    public partial class LoginUserControl : UserControl
    {
        private readonly CustomerAuthService _customerAuthService;

        public CustomerAccount? LoggedInCustomer { get; private set; }
        public event EventHandler? GoToRegisterRequest;
        public event EventHandler? LoginSuccess;
        public event EventHandler? ExitApplication;
        

        private readonly UserService _userService;

        // Store logged-in user
        public User? LoggedInUser { get; private set; }
        
        public LoginUserControl()
            : this(
                ApplicationServices.UserService,
                ApplicationServices.CustomerAuthService)
        {
        }
        
        internal LoginUserControl(
            UserService userService,
            CustomerAuthService customerAuthService)
        {
            InitializeComponent();

            _userService = userService;
            _customerAuthService = customerAuthService;

            rbAgent.Checked = true;
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
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            try
            {
                if (rbAgent.Checked)
                {
                    // =========================
                    // AGENT LOGIN
                    // =========================
                    var user = _userService.Authenticate(username, password);

                    if (!user.IsActive)
                        throw new InvalidOperationException("Account inactive.");

                    LoggedInUser = user;
                }
                else
                {
                    // =========================
                    // CUSTOMER LOGIN
                    // =========================
                    var customer =
                        _customerAuthService.Authenticate(username, password);

                    LoggedInCustomer = customer;
                }

                LoginSuccess?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login Failed");
            }
        }



        public void FocusUsername()
        {
            txtUsername.Focus();
            txtUsername.SelectAll();
        }
    }
}
