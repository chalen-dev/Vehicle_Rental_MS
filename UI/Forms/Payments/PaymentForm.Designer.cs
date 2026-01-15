namespace VRMS.Forms
{
    partial class PaymentForm
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

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblHeader = new Label();
            grpSummary = new GroupBox();
            lblRentalDuration = new Label();
            lblVehicleDetails = new Label();
            lblCustomerName = new Label();
            grpBreakdown = new GroupBox();
            lblGrandTotal = new Label();
            lblFuelCharge = new Label();
            lblDamageFee = new Label();
            lblLateFee = new Label();
            lblBaseRental = new Label();
            grpPayment = new GroupBox();
            lblChange = new Label();
            txtAmountPaid = new TextBox();
            label9 = new Label();
            cbPaymentMethod = new ComboBox();
            label8 = new Label();
            btnProcess = new Button();
            btnCancel = new Button();
            pnlHeader.SuspendLayout();
            grpSummary.SuspendLayout();
            grpBreakdown.SuspendLayout();
            grpPayment.SuspendLayout();
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
            pnlHeader.Size = new Size(480, 75);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(15, 19);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(226, 37);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Billing & Payment";
            // 
            // grpSummary
            // 
            grpSummary.Controls.Add(lblRentalDuration);
            grpSummary.Controls.Add(lblVehicleDetails);
            grpSummary.Controls.Add(lblCustomerName);
            grpSummary.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpSummary.Location = new Point(20, 94);
            grpSummary.Margin = new Padding(3, 4, 3, 4);
            grpSummary.Name = "grpSummary";
            grpSummary.Padding = new Padding(3, 4, 3, 4);
            grpSummary.Size = new Size(440, 138);
            grpSummary.TabIndex = 1;
            grpSummary.TabStop = false;
            grpSummary.Text = "Rental Summary";
            // 
            // lblRentalDuration
            // 
            lblRentalDuration.AutoSize = true;
            lblRentalDuration.Font = new Font("Segoe UI", 9F);
            lblRentalDuration.ForeColor = Color.DimGray;
            lblRentalDuration.Location = new Point(15, 100);
            lblRentalDuration.Name = "lblRentalDuration";
            lblRentalDuration.Size = new Size(122, 20);
            lblRentalDuration.TabIndex = 2;
            lblRentalDuration.Text = "Duration: -- Days";
            // 
            // lblVehicleDetails
            // 
            lblVehicleDetails.AutoSize = true;
            lblVehicleDetails.Font = new Font("Segoe UI", 9F);
            lblVehicleDetails.Location = new Point(15, 69);
            lblVehicleDetails.Name = "lblVehicleDetails";
            lblVehicleDetails.Size = new Size(75, 20);
            lblVehicleDetails.TabIndex = 1;
            lblVehicleDetails.Text = "Vehicle: --";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblCustomerName.Location = new Point(15, 31);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(122, 25);
            lblCustomerName.TabIndex = 0;
            lblCustomerName.Text = "Customer: --";
            // 
            // grpBreakdown
            // 
            grpBreakdown.Controls.Add(lblGrandTotal);
            grpBreakdown.Controls.Add(lblFuelCharge);
            grpBreakdown.Controls.Add(lblDamageFee);
            grpBreakdown.Controls.Add(lblLateFee);
            grpBreakdown.Controls.Add(lblBaseRental);
            grpBreakdown.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpBreakdown.Location = new Point(20, 244);
            grpBreakdown.Margin = new Padding(3, 4, 3, 4);
            grpBreakdown.Name = "grpBreakdown";
            grpBreakdown.Padding = new Padding(3, 4, 3, 4);
            grpBreakdown.Size = new Size(440, 231);
            grpBreakdown.TabIndex = 2;
            grpBreakdown.TabStop = false;
            grpBreakdown.Text = "Billing Breakdown";
            // 
            // lblGrandTotal
            // 
            lblGrandTotal.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblGrandTotal.ForeColor = Color.FromArgb(46, 204, 113);
            lblGrandTotal.Location = new Point(6, 169);
            lblGrandTotal.Name = "lblGrandTotal";
            lblGrandTotal.Size = new Size(428, 50);
            lblGrandTotal.TabIndex = 4;
            lblGrandTotal.Text = "TOTAL DUE: ₱0.00";
            lblGrandTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblFuelCharge
            // 
            lblFuelCharge.AutoSize = true;
            lblFuelCharge.Font = new Font("Segoe UI", 10F);
            lblFuelCharge.Location = new Point(15, 138);
            lblFuelCharge.Name = "lblFuelCharge";
            lblFuelCharge.Size = new Size(181, 23);
            lblFuelCharge.TabIndex = 3;
            lblFuelCharge.Text = "Mileage Overage Fees:";
            // 
            // lblDamageFee
            // 
            lblDamageFee.AutoSize = true;
            lblDamageFee.Font = new Font("Segoe UI", 10F);
            lblDamageFee.Location = new Point(15, 106);
            lblDamageFee.Name = "lblDamageFee";
            lblDamageFee.Size = new Size(116, 23);
            lblDamageFee.TabIndex = 2;
            lblDamageFee.Text = "Damage Fees:";
            // 
            // lblLateFee
            // 
            lblLateFee.AutoSize = true;
            lblLateFee.Font = new Font("Segoe UI", 10F);
            lblLateFee.Location = new Point(15, 75);
            lblLateFee.Name = "lblLateFee";
            lblLateFee.Size = new Size(84, 23);
            lblLateFee.TabIndex = 1;
            lblLateFee.Text = "Late Fees:";
            // 
            // lblBaseRental
            // 
            lblBaseRental.AutoSize = true;
            lblBaseRental.Font = new Font("Segoe UI", 10F);
            lblBaseRental.Location = new Point(15, 44);
            lblBaseRental.Name = "lblBaseRental";
            lblBaseRental.Size = new Size(129, 23);
            lblBaseRental.TabIndex = 0;
            lblBaseRental.Text = "Rental Charges:";
            // 
            // grpPayment
            // 
            grpPayment.BackColor = Color.WhiteSmoke;
            grpPayment.Controls.Add(lblChange);
            grpPayment.Controls.Add(txtAmountPaid);
            grpPayment.Controls.Add(label9);
            grpPayment.Controls.Add(cbPaymentMethod);
            grpPayment.Controls.Add(label8);
            grpPayment.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpPayment.Location = new Point(20, 494);
            grpPayment.Margin = new Padding(3, 4, 3, 4);
            grpPayment.Name = "grpPayment";
            grpPayment.Padding = new Padding(3, 4, 3, 4);
            grpPayment.Size = new Size(440, 175);
            grpPayment.TabIndex = 3;
            grpPayment.TabStop = false;
            grpPayment.Text = "Payment Processing";
            // 
            // lblChange
            // 
            lblChange.AutoSize = true;
            lblChange.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblChange.ForeColor = Color.FromArgb(41, 128, 185);
            lblChange.Location = new Point(220, 116);
            lblChange.Name = "lblChange";
            lblChange.Size = new Size(126, 28);
            lblChange.TabIndex = 4;
            lblChange.Text = "Change: ₱ --";
            // 
            // txtAmountPaid
            // 
            txtAmountPaid.Font = new Font("Segoe UI", 11F);
            txtAmountPaid.Location = new Point(225, 69);
            txtAmountPaid.Margin = new Padding(3, 4, 3, 4);
            txtAmountPaid.Name = "txtAmountPaid";
            txtAmountPaid.Size = new Size(185, 32);
            txtAmountPaid.TabIndex = 3;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F);
            label9.Location = new Point(221, 44);
            label9.Name = "label9";
            label9.Size = new Size(97, 20);
            label9.TabIndex = 2;
            label9.Text = "Amount Paid:";
            // 
            // cbPaymentMethod
            // 
            cbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPaymentMethod.Font = new Font("Segoe UI", 10F);
            cbPaymentMethod.FormattingEnabled = true;
            cbPaymentMethod.Items.AddRange(new object[] { "Cash", "Credit Card", "Debit Card", "E-Wallet" });
            cbPaymentMethod.Location = new Point(19, 69);
            cbPaymentMethod.Margin = new Padding(3, 4, 3, 4);
            cbPaymentMethod.Name = "cbPaymentMethod";
            cbPaymentMethod.Size = new Size(185, 31);
            cbPaymentMethod.TabIndex = 1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F);
            label8.Location = new Point(15, 44);
            label8.Name = "label8";
            label8.Size = new Size(124, 20);
            label8.TabIndex = 0;
            label8.Text = "Payment Method:";
            // 
            // btnProcess
            // 
            btnProcess.BackColor = Color.FromArgb(46, 204, 113);
            btnProcess.FlatAppearance.BorderSize = 0;
            btnProcess.FlatStyle = FlatStyle.Flat;
            btnProcess.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnProcess.ForeColor = Color.White;
            btnProcess.Location = new Point(240, 688);
            btnProcess.Margin = new Padding(3, 4, 3, 4);
            btnProcess.Name = "btnProcess";
            btnProcess.Size = new Size(220, 62);
            btnProcess.TabIndex = 4;
            btnProcess.Text = "Complete Payment";
            btnProcess.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(189, 195, 199);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(44, 62, 80);
            btnCancel.Location = new Point(20, 688);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(200, 62);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // PaymentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(480, 775);
            Controls.Add(btnCancel);
            Controls.Add(btnProcess);
            Controls.Add(grpPayment);
            Controls.Add(grpBreakdown);
            Controls.Add(grpSummary);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PaymentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Invoice & Payment";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            grpSummary.ResumeLayout(false);
            grpSummary.PerformLayout();
            grpBreakdown.ResumeLayout(false);
            grpBreakdown.PerformLayout();
            grpPayment.ResumeLayout(false);
            grpPayment.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.GroupBox grpSummary;
        private System.Windows.Forms.Label lblRentalDuration;
        private System.Windows.Forms.Label lblVehicleDetails;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.GroupBox grpBreakdown;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.Label lblFuelCharge;
        private System.Windows.Forms.Label lblDamageFee;
        private System.Windows.Forms.Label lblLateFee;
        private System.Windows.Forms.Label lblBaseRental;
        private System.Windows.Forms.GroupBox grpPayment;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.TextBox txtAmountPaid;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbPaymentMethod;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnCancel;
    }
}