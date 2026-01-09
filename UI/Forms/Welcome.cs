using System;
using System.Drawing;
using System.Windows.Forms;
using VRMS.Controls;
using VRMS.Forms;
using VRMS.Models.Accounts;
using VRMS.Support;
using VRMS.UI.Animation;

namespace VRMS.UI.Forms
{
    public partial class Welcome : Form, IAnimationHost
    {
        private UserControl? _currentControl;
        private readonly IAnimationManager _animationManager;

        public Welcome()
        {
            InitializeComponent();

            _animationManager = new WelcomeFormAnimationManager(this);
            _animationManager.AnimationCompleted += (_, __) => FocusContent();

            InitializeForm();
        }

        private void InitializeForm()
        {
            DoubleBuffered = true;

            Load += (_, __) =>
            {
                WindowState = FormWindowState.Maximized;
                UpdateLayout();

                // ✅ IMPORTANT: initial hidden state
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

            LoadControl(new LoginUserControl());

            // ✅ RESET POSITION BEFORE ANIMATION
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
                    LoadControl(new RegisterUserControl());
                };

                login.ExitApplication += (_, __) => Application.Exit();

                login.LoginSuccess += (_, __) =>
                {
                    if (login.LoggedInUser == null)
                        return;

                    HandleLoginSuccess(login.LoggedInUser);
                };
            }
            else if (control is RegisterUserControl register)
            {
                register.GoBackToLoginRequest += (_, __) =>
                {
                    LoadControl(new LoginUserControl());
                };
            }

            panelLogin.Controls.Add(control);
            CenterControl(control);
            panelLogin.BringToFront();
        }

        // =========================
        // LOGIN SUCCESS
        // =========================

        private void HandleLoginSuccess(User user)
        {
            Session.CurrentUser = user;

            Program.CurrentUsername = user.Username;
            Program.CurrentUserRole = user.Role.ToString();

            var mainForm = new MainForm();
            mainForm.Show();

            Hide();
            mainForm.FormClosed += (_, __) => Application.Exit();
        }

        // =========================
        // IAnimationHost
        // =========================

        public void OnAnimationStart()
        {
            btnProceed.Enabled = false;

            // ✅ ENSURE VISIBILITY DURING ANIMATION
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
            if (control == null) return;

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
    }
}
