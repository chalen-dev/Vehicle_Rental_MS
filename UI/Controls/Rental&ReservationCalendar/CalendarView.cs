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
        private const int DayColumnWidth = 45;     // Slightly wider for better spacing
        private const int RowHeight = 50;          // Increased from 40 to 50 (25% taller)
        private const int HeaderHeight = 45;       // Slightly taller header to match
        private const int DayStartHour = 8;        // 8 AM
        private const int DayEndHour = 20;         // 8 PM

        // ===============================
        // ENUMS
        // ===============================
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
            // Monthly view rentals only
            new DummyRental { VehicleRow = 0, StartDay = 2,  Duration = 3, Customer = "Juan D.", Color = Color.SkyBlue },
            new DummyRental { VehicleRow = 1, StartDay = 5,  Duration = 4, Customer = "Maria S.", Color = Color.LightGreen },
            new DummyRental { VehicleRow = 2, StartDay = 1,  Duration = 2, Customer = "Alex R.", Color = Color.Khaki },
            new DummyRental { VehicleRow = 3, StartDay = 10, Duration = 5, Customer = "Chris T.", Color = Color.Plum },
            new DummyRental { VehicleRow = 4, StartDay = 8,  Duration = 3, Customer = "Liam K.", Color = Color.LightSalmon },
            new DummyRental { VehicleRow = 5, StartDay = 15, Duration = 2, Customer = "Emma W.", Color = Color.LightCoral },
            new DummyRental { VehicleRow = 6, StartDay = 20, Duration = 4, Customer = "Noah B.", Color = Color.LightSeaGreen },
            new DummyRental { VehicleRow = 7, StartDay = 18, Duration = 3, Customer = "Olivia M.", Color = Color.LightSkyBlue }
        };

        private readonly List<DummyMaintenance> _dummyMaintenance = new()
        {
            // Monthly view maintenance only
            new DummyMaintenance { VehicleRow = 2, StartDay = 5, Duration = 3, Description = "Oil Change & Brakes", Color = Color.Orange },
            new DummyMaintenance { VehicleRow = 6, StartDay = 12, Duration = 2, Description = "Tire Replacement", Color = Color.OrangeRed },
            new DummyMaintenance { VehicleRow = 1, StartDay = 20, Duration = 1, Description = "Engine Check", Color = Color.DarkOrange },
            new DummyMaintenance { VehicleRow = 4, StartDay = 25, Duration = 4, Description = "Major Service", Color = Color.Coral }
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

            SetupVehicleDataGrid();
            EnableDoubleBuffering();

            // Position DGV correctly
            PositionDGV();
        }

        // ===============================
        // POSITION DGV TO MATCH CALENDAR
        // ===============================
        private void PositionDGV()
        {
            // Set DGV position to match calendar header
            dgvVehicles.Location = new Point(0, HeaderHeight);
            dgvVehicles.Height = pnlVehicleList.Height - HeaderHeight;

            // Configure row height
            dgvVehicles.RowTemplate.Height = RowHeight;
            foreach (DataGridViewRow row in dgvVehicles.Rows)
            {
                row.Height = RowHeight;
            }
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

            // Use slightly larger font for taller rows
            dgvVehicles.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);

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
        // VEHICLE HEADER PAINT
        // ===============================
        private void pnlVehicleHeader_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = pnlVehicleHeader.ClientRectangle;

            // Fill background
            using Brush headerBrush = new SolidBrush(Color.FromArgb(240, 240, 240));
            g.FillRectangle(headerBrush, rect);

            // Draw border
            using Pen borderPen = new Pen(Color.LightGray);
            g.DrawRectangle(borderPen, rect);

            // Draw header text with slightly larger font
            using Font headerFont = new Font(Font.FontFamily, 10, FontStyle.Bold);
            TextRenderer.DrawText(
                g,
                "VEHICLES",
                headerFont,
                rect,
                Color.Black,
                TextFormatFlags.HorizontalCenter |
                TextFormatFlags.VerticalCenter
            );
        }

        // ===============================
        // EVENT HANDLERS
        // ===============================
        private void btnPrev_Click(object sender, EventArgs e)
        {
            _currentDate = _currentDate.AddMonths(-1);
            dtpMonthYear.Value = _currentDate;
            pnlCalendarCanvas.Invalidate();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _currentDate = _currentDate.AddMonths(1);
            dtpMonthYear.Value = _currentDate;
            pnlCalendarCanvas.Invalidate();
        }

        private void dtpMonthYear_ValueChanged(object sender, EventArgs e)
        {
            _currentDate = dtpMonthYear.Value;
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
                dgvVehicles.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);

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
            DrawMonthView(g);
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
        }

        private void DrawDayHeaders(Graphics g, int daysInMonth)
        {
            using Brush headerBrush = new SolidBrush(Color.FromArgb(240, 240, 240));
            using Pen borderPen = new Pen(Color.LightGray);
            using Font dayFont = new Font(Font.FontFamily, 9, FontStyle.Bold);
            using Font dateFont = new Font(Font.FontFamily, 10, FontStyle.Regular);

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

                // Draw day name (abbreviated)
                Rectangle dayNameRect = new Rectangle(x, 2, DayColumnWidth, 18);
                TextRenderer.DrawText(
                    g,
                    date.ToString("ddd"),
                    dayFont,
                    dayNameRect,
                    Color.Black,
                    TextFormatFlags.HorizontalCenter |
                    TextFormatFlags.Top
                );

                // Draw date number
                Rectangle dateRect = new Rectangle(x, 20, DayColumnWidth, 23);
                TextRenderer.DrawText(
                    g,
                    day.ToString(),
                    dateFont,
                    dateRect,
                    Color.Black,
                    TextFormatFlags.HorizontalCenter |
                    TextFormatFlags.Top
                );
            }
        }

        private void DrawGrid(Graphics g, int daysInMonth)
        {
            int totalHeight = pnlCalendarCanvas.Height;
            int totalWidth = daysInMonth * DayColumnWidth;
            int rowCount = dgvVehicles.Rows.Count;

            using Pen pen = new Pen(Color.LightGray);

            // Vertical day lines (start from x = 0, no first column for vehicle names)
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

        private void DrawMonthRentals(Graphics g)
        {
            using Pen borderPen = new Pen(Color.DimGray);
            using Font rentalFont = new Font(Font.FontFamily, 9);

            foreach (var rental in _dummyRentals)
            {
                int x = (rental.StartDay - 1) * DayColumnWidth;
                int y = HeaderHeight + rental.VehicleRow * RowHeight;
                int width = rental.Duration * DayColumnWidth;
                int height = RowHeight - 8; // Slightly less than full row for padding

                Rectangle rect = new Rectangle(
                    x + 3,
                    y + 4,
                    width - 6,
                    height
                );

                using Brush fillBrush = new SolidBrush(Color.FromArgb(200, rental.Color));
                g.FillRectangle(fillBrush, rect);
                g.DrawRectangle(borderPen, rect);

                TextRenderer.DrawText(
                    g,
                    rental.Customer,
                    rentalFont,
                    rect,
                    Color.Black,
                    TextFormatFlags.HorizontalCenter |
                    TextFormatFlags.VerticalCenter |
                    TextFormatFlags.EndEllipsis |
                    TextFormatFlags.WordBreak
                );
            }
        }

        private void DrawMonthMaintenance(Graphics g)
        {
            using Pen borderPen = new Pen(Color.DarkRed, 1);
            using Font maintFont = new Font(Font.FontFamily, 9, FontStyle.Bold);

            foreach (var maintenance in _dummyMaintenance)
            {
                int x = (maintenance.StartDay - 1) * DayColumnWidth;
                int y = HeaderHeight + maintenance.VehicleRow * RowHeight;
                int width = maintenance.Duration * DayColumnWidth;
                int height = RowHeight - 8;

                Rectangle rect = new Rectangle(
                    x + 3,
                    y + 4,
                    width - 6,
                    height
                );

                using Brush fillBrush = new SolidBrush(Color.FromArgb(200, maintenance.Color));
                g.FillRectangle(fillBrush, rect);
                g.DrawRectangle(borderPen, rect);

                // Draw diagonal lines pattern
                using Pen patternPen = new Pen(Color.DarkRed, 1);
                for (int i = -height; i < width; i += 5)
                {
                    g.DrawLine(patternPen, x + 3 + i, y + 4, x + 3 + i + height, y + 4 + height);
                }

                TextRenderer.DrawText(
                    g,
                    "MAINT",
                    maintFont,
                    rect,
                    Color.White,
                    TextFormatFlags.HorizontalCenter |
                    TextFormatFlags.VerticalCenter |
                    TextFormatFlags.EndEllipsis
                );
            }
        }

        private void dgvVehicles_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Ensure row height stays consistent
            dgvVehicles.Rows[e.RowIndex].Height = RowHeight;
        }

        private void pnlVehicleList_Resize(object sender, EventArgs e)
        {
            // Reposition DGV when panel resizes
            PositionDGV();
        }
    }
}