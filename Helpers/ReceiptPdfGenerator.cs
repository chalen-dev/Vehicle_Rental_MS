using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using VRMS.Models.Fleet;
using VRMS.Models.Rentals;

namespace VRMS.Helpers
{
    public static class ReceiptPdfGenerator
    {
        public static void Generate(
            string filePath,
            Rental rental,
            Vehicle vehicle,
            string customerName)
        {
            using var document = new PdfDocument();
            var page = document.AddPage();
            page.Size = PdfSharpCore.PageSize.A4;

            var gfx = XGraphics.FromPdfPage(page);

            // Thin receipt fonts - use monospace for receipt look
            var fontTitle = new XFont("Courier New", 16, XFontStyle.Bold);
            var fontStore = new XFont("Courier New", 12, XFontStyle.Bold);
            var fontHeader = new XFont("Courier New", 10, XFontStyle.Bold);
            var fontBody = new XFont("Courier New", 9, XFontStyle.Regular);
            var fontSmall = new XFont("Courier New", 8, XFontStyle.Regular);

            double y = 30;
            double leftMargin = 40;
            double centerX = page.Width / 2;

            // Store header - centered like receipt
            gfx.DrawString("SNB (SAKYANAN NI BET)", fontStore, XBrushes.Black,
                new XRect(0, y, page.Width, 20), XStringFormats.TopCenter);
            y += 20;

            gfx.DrawString("Vehicle Rental", fontSmall, XBrushes.Black,
                new XRect(0, y, page.Width, 15), XStringFormats.TopCenter);
            y += 15;

            gfx.DrawString("09165968511", fontSmall, XBrushes.Black,
                new XRect(0, y, page.Width, 15), XStringFormats.TopCenter);
            y += 20;

            // Separator line
            DrawCenteredLine(gfx, centerX - 100, y, centerX + 100, y);
            y += 20;

            // Receipt title
            gfx.DrawString("RENTAL RECEIPT", fontTitle, XBrushes.Black,
                new XRect(0, y, page.Width, 20), XStringFormats.TopCenter);
            y += 25;

            // Receipt info in simple columns
            gfx.DrawString($"Receipt #: RENT-{rental.Id:D6}", fontBody, XBrushes.Black, leftMargin, y);
            gfx.DrawString($"Date: {DateTime.Now:MM/dd/yyyy}", fontBody, XBrushes.Black, page.Width - 200, y);
            y += 15;

            gfx.DrawString($"Time: {DateTime.Now:hh:mm tt}", fontBody, XBrushes.Black, leftMargin, y);
            y += 20;

            // Simple separator
            DrawCenteredLine(gfx, centerX - 80, y, centerX + 80, y);
            y += 20;

            // Simple customer info - using original parameter
            gfx.DrawString("CUSTOMER:", fontHeader, XBrushes.Black, leftMargin, y);
            y += 15;
            gfx.DrawString(customerName, fontBody, XBrushes.Black, leftMargin, y);
            y += 20;

            // Simple vehicle info - using original logic
            gfx.DrawString("VEHICLE:", fontHeader, XBrushes.Black, leftMargin, y);
            y += 15;
            gfx.DrawString($"{vehicle.Make} {vehicle.Model}", fontBody, XBrushes.Black, leftMargin, y);
            y += 20;

            // Simple rental period - using original logic
            gfx.DrawString("RENTAL PERIOD:", fontHeader, XBrushes.Black, leftMargin, y);
            y += 15;
            gfx.DrawString($"{rental.PickupDate:MM/dd/yyyy} → {rental.ExpectedReturnDate:MM/dd/yyyy}", fontBody, XBrushes.Black, leftMargin, y);
            y += 20;

            // Simple status - using original logic
            gfx.DrawString("STATUS:", fontHeader, XBrushes.Black, leftMargin, y);
            y += 15;
            gfx.DrawString(rental.Status.ToString(), fontBody, XBrushes.Black, leftMargin, y);
            y += 25;

            // Simple separator
            DrawCenteredLine(gfx, centerX - 80, y, centerX + 80, y);
            y += 20;

            // Simple billing placeholder - like original but styled
            gfx.DrawString("BILLING INFORMATION", fontHeader, XBrushes.Black, leftMargin, y);
            y += 20;

            gfx.DrawString("Details available upon return", fontBody, XBrushes.Gray, leftMargin, y);
            y += 40;

            // Simple thank you - centered
            gfx.DrawString("Thank you for choosing SNB", fontBody, XBrushes.Black,
                new XRect(0, y, page.Width, 20), XStringFormats.TopCenter);
            y += 15;

            gfx.DrawString("09165968511", fontSmall, XBrushes.Black,
                new XRect(0, y, page.Width, 15), XStringFormats.TopCenter);

            document.Save(filePath);
        }

        private static void DrawCenteredLine(XGraphics gfx, double x1, double y1, double x2, double y2)
        {
            var pen = new XPen(XColor.FromArgb(0, 0, 0), 0.5);
            gfx.DrawLine(pen, x1, y1, x2, y2);
        }
    }
}