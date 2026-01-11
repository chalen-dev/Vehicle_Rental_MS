using System;
using System.Windows.Forms;
using VRMS.Forms.Payments;
using VRMS.Services.Customer;
using VRMS.Services.Fleet;
using VRMS.Models.Customers;
using VRMS.Models.Fleet;
using VRMS.Enums;

namespace VRMS.Forms
{
    public partial class NewRentalForm : Form
    {
        private readonly CustomerService _customerService;
        private readonly VehicleService _vehicleService;

        public NewRentalForm(
            CustomerService customerService,
            VehicleService vehicleService)
        {
            InitializeComponent();

            _customerService = customerService;
            _vehicleService = vehicleService;

            Load += NewRentalForm_Load;

            btnSave.Click += btnSave_Click;
            btnCancel.Click += (_, __) => Close();
        }

        // -------------------------------
        // LOAD DATA
        // -------------------------------
        private void NewRentalForm_Load(object? sender, EventArgs e)
        {
            LoadCustomers();
            LoadVehicles();
        }

        private void LoadCustomers()
        {
            cbCustomer.DataSource = null;
            cbCustomer.DataSource = _customerService.GetAllCustomers();
            cbCustomer.DisplayMember = "FullName"; // or build manually
            cbCustomer.ValueMember = "Id";
        }

        private void LoadVehicles()
        {
            cbVehicle.DataSource = null;
            cbVehicle.DataSource =
                _vehicleService
                    .GetAllVehicles()
                    .FindAll(v => v.Status == VehicleStatus.Available);

            cbVehicle.DisplayMember = "DisplayName";
            cbVehicle.ValueMember = "Id";
        }

        // -------------------------------
        // SAVE / NEXT STEP
        // -------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbCustomer.SelectedItem is not Customer customer)
                    throw new InvalidOperationException(
                        "Please select a customer.");

                if (cbVehicle.SelectedItem is not Vehicle vehicle)
                    throw new InvalidOperationException(
                        "Please select a vehicle.");

                if (!int.TryParse(txtOdometer.Text, out int odometer))
                    throw new InvalidOperationException(
                        "Invalid odometer value.");

                if (dtReturn.Value.Date <= dtPickup.Value.Date)
                    throw new InvalidOperationException(
                        "Return date must be after pickup date.");

                // UI-friendly strings
                string customerName =
                    $"{customer.FirstName} {customer.LastName}";

                string vehicleName =
                    $"{vehicle.Make} {vehicle.Model} ({vehicle.LicensePlate})";

                // TODO: Replace with RateService
                decimal estimatedTotal = 0m;

                lblTotal.Text =
                    $"Total: ₱{estimatedTotal:N2}";

                using var paymentForm =
                    new RentalDownPayment(
                        customerName,
                        vehicleName,
                        estimatedTotal);

                if (paymentForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show(
                        "Rental record created (pending backend integration).",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Cannot Proceed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
