namespace VRMS.UI.Forms.Damages
{
    partial class DamageReportDetails
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
            components = new System.ComponentModel.Container();
            pnlHeader = new Panel();
            lblTitle = new Label();
            pnlMain = new Panel();
            splitContainerMain = new SplitContainer();
            pnlReportInfo = new Panel();
            gbDamageDetails = new GroupBox();
            txtRepairCost = new TextBox();
            lblRepairCost = new Label();
            txtSeverity = new TextBox();
            lblSeverity = new Label();
            txtDamageType = new TextBox();
            lblDamageType = new Label();
            txtDamageDescription = new TextBox();
            lblDamageDescription = new Label();
            gbVehicleInfo = new GroupBox();
            txtVehicleColor = new TextBox();
            lblVehicleColor = new Label();
            txtVehicleModel = new TextBox();
            lblVehicleModel = new Label();
            txtVehicleMake = new TextBox();
            lblVehicleMake = new Label();
            txtLicensePlate = new TextBox();
            lblLicensePlate = new Label();
            txtVIN = new TextBox();
            lblVIN = new Label();
            gbReportDetails = new GroupBox();
            txtLocation = new TextBox();
            lblLocation = new Label();
            dtpReportDate = new DateTimePicker();
            lblReportDate = new Label();
            txtReportedBy = new TextBox();
            lblReportedBy = new Label();
            txtReportId = new TextBox();
            lblReportId = new Label();
            pnlImages = new Panel();
            gbDamageImages = new GroupBox();
            flowLayoutPanelImages = new FlowLayoutPanel();
            pbDamageImage1 = new PictureBox();
            pbDamageImage2 = new PictureBox();
            pbDamageImage3 = new PictureBox();
            pbDamageImage4 = new PictureBox();
            pnlActions = new Panel();
            gbStatusActions = new GroupBox();
            button1 = new Button();
            btnEdit = new Button();
            btnSave = new Button();
            btnClose = new Button();
            pnlFooter = new Panel();
            lblFooterInfo = new Label();
            toolTip = new ToolTip(components);
            pnlHeader.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            pnlReportInfo.SuspendLayout();
            gbDamageDetails.SuspendLayout();
            gbVehicleInfo.SuspendLayout();
            gbReportDetails.SuspendLayout();
            pnlImages.SuspendLayout();
            gbDamageImages.SuspendLayout();
            flowLayoutPanelImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbDamageImage1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbDamageImage2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbDamageImage3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbDamageImage4).BeginInit();
            pnlActions.SuspendLayout();
            gbStatusActions.SuspendLayout();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(52, 73, 94);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1200, 80);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(462, 54);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Damage Report Details";
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(splitContainerMain);
            pnlMain.Controls.Add(pnlActions);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 80);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(15);
            pnlMain.Size = new Size(1200, 746);
            pnlMain.TabIndex = 1;
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(15, 15);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(pnlReportInfo);
            splitContainerMain.Panel1.Padding = new Padding(0, 0, 10, 0);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(pnlImages);
            splitContainerMain.Panel2.Padding = new Padding(10, 0, 0, 0);
            splitContainerMain.Size = new Size(870, 716);
            splitContainerMain.SplitterDistance = 580;
            splitContainerMain.SplitterWidth = 10;
            splitContainerMain.TabIndex = 0;
            // 
            // pnlReportInfo
            // 
            pnlReportInfo.Controls.Add(gbDamageDetails);
            pnlReportInfo.Controls.Add(gbVehicleInfo);
            pnlReportInfo.Controls.Add(gbReportDetails);
            pnlReportInfo.Dock = DockStyle.Fill;
            pnlReportInfo.Location = new Point(0, 0);
            pnlReportInfo.Name = "pnlReportInfo";
            pnlReportInfo.Size = new Size(570, 716);
            pnlReportInfo.TabIndex = 0;
            // 
            // gbDamageDetails
            // 
            gbDamageDetails.Controls.Add(txtRepairCost);
            gbDamageDetails.Controls.Add(lblRepairCost);
            gbDamageDetails.Controls.Add(txtSeverity);
            gbDamageDetails.Controls.Add(lblSeverity);
            gbDamageDetails.Controls.Add(txtDamageType);
            gbDamageDetails.Controls.Add(lblDamageType);
            gbDamageDetails.Controls.Add(txtDamageDescription);
            gbDamageDetails.Controls.Add(lblDamageDescription);
            gbDamageDetails.Dock = DockStyle.Fill;
            gbDamageDetails.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            gbDamageDetails.Location = new Point(0, 415);
            gbDamageDetails.Name = "gbDamageDetails";
            gbDamageDetails.Size = new Size(570, 301);
            gbDamageDetails.TabIndex = 2;
            gbDamageDetails.TabStop = false;
            gbDamageDetails.Text = "Damage Details";
            // 
            // txtRepairCost
            // 
            txtRepairCost.Font = new Font("Segoe UI", 10F);
            txtRepairCost.Location = new Point(296, 135);
            txtRepairCost.Name = "txtRepairCost";
            txtRepairCost.ReadOnly = true;
            txtRepairCost.Size = new Size(250, 30);
            txtRepairCost.TabIndex = 7;
            // 
            // lblRepairCost
            // 
            lblRepairCost.AutoSize = true;
            lblRepairCost.Font = new Font("Segoe UI", 10F);
            lblRepairCost.Location = new Point(292, 110);
            lblRepairCost.Name = "lblRepairCost";
            lblRepairCost.Size = new Size(101, 23);
            lblRepairCost.TabIndex = 6;
            lblRepairCost.Text = "Repair Cost:";
            // 
            // txtSeverity
            // 
            txtSeverity.Font = new Font("Segoe UI", 10F);
            txtSeverity.Location = new Point(16, 63);
            txtSeverity.Name = "txtSeverity";
            txtSeverity.ReadOnly = true;
            txtSeverity.Size = new Size(250, 30);
            txtSeverity.TabIndex = 5;
            // 
            // lblSeverity
            // 
            lblSeverity.AutoSize = true;
            lblSeverity.Font = new Font("Segoe UI", 10F);
            lblSeverity.Location = new Point(20, 38);
            lblSeverity.Name = "lblSeverity";
            lblSeverity.Size = new Size(73, 23);
            lblSeverity.TabIndex = 4;
            lblSeverity.Text = "Severity:";
            // 
            // txtDamageType
            // 
            txtDamageType.Font = new Font("Segoe UI", 10F);
            txtDamageType.Location = new Point(300, 65);
            txtDamageType.Name = "txtDamageType";
            txtDamageType.ReadOnly = true;
            txtDamageType.Size = new Size(250, 30);
            txtDamageType.TabIndex = 3;
            // 
            // lblDamageType
            // 
            lblDamageType.AutoSize = true;
            lblDamageType.Font = new Font("Segoe UI", 10F);
            lblDamageType.Location = new Point(296, 40);
            lblDamageType.Name = "lblDamageType";
            lblDamageType.Size = new Size(118, 23);
            lblDamageType.TabIndex = 2;
            lblDamageType.Text = "Damage Type:";
            // 
            // txtDamageDescription
            // 
            txtDamageDescription.Font = new Font("Segoe UI", 10F);
            txtDamageDescription.Location = new Point(20, 191);
            txtDamageDescription.Multiline = true;
            txtDamageDescription.Name = "txtDamageDescription";
            txtDamageDescription.ReadOnly = true;
            txtDamageDescription.ScrollBars = ScrollBars.Vertical;
            txtDamageDescription.Size = new Size(526, 89);
            txtDamageDescription.TabIndex = 1;
            // 
            // lblDamageDescription
            // 
            lblDamageDescription.AutoSize = true;
            lblDamageDescription.Font = new Font("Segoe UI", 10F);
            lblDamageDescription.Location = new Point(29, 157);
            lblDamageDescription.Name = "lblDamageDescription";
            lblDamageDescription.Size = new Size(169, 23);
            lblDamageDescription.TabIndex = 0;
            lblDamageDescription.Text = "Damage Description:";
            // 
            // gbVehicleInfo
            // 
            gbVehicleInfo.Controls.Add(txtVehicleColor);
            gbVehicleInfo.Controls.Add(lblVehicleColor);
            gbVehicleInfo.Controls.Add(txtVehicleModel);
            gbVehicleInfo.Controls.Add(lblVehicleModel);
            gbVehicleInfo.Controls.Add(txtVehicleMake);
            gbVehicleInfo.Controls.Add(lblVehicleMake);
            gbVehicleInfo.Controls.Add(txtLicensePlate);
            gbVehicleInfo.Controls.Add(lblLicensePlate);
            gbVehicleInfo.Controls.Add(txtVIN);
            gbVehicleInfo.Controls.Add(lblVIN);
            gbVehicleInfo.Dock = DockStyle.Top;
            gbVehicleInfo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            gbVehicleInfo.Location = new Point(0, 180);
            gbVehicleInfo.Name = "gbVehicleInfo";
            gbVehicleInfo.Size = new Size(570, 235);
            gbVehicleInfo.TabIndex = 1;
            gbVehicleInfo.TabStop = false;
            gbVehicleInfo.Text = "Vehicle Information";
            // 
            // txtVehicleColor
            // 
            txtVehicleColor.Font = new Font("Segoe UI", 10F);
            txtVehicleColor.Location = new Point(300, 165);
            txtVehicleColor.Name = "txtVehicleColor";
            txtVehicleColor.ReadOnly = true;
            txtVehicleColor.Size = new Size(250, 30);
            txtVehicleColor.TabIndex = 9;
            // 
            // lblVehicleColor
            // 
            lblVehicleColor.AutoSize = true;
            lblVehicleColor.Font = new Font("Segoe UI", 10F);
            lblVehicleColor.Location = new Point(296, 140);
            lblVehicleColor.Name = "lblVehicleColor";
            lblVehicleColor.Size = new Size(114, 23);
            lblVehicleColor.TabIndex = 8;
            lblVehicleColor.Text = "Vehicle Color:";
            // 
            // txtVehicleModel
            // 
            txtVehicleModel.Font = new Font("Segoe UI", 10F);
            txtVehicleModel.Location = new Point(20, 165);
            txtVehicleModel.Name = "txtVehicleModel";
            txtVehicleModel.ReadOnly = true;
            txtVehicleModel.Size = new Size(250, 30);
            txtVehicleModel.TabIndex = 7;
            // 
            // lblVehicleModel
            // 
            lblVehicleModel.AutoSize = true;
            lblVehicleModel.Font = new Font("Segoe UI", 10F);
            lblVehicleModel.Location = new Point(16, 140);
            lblVehicleModel.Name = "lblVehicleModel";
            lblVehicleModel.Size = new Size(121, 23);
            lblVehicleModel.TabIndex = 6;
            lblVehicleModel.Text = "Vehicle Model:";
            // 
            // txtVehicleMake
            // 
            txtVehicleMake.Font = new Font("Segoe UI", 10F);
            txtVehicleMake.Location = new Point(300, 95);
            txtVehicleMake.Name = "txtVehicleMake";
            txtVehicleMake.ReadOnly = true;
            txtVehicleMake.Size = new Size(250, 30);
            txtVehicleMake.TabIndex = 5;
            // 
            // lblVehicleMake
            // 
            lblVehicleMake.AutoSize = true;
            lblVehicleMake.Font = new Font("Segoe UI", 10F);
            lblVehicleMake.Location = new Point(296, 70);
            lblVehicleMake.Name = "lblVehicleMake";
            lblVehicleMake.Size = new Size(114, 23);
            lblVehicleMake.TabIndex = 4;
            lblVehicleMake.Text = "Vehicle Make:";
            // 
            // txtLicensePlate
            // 
            txtLicensePlate.Font = new Font("Segoe UI", 10F);
            txtLicensePlate.Location = new Point(20, 95);
            txtLicensePlate.Name = "txtLicensePlate";
            txtLicensePlate.ReadOnly = true;
            txtLicensePlate.Size = new Size(250, 30);
            txtLicensePlate.TabIndex = 3;
            // 
            // lblLicensePlate
            // 
            lblLicensePlate.AutoSize = true;
            lblLicensePlate.Font = new Font("Segoe UI", 10F);
            lblLicensePlate.Location = new Point(16, 55);
            lblLicensePlate.Name = "lblLicensePlate";
            lblLicensePlate.Size = new Size(112, 23);
            lblLicensePlate.TabIndex = 2;
            lblLicensePlate.Text = "License Plate:";
            // 
            // txtVIN
            // 
            txtVIN.Font = new Font("Segoe UI", 10F);
            txtVIN.Location = new Point(160, 28);
            txtVIN.Name = "txtVIN";
            txtVIN.ReadOnly = true;
            txtVIN.Size = new Size(390, 30);
            txtVIN.TabIndex = 1;
            // 
            // lblVIN
            // 
            lblVIN.AutoSize = true;
            lblVIN.Font = new Font("Segoe UI", 10F);
            lblVIN.Location = new Point(16, 31);
            lblVIN.Name = "lblVIN";
            lblVIN.Size = new Size(134, 23);
            lblVIN.TabIndex = 0;
            lblVIN.Text = "VIN (Vehicle ID):";
            // 
            // gbReportDetails
            // 
            gbReportDetails.Controls.Add(txtLocation);
            gbReportDetails.Controls.Add(lblLocation);
            gbReportDetails.Controls.Add(dtpReportDate);
            gbReportDetails.Controls.Add(lblReportDate);
            gbReportDetails.Controls.Add(txtReportedBy);
            gbReportDetails.Controls.Add(lblReportedBy);
            gbReportDetails.Controls.Add(txtReportId);
            gbReportDetails.Controls.Add(lblReportId);
            gbReportDetails.Dock = DockStyle.Top;
            gbReportDetails.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            gbReportDetails.Location = new Point(0, 0);
            gbReportDetails.Name = "gbReportDetails";
            gbReportDetails.Size = new Size(570, 180);
            gbReportDetails.TabIndex = 0;
            gbReportDetails.TabStop = false;
            gbReportDetails.Text = "Report Information";
            // 
            // txtLocation
            // 
            txtLocation.Font = new Font("Segoe UI", 10F);
            txtLocation.Location = new Point(300, 120);
            txtLocation.Name = "txtLocation";
            txtLocation.ReadOnly = true;
            txtLocation.Size = new Size(250, 30);
            txtLocation.TabIndex = 7;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Font = new Font("Segoe UI", 10F);
            lblLocation.Location = new Point(296, 95);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(79, 23);
            lblLocation.TabIndex = 6;
            lblLocation.Text = "Location:";
            // 
            // dtpReportDate
            // 
            dtpReportDate.Enabled = false;
            dtpReportDate.Font = new Font("Segoe UI", 10F);
            dtpReportDate.Location = new Point(16, 121);
            dtpReportDate.Name = "dtpReportDate";
            dtpReportDate.Size = new Size(273, 30);
            dtpReportDate.TabIndex = 5;
            // 
            // lblReportDate
            // 
            lblReportDate.AutoSize = true;
            lblReportDate.Font = new Font("Segoe UI", 10F);
            lblReportDate.Location = new Point(16, 95);
            lblReportDate.Name = "lblReportDate";
            lblReportDate.Size = new Size(106, 23);
            lblReportDate.TabIndex = 4;
            lblReportDate.Text = "Report Date:";
            // 
            // txtReportedBy
            // 
            txtReportedBy.Font = new Font("Segoe UI", 10F);
            txtReportedBy.Location = new Point(300, 50);
            txtReportedBy.Name = "txtReportedBy";
            txtReportedBy.ReadOnly = true;
            txtReportedBy.Size = new Size(250, 30);
            txtReportedBy.TabIndex = 3;
            // 
            // lblReportedBy
            // 
            lblReportedBy.AutoSize = true;
            lblReportedBy.Font = new Font("Segoe UI", 10F);
            lblReportedBy.Location = new Point(296, 25);
            lblReportedBy.Name = "lblReportedBy";
            lblReportedBy.Size = new Size(107, 23);
            lblReportedBy.TabIndex = 2;
            lblReportedBy.Text = "Reported By:";
            // 
            // txtReportId
            // 
            txtReportId.Font = new Font("Segoe UI", 10F);
            txtReportId.Location = new Point(20, 50);
            txtReportId.Name = "txtReportId";
            txtReportId.ReadOnly = true;
            txtReportId.Size = new Size(269, 30);
            txtReportId.TabIndex = 1;
            // 
            // lblReportId
            // 
            lblReportId.AutoSize = true;
            lblReportId.Font = new Font("Segoe UI", 10F);
            lblReportId.Location = new Point(16, 25);
            lblReportId.Name = "lblReportId";
            lblReportId.Size = new Size(87, 23);
            lblReportId.TabIndex = 0;
            lblReportId.Text = "Report ID:";
            // 
            // pnlImages
            // 
            pnlImages.Controls.Add(gbDamageImages);
            pnlImages.Dock = DockStyle.Fill;
            pnlImages.Location = new Point(10, 0);
            pnlImages.Name = "pnlImages";
            pnlImages.Size = new Size(270, 716);
            pnlImages.TabIndex = 0;
            // 
            // gbDamageImages
            // 
            gbDamageImages.Controls.Add(flowLayoutPanelImages);
            gbDamageImages.Dock = DockStyle.Fill;
            gbDamageImages.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            gbDamageImages.Location = new Point(0, 0);
            gbDamageImages.Name = "gbDamageImages";
            gbDamageImages.Size = new Size(270, 716);
            gbDamageImages.TabIndex = 0;
            gbDamageImages.TabStop = false;
            gbDamageImages.Text = "Damage Images";
            // 
            // flowLayoutPanelImages
            // 
            flowLayoutPanelImages.AutoScroll = true;
            flowLayoutPanelImages.Controls.Add(pbDamageImage1);
            flowLayoutPanelImages.Controls.Add(pbDamageImage2);
            flowLayoutPanelImages.Controls.Add(pbDamageImage3);
            flowLayoutPanelImages.Controls.Add(pbDamageImage4);
            flowLayoutPanelImages.Dock = DockStyle.Fill;
            flowLayoutPanelImages.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelImages.Location = new Point(3, 26);
            flowLayoutPanelImages.Name = "flowLayoutPanelImages";
            flowLayoutPanelImages.Padding = new Padding(10);
            flowLayoutPanelImages.Size = new Size(264, 687);
            flowLayoutPanelImages.TabIndex = 0;
            // 
            // pbDamageImage1
            // 
            pbDamageImage1.BorderStyle = BorderStyle.FixedSingle;
            pbDamageImage1.Location = new Point(13, 13);
            pbDamageImage1.Name = "pbDamageImage1";
            pbDamageImage1.Size = new Size(240, 180);
            pbDamageImage1.SizeMode = PictureBoxSizeMode.Zoom;
            pbDamageImage1.TabIndex = 0;
            pbDamageImage1.TabStop = false;
            toolTip.SetToolTip(pbDamageImage1, "Click to view full size");
            // 
            // pbDamageImage2
            // 
            pbDamageImage2.BorderStyle = BorderStyle.FixedSingle;
            pbDamageImage2.Location = new Point(13, 199);
            pbDamageImage2.Name = "pbDamageImage2";
            pbDamageImage2.Size = new Size(240, 180);
            pbDamageImage2.SizeMode = PictureBoxSizeMode.Zoom;
            pbDamageImage2.TabIndex = 1;
            pbDamageImage2.TabStop = false;
            toolTip.SetToolTip(pbDamageImage2, "Click to view full size");
            // 
            // pbDamageImage3
            // 
            pbDamageImage3.BorderStyle = BorderStyle.FixedSingle;
            pbDamageImage3.Location = new Point(13, 385);
            pbDamageImage3.Name = "pbDamageImage3";
            pbDamageImage3.Size = new Size(240, 180);
            pbDamageImage3.SizeMode = PictureBoxSizeMode.Zoom;
            pbDamageImage3.TabIndex = 2;
            pbDamageImage3.TabStop = false;
            toolTip.SetToolTip(pbDamageImage3, "Click to view full size");
            // 
            // pbDamageImage4
            // 
            pbDamageImage4.BorderStyle = BorderStyle.FixedSingle;
            pbDamageImage4.Location = new Point(259, 13);
            pbDamageImage4.Name = "pbDamageImage4";
            pbDamageImage4.Size = new Size(240, 180);
            pbDamageImage4.SizeMode = PictureBoxSizeMode.Zoom;
            pbDamageImage4.TabIndex = 3;
            pbDamageImage4.TabStop = false;
            toolTip.SetToolTip(pbDamageImage4, "Click to view full size");
            // 
            // pnlActions
            // 
            pnlActions.Controls.Add(gbStatusActions);
            pnlActions.Dock = DockStyle.Right;
            pnlActions.Location = new Point(885, 15);
            pnlActions.Name = "pnlActions";
            pnlActions.Padding = new Padding(10, 0, 0, 0);
            pnlActions.Size = new Size(300, 716);
            pnlActions.TabIndex = 1;
            // 
            // gbStatusActions
            // 
            gbStatusActions.Controls.Add(button1);
            gbStatusActions.Controls.Add(btnEdit);
            gbStatusActions.Controls.Add(btnSave);
            gbStatusActions.Controls.Add(btnClose);
            gbStatusActions.Dock = DockStyle.Fill;
            gbStatusActions.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            gbStatusActions.Location = new Point(10, 0);
            gbStatusActions.Name = "gbStatusActions";
            gbStatusActions.Size = new Size(290, 716);
            gbStatusActions.TabIndex = 0;
            gbStatusActions.TabStop = false;
            gbStatusActions.Text = "Status & Actions";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(220, 53, 69);
            button1.Enabled = false;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(20, 249);
            button1.Name = "button1";
            button1.Size = new Size(250, 50);
            button1.TabIndex = 5;
            button1.Text = "Delete Report";
            button1.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(243, 156, 18);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(20, 188);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(250, 50);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.Enabled = false;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(20, 125);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(250, 50);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(149, 165, 166);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(20, 550);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(250, 50);
            btnClose.TabIndex = 4;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(241, 241, 241);
            pnlFooter.Controls.Add(lblFooterInfo);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 826);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1200, 30);
            pnlFooter.TabIndex = 2;
            // 
            // lblFooterInfo
            // 
            lblFooterInfo.AutoSize = true;
            lblFooterInfo.Font = new Font("Segoe UI", 9F);
            lblFooterInfo.ForeColor = Color.FromArgb(100, 100, 100);
            lblFooterInfo.Location = new Point(10, 6);
            lblFooterInfo.Name = "lblFooterInfo";
            lblFooterInfo.Size = new Size(298, 20);
            lblFooterInfo.TabIndex = 0;
            lblFooterInfo.Text = "Damage Report Details - View and Manage";
            // 
            // DamageReportDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1200, 856);
            Controls.Add(pnlMain);
            Controls.Add(pnlFooter);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(1218, 827);
            Name = "DamageReportDetails";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Damage Report Details - VRMS";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlMain.ResumeLayout(false);
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            pnlReportInfo.ResumeLayout(false);
            gbDamageDetails.ResumeLayout(false);
            gbDamageDetails.PerformLayout();
            gbVehicleInfo.ResumeLayout(false);
            gbVehicleInfo.PerformLayout();
            gbReportDetails.ResumeLayout(false);
            gbReportDetails.PerformLayout();
            pnlImages.ResumeLayout(false);
            gbDamageImages.ResumeLayout(false);
            flowLayoutPanelImages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbDamageImage1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbDamageImage2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbDamageImage3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbDamageImage4).EndInit();
            pnlActions.ResumeLayout(false);
            gbStatusActions.ResumeLayout(false);
            pnlFooter.ResumeLayout(false);
            pnlFooter.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.Panel pnlReportInfo;
        private System.Windows.Forms.GroupBox gbReportDetails;
        private System.Windows.Forms.TextBox txtReportId;
        private System.Windows.Forms.Label lblReportId;
        private System.Windows.Forms.TextBox txtReportedBy;
        private System.Windows.Forms.Label lblReportedBy;
        private System.Windows.Forms.DateTimePicker dtpReportDate;
        private System.Windows.Forms.Label lblReportDate;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.GroupBox gbVehicleInfo;
        private System.Windows.Forms.TextBox txtVIN;
        private System.Windows.Forms.Label lblVIN;
        private System.Windows.Forms.TextBox txtLicensePlate;
        private System.Windows.Forms.Label lblLicensePlate;
        private System.Windows.Forms.TextBox txtVehicleMake;
        private System.Windows.Forms.Label lblVehicleMake;
        private System.Windows.Forms.TextBox txtVehicleModel;
        private System.Windows.Forms.Label lblVehicleModel;
        private System.Windows.Forms.TextBox txtVehicleColor;
        private System.Windows.Forms.Label lblVehicleColor;
        private System.Windows.Forms.GroupBox gbDamageDetails;
        private System.Windows.Forms.TextBox txtDamageDescription;
        private System.Windows.Forms.Label lblDamageDescription;
        private System.Windows.Forms.TextBox txtDamageType;
        private System.Windows.Forms.Label lblDamageType;
        private System.Windows.Forms.TextBox txtSeverity;
        private System.Windows.Forms.Label lblSeverity;
        private System.Windows.Forms.TextBox txtRepairCost;
        private System.Windows.Forms.Label lblRepairCost;
        private System.Windows.Forms.Panel pnlImages;
        private System.Windows.Forms.GroupBox gbDamageImages;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelImages;
        private System.Windows.Forms.PictureBox pbDamageImage1;
        private System.Windows.Forms.PictureBox pbDamageImage2;
        private System.Windows.Forms.PictureBox pbDamageImage3;
        private System.Windows.Forms.PictureBox pbDamageImage4;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.GroupBox gbStatusActions;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblFooterInfo;
        private System.Windows.Forms.ToolTip toolTip;
        private Button button1;
    }
}