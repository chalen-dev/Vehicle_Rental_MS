using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using VRMS.Models.Dashboard;
using VRMS.Repositories.Dashboard;
using VRMS.Services.Dashboard;
using VRMS.UI.ApplicationService;

namespace VRMS.Controls
{
    public partial class DashboardView : UserControl
    {
        private readonly DashboardService _dashboardService;
        public DashboardView()
        {
            InitializeComponent();

            _dashboardService = ApplicationServices.DashboardService;

            dateRangePicker.Value =
                new DateTime(
                    DateTime.Today.Year,
                    DateTime.Today.Month,
                    1
                );

            dateRangePicker.ValueChanged += (s, e) => LoadDashboard();
            this.Load += (s, e) => LoadDashboard();
            btnRefresh.Click += (s, e) => LoadDashboard();
        }

        private void LoadDashboard()
        {
            int year = dateRangePicker.Value.Year;
            int month = dateRangePicker.Value.Month;

            DashboardSnapshot snapshot;

            try
            {
                snapshot =
                    _dashboardService.GetSnapshot(
                        dateRangePicker.Value.Year,
                        dateRangePicker.Value.Month
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Dashboard Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // -----------------------------
            // FLEET CARDS
            // -----------------------------

            lblTotalValue.Text =
                snapshot.Fleet.TotalVehicles.ToString();

            lblAvailableValue.Text =
                snapshot.Fleet.AvailableVehicles.ToString();

            lblMaintenanceValue.Text =
                snapshot.Fleet.UnderMaintenanceVehicles.ToString();

            // -----------------------------
            // RENTAL CARDS
            // -----------------------------

            lblRentedValue.Text =
                snapshot.Rentals.ActiveRentals.ToString();

            lblOverdueValue.Text =
                snapshot.Rentals.OverdueRentals.ToString();

            // -----------------------------
            // REVENUE CARD
            // -----------------------------

            lblRevenueValue.Text =
                $"₱{snapshot.Revenue.MonthlyRevenue:N0}";

            // -----------------------------
            // CHART
            // -----------------------------

            SetupPerformanceChart(snapshot.MonthlyTrends);

            // -----------------------------
            // GRIDS (STILL MOCKED FOR NOW)
            // -----------------------------

            PopulateGrids();
        }


        private void PopulateGrids()
        {
            // =============================
            // TODAY'S SCHEDULE (REAL DATA)
            // =============================

            dgvTodaySchedule.DataSource =
                _dashboardService.GetTodaySchedule();

            // =============================
            // ALERTS (REAL DATA)
            // =============================

            dgvAlerts.DataSource =
                _dashboardService.GetAlerts();

            // Priority coloring
            dgvAlerts.DataBindingComplete += (s, e) =>
            {
                foreach (DataGridViewRow row in dgvAlerts.Rows)
                {
                    string priority =
                        row.Cells["priority"].Value?.ToString();

                    if (priority == "CRITICAL")
                        row.DefaultCellStyle.ForeColor = Color.Red;

                    if (priority == "HIGH")
                        row.DefaultCellStyle.ForeColor = Color.OrangeRed;
                }
            };
        }


        private void SetupPerformanceChart(
            IReadOnlyList<DashboardMonthlyTrend> trends)
        {
            pnlChartArea.Controls.Clear();
            pnlChartArea.Controls.Add(lblChartTitle);

            Chart chart = new Chart { Dock = DockStyle.Fill };

            // 1. Force the Chart Area to expand
            ChartArea area = new ChartArea("Main");
            area.AxisX.MajorGrid.LineColor = Color.FromArgb(240, 240, 240);
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(240, 240, 240);

            // Ensure all labels show up
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Enabled = true;

            chart.ChartAreas.Add(area);

            // 2. Configure the Series with explicit Bar Width
            Series s = new Series("Rentals Completed")
            {
                ChartType = SeriesChartType.Column, // Using Column for clearer bars
                XValueType = ChartValueType.String,
                Color = Color.FromArgb(52, 152, 219),
            };

            // Explicitly set the bar width (0.8 is a good standard size)
            s["PointWidth"] = "0.8";

            string[] months = { "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec", "Jan" };
            int[] data = { 38, 42, 55, 68, 50, 62, 45, 80, 110, 75 };

            // 3. Clear existing points before adding new ones
            s.Points.Clear();

            foreach (var item in trends)
            {
                var label =
                    new DateTime(item.Year, item.Month, 1)
                        .ToString("MMM");

                int index =
                    s.Points.AddXY(label, item.CompletedRentals);

                s.Points[index].AxisLabel = label;
            }


            chart.Series.Add(s);

            // 4. Position the Legend at the bottom
            Legend leg = new Legend("Legend") { Docking = Docking.Bottom };
            chart.Legends.Add(leg);

            pnlChartArea.Controls.Add(chart);
            chart.BringToFront();
            lblChartTitle.BringToFront();
        }
    }
}