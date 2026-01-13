using System;
using System.Drawing;
using System.Windows.Forms;

namespace VRMS.Controls
{
    public partial class CustomersRentalsView : UserControl
    {
        public CustomersRentalsView()
        {
            InitializeComponent();
            InitializeGrid();
            InitializeStatusFilter();
            ResetDetailsPanel();
            WireUiOnlyEvents();
        }

        // =========================
        // GRID SETUP (EMPTY)
        // =========================
        private void InitializeGrid()
        {
            dgvRentals.Rows.Clear();
            dgvRentals.Columns.Clear();
            dgvRentals.AutoGenerateColumns = false;

            dgvRentals.Columns.Add("Vehicle", "Vehicle");
            dgvRentals.Columns.Add("Plate", "Plate No.");
            dgvRentals.Columns.Add("Category", "Category");
            dgvRentals.Columns.Add("Transmission", "Transmission");
            dgvRentals.Columns.Add("Fuel", "Fuel");
            dgvRentals.Columns.Add("Pickup", "Pickup Location");
            dgvRentals.Columns.Add("Period", "Rental Period");
            dgvRentals.Columns.Add("Amount", "Amount");
            dgvRentals.Columns.Add("Status", "Status");
            dgvRentals.Columns.Add("Payment", "Payment");

            dgvRentals.Columns["Amount"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgvRentals.Columns["Amount"].DefaultCellStyle.Format =
                "₱ #,##0.00";
        }

        // =========================
        // STATUS FILTER (EMPTY)
        // =========================
        private void InitializeStatusFilter()
        {
            cbStatusFilter.Items.Clear();
            cbStatusFilter.Items.Add("All");
            cbStatusFilter.Items.Add("Active");
            cbStatusFilter.Items.Add("Returned");
            cbStatusFilter.Items.Add("Pending");
            cbStatusFilter.Items.Add("Cancelled");

            cbStatusFilter.SelectedIndex = 0;
        }

        // =========================
        // DETAILS PANEL DEFAULT
        // =========================
        private void ResetDetailsPanel()
        {
            pbVehicle.Image = null;

            lblDetailVehicle.Text = "Select a rental";
            lblDetailDates.Text = "Period: —";
            lblDetailAmount.Text = "Total: ₱ 0.00";

            btnProceedRent.Enabled = false;
            btnViewDetails.Enabled = false;
        }

        // =========================
        // UI-ONLY EVENTS (STUBS)
        // =========================
        private void WireUiOnlyEvents()
        {
            btnRefresh.Click += (_, __) => ResetDetailsPanel();
            btnViewDetails.Click += (_, __) => ShowComingSoon();
            btnProceedRent.Click += (_, __) => ShowComingSoon();

            txtSearch.TextChanged += (_, __) => { };
            cbStatusFilter.SelectedIndexChanged += (_, __) => { };

            dgvRentals.SelectionChanged += (_, __) =>
            {
                // Placeholder behavior until real data is wired
                btnViewDetails.Enabled = dgvRentals.SelectedRows.Count > 0;
                btnProceedRent.Enabled = dgvRentals.SelectedRows.Count > 0;
            };
        }

        private void ShowComingSoon()
        {
            MessageBox.Show(
                "This feature will be implemented soon.",
                "Coming Soon",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
