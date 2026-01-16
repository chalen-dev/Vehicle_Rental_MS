namespace VRMS.UI.Forms.Receipts
{
    partial class ReceiptForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelHeader;
        private Panel panelContent;
        private Panel panelBilling;
        private Panel panelFooter;

        private Label lblTitle;
        private Label lblReceiptNumber;

        private Label lblCustomerTitle;
        private Label lblCustomer;
        private Label lblVehicleTitle;
        private Label lblVehicle;
        private Label lblPeriodTitle;
        private Label lblPeriod;
        private Label lblDurationTitle;
        private Label lblDuration;
        private Label lblOdometerTitle;
        private Label lblOdometer;
        private Label lblStatusTitle;
        private Label lblStatus;
        private Label lblIssuedTitle;
        private Label lblIssuedDate;

        private Label lblBillingHeader;
        private Label lblBillingInfo;

        private Button btnPrint;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            panelContent = new Panel();
            panelBilling = new Panel();
            panelFooter = new Panel();

            lblTitle = new Label();
            lblReceiptNumber = new Label();

            lblCustomerTitle = new Label();
            lblCustomer = new Label();
            lblVehicleTitle = new Label();
            lblVehicle = new Label();
            lblPeriodTitle = new Label();
            lblPeriod = new Label();
            lblDurationTitle = new Label();
            lblDuration = new Label();
            lblOdometerTitle = new Label();
            lblOdometer = new Label();
            lblStatusTitle = new Label();
            lblStatus = new Label();
            lblIssuedTitle = new Label();
            lblIssuedDate = new Label();

            lblBillingHeader = new Label();
            lblBillingInfo = new Label();

            btnPrint = new Button();
            btnClose = new Button();

            SuspendLayout();

            // HEADER
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 80;
            panelHeader.BackColor = Color.FromArgb(30, 60, 90);

            lblTitle.Text = "🧾 Rental Receipt";
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 15);

            lblReceiptNumber.ForeColor = Color.Gainsboro;
            lblReceiptNumber.Location = new Point(22, 45);

            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblReceiptNumber);

            // CONTENT
            panelContent.Dock = DockStyle.Top;
            panelContent.Height = 260;
            panelContent.Padding = new Padding(20);

            int y = 20;
            AddPair(lblCustomerTitle, "Customer:", lblCustomer, y); y += 32;
            AddPair(lblVehicleTitle, "Vehicle:", lblVehicle, y); y += 32;
            AddPair(lblPeriodTitle, "Period:", lblPeriod, y); y += 32;
            AddPair(lblDurationTitle, "Duration:", lblDuration, y); y += 32;
            AddPair(lblOdometerTitle, "Odometer:", lblOdometer, y); y += 32;
            AddPair(lblStatusTitle, "Status:", lblStatus, y); y += 32;
            AddPair(lblIssuedTitle, "Issued:", lblIssuedDate, y);

            panelContent.Controls.AddRange(new Control[]
            {
                lblCustomerTitle, lblCustomer,
                lblVehicleTitle, lblVehicle,
                lblPeriodTitle, lblPeriod,
                lblDurationTitle, lblDuration,
                lblOdometerTitle, lblOdometer,
                lblStatusTitle, lblStatus,
                lblIssuedTitle, lblIssuedDate
            });

            // BILLING
            panelBilling.Dock = DockStyle.Fill;
            panelBilling.Padding = new Padding(20);
            panelBilling.BackColor = Color.FromArgb(248, 249, 250);

            lblBillingHeader.Text = "Billing";
            lblBillingHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblBillingHeader.Location = new Point(20, 15);

            lblBillingInfo.Location = new Point(20, 45);
            lblBillingInfo.Size = new Size(460, 120);

            panelBilling.Controls.Add(lblBillingHeader);
            panelBilling.Controls.Add(lblBillingInfo);

            // FOOTER
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Height = 60;
            panelFooter.Padding = new Padding(15);

            btnPrint.Text = "Print";
            btnPrint.Dock = DockStyle.Left;
            btnPrint.Width = 120;

            btnClose.Text = "Close";
            btnClose.Dock = DockStyle.Right;
            btnClose.Width = 100;

            panelFooter.Controls.Add(btnPrint);
            panelFooter.Controls.Add(btnClose);

            // FORM (ORDER IS CRITICAL)
            Controls.Add(panelBilling);
            Controls.Add(panelContent);
            Controls.Add(panelFooter);
            Controls.Add(panelHeader);

            ClientSize = new Size(520, 560);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            Text = "Receipt";

            ResumeLayout(false);
        }

        private void AddPair(Label title, string text, Label value, int y)
        {
            title.Text = text;
            title.ForeColor = Color.Gray;
            title.Location = new Point(20, y);

            value.Location = new Point(150, y);
            value.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        }
    }
}
