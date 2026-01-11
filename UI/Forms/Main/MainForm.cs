using System;
using System.Drawing;
using System.Windows.Forms;
using VRMS;
using VRMS.Controls;
using VRMS.Forms;
using VRMS.Controls.UserProfile;
using VRMS.Repositories.Accounts;
using VRMS.Services.Account;
using VRMS.UI.Forms; // Add this for UserProfileView

namespace VRMS.Forms
{
    public partial class MainForm : Form
    {
        private Button activeButton = null;
        
        private readonly UserService _userService;

        // THEME COLORS (match NewRentalForm)
        private readonly Color normalColor = Color.Transparent;
        private readonly Color hoverColor = Color.FromArgb(46, 204, 113);
        private readonly Color activeColor = Color.FromArgb(39, 174, 96);

        public MainForm()
        {
            InitializeComponent();

            _userService = new UserService(new UserRepository());

            SetupForm();
        }


        private void SetupForm()
        {
            // User info in sidebar
            if (lbluserInfo != null)
            {
                lbluserInfo.Text =
                    $"Welcome,\n{Program.CurrentUsername}\n({Program.CurrentUserRole})";
            }

            // Set header user info
            if (mainHeader != null)
            {
                mainHeader.SetUser(Program.CurrentUsername, Program.CurrentUserRole);

                // Subscribe to user info click event
                mainHeader.UserInfoClicked += MainHeader_UserInfoClicked;
            }

            Text = $"Vehicle Rental System - {Program.CurrentUsername}";

            // Role-based access
            if (Program.CurrentUserRole != "Admin" && btnAdmin != null)
            {
                btnAdmin.Visible = false;
            }

            SetupButtonEvents();

            // Default view
            ActivateButton(btnDashboard);
            ShowView(new DashboardView(), "Dashboard", "Overview and Key Metrics");
        }

        private void MainHeader_UserInfoClicked(object sender, EventArgs e)
        {
            // Navigate to User Profile when header user info is clicked
            NavigateToUserProfile();
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

                // Ensure clean base state
                button.BackColor = normalColor;
                button.FlatAppearance.BorderSize = 0;

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
            // Reset previous
            if (activeButton != null)
            {
                activeButton.BackColor = normalColor;
                activeButton.Font = new Font(activeButton.Font, FontStyle.Bold);
            }

            // Activate new
            button.BackColor = activeColor;
            activeButton = button;
        }

        private void HandleNavigation(Button button)
        {
            switch (button.Name)
            {
                case "btnDashboard":
                    ShowView(new DashboardView(), "Dashboard", "Overview and Key Metrics");
                    break;

                case "btnVehicles":
                    ShowView(new VehiclesView(), "Vehicles", "Manage Fleet Inventory");
                    break;

                case "btnCustomers":
                    ShowView(new CustomersView(), "Customers", "Customer Database");
                    break;

                case "btnReservation":
                    ShowView(new ReservationsView(), "Reservations", "Bookings and Scheduling");
                    break;

                case "btnRentals":
                    ShowView(new RentalsView(), "Rentals", "Active and Completed Rentals");
                    break;

                case "btnReports":
                    ShowView(new ReportsView(), "Reports", "Analytics and Insights");
                    break;

                case "btnAdmin":
                    ShowView(
                        new AdminView(_userService),
                        "Admin",
                        "System Management"
                    );
                    break;
            }
        }

        private void NavigateToUserProfile()
        {
            ShowView(
                new UserProfileView(
                    _userService,
                    Program.CurrentUserId
                ),
                "My Profile",
                "Manage your account settings"
            );

            if (activeButton != null)
            {
                activeButton.BackColor = normalColor;
                activeButton = null;
            }
        }

        private void ShowView(UserControl view, string title = "", string subtitle = "")
        {
            if (view == null) return;

            contentPanel.Controls.Clear();
            view.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(view);

            // Update header with view information
            UpdateHeaderTitle(title, subtitle);
        }

        private void UpdateHeaderTitle(string title, string subtitle = "")
        {
            if (mainHeader != null)
            {
                mainHeader.SetTitle(title, subtitle);
            }
        }

        private void ShowPlaceholder(string title)
        {
            contentPanel.Controls.Clear();

            Label lbl = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 62, 80),
                Location = new Point(50, 30),
                AutoSize = true
            };

            contentPanel.Controls.Add(lbl);
        }

        private void Logout()
        {
            if (MessageBox.Show(
                    "Are you sure you want to logout?",
                    "Confirm Logout",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            Hide();
            new Welcome().Show();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Clean up event handlers
            if (mainHeader != null)
            {
                mainHeader.UserInfoClicked -= MainHeader_UserInfoClicked;
            }

            base.OnFormClosed(e);
        }
    }
}