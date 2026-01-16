namespace VRMS.UI.Forms.Payments
{
    partial class RentalDownPayment
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblHeader = new Label();
            grpRentalSummary = new GroupBox();
            lblReturnDate = new Label();
            lblRentalID = new Label();
            lblVehicleDetails = new Label();
            lblCustomerName = new Label();
            grpInitialCosts = new GroupBox();
            lblTotalInitialPayment = new Label();
            lblFirstInstallment = new Label();
            grpPaymentProcessing = new GroupBox();
            txtAmountPaid = new TextBox();
            lblLabelAmount = new Label();
            cbPaymentMethod = new ComboBox();
            lblLabelMethod = new Label();
            btnProcess = new Button();
            btnCancel = new Button();
            pnlHeader.SuspendLayout();
            grpRentalSummary.SuspendLayout();
            grpInitialCosts.SuspendLayout();
            grpPaymentProcessing.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(52, 73, 94);
            pnlHeader.Controls.Add(lblHeader);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(549, 80);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(17, 20);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(228, 37);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Security Deposit";
            // 
            // grpRentalSummary
            // 
            grpRentalSummary.Controls.Add(lblReturnDate);
            grpRentalSummary.Controls.Add(lblRentalID);
            grpRentalSummary.Controls.Add(lblVehicleDetails);
            grpRentalSummary.Controls.Add(lblCustomerName);
            grpRentalSummary.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpRentalSummary.Location = new Point(23, 100);
            grpRentalSummary.Margin = new Padding(3, 4, 3, 4);
            grpRentalSummary.Name = "grpRentalSummary";
            grpRentalSummary.Padding = new Padding(3, 4, 3, 4);
            grpRentalSummary.Size = new Size(503, 153);
            grpRentalSummary.TabIndex = 1;
            grpRentalSummary.TabStop = false;
            grpRentalSummary.Text = "Rental Details";
            // 
            // lblReturnDate
            // 
            lblReturnDate.AutoSize = true;
            lblReturnDate.Font = new Font("Segoe UI", 9F);
            lblReturnDate.ForeColor = Color.DimGray;
            lblReturnDate.Location = new Point(17, 117);
            lblReturnDate.Name = "lblReturnDate";
            lblReturnDate.Size = new Size(107, 20);
            lblReturnDate.TabIndex = 0;
            lblReturnDate.Text = "Return Date: --";
            // 
            // lblRentalID
            // 
            lblRentalID.AutoSize = true;
            lblRentalID.Font = new Font("Segoe UI", 9F);
            lblRentalID.ForeColor = Color.DimGray;
            lblRentalID.Location = new Point(286, 33);
            lblRentalID.Name = "lblRentalID";
            lblRentalID.Size = new Size(89, 20);
            lblRentalID.TabIndex = 1;
            lblRentalID.Text = "Rental ID: --";
            // 
            // lblVehicleDetails
            // 
            lblVehicleDetails.AutoSize = true;
            lblVehicleDetails.Font = new Font("Segoe UI", 9F);
            lblVehicleDetails.Location = new Point(17, 80);
            lblVehicleDetails.Name = "lblVehicleDetails";
            lblVehicleDetails.Size = new Size(75, 20);
            lblVehicleDetails.TabIndex = 2;
            lblVehicleDetails.Text = "Vehicle: --";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblCustomerName.Location = new Point(17, 33);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(122, 25);
            lblCustomerName.TabIndex = 3;
            lblCustomerName.Text = "Customer: --";
            // 
            // grpInitialCosts
            // 
            grpInitialCosts.Controls.Add(lblTotalInitialPayment);
            grpInitialCosts.Controls.Add(lblFirstInstallment);
            grpInitialCosts.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpInitialCosts.Location = new Point(23, 267);
            grpInitialCosts.Margin = new Padding(3, 4, 3, 4);
            grpInitialCosts.Name = "grpInitialCosts";
            grpInitialCosts.Padding = new Padding(3, 4, 3, 4);
            grpInitialCosts.Size = new Size(503, 144);
            grpInitialCosts.TabIndex = 2;
            grpInitialCosts.TabStop = false;
            grpInitialCosts.Text = "Initial Payment Breakdown";
            // 
            // lblTotalInitialPayment
            // 
            lblTotalInitialPayment.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalInitialPayment.ForeColor = Color.FromArgb(46, 204, 113);
            lblTotalInitialPayment.Location = new Point(8, 82);
            lblTotalInitialPayment.Name = "lblTotalInitialPayment";
            lblTotalInitialPayment.Size = new Size(489, 53);
            lblTotalInitialPayment.TabIndex = 0;
            lblTotalInitialPayment.Text = "TOTAL DUE: ₱0.00";
            lblTotalInitialPayment.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblFirstInstallment
            // 
            lblFirstInstallment.AutoSize = true;
            lblFirstInstallment.Font = new Font("Segoe UI", 10F);
            lblFirstInstallment.Location = new Point(17, 40);
            lblFirstInstallment.Name = "lblFirstInstallment";
            lblFirstInstallment.Size = new Size(186, 23);
            lblFirstInstallment.TabIndex = 2;
            lblFirstInstallment.Text = "Initial Rental Fee: ₱0.00";
            // 
            // grpPaymentProcessing
            // 
            grpPaymentProcessing.BackColor = Color.WhiteSmoke;
            grpPaymentProcessing.Controls.Add(txtAmountPaid);
            grpPaymentProcessing.Controls.Add(lblLabelAmount);
            grpPaymentProcessing.Controls.Add(cbPaymentMethod);
            grpPaymentProcessing.Controls.Add(lblLabelMethod);
            grpPaymentProcessing.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpPaymentProcessing.Location = new Point(23, 429);
            grpPaymentProcessing.Margin = new Padding(3, 4, 3, 4);
            grpPaymentProcessing.Name = "grpPaymentProcessing";
            grpPaymentProcessing.Padding = new Padding(3, 4, 3, 4);
            grpPaymentProcessing.Size = new Size(503, 153);
            grpPaymentProcessing.TabIndex = 3;
            grpPaymentProcessing.TabStop = false;
            grpPaymentProcessing.Text = "Payment Processing";
            // 
            // txtAmountPaid
            // 
            txtAmountPaid.Font = new Font("Segoe UI", 11F);
            txtAmountPaid.Location = new Point(257, 80);
            txtAmountPaid.Margin = new Padding(3, 4, 3, 4);
            txtAmountPaid.Name = "txtAmountPaid";
            txtAmountPaid.Size = new Size(211, 32);
            txtAmountPaid.TabIndex = 0;
            txtAmountPaid.ReadOnly = true;
            txtAmountPaid.TabStop = false;
            txtAmountPaid.BackColor = SystemColors.Control;
            // 
            // lblLabelAmount
            // 
            lblLabelAmount.AutoSize = true;
            lblLabelAmount.Font = new Font("Segoe UI", 9F);
            lblLabelAmount.Location = new Point(253, 53);
            lblLabelAmount.Name = "lblLabelAmount";
            lblLabelAmount.Size = new Size(97, 20);
            lblLabelAmount.TabIndex = 1;
            lblLabelAmount.Text = "Amount Paid:";
            // 
            // cbPaymentMethod
            // 
            cbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPaymentMethod.Font = new Font("Segoe UI", 10F);
            cbPaymentMethod.Location = new Point(22, 80);
            cbPaymentMethod.Margin = new Padding(3, 4, 3, 4);
            cbPaymentMethod.Name = "cbPaymentMethod";
            cbPaymentMethod.Size = new Size(211, 31);
            cbPaymentMethod.TabIndex = 2;
            // 
            // lblLabelMethod
            // 
            lblLabelMethod.AutoSize = true;
            lblLabelMethod.Font = new Font("Segoe UI", 9F);
            lblLabelMethod.Location = new Point(17, 53);
            lblLabelMethod.Name = "lblLabelMethod";
            lblLabelMethod.Size = new Size(124, 20);
            lblLabelMethod.TabIndex = 3;
            lblLabelMethod.Text = "Payment Method:";
            // 
            // btnProcess
            // 
            btnProcess.BackColor = Color.FromArgb(46, 204, 113);
            btnProcess.FlatStyle = FlatStyle.Flat;
            btnProcess.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnProcess.ForeColor = Color.White;
            btnProcess.Location = new Point(274, 647);
            btnProcess.Margin = new Padding(3, 4, 3, 4);
            btnProcess.Name = "btnProcess";
            btnProcess.Size = new Size(251, 67);
            btnProcess.TabIndex = 1;
            btnProcess.Text = "Confirm Payment";
            btnProcess.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(189, 195, 199);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(44, 62, 80);
            btnCancel.Location = new Point(23, 647);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(229, 67);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // RentalDownPayment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(549, 740);
            Controls.Add(btnCancel);
            Controls.Add(btnProcess);
            Controls.Add(grpPaymentProcessing);
            Controls.Add(grpInitialCosts);
            Controls.Add(grpRentalSummary);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RentalDownPayment";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Upfront Rental Payment";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            grpRentalSummary.ResumeLayout(false);
            grpRentalSummary.PerformLayout();
            grpInitialCosts.ResumeLayout(false);
            grpInitialCosts.PerformLayout();
            grpPaymentProcessing.ResumeLayout(false);
            grpPaymentProcessing.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.GroupBox grpRentalSummary;
        private System.Windows.Forms.Label lblReturnDate;
        private System.Windows.Forms.Label lblRentalID;
        private System.Windows.Forms.Label lblVehicleDetails;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.GroupBox grpInitialCosts;
        private System.Windows.Forms.Label lblTotalInitialPayment;
        private System.Windows.Forms.Label lblFirstInstallment;
        private System.Windows.Forms.GroupBox grpPaymentProcessing;
        private System.Windows.Forms.TextBox txtAmountPaid;
        private System.Windows.Forms.Label lblLabelAmount;
        private System.Windows.Forms.ComboBox cbPaymentMethod;
        private System.Windows.Forms.Label lblLabelMethod;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnCancel;
    }
}