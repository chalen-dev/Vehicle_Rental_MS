using System;
using System.Drawing;
using System.Windows.Forms;
using VRMS.Controls;
using VRMS.Enums;
using VRMS.Forms;
using VRMS.Models.Accounts;
using VRMS.Repositories.Accounts;
using VRMS.Services.Account;
using VRMS.UI.ApplicationService;
using VRMS.UI.Config.Animation;
using VRMS.UI.Config.Support;
using VRMS.UI.Forms.Main;

namespace VRMS.UI.Forms
{
    public partial class Welcome : Form, IAnimationHost
    {
        private UserControl? _currentControl;
        private readonly IAnimationManager _animationManager;
        private readonly UserService _userService =
            ApplicationServices.UserService;

        private readonly CustomerAuthService _customerAuthService =
            ApplicationServices.CustomerAuthService;

        public Welcome()
        {
            InitializeComponent();

            _animationManager = new WelcomeFormAnimationManager(this);
            _animationManager.AnimationCompleted += (_, __) => FocusContent();

            InitializeForm();
        }


        // =========================
        // FORM INIT
        // =========================
        private void InitializeForm()
        {
            DoubleBuffered = true;

            Load += (_, __) =>
            {
                WindowState = FormWindowState.Maximized;
                UpdateLayout();
                panelLogin.Visible = false;
            };

            Resize += (_, __) => UpdateLayout();
        }

        // =========================
        // ENTRY POINT
        // =========================
        private void btnProceed_Click(object sender, EventArgs e)
        {
            if (_animationManager.IsAnimating)
                return;

            LoadControl(
                new LoginUserControl(
                    _userService,
                    _customerAuthService
                )
            );

            panelLogin.Visible = true;
            panelLogin.Left = -panelLogin.Width;

            _animationManager.StartSlideAnimation();
        }

        // =========================
        // CONTROL LOADER
        // =========================
        private void LoadControl(UserControl control)
        {
            panelLogin.Controls.Clear();
            _currentControl = control;

            if (control is LoginUserControl login)
            {
                login.GoToRegisterRequest += (_, __) =>
                {
                    LoadControl(new RegisterUserControl(_userService));
                };

                login.ExitApplication += (_, __) => Application.Exit();

                login.LoginSuccess += (_, __) =>
                {
                    HandleLoginSuccess(login);
                };
            }
            else if (control is RegisterUserControl register)
            {
                register.GoBackToLoginRequest += (_, __) =>
                {
                    LoadControl(
                        new LoginUserControl(
                            _userService,
                            _customerAuthService
                        )
                    );
                };
            }

            panelLogin.Controls.Add(control);
            CenterControl(control);
            panelLogin.BringToFront();
        }

        // =========================
        // LOGIN SUCCESS HANDLER
        // =========================
        private void HandleLoginSuccess(LoginUserControl login)
        {
            // =========================
            // INTERNAL USER (AGENT)
            // =========================
            if (login.LoggedInUser != null)
            {
                var user = login.LoggedInUser;

                Session.CurrentUser = user;
                Program.CurrentUserId = user.Id;
                Program.CurrentUsername = user.Username;
                Program.CurrentUserRole = user.Role.ToString();

                var mainForm = new MainForm();
                mainForm.Show();
                Hide();

                mainForm.FormClosed += (_, __) => Application.Exit();
                return;
            }

            // =========================
            // CUSTOMER
            // =========================
            if (login.LoggedInCustomer != null)
            {
                Session.CurrentCustomer = login.LoggedInCustomer;

                var customerForm =
                    new CustomerMainForm(login.LoggedInCustomer);

                customerForm.Show();
                Hide();

                customerForm.FormClosed += OnChildFormClosed;
            }
        }

        // =========================
        // ANIMATION HOST
        // =========================
        public void OnAnimationStart()
        {
            btnProceed.Enabled = false;
            panelLogin.Visible = true;
        }

        public void UpdateAnimationFrame(float easedProgress, float rawProgress)
        {
            panelLeft.Left = (int)(ClientSize.Width * easedProgress);
            panelLogin.Left = -panelLogin.Width + (int)(panelLogin.Width * easedProgress);
        }

        public void OnAnimationComplete()
        {
            panelLeft.Visible = false;
            FocusContent();
        }

        // =========================
        // UI HELPERS
        // =========================
        private void FocusContent()
        {
            if (_currentControl is LoginUserControl login)
                login.FocusUsername();
            else
                _currentControl?.Focus();
        }

        private void CenterControl(Control control)
        {
            control.Location = new Point(
                (panelLogin.Width - control.Width) / 2,
                (panelLogin.Height - control.Height) / 2
            );
        }

        private void UpdateLayout()
        {
            panelRight.Size = panelLogin.Size = ClientSize;

            panelLeft.Size = new Size(
                Math.Max(400, (int)(ClientSize.Width * 0.4)),
                ClientSize.Height
            );

            if (_currentControl != null)
                CenterControl(_currentControl);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _animationManager.Dispose();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void OnChildFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
