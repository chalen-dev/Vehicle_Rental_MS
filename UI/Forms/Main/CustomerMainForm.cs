using System;
using System.Windows.Forms;
using VRMS.Models.Accounts;
using VRMS.Services.Customer;
using VRMS.Services.Account;
using VRMS.Repositories.Accounts;
using VRMS.Repositories.Billing;
using VRMS.Repositories.Fleet;
using VRMS.Repositories.Rentals;
using VRMS.Services.Fleet;
using VRMS.Services.Rental;
using VRMS.UI.Controls.CustomerVehicleCatalog;
using VRMS.UI.Controls.UserProfile;
using VRMS.UI.Forms.Rentals;
using VRMS.Controls;
using VRMS.UI.ApplicationService;

namespace VRMS.UI.Forms.Main
{
    public partial class CustomerMainForm : Form
    {
        private readonly CustomerAccount _account;
        private readonly CustomerService _customerService;

        private VRMS.Models.Customers.Customer? _customer;
        private UserControl? _currentView;

        // =========================
        // CONSTRUCTORS
        // =========================
        public CustomerMainForm()
        {
            InitializeComponent();

            // Header click → profile view
            mainHeader.UserInfoClicked += MainHeader_UserInfoClicked;
        }

        public CustomerMainForm(CustomerAccount account) : this()
        {
            _account = account;
            _customerService = ApplicationServices.CustomerService;

            InitializeCustomer();
            LoadVehiclesView();
        }

        // =========================
        // INITIALIZE CUSTOMER
        // =========================
        private void InitializeCustomer()
        {
            var customer =
                _customerService.GetCustomerById(_account.CustomerId);

            _customer = customer;

            // Sidebar welcome
            lblWelcome.Text =
                $"Welcome,\n{customer.FirstName} {customer.LastName}\n(Customer)";

            // Header user info
            mainHeader.SetUser(
                $"{customer.FirstName} {customer.LastName}",
                "Customer"
            );
        }

        // =========================
        // NAV BUTTON EVENTS
        // =========================
        private void btnVehicles_Click(object sender, EventArgs e)
        {
            LoadVehiclesView();
        }

        private void btnRentals_Click(object sender, EventArgs e)
        {
            LoadRentalsView();
        }

        // =========================
        // VEHICLES VIEW
        // =========================
        private void LoadVehiclesView()
        {
            if (_customer == null)
                return;

            mainHeader.SetTitle(
                "Browse Vehicles",
                "Find and reserve available vehicles"
            );

            LoadView(
                new CustomerVehicleCatalog(
                    ApplicationServices.VehicleService,
                    ApplicationServices.ReservationService,
                    _customer
                )
            );

            HighlightActiveButton(btnVehicles);
        }

        // =========================
        // RENTALS VIEW
        // =========================
        private void LoadRentalsView()
        {
            mainHeader.SetTitle(
                "My Rentals",
                "View and manage your rentals"
            );

            var rentalsView = new CustomersRentalsView();

            rentalsView.ProceedRentRequested += (_, __) =>
            {
                OpenCustomerRentalForm();
            };

            LoadView(rentalsView);
            HighlightActiveButton(btnRentals);
        }

        // =========================
        // PROFILE VIEW (HEADER CLICK)
        // =========================
        private void LoadCustomerProfileView()
        {
            if (_customer == null)
                return;

            mainHeader.SetTitle(
                "My Profile",
                "Manage your personal information"
            );

            var customerProfileView = new CustomerProfileView(
                ApplicationServices.CustomerService,
                ApplicationServices.CustomerAccountService,
                _customer.Id
            );

            LoadView(customerProfileView);

            // No sidebar button highlighted
            HighlightActiveButton(null);
        }

        private void MainHeader_UserInfoClicked(object? sender, EventArgs e)
        {
            LoadCustomerProfileView();
        }

        // =========================
        // OPEN RENTAL FORM (MODAL)
        // =========================
        private void OpenCustomerRentalForm()
        {
            using (var rentalForm = new CustomerRentalForm())
            {
                rentalForm.StartPosition = FormStartPosition.CenterParent;
                rentalForm.ShowDialog(this);
            }
        }

        // =========================
        // VIEW MANAGEMENT
        // =========================
        private void LoadView(UserControl view)
        {
            contentPanel.SuspendLayout();

            if (_currentView != null)
            {
                contentPanel.Controls.Remove(_currentView);
                _currentView.Dispose();
            }

            _currentView = view;
            view.Dock = DockStyle.Fill;

            contentPanel.Controls.Add(view);
            contentPanel.ResumeLayout();
        }

        private void HighlightActiveButton(Button? activeButton)
        {
            foreach (Control ctrl in navButtonsPanel.Controls)
            {
                if (ctrl is Button btn)
                    btn.BackColor = System.Drawing.Color.Transparent;
            }

            if (activeButton != null)
            {
                activeButton.BackColor =
                    System.Drawing.Color.FromArgb(44, 62, 80);
            }
        }
    }
}
