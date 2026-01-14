using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using VRMS.Models.Rentals;
using VRMS.Models.Fleet;

namespace VRMS.UI.Pdf
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

            var fontTitle = new XFont("Arial", 18, XFontStyle.Bold);
            var fontHeader = new XFont("Arial", 11, XFontStyle.Bold);
            var fontBody = new XFont("Arial", 10, XFontStyle.Regular);

            double y = 40;

            // Title
            gfx.DrawString(
                "RENTAL RECEIPT",
                fontTitle,
                XBrushes.Black,
                new XRect(0, y, page.Width, 30),
                XStringFormats.TopCenter);

            y += 50;

            // Receipt number
            gfx.DrawString(
                $"Receipt #: RENT-{rental.Id:D6}",
                fontBody,
                XBrushes.Black,
                40, y);

            y += 20;

            gfx.DrawString(
                $"Date: {DateTime.Now:yyyy-MM-dd}",
                fontBody,
                XBrushes.Black,
                40, y);

            y += 30;

            gfx.DrawLine(XPens.Black, 40, y, page.Width - 40, y);
            y += 20;

            // Info block
            DrawRow(gfx, fontHeader, fontBody, "Customer:", customerName, ref y);
            DrawRow(gfx, fontHeader, fontBody, "Vehicle:",
                $"{vehicle.Make} {vehicle.Model}", ref y);

            DrawRow(gfx, fontHeader, fontBody, "Rental Period:",
                $"{rental.PickupDate:d} → {rental.ExpectedReturnDate:d}", ref y);

            DrawRow(gfx, fontHeader, fontBody, "Status:",
                rental.Status.ToString(), ref y);

            y += 20;

            gfx.DrawLine(XPens.Black, 40, y, page.Width - 40, y);
            y += 20;

            // Billing placeholder
            gfx.DrawString(
                "Billing Information",
                fontHeader,
                XBrushes.Black,
                40, y);

            y += 20;

            gfx.DrawString(
                "Billing details are not available yet.",
                fontBody,
                XBrushes.Gray,
                40, y);

            y += 40;

            gfx.DrawString(
                "Thank you for choosing VRMS",
                fontBody,
                XBrushes.Black,
                new XRect(0, y, page.Width, 20),
                XStringFormats.TopCenter);

            document.Save(filePath);
        }

        private static void DrawRow(
            XGraphics gfx,
            XFont header,
            XFont body,
            string label,
            string value,
            ref double y)
        {
            gfx.DrawString(label, header, XBrushes.Black, 40, y);
            gfx.DrawString(value, body, XBrushes.Black, 160, y);
            y += 18;
        }
    }
}
