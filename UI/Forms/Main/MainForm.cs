using System;
using System.Drawing;
using System.Windows.Forms;
using VRMS;
using VRMS.Controls;
using VRMS.Forms;
using VRMS.Controls.UserProfile;
using VRMS.Repositories.Accounts;
using VRMS.Services.Account;
using VRMS.UI.Forms;
using VRMS.UI.Controls.CustomerVehicleCatalog;

namespace VRMS.Forms
{
    public partial class MainForm : Form
    {
        private Button activeButton = null;

        private readonly UserService _userService;

        // THEME COLORS
        private readonly Color normalColor = Color.Transparent;
        private readonly Color hoverColor = Color.FromArgb(46, 204, 113);
        private readonly Color activeColor = Color.FromArgb(39, 174, 96);

        public MainForm()
        {
            InitializeComponent();

            _userService = new UserService(new UserRepository());

            SetupForm();
        }

        // =====================================================
        // ROLE HELPERS
        // =====================================================

        private bool IsCustomer()
        {
            return Program.CurrentUserRole.Equals("Customer", StringComparison.OrdinalIgnoreCase);
        }

        private bool IsAdmin()
        {
            return Program.CurrentUserRole.Equals("Admin", StringComparison.OrdinalIgnoreCase);
        }

        // =====================================================
        // INITIAL SETUP
        // =====================================================

        private void SetupForm()
        {
            // Sidebar user info
            if (lbluserInfo != null)
            {
                lbluserInfo.Text =
                    $"Welcome,\n{Program.CurrentUsername}\n({Program.CurrentUserRole})";
            }

            // Header user info
            if (mainHeader != null)
            {
                mainHeader.SetUser(Program.CurrentUsername, Program.CurrentUserRole);
                mainHeader.UserInfoClicked += MainHeader_UserInfoClicked;
            }

            Text = $"Vehicle Rental System - {Program.CurrentUsername}";

            ApplyRoleBasedVisibility();
            SetupButtonEvents();
            LoadDefaultView();
        }

        private void ApplyRoleBasedVisibility()
        {
            // CUSTOMER UI RULES
            if (IsCustomer())
            {
                btnCustomers.Visible = false;
                btnReports.Visible = false;
                btnAdmin.Visible = false;
            }

            // NON-ADMIN RULES
            if (!IsAdmin())
            {
                btnAdmin.Visible = false;
            }
        }

        private void LoadDefaultView()
        {
            if (IsCustomer())
            {
                ActivateButton(btnVehicles);
                ShowView(
                    new CustomerVehicleCatalog(),
                    "Vehicle Catalog",
                    "Browse & rent available vehicles"
                );
            }
            else
            {
                ActivateButton(btnDashboard);
                ShowView(
                    new DashboardView(),
                    "Dashboard",
                    "Overview and Key Metrics"
                );
            }
        }

        // =====================================================
        // HEADER EVENTS
        // =====================================================

        private void MainHeader_UserInfoClicked(object sender, EventArgs e)
        {
            NavigateToUserProfile();
        }

        // =====================================================
        // NAVIGATION BUTTONS
        // =====================================================

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
            if (activeButton != null)
            {
                activeButton.BackColor = normalColor;
            }

            button.BackColor = activeColor;
            activeButton = button;
        }

        // =====================================================
        // ROLE-BASED NAVIGATION
        // =====================================================

        private void HandleNavigation(Button button)
        {
            switch (button.Name)
            {
                case "btnDashboard":
                    ShowView(
                        new DashboardView(),
                        "Dashboard",
                        "Overview and Key Metrics"
                    );
                    break;

                case "btnVehicles":
                    if (IsCustomer())
                    {
                        ShowView(
                            new CustomerVehicleCatalog(),
                            "Vehicle Catalog",
                            "Browse & rent available vehicles"
                        );
                    }
                    else
                    {
                        ShowView(
                            new VehiclesView(),
                            "Vehicles",
                            "Manage Fleet Inventory"
                        );
                    }
                    break;

                case "btnCustomers":
                    ShowView(
                        new CustomersView(),
                        "Customers",
                        "Customer Database"
                    );
                    break;

                case "btnReservation":
                    ShowView(
                        new ReservationsView(),
                        "Reservations",
                        "Bookings and Scheduling"
                    );
                    break;

                case "btnRentals":
                    ShowView(
                        new RentalsView(),
                        "Rentals",
                        "Active and Completed Rentals"
                    );
                    break;

                case "btnReports":
                    ShowView(
                        new ReportsView(),
                        "Reports",
                        "Analytics and Insights"
                    );
                    break;

                case "btnAdmin":
                    if (!IsAdmin())
                    {
                        MessageBox.Show(
                            "You do not have permission to access this section.",
                            "Access Denied",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    ShowView(
                        new AdminView(_userService),
                        "Administration",
                        "User & System Management"
                    );
                    break;
            }
        }

        // =====================================================
        // USER PROFILE
        // =====================================================

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

        // =====================================================
        // VIEW HANDLING
        // =====================================================

        private void ShowView(UserControl view, string title = "", string subtitle = "")
        {
            if (view == null) return;

            contentPanel.Controls.Clear();
            view.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(view);

            UpdateHeaderTitle(title, subtitle);
        }

        private void UpdateHeaderTitle(string title, string subtitle)
        {
            if (mainHeader != null)
            {
                mainHeader.SetTitle(title, subtitle);
            }
        }

        // =====================================================
        // LOGOUT
        // =====================================================

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

        // =====================================================
        // CLEANUP
        // =====================================================

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (mainHeader != null)
            {
                mainHeader.UserInfoClicked -= MainHeader_UserInfoClicked;
            }

            base.OnFormClosed(e);
        }
    }
}
