using System;
using System.Drawing;
using System.Windows.Forms;
using VRMS.Controls;

namespace VRMS
{
    public partial class Welcome : Form
    {
        private UserControl currentUC;
        private bool isAnimating, showingLogin = true;
        private float slideProgress;
        private int animationTime;

        private const int TOTAL_ANIMATION_TIME = 800;

        public Welcome()
        {
            InitializeComponent();

            DoubleBuffered = true;

            Load += (s, e) =>
            {
                WindowState = FormWindowState.Maximized;
                UpdateLayout();
            };

            Resize += (s, e) => UpdateLayout();
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            if (isAnimating) return;

            btnProceed.Enabled = false;
            isAnimating = true;

            LoadControl(new LoginUserControl());

            panelLogin.Visible = true;
            panelLogin.Left = -panelLogin.Width;

            animationTimer.Start();
        }

        private void LoadControl(UserControl uc)
        {
            panelLogin.Controls.Clear();
            currentUC = uc;

            if (uc is LoginUserControl log)
            {
                log.GoToRegisterRequest += (s, e) =>
                {
                    showingLogin = false;
                    LoadControl(new RegisterUserControl());
                };

                log.ExitApplication += (s, e) => Application.Exit();
                log.LoginSuccess += LoginUC_LoginSuccess;
            }
            else if (uc is RegisterUserControl reg)
            {
                reg.GoBackToLoginRequest += (s, e) =>
                {
                    showingLogin = true;
                    LoadControl(new LoginUserControl());
                };
            }

            panelLogin.Controls.Add(uc);
            CenterUC(uc);
            panelLogin.BringToFront();
            FocusContent();
        }

        private void LoginUC_LoginSuccess(object sender, EventArgs e)
        {
            var mainForm = new VRMS.Forms.MainForm();

            mainForm.Show();
            Hide();

            mainForm.FormClosed += (s, args) => Application.Exit();
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            animationTime += animationTimer.Interval;

            if (animationTime < TOTAL_ANIMATION_TIME)
            {
                slideProgress = animationTime / (float)TOTAL_ANIMATION_TIME;

                float eased = EaseOutCubic(slideProgress);

                panelLeft.Left = (int)(ClientSize.Width * eased);
                panelLogin.Left = -panelLogin.Width + (int)(panelLogin.Width * eased);

                UpdateFade();
            }
            else
            {
                FinishAnimation();
            }
        }

        private void FinishAnimation()
        {
            animationTimer.Stop();

            panelLeft.Left = ClientSize.Width;
            panelLogin.Left = 0;
            panelLeft.Visible = false;

            BackColor = panelRight.BackColor = Color.White;

            FocusContent();
            isAnimating = false;
        }

        private void UpdateFade()
        {
            if (slideProgress <= 0.1f) return;

            int val = Math.Min(
                255,
                30 + (int)(225 * EaseOutQuad((slideProgress - 0.1f) / 0.9f))
            );

            BackColor = panelRight.BackColor = Color.FromArgb(255, val, val, val);
        }

        private void FocusContent()
        {
            if (currentUC is LoginUserControl log)
                log.FocusUsername();
            else
                currentUC?.Focus();
        }

        private void CenterUC(Control c)
        {
            if (c == null) return;

            c.Location = new Point(
                (panelLogin.Width - c.Width) / 2,
                (panelLogin.Height - c.Height) / 2
            );
        }

        private void UpdateLayout()
        {
            panelRight.Size = panelLogin.Size = ClientSize;

            panelLeft.Size = new Size(
                Math.Max(400, (int)(ClientSize.Width * 0.4)),
                ClientSize.Height
            );

            CenterUC(currentUC);
        }

        private float EaseOutCubic(float t) => 1 - (float)Math.Pow(1 - t, 3);
        private float EaseOutQuad(float t) => 1 - (1 - t) * (1 - t);
    }
}
