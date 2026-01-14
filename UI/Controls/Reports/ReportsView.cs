using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace VRMS.UI.Controls.Reports
{
    public partial class ReportsView : UserControl
    {
        private Random _random = new Random();

        public ReportsView()
        {
            InitializeComponent();
            SetupDesign();

            // Wire up Events
            tcReports.SelectedIndexChanged += TcReports_SelectedIndexChanged;
            btnApplyFilter.Click += BtnApplyFilter_Click;
            btnExportExcel.Click += (s, e) => MessageBox.Show("Exporting to Excel...", "System Export");
            btnExportPDF.Click += (s, e) => MessageBox.Show("Exporting to PDF...", "System Export");

            // Initial Data Load
            LoadFleetData();
        }

        private void SetupDesign()
        {
            // Grid Styling
            dgvReportData.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvReportData.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvReportData.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReportData.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvReportData.EnableHeadersVisualStyles = false;
            dgvReportData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReportData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReportData.BackgroundColor = Color.White;
            dgvReportData.BorderStyle = BorderStyle.None;
            dgvReportData.ReadOnly = true;

            // Enable Double Buffering to prevent flickering with "a lot of data"
            PropertyInfo pi = typeof(DataGridView).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgvReportData, true, null);
        }

        private void TcReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Move grid to the current active tab
            tcReports.SelectedTab.Controls.Add(dgvReportData);
            RefreshCurrentTab();
        }

        private void BtnApplyFilter_Click(object sender, EventArgs e)
        {
            RefreshCurrentTab();
        }

        private void RefreshCurrentTab()
        {
            switch (tcReports.SelectedIndex)
            {
                case 0: LoadFleetData(); break;
                case 1: LoadRevenueData(); break;
                case 2: LoadKPIData(); break;
            }
        }

        #region Business Logic & Data Generation

        private void LoadFleetData()
        {
            var data = new List<FleetReportItem>();
            string[] makes = { "Toyota", "Mitsubishi", "Ford", "Honda", "Isuzu" };
            string[] models = { "Hiace (Van)", "Montero (SUV)", "Ranger (Pickup)", "Civic (Sedan)", "Vios (Sedan)" };
            string[] status = { "Available", "Rented", "Reserved", "Under Maintenance", "Out of Service" };

            for (int i = 1; i <= 100; i++)
            {
                int totalAvailableDays = 30;
                int rentalDays = _random.Next(5, 29);
                // Formula: (Total Rental Days / Total Available Days) × 100%
                double utilization = (double)rentalDays / totalAvailableDays * 100;

                data.Add(new FleetReportItem
                {
                    VehicleID = $"V-{1000 + i}",
                    Model = models[_random.Next(models.Length)],
                    Category = "Standard",
                    Status = status[_random.Next(status.Length)],
                    TotalRentalDays = rentalDays,
                    UtilizationRate = utilization.ToString("F1") + "%",
                    LastMaintenance = DateTime.Now.AddDays(-_random.Next(5, 60)).ToShortDateString()
                });
            }
            dgvReportData.DataSource = data;
        }

        private void LoadRevenueData()
        {
            var data = new List<RevenueReportItem>();
            string[] types = { "Hatchback", "Sedan", "SUV", "Pickup", "Van" };

            for (int i = 0; i < 50; i++)
            {
                decimal baseRate = _random.Next(1500, 5000);
                int days = _random.Next(1, 14);
                decimal rentalRev = baseRate * days;
                decimal damageFees = (_random.Next(0, 10) > 8) ? _random.Next(500, 5000) : 0;
                decimal total = rentalRev + damageFees;

                data.Add(new RevenueReportItem
                {
                    TxnID = $"TRX-{5000 + i}",
                    Category = types[_random.Next(types.Length)],
                    RentalRevenue = rentalRev,
                    DamageFees = damageFees,
                    TotalCollected = total,
                    Date = DateTime.Now.AddDays(-_random.Next(0, 30)).ToShortDateString()
                });
            }
            dgvReportData.DataSource = data;

            // Format Currency
            dgvReportData.Columns["RentalRevenue"].DefaultCellStyle.Format = "N2";
            dgvReportData.Columns["DamageFees"].DefaultCellStyle.Format = "N2";
            dgvReportData.Columns["TotalCollected"].DefaultCellStyle.Format = "N2";
        }

        private void LoadKPIData()
        {
            var data = new List<KPIReportItem>
            {
                new KPIReportItem { Metric = "Fleet Utilization Rate", Value = "74.2%", Target = "85.0%", Status = "Action Required" },
                new KPIReportItem { Metric = "Revenue Per Vehicle (RPV)", Value = "₱1,420.50", Target = "₱1,200.00", Status = "Optimal" },
                new KPIReportItem { Metric = "Average Rental Duration", Value = "4.5 Days", Target = "3.0 Days", Status = "Good" },
                new KPIReportItem { Metric = "Damage Incident Rate", Value = "8.2%", Target = "5.0%", Status = "High" },
                new KPIReportItem { Metric = "Customer Retention Rate", Value = "61.0%", Target = "60.0%", Status = "Optimal" }
            };
            dgvReportData.DataSource = data;
        }

        #endregion
    }

    #region Requirement-Specific Classes (OOP)

    public class FleetReportItem
    {
        public string VehicleID { get; set; }
        public string Model { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public int TotalRentalDays { get; set; }
        public string UtilizationRate { get; set; }
        public string LastMaintenance { get; set; }
    }

    public class RevenueReportItem
    {
        public string TxnID { get; set; }
        public string Date { get; set; }
        public string Category { get; set; }
        public decimal RentalRevenue { get; set; }
        public decimal DamageFees { get; set; }
        public decimal TotalCollected { get; set; }
    }

    public class KPIReportItem
    {
        public string Metric { get; set; }
        public string Value { get; set; }
        public string Target { get; set; }
        public string Status { get; set; }
    }

    #endregion
}