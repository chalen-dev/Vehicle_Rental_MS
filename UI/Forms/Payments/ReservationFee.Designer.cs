namespace VRMS.UI.Forms.Payments
{
    partial class ReservationFee
    {
        private System.ComponentModel.IContainer components = null;
        

        // Constructor
        

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblHeader = new Label();
            grpReservation = new GroupBox();
            lblCustomerInfo = new Label();
            lblVehicleInfo = new Label();
            lblReservationID = new Label();
            grpFeeSummary = new GroupBox();
            lblEstimatedTotal = new Label();
            lblReservationFee = new Label();
            lblFeeNote = new Label();
            grpPaymentInput = new GroupBox();
            lblMethod = new Label();
            cbPaymentMethod = new ComboBox();
            lblAmountPaid = new Label();
            txtAmountPaid = new TextBox();
            btnConfirm = new Button();
            btnCancel = new Button();
            pnlHeader.SuspendLayout();
            grpReservation.SuspendLayout();
            grpFeeSummary.SuspendLayout();
            grpPaymentInput.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(52, 73, 94);
            pnlHeader.Controls.Add(lblHeader);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(480, 60);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(15, 15);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(221, 37);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Reservation Fee";
            // 
            // grpReservation
            // 
            grpReservation.Controls.Add(lblCustomerInfo);
            grpReservation.Controls.Add(lblVehicleInfo);
            grpReservation.Controls.Add(lblReservationID);
            grpReservation.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpReservation.Location = new Point(20, 75);
            grpReservation.Name = "grpReservation";
            grpReservation.Size = new Size(440, 110);
            grpReservation.TabIndex = 1;
            grpReservation.TabStop = false;
            grpReservation.Text = "Reservation Details";
            // 
            // lblCustomerInfo
            // 
            lblCustomerInfo.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblCustomerInfo.Location = new Point(15, 25);
            lblCustomerInfo.Name = "lblCustomerInfo";
            lblCustomerInfo.Size = new Size(410, 23);
            lblCustomerInfo.TabIndex = 0;
            lblCustomerInfo.Text = "Customer: --";
            // 
            // lblVehicleInfo
            // 
            lblVehicleInfo.Location = new Point(15, 55);
            lblVehicleInfo.Name = "lblVehicleInfo";
            lblVehicleInfo.Size = new Size(410, 23);
            lblVehicleInfo.TabIndex = 1;
            lblVehicleInfo.Text = "Vehicle: --";
            // 
            // lblReservationID
            // 
            lblReservationID.ForeColor = Color.DimGray;
            lblReservationID.Location = new Point(15, 80);
            lblReservationID.Name = "lblReservationID";
            lblReservationID.Size = new Size(410, 23);
            lblReservationID.TabIndex = 2;
            lblReservationID.Text = "Reservation ID: --";
            // 
            // grpFeeSummary
            // 
            grpFeeSummary.Controls.Add(lblEstimatedTotal);
            grpFeeSummary.Controls.Add(lblReservationFee);
            grpFeeSummary.Controls.Add(lblFeeNote);
            grpFeeSummary.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpFeeSummary.Location = new Point(20, 195);
            grpFeeSummary.Name = "grpFeeSummary";
            grpFeeSummary.Size = new Size(440, 151);
            grpFeeSummary.TabIndex = 2;
            grpFeeSummary.TabStop = false;
            grpFeeSummary.Text = "Reservation Fee Summary";
            // 
            // lblEstimatedTotal
            // 
            lblEstimatedTotal.Location = new Point(15, 30);
            lblEstimatedTotal.Name = "lblEstimatedTotal";
            lblEstimatedTotal.Size = new Size(410, 23);
            lblEstimatedTotal.TabIndex = 0;
            lblEstimatedTotal.Text = "Estimated Rental Cost: ₱0.00";
            // 
            // lblReservationFee
            // 
            lblReservationFee.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblReservationFee.ForeColor = Color.FromArgb(241, 196, 15);
            lblReservationFee.Location = new Point(6, 60);
            lblReservationFee.Name = "lblReservationFee";
            lblReservationFee.Size = new Size(428, 40);
            lblReservationFee.TabIndex = 1;
            lblReservationFee.Text = "RESERVATION FEE: ₱0.00";
            lblReservationFee.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblFeeNote
            // 
            lblFeeNote.Font = new Font("Segoe UI", 8F);
            lblFeeNote.ForeColor = Color.Gray;
            lblFeeNote.Location = new Point(15, 105);
            lblFeeNote.Name = "lblFeeNote";
            lblFeeNote.Size = new Size(410, 20);
            lblFeeNote.TabIndex = 2;
            lblFeeNote.Text = "* Fee secures the vehicle and will be deducted from the final bill.";
            // 
            // grpPaymentInput
            // 
            grpPaymentInput.Controls.Add(lblMethod);
            grpPaymentInput.Controls.Add(cbPaymentMethod);
            grpPaymentInput.Controls.Add(lblAmountPaid);
            grpPaymentInput.Controls.Add(txtAmountPaid);
            grpPaymentInput.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpPaymentInput.Location = new Point(20, 352);
            grpPaymentInput.Name = "grpPaymentInput";
            grpPaymentInput.Size = new Size(440, 110);
            grpPaymentInput.TabIndex = 3;
            grpPaymentInput.TabStop = false;
            grpPaymentInput.Text = "Payment Method";
            // 
            // lblMethod
            // 
            lblMethod.Location = new Point(15, 29);
            lblMethod.Name = "lblMethod";
            lblMethod.Size = new Size(150, 23);
            lblMethod.TabIndex = 0;
            lblMethod.Text = "Method:";
            // 
            // cbPaymentMethod
            // 
            cbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPaymentMethod.Font = new Font("Segoe UI", 10F);
            cbPaymentMethod.Items.AddRange(new object[] { "Cash", "Credit Card", "Debit Card", "E-Wallet" });
            cbPaymentMethod.Location = new Point(19, 55);
            cbPaymentMethod.Name = "cbPaymentMethod";
            cbPaymentMethod.Size = new Size(185, 31);
            cbPaymentMethod.TabIndex = 1;
            // 
            // lblAmountPaid
            // 
            lblAmountPaid.Location = new Point(220, 26);
            lblAmountPaid.Name = "lblAmountPaid";
            lblAmountPaid.Size = new Size(190, 23);
            lblAmountPaid.TabIndex = 2;
            lblAmountPaid.Text = "Reservation Fee Paid:";
            // 
            // txtAmountPaid
            // 
            txtAmountPaid.Font = new Font("Segoe UI", 10F);
            txtAmountPaid.Location = new Point(225, 55);
            txtAmountPaid.Name = "txtAmountPaid";
            txtAmountPaid.Size = new Size(185, 30);
            txtAmountPaid.TabIndex = 3;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.FromArgb(46, 204, 113);
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.Location = new Point(240, 479);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(220, 50);
            btnConfirm.TabIndex = 4;
            btnConfirm.Text = "Confirm Reservation";
            btnConfirm.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(189, 195, 199);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.Location = new Point(20, 479);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(200, 50);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // ReservationFee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(480, 551);
            Controls.Add(pnlHeader);
            Controls.Add(grpReservation);
            Controls.Add(grpFeeSummary);
            Controls.Add(grpPaymentInput);
            Controls.Add(btnConfirm);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReservationFee";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Vehicle Reservation Fee";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            grpReservation.ResumeLayout(false);
            grpFeeSummary.ResumeLayout(false);
            grpPaymentInput.ResumeLayout(false);
            grpPaymentInput.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.GroupBox grpReservation;
        private System.Windows.Forms.Label lblReservationID;
        private System.Windows.Forms.Label lblVehicleInfo;
        private System.Windows.Forms.Label lblCustomerInfo;
        private System.Windows.Forms.GroupBox grpFeeSummary;
        private System.Windows.Forms.Label lblReservationFee;
        private System.Windows.Forms.Label lblEstimatedTotal;
        private System.Windows.Forms.Label lblFeeNote;
        private System.Windows.Forms.GroupBox grpPaymentInput;
        private System.Windows.Forms.TextBox txtAmountPaid;
        private System.Windows.Forms.Label lblAmountPaid;
        private System.Windows.Forms.ComboBox cbPaymentMethod;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
    }
}