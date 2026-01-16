using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using System.Text;
using VRMS.DTOs.Reports;
using VRMS.Services.Reports;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;

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
                Color.FromArgb(32, 191, 158);

            dgvReportData.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReportData.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvReportData.EnableHeadersVisualStyles = false;
            dgvReportData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReportData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReportData.ReadOnly = true;
            dgvReportData.BorderStyle = BorderStyle.None;
            dgvReportData.BackgroundColor = Color.White;

            PropertyInfo pi = typeof(DataGridView)
                .GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
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
                MessageBox.Show(ex.Message, "Report Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // FLEET UTILIZATION
        // =====================================================

        private void LoadFleetUtilization()
        {
            var data = _reportsService.GetFleetUtilization(
                dtpStart.Value.Date,
                dtpEnd.Value.Date);

            dgvReportData.DataSource = data;

            dgvReportData.Columns[nameof(FleetUtilizationRowDto.VehicleId)].Visible = false;
            dgvReportData.Columns[nameof(FleetUtilizationRowDto.VehicleCode)].HeaderText = "Vehicle Code";
            dgvReportData.Columns[nameof(FleetUtilizationRowDto.MakeModel)].HeaderText = "Make / Model";
            dgvReportData.Columns[nameof(FleetUtilizationRowDto.DaysRented)].HeaderText = "Days Rented";
            dgvReportData.Columns[nameof(FleetUtilizationRowDto.TotalDays)].HeaderText = "Total Days";
            dgvReportData.Columns[nameof(FleetUtilizationRowDto.UtilizationPercent)].HeaderText = "Utilization (%)";

            dgvReportData.Columns[nameof(FleetUtilizationRowDto.UtilizationPercent)]
                .DefaultCellStyle.Format = "N2";
        }

        // =====================================================
        // REVENUE REPORT
        // =====================================================

        private void LoadRevenueReport()
        {
            var data = _reportsService.GetRevenueReport(
                dtpStart.Value.Date,
                dtpEnd.Value.Date);

            dgvReportData.DataSource = data;

            dgvReportData.Columns[nameof(RevenueReportRowDto.InvoiceId)].HeaderText = "Invoice #";
            dgvReportData.Columns[nameof(RevenueReportRowDto.RentalId)].HeaderText = "Rental #";
            dgvReportData.Columns[nameof(RevenueReportRowDto.VehicleCode)].HeaderText = "Vehicle";
            dgvReportData.Columns[nameof(RevenueReportRowDto.InvoiceDate)].HeaderText = "Invoice Date";
            dgvReportData.Columns[nameof(RevenueReportRowDto.Amount)].HeaderText = "Amount (₱)";
            dgvReportData.Columns[nameof(RevenueReportRowDto.IsPaid)].HeaderText = "Paid";
        }

        // =====================================================
        // KPI REPORT (FIXED TYPE ISSUE)
        // =====================================================

        private void LoadKpiReport()
        {
            var kpi = _reportsService.GetKpis(
                dtpStart.Value.Date,
                dtpEnd.Value.Date);

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

        // =====================================================
        // EXPORT EXCEL (CSV)
        // =====================================================

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvReportData.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.");
                return;
            }

            using SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv",
                FileName = $"Report_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            };

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            StringBuilder sb = new StringBuilder();

            foreach (DataGridViewColumn col in dgvReportData.Columns)
                sb.Append(col.HeaderText + ",");

            sb.Length--;
            sb.AppendLine();

            foreach (DataGridViewRow row in dgvReportData.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                    sb.Append((cell.Value?.ToString() ?? "").Replace(",", " ") + ",");

                sb.Length--;
                sb.AppendLine();
            }

            File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
            MessageBox.Show("Excel export completed.");
        }

        // =====================================================
        // EXPORT PDF (PdfSharpCore — FIXED)
        // =====================================================

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            if (dgvReportData.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.");
                return;
            }

            using SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf",
                FileName = $"Report_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
            };

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            PdfDocument doc = new PdfDocument();
            PdfPage page = doc.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont titleFont = new XFont("Arial", 14, XFontStyle.Bold);
            XFont cellFont = new XFont("Arial", 9);

            double margin = 40;
            double y = margin;

            gfx.DrawString(
                "Report Export",
                titleFont,
                XBrushes.Black,
                new XRect(0, y, page.Width, 30),
                XStringFormats.TopCenter);

            y += 40;

            int columnCount = dgvReportData.Columns.Count;
            double tableWidth = page.Width - (margin * 2);
            double colWidth = tableWidth / columnCount;
            double rowHeight = 20;

            // HEADERS
            foreach (DataGridViewColumn col in dgvReportData.Columns)
            {
                double x = margin + col.Index * colWidth;

                gfx.DrawRectangle(XPens.Black, x, y, colWidth, rowHeight);

                gfx.DrawString(
                    col.HeaderText,
                    cellFont,
                    XBrushes.Black,
                    new XRect(x + 3, y + 3, colWidth - 6, rowHeight - 6),
                    XStringFormats.TopLeft);
            }

            y += rowHeight;

            // ROWS
            foreach (DataGridViewRow row in dgvReportData.Rows)
            {
                if (y + rowHeight > page.Height - margin)
                {
                    page = doc.AddPage();
                    gfx = XGraphics.FromPdfPage(page);
                    y = margin;
                }

                for (int i = 0; i < columnCount; i++)
                {
                    double x = margin + i * colWidth;

                    gfx.DrawRectangle(XPens.Black, x, y, colWidth, rowHeight);

                    gfx.DrawString(
                        row.Cells[i].Value?.ToString() ?? "",
                        cellFont,
                        XBrushes.Black,
                        new XRect(x + 3, y + 3, colWidth - 6, rowHeight - 6),
                        XStringFormats.TopLeft);
                }

                y += rowHeight;
            }

            doc.Save(sfd.FileName);
            MessageBox.Show("PDF export completed.");
        }
    }
}
