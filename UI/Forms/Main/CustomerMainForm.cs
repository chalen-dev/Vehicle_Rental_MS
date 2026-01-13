using System;
using System.Windows.Forms;
using VRMS.Models.Accounts;
using VRMS.Models.Customers;
using VRMS.Services.Customer;
using VRMS.Services.Account;
using VRMS.Repositories.Accounts;
using VRMS.UI.Controls.CustomerVehicleCatalog;
using VRMS.Controls;

namespace VRMS.UI.Forms.Main
{
    public partial class CustomerMainForm : Form
    {
        private readonly CustomerAccount _account;
        private readonly CustomerService _customerService;

        private VRMS.Models.Customers.Customer? _customer;
        private UserControl? _currentView;

        public CustomerMainForm()
        {
            InitializeComponent();
        }

        public CustomerMainForm(CustomerAccount account) : this()
        {
            _account = account;

            _customerService = new CustomerService(
                new DriversLicenseService(),
                new CustomerAccountService(
                    new CustomerAccountRepository()
                )
            );

            InitializeCustomer();
            LoadVehiclesView();
        }

        private void InitializeCustomer()
        {
            _customer =
                _customerService.GetCustomerById(_account.CustomerId);

            lblWelcome.Text =
                $"Welcome,\n{_customer.FirstName} {_customer.LastName}\n(Customer)";
        }

        private void btnVehicles_Click(object sender, EventArgs e)
        {
            LoadVehiclesView();
        }

        private void btnRentals_Click(object sender, EventArgs e)
        {
            LoadRentalsView();
        }

        private void LoadVehiclesView()
        {
            LoadView(new CustomerVehicleCatalog());
            HighlightActiveButton(btnVehicles);
        }

        private void LoadRentalsView()
        {
            LoadView(new CustomersRentalsView());
            HighlightActiveButton(btnRentals);
        }

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

        private void HighlightActiveButton(Button activeButton)
        {
            foreach (Control ctrl in navButtonsPanel.Controls)
            {
                if (ctrl is Button btn)
                    btn.BackColor = System.Drawing.Color.Transparent;
            }

            activeButton.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
        }
    }
}
