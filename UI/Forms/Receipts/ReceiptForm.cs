using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using VRMS.Services.Rental;
using VRMS.Services.Customer;
using VRMS.Services.Fleet;
using VRMS.UI.Config.ApplicationService;



namespace VRMS.UI.Forms.Receipts
{
    public partial class ReceiptForm : Form
    {
        private readonly int _rentalId;

        // REQUIRED constructor (used by History)
        public ReceiptForm(int rentalId)
        {
            InitializeComponent();
            _rentalId = rentalId;

            Load += ReceiptForm_Load;
            btnPrint.Click += BtnPrint_Click;
            btnClose.Click += BtnClose_Click;
        }

        // Parameterless constructor (Designer support)
        public ReceiptForm()
        {
            InitializeComponent();
            btnClose.Click += BtnClose_Click;
        }

        private void ReceiptForm_Load(object sender, EventArgs e)
        {
            LoadReceipt();
        }

        private void LoadReceipt()
        {
            var rentalService = ApplicationServices.RentalService;
            var customerService = ApplicationServices.CustomerService;
            var vehicleService = ApplicationServices.VehicleService;

            var rental = rentalService.GetRentalById(_rentalId);
            var vehicle = vehicleService.GetVehicleById(rental.VehicleId);

            string customerName = "Walk-in";

            if (rental.CustomerId.HasValue)
            {
                var customer =
                    customerService.GetCustomerById(rental.CustomerId.Value);

                customerName =
                    $"{customer.FirstName} {customer.LastName}";
            }

            lblReceiptNumber.Text = $"RENT-{rental.Id:D6}";
            lblCustomer.Text = customerName;
            lblVehicle.Text = $"{vehicle.Make} {vehicle.Model}";
            lblPeriod.Text =
                $"{rental.PickupDate:MMM dd, yyyy} → {rental.ExpectedReturnDate:MMM dd, yyyy}";
            lblStatus.Text = rental.Status.ToString();

            lblBillingInfo.Text =
                "Billing details are not available yet.";
        }

        // ===============================
        // SAVE RECEIPT AS IMAGE
        // ===============================

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var rentalService = ApplicationServices.RentalService;
                var customerService = ApplicationServices.CustomerService;
                var vehicleService = ApplicationServices.VehicleService;

                var rental = rentalService.GetRentalById(_rentalId);
                var vehicle = vehicleService.GetVehicleById(rental.VehicleId);

                string customerName = "Walk-in";
                if (rental.CustomerId.HasValue)
                {
                    var customer =
                        customerService.GetCustomerById(rental.CustomerId.Value);
                    customerName = $"{customer.FirstName} {customer.LastName}";
                }

                string baseDir =
                    Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                        "VRMS",
                        "Receipts");

                Directory.CreateDirectory(baseDir);

                string filePath =
                    Path.Combine(
                        baseDir,
                        $"Receipt_RENT-{rental.Id:D6}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

                VRMS.UI.Pdf.ReceiptPdfGenerator.Generate(
                    filePath,
                    rental,
                    vehicle,
                    customerName);

                MessageBox.Show(
                    $"Receipt saved successfully:\n\n{filePath}",
                    "PDF Generated",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                System.Diagnostics.Process.Start("explorer.exe", baseDir);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "PDF Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }



        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
