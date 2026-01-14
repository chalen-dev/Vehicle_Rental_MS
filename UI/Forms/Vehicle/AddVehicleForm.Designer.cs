namespace VRMS.Forms
{
    partial class AddVehicleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            panelHeader = new Panel();
            lblTitle = new Label();
            panelContent = new Panel();
            tabControl = new TabControl();
            tabBasicInfo = new TabPage();
            panelBasicInfo = new Panel();
            grpBasicInfo = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblMake = new Label();
            txtMake = new TextBox();
            lblModel = new Label();
            txtModel = new TextBox();
            lblYear = new Label();
            numYear = new NumericUpDown();
            lblColor = new Label();
            txtColor = new TextBox();
            lblPlate = new Label();
            txtPlate = new TextBox();
            lblCategory = new Label();
            cbCategory = new ComboBox();
            lblVehicleCode = new Label();
            tabSpecifications = new TabPage();
            panelSpecs = new Panel();
            grpSpecifications = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            lblTransmission = new Label();
            cbTransmission = new ComboBox();
            lblFuel = new Label();
            cbFuel = new ComboBox();
            lblSeats = new Label();
            numSeats = new NumericUpDown();
            lblMileage = new Label();
            numMileage = new NumericUpDown();
            lblVIN = new Label();
            txtVIN = new TextBox();
            lblStatus = new Label();
            cbStatus = new ComboBox();
            tabFeatures = new TabPage();
            panelFeatures = new Panel();
            grpFeatures = new GroupBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            chkAC = new CheckBox();
            chkGPS = new CheckBox();
            chkBluetooth = new CheckBox();
            chkChildSeat = new CheckBox();
            lblFuelEfficiency = new Label();
            txtFuelEfficiency = new TextBox();
            lblCargoCapacity = new Label();
            numCargoCapacity = new NumericUpDown();
            chkInsuranceIncluded = new CheckBox();
            tabImages = new TabPage();
            panelImages = new Panel();
            grpImages = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            picVehicleImage = new PictureBox();
            lstImages = new ListBox();
            btnAddImage = new Button();
            btnRemoveImage = new Button();
            panelFooter = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            panelHeader.SuspendLayout();
            panelContent.SuspendLayout();
            tabControl.SuspendLayout();
            tabBasicInfo.SuspendLayout();
            panelBasicInfo.SuspendLayout();
            grpBasicInfo.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numYear).BeginInit();
            tabSpecifications.SuspendLayout();
            panelSpecs.SuspendLayout();
            grpSpecifications.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSeats).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMileage).BeginInit();
            tabFeatures.SuspendLayout();
            panelFeatures.SuspendLayout();
            grpFeatures.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCargoCapacity).BeginInit();
            tabImages.SuspendLayout();
            panelImages.SuspendLayout();
            grpImages.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picVehicleImage).BeginInit();
            panelFooter.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(30, 60, 90);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(850, 70);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(286, 41);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Vehicle Information";
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.White;
            panelContent.Controls.Add(tabControl);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 70);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(20);
            panelContent.Size = new Size(850, 460);
            panelContent.TabIndex = 1;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabBasicInfo);
            tabControl.Controls.Add(tabSpecifications);
            tabControl.Controls.Add(tabFeatures);
            tabControl.Controls.Add(tabImages);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl.ItemSize = new Size(120, 30);
            tabControl.Location = new Point(20, 20);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(810, 420);
            tabControl.TabIndex = 0;
            // 
            // tabBasicInfo
            // 
            tabBasicInfo.BackColor = Color.FromArgb(248, 249, 250);
            tabBasicInfo.Controls.Add(panelBasicInfo);
            tabBasicInfo.Location = new Point(4, 34);
            tabBasicInfo.Name = "tabBasicInfo";
            tabBasicInfo.Padding = new Padding(3);
            tabBasicInfo.Size = new Size(802, 382);
            tabBasicInfo.TabIndex = 0;
            tabBasicInfo.Text = "Basic Information";
            // 
            // panelBasicInfo
            // 
            panelBasicInfo.Controls.Add(grpBasicInfo);
            panelBasicInfo.Dock = DockStyle.Fill;
            panelBasicInfo.Location = new Point(3, 3);
            panelBasicInfo.Name = "panelBasicInfo";
            panelBasicInfo.Padding = new Padding(10);
            panelBasicInfo.Size = new Size(796, 376);
            panelBasicInfo.TabIndex = 0;
            // 
            // grpBasicInfo
            // 
            grpBasicInfo.BackColor = Color.White;
            grpBasicInfo.Controls.Add(tableLayoutPanel1);
            grpBasicInfo.Dock = DockStyle.Fill;
            grpBasicInfo.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpBasicInfo.ForeColor = Color.FromArgb(50, 50, 50);
            grpBasicInfo.Location = new Point(10, 10);
            grpBasicInfo.Name = "grpBasicInfo";
            grpBasicInfo.Size = new Size(776, 356);
            grpBasicInfo.TabIndex = 0;
            grpBasicInfo.TabStop = false;
            grpBasicInfo.Text = "Vehicle Details";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.7671242F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41.36986F));
            tableLayoutPanel1.Controls.Add(lblMake, 0, 0);
            tableLayoutPanel1.Controls.Add(txtMake, 1, 0);
            tableLayoutPanel1.Controls.Add(lblModel, 0, 1);
            tableLayoutPanel1.Controls.Add(txtModel, 1, 1);
            tableLayoutPanel1.Controls.Add(lblYear, 0, 2);
            tableLayoutPanel1.Controls.Add(numYear, 1, 2);
            tableLayoutPanel1.Controls.Add(lblColor, 0, 3);
            tableLayoutPanel1.Controls.Add(txtColor, 1, 3);
            tableLayoutPanel1.Controls.Add(lblPlate, 0, 4);
            tableLayoutPanel1.Controls.Add(txtPlate, 1, 4);
            tableLayoutPanel1.Controls.Add(lblCategory, 0, 5);
            tableLayoutPanel1.Controls.Add(cbCategory, 1, 5);
            tableLayoutPanel1.Controls.Add(lblVehicleCode, 0, 6);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 25);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(20, 10, 20, 10);
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.28571F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.28571F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.28571F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.28571F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.28571F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.28571F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.28571F));
            tableLayoutPanel1.Size = new Size(770, 328);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblMake
            // 
            lblMake.AutoSize = true;
            lblMake.Dock = DockStyle.Fill;
            lblMake.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblMake.ForeColor = Color.FromArgb(30, 60, 90);
            lblMake.Location = new Point(23, 10);
            lblMake.Name = "lblMake";
            lblMake.Size = new Size(212, 44);
            lblMake.TabIndex = 0;
            lblMake.Text = "Make:";
            lblMake.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtMake
            // 
            txtMake.BorderStyle = BorderStyle.FixedSingle;
            tableLayoutPanel1.SetColumnSpan(txtMake, 2);
            txtMake.Dock = DockStyle.Fill;
            txtMake.Font = new Font("Segoe UI", 9.75F);
            txtMake.Location = new Point(241, 13);
            txtMake.Name = "txtMake";
            txtMake.Size = new Size(506, 29);
            txtMake.TabIndex = 1;
            // 
            // lblModel
            // 
            lblModel.AutoSize = true;
            lblModel.Dock = DockStyle.Fill;
            lblModel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblModel.ForeColor = Color.FromArgb(30, 60, 90);
            lblModel.Location = new Point(23, 54);
            lblModel.Name = "lblModel";
            lblModel.Size = new Size(212, 44);
            lblModel.TabIndex = 2;
            lblModel.Text = "Model:";
            lblModel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtModel
            // 
            txtModel.BorderStyle = BorderStyle.FixedSingle;
            tableLayoutPanel1.SetColumnSpan(txtModel, 2);
            txtModel.Dock = DockStyle.Fill;
            txtModel.Font = new Font("Segoe UI", 9.75F);
            txtModel.Location = new Point(241, 57);
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(506, 29);
            txtModel.TabIndex = 3;
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Dock = DockStyle.Fill;
            lblYear.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblYear.ForeColor = Color.FromArgb(30, 60, 90);
            lblYear.Location = new Point(23, 98);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(212, 44);
            lblYear.TabIndex = 4;
            lblYear.Text = "Year:";
            lblYear.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numYear
            // 
            numYear.BorderStyle = BorderStyle.FixedSingle;
            tableLayoutPanel1.SetColumnSpan(numYear, 2);
            numYear.Dock = DockStyle.Fill;
            numYear.Font = new Font("Segoe UI", 9.75F);
            numYear.Location = new Point(241, 101);
            numYear.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            numYear.Minimum = new decimal(new int[] { 1990, 0, 0, 0 });
            numYear.Name = "numYear";
            numYear.Size = new Size(506, 29);
            numYear.TabIndex = 5;
            numYear.Value = new decimal(new int[] { 2024, 0, 0, 0 });
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.Dock = DockStyle.Fill;
            lblColor.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblColor.ForeColor = Color.FromArgb(30, 60, 90);
            lblColor.Location = new Point(23, 142);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(212, 44);
            lblColor.TabIndex = 6;
            lblColor.Text = "Color:";
            lblColor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtColor
            // 
            txtColor.BorderStyle = BorderStyle.FixedSingle;
            tableLayoutPanel1.SetColumnSpan(txtColor, 2);
            txtColor.Dock = DockStyle.Fill;
            txtColor.Font = new Font("Segoe UI", 9.75F);
            txtColor.Location = new Point(241, 145);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(506, 29);
            txtColor.TabIndex = 7;
            // 
            // lblPlate
            // 
            lblPlate.AutoSize = true;
            lblPlate.Dock = DockStyle.Fill;
            lblPlate.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblPlate.ForeColor = Color.FromArgb(30, 60, 90);
            lblPlate.Location = new Point(23, 186);
            lblPlate.Name = "lblPlate";
            lblPlate.Size = new Size(212, 44);
            lblPlate.TabIndex = 8;
            lblPlate.Text = "License Plate:";
            lblPlate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtPlate
            // 
            txtPlate.BorderStyle = BorderStyle.FixedSingle;
            tableLayoutPanel1.SetColumnSpan(txtPlate, 2);
            txtPlate.Dock = DockStyle.Fill;
            txtPlate.Font = new Font("Segoe UI", 9.75F);
            txtPlate.Location = new Point(241, 189);
            txtPlate.Name = "txtPlate";
            txtPlate.Size = new Size(506, 29);
            txtPlate.TabIndex = 9;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Dock = DockStyle.Fill;
            lblCategory.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblCategory.ForeColor = Color.FromArgb(30, 60, 90);
            lblCategory.Location = new Point(23, 230);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(212, 44);
            lblCategory.TabIndex = 10;
            lblCategory.Text = "Category:";
            lblCategory.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbCategory
            // 
            cbCategory.Dock = DockStyle.Fill;
            cbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCategory.Font = new Font("Segoe UI", 9.75F);
            cbCategory.FormattingEnabled = true;
            cbCategory.Items.AddRange(new object[] { "Hatchback", "Sedan", "SUV", "Pick-up", "Van/Minibus" });
            cbCategory.Location = new Point(241, 233);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(203, 29);
            cbCategory.TabIndex = 11;
            // 
            // lblVehicleCode
            // 
            lblVehicleCode.Location = new Point(23, 274);
            lblVehicleCode.Name = "lblVehicleCode";
            lblVehicleCode.Size = new Size(100, 23);
            lblVehicleCode.TabIndex = 15;
            // 
            // tabSpecifications
            // 
            tabSpecifications.BackColor = Color.FromArgb(248, 249, 250);
            tabSpecifications.Controls.Add(panelSpecs);
            tabSpecifications.Location = new Point(4, 34);
            tabSpecifications.Name = "tabSpecifications";
            tabSpecifications.Padding = new Padding(3);
            tabSpecifications.Size = new Size(802, 382);
            tabSpecifications.TabIndex = 1;
            tabSpecifications.Text = "Specifications";
            // 
            // panelSpecs
            // 
            panelSpecs.Controls.Add(grpSpecifications);
            panelSpecs.Dock = DockStyle.Fill;
            panelSpecs.Location = new Point(3, 3);
            panelSpecs.Name = "panelSpecs";
            panelSpecs.Padding = new Padding(10);
            panelSpecs.Size = new Size(796, 376);
            panelSpecs.TabIndex = 0;
            // 
            // grpSpecifications
            // 
            grpSpecifications.BackColor = Color.White;
            grpSpecifications.Controls.Add(tableLayoutPanel2);
            grpSpecifications.Dock = DockStyle.Fill;
            grpSpecifications.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpSpecifications.ForeColor = Color.FromArgb(50, 50, 50);
            grpSpecifications.Location = new Point(10, 10);
            grpSpecifications.Name = "grpSpecifications";
            grpSpecifications.Size = new Size(776, 356);
            grpSpecifications.TabIndex = 0;
            grpSpecifications.TabStop = false;
            grpSpecifications.Text = "Technical Specifications";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel2.Controls.Add(lblTransmission, 0, 0);
            tableLayoutPanel2.Controls.Add(cbTransmission, 1, 0);
            tableLayoutPanel2.Controls.Add(lblFuel, 0, 1);
            tableLayoutPanel2.Controls.Add(cbFuel, 1, 1);
            tableLayoutPanel2.Controls.Add(lblSeats, 0, 2);
            tableLayoutPanel2.Controls.Add(numSeats, 1, 2);
            tableLayoutPanel2.Controls.Add(lblMileage, 0, 3);
            tableLayoutPanel2.Controls.Add(numMileage, 1, 3);
            tableLayoutPanel2.Controls.Add(lblVIN, 0, 4);
            tableLayoutPanel2.Controls.Add(txtVIN, 1, 4);
            tableLayoutPanel2.Controls.Add(lblStatus, 0, 5);
            tableLayoutPanel2.Controls.Add(cbStatus, 1, 5);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 25);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.Padding = new Padding(20, 10, 20, 10);
            tableLayoutPanel2.RowCount = 6;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tableLayoutPanel2.Size = new Size(770, 328);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // lblTransmission
            // 
            lblTransmission.AutoSize = true;
            lblTransmission.Dock = DockStyle.Fill;
            lblTransmission.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblTransmission.ForeColor = Color.FromArgb(30, 60, 90);
            lblTransmission.Location = new Point(23, 10);
            lblTransmission.Name = "lblTransmission";
            lblTransmission.Size = new Size(213, 51);
            lblTransmission.TabIndex = 0;
            lblTransmission.Text = "Transmission:";
            lblTransmission.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbTransmission
            // 
            cbTransmission.Dock = DockStyle.Fill;
            cbTransmission.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTransmission.Font = new Font("Segoe UI", 9.75F);
            cbTransmission.FormattingEnabled = true;
            cbTransmission.Items.AddRange(new object[] { "Manual", "Automatic" });
            cbTransmission.Location = new Point(242, 13);
            cbTransmission.Name = "cbTransmission";
            cbTransmission.Size = new Size(505, 29);
            cbTransmission.TabIndex = 1;
            // 
            // lblFuel
            // 
            lblFuel.AutoSize = true;
            lblFuel.Dock = DockStyle.Fill;
            lblFuel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblFuel.ForeColor = Color.FromArgb(30, 60, 90);
            lblFuel.Location = new Point(23, 61);
            lblFuel.Name = "lblFuel";
            lblFuel.Size = new Size(213, 51);
            lblFuel.TabIndex = 2;
            lblFuel.Text = "Fuel Type:";
            lblFuel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbFuel
            // 
            cbFuel.Dock = DockStyle.Fill;
            cbFuel.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFuel.Font = new Font("Segoe UI", 9.75F);
            cbFuel.FormattingEnabled = true;
            cbFuel.Items.AddRange(new object[] { "Gasoline", "Diesel", "Electric", "Hybrid" });
            cbFuel.Location = new Point(242, 64);
            cbFuel.Name = "cbFuel";
            cbFuel.Size = new Size(505, 29);
            cbFuel.TabIndex = 3;
            // 
            // lblSeats
            // 
            lblSeats.AutoSize = true;
            lblSeats.Dock = DockStyle.Fill;
            lblSeats.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblSeats.ForeColor = Color.FromArgb(30, 60, 90);
            lblSeats.Location = new Point(23, 112);
            lblSeats.Name = "lblSeats";
            lblSeats.Size = new Size(213, 51);
            lblSeats.TabIndex = 4;
            lblSeats.Text = "Seats:";
            lblSeats.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numSeats
            // 
            numSeats.BorderStyle = BorderStyle.FixedSingle;
            numSeats.Dock = DockStyle.Fill;
            numSeats.Font = new Font("Segoe UI", 9.75F);
            numSeats.Location = new Point(242, 115);
            numSeats.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numSeats.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numSeats.Name = "numSeats";
            numSeats.Size = new Size(505, 29);
            numSeats.TabIndex = 5;
            numSeats.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // lblMileage
            // 
            lblMileage.AutoSize = true;
            lblMileage.Dock = DockStyle.Fill;
            lblMileage.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblMileage.ForeColor = Color.FromArgb(30, 60, 90);
            lblMileage.Location = new Point(23, 163);
            lblMileage.Name = "lblMileage";
            lblMileage.Size = new Size(213, 51);
            lblMileage.TabIndex = 6;
            lblMileage.Text = "Current Mileage (km):";
            lblMileage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numMileage
            // 
            numMileage.BorderStyle = BorderStyle.FixedSingle;
            numMileage.Dock = DockStyle.Fill;
            numMileage.Font = new Font("Segoe UI", 9.75F);
            numMileage.Location = new Point(242, 166);
            numMileage.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numMileage.Name = "numMileage";
            numMileage.Size = new Size(505, 29);
            numMileage.TabIndex = 7;
            // 
            // lblVIN
            // 
            lblVIN.AutoSize = true;
            lblVIN.Dock = DockStyle.Fill;
            lblVIN.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblVIN.ForeColor = Color.FromArgb(30, 60, 90);
            lblVIN.Location = new Point(23, 214);
            lblVIN.Name = "lblVIN";
            lblVIN.Size = new Size(213, 51);
            lblVIN.TabIndex = 8;
            lblVIN.Text = "VIN (Vehicle ID):";
            lblVIN.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtVIN
            // 
            txtVIN.BorderStyle = BorderStyle.FixedSingle;
            txtVIN.Dock = DockStyle.Fill;
            txtVIN.Font = new Font("Segoe UI", 9.75F);
            txtVIN.Location = new Point(242, 217);
            txtVIN.Name = "txtVIN";
            txtVIN.Size = new Size(505, 29);
            txtVIN.TabIndex = 9;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(30, 60, 90);
            lblStatus.Location = new Point(23, 265);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(213, 53);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "Status:";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbStatus
            // 
            cbStatus.Dock = DockStyle.Fill;
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.Font = new Font("Segoe UI", 9.75F);
            cbStatus.FormattingEnabled = true;
            cbStatus.Items.AddRange(new object[] { "Available for rent", "Currently rented", "Reserved", "Under maintenance", "Out of service", "Retired/Sold" });
            cbStatus.Location = new Point(242, 268);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(505, 29);
            cbStatus.TabIndex = 11;
            // 
            // tabFeatures
            // 
            tabFeatures.BackColor = Color.FromArgb(248, 249, 250);
            tabFeatures.Controls.Add(panelFeatures);
            tabFeatures.Location = new Point(4, 34);
            tabFeatures.Name = "tabFeatures";
            tabFeatures.Size = new Size(802, 382);
            tabFeatures.TabIndex = 2;
            tabFeatures.Text = "Features";
            // 
            // panelFeatures
            // 
            panelFeatures.Controls.Add(grpFeatures);
            panelFeatures.Dock = DockStyle.Fill;
            panelFeatures.Location = new Point(0, 0);
            panelFeatures.Name = "panelFeatures";
            panelFeatures.Padding = new Padding(10);
            panelFeatures.Size = new Size(802, 382);
            panelFeatures.TabIndex = 0;
            // 
            // grpFeatures
            // 
            grpFeatures.BackColor = Color.White;
            grpFeatures.Controls.Add(tableLayoutPanel3);
            grpFeatures.Dock = DockStyle.Fill;
            grpFeatures.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpFeatures.ForeColor = Color.FromArgb(50, 50, 50);
            grpFeatures.Location = new Point(10, 10);
            grpFeatures.Name = "grpFeatures";
            grpFeatures.Size = new Size(782, 362);
            grpFeatures.TabIndex = 0;
            grpFeatures.TabStop = false;
            grpFeatures.Text = "Features & Amenities";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(chkAC, 0, 0);
            tableLayoutPanel3.Controls.Add(chkGPS, 0, 1);
            tableLayoutPanel3.Controls.Add(chkBluetooth, 0, 2);
            tableLayoutPanel3.Controls.Add(chkChildSeat, 0, 3);
            tableLayoutPanel3.Controls.Add(lblFuelEfficiency, 1, 0);
            tableLayoutPanel3.Controls.Add(txtFuelEfficiency, 1, 1);
            tableLayoutPanel3.Controls.Add(lblCargoCapacity, 1, 2);
            tableLayoutPanel3.Controls.Add(numCargoCapacity, 1, 3);
            tableLayoutPanel3.Controls.Add(chkInsuranceIncluded, 0, 4);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 25);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.Padding = new Padding(20, 10, 20, 10);
            tableLayoutPanel3.RowCount = 5;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel3.Size = new Size(776, 334);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // chkAC
            // 
            chkAC.AutoSize = true;
            chkAC.Dock = DockStyle.Fill;
            chkAC.Font = new Font("Segoe UI", 9.75F);
            chkAC.ForeColor = Color.FromArgb(50, 50, 50);
            chkAC.Location = new Point(23, 13);
            chkAC.Name = "chkAC";
            chkAC.Size = new Size(362, 56);
            chkAC.TabIndex = 0;
            chkAC.Text = "✓ Air Conditioning";
            chkAC.UseVisualStyleBackColor = true;
            // 
            // chkGPS
            // 
            chkGPS.AutoSize = true;
            chkGPS.Dock = DockStyle.Fill;
            chkGPS.Font = new Font("Segoe UI", 9.75F);
            chkGPS.ForeColor = Color.FromArgb(50, 50, 50);
            chkGPS.Location = new Point(23, 75);
            chkGPS.Name = "chkGPS";
            chkGPS.Size = new Size(362, 56);
            chkGPS.TabIndex = 1;
            chkGPS.Text = "✓ GPS Navigation";
            chkGPS.UseVisualStyleBackColor = true;
            // 
            // chkBluetooth
            // 
            chkBluetooth.AutoSize = true;
            chkBluetooth.Dock = DockStyle.Fill;
            chkBluetooth.Font = new Font("Segoe UI", 9.75F);
            chkBluetooth.ForeColor = Color.FromArgb(50, 50, 50);
            chkBluetooth.Location = new Point(23, 137);
            chkBluetooth.Name = "chkBluetooth";
            chkBluetooth.Size = new Size(362, 56);
            chkBluetooth.TabIndex = 2;
            chkBluetooth.Text = "✓ Bluetooth Connectivity";
            chkBluetooth.UseVisualStyleBackColor = true;
            // 
            // chkChildSeat
            // 
            chkChildSeat.AutoSize = true;
            chkChildSeat.Dock = DockStyle.Fill;
            chkChildSeat.Font = new Font("Segoe UI", 9.75F);
            chkChildSeat.ForeColor = Color.FromArgb(50, 50, 50);
            chkChildSeat.Location = new Point(23, 199);
            chkChildSeat.Name = "chkChildSeat";
            chkChildSeat.Size = new Size(362, 56);
            chkChildSeat.TabIndex = 3;
            chkChildSeat.Text = "✓ Child Seat Availability";
            chkChildSeat.UseVisualStyleBackColor = true;
            // 
            // lblFuelEfficiency
            // 
            lblFuelEfficiency.AutoSize = true;
            lblFuelEfficiency.Dock = DockStyle.Fill;
            lblFuelEfficiency.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblFuelEfficiency.ForeColor = Color.FromArgb(30, 60, 90);
            lblFuelEfficiency.Location = new Point(391, 10);
            lblFuelEfficiency.Name = "lblFuelEfficiency";
            lblFuelEfficiency.Size = new Size(362, 62);
            lblFuelEfficiency.TabIndex = 4;
            lblFuelEfficiency.Text = "Fuel Efficiency (km/L):";
            lblFuelEfficiency.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtFuelEfficiency
            // 
            txtFuelEfficiency.BorderStyle = BorderStyle.FixedSingle;
            txtFuelEfficiency.Dock = DockStyle.Fill;
            txtFuelEfficiency.Font = new Font("Segoe UI", 9.75F);
            txtFuelEfficiency.Location = new Point(391, 75);
            txtFuelEfficiency.Name = "txtFuelEfficiency";
            txtFuelEfficiency.Size = new Size(362, 29);
            txtFuelEfficiency.TabIndex = 5;
            // 
            // lblCargoCapacity
            // 
            lblCargoCapacity.AutoSize = true;
            lblCargoCapacity.Dock = DockStyle.Fill;
            lblCargoCapacity.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblCargoCapacity.ForeColor = Color.FromArgb(30, 60, 90);
            lblCargoCapacity.Location = new Point(391, 134);
            lblCargoCapacity.Name = "lblCargoCapacity";
            lblCargoCapacity.Size = new Size(362, 62);
            lblCargoCapacity.TabIndex = 6;
            lblCargoCapacity.Text = "Cargo Capacity (liters):";
            lblCargoCapacity.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numCargoCapacity
            // 
            numCargoCapacity.BorderStyle = BorderStyle.FixedSingle;
            numCargoCapacity.Dock = DockStyle.Fill;
            numCargoCapacity.Font = new Font("Segoe UI", 9.75F);
            numCargoCapacity.Location = new Point(391, 199);
            numCargoCapacity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numCargoCapacity.Name = "numCargoCapacity";
            numCargoCapacity.Size = new Size(362, 29);
            numCargoCapacity.TabIndex = 7;
            // 
            // chkInsuranceIncluded
            // 
            chkInsuranceIncluded.AutoSize = true;
            tableLayoutPanel3.SetColumnSpan(chkInsuranceIncluded, 2);
            chkInsuranceIncluded.Dock = DockStyle.Fill;
            chkInsuranceIncluded.Font = new Font("Segoe UI", 9.75F);
            chkInsuranceIncluded.ForeColor = Color.FromArgb(50, 50, 50);
            chkInsuranceIncluded.Location = new Point(23, 261);
            chkInsuranceIncluded.Name = "chkInsuranceIncluded";
            chkInsuranceIncluded.Size = new Size(730, 60);
            chkInsuranceIncluded.TabIndex = 8;
            chkInsuranceIncluded.Text = "✓ Insurance Coverage Included";
            chkInsuranceIncluded.UseVisualStyleBackColor = true;
            // 
            // tabImages
            // 
            tabImages.BackColor = Color.FromArgb(248, 249, 250);
            tabImages.Controls.Add(panelImages);
            tabImages.Location = new Point(4, 34);
            tabImages.Name = "tabImages";
            tabImages.Size = new Size(802, 382);
            tabImages.TabIndex = 4;
            tabImages.Text = "Images";
            // 
            // panelImages
            // 
            panelImages.Controls.Add(grpImages);
            panelImages.Dock = DockStyle.Fill;
            panelImages.Location = new Point(0, 0);
            panelImages.Name = "panelImages";
            panelImages.Padding = new Padding(10);
            panelImages.Size = new Size(802, 382);
            panelImages.TabIndex = 0;
            // 
            // grpImages
            // 
            grpImages.BackColor = Color.White;
            grpImages.Controls.Add(flowLayoutPanel1);
            grpImages.Dock = DockStyle.Fill;
            grpImages.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpImages.ForeColor = Color.FromArgb(50, 50, 50);
            grpImages.Location = new Point(10, 10);
            grpImages.Name = "grpImages";
            grpImages.Size = new Size(782, 362);
            grpImages.TabIndex = 0;
            grpImages.TabStop = false;
            grpImages.Text = "Vehicle Images";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(picVehicleImage);
            flowLayoutPanel1.Controls.Add(lstImages);
            flowLayoutPanel1.Controls.Add(btnAddImage);
            flowLayoutPanel1.Controls.Add(btnRemoveImage);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 25);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(10);
            flowLayoutPanel1.Size = new Size(776, 334);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // picVehicleImage
            // 
            picVehicleImage.BackColor = Color.White;
            picVehicleImage.BorderStyle = BorderStyle.FixedSingle;
            picVehicleImage.Location = new Point(13, 13);
            picVehicleImage.Name = "picVehicleImage";
            picVehicleImage.Size = new Size(350, 250);
            picVehicleImage.SizeMode = PictureBoxSizeMode.Zoom;
            picVehicleImage.TabIndex = 0;
            picVehicleImage.TabStop = false;
            // 
            // lstImages
            // 
            lstImages.Font = new Font("Segoe UI", 9.75F);
            lstImages.FormattingEnabled = true;
            lstImages.Location = new Point(369, 13);
            lstImages.Name = "lstImages";
            lstImages.Size = new Size(350, 88);
            lstImages.TabIndex = 1;
            // 
            // btnAddImage
            // 
            btnAddImage.BackColor = Color.FromArgb(52, 152, 219);
            btnAddImage.FlatAppearance.BorderSize = 0;
            btnAddImage.FlatStyle = FlatStyle.Flat;
            btnAddImage.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnAddImage.ForeColor = Color.White;
            btnAddImage.Location = new Point(13, 269);
            btnAddImage.Name = "btnAddImage";
            btnAddImage.Size = new Size(150, 40);
            btnAddImage.TabIndex = 2;
            btnAddImage.Text = "Browse Image...";
            btnAddImage.UseVisualStyleBackColor = false;
            // 
            // btnRemoveImage
            // 
            btnRemoveImage.BackColor = Color.FromArgb(231, 76, 60);
            btnRemoveImage.FlatAppearance.BorderSize = 0;
            btnRemoveImage.FlatStyle = FlatStyle.Flat;
            btnRemoveImage.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnRemoveImage.ForeColor = Color.White;
            btnRemoveImage.Location = new Point(169, 269);
            btnRemoveImage.Name = "btnRemoveImage";
            btnRemoveImage.Size = new Size(150, 40);
            btnRemoveImage.TabIndex = 3;
            btnRemoveImage.Text = "Remove Selected";
            btnRemoveImage.UseVisualStyleBackColor = false;
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.FromArgb(248, 249, 250);
            panelFooter.Controls.Add(btnCancel);
            panelFooter.Controls.Add(btnSave);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(0, 530);
            panelFooter.Name = "panelFooter";
            panelFooter.Padding = new Padding(20);
            panelFooter.Size = new Size(850, 90);
            panelFooter.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(108, 122, 137);
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(590, 20);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 45);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(720, 20);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 45);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save Vehicle";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // AddVehicleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnCancel;
            ClientSize = new Size(850, 620);
            Controls.Add(panelContent);
            Controls.Add(panelFooter);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddVehicleForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Vehicle Management - VRMS";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelContent.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabBasicInfo.ResumeLayout(false);
            panelBasicInfo.ResumeLayout(false);
            grpBasicInfo.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numYear).EndInit();
            tabSpecifications.ResumeLayout(false);
            panelSpecs.ResumeLayout(false);
            grpSpecifications.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSeats).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMileage).EndInit();
            tabFeatures.ResumeLayout(false);
            panelFeatures.ResumeLayout(false);
            grpFeatures.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCargoCapacity).EndInit();
            tabImages.ResumeLayout(false);
            panelImages.ResumeLayout(false);
            grpImages.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picVehicleImage).EndInit();
            panelFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private TabControl tabControl;
        private TabPage tabBasicInfo;
        private Panel panelBasicInfo;
        private GroupBox grpBasicInfo;
        private TabPage tabSpecifications;
        private Panel panelSpecs;
        private GroupBox grpSpecifications;
        private TableLayoutPanel tableLayoutPanel2;
        private Label lblTransmission;
        private ComboBox cbTransmission;
        private Label lblFuel;
        private ComboBox cbFuel;
        private Label lblSeats;
        private NumericUpDown numSeats;
        private Label lblMileage;
        private NumericUpDown numMileage;
        private Label lblVIN;
        private TextBox txtVIN;
        private Label lblStatus;
        private ComboBox cbStatus;
        private TabPage tabFeatures;
        private Panel panelFeatures;
        private GroupBox grpFeatures;
        private TableLayoutPanel tableLayoutPanel3;
        private CheckBox chkAC;
        private CheckBox chkGPS;
        private CheckBox chkBluetooth;
        private CheckBox chkChildSeat;
        private Label lblFuelEfficiency;
        private TextBox txtFuelEfficiency;
        private Label lblCargoCapacity;
        private NumericUpDown numCargoCapacity;
        private CheckBox chkInsuranceIncluded;
        private TabPage tabImages;
        private Panel panelImages;
        private GroupBox grpImages;
        private FlowLayoutPanel flowLayoutPanel1;
        private PictureBox picVehicleImage;
        private ListBox lstImages;
        private Button btnAddImage;
        private Button btnRemoveImage;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblMake;
        private TextBox txtMake;
        private Label lblModel;
        private TextBox txtModel;
        private Label lblYear;
        private NumericUpDown numYear;
        private Label lblColor;
        private TextBox txtColor;
        private Label lblPlate;
        private TextBox txtPlate;
        private Label lblCategory;
        private ComboBox cbCategory;
        private Label lblVehicleCode;
    }
}