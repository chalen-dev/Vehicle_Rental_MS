using System;
using System.Globalization;
using System.Windows.Forms;
using VRMS.Enums;
using VRMS.Models.Billing;
using VRMS.Repositories.Billing;
using VRMS.Repositories.Rentals;
using VRMS.Services.Billing;
using VRMS.UI.ApplicationService;

namespace VRMS.Forms
{
    public partial class PaymentForm : Form
    {
        private readonly int _rentalId;
        private readonly BillingService _billingService;
        private decimal _currentBalance = 0m;
        private Invoice _invoice = null!;
        public PaymentForm(int rentalId)
        {
            InitializeComponent();

            _rentalId = rentalId;
            _billingService = ApplicationServices.BillingService;

            // UI wiring
            Load += PaymentForm_Load;
            btnProcess.Click += BtnProcess_Click;

            // keep existing cancel behavior
            btnCancel.Click += (_, __) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };

            // live change calculation
        }


        
        private void PaymentForm_Load(object? sender, EventArgs e)
        {
            // Load invoice and balance (existing logic kept)
            _invoice =
                _billingService.GetInvoiceByRental(_rentalId)
                ?? throw new InvalidOperationException("Invoice not found.");

            _currentBalance =
                _billingService.GetInvoiceBalance(_invoice.Id);

            // Bind payment methods to the enum (overrides designer list safely)
            cbPaymentMethod.DataSource = Enum.GetValues(typeof(PaymentMethod));
            cbPaymentMethod.SelectedIndex = -1;

            // Fill summary (rental, customer, vehicle)
            try
            {
                var rentalRepo = new RentalRepository();
                var rental = rentalRepo.GetById(_rentalId);

                // Customer
                if (rental.CustomerId.HasValue)
                {
                    var customer = ApplicationServices.CustomerService.GetCustomerById(rental.CustomerId.Value);
                    lblCustomerName.Text = $"Customer: {customer.FullName}";
                }
                else
                {
                    lblCustomerName.Text = $"Customer: --";
                }

                // Vehicle
                var vehicle = ApplicationServices.VehicleService.GetVehicleById(rental.VehicleId);
                lblVehicleDetails.Text = $"Vehicle: {vehicle.Make} {vehicle.Model} ({vehicle.LicensePlate})";

                // Duration: use actual return date if present, else expected
                var end = rental.ActualReturnDate ?? rental.ExpectedReturnDate;
                var days = Math.Ceiling((end - rental.PickupDate).TotalDays);
                if (days <= 0) days = 1;
                lblRentalDuration.Text = $"Duration: {days} Days";

                // Billing breakdown: prefer invoice line items when present
                var lineRepo = new InvoiceLineItemRepository();
                var items = lineRepo.GetByInvoice(_invoice.Id);

                decimal baseRental = 0m;
                decimal lateFee = 0m;
                decimal mileageCharge = 0m;
                decimal damageTotal = 0m;

                if (items != null && items.Count > 0)
                {
                    baseRental = items
                        .Where(i => i.Description.IndexOf("base", StringComparison.OrdinalIgnoreCase) >= 0
                                 || i.Description.IndexOf("rental charge", StringComparison.OrdinalIgnoreCase) >= 0)
                        .Sum(i => i.Amount);

                    lateFee = items
                        .Where(i => i.Description.IndexOf("late", StringComparison.OrdinalIgnoreCase) >= 0)
                        .Sum(i => i.Amount);

                    mileageCharge = items
                        .Where(i => i.Description.IndexOf("mileage", StringComparison.OrdinalIgnoreCase) >= 0
                                 || i.Description.IndexOf("mileage overage", StringComparison.OrdinalIgnoreCase) >= 0)
                        .Sum(i => i.Amount);

                    damageTotal = items
                        .Where(i => i.Description.StartsWith("Damage:", StringComparison.OrdinalIgnoreCase)
                                 || i.Description.IndexOf("damage", StringComparison.OrdinalIgnoreCase) >= 0)
                        .Sum(i => i.Amount);
                }

                // Fallback: compute with RateService if something isn't present
                var rateSvc = ApplicationServices.RateService;
                if (baseRental == 0m)
                    baseRental = rateSvc.CalculateRentalCost(rental.PickupDate, end, vehicle.VehicleCategoryId);

                if (lateFee == 0m)
                    lateFee = rateSvc.CalculateLatePenalty(rental.ExpectedReturnDate, rental.ActualReturnDate ?? rental.ExpectedReturnDate, vehicle.VehicleCategoryId);

                if (mileageCharge == 0m && rental.EndOdometer.HasValue)
                    mileageCharge = rateSvc.CalculateMileageOverage(rental.StartOdometer, rental.EndOdometer.Value, rental.PickupDate, end, vehicle.VehicleCategoryId);

                // Fill labels
                lblBaseRental.Text = $"Rental Charges: ₱{baseRental:N2}";
                lblLateFee.Text = $"Late Fees: ₱{lateFee:N2}";
                lblDamageFee.Text = $"Damage Fees: ₱{damageTotal:N2}";
                lblFuelCharge.Text = $"Mileage Overage Fees: ₱{mileageCharge:N2}";

                // Grand total / balance (use authoritative balance from BillingService)
                lblGrandTotal.Text = $"TOTAL DUE: ₱{_currentBalance:N2}";
                
                // Force payment amount to exact total due
                txtAmountPaid.Text = _currentBalance.ToString("N2");

                // Reset change label
                lblChange.Text = "Change: ₱ --";
            }
            catch (Exception ex)
            {
                // Defensive: surface any problems loading lookup info but still show total
                lblCustomerName.Text = "Customer: --";
                lblVehicleDetails.Text = "Vehicle: --";
                lblRentalDuration.Text = "Duration: --";
                lblBaseRental.Text = "Rental Charges: ₱0.00";
                lblLateFee.Text = "Late Fees: ₱0.00";
                lblDamageFee.Text = "Damage Fees: ₱0.00";
                lblFuelCharge.Text = "Mileage Overage Fees: ₱0.00";
                lblGrandTotal.Text = $"TOTAL DUE: ₱{_currentBalance:N2}";

                // show error so dev can see why (optional)
                // MessageBox.Show($"Unable to load rental summary: {ex.Message}", "Load error");
            }
        }



        // Common UI events placeholders
        private void BtnProcess_Click(object sender, EventArgs e)
        {
            if (cbPaymentMethod.SelectedItem == null)
            {
                MessageBox.Show("Select payment method.");
                return;
            }

            if (!(cbPaymentMethod.SelectedItem is PaymentMethod method))
            {
                if (!Enum.TryParse<PaymentMethod>(
                        cbPaymentMethod.SelectedItem.ToString(),
                        true,
                        out method))
                {
                    MessageBox.Show("Invalid payment method.");
                    return;
                }
            }

            var amount = _currentBalance;

            try
            {
                _billingService.AddPayment(
                    invoiceId: _invoice.Id,
                    amount: amount,
                    method: method,
                    paymentType: PaymentType.Final,
                    date: DateTime.Now
                );

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Payment Failed");
            }
        }
        
    }
}