namespace VRMS.UI.Forms.Rentals
{
    partial class CompleteRentalForm
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
            lblFormTitle = new Label();
            pnlRentalSummary = new Panel();
            lblVehicleInfo = new Label();
            lblCustomerInfo = new Label();
            lblRentalId = new Label();
            pnlReturnDetails = new Panel();
            lblSectionTitleReturn = new Label();
            lblReturnDate = new Label();
            dtReturns = new DateTimePicker();
            lblOdometer = new Label();
            numOdometer = new NumericUpDown();
            lblFuelLevel = new Label();
            cbFuels = new ComboBox();
            lblConditionNotes = new Label();
            txtConditions = new TextBox();
            pnlDamageAssessment = new Panel();
            btnInspectionChecklist = new Button();
            lblSectionTitleDamage = new Label();
            btnAddDamage = new Button();
            dgvDamages = new DataGridView();
            pnlBillingSummary = new Panel();
            lblSectionTitleBilling = new Label();
            lblTotalValue = new Label();
            lblTotalLabel = new Label();
            lblDamageFeesValue = new Label();
            lblDamageFees = new Label();
            lblLateFeesValue = new Label();
            lblLateFees = new Label();
            lblSubtotal = new Label();
            lblSubtotalValue = new Label();
            lblBaseRental = new Label();
            lblBaseRentalValue = new Label();
            pnlActionBar = new Panel();
            btnCompleteReturn = new Button();
            btnCancels = new Button();
            pnlHeader.SuspendLayout();
            pnlRentalSummary.SuspendLayout();
            pnlReturnDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numOdometer).BeginInit();
            pnlDamageAssessment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDamages).BeginInit();
            pnlBillingSummary.SuspendLayout();
            pnlActionBar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lblFormTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(30, 25, 30, 25);
            pnlHeader.Size = new Size(1300, 100);
            pnlHeader.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblFormTitle.Location = new Point(25, 25);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(221, 41);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "Vehicle Return";
            // 
            // pnlRentalSummary
            // 
            pnlRentalSummary.BackColor = Color.FromArgb(236, 240, 241);
            pnlRentalSummary.BorderStyle = BorderStyle.FixedSingle;
            pnlRentalSummary.Controls.Add(lblVehicleInfo);
            pnlRentalSummary.Controls.Add(lblCustomerInfo);
            pnlRentalSummary.Controls.Add(lblRentalId);
            pnlRentalSummary.Location = new Point(30, 125);
            pnlRentalSummary.Name = "pnlRentalSummary";
            pnlRentalSummary.Size = new Size(600, 124);
            pnlRentalSummary.TabIndex = 1;
            // 
            // lblVehicleInfo
            // 
            lblVehicleInfo.AutoSize = true;
            lblVehicleInfo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblVehicleInfo.ForeColor = Color.FromArgb(41, 128, 185);
            lblVehicleInfo.Location = new Point(20, 19);
            lblVehicleInfo.Name = "lblVehicleInfo";
            lblVehicleInfo.Size = new Size(0, 23);
            lblVehicleInfo.TabIndex = 0;
            // 
            // lblCustomerInfo
            // 
            lblCustomerInfo.AutoSize = true;
            lblCustomerInfo.Font = new Font("Segoe UI", 10F);
            lblCustomerInfo.Location = new Point(20, 56);
            lblCustomerInfo.Name = "lblCustomerInfo";
            lblCustomerInfo.Size = new Size(0, 23);
            lblCustomerInfo.TabIndex = 1;
            // 
            // lblRentalId
            // 
            lblRentalId.AutoSize = true;
            lblRentalId.Font = new Font("Segoe UI", 9F);
            lblRentalId.ForeColor = Color.Gray;
            lblRentalId.Location = new Point(20, 94);
            lblRentalId.Name = "lblRentalId";
            lblRentalId.Size = new Size(0, 20);
            lblRentalId.TabIndex = 2;
            // 
            // pnlReturnDetails
            // 
            pnlReturnDetails.BackColor = Color.White;
            pnlReturnDetails.BorderStyle = BorderStyle.FixedSingle;
            pnlReturnDetails.Controls.Add(lblSectionTitleReturn);
            pnlReturnDetails.Controls.Add(lblReturnDate);
            pnlReturnDetails.Controls.Add(dtReturns);
            pnlReturnDetails.Controls.Add(lblOdometer);
            pnlReturnDetails.Controls.Add(numOdometer);
            pnlReturnDetails.Controls.Add(lblFuelLevel);
            pnlReturnDetails.Controls.Add(cbFuels);
            pnlReturnDetails.Controls.Add(lblConditionNotes);
            pnlReturnDetails.Controls.Add(txtConditions);
            pnlReturnDetails.Location = new Point(30, 275);
            pnlReturnDetails.Name = "pnlReturnDetails";
            pnlReturnDetails.Size = new Size(600, 500);
            pnlReturnDetails.TabIndex = 2;
            // 
            // lblSectionTitleReturn
            // 
            lblSectionTitleReturn.AutoSize = true;
            lblSectionTitleReturn.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblSectionTitleReturn.Location = new Point(15, 19);
            lblSectionTitleReturn.Name = "lblSectionTitleReturn";
            lblSectionTitleReturn.Size = new Size(133, 25);
            lblSectionTitleReturn.TabIndex = 0;
            lblSectionTitleReturn.Text = "Return Details";
            // 
            // lblReturnDate
            // 
            lblReturnDate.AutoSize = true;
            lblReturnDate.Font = new Font("Segoe UI", 9F);
            lblReturnDate.ForeColor = Color.DimGray;
            lblReturnDate.Location = new Point(17, 60);
            lblReturnDate.Name = "lblReturnDate";
            lblReturnDate.Size = new Size(91, 20);
            lblReturnDate.TabIndex = 1;
            lblReturnDate.Text = "Return Date:";
            // 
            // dtReturns
            // 
            dtReturns.Font = new Font("Segoe UI", 10F);
            dtReturns.Location = new Point(20, 85);
            dtReturns.Name = "dtReturns";
            dtReturns.Size = new Size(560, 30);
            dtReturns.TabIndex = 2;
            // 
            // lblOdometer
            // 
            lblOdometer.AutoSize = true;
            lblOdometer.Font = new Font("Segoe UI", 9F);
            lblOdometer.ForeColor = Color.DimGray;
            lblOdometer.Location = new Point(17, 140);
            lblOdometer.Name = "lblOdometer";
            lblOdometer.Size = new Size(174, 20);
            lblOdometer.TabIndex = 3;
            lblOdometer.Text = "Final Odometer Reading:";
            // 
            // numOdometer
            // 
            numOdometer.Font = new Font("Segoe UI", 10F);
            numOdometer.Location = new Point(20, 165);
            numOdometer.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numOdometer.Name = "numOdometer";
            numOdometer.Size = new Size(250, 30);
            numOdometer.TabIndex = 4;
            numOdometer.TextAlign = HorizontalAlignment.Right;
            numOdometer.ThousandsSeparator = true;
            // 
            // lblFuelLevel
            // 
            lblFuelLevel.AutoSize = true;
            lblFuelLevel.Font = new Font("Segoe UI", 9F);
            lblFuelLevel.ForeColor = Color.DimGray;
            lblFuelLevel.Location = new Point(17, 220);
            lblFuelLevel.Name = "lblFuelLevel";
            lblFuelLevel.Size = new Size(77, 20);
            lblFuelLevel.TabIndex = 5;
            lblFuelLevel.Text = "Fuel Level:";
            // 
            // cbFuels
            // 
            cbFuels.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFuels.Font = new Font("Segoe UI", 10F);
            cbFuels.Items.AddRange(new object[] { "Empty", "1/4", "1/2", "3/4", "Full" });
            cbFuels.Location = new Point(20, 245);
            cbFuels.Name = "cbFuels";
            cbFuels.Size = new Size(250, 31);
            cbFuels.TabIndex = 6;
            // 
            // lblConditionNotes
            // 
            lblConditionNotes.AutoSize = true;
            lblConditionNotes.Font = new Font("Segoe UI", 9F);
            lblConditionNotes.ForeColor = Color.DimGray;
            lblConditionNotes.Location = new Point(17, 302);
            lblConditionNotes.Name = "lblConditionNotes";
            lblConditionNotes.Size = new Size(165, 20);
            lblConditionNotes.TabIndex = 7;
            lblConditionNotes.Text = "Final Condition / Notes:";
            // 
            // txtConditions
            // 
            txtConditions.Font = new Font("Segoe UI", 10F);
            txtConditions.Location = new Point(20, 328);
            txtConditions.Multiline = true;
            txtConditions.Name = "txtConditions";
            txtConditions.Size = new Size(560, 146);
            txtConditions.TabIndex = 8;
            // 
            // pnlDamageAssessment
            // 
            pnlDamageAssessment.BackColor = Color.White;
            pnlDamageAssessment.BorderStyle = BorderStyle.FixedSingle;
            pnlDamageAssessment.Controls.Add(btnInspectionChecklist);
            pnlDamageAssessment.Controls.Add(lblSectionTitleDamage);
            pnlDamageAssessment.Controls.Add(btnAddDamage);
            pnlDamageAssessment.Controls.Add(dgvDamages);
            pnlDamageAssessment.Location = new Point(655, 125);
            pnlDamageAssessment.Name = "pnlDamageAssessment";
            pnlDamageAssessment.Size = new Size(615, 350);
            pnlDamageAssessment.TabIndex = 3;
            // 
            // btnInspectionChecklist
            // 
            btnInspectionChecklist.BackColor = Color.FromArgb(155, 89, 182);
            btnInspectionChecklist.FlatStyle = FlatStyle.Flat;
            btnInspectionChecklist.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnInspectionChecklist.ForeColor = Color.White;
            btnInspectionChecklist.ImageAlign = ContentAlignment.MiddleLeft;
            btnInspectionChecklist.Location = new Point(380, 15);
            btnInspectionChecklist.Name = "btnInspectionChecklist";
            btnInspectionChecklist.Size = new Size(220, 35);
            btnInspectionChecklist.TabIndex = 3;
            btnInspectionChecklist.Text = "Inspection Checklist";
            btnInspectionChecklist.UseVisualStyleBackColor = false;
            btnInspectionChecklist.Click += BtnInspectionChecklist_Click;
            // 
            // lblSectionTitleDamage
            // 
            lblSectionTitleDamage.AutoSize = true;
            lblSectionTitleDamage.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblSectionTitleDamage.Location = new Point(15, 19);
            lblSectionTitleDamage.Name = "lblSectionTitleDamage";
            lblSectionTitleDamage.Size = new Size(189, 25);
            lblSectionTitleDamage.TabIndex = 0;
            lblSectionTitleDamage.Text = "Damage Assessment";
            // 
            // btnAddDamage
            // 
            btnAddDamage.BackColor = Color.FromArgb(39, 174, 96);
            btnAddDamage.FlatStyle = FlatStyle.Flat;
            btnAddDamage.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddDamage.ForeColor = Color.White;
            btnAddDamage.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddDamage.Location = new Point(20, 305);
            btnAddDamage.Name = "btnAddDamage";
            btnAddDamage.Size = new Size(580, 35);
            btnAddDamage.TabIndex = 1;
            btnAddDamage.Text = "Add Damage Record";
            btnAddDamage.UseVisualStyleBackColor = false;
            btnAddDamage.Click += BtnAddDamage_Click;
            // 
            // dgvDamages
            // 
            dgvDamages.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDamages.ColumnHeadersHeight = 29;
            dgvDamages.Location = new Point(20, 50);
            dgvDamages.Name = "dgvDamages";
            dgvDamages.ReadOnly = true;
            dgvDamages.RowHeadersWidth = 51;
            dgvDamages.Size = new Size(580, 240);
            dgvDamages.TabIndex = 2;
            // 
            // pnlBillingSummary
            // 
            pnlBillingSummary.BackColor = Color.White;
            pnlBillingSummary.BorderStyle = BorderStyle.FixedSingle;
            pnlBillingSummary.Controls.Add(lblSectionTitleBilling);
            pnlBillingSummary.Controls.Add(lblTotalValue);
            pnlBillingSummary.Controls.Add(lblTotalLabel);
            pnlBillingSummary.Controls.Add(lblDamageFeesValue);
            pnlBillingSummary.Controls.Add(lblDamageFees);
            pnlBillingSummary.Controls.Add(lblLateFeesValue);
            pnlBillingSummary.Controls.Add(lblLateFees);
            pnlBillingSummary.Controls.Add(lblSubtotal);
            pnlBillingSummary.Controls.Add(lblSubtotalValue);
            pnlBillingSummary.Controls.Add(lblBaseRental);
            pnlBillingSummary.Controls.Add(lblBaseRentalValue);
            pnlBillingSummary.Location = new Point(655, 495);
            pnlBillingSummary.Name = "pnlBillingSummary";
            pnlBillingSummary.Size = new Size(615, 280);
            pnlBillingSummary.TabIndex = 4;
            // 
            // lblSectionTitleBilling
            // 
            lblSectionTitleBilling.AutoSize = true;
            lblSectionTitleBilling.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblSectionTitleBilling.Location = new Point(15, 19);
            lblSectionTitleBilling.Name = "lblSectionTitleBilling";
            lblSectionTitleBilling.Size = new Size(153, 25);
            lblSectionTitleBilling.TabIndex = 0;
            lblSectionTitleBilling.Text = "Billing Summary";
            // 
            // lblTotalValue
            // 
            lblTotalValue.AutoSize = true;
            lblTotalValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalValue.ForeColor = Color.FromArgb(41, 128, 185);
            lblTotalValue.Location = new Point(420, 225);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(89, 37);
            lblTotalValue.TabIndex = 1;
            lblTotalValue.Text = "₱0.00";
            // 
            // lblTotalLabel
            // 
            lblTotalLabel.AutoSize = true;
            lblTotalLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTotalLabel.ForeColor = Color.FromArgb(44, 62, 80);
            lblTotalLabel.Location = new Point(20, 230);
            lblTotalLabel.Name = "lblTotalLabel";
            lblTotalLabel.Size = new Size(139, 28);
            lblTotalLabel.TabIndex = 2;
            lblTotalLabel.Text = "Total Charges:";
            // 
            // lblDamageFeesValue
            // 
            lblDamageFeesValue.AutoSize = true;
            lblDamageFeesValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDamageFeesValue.ForeColor = Color.FromArgb(231, 76, 60);
            lblDamageFeesValue.Location = new Point(420, 160);
            lblDamageFeesValue.Name = "lblDamageFeesValue";
            lblDamageFeesValue.Size = new Size(62, 25);
            lblDamageFeesValue.TabIndex = 3;
            lblDamageFeesValue.Text = "₱0.00";
            // 
            // lblDamageFees
            // 
            lblDamageFees.AutoSize = true;
            lblDamageFees.Font = new Font("Segoe UI", 10F);
            lblDamageFees.ForeColor = Color.DimGray;
            lblDamageFees.Location = new Point(20, 163);
            lblDamageFees.Name = "lblDamageFees";
            lblDamageFees.Size = new Size(116, 23);
            lblDamageFees.TabIndex = 4;
            lblDamageFees.Text = "Damage Fees:";
            // 
            // lblLateFeesValue
            // 
            lblLateFeesValue.AutoSize = true;
            lblLateFeesValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLateFeesValue.ForeColor = Color.FromArgb(243, 156, 18);
            lblLateFeesValue.Location = new Point(420, 120);
            lblLateFeesValue.Name = "lblLateFeesValue";
            lblLateFeesValue.Size = new Size(62, 25);
            lblLateFeesValue.TabIndex = 5;
            lblLateFeesValue.Text = "₱0.00";
            // 
            // lblLateFees
            // 
            lblLateFees.AutoSize = true;
            lblLateFees.Font = new Font("Segoe UI", 10F);
            lblLateFees.ForeColor = Color.DimGray;
            lblLateFees.Location = new Point(20, 123);
            lblLateFees.Name = "lblLateFees";
            lblLateFees.Size = new Size(84, 23);
            lblLateFees.TabIndex = 6;
            lblLateFees.Text = "Late Fees:";
            // 
            // lblSubtotal
            // 
            lblSubtotal.Location = new Point(0, 0);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(100, 23);
            lblSubtotal.TabIndex = 7;
            // 
            // lblSubtotalValue
            // 
            lblSubtotalValue.Location = new Point(0, 0);
            lblSubtotalValue.Name = "lblSubtotalValue";
            lblSubtotalValue.Size = new Size(100, 23);
            lblSubtotalValue.TabIndex = 8;
            // 
            // lblBaseRental
            // 
            lblBaseRental.Location = new Point(0, 0);
            lblBaseRental.Name = "lblBaseRental";
            lblBaseRental.Size = new Size(100, 23);
            lblBaseRental.TabIndex = 9;
            // 
            // lblBaseRentalValue
            // 
            lblBaseRentalValue.Location = new Point(0, 0);
            lblBaseRentalValue.Name = "lblBaseRentalValue";
            lblBaseRentalValue.Size = new Size(100, 23);
            lblBaseRentalValue.TabIndex = 10;
            // 
            // pnlActionBar
            // 
            pnlActionBar.BackColor = Color.White;
            pnlActionBar.Controls.Add(btnCompleteReturn);
            pnlActionBar.Controls.Add(btnCancels);
            pnlActionBar.Dock = DockStyle.Bottom;
            pnlActionBar.Location = new Point(0, 788);
            pnlActionBar.Name = "pnlActionBar";
            pnlActionBar.Padding = new Padding(20, 25, 20, 25);
            pnlActionBar.Size = new Size(1300, 101);
            pnlActionBar.TabIndex = 5;
            // 
            // btnCompleteReturn
            // 
            btnCompleteReturn.BackColor = Color.FromArgb(41, 128, 185);
            btnCompleteReturn.Dock = DockStyle.Right;
            btnCompleteReturn.FlatStyle = FlatStyle.Flat;
            btnCompleteReturn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCompleteReturn.ForeColor = Color.White;
            btnCompleteReturn.Location = new Point(830, 25);
            btnCompleteReturn.Name = "btnCompleteReturn";
            btnCompleteReturn.Size = new Size(450, 51);
            btnCompleteReturn.TabIndex = 0;
            btnCompleteReturn.Text = "Complete Return Process";
            btnCompleteReturn.UseVisualStyleBackColor = false;
            btnCompleteReturn.Click += btnCompleteReturn_Click;
            // 
            // btnCancels
            // 
            btnCancels.BackColor = Color.FromArgb(189, 195, 199);
            btnCancels.Dock = DockStyle.Left;
            btnCancels.FlatStyle = FlatStyle.Flat;
            btnCancels.Font = new Font("Segoe UI", 11F);
            btnCancels.ForeColor = Color.White;
            btnCancels.Location = new Point(20, 25);
            btnCancels.Name = "btnCancels";
            btnCancels.Size = new Size(450, 51);
            btnCancels.TabIndex = 1;
            btnCancels.Text = "Cancel";
            btnCancels.UseVisualStyleBackColor = false;
            btnCancels.Click += btnCancel_Click;
            // 
            // ReturnVehicleForm
            // 
            ClientSize = new Size(1300, 889);
            Controls.Add(pnlHeader);
            Controls.Add(pnlRentalSummary);
            Controls.Add(pnlReturnDetails);
            Controls.Add(pnlDamageAssessment);
            Controls.Add(pnlBillingSummary);
            Controls.Add(pnlActionBar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CompleteRentalForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Return Vehicle";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlRentalSummary.ResumeLayout(false);
            pnlRentalSummary.PerformLayout();
            pnlReturnDetails.ResumeLayout(false);
            pnlReturnDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numOdometer).EndInit();
            pnlDamageAssessment.ResumeLayout(false);
            pnlDamageAssessment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDamages).EndInit();
            pnlBillingSummary.ResumeLayout(false);
            pnlBillingSummary.PerformLayout();
            pnlActionBar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblFormTitle;
        private Panel pnlRentalSummary;
        private Label lblCustomerInfo;
        private Label lblVehicleInfo;
        private Label lblRentalId;
        private Panel pnlReturnDetails;
        private Label lblSectionTitleReturn;
        private TextBox txtConditions;
        private Label lblConditionNotes;
        private ComboBox cbFuels;
        private Label lblFuelLevel;
        private NumericUpDown numOdometer;
        private Label lblOdometer;
        private DateTimePicker dtReturns;
        private Label lblReturnDate;
        private Panel pnlDamageAssessment;
        private Label lblSectionTitleDamage;
        private Button btnAddDamage;
        private DataGridView dgvDamages;
        private Panel pnlBillingSummary;
        private Label lblSectionTitleBilling;
        private Label lblTotalValue;
        private Label lblTotalLabel;
        private Label lblDamageFeesValue;
        private Label lblDamageFees;
        private Label lblLateFeesValue;
        private Label lblLateFees;
        private Panel pnlActionBar;
        private Button btnCompleteReturn;
        private Button btnCancels;
        private Button btnInspectionChecklist;
        private Label lblSubtotal;
        private Label lblSubtotalValue;
        private Label lblBaseRental;
        private Label lblBaseRentalValue;
    }
}