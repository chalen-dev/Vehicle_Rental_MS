using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using VRMS.DTOs.Reports;
using VRMS.Services.Reports;

namespace VRMS.UI.Controls.Reports
{
    public partial class ReportsView : UserControl
    {
        private readonly ReportsService _reportsService;

        public ReportsView(ReportsService reportsService)
        {
            _reportsService = reportsService;

            InitializeComponent();
            SetupDesign();

            tcReports.SelectedIndexChanged += TcReports_SelectedIndexChanged;
            btnApplyFilter.Click += BtnApplyFilter_Click;

            btnExportExcel.Click += (s, e) =>
                MessageBox.Show("Export to Excel not implemented yet.", "Export");

            btnExportPDF.Click += (s, e) =>
                MessageBox.Show("Export to PDF not implemented yet.", "Export");

            RefreshCurrentTab();
        }

        // =====================================================
        // UI SETUP
        // =====================================================

        private void SetupDesign()
        {
            dgvReportData.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 245, 245);

            dgvReportData.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(32, 191, 158); // Changed to teal color

            dgvReportData.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReportData.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvReportData.EnableHeadersVisualStyles = false;
            dgvReportData.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvReportData.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvReportData.ReadOnly = true;
            dgvReportData.BorderStyle = BorderStyle.None;
            dgvReportData.BackgroundColor = Color.White;

            // Enable double buffering
            PropertyInfo pi =
                typeof(DataGridView).GetProperty(
                    "DoubleBuffered",
                    BindingFlags.Instance | BindingFlags.NonPublic);

            pi?.SetValue(dgvReportData, true, null);
        }

        // =====================================================
        // EVENTS
        // =====================================================

        private void BtnApplyFilter_Click(object sender, EventArgs e)
        {
            RefreshCurrentTab();
        }

        private void TcReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!tcReports.SelectedTab.Controls.Contains(dgvReportData))
                tcReports.SelectedTab.Controls.Add(dgvReportData);

            dgvReportData.Dock = DockStyle.Fill;
            RefreshCurrentTab();
        }

        // =====================================================
        // TAB DISPATCHER
        // =====================================================

        private void RefreshCurrentTab()
        {
            try
            {
                switch (tcReports.SelectedIndex)
                {
                    case 0:
                        LoadFleetUtilization();
                        break;

                    case 1:
                        LoadRevenueReport();
                        break;

                    case 2:
                        LoadKpiReport();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Report Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // FLEET UTILIZATION
        // =====================================================

        private void LoadFleetUtilization()
        {
            var from = dtpStart.Value.Date;
            var to = dtpEnd.Value.Date;

            var data = _reportsService.GetFleetUtilization(from, to);
            dgvReportData.DataSource = data;

            dgvReportData.Columns[nameof(FleetUtilizationRowDto.VehicleId)].Visible = false;

            dgvReportData.Columns[nameof(FleetUtilizationRowDto.VehicleCode)].HeaderText =
                "Vehicle Code";

            dgvReportData.Columns[nameof(FleetUtilizationRowDto.MakeModel)].HeaderText =
                "Make / Model";

            dgvReportData.Columns[nameof(FleetUtilizationRowDto.DaysRented)].HeaderText =
                "Days Rented";

            dgvReportData.Columns[nameof(FleetUtilizationRowDto.TotalDays)].HeaderText =
                "Total Days";

            dgvReportData.Columns[nameof(FleetUtilizationRowDto.UtilizationPercent)].HeaderText =
                "Utilization (%)";

            dgvReportData.Columns[nameof(FleetUtilizationRowDto.UtilizationPercent)]
                .DefaultCellStyle.Format = "N2";

            dgvReportData.Columns[nameof(FleetUtilizationRowDto.DaysRented)]
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvReportData.Columns[nameof(FleetUtilizationRowDto.TotalDays)]
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvReportData.Columns[nameof(FleetUtilizationRowDto.UtilizationPercent)]
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        // =====================================================
        // REVENUE REPORT
        // =====================================================

        private void LoadRevenueReport()
        {
            var from = dtpStart.Value.Date;
            var to = dtpEnd.Value.Date;

            var data = _reportsService.GetRevenueReport(from, to);
            dgvReportData.DataSource = data;

            dgvReportData.Columns[nameof(RevenueReportRowDto.InvoiceId)].HeaderText =
                "Invoice #";

            dgvReportData.Columns[nameof(RevenueReportRowDto.RentalId)].HeaderText =
                "Rental #";

            dgvReportData.Columns[nameof(RevenueReportRowDto.VehicleCode)].HeaderText =
                "Vehicle";

            dgvReportData.Columns[nameof(RevenueReportRowDto.InvoiceDate)].HeaderText =
                "Invoice Date";

            dgvReportData.Columns[nameof(RevenueReportRowDto.Amount)].HeaderText =
                "Amount (₱)";

            dgvReportData.Columns[nameof(RevenueReportRowDto.IsPaid)].HeaderText =
                "Paid";

            dgvReportData.Columns[nameof(RevenueReportRowDto.InvoiceDate)]
                .DefaultCellStyle.Format = "yyyy-MM-dd";

            dgvReportData.Columns[nameof(RevenueReportRowDto.Amount)]
                .DefaultCellStyle.Format = "N2";

            dgvReportData.Columns[nameof(RevenueReportRowDto.Amount)]
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvReportData.Columns[nameof(RevenueReportRowDto.IsPaid)]
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        // =====================================================
        // KPI REPORT
        // =====================================================

        private void LoadKpiReport()
        {
            var from = dtpStart.Value.Date;
            var to = dtpEnd.Value.Date;

            var kpi = _reportsService.GetKpis(from, to);

            dgvReportData.DataSource = new[]
            {
        new { Metric = "Total Vehicles", Value = kpi.TotalVehicles.ToString() },
        new { Metric = "Total Rentals", Value = kpi.TotalRentals.ToString() },
        new { Metric = "Total Rental Days", Value = kpi.TotalRentalDays.ToString() },
        new { Metric = "Total Revenue (₱)", Value = kpi.TotalRevenue.ToString("N2") },
        new { Metric = "Avg Rental Duration (Days)", Value = kpi.AverageRentalDurationDays.ToString("N2") },
        new { Metric = "Fleet Utilization (%)", Value = kpi.FleetUtilizationPercent.ToString("N2") },
        new { Metric = "Damage Incidents", Value = kpi.DamageIncidentCount.ToString() }
    };

            dgvReportData.Columns["Metric"].Width = 350;
            dgvReportData.Columns["Metric"].DefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvReportData.Columns["Value"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
        }

    }
}
