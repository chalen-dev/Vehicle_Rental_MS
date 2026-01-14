namespace VRMS.UI.Forms.Maintenance
{
    partial class MaintenanceForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            mainPanel = new Panel();
            tabControlMain = new TabControl();
            tabNew = new TabPage();
            panel3 = new Panel();
            grpMaintenanceInfo = new GroupBox();
            cmbMaintenanceType = new ComboBox();
            lblType = new Label();
            cmbStatus = new ComboBox();
            lblStatus = new Label();
            nudCost = new NumericUpDown();
            lblCost = new Label();
            dtpEnd = new DateTimePicker();
            chkHasEndDate = new CheckBox();
            lblEndDate = new Label();
            dtpStart = new DateTimePicker();
            lblStartDate = new Label();
            txtDescription = new TextBox();
            lblDescription = new Label();
            txtTitle = new TextBox();
            lblTitle = new Label();
            grpVehicleInfo = new GroupBox();
            lblPlateNo = new Label();
            lblVehicleModel = new Label();
            lblVehicleMake = new Label();
            panel4 = new Panel();
            btnMarkAvailable = new Button();
            btnClear = new Button();
            btnSave = new Button();
            tabHistory = new TabPage();
            panel5 = new Panel();
            splitContainer1 = new SplitContainer();
            dgvHistory = new DataGridView();
            panel6 = new Panel();
            grpRecordDetails = new GroupBox();
            txtDetailDescription = new TextBox();
            lblDetailCost = new Label();
            lblDetailEndDate = new Label();
            lblDetailStartDate = new Label();
            lblDetailStatus = new Label();
            lblDetailType = new Label();
            lblDetailTitle = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            panel2 = new Panel();
            btnExport = new Button();
            btnGenerateDoc = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnRefreshHistory = new Button();
            panel1 = new Panel();
            btnClose = new Button();
            lblFormTitle = new Label();
            picVehicle = new PictureBox();
            statusStrip1 = new StatusStrip();
            lblStatusMessage = new ToolStripStatusLabel();
            lblRecordCount = new ToolStripStatusLabel();
            mainPanel.SuspendLayout();
            tabControlMain.SuspendLayout();
            tabNew.SuspendLayout();
            panel3.SuspendLayout();
            grpMaintenanceInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCost).BeginInit();
            grpVehicleInfo.SuspendLayout();
            panel4.SuspendLayout();
            tabHistory.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            grpRecordDetails.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picVehicle).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(tabControlMain);
            mainPanel.Controls.Add(panel1);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Margin = new Padding(3, 4, 3, 4);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(11, 13, 11, 13);
            mainPanel.Size = new Size(1125, 980);
            mainPanel.TabIndex = 0;
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabNew);
            tabControlMain.Controls.Add(tabHistory);
            tabControlMain.Dock = DockStyle.Fill;
            tabControlMain.Font = new Font("Segoe UI", 9.5F);
            tabControlMain.ItemSize = new Size(120, 30);
            tabControlMain.Location = new Point(11, 106);
            tabControlMain.Margin = new Padding(3, 4, 3, 4);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(1103, 861);
            tabControlMain.TabIndex = 1;
            // 
            // tabNew
            // 
            tabNew.BackColor = Color.White;
            tabNew.Controls.Add(panel3);
            tabNew.Controls.Add(panel4);
            tabNew.Location = new Point(4, 34);
            tabNew.Margin = new Padding(3, 4, 3, 4);
            tabNew.Name = "tabNew";
            tabNew.Padding = new Padding(3, 4, 3, 4);
            tabNew.Size = new Size(1095, 823);
            tabNew.TabIndex = 0;
            tabNew.Text = "New Maintenance Record";
            // 
            // panel3
            // 
            panel3.Controls.Add(grpMaintenanceInfo);
            panel3.Controls.Add(grpVehicleInfo);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 4);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(11, 13, 11, 13);
            panel3.Size = new Size(867, 815);
            panel3.TabIndex = 0;
            // 
            // grpMaintenanceInfo
            // 
            grpMaintenanceInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpMaintenanceInfo.Controls.Add(cmbMaintenanceType);
            grpMaintenanceInfo.Controls.Add(lblType);
            grpMaintenanceInfo.Controls.Add(cmbStatus);
            grpMaintenanceInfo.Controls.Add(lblStatus);
            grpMaintenanceInfo.Controls.Add(nudCost);
            grpMaintenanceInfo.Controls.Add(lblCost);
            grpMaintenanceInfo.Controls.Add(dtpEnd);
            grpMaintenanceInfo.Controls.Add(chkHasEndDate);
            grpMaintenanceInfo.Controls.Add(lblEndDate);
            grpMaintenanceInfo.Controls.Add(dtpStart);
            grpMaintenanceInfo.Controls.Add(lblStartDate);
            grpMaintenanceInfo.Controls.Add(txtDescription);
            grpMaintenanceInfo.Controls.Add(lblDescription);
            grpMaintenanceInfo.Controls.Add(txtTitle);
            grpMaintenanceInfo.Controls.Add(lblTitle);
            grpMaintenanceInfo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpMaintenanceInfo.Location = new Point(15, 173);
            grpMaintenanceInfo.Margin = new Padding(3, 4, 3, 4);
            grpMaintenanceInfo.Name = "grpMaintenanceInfo";
            grpMaintenanceInfo.Padding = new Padding(3, 4, 3, 4);
            grpMaintenanceInfo.Size = new Size(837, 624);
            grpMaintenanceInfo.TabIndex = 1;
            grpMaintenanceInfo.TabStop = false;
            grpMaintenanceInfo.Text = "Maintenance Information";
            // 
            // cmbMaintenanceType
            // 
            cmbMaintenanceType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaintenanceType.Font = new Font("Segoe UI", 9F);
            cmbMaintenanceType.FormattingEnabled = true;
            cmbMaintenanceType.Location = new Point(171, 320);
            cmbMaintenanceType.Margin = new Padding(3, 4, 3, 4);
            cmbMaintenanceType.Name = "cmbMaintenanceType";
            cmbMaintenanceType.Size = new Size(285, 28);
            cmbMaintenanceType.TabIndex = 5;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI", 9F);
            lblType.Location = new Point(23, 324);
            lblType.Name = "lblType";
            lblType.Size = new Size(43, 20);
            lblType.TabIndex = 18;
            lblType.Text = "Type:";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 9F);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(171, 273);
            cmbStatus.Margin = new Padding(3, 4, 3, 4);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(171, 28);
            cmbStatus.TabIndex = 4;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.Location = new Point(23, 277);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(52, 20);
            lblStatus.TabIndex = 14;
            lblStatus.Text = "Status:";
            // 
            // nudCost
            // 
            nudCost.DecimalPlaces = 2;
            nudCost.Font = new Font("Segoe UI", 9F);
            nudCost.Location = new Point(560, 320);
            nudCost.Margin = new Padding(3, 4, 3, 4);
            nudCost.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudCost.Name = "nudCost";
            nudCost.Size = new Size(137, 27);
            nudCost.TabIndex = 7;
            // 
            // lblCost
            // 
            lblCost.AutoSize = true;
            lblCost.Font = new Font("Segoe UI", 9F);
            lblCost.Location = new Point(480, 324);
            lblCost.Name = "lblCost";
            lblCost.Size = new Size(41, 20);
            lblCost.TabIndex = 10;
            lblCost.Text = "Cost:";
            // 
            // dtpEnd
            // 
            dtpEnd.Enabled = false;
            dtpEnd.Font = new Font("Segoe UI", 9F);
            dtpEnd.Location = new Point(560, 227);
            dtpEnd.Margin = new Padding(3, 4, 3, 4);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(228, 27);
            dtpEnd.TabIndex = 3;
            // 
            // chkHasEndDate
            // 
            chkHasEndDate.AutoSize = true;
            chkHasEndDate.Font = new Font("Segoe UI", 9F);
            chkHasEndDate.Location = new Point(560, 193);
            chkHasEndDate.Margin = new Padding(3, 4, 3, 4);
            chkHasEndDate.Name = "chkHasEndDate";
            chkHasEndDate.Size = new Size(117, 24);
            chkHasEndDate.TabIndex = 2;
            chkHasEndDate.Text = "Set End Date";
            chkHasEndDate.UseVisualStyleBackColor = true;
            chkHasEndDate.CheckedChanged += chkHasEndDate_CheckedChanged;
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Font = new Font("Segoe UI", 9F);
            lblEndDate.Location = new Point(480, 233);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(73, 20);
            lblEndDate.TabIndex = 7;
            lblEndDate.Text = "End Date:";
            // 
            // dtpStart
            // 
            dtpStart.Font = new Font("Segoe UI", 9F);
            dtpStart.Location = new Point(171, 227);
            dtpStart.Margin = new Padding(3, 4, 3, 4);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(228, 27);
            dtpStart.TabIndex = 1;
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Font = new Font("Segoe UI", 9F);
            lblStartDate.Location = new Point(23, 233);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(79, 20);
            lblStartDate.TabIndex = 5;
            lblStartDate.Text = "Start Date:";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 9F);
            txtDescription.Location = new Point(171, 87);
            txtDescription.Margin = new Padding(3, 4, 3, 4);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(639, 85);
            txtDescription.TabIndex = 0;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 9F);
            lblDescription.Location = new Point(23, 91);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(88, 20);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "Description:";
            // 
            // txtTitle
            // 
            txtTitle.Font = new Font("Segoe UI", 9F);
            txtTitle.Location = new Point(171, 40);
            txtTitle.Margin = new Padding(3, 4, 3, 4);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(639, 27);
            txtTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 9F);
            lblTitle.Location = new Point(23, 44);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(41, 20);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Title:";
            // 
            // grpVehicleInfo
            // 
            grpVehicleInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpVehicleInfo.Controls.Add(lblPlateNo);
            grpVehicleInfo.Controls.Add(lblVehicleModel);
            grpVehicleInfo.Controls.Add(lblVehicleMake);
            grpVehicleInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpVehicleInfo.Location = new Point(15, 17);
            grpVehicleInfo.Margin = new Padding(3, 4, 3, 4);
            grpVehicleInfo.Name = "grpVehicleInfo";
            grpVehicleInfo.Padding = new Padding(3, 4, 3, 4);
            grpVehicleInfo.Size = new Size(837, 135);
            grpVehicleInfo.TabIndex = 0;
            grpVehicleInfo.TabStop = false;
            grpVehicleInfo.Text = "Vehicle Information";
            // 
            // lblPlateNo
            // 
            lblPlateNo.AutoSize = true;
            lblPlateNo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPlateNo.ForeColor = Color.FromArgb(52, 73, 94);
            lblPlateNo.Location = new Point(606, 53);
            lblPlateNo.Name = "lblPlateNo";
            lblPlateNo.Size = new Size(113, 32);
            lblPlateNo.TabIndex = 2;
            lblPlateNo.Text = "ABC-123";
            // 
            // lblVehicleModel
            // 
            lblVehicleModel.AutoSize = true;
            lblVehicleModel.Font = new Font("Segoe UI", 12F);
            lblVehicleModel.Location = new Point(23, 87);
            lblVehicleModel.Name = "lblVehicleModel";
            lblVehicleModel.Size = new Size(147, 28);
            lblVehicleModel.TabIndex = 1;
            lblVehicleModel.Text = "Model: [Model]";
            // 
            // lblVehicleMake
            // 
            lblVehicleMake.AutoSize = true;
            lblVehicleMake.Font = new Font("Segoe UI", 12F);
            lblVehicleMake.Location = new Point(23, 47);
            lblVehicleMake.Name = "lblVehicleMake";
            lblVehicleMake.Size = new Size(129, 28);
            lblVehicleMake.TabIndex = 0;
            lblVehicleMake.Text = "Make: [Make]";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(248, 249, 250);
            panel4.Controls.Add(btnMarkAvailable);
            panel4.Controls.Add(btnClear);
            panel4.Controls.Add(btnSave);
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(870, 4);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(11, 13, 11, 13);
            panel4.Size = new Size(222, 815);
            panel4.TabIndex = 1;
            // 
            // btnMarkAvailable
            // 
            btnMarkAvailable.BackColor = Color.FromArgb(255, 193, 7);
            btnMarkAvailable.FlatAppearance.BorderSize = 0;
            btnMarkAvailable.FlatStyle = FlatStyle.Flat;
            btnMarkAvailable.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnMarkAvailable.ForeColor = Color.White;
            btnMarkAvailable.ImageAlign = ContentAlignment.MiddleLeft;
            btnMarkAvailable.Location = new Point(11, 187);
            btnMarkAvailable.Margin = new Padding(3, 4, 3, 4);
            btnMarkAvailable.Name = "btnMarkAvailable";
            btnMarkAvailable.Size = new Size(199, 60);
            btnMarkAvailable.TabIndex = 2;
            btnMarkAvailable.Text = "Mark Vehicle Available";
            btnMarkAvailable.UseVisualStyleBackColor = false;
            btnMarkAvailable.Click += btnMarkAvailable_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(108, 117, 125);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.ImageAlign = ContentAlignment.MiddleLeft;
            btnClear.Location = new Point(11, 107);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(199, 60);
            btnClear.TabIndex = 1;
            btnClear.Text = "Clear Form";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(40, 167, 69);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(11, 27);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(199, 60);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save Record";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // tabHistory
            // 
            tabHistory.BackColor = Color.White;
            tabHistory.Controls.Add(panel5);
            tabHistory.Controls.Add(panel2);
            tabHistory.Location = new Point(4, 34);
            tabHistory.Margin = new Padding(3, 4, 3, 4);
            tabHistory.Name = "tabHistory";
            tabHistory.Padding = new Padding(3, 4, 3, 4);
            tabHistory.Size = new Size(1095, 724);
            tabHistory.TabIndex = 1;
            tabHistory.Text = "Maintenance History";
            // 
            // panel5
            // 
            panel5.Controls.Add(splitContainer1);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(3, 4);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(1089, 596);
            panel5.TabIndex = 1;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(3, 4, 3, 4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvHistory);
            splitContainer1.Panel1.Controls.Add(panel6);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(grpRecordDetails);
            splitContainer1.Size = new Size(1089, 596);
            splitContainer1.SplitterDistance = 722;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 0;
            // 
            // dgvHistory
            // 
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToDeleteRows = false;
            dgvHistory.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 249, 250);
            dgvHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistory.BackgroundColor = Color.White;
            dgvHistory.BorderStyle = BorderStyle.None;
            dgvHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(52, 73, 94);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(52, 73, 94);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvHistory.ColumnHeadersHeight = 40;
            dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(52, 73, 94);
            dataGridViewCellStyle3.Padding = new Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvHistory.DefaultCellStyle = dataGridViewCellStyle3;
            dgvHistory.Dock = DockStyle.Fill;
            dgvHistory.EnableHeadersVisualStyles = false;
            dgvHistory.GridColor = Color.FromArgb(234, 236, 238);
            dgvHistory.Location = new Point(0, 0);
            dgvHistory.Margin = new Padding(3, 4, 3, 4);
            dgvHistory.MultiSelect = false;
            dgvHistory.Name = "dgvHistory";
            dgvHistory.ReadOnly = true;
            dgvHistory.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(52, 73, 94);
            dataGridViewCellStyle4.Padding = new Padding(0, 5, 0, 5);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.RowHeadersWidth = 51;
            dataGridViewCellStyle5.Padding = new Padding(5);
            dgvHistory.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvHistory.RowTemplate.Height = 35;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.Size = new Size(722, 596);
            dgvHistory.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Right;
            panel6.Location = new Point(722, 0);
            panel6.Margin = new Padding(3, 4, 3, 4);
            panel6.Name = "panel6";
            panel6.Size = new Size(0, 596);
            panel6.TabIndex = 1;
            // 
            // grpRecordDetails
            // 
            grpRecordDetails.Controls.Add(txtDetailDescription);
            grpRecordDetails.Controls.Add(lblDetailCost);
            grpRecordDetails.Controls.Add(lblDetailEndDate);
            grpRecordDetails.Controls.Add(lblDetailStartDate);
            grpRecordDetails.Controls.Add(lblDetailStatus);
            grpRecordDetails.Controls.Add(lblDetailType);
            grpRecordDetails.Controls.Add(lblDetailTitle);
            grpRecordDetails.Controls.Add(label7);
            grpRecordDetails.Controls.Add(label6);
            grpRecordDetails.Controls.Add(label5);
            grpRecordDetails.Controls.Add(label4);
            grpRecordDetails.Controls.Add(label3);
            grpRecordDetails.Controls.Add(label2);
            grpRecordDetails.Dock = DockStyle.Fill;
            grpRecordDetails.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpRecordDetails.Location = new Point(0, 0);
            grpRecordDetails.Margin = new Padding(3, 4, 3, 4);
            grpRecordDetails.Name = "grpRecordDetails";
            grpRecordDetails.Padding = new Padding(3, 4, 3, 4);
            grpRecordDetails.Size = new Size(362, 596);
            grpRecordDetails.TabIndex = 0;
            grpRecordDetails.TabStop = false;
            grpRecordDetails.Text = "Record Details";
            // 
            // txtDetailDescription
            // 
            txtDetailDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtDetailDescription.BackColor = Color.White;
            txtDetailDescription.BorderStyle = BorderStyle.None;
            txtDetailDescription.Font = new Font("Segoe UI", 9F);
            txtDetailDescription.Location = new Point(23, 360);
            txtDetailDescription.Margin = new Padding(3, 4, 3, 4);
            txtDetailDescription.Multiline = true;
            txtDetailDescription.Name = "txtDetailDescription";
            txtDetailDescription.ReadOnly = true;
            txtDetailDescription.ScrollBars = ScrollBars.Vertical;
            txtDetailDescription.Size = new Size(321, 213);
            txtDetailDescription.TabIndex = 12;
            txtDetailDescription.Text = "No record selected";
            // 
            // lblDetailCost
            // 
            lblDetailCost.AutoSize = true;
            lblDetailCost.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDetailCost.Location = new Point(137, 300);
            lblDetailCost.Name = "lblDetailCost";
            lblDetailCost.Size = new Size(49, 20);
            lblDetailCost.TabIndex = 11;
            lblDetailCost.Text = "$0.00";
            // 
            // lblDetailEndDate
            // 
            lblDetailEndDate.AutoSize = true;
            lblDetailEndDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDetailEndDate.Location = new Point(137, 260);
            lblDetailEndDate.Name = "lblDetailEndDate";
            lblDetailEndDate.Size = new Size(39, 20);
            lblDetailEndDate.TabIndex = 10;
            lblDetailEndDate.Text = "N/A";
            // 
            // lblDetailStartDate
            // 
            lblDetailStartDate.AutoSize = true;
            lblDetailStartDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDetailStartDate.Location = new Point(137, 220);
            lblDetailStartDate.Name = "lblDetailStartDate";
            lblDetailStartDate.Size = new Size(39, 20);
            lblDetailStartDate.TabIndex = 9;
            lblDetailStartDate.Text = "N/A";
            // 
            // lblDetailStatus
            // 
            lblDetailStatus.AutoSize = true;
            lblDetailStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDetailStatus.Location = new Point(137, 180);
            lblDetailStatus.Name = "lblDetailStatus";
            lblDetailStatus.Size = new Size(39, 20);
            lblDetailStatus.TabIndex = 8;
            lblDetailStatus.Text = "N/A";
            // 
            // lblDetailType
            // 
            lblDetailType.AutoSize = true;
            lblDetailType.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDetailType.Location = new Point(137, 140);
            lblDetailType.Name = "lblDetailType";
            lblDetailType.Size = new Size(39, 20);
            lblDetailType.TabIndex = 7;
            lblDetailType.Text = "N/A";
            // 
            // lblDetailTitle
            // 
            lblDetailTitle.AutoSize = true;
            lblDetailTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDetailTitle.Location = new Point(137, 100);
            lblDetailTitle.Name = "lblDetailTitle";
            lblDetailTitle.Size = new Size(39, 20);
            lblDetailTitle.TabIndex = 6;
            lblDetailTitle.Text = "N/A";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F);
            label7.Location = new Point(23, 300);
            label7.Name = "label7";
            label7.Size = new Size(41, 20);
            label7.TabIndex = 5;
            label7.Text = "Cost:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F);
            label6.Location = new Point(23, 260);
            label6.Name = "label6";
            label6.Size = new Size(73, 20);
            label6.TabIndex = 4;
            label6.Text = "End Date:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F);
            label5.Location = new Point(23, 220);
            label5.Name = "label5";
            label5.Size = new Size(79, 20);
            label5.TabIndex = 3;
            label5.Text = "Start Date:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F);
            label4.Location = new Point(23, 180);
            label4.Name = "label4";
            label4.Size = new Size(52, 20);
            label4.TabIndex = 2;
            label4.Text = "Status:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(23, 140);
            label3.Name = "label3";
            label3.Size = new Size(43, 20);
            label3.TabIndex = 1;
            label3.Text = "Type:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(23, 100);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 0;
            label2.Text = "Title:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(248, 249, 250);
            panel2.Controls.Add(btnExport);
            panel2.Controls.Add(btnGenerateDoc);
            panel2.Controls.Add(btnDelete);
            panel2.Controls.Add(btnEdit);
            panel2.Controls.Add(btnRefreshHistory);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(3, 600);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(11, 13, 11, 13);
            panel2.Size = new Size(1089, 120);
            panel2.TabIndex = 0;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(108, 117, 125);
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.ImageAlign = ContentAlignment.MiddleLeft;
            btnExport.Location = new Point(777, 27);
            btnExport.Margin = new Padding(3, 4, 3, 4);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(137, 60);
            btnExport.TabIndex = 4;
            btnExport.Text = "Export CSV";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnGenerateDoc
            // 
            btnGenerateDoc.BackColor = Color.FromArgb(40, 167, 69);
            btnGenerateDoc.FlatAppearance.BorderSize = 0;
            btnGenerateDoc.FlatStyle = FlatStyle.Flat;
            btnGenerateDoc.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGenerateDoc.ForeColor = Color.White;
            btnGenerateDoc.ImageAlign = ContentAlignment.MiddleLeft;
            btnGenerateDoc.Location = new Point(617, 27);
            btnGenerateDoc.Margin = new Padding(3, 4, 3, 4);
            btnGenerateDoc.Name = "btnGenerateDoc";
            btnGenerateDoc.Size = new Size(137, 60);
            btnGenerateDoc.TabIndex = 3;
            btnGenerateDoc.Text = "Generate Doc";
            btnGenerateDoc.UseVisualStyleBackColor = false;
            btnGenerateDoc.Click += btnGenerateDoc_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            btnDelete.Location = new Point(457, 27);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(137, 60);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(23, 162, 184);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.ImageAlign = ContentAlignment.MiddleLeft;
            btnEdit.Location = new Point(297, 27);
            btnEdit.Margin = new Padding(3, 4, 3, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(137, 60);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnRefreshHistory
            // 
            btnRefreshHistory.BackColor = Color.FromArgb(41, 128, 185);
            btnRefreshHistory.FlatAppearance.BorderSize = 0;
            btnRefreshHistory.FlatStyle = FlatStyle.Flat;
            btnRefreshHistory.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefreshHistory.ForeColor = Color.White;
            btnRefreshHistory.ImageAlign = ContentAlignment.MiddleLeft;
            btnRefreshHistory.Location = new Point(137, 27);
            btnRefreshHistory.Margin = new Padding(3, 4, 3, 4);
            btnRefreshHistory.Name = "btnRefreshHistory";
            btnRefreshHistory.Size = new Size(137, 60);
            btnRefreshHistory.TabIndex = 0;
            btnRefreshHistory.Text = "Refresh";
            btnRefreshHistory.UseVisualStyleBackColor = false;
            btnRefreshHistory.Click += btnRefreshHistory_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(41, 128, 185);
            panel1.Controls.Add(btnClose);
            panel1.Controls.Add(lblFormTitle);
            panel1.Controls.Add(picVehicle);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(11, 13);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1103, 93);
            panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.Transparent;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(231, 76, 60);
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 57, 43);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1015, 13);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(77, 44);
            btnClose.TabIndex = 2;
            btnClose.Text = "✕";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.White;
            lblFormTitle.Location = new Point(80, 27);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(281, 37);
            lblFormTitle.TabIndex = 1;
            lblFormTitle.Text = "Vehicle Maintenance";
            // 
            // picVehicle
            // 
            picVehicle.Location = new Point(17, 13);
            picVehicle.Margin = new Padding(3, 4, 3, 4);
            picVehicle.Name = "picVehicle";
            picVehicle.Size = new Size(57, 67);
            picVehicle.SizeMode = PictureBoxSizeMode.Zoom;
            picVehicle.TabIndex = 0;
            picVehicle.TabStop = false;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatusMessage, lblRecordCount });
            statusStrip1.Location = new Point(0, 954);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(1125, 26);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatusMessage
            // 
            lblStatusMessage.Name = "lblStatusMessage";
            lblStatusMessage.Size = new Size(949, 20);
            lblStatusMessage.Spring = true;
            lblStatusMessage.Text = "Ready";
            lblStatusMessage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRecordCount
            // 
            lblRecordCount.Name = "lblRecordCount";
            lblRecordCount.Size = new Size(159, 20);
            lblRecordCount.Text = "0 maintenance records";
            // 
            // MaintenanceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1125, 980);
            Controls.Add(statusStrip1);
            Controls.Add(mainPanel);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1140, 918);
            Name = "MaintenanceForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Vehicle Maintenance";
            mainPanel.ResumeLayout(false);
            tabControlMain.ResumeLayout(false);
            tabNew.ResumeLayout(false);
            panel3.ResumeLayout(false);
            grpMaintenanceInfo.ResumeLayout(false);
            grpMaintenanceInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCost).EndInit();
            grpVehicleInfo.ResumeLayout(false);
            grpVehicleInfo.PerformLayout();
            panel4.ResumeLayout(false);
            tabHistory.ResumeLayout(false);
            panel5.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            grpRecordDetails.ResumeLayout(false);
            grpRecordDetails.PerformLayout();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picVehicle).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Panel mainPanel;
        private Panel panel1;
        private Label lblFormTitle;
        private PictureBox picVehicle;
        private TabControl tabControlMain;
        private TabPage tabNew;
        private Panel panel3;
        private GroupBox grpMaintenanceInfo;
        private ComboBox cmbMaintenanceType;
        private Label lblType;
        private ComboBox cmbStatus;
        private Label lblStatus;
        private NumericUpDown nudCost;
        private Label lblCost;
        private DateTimePicker dtpEnd;
        private CheckBox chkHasEndDate;
        private Label lblEndDate;
        private DateTimePicker dtpStart;
        private Label lblStartDate;
        private TextBox txtDescription;
        private Label lblDescription;
        private TextBox txtTitle;
        private Label lblTitle;
        private GroupBox grpVehicleInfo;
        private Label lblPlateNo;
        private Label lblVehicleModel;
        private Label lblVehicleMake;
        private Panel panel4;
        private Button btnMarkAvailable;
        private Button btnClear;
        private Button btnSave;
        private TabPage tabHistory;
        private Panel panel5;
        private SplitContainer splitContainer1;
        private DataGridView dgvHistory;
        private Panel panel6;
        private GroupBox grpRecordDetails;
        private TextBox txtDetailDescription;
        private Label lblDetailCost;
        private Label lblDetailEndDate;
        private Label lblDetailStartDate;
        private Label lblDetailStatus;
        private Label lblDetailType;
        private Label lblDetailTitle;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Panel panel2;
        private Button btnExport;
        private Button btnGenerateDoc;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnRefreshHistory;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatusMessage;
        private ToolStripStatusLabel lblRecordCount;
        private Button btnClose;
    }
}