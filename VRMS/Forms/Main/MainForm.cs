using System;
using System.Drawing;
using System.Windows.Forms;
using VRMS;               
using VRMS.Controls;     
using VRMS.Forms;          

namespace VRMS.Forms
{
    public partial class MainForm : Form
    {
        private Button activeButton = null;

        private readonly Color normalColor = Color.DarkSlateGray;
        private readonly Color hoverColor = Color.FromArgb(47, 79, 79);
        private readonly Color activeColor = Color.FromArgb(0, 120, 215);

        public MainForm()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            if (lbluserInfo != null)
            {
                lbluserInfo.Text =
                    $"Welcome,\n{Program.CurrentUsername}\n({Program.CurrentUserRole})";
            }

            Text = $"Vehicle Rental System - {Program.CurrentUsername}";

            if (Program.CurrentUserRole != "Admin" && btnAdmin != null)
            {
                btnAdmin.Visible = false;
            }

            SetupButtonEvents();

            ActivateButton(btnDashboard);
            ShowView(new DashboardView());
        }

        private void SetupButtonEvents()
        {
            Button[] navButtons =
            {
                btnDashboard,
                btnVehicles,
                btnCustomers,
                btnReservation,
                btnRentals,
                btnReports,
                btnAdmin
            };

            foreach (Button button in navButtons)
            {
                if (button == null) continue;

                button.Click += NavButton_Click;
                button.MouseEnter += (s, e) =>
                {
                    if (button != activeButton)
                        button.BackColor = hoverColor;
                };
                button.MouseLeave += (s, e) =>
                {
                    if (button != activeButton)
                        button.BackColor = normalColor;
                };
            }

            if (btnLogout != null)
            {
                btnLogout.Click += (s, e) => Logout();
            }
        }

        private void NavButton_Click(object sender, EventArgs e)
        {
            if (sender is not Button clickedButton) return;
            if (clickedButton == activeButton) return;

            ActivateButton(clickedButton);
            HandleNavigation(clickedButton);
        }

        private void ActivateButton(Button button)
        {
            if (activeButton != null)
            {
                activeButton.BackColor = normalColor;
                activeButton.Font = new Font(activeButton.Font, FontStyle.Bold);
            }

            button.BackColor = activeColor;
            activeButton = button;
        }

        private void HandleNavigation(Button button)
        {
            switch (button.Name)
            {
                case "btnDashboard":
                    ShowView(new DashboardView());
                    break;

                case "btnVehicles":
                    ShowView(new VehiclesView());
                    break;

                case "btnCustomers":
                    ShowView(new CustomersView());
                    break;

                case "btnReservation":
                    ShowView(new ReservationsView());
                    break;

                case "btnRentals":
                    ShowView(new RentalsView());
                    break;

                case "btnReports":
                    ShowView(new ReportsView());
                    break;

                case "btnAdmin":
                    ShowPlaceholder("Admin Management");
                    break;
            }
        }

        private void ShowView(UserControl view)
        {
            if (view == null) return;

            contentPanel.Controls.Clear();
            view.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(view);
        }

        private void ShowPlaceholder(string title)
        {
            contentPanel.Controls.Clear();

            Label lbl = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Location = new Point(50, 30),
                AutoSize = true
            };

            contentPanel.Controls.Add(lbl);
        }

        private void Logout()
        {
            if (MessageBox.Show(
                    "Are you sure you want to logout?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            Hide();
            new Welcome().Show();
        }
    }
}
