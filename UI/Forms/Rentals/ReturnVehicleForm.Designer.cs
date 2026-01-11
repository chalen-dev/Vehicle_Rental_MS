namespace VRMS.Forms
{
    partial class ReturnVehicleForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReturnVehicleForm));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.pnlRentalSummary = new System.Windows.Forms.Panel();
            this.lblCustomerInfo = new System.Windows.Forms.Label();
            this.lblVehicleInfo = new System.Windows.Forms.Label();
            this.lblRentalId = new System.Windows.Forms.Label();
            this.pnlReturnDetails = new System.Windows.Forms.Panel();
            this.lblSectionTitleReturn = new System.Windows.Forms.Label();
            this.txtConditions = new System.Windows.Forms.TextBox();
            this.lblConditionNotes = new System.Windows.Forms.Label();
            this.cbFuels = new System.Windows.Forms.ComboBox();
            this.lblFuelLevel = new System.Windows.Forms.Label();
            this.txtOdometers = new System.Windows.Forms.TextBox();
            this.lblOdometer = new System.Windows.Forms.Label();
            this.dtReturns = new System.Windows.Forms.DateTimePicker();
            this.lblReturnDate = new System.Windows.Forms.Label();
            this.pnlDamageAssessment = new System.Windows.Forms.Panel();
            this.lblSectionTitleDamage = new System.Windows.Forms.Label();
            this.btnAddDamage = new System.Windows.Forms.Button();
            this.dgvDamages = new System.Windows.Forms.DataGridView();
            this.pnlBillingSummary = new System.Windows.Forms.Panel();
            this.lblSectionTitleBilling = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.numDamages = new System.Windows.Forms.NumericUpDown();
            this.lblDamageFees = new System.Windows.Forms.Label();
            this.numLateFee = new System.Windows.Forms.NumericUpDown();
            this.lblLateFees = new System.Windows.Forms.Label();
            this.pnlActionBar = new System.Windows.Forms.Panel();
            this.btnConfirms = new System.Windows.Forms.Button();
            this.btnCancels = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlRentalSummary.SuspendLayout();
            this.pnlReturnDetails.SuspendLayout();
            this.pnlDamageAssessment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDamages)).BeginInit();
            this.pnlBillingSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDamages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLateFee)).BeginInit();
            this.pnlActionBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblFormTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.pnlHeader.Size = new System.Drawing.Size(1150, 80);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblFormTitle.Location = new System.Drawing.Point(25, 20);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(225, 41);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Vehicle Return";
            // 
            // pnlRentalSummary
            // 
            this.pnlRentalSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pnlRentalSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRentalSummary.Controls.Add(this.lblCustomerInfo);
            this.pnlRentalSummary.Controls.Add(this.lblVehicleInfo);
            this.pnlRentalSummary.Controls.Add(this.lblRentalId);
            this.pnlRentalSummary.Location = new System.Drawing.Point(30, 100);
            this.pnlRentalSummary.Name = "pnlRentalSummary";
            this.pnlRentalSummary.Size = new System.Drawing.Size(530, 100);
            this.pnlRentalSummary.TabIndex = 1;
            // 
            // lblCustomerInfo
            // 
            this.lblCustomerInfo.AutoSize = true;
            this.lblCustomerInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerInfo.Location = new System.Drawing.Point(20, 45);
            this.lblCustomerInfo.Name = "lblCustomerInfo";
            this.lblCustomerInfo.Size = new System.Drawing.Size(94, 23);
            this.lblCustomerInfo.TabIndex = 2;
            this.lblCustomerInfo.Text = "Customer: ";
            // 
            // lblVehicleInfo
            // 
            this.lblVehicleInfo.AutoSize = true;
            this.lblVehicleInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblVehicleInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblVehicleInfo.Location = new System.Drawing.Point(20, 15);
            this.lblVehicleInfo.Name = "lblVehicleInfo";
            this.lblVehicleInfo.Size = new System.Drawing.Size(73, 23);
            this.lblVehicleInfo.TabIndex = 1;
            this.lblVehicleInfo.Text = "Vehicle: ";
            // 
            // lblRentalId
            // 
            this.lblRentalId.AutoSize = true;
            this.lblRentalId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRentalId.ForeColor = System.Drawing.Color.Gray;
            this.lblRentalId.Location = new System.Drawing.Point(20, 75);
            this.lblRentalId.Name = "lblRentalId";
            this.lblRentalId.Size = new System.Drawing.Size(127, 20);
            this.lblRentalId.TabIndex = 0;
            this.lblRentalId.Text = "Rental #: Loading...";
            // 
            // pnlReturnDetails
            // 
            this.pnlReturnDetails.BackColor = System.Drawing.Color.White;
            this.pnlReturnDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReturnDetails.Controls.Add(this.lblSectionTitleReturn);
            this.pnlReturnDetails.Controls.Add(this.txtConditions);
            this.pnlReturnDetails.Controls.Add(this.lblConditionNotes);
            this.pnlReturnDetails.Controls.Add(this.cbFuels);
            this.pnlReturnDetails.Controls.Add(this.lblFuelLevel);
            this.pnlReturnDetails.Controls.Add(this.txtOdometers);
            this.pnlReturnDetails.Controls.Add(this.lblOdometer);
            this.pnlReturnDetails.Controls.Add(this.dtReturns);
            this.pnlReturnDetails.Controls.Add(this.lblReturnDate);
            this.pnlReturnDetails.Location = new System.Drawing.Point(30, 220);
            this.pnlReturnDetails.Name = "pnlReturnDetails";
            this.pnlReturnDetails.Size = new System.Drawing.Size(530, 300);
            this.pnlReturnDetails.TabIndex = 2;
            // 
            // lblSectionTitleReturn
            // 
            this.lblSectionTitleReturn.AutoSize = true;
            this.lblSectionTitleReturn.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblSectionTitleReturn.Location = new System.Drawing.Point(15, 15);
            this.lblSectionTitleReturn.Name = "lblSectionTitleReturn";
            this.lblSectionTitleReturn.Size = new System.Drawing.Size(118, 25);
            this.lblSectionTitleReturn.TabIndex = 0;
            this.lblSectionTitleReturn.Text = "Return Details";
            // 
            // txtConditions
            // 
            this.txtConditions.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtConditions.Location = new System.Drawing.Point(20, 230);
            this.txtConditions.Multiline = true;
            this.txtConditions.Name = "txtConditions";
            this.txtConditions.Size = new System.Drawing.Size(490, 50);
            this.txtConditions.TabIndex = 3;
            // 
            // lblConditionNotes
            // 
            this.lblConditionNotes.AutoSize = true;
            this.lblConditionNotes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConditionNotes.ForeColor = System.Drawing.Color.DimGray;
            this.lblConditionNotes.Location = new System.Drawing.Point(17, 210);
            this.lblConditionNotes.Name = "lblConditionNotes";
            this.lblConditionNotes.Size = new System.Drawing.Size(166, 20);
            this.lblConditionNotes.TabIndex = 6;
            this.lblConditionNotes.Text = "Final Condition / Notes:";
            // 
            // cbFuels
            // 
            this.cbFuels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFuels.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbFuels.Items.AddRange(new object[] {
            "Empty",
            "1/4",
            "1/2",
            "3/4",
            "Full"});
            this.cbFuels.Location = new System.Drawing.Point(20, 165);
            this.cbFuels.Name = "cbFuels";
            this.cbFuels.Size = new System.Drawing.Size(490, 31);
            this.cbFuels.TabIndex = 2;
            // 
            // lblFuelLevel
            // 
            this.lblFuelLevel.AutoSize = true;
            this.lblFuelLevel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFuelLevel.ForeColor = System.Drawing.Color.DimGray;
            this.lblFuelLevel.Location = new System.Drawing.Point(17, 145);
            this.lblFuelLevel.Name = "lblFuelLevel";
            this.lblFuelLevel.Size = new System.Drawing.Size(81, 20);
            this.lblFuelLevel.TabIndex = 4;
            this.lblFuelLevel.Text = "Fuel Level:";
            // 
            // txtOdometers
            // 
            this.txtOdometers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtOdometers.Location = new System.Drawing.Point(20, 100);
            this.txtOdometers.Name = "txtOdometers";
            this.txtOdometers.Size = new System.Drawing.Size(490, 30);
            this.txtOdometers.TabIndex = 1;
            // 
            // lblOdometer
            // 
            this.lblOdometer.AutoSize = true;
            this.lblOdometer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOdometer.ForeColor = System.Drawing.Color.DimGray;
            this.lblOdometer.Location = new System.Drawing.Point(17, 80);
            this.lblOdometer.Name = "lblOdometer";
            this.lblOdometer.Size = new System.Drawing.Size(183, 20);
            this.lblOdometer.TabIndex = 2;
            this.lblOdometer.Text = "Final Odometer Reading:";
            // 
            // dtReturns
            // 
            this.dtReturns.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtReturns.Location = new System.Drawing.Point(20, 35);
            this.dtReturns.Name = "dtReturns";
            this.dtReturns.Size = new System.Drawing.Size(490, 30);
            this.dtReturns.TabIndex = 0;
            // 
            // lblReturnDate
            // 
            this.lblReturnDate.AutoSize = true;
            this.lblReturnDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturnDate.ForeColor = System.Drawing.Color.DimGray;
            this.lblReturnDate.Location = new System.Drawing.Point(17, 15);
            this.lblReturnDate.Name = "lblReturnDate";
            this.lblReturnDate.Size = new System.Drawing.Size(95, 20);
            this.lblReturnDate.TabIndex = 0;
            this.lblReturnDate.Text = "Return Date:";
            // 
            // pnlDamageAssessment
            // 
            this.pnlDamageAssessment.BackColor = System.Drawing.Color.White;
            this.pnlDamageAssessment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDamageAssessment.Controls.Add(this.lblSectionTitleDamage);
            this.pnlDamageAssessment.Controls.Add(this.btnAddDamage);
            this.pnlDamageAssessment.Controls.Add(this.dgvDamages);
            this.pnlDamageAssessment.Location = new System.Drawing.Point(580, 100);
            this.pnlDamageAssessment.Name = "pnlDamageAssessment";
            this.pnlDamageAssessment.Size = new System.Drawing.Size(540, 420);
            this.pnlDamageAssessment.TabIndex = 3;
            // 
            // lblSectionTitleDamage
            // 
            this.lblSectionTitleDamage.AutoSize = true;
            this.lblSectionTitleDamage.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblSectionTitleDamage.Location = new System.Drawing.Point(15, 15);
            this.lblSectionTitleDamage.Name = "lblSectionTitleDamage";
            this.lblSectionTitleDamage.Size = new System.Drawing.Size(176, 25);
            this.lblSectionTitleDamage.TabIndex = 0;
            this.lblSectionTitleDamage.Text = "Damage Assessment";
            // 
            // btnAddDamage
            // 
            this.btnAddDamage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnAddDamage.FlatAppearance.BorderSize = 0;
            this.btnAddDamage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDamage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddDamage.ForeColor = System.Drawing.Color.White;
            this.btnAddDamage.Location = new System.Drawing.Point(380, 10);
            this.btnAddDamage.Name = "btnAddDamage";
            this.btnAddDamage.Size = new System.Drawing.Size(150, 35);
            this.btnAddDamage.TabIndex = 1;
            this.btnAddDamage.Text = "+ Add Damage";
            this.btnAddDamage.UseVisualStyleBackColor = false;
            // 
            // dgvDamages
            // 
            this.dgvDamages.AllowUserToAddRows = false;
            this.dgvDamages.AllowUserToDeleteRows = false;
            this.dgvDamages.AllowUserToResizeRows = false;
            this.dgvDamages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDamages.BackgroundColor = System.Drawing.Color.White;
            this.dgvDamages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDamages.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDamages.ColumnHeadersHeight = 40;
            this.dgvDamages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDamages.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDamages.EnableHeadersVisualStyles = false;
            this.dgvDamages.Location = new System.Drawing.Point(20, 60);
            this.dgvDamages.MultiSelect = false;
            this.dgvDamages.Name = "dgvDamages";
            this.dgvDamages.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDamages.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDamages.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.dgvDamages.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDamages.RowTemplate.Height = 35;
            this.dgvDamages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDamages.Size = new System.Drawing.Size(500, 340);
            this.dgvDamages.TabIndex = 2;
            // 
            // pnlBillingSummary
            // 
            this.pnlBillingSummary.BackColor = System.Drawing.Color.White;
            this.pnlBillingSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBillingSummary.Controls.Add(this.lblSectionTitleBilling);
            this.pnlBillingSummary.Controls.Add(this.lblTotalValue);
            this.pnlBillingSummary.Controls.Add(this.lblTotalLabel);
            this.pnlBillingSummary.Controls.Add(this.numDamages);
            this.pnlBillingSummary.Controls.Add(this.lblDamageFees);
            this.pnlBillingSummary.Controls.Add(this.numLateFee);
            this.pnlBillingSummary.Controls.Add(this.lblLateFees);
            this.pnlBillingSummary.Location = new System.Drawing.Point(30, 540);
            this.pnlBillingSummary.Name = "pnlBillingSummary";
            this.pnlBillingSummary.Size = new System.Drawing.Size(530, 160);
            this.pnlBillingSummary.TabIndex = 4;
            // 
            // lblSectionTitleBilling
            // 
            this.lblSectionTitleBilling.AutoSize = true;
            this.lblSectionTitleBilling.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblSectionTitleBilling.Location = new System.Drawing.Point(15, 15);
            this.lblSectionTitleBilling.Name = "lblSectionTitleBilling";
            this.lblSectionTitleBilling.Size = new System.Drawing.Size(135, 25);
            this.lblSectionTitleBilling.TabIndex = 0;
            this.lblSectionTitleBilling.Text = "Billing Summary";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblTotalValue.Location = new System.Drawing.Point(240, 115);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(111, 32);
            this.lblTotalValue.TabIndex = 6;
            this.lblTotalValue.Text = "₱ 0.00";
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalLabel.Location = new System.Drawing.Point(15, 120);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(138, 25);
            this.lblTotalLabel.TabIndex = 5;
            this.lblTotalLabel.Text = "Grand Total:";
            // 
            // numDamages
            // 
            this.numDamages.DecimalPlaces = 2;
            this.numDamages.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numDamages.Location = new System.Drawing.Point(290, 45);
            this.numDamages.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numDamages.Name = "numDamages";
            this.numDamages.ReadOnly = true;
            this.numDamages.Size = new System.Drawing.Size(220, 30);
            this.numDamages.TabIndex = 2;
            this.numDamages.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numDamages.ThousandsSeparator = true;
            // 
            // lblDamageFees
            // 
            this.lblDamageFees.AutoSize = true;
            this.lblDamageFees.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDamageFees.ForeColor = System.Drawing.Color.DimGray;
            this.lblDamageFees.Location = new System.Drawing.Point(287, 25);
            this.lblDamageFees.Name = "lblDamageFees";
            this.lblDamageFees.Size = new System.Drawing.Size(104, 20);
            this.lblDamageFees.TabIndex = 3;
            this.lblDamageFees.Text = "Damage Fees:";
            // 
            // numLateFee
            // 
            this.numLateFee.DecimalPlaces = 2;
            this.numLateFee.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numLateFee.Location = new System.Drawing.Point(20, 45);
            this.numLateFee.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numLateFee.Name = "numLateFee";
            this.numLateFee.ReadOnly = true;
            this.numLateFee.Size = new System.Drawing.Size(220, 30);
            this.numLateFee.TabIndex = 1;
            this.numLateFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numLateFee.ThousandsSeparator = true;
            // 
            // lblLateFees
            // 
            this.lblLateFees.AutoSize = true;
            this.lblLateFees.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLateFees.ForeColor = System.Drawing.Color.DimGray;
            this.lblLateFees.Location = new System.Drawing.Point(17, 25);
            this.lblLateFees.Name = "lblLateFees";
            this.lblLateFees.Size = new System.Drawing.Size(76, 20);
            this.lblLateFees.TabIndex = 0;
            this.lblLateFees.Text = "Late Fees:";
            // 
            // pnlActionBar
            // 
            this.pnlActionBar.BackColor = System.Drawing.Color.White;
            this.pnlActionBar.Controls.Add(this.btnConfirms);
            this.pnlActionBar.Controls.Add(this.btnCancels);
            this.pnlActionBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActionBar.Location = new System.Drawing.Point(0, 720);
            this.pnlActionBar.Name = "pnlActionBar";
            this.pnlActionBar.Padding = new System.Windows.Forms.Padding(20);
            this.pnlActionBar.Size = new System.Drawing.Size(1150, 100);
            this.pnlActionBar.TabIndex = 5;
            // 
            // btnConfirms
            // 
            this.btnConfirms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnConfirms.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnConfirms.FlatAppearance.BorderSize = 0;
            this.btnConfirms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirms.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnConfirms.ForeColor = System.Drawing.Color.White;
            this.btnConfirms.Location = new System.Drawing.Point(680, 20);
            this.btnConfirms.Name = "btnConfirms";
            this.btnConfirms.Size = new System.Drawing.Size(450, 60);
            this.btnConfirms.TabIndex = 1;
            this.btnConfirms.Text = "Complete Return Process";
            this.btnConfirms.UseVisualStyleBackColor = false;
            // 
            // btnCancels
            // 
            this.btnCancels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.btnCancels.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCancels.FlatAppearance.BorderSize = 0;
            this.btnCancels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancels.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCancels.Location = new System.Drawing.Point(20, 20);
            this.btnCancels.Name = "btnCancels";
            this.btnCancels.Size = new System.Drawing.Size(450, 60);
            this.btnCancels.TabIndex = 0;
            this.btnCancels.Text = "Cancel";
            this.btnCancels.UseVisualStyleBackColor = false;
            // 
            // ReturnVehicleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1150, 820);
            this.Controls.Add(this.pnlActionBar);
            this.Controls.Add(this.pnlBillingSummary);
            this.Controls.Add(this.pnlDamageAssessment);
            this.Controls.Add(this.pnlReturnDetails);
            this.Controls.Add(this.pnlRentalSummary);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReturnVehicleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Return Vehicle";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlRentalSummary.ResumeLayout(false);
            this.pnlRentalSummary.PerformLayout();
            this.pnlReturnDetails.ResumeLayout(false);
            this.pnlReturnDetails.PerformLayout();
            this.pnlDamageAssessment.ResumeLayout(false);
            this.pnlDamageAssessment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDamages)).EndInit();
            this.pnlBillingSummary.ResumeLayout(false);
            this.pnlBillingSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDamages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLateFee)).EndInit();
            this.pnlActionBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel pnlRentalSummary;
        private System.Windows.Forms.Label lblCustomerInfo;
        private System.Windows.Forms.Label lblVehicleInfo;
        private System.Windows.Forms.Label lblRentalId;
        private System.Windows.Forms.Panel pnlReturnDetails;
        private System.Windows.Forms.Label lblSectionTitleReturn;
        private System.Windows.Forms.TextBox txtConditions;
        private System.Windows.Forms.Label lblConditionNotes;
        private System.Windows.Forms.ComboBox cbFuels;
        private System.Windows.Forms.Label lblFuelLevel;
        private System.Windows.Forms.TextBox txtOdometers;
        private System.Windows.Forms.Label lblOdometer;
        private System.Windows.Forms.DateTimePicker dtReturns;
        private System.Windows.Forms.Label lblReturnDate;
        private System.Windows.Forms.Panel pnlDamageAssessment;
        private System.Windows.Forms.Label lblSectionTitleDamage;
        private System.Windows.Forms.Button btnAddDamage;
        private System.Windows.Forms.DataGridView dgvDamages;
        private System.Windows.Forms.Panel pnlBillingSummary;
        private System.Windows.Forms.Label lblSectionTitleBilling;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.NumericUpDown numDamages;
        private System.Windows.Forms.Label lblDamageFees;
        private System.Windows.Forms.NumericUpDown numLateFee;
        private System.Windows.Forms.Label lblLateFees;
        private System.Windows.Forms.Panel pnlActionBar;
        private System.Windows.Forms.Button btnConfirms;
        private System.Windows.Forms.Button btnCancels;
    }
}