using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VRMS.Helpers;
using VRMS.UI.ApplicationService;

namespace VRMS.UI.Forms.Receipts
{
    public partial class ReceiptForm : Form
    {
        private readonly int _rentalId;

        // ===============================
        // REQUIRED CONSTRUCTOR (RUNTIME)
        // ===============================
        public ReceiptForm(int rentalId)
        {
            if (rentalId <= 0)
                throw new ArgumentException("Invalid rental ID.");

            InitializeComponent();
            _rentalId = rentalId;

            Load += ReceiptForm_Load;
            btnPrint.Click += BtnPrint_Click;
            btnClose.Click += BtnClose_Click;
        }

        // ===============================
        // DESIGNER-ONLY CONSTRUCTOR
        // ===============================
        // ❌ NEVER USED AT RUNTIME
        private ReceiptForm()
        {
            InitializeComponent();
        }

        // ===============================
        // LOAD
        // ===============================
        private void ReceiptForm_Load(object sender, EventArgs e)
        {
            LoadReceipt();
        }

        // ===============================
        // LOAD RECEIPT DATA
        // ===============================
        private void LoadReceipt()
        {
            var rentalService = ApplicationServices.RentalService;
            var customerService = ApplicationServices.CustomerService;
            var vehicleService = ApplicationServices.VehicleService;
            var billingService = ApplicationServices.BillingService;

            // -------- RENTAL --------
            var rental = rentalService.GetRentalById(_rentalId);
            var vehicle = vehicleService.GetVehicleById(rental.VehicleId);

            // -------- CUSTOMER --------
            string customerName = "Walk-in";
            if (rental.CustomerId.HasValue)
            {
                var customer =
                    customerService.GetCustomerById(rental.CustomerId.Value);

                customerName = $"{customer.FirstName} {customer.LastName}";
            }

            // -------- HEADER --------
            lblReceiptNumber.Text = $"RENT-{rental.Id:D6}";
            lblCustomer.Text = customerName;
            lblVehicle.Text = $"{vehicle.Year} {vehicle.Make} {vehicle.Model}";
            lblStatus.Text = rental.Status.ToString();

            // -------- DATES --------
            DateTime start = rental.PickupDate;
            DateTime end =
                rental.ActualReturnDate ?? rental.ExpectedReturnDate;

            lblPeriod.Text =
                $"{start:MMM dd, yyyy} → {end:MMM dd, yyyy}";

            lblIssuedDate.Text =
                DateTime.Now.ToString("MMM dd, yyyy");

            // -------- DURATION --------
            int days =
                Math.Max(1, (end.Date - start.Date).Days);

            lblDuration.Text = $"{days} day(s)";

            // -------- ODOMETER --------
            if (rental.EndOdometer.HasValue)
            {
                lblOdometer.Text =
                    $"{rental.StartOdometer:N0} km → {rental.EndOdometer.Value:N0} km";
            }
            else
            {
                lblOdometer.Text =
                    $"{rental.StartOdometer:N0} km";
            }

            // -------- BILLING (AUTHORITATIVE) --------
            var invoice =
                billingService.GetInvoiceByRental(_rentalId);

            if (invoice == null)
            {
                lblBillingInfo.Text =
                    "No invoice has been generated yet.";
                lblBillingInfo.ForeColor = Color.Gray;
                return;
            }

            decimal balance =
                billingService.GetInvoiceBalance(invoice.Id);

            lblBillingInfo.Text =
                $"Invoice #: INV-{invoice.Id:D6}\n" +
                $"Generated: {invoice.GeneratedDate:MMM dd, yyyy}\n\n" +
                $"Total Amount: ₱ {invoice.TotalAmount:N2}\n" +
                $"Outstanding Balance: ₱ {balance:N2}\n\n" +
                $"Status: {invoice.Status}";

            lblBillingInfo.ForeColor = Color.Black;
        }

        // ===============================
        // PRINT RECEIPT (PDF)
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

                ReceiptPdfGenerator.Generate(
                    filePath,
                    rental,
                    vehicle,
                    customerName);

                MessageBox.Show(
                    $"Receipt saved successfully:\n\n{filePath}",
                    "PDF Generated",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Process.Start("explorer.exe", baseDir);
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
            DialogResult = DialogResult.OK;
            Close(); 
        }
    }
}
