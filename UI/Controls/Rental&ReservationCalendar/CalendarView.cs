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
        private const int RowHeight = 40;
        private const int HeaderHeight = 40;

        // ===============================
        // STATE
        // ===============================
        private DateTime _currentMonth;

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
        // DUMMY DATA (10 ITEMS)
        // ===============================
        private readonly List<DummyRental> _dummyRentals = new()
        {
            new DummyRental { VehicleRow = 0, StartDay = 2,  Duration = 3, Customer = "Juan D.", Color = Color.SkyBlue },
            new DummyRental { VehicleRow = 1, StartDay = 5,  Duration = 4, Customer = "Maria S.", Color = Color.LightGreen },
            new DummyRental { VehicleRow = 2, StartDay = 1,  Duration = 2, Customer = "Alex R.", Color = Color.Khaki },
            new DummyRental { VehicleRow = 3, StartDay = 10, Duration = 5, Customer = "Chris T.", Color = Color.Plum },
            new DummyRental { VehicleRow = 4, StartDay = 8,  Duration = 3, Customer = "Liam K.", Color = Color.LightSalmon },
            new DummyRental { VehicleRow = 5, StartDay = 15, Duration = 6, Customer = "Noah P.", Color = Color.LightSteelBlue },
            new DummyRental { VehicleRow = 6, StartDay = 20, Duration = 4, Customer = "Emma L.", Color = Color.PaleGreen },
            new DummyRental { VehicleRow = 7, StartDay = 12, Duration = 2, Customer = "Ava M.", Color = Color.Wheat },
            new DummyRental { VehicleRow = 8, StartDay = 18, Duration = 5, Customer = "Oliver C.", Color = Color.LightPink },
            new DummyRental { VehicleRow = 9, StartDay = 25, Duration = 3, Customer = "Sophia B.", Color = Color.LightCyan }
        };

        public CalendarView()
        {
            InitializeComponent();

            _currentMonth = new DateTime(
                DateTime.Today.Year,
                DateTime.Today.Month,
                1
            );

            dtpMonthYear.Value = _currentMonth;

            EnableDoubleBuffering();
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

            DrawDayHeaders(g);
            DrawGrid(g);
            DrawDummyRentals(g);
        }

        private void pnlCalendarCanvas_Resize(object sender, EventArgs e)
        {
            pnlCalendarCanvas.Invalidate();
        }

        // ===============================
        // DRAWING METHODS
        // ===============================
        private void DrawDayHeaders(Graphics g)
        {
            int daysInMonth = DateTime.DaysInMonth(
                _currentMonth.Year,
                _currentMonth.Month
            );

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
                    _currentMonth.Year,
                    _currentMonth.Month,
                    day
                );

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

        private void DrawGrid(Graphics g)
        {
            int daysInMonth = DateTime.DaysInMonth(
                _currentMonth.Year,
                _currentMonth.Month
            );

            int totalHeight = pnlCalendarCanvas.Height;
            int totalWidth = daysInMonth * DayColumnWidth;

            using Pen pen = new Pen(Color.LightGray);

            // Vertical day lines
            for (int i = 0; i <= daysInMonth; i++)
            {
                int x = i * DayColumnWidth;
                g.DrawLine(pen, x, HeaderHeight, x, totalHeight);
            }

            // Horizontal rows
            for (int y = HeaderHeight; y < totalHeight; y += RowHeight)
            {
                g.DrawLine(pen, 0, y, totalWidth, y);
            }
        }

        // ===============================
        // DRAW DUMMY RENTALS
        // ===============================
        private void DrawDummyRentals(Graphics g)
        {
            using Pen borderPen = new Pen(Color.DimGray);

            foreach (var rental in _dummyRentals)
            {
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

                using Brush fillBrush = new SolidBrush(rental.Color);
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
    }
}
