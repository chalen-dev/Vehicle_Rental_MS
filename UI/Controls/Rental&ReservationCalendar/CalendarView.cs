using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace VRMS.UI.Controls.Rental_ReservationCalendar
{
    public partial class CalendarView : UserControl
    {
        // ===============================
        // LAYOUT CONSTANTS
        // ===============================
        private const int DayColumnWidth = 40;
        private const int RowHeight = 40;  // Match this with DGV row height
        private const int HeaderHeight = 40;
        private const int HourRowHeight = 60;
        private const int TimeColumnWidth = 60;
        private const int DayStartHour = 8;   // 8 AM
        private const int DayEndHour = 20;    // 8 PM

        // ===============================
        // ENUMS
        // ===============================
        public enum CalendarViewMode
        {
            Month,
            Week
        }

        public enum VehicleStatus
        {
            Available,
            Rented,
            UnderMaintenance
        }

        // ===============================
        // STATE
        // ===============================
        private DateTime _currentDate;
        private CalendarViewMode _currentViewMode = CalendarViewMode.Month;
        private bool _isFirstPaint = true;

        // ===============================
        // DUMMY VEHICLE MODEL
        // ===============================
        private class DummyVehicle
        {
            public int RowId { get; set; }
            public string LicensePlate { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            public string Category { get; set; }
            public VehicleStatus Status { get; set; }
        }

        // ===============================
        // DUMMY RENTAL MODEL
        // ===============================
        private class DummyRental
        {
            public int VehicleRow { get; set; }   // row index
            public int StartDay { get; set; }     // day of month
            public int Duration { get; set; }     // days long
            public string Customer { get; set; }
            public Color Color { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public string RentalType { get; set; } = "Rental";
        }

        // ===============================
        // DUMMY MAINTENANCE MODEL
        // ===============================
        private class DummyMaintenance
        {
            public int VehicleRow { get; set; }
            public int StartDay { get; set; }
            public int Duration { get; set; }
            public string Description { get; set; }
            public Color Color { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public string MaintenanceType { get; set; } = "Maintenance";
        }

        // ===============================
        // DUMMY DATA
        // ===============================
        private readonly List<DummyVehicle> _dummyVehicles = new()
        {
            new DummyVehicle { RowId = 0, LicensePlate = "ABC-123", Model = "Toyota Corolla", Year = 2022, Category = "Small", Status = VehicleStatus.Available },
            new DummyVehicle { RowId = 1, LicensePlate = "DEF-456", Model = "Honda CR-V", Year = 2021, Category = "Medium", Status = VehicleStatus.Rented },
            new DummyVehicle { RowId = 2, LicensePlate = "GHI-789", Model = "Ford Escape", Year = 2023, Category = "Medium", Status = VehicleStatus.UnderMaintenance },
            new DummyVehicle { RowId = 3, LicensePlate = "JKL-012", Model = "Chevrolet Tahoe", Year = 2020, Category = "Large", Status = VehicleStatus.Available },
            new DummyVehicle { RowId = 4, LicensePlate = "MNO-345", Model = "Toyota Camry", Year = 2022, Category = "Small", Status = VehicleStatus.Rented },
            new DummyVehicle { RowId = 5, LicensePlate = "PQR-678", Model = "Jeep Wrangler", Year = 2023, Category = "Large", Status = VehicleStatus.Available },
            new DummyVehicle { RowId = 6, LicensePlate = "STU-901", Model = "Hyundai Elantra", Year = 2021, Category = "Small", Status = VehicleStatus.UnderMaintenance },
            new DummyVehicle { RowId = 7, LicensePlate = "VWX-234", Model = "Nissan Rogue", Year = 2022, Category = "Medium", Status = VehicleStatus.Available }
        };

        private readonly List<DummyRental> _dummyRentals = new()
        {
            // Monthly view rentals
            new DummyRental { VehicleRow = 0, StartDay = 2,  Duration = 3, Customer = "Juan D.", Color = Color.SkyBlue },
            new DummyRental { VehicleRow = 1, StartDay = 5,  Duration = 4, Customer = "Maria S.", Color = Color.LightGreen },
            new DummyRental { VehicleRow = 2, StartDay = 1,  Duration = 2, Customer = "Alex R.", Color = Color.Khaki },
            new DummyRental { VehicleRow = 3, StartDay = 10, Duration = 5, Customer = "Chris T.", Color = Color.Plum },
            new DummyRental { VehicleRow = 4, StartDay = 8,  Duration = 3, Customer = "Liam K.", Color = Color.LightSalmon },
            new DummyRental { VehicleRow = 5, StartDay = 15, Duration = 2, Customer = "Emma W.", Color = Color.LightCoral },
            new DummyRental { VehicleRow = 6, StartDay = 20, Duration = 4, Customer = "Noah B.", Color = Color.LightSeaGreen },
            new DummyRental { VehicleRow = 7, StartDay = 18, Duration = 3, Customer = "Olivia M.", Color = Color.LightSkyBlue },
            
            // Weekly view rentals (with time information)
            new DummyRental {
                VehicleRow = 0,
                StartTime = DateTime.Today.AddDays(1).AddHours(9),
                EndTime = DateTime.Today.AddDays(1).AddHours(11),
                Customer = "Morning Rental",
                Color = Color.SkyBlue
            },
            new DummyRental {
                VehicleRow = 1,
                StartTime = DateTime.Today.AddDays(2).AddHours(14),
                EndTime = DateTime.Today.AddDays(2).AddHours(16),
                Customer = "Afternoon Slot",
                Color = Color.LightGreen
            },
            new DummyRental {
                VehicleRow = 2,
                StartTime = DateTime.Today.AddDays(0).AddHours(10),
                EndTime = DateTime.Today.AddDays(0).AddHours(12),
                Customer = "Today's Booking",
                Color = Color.Khaki
            },
            new DummyRental {
                VehicleRow = 3,
                StartTime = DateTime.Today.AddDays(3).AddHours(8),
                EndTime = DateTime.Today.AddDays(3).AddHours(10),
                Customer = "Early Morning",
                Color = Color.Plum
            },
            new DummyRental {
                VehicleRow = 4,
                StartTime = DateTime.Today.AddDays(4).AddHours(13),
                EndTime = DateTime.Today.AddDays(4).AddHours(15),
                Customer = "Afternoon Tour",
                Color = Color.LightSalmon
            },
            new DummyRental {
                VehicleRow = 5,
                StartTime = DateTime.Today.AddDays(5).AddHours(16),
                EndTime = DateTime.Today.AddDays(5).AddHours(18),
                Customer = "Evening Drive",
                Color = Color.LightCoral
            }
        };

        private readonly List<DummyMaintenance> _dummyMaintenance = new()
        {
            // Monthly view maintenance
            new DummyMaintenance { VehicleRow = 2, StartDay = 5, Duration = 3, Description = "Oil Change & Brakes", Color = Color.Orange },
            new DummyMaintenance { VehicleRow = 6, StartDay = 12, Duration = 2, Description = "Tire Replacement", Color = Color.OrangeRed },
            new DummyMaintenance { VehicleRow = 1, StartDay = 20, Duration = 1, Description = "Engine Check", Color = Color.DarkOrange },
            new DummyMaintenance { VehicleRow = 4, StartDay = 25, Duration = 4, Description = "Major Service", Color = Color.Coral },
            
            // Weekly view maintenance
            new DummyMaintenance {
                VehicleRow = 2,
                StartTime = DateTime.Today.AddDays(1).AddHours(13),
                EndTime = DateTime.Today.AddDays(1).AddHours(17),
                Description = "Scheduled Maintenance",
                Color = Color.Orange
            },
            new DummyMaintenance {
                VehicleRow = 6,
                StartTime = DateTime.Today.AddDays(3).AddHours(10),
                EndTime = DateTime.Today.AddDays(3).AddHours(14),
                Description = "Repair Work",
                Color = Color.OrangeRed
            },
            new DummyMaintenance {
                VehicleRow = 1,
                StartTime = DateTime.Today.AddDays(4).AddHours(8),
                EndTime = DateTime.Today.AddDays(4).AddHours(12),
                Description = "Oil Change",
                Color = Color.DarkOrange
            }
        };

        public CalendarView()
        {
            InitializeComponent();

            _currentDate = new DateTime(
                DateTime.Today.Year,
                DateTime.Today.Month,
                DateTime.Today.Day
            );

            dtpMonthYear.Value = _currentDate;
            dtpWeekView.Value = _currentDate;

            SetupVehicleDataGrid();
            SetViewMode(CalendarViewMode.Month);
            EnableDoubleBuffering();

            // Configure DGV to match calendar rows
            ConfigureDataGridView();
        }

        // ===============================
        // DATA GRID VIEW CONFIGURATION
        // ===============================
        private void ConfigureDataGridView()
        {
            // Set row height to match calendar row height
            dgvVehicles.RowTemplate.Height = RowHeight;

            // Set font size to fit better
            dgvVehicles.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);

            // Set alignment
            dgvVehicles.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvVehicles.DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            // Configure columns for better display
            if (dgvVehicles.Columns.Count >= 3)
            {
                dgvVehicles.Columns[0].Width = 50;  // Year column
                dgvVehicles.Columns[1].Width = 80;  // License column
                dgvVehicles.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Model column
            }

            // Make sure DGV doesn't add extra rows
            dgvVehicles.AllowUserToAddRows = false;
            dgvVehicles.AllowUserToDeleteRows = false;
            dgvVehicles.AllowUserToResizeRows = false;

            // Set row height explicitly
            dgvVehicles.RowHeadersVisible = false;
        }

        // ===============================
        // VEHICLE DATA GRID SETUP
        // ===============================
        private void SetupVehicleDataGrid()
        {
            // Clear existing rows
            dgvVehicles.Rows.Clear();

            // Set consistent row height
            dgvVehicles.RowTemplate.Height = RowHeight;

            // Add vehicle data
            foreach (var vehicle in _dummyVehicles)
            {
                int rowIndex = dgvVehicles.Rows.Add(
                    vehicle.Year.ToString(),
                    vehicle.LicensePlate,
                    vehicle.Model
                );

                // Color code based on status
                DataGridViewRow row = dgvVehicles.Rows[rowIndex];

                // Set row height explicitly
                row.Height = RowHeight;

                switch (vehicle.Status)
                {
                    case VehicleStatus.Available:
                        row.DefaultCellStyle.BackColor = Color.FromArgb(240, 255, 240); // Light green
                        break;
                    case VehicleStatus.Rented:
                        row.DefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255); // Light blue
                        break;
                    case VehicleStatus.UnderMaintenance:
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 240, 240); // Light red
                        break;
                }

                // Set text color for better contrast
                row.DefaultCellStyle.ForeColor = Color.Black;

                // Add tooltip
                row.Cells[1].ToolTipText = $"Category: {vehicle.Category}\nStatus: {vehicle.Status}";
            }
        }

        // ===============================
        // VIEW MODE MANAGEMENT
        // ===============================
        private void SetViewMode(CalendarViewMode mode)
        {
            _currentViewMode = mode;

            // Update button states
            if (mode == CalendarViewMode.Month)
            {
                btnMonthView.BackColor = Color.SteelBlue;
                btnMonthView.ForeColor = Color.White;
                btnWeekView.BackColor = SystemColors.Control;
                btnWeekView.ForeColor = SystemColors.ControlText;

                dtpMonthYear.Visible = true;
                dtpWeekView.Visible = false;

                // Set to first day of month
                _currentDate = new DateTime(_currentDate.Year, _currentDate.Month, 1);
                dtpMonthYear.Value = _currentDate;
            }
            else // Week view
            {
                btnWeekView.BackColor = Color.SteelBlue;
                btnWeekView.ForeColor = Color.White;
                btnMonthView.BackColor = SystemColors.Control;
                btnMonthView.ForeColor = SystemColors.ControlText;

                dtpMonthYear.Visible = false;
                dtpWeekView.Visible = true;

                // Set to Monday of current week
                _currentDate = GetStartOfWeek(_currentDate);
                dtpWeekView.Value = _currentDate;
            }

            pnlCalendarCanvas.Invalidate();
        }

        private DateTime GetStartOfWeek(DateTime date)
        {
            int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
            return date.AddDays(-1 * diff).Date;
        }

        private DateTime GetEndOfWeek(DateTime date)
        {
            return GetStartOfWeek(date).AddDays(6);
        }

        // ===============================
        // EVENT HANDLERS
        // ===============================
        private void btnMonthView_Click(object sender, EventArgs e)
        {
            SetViewMode(CalendarViewMode.Month);
        }

        private void btnWeekView_Click(object sender, EventArgs e)
        {
            SetViewMode(CalendarViewMode.Week);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_currentViewMode == CalendarViewMode.Month)
            {
                _currentDate = _currentDate.AddMonths(-1);
                dtpMonthYear.Value = _currentDate;
            }
            else // Week view
            {
                _currentDate = _currentDate.AddDays(-7);
                dtpWeekView.Value = _currentDate;
            }
            pnlCalendarCanvas.Invalidate();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentViewMode == CalendarViewMode.Month)
            {
                _currentDate = _currentDate.AddMonths(1);
                dtpMonthYear.Value = _currentDate;
            }
            else // Week view
            {
                _currentDate = _currentDate.AddDays(7);
                dtpWeekView.Value = _currentDate;
            }
            pnlCalendarCanvas.Invalidate();
        }

        private void dtpMonthYear_ValueChanged(object sender, EventArgs e)
        {
            _currentDate = dtpMonthYear.Value;
            pnlCalendarCanvas.Invalidate();
        }

        private void dtpWeekView_ValueChanged(object sender, EventArgs e)
        {
            _currentDate = GetStartOfWeek(dtpWeekView.Value);
            pnlCalendarCanvas.Invalidate();
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Filter vehicles based on category
            string filter = cmbFilter.SelectedItem?.ToString();
            if (filter == "All Categories")
            {
                SetupVehicleDataGrid();
            }
            else
            {
                dgvVehicles.Rows.Clear();
                dgvVehicles.RowTemplate.Height = RowHeight;

                foreach (var vehicle in _dummyVehicles)
                {
                    if (vehicle.Category == filter.Replace(" Category", ""))
                    {
                        int rowIndex = dgvVehicles.Rows.Add(
                            vehicle.Year.ToString(),
                            vehicle.LicensePlate,
                            vehicle.Model
                        );

                        DataGridViewRow row = dgvVehicles.Rows[rowIndex];
                        row.Height = RowHeight;

                        switch (vehicle.Status)
                        {
                            case VehicleStatus.Available:
                                row.DefaultCellStyle.BackColor = Color.FromArgb(240, 255, 240);
                                break;
                            case VehicleStatus.Rented:
                                row.DefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
                                break;
                            case VehicleStatus.UnderMaintenance:
                                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 240, 240);
                                break;
                        }

                        row.DefaultCellStyle.ForeColor = Color.Black;
                        row.Cells[1].ToolTipText = $"Category: {vehicle.Category}\nStatus: {vehicle.Status}";
                    }
                }
            }
            pnlCalendarCanvas.Invalidate();
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Sort functionality - can be enhanced based on your needs
            pnlCalendarCanvas.Invalidate();
        }

        // ===============================
        // DOUBLE BUFFERING
        // ===============================
        private void EnableDoubleBuffering()
        {
            typeof(Panel)
                .GetProperty(
                    "DoubleBuffered",
                    BindingFlags.Instance | BindingFlags.NonPublic
                )
                ?.SetValue(pnlCalendarCanvas, true);
        }

        // ===============================
        // PAINT EVENTS
        // ===============================
        private void pnlCalendarCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            // Update DGV row heights to match calendar
            SyncDGVRowHeights();

            switch (_currentViewMode)
            {
                case CalendarViewMode.Month:
                    DrawMonthView(g);
                    break;
                case CalendarViewMode.Week:
                    DrawWeekView(g);
                    break;
            }

            _isFirstPaint = false;
        }

        private void SyncDGVRowHeights()
        {
            // Ensure all DGV rows have the same height as calendar rows
            foreach (DataGridViewRow row in dgvVehicles.Rows)
            {
                row.Height = RowHeight;
            }
        }

        private void pnlCalendarCanvas_Resize(object sender, EventArgs e)
        {
            pnlCalendarCanvas.Invalidate();
        }

        // ===============================
        // MONTH VIEW DRAWING
        // ===============================
        private void DrawMonthView(Graphics g)
        {
            int daysInMonth = DateTime.DaysInMonth(
                _currentDate.Year,
                _currentDate.Month
            );

            DrawDayHeaders(g, daysInMonth);
            DrawGrid(g, daysInMonth);
            DrawMonthRentals(g);
            DrawMonthMaintenance(g);
            DrawVehicleRows(g, daysInMonth);
        }

        private void DrawDayHeaders(Graphics g, int daysInMonth)
        {
            using Brush headerBrush = new SolidBrush(Color.FromArgb(240, 240, 240));
            using Pen borderPen = new Pen(Color.LightGray);

            for (int day = 1; day <= daysInMonth; day++)
            {
                int x = (day - 1) * DayColumnWidth;

                Rectangle rect = new Rectangle(
                    x,
                    0,
                    DayColumnWidth,
                    HeaderHeight
                );

                g.FillRectangle(headerBrush, rect);
                g.DrawRectangle(borderPen, rect);

                DateTime date = new DateTime(
                    _currentDate.Year,
                    _currentDate.Month,
                    day
                );

                // Highlight weekends
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    using Brush weekendBrush = new SolidBrush(Color.FromArgb(255, 240, 240));
                    g.FillRectangle(weekendBrush, rect);
                }

                // Highlight today
                if (date.Date == DateTime.Today)
                {
                    using Pen todayPen = new Pen(Color.Red, 2);
                    g.DrawRectangle(todayPen, rect);
                }

                TextRenderer.DrawText(
                    g,
                    $"{date:ddd}\n{day}",
                    Font,
                    rect,
                    Color.Black,
                    TextFormatFlags.HorizontalCenter |
                    TextFormatFlags.VerticalCenter |
                    TextFormatFlags.WordBreak
                );
            }
        }

        private void DrawGrid(Graphics g, int daysInMonth)
        {
            int totalHeight = pnlCalendarCanvas.Height;
            int totalWidth = daysInMonth * DayColumnWidth;
            int rowCount = dgvVehicles.Rows.Count;

            using Pen pen = new Pen(Color.LightGray);

            // Vertical day lines
            for (int i = 0; i <= daysInMonth; i++)
            {
                int x = i * DayColumnWidth;
                int bottomY = HeaderHeight + (rowCount * RowHeight);
                g.DrawLine(pen, x, HeaderHeight, x, bottomY);
            }

            // Horizontal rows
            for (int i = 0; i <= rowCount; i++)
            {
                int y = HeaderHeight + (i * RowHeight);
                g.DrawLine(pen, 0, y, totalWidth, y);
            }
        }

        private void DrawVehicleRows(Graphics g, int daysInMonth)
        {
            using Font rowFont = new Font(Font.FontFamily, 8);
            using Brush textBrush = new SolidBrush(Color.Black);

            for (int i = 0; i < dgvVehicles.Rows.Count; i++)
            {
                int y = HeaderHeight + (i * RowHeight);

                // Draw vehicle name in first cell area
                string vehicleInfo = _dummyVehicles[i].Model;
                RectangleF textRect = new RectangleF(2, y + 2, DayColumnWidth - 4, RowHeight - 4);

                g.DrawString(vehicleInfo, rowFont, textBrush, textRect);
            }
        }

        private void DrawMonthRentals(Graphics g)
        {
            using Pen borderPen = new Pen(Color.DimGray);

            foreach (var rental in _dummyRentals)
            {
                if (rental.StartDay == 0) continue; // Skip weekly rentals

                int x = (rental.StartDay - 1) * DayColumnWidth;
                int y = HeaderHeight + rental.VehicleRow * RowHeight;
                int width = rental.Duration * DayColumnWidth;
                int height = RowHeight - 6;

                Rectangle rect = new Rectangle(
                    x + 2,
                    y + 3,
                    width - 4,
                    height
                );

                using Brush fillBrush = new SolidBrush(Color.FromArgb(200, rental.Color));
                g.FillRectangle(fillBrush, rect);
                g.DrawRectangle(borderPen, rect);

                TextRenderer.DrawText(
                    g,
                    rental.Customer,
                    Font,
                    rect,
                    Color.Black,
                    TextFormatFlags.HorizontalCenter |
                    TextFormatFlags.VerticalCenter |
                    TextFormatFlags.EndEllipsis
                );
            }
        }

        private void DrawMonthMaintenance(Graphics g)
        {
            using Pen borderPen = new Pen(Color.DarkRed, 1);

            foreach (var maintenance in _dummyMaintenance)
            {
                if (maintenance.StartDay == 0) continue; // Skip weekly maintenance

                int x = (maintenance.StartDay - 1) * DayColumnWidth;
                int y = HeaderHeight + maintenance.VehicleRow * RowHeight;
                int width = maintenance.Duration * DayColumnWidth;
                int height = RowHeight - 6;

                Rectangle rect = new Rectangle(
                    x + 2,
                    y + 3,
                    width - 4,
                    height
                );

                using Brush fillBrush = new SolidBrush(Color.FromArgb(200, maintenance.Color));
                g.FillRectangle(fillBrush, rect);
                g.DrawRectangle(borderPen, rect);

                // Draw diagonal lines pattern
                using Pen patternPen = new Pen(Color.DarkRed, 1);
                for (int i = -height; i < width; i += 4)
                {
                    g.DrawLine(patternPen, x + 2 + i, y + 3, x + 2 + i + height, y + 3 + height);
                }

                TextRenderer.DrawText(
                    g,
                    "MAINT",
                    Font,
                    rect,
                    Color.White,
                    TextFormatFlags.HorizontalCenter |
                    TextFormatFlags.VerticalCenter |
                    TextFormatFlags.EndEllipsis
                );
            }
        }

        // ===============================
        // WEEK VIEW DRAWING
        // ===============================
        private void DrawWeekView(Graphics g)
        {
            DateTime startOfWeek = GetStartOfWeek(_currentDate);

            DrawWeekTimeHeaders(g, startOfWeek);
            DrawWeekGrid(g);
            DrawWeekRentals(g, startOfWeek);
            DrawWeekMaintenance(g, startOfWeek);
            DrawVehicleTimeRows(g);
        }

        private void DrawWeekTimeHeaders(Graphics g, DateTime startOfWeek)
        {
            using Brush timeHeaderBrush = new SolidBrush(Color.FromArgb(240, 240, 240));
            using Brush dayHeaderBrush = new SolidBrush(Color.FromArgb(220, 220, 220));
            using Pen borderPen = new Pen(Color.LightGray);

            // Time column header
            Rectangle timeHeaderRect = new Rectangle(0, 0, TimeColumnWidth, HeaderHeight);
            g.FillRectangle(timeHeaderBrush, timeHeaderRect);
            g.DrawRectangle(borderPen, timeHeaderRect);

            TextRenderer.DrawText(
                g,
                "TIME",
                Font,
                timeHeaderRect,
                Color.Black,
                TextFormatFlags.HorizontalCenter |
                TextFormatFlags.VerticalCenter
            );

            // Day headers
            for (int day = 0; day < 7; day++)
            {
                DateTime currentDay = startOfWeek.AddDays(day);
                int x = TimeColumnWidth + (day * ((pnlCalendarCanvas.Width - TimeColumnWidth) / 7));

                Rectangle dayHeaderRect = new Rectangle(
                    x,
                    0,
                    (pnlCalendarCanvas.Width - TimeColumnWidth) / 7,
                    HeaderHeight
                );

                g.FillRectangle(dayHeaderBrush, dayHeaderRect);
                g.DrawRectangle(borderPen, dayHeaderRect);

                // Highlight weekends
                if (currentDay.DayOfWeek == DayOfWeek.Saturday || currentDay.DayOfWeek == DayOfWeek.Sunday)
                {
                    using Brush weekendBrush = new SolidBrush(Color.FromArgb(255, 240, 240));
                    g.FillRectangle(weekendBrush, dayHeaderRect);
                }

                // Highlight today
                if (currentDay.Date == DateTime.Today)
                {
                    using Pen todayPen = new Pen(Color.Red, 2);
                    g.DrawRectangle(todayPen, dayHeaderRect);
                }

                TextRenderer.DrawText(
                    g,
                    $"{currentDay:ddd}\n{currentDay:MMM d}",
                    Font,
                    dayHeaderRect,
                    Color.Black,
                    TextFormatFlags.HorizontalCenter |
                    TextFormatFlags.VerticalCenter |
                    TextFormatFlags.WordBreak
                );
            }
        }

        private void DrawWeekGrid(Graphics g)
        {
            int totalHeight = pnlCalendarCanvas.Height;
            int dayWidth = (pnlCalendarCanvas.Width - TimeColumnWidth) / 7;
            int rowCount = dgvVehicles.Rows.Count;

            using Pen lightPen = new Pen(Color.LightGray);
            using Pen mediumPen = new Pen(Color.Gray);

            // Draw time column
            for (int hour = DayStartHour; hour <= DayEndHour; hour++)
            {
                int y = HeaderHeight + ((hour - DayStartHour) * HourRowHeight);

                // Time labels
                Rectangle timeRect = new Rectangle(0, y, TimeColumnWidth, HourRowHeight);
                g.DrawRectangle(lightPen, timeRect);

                TextRenderer.DrawText(
                    g,
                    $"{hour:00}:00",
                    Font,
                    timeRect,
                    Color.Black,
                    TextFormatFlags.HorizontalCenter |
                    TextFormatFlags.VerticalCenter
                );

                // Horizontal lines across days
                g.DrawLine(lightPen, TimeColumnWidth, y, pnlCalendarCanvas.Width, y);
            }

            // Draw vertical day separators
            for (int day = 0; day <= 7; day++)
            {
                int x = TimeColumnWidth + (day * dayWidth);
                int bottomY = HeaderHeight + (rowCount * HourRowHeight * (DayEndHour - DayStartHour + 1));
                g.DrawLine(mediumPen, x, HeaderHeight, x, bottomY);
            }

            // Draw vehicle row separators
            for (int i = 0; i <= rowCount; i++)
            {
                int y = HeaderHeight + (i * HourRowHeight * (DayEndHour - DayStartHour + 1));
                g.DrawLine(mediumPen, 0, y, pnlCalendarCanvas.Width, y);
            }
        }

        private void DrawVehicleTimeRows(Graphics g)
        {
            using Font rowFont = new Font(Font.FontFamily, 8);
            using Brush textBrush = new SolidBrush(Color.Black);

            for (int i = 0; i < dgvVehicles.Rows.Count; i++)
            {
                int y = HeaderHeight + (i * HourRowHeight * (DayEndHour - DayStartHour + 1));

                // Draw vehicle name in time column
                string vehicleInfo = _dummyVehicles[i].LicensePlate;
                RectangleF textRect = new RectangleF(2, y + 2, TimeColumnWidth - 4, 20);

                g.DrawString(vehicleInfo, rowFont, textBrush, textRect);

                // Draw model on second line
                string modelInfo = _dummyVehicles[i].Model;
                RectangleF modelRect = new RectangleF(2, y + 22, TimeColumnWidth - 4, 20);
                g.DrawString(modelInfo, rowFont, textBrush, modelRect);
            }
        }

        private void DrawWeekRentals(Graphics g, DateTime startOfWeek)
        {
            using Pen borderPen = new Pen(Color.DimGray);
            int dayWidth = (pnlCalendarCanvas.Width - TimeColumnWidth) / 7;

            foreach (var rental in _dummyRentals)
            {
                if (rental.StartTime == DateTime.MinValue) continue; // Skip monthly rentals

                // Check if rental is in current week
                if (rental.StartTime.Date < startOfWeek || rental.StartTime.Date > startOfWeek.AddDays(6))
                    continue;

                // Calculate position
                int dayIndex = (int)(rental.StartTime.Date - startOfWeek.Date).TotalDays;
                int x = TimeColumnWidth + (dayIndex * dayWidth);

                // Calculate vertical position based on time
                double hourFraction = rental.StartTime.Hour + (rental.StartTime.Minute / 60.0);
                double durationHours = (rental.EndTime - rental.StartTime).TotalHours;

                int y = HeaderHeight + (rental.VehicleRow * HourRowHeight * (DayEndHour - DayStartHour + 1))
                        + (int)((hourFraction - DayStartHour) * HourRowHeight);
                int height = (int)(durationHours * HourRowHeight);

                Rectangle rect = new Rectangle(
                    x + 2,
                    y + 2,
                    dayWidth - 4,
                    height - 4
                );

                using Brush fillBrush = new SolidBrush(Color.FromArgb(200, rental.Color));
                g.FillRectangle(fillBrush, rect);
                g.DrawRectangle(borderPen, rect);

                // Draw rental info
                string timeText = $"{rental.StartTime:HH:mm} - {rental.EndTime:HH:mm}";
                string displayText = $"{rental.Customer}\n{timeText}";

                TextRenderer.DrawText(
                    g,
                    displayText,
                    new Font(Font.FontFamily, 8),
                    rect,
                    Color.Black,
                    TextFormatFlags.HorizontalCenter |
                    TextFormatFlags.VerticalCenter |
                    TextFormatFlags.WordBreak
                );
            }
        }

        private void DrawWeekMaintenance(Graphics g, DateTime startOfWeek)
        {
            using Pen borderPen = new Pen(Color.DarkRed, 1);
            int dayWidth = (pnlCalendarCanvas.Width - TimeColumnWidth) / 7;

            foreach (var maintenance in _dummyMaintenance)
            {
                if (maintenance.StartTime == DateTime.MinValue) continue; // Skip monthly maintenance

                // Check if maintenance is in current week
                if (maintenance.StartTime.Date < startOfWeek || maintenance.StartTime.Date > startOfWeek.AddDays(6))
                    continue;

                // Calculate position
                int dayIndex = (int)(maintenance.StartTime.Date - startOfWeek.Date).TotalDays;
                int x = TimeColumnWidth + (dayIndex * dayWidth);

                // Calculate vertical position based on time
                double hourFraction = maintenance.StartTime.Hour + (maintenance.StartTime.Minute / 60.0);
                double durationHours = (maintenance.EndTime - maintenance.StartTime).TotalHours;

                int y = HeaderHeight + (maintenance.VehicleRow * HourRowHeight * (DayEndHour - DayStartHour + 1))
                        + (int)((hourFraction - DayStartHour) * HourRowHeight);
                int height = (int)(durationHours * HourRowHeight);

                Rectangle rect = new Rectangle(
                    x + 2,
                    y + 2,
                    dayWidth - 4,
                    height - 4
                );

                using Brush fillBrush = new SolidBrush(Color.FromArgb(200, maintenance.Color));
                g.FillRectangle(fillBrush, rect);
                g.DrawRectangle(borderPen, rect);

                // Draw diagonal lines pattern
                using Pen patternPen = new Pen(Color.DarkRed, 1);
                for (int i = -height; i < dayWidth; i += 4)
                {
                    g.DrawLine(patternPen, x + 2 + i, y + 2, x + 2 + i + height, y + 2 + height);
                }

                // Draw maintenance info
                string timeText = $"{maintenance.StartTime:HH:mm} - {maintenance.EndTime:HH:mm}";
                string displayText = $"MAINT\n{timeText}";

                TextRenderer.DrawText(
                    g,
                    displayText,
                    new Font(Font.FontFamily, 8, FontStyle.Bold),
                    rect,
                    Color.White,
                    TextFormatFlags.HorizontalCenter |
                    TextFormatFlags.VerticalCenter |
                    TextFormatFlags.WordBreak
                );
            }
        }

        private void dgvVehicles_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Ensure row height stays consistent
            dgvVehicles.Rows[e.RowIndex].Height = RowHeight;
        }
    }
}