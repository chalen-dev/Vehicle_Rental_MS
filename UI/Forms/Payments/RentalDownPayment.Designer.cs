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
            pnlHeader = new System.Windows.Forms.Panel();
            lblHeader = new System.Windows.Forms.Label();
            grpRentalSummary = new System.Windows.Forms.GroupBox();
            lblReturnDate = new System.Windows.Forms.Label();
            lblRentalID = new System.Windows.Forms.Label();
            lblVehicleDetails = new System.Windows.Forms.Label();
            lblCustomerName = new System.Windows.Forms.Label();
            grpInitialCosts = new System.Windows.Forms.GroupBox();
            lblTotalInitialPayment = new System.Windows.Forms.Label();
            lblSecurityDeposit = new System.Windows.Forms.Label();
            lblFirstInstallment = new System.Windows.Forms.Label();
            grpPaymentProcessing = new System.Windows.Forms.GroupBox();
            txtAmountPaid = new System.Windows.Forms.TextBox();
            lblLabelAmount = new System.Windows.Forms.Label();
            cbPaymentMethod = new System.Windows.Forms.ComboBox();
            lblLabelMethod = new System.Windows.Forms.Label();
            btnProcess = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            pnlHeader.SuspendLayout();
            grpRentalSummary.SuspendLayout();
            grpInitialCosts.SuspendLayout();
            grpPaymentProcessing.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)((byte)52)), ((int)((byte)73)), ((int)((byte)94)));
            pnlHeader.Controls.Add(lblHeader);
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new System.Drawing.Size(549, 80);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblHeader.ForeColor = System.Drawing.Color.White;
            lblHeader.Location = new System.Drawing.Point(17, 20);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new System.Drawing.Size(228, 37);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Security Deposit";
            // 
            // grpRentalSummary
            // 
            grpRentalSummary.Controls.Add(lblReturnDate);
            grpRentalSummary.Controls.Add(lblRentalID);
            grpRentalSummary.Controls.Add(lblVehicleDetails);
            grpRentalSummary.Controls.Add(lblCustomerName);
            grpRentalSummary.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            grpRentalSummary.Location = new System.Drawing.Point(23, 100);
            grpRentalSummary.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            grpRentalSummary.Name = "grpRentalSummary";
            grpRentalSummary.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            grpRentalSummary.Size = new System.Drawing.Size(503, 153);
            grpRentalSummary.TabIndex = 1;
            grpRentalSummary.TabStop = false;
            grpRentalSummary.Text = "Rental Details";
            // 
            // lblReturnDate
            // 
            lblReturnDate.AutoSize = true;
            lblReturnDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblReturnDate.ForeColor = System.Drawing.Color.DimGray;
            lblReturnDate.Location = new System.Drawing.Point(17, 117);
            lblReturnDate.Name = "lblReturnDate";
            lblReturnDate.Size = new System.Drawing.Size(107, 20);
            lblReturnDate.TabIndex = 0;
            lblReturnDate.Text = "Return Date: --";
            // 
            // lblRentalID
            // 
            lblRentalID.AutoSize = true;
            lblRentalID.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblRentalID.ForeColor = System.Drawing.Color.DimGray;
            lblRentalID.Location = new System.Drawing.Point(286, 33);
            lblRentalID.Name = "lblRentalID";
            lblRentalID.Size = new System.Drawing.Size(89, 20);
            lblRentalID.TabIndex = 1;
            lblRentalID.Text = "Rental ID: --";
            // 
            // lblVehicleDetails
            // 
            lblVehicleDetails.AutoSize = true;
            lblVehicleDetails.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblVehicleDetails.Location = new System.Drawing.Point(17, 80);
            lblVehicleDetails.Name = "lblVehicleDetails";
            lblVehicleDetails.Size = new System.Drawing.Size(75, 20);
            lblVehicleDetails.TabIndex = 2;
            lblVehicleDetails.Text = "Vehicle: --";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            lblCustomerName.Location = new System.Drawing.Point(17, 33);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new System.Drawing.Size(122, 25);
            lblCustomerName.TabIndex = 3;
            lblCustomerName.Text = "Customer: --";
            // 
            // grpInitialCosts
            // 
            grpInitialCosts.Controls.Add(lblTotalInitialPayment);
            grpInitialCosts.Controls.Add(lblSecurityDeposit);
            grpInitialCosts.Controls.Add(lblFirstInstallment);
            grpInitialCosts.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            grpInitialCosts.Location = new System.Drawing.Point(23, 267);
            grpInitialCosts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            grpInitialCosts.Name = "grpInitialCosts";
            grpInitialCosts.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            grpInitialCosts.Size = new System.Drawing.Size(503, 187);
            grpInitialCosts.TabIndex = 2;
            grpInitialCosts.TabStop = false;
            grpInitialCosts.Text = "Initial Payment Breakdown";
            // 
            // lblTotalInitialPayment
            // 
            lblTotalInitialPayment.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTotalInitialPayment.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)46)), ((int)((byte)204)), ((int)((byte)113)));
            lblTotalInitialPayment.Location = new System.Drawing.Point(7, 120);
            lblTotalInitialPayment.Name = "lblTotalInitialPayment";
            lblTotalInitialPayment.Size = new System.Drawing.Size(489, 53);
            lblTotalInitialPayment.TabIndex = 0;
            lblTotalInitialPayment.Text = "TOTAL DUE: ₱0.00";
            lblTotalInitialPayment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSecurityDeposit
            // 
            lblSecurityDeposit.AutoSize = true;
            lblSecurityDeposit.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblSecurityDeposit.Location = new System.Drawing.Point(17, 80);
            lblSecurityDeposit.Name = "lblSecurityDeposit";
            lblSecurityDeposit.Size = new System.Drawing.Size(183, 23);
            lblSecurityDeposit.TabIndex = 1;
            lblSecurityDeposit.Text = "Security Deposit: ₱0.00";
            // 
            // lblFirstInstallment
            // 
            lblFirstInstallment.AutoSize = true;
            lblFirstInstallment.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblFirstInstallment.Location = new System.Drawing.Point(17, 40);
            lblFirstInstallment.Name = "lblFirstInstallment";
            lblFirstInstallment.Size = new System.Drawing.Size(186, 23);
            lblFirstInstallment.TabIndex = 2;
            lblFirstInstallment.Text = "Initial Rental Fee: ₱0.00";
            // 
            // grpPaymentProcessing
            // 
            grpPaymentProcessing.BackColor = System.Drawing.Color.WhiteSmoke;
            grpPaymentProcessing.Controls.Add(txtAmountPaid);
            grpPaymentProcessing.Controls.Add(lblLabelAmount);
            grpPaymentProcessing.Controls.Add(cbPaymentMethod);
            grpPaymentProcessing.Controls.Add(lblLabelMethod);
            grpPaymentProcessing.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            grpPaymentProcessing.Location = new System.Drawing.Point(23, 473);
            grpPaymentProcessing.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            grpPaymentProcessing.Name = "grpPaymentProcessing";
            grpPaymentProcessing.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            grpPaymentProcessing.Size = new System.Drawing.Size(503, 153);
            grpPaymentProcessing.TabIndex = 3;
            grpPaymentProcessing.TabStop = false;
            grpPaymentProcessing.Text = "Payment Processing";
            // 
            // txtAmountPaid
            // 
            txtAmountPaid.Font = new System.Drawing.Font("Segoe UI", 11F);
            txtAmountPaid.Location = new System.Drawing.Point(257, 80);
            txtAmountPaid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtAmountPaid.Name = "txtAmountPaid";
            txtAmountPaid.Size = new System.Drawing.Size(211, 32);
            txtAmountPaid.TabIndex = 0;
            // 
            // lblLabelAmount
            // 
            lblLabelAmount.AutoSize = true;
            lblLabelAmount.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblLabelAmount.Location = new System.Drawing.Point(253, 53);
            lblLabelAmount.Name = "lblLabelAmount";
            lblLabelAmount.Size = new System.Drawing.Size(97, 20);
            lblLabelAmount.TabIndex = 1;
            lblLabelAmount.Text = "Amount Paid:";
            // 
            // cbPaymentMethod
            // 
            cbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 10F);
            cbPaymentMethod.Items.AddRange(new object[] { "Cash", "Credit Card", "Bank Transfer", "E-Wallet" });
            cbPaymentMethod.Location = new System.Drawing.Point(22, 80);
            cbPaymentMethod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            cbPaymentMethod.Name = "cbPaymentMethod";
            cbPaymentMethod.Size = new System.Drawing.Size(211, 31);
            cbPaymentMethod.TabIndex = 2;
            // 
            // lblLabelMethod
            // 
            lblLabelMethod.AutoSize = true;
            lblLabelMethod.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblLabelMethod.Location = new System.Drawing.Point(17, 53);
            lblLabelMethod.Name = "lblLabelMethod";
            lblLabelMethod.Size = new System.Drawing.Size(124, 20);
            lblLabelMethod.TabIndex = 3;
            lblLabelMethod.Text = "Payment Method:";
            // 
            // btnProcess
            // 
            btnProcess.BackColor = System.Drawing.Color.FromArgb(((int)((byte)46)), ((int)((byte)204)), ((int)((byte)113)));
            btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnProcess.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnProcess.ForeColor = System.Drawing.Color.White;
            btnProcess.Location = new System.Drawing.Point(274, 647);
            btnProcess.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnProcess.Name = "btnProcess";
            btnProcess.Size = new System.Drawing.Size(251, 67);
            btnProcess.TabIndex = 1;
            btnProcess.Text = "Confirm Payment";
            btnProcess.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)((byte)189)), ((int)((byte)195)), ((int)((byte)199)));
            btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)44)), ((int)((byte)62)), ((int)((byte)80)));
            btnCancel.Location = new System.Drawing.Point(23, 647);
            btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(229, 67);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // RentalDownPayment
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(549, 740);
            Controls.Add(btnCancel);
            Controls.Add(btnProcess);
            Controls.Add(grpPaymentProcessing);
            Controls.Add(grpInitialCosts);
            Controls.Add(grpRentalSummary);
            Controls.Add(pnlHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
        private System.Windows.Forms.Label lblSecurityDeposit;
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