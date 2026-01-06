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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.grpSummary = new System.Windows.Forms.GroupBox();
            this.lblRentalDuration = new System.Windows.Forms.Label();
            this.lblVehicleDetails = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.grpBreakdown = new System.Windows.Forms.GroupBox();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.lblFuelCharge = new System.Windows.Forms.Label();
            this.lblDamageFee = new System.Windows.Forms.Label();
            this.lblLateFee = new System.Windows.Forms.Label();
            this.lblBaseRental = new System.Windows.Forms.Label();
            this.grpPayment = new System.Windows.Forms.GroupBox();
            this.lblChange = new System.Windows.Forms.Label();
            this.txtAmountPaid = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.grpSummary.SuspendLayout();
            this.grpBreakdown.SuspendLayout();
            this.grpPayment.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(480, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(15, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(223, 37);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Billing & Payment";
            // 
            // grpSummary
            // 
            this.grpSummary.Controls.Add(this.lblRentalDuration);
            this.grpSummary.Controls.Add(this.lblVehicleDetails);
            this.grpSummary.Controls.Add(this.lblCustomerName);
            this.grpSummary.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpSummary.Location = new System.Drawing.Point(20, 75);
            this.grpSummary.Name = "grpSummary";
            this.grpSummary.Size = new System.Drawing.Size(440, 110);
            this.grpSummary.TabIndex = 1;
            this.grpSummary.TabStop = false;
            this.grpSummary.Text = "Rental Summary";
            // 
            // lblRentalDuration
            // 
            this.lblRentalDuration.AutoSize = true;
            this.lblRentalDuration.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRentalDuration.ForeColor = System.Drawing.Color.DimGray;
            this.lblRentalDuration.Location = new System.Drawing.Point(15, 80);
            this.lblRentalDuration.Name = "lblRentalDuration";
            this.lblRentalDuration.Size = new System.Drawing.Size(126, 20);
            this.lblRentalDuration.TabIndex = 2;
            this.lblRentalDuration.Text = "Duration: -- Days";
            // 
            // lblVehicleDetails
            // 
            this.lblVehicleDetails.AutoSize = true;
            this.lblVehicleDetails.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVehicleDetails.Location = new System.Drawing.Point(15, 55);
            this.lblVehicleDetails.Name = "lblVehicleDetails";
            this.lblVehicleDetails.Size = new System.Drawing.Size(73, 20);
            this.lblVehicleDetails.TabIndex = 1;
            this.lblVehicleDetails.Text = "Vehicle: --";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblCustomerName.Location = new System.Drawing.Point(15, 25);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(127, 25);
            this.lblCustomerName.TabIndex = 0;
            this.lblCustomerName.Text = "Customer: --";
            // 
            // grpBreakdown
            // 
            this.grpBreakdown.Controls.Add(this.lblGrandTotal);
            this.grpBreakdown.Controls.Add(this.lblFuelCharge);
            this.grpBreakdown.Controls.Add(this.lblDamageFee);
            this.grpBreakdown.Controls.Add(this.lblLateFee);
            this.grpBreakdown.Controls.Add(this.lblBaseRental);
            this.grpBreakdown.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpBreakdown.Location = new System.Drawing.Point(20, 195);
            this.grpBreakdown.Name = "grpBreakdown";
            this.grpBreakdown.Size = new System.Drawing.Size(440, 185);
            this.grpBreakdown.TabIndex = 2;
            this.grpBreakdown.TabStop = false;
            this.grpBreakdown.Text = "Billing Breakdown";
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblGrandTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblGrandTotal.Location = new System.Drawing.Point(6, 135);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(428, 40);
            this.lblGrandTotal.TabIndex = 4;
            this.lblGrandTotal.Text = "TOTAL DUE: ₱0.00";
            this.lblGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFuelCharge
            // 
            this.lblFuelCharge.AutoSize = true;
            this.lblFuelCharge.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFuelCharge.Location = new System.Drawing.Point(15, 110);
            this.lblFuelCharge.Name = "lblFuelCharge";
            this.lblFuelCharge.Size = new System.Drawing.Size(124, 23);
            this.lblFuelCharge.TabIndex = 3;
            this.lblFuelCharge.Text = "Fuel Surcharge:";
            // 
            // lblDamageFee
            // 
            this.lblDamageFee.AutoSize = true;
            this.lblDamageFee.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDamageFee.Location = new System.Drawing.Point(15, 85);
            this.lblDamageFee.Name = "lblDamageFee";
            this.lblDamageFee.Size = new System.Drawing.Size(117, 23);
            this.lblDamageFee.TabIndex = 2;
            this.lblDamageFee.Text = "Damage Fees:";
            // 
            // lblLateFee
            // 
            this.lblLateFee.AutoSize = true;
            this.lblLateFee.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLateFee.Location = new System.Drawing.Point(15, 60);
            this.lblLateFee.Name = "lblLateFee";
            this.lblLateFee.Size = new System.Drawing.Size(83, 23);
            this.lblLateFee.TabIndex = 1;
            this.lblLateFee.Text = "Late Fees:";
            // 
            // lblBaseRental
            // 
            this.lblBaseRental.AutoSize = true;
            this.lblBaseRental.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBaseRental.Location = new System.Drawing.Point(15, 35);
            this.lblBaseRental.Name = "lblBaseRental";
            this.lblBaseRental.Size = new System.Drawing.Size(126, 23);
            this.lblBaseRental.TabIndex = 0;
            this.lblBaseRental.Text = "Rental Charges:";
            // 
            // grpPayment
            // 
            this.grpPayment.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpPayment.Controls.Add(this.lblChange);
            this.grpPayment.Controls.Add(this.txtAmountPaid);
            this.grpPayment.Controls.Add(this.label9);
            this.grpPayment.Controls.Add(this.cbPaymentMethod);
            this.grpPayment.Controls.Add(this.label8);
            this.grpPayment.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpPayment.Location = new System.Drawing.Point(20, 395);
            this.grpPayment.Name = "grpPayment";
            this.grpPayment.Size = new System.Drawing.Size(440, 140);
            this.grpPayment.TabIndex = 3;
            this.grpPayment.TabStop = false;
            this.grpPayment.Text = "Payment Processing";
            // 
            // lblChange
            // 
            this.lblChange.AutoSize = true;
            this.lblChange.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblChange.Location = new System.Drawing.Point(220, 93);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(121, 28);
            this.lblChange.TabIndex = 4;
            this.lblChange.Text = "Change: ₱ --";
            // 
            // txtAmountPaid
            // 
            this.txtAmountPaid.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtAmountPaid.Location = new System.Drawing.Point(225, 55);
            this.txtAmountPaid.Name = "txtAmountPaid";
            this.txtAmountPaid.Size = new System.Drawing.Size(185, 32);
            this.txtAmountPaid.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label9.Location = new System.Drawing.Point(221, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "Amount Paid:";
            // 
            // cbPaymentMethod
            // 
            this.cbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbPaymentMethod.FormattingEnabled = true;
            this.cbPaymentMethod.Items.AddRange(new object[] { "Cash", "Credit Card", "Debit Card", "E-Wallet" });
            this.cbPaymentMethod.Location = new System.Drawing.Point(19, 55);
            this.cbPaymentMethod.Name = "cbPaymentMethod";
            this.cbPaymentMethod.Size = new System.Drawing.Size(185, 31);
            this.cbPaymentMethod.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label8.Location = new System.Drawing.Point(15, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Payment Method:";
            // 
            // btnProcess
            // 
            this.btnProcess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnProcess.FlatAppearance.BorderSize = 0;
            this.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcess.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnProcess.ForeColor = System.Drawing.Color.White;
            this.btnProcess.Location = new System.Drawing.Point(240, 550);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(220, 50);
            this.btnProcess.TabIndex = 4;
            this.btnProcess.Text = "Complete Payment";
            this.btnProcess.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnCancel.Location = new System.Drawing.Point(20, 550);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(200, 50);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(480, 620);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.grpPayment);
            this.Controls.Add(this.grpBreakdown);
            this.Controls.Add(this.grpSummary);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Invoice & Payment";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpSummary.ResumeLayout(false);
            this.grpSummary.PerformLayout();
            this.grpBreakdown.ResumeLayout(false);
            this.grpBreakdown.PerformLayout();
            this.grpPayment.ResumeLayout(false);
            this.grpPayment.PerformLayout();
            this.ResumeLayout(false);

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