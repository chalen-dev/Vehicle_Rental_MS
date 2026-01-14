namespace VRMS.UI.Forms.Receipts
{
    partial class ReceiptForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblReceiptNumber;

        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblCustomerTitle;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblVehicleTitle;
        private System.Windows.Forms.Label lblVehicle;
        private System.Windows.Forms.Label lblPeriodTitle;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.Label lblStatusTitle;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblIssuedTitle;
        private System.Windows.Forms.Label lblIssuedDate;
        private System.Windows.Forms.Label lblDurationTitle;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblOdometerTitle;
        private System.Windows.Forms.Label lblOdometer;

        private System.Windows.Forms.Panel panelBilling;
        private System.Windows.Forms.Label lblBillingHeader;
        private System.Windows.Forms.Label lblBillingInfo;

        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            panelHeader = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            lblReceiptNumber = new System.Windows.Forms.Label();

            panelContent = new System.Windows.Forms.Panel();
            lblCustomerTitle = new System.Windows.Forms.Label();
            lblCustomer = new System.Windows.Forms.Label();
            lblVehicleTitle = new System.Windows.Forms.Label();
            lblVehicle = new System.Windows.Forms.Label();
            lblPeriodTitle = new System.Windows.Forms.Label();
            lblPeriod = new System.Windows.Forms.Label();
            lblStatusTitle = new System.Windows.Forms.Label();
            lblStatus = new System.Windows.Forms.Label();
            lblIssuedTitle = new System.Windows.Forms.Label();
            lblIssuedDate = new System.Windows.Forms.Label();
            lblDurationTitle = new System.Windows.Forms.Label();
            lblDuration = new System.Windows.Forms.Label();
            lblOdometerTitle = new System.Windows.Forms.Label();
            lblOdometer = new System.Windows.Forms.Label();

            panelBilling = new System.Windows.Forms.Panel();
            lblBillingHeader = new System.Windows.Forms.Label();
            lblBillingInfo = new System.Windows.Forms.Label();

            panelFooter = new System.Windows.Forms.Panel();
            btnPrint = new System.Windows.Forms.Button();
            btnClose = new System.Windows.Forms.Button();

            panelHeader.SuspendLayout();
            panelContent.SuspendLayout();
            panelBilling.SuspendLayout();
            panelFooter.SuspendLayout();
            SuspendLayout();

            // ================= HEADER =================
            panelHeader.BackColor = System.Drawing.Color.FromArgb(30, 60, 90);
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Height = 80;

            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(20, 15);
            lblTitle.Text = "🧾 Rental Receipt";

            lblReceiptNumber.AutoSize = true;
            lblReceiptNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblReceiptNumber.ForeColor = System.Drawing.Color.Gainsboro;
            lblReceiptNumber.Location = new System.Drawing.Point(22, 45);
            lblReceiptNumber.Text = "RENT-000000";

            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblReceiptNumber);

            // ================= CONTENT =================
            panelContent.Dock = System.Windows.Forms.DockStyle.Top;
            panelContent.Padding = new System.Windows.Forms.Padding(20);
            panelContent.Height = 300;

            AddLabel(lblCustomerTitle, "Customer:", 20, 20);
            AddValue(lblCustomer, 140, 18);

            AddLabel(lblVehicleTitle, "Vehicle:", 20, 55);
            AddValue(lblVehicle, 140, 53);

            AddLabel(lblPeriodTitle, "Rental Period:", 20, 90);
            AddValue(lblPeriod, 140, 88);

            AddLabel(lblDurationTitle, "Duration:", 20, 125);
            AddValue(lblDuration, 140, 123);

            AddLabel(lblOdometerTitle, "Odometer:", 20, 160);
            AddValue(lblOdometer, 140, 158);

            AddLabel(lblStatusTitle, "Status:", 20, 195);
            AddValue(lblStatus, 140, 193);

            AddLabel(lblIssuedTitle, "Issued:", 20, 230);
            AddValue(lblIssuedDate, 140, 228);

            panelContent.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblCustomerTitle, lblCustomer,
                lblVehicleTitle, lblVehicle,
                lblPeriodTitle, lblPeriod,
                lblDurationTitle, lblDuration,
                lblOdometerTitle, lblOdometer,
                lblStatusTitle, lblStatus,
                lblIssuedTitle, lblIssuedDate
            });

            // ================= BILLING =================
            panelBilling.Dock = System.Windows.Forms.DockStyle.Fill;
            panelBilling.Padding = new System.Windows.Forms.Padding(20);
            panelBilling.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);

            lblBillingHeader.Text = "Billing Information";
            lblBillingHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            lblBillingHeader.Location = new System.Drawing.Point(20, 15);

            lblBillingInfo.Text = "Billing details are not available yet.";
            lblBillingInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblBillingInfo.ForeColor = System.Drawing.Color.Gray;
            lblBillingInfo.Location = new System.Drawing.Point(20, 45);
            lblBillingInfo.Size = new System.Drawing.Size(440, 50);

            panelBilling.Controls.Add(lblBillingHeader);
            panelBilling.Controls.Add(lblBillingInfo);

            // ================= FOOTER =================
            panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelFooter.Height = 60;
            panelFooter.Padding = new System.Windows.Forms.Padding(15);
            panelFooter.BackColor = System.Drawing.Color.WhiteSmoke;

            btnPrint.Text = "🖨 Print";
            btnPrint.Width = 120;
            btnPrint.Dock = System.Windows.Forms.DockStyle.Left;
            btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            btnPrint.ForeColor = System.Drawing.Color.White;

            btnClose.Text = "Close";
            btnClose.Width = 100;
            btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btnClose.ForeColor = System.Drawing.Color.White;

            panelFooter.Controls.Add(btnPrint);
            panelFooter.Controls.Add(btnClose);

            // ================= FORM =================
            Controls.Add(panelBilling);
            Controls.Add(panelContent);
            Controls.Add(panelFooter);
            Controls.Add(panelHeader);

            Text = "Receipt";
            ClientSize = new System.Drawing.Size(520, 520);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;

            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelContent.ResumeLayout(false);
            panelBilling.ResumeLayout(false);
            panelFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        // ================= HELPERS =================
        private void AddLabel(System.Windows.Forms.Label lbl, string text, int x, int y)
        {
            lbl.Text = text;
            lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            lbl.ForeColor = System.Drawing.Color.Gray;
            lbl.Location = new System.Drawing.Point(x, y);
            lbl.AutoSize = true;
        }

        private void AddValue(System.Windows.Forms.Label lbl, int x, int y)
        {
            lbl.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            lbl.Location = new System.Drawing.Point(x, y);
            lbl.AutoSize = true;
        }
    }
}
