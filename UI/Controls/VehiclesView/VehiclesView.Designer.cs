namespace VRMS.UI.Controls.VehiclesView
{
    partial class VehiclesView
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelHeader = new Panel();
            label1 = new Label();
            lblVehicleCount = new Label();
            panelToolbar = new Panel();
            btnUnderMaintenance = new Button();
            btnAddCategory = new Button();
            panelSearch = new Panel();
            txtSearch = new TextBox();
            cmbStatusFilter = new ComboBox();
            btnEdit = new Button();
            btnAdd = new Button();
            splitContainerMain = new SplitContainer();
            panelVehicleList = new Panel();
            dgvVehicles = new DataGridView();
            panelStatusFilter = new Panel();
            cmbAdvancedFilter = new ComboBox();
            lblStatusFilter = new Label();
            panelVehicleDetails = new Panel();
            panelFeatures = new Panel();
            flowLayoutPanelFeatures = new FlowLayoutPanel();
            lblFeaturesTitle = new Label();
            panelVehicleInfo = new Panel();
            lblMileageValue = new Label();
            lblMileage = new Label();
            lblPlateValue = new Label();
            lblPlate = new Label();
            lblDailyRateValue = new Label();
            lblDailyRate = new Label();
            lblYearColorValue = new Label();
            lblYearColor = new Label();
            lblCategoryValue = new Label();
            lblStatusValue = new Label();
            lblStatus = new Label();
            lblCategory = new Label();
            lblMakeModel = new Label();
            lblDetailsTitle = new Label();
            panelPreviewHeader = new Panel();
            lblVehicleDetails = new Label();
            picVehiclePreview = new PictureBox();
            panelHeader.SuspendLayout();
            panelToolbar.SuspendLayout();
            panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            panelVehicleList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVehicles).BeginInit();
            panelStatusFilter.SuspendLayout();
            panelVehicleDetails.SuspendLayout();
            panelFeatures.SuspendLayout();
            panelVehicleInfo.SuspendLayout();
            panelPreviewHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picVehiclePreview).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(30, 60, 90);
            panelHeader.Controls.Add(label1);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1491, 70);
            panelHeader.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(20, 15);
            label1.Name = "label1";
            label1.Size = new Size(127, 41);
            label1.TabIndex = 0;
            label1.Text = "Vehicles";
            // 
            // lblVehicleCount
            // 
            lblVehicleCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblVehicleCount.Font = new Font("Segoe UI", 10F);
            lblVehicleCount.ForeColor = Color.Black;
            lblVehicleCount.Location = new Point(905, 1);
            lblVehicleCount.Name = "lblVehicleCount";
            lblVehicleCount.Size = new Size(180, 27);
            lblVehicleCount.TabIndex = 1;
            lblVehicleCount.Text = "Total: 0 vehicles";
            lblVehicleCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panelToolbar
            // 
            panelToolbar.BackColor = Color.White;
            panelToolbar.Controls.Add(btnUnderMaintenance);
            panelToolbar.Controls.Add(btnAddCategory);
            panelToolbar.Controls.Add(panelSearch);
            panelToolbar.Controls.Add(cmbStatusFilter);
            panelToolbar.Controls.Add(btnEdit);
            panelToolbar.Controls.Add(btnAdd);
            panelToolbar.Dock = DockStyle.Top;
            panelToolbar.Location = new Point(0, 70);
            panelToolbar.Name = "panelToolbar";
            panelToolbar.Padding = new Padding(15, 10, 15, 10);
            panelToolbar.Size = new Size(1491, 60);
            panelToolbar.TabIndex = 1;
            // 
            // btnUnderMaintenance
            // 
            btnUnderMaintenance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUnderMaintenance.BackColor = Color.Gold;
            btnUnderMaintenance.FlatAppearance.BorderSize = 0;
            btnUnderMaintenance.FlatStyle = FlatStyle.Flat;
            btnUnderMaintenance.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnUnderMaintenance.ForeColor = Color.White;
            btnUnderMaintenance.Location = new Point(895, 11);
            btnUnderMaintenance.Name = "btnUnderMaintenance";
            btnUnderMaintenance.Size = new Size(184, 40);
            btnUnderMaintenance.TabIndex = 9;
            btnUnderMaintenance.Text = "🔧 Maintenance";
            btnUnderMaintenance.UseVisualStyleBackColor = false;
            // 
            // btnAddCategory
            // 
            btnAddCategory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddCategory.BackColor = Color.FromArgb(128, 128, 255);
            btnAddCategory.FlatAppearance.BorderSize = 0;
            btnAddCategory.FlatStyle = FlatStyle.Flat;
            btnAddCategory.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnAddCategory.ForeColor = Color.White;
            btnAddCategory.Location = new Point(1307, 11);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(119, 40);
            btnAddCategory.TabIndex = 7;
            btnAddCategory.Text = "➕ Categories";
            btnAddCategory.UseVisualStyleBackColor = false;
            btnAddCategory.Click += btnAddCategory_Click;
            // 
            // panelSearch
            // 
            panelSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelSearch.BackColor = Color.FromArgb(248, 249, 250);
            panelSearch.BorderStyle = BorderStyle.FixedSingle;
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Location = new Point(15, 10);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(415, 40);
            panelSearch.TabIndex = 6;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(4, 8);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "🔍 Search vehicles...";
            txtSearch.Size = new Size(406, 23);
            txtSearch.TabIndex = 1;
            // 
            // cmbStatusFilter
            // 
            cmbStatusFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatusFilter.FlatStyle = FlatStyle.Flat;
            cmbStatusFilter.Font = new Font("Segoe UI", 9F);
            cmbStatusFilter.FormattingEnabled = true;
            cmbStatusFilter.Items.AddRange(new object[] { "🚗 All Vehicles", "✅ Available", "🔧 Under Maintenance", "🚗 Rented", "📅 Reserved", "♻ Retired" });
            cmbStatusFilter.Location = new Point(462, 18);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(160, 28);
            cmbStatusFilter.TabIndex = 5;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.BackColor = Color.FromArgb(243, 156, 18);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(1094, 10);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(90, 40);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "✏ Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.BackColor = Color.FromArgb(46, 204, 113);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(1191, 11);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(110, 40);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "➕ Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 130);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(panelVehicleList);
            splitContainerMain.Panel1.Controls.Add(panelStatusFilter);
            splitContainerMain.Panel1.Padding = new Padding(10);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(panelVehicleDetails);
            splitContainerMain.Panel2.Padding = new Padding(10);
            splitContainerMain.Size = new Size(1491, 670);
            splitContainerMain.SplitterDistance = 1108;
            splitContainerMain.SplitterWidth = 8;
            splitContainerMain.TabIndex = 2;
            // 
            // panelVehicleList
            // 
            panelVehicleList.BackColor = Color.White;
            panelVehicleList.Controls.Add(dgvVehicles);
            panelVehicleList.Dock = DockStyle.Fill;
            panelVehicleList.Location = new Point(10, 40);
            panelVehicleList.Name = "panelVehicleList";
            panelVehicleList.Padding = new Padding(10);
            panelVehicleList.Size = new Size(1088, 620);
            panelVehicleList.TabIndex = 1;
            // 
            // dgvVehicles
            // 
            dgvVehicles.AllowUserToAddRows = false;
            dgvVehicles.AllowUserToDeleteRows = false;
            dgvVehicles.AllowUserToResizeRows = false;
            dgvVehicles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVehicles.BackgroundColor = Color.White;
            dgvVehicles.BorderStyle = BorderStyle.None;
            dgvVehicles.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvVehicles.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(32, 191, 158);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(32, 191, 158);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvVehicles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvVehicles.ColumnHeadersHeight = 40;
            dgvVehicles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(236, 240, 241);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvVehicles.DefaultCellStyle = dataGridViewCellStyle2;
            dgvVehicles.Dock = DockStyle.Fill;
            dgvVehicles.EnableHeadersVisualStyles = false;
            dgvVehicles.GridColor = Color.WhiteSmoke;
            dgvVehicles.Location = new Point(10, 10);
            dgvVehicles.MultiSelect = false;
            dgvVehicles.Name = "dgvVehicles";
            dgvVehicles.ReadOnly = true;
            dgvVehicles.RowHeadersVisible = false;
            dgvVehicles.RowHeadersWidth = 51;
            dgvVehicles.RowTemplate.Height = 35;
            dgvVehicles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehicles.Size = new Size(1068, 600);
            dgvVehicles.TabIndex = 0;
            // 
            // panelStatusFilter
            // 
            panelStatusFilter.BackColor = Color.White;
            panelStatusFilter.Controls.Add(cmbAdvancedFilter);
            panelStatusFilter.Controls.Add(lblVehicleCount);
            panelStatusFilter.Controls.Add(lblStatusFilter);
            panelStatusFilter.Dock = DockStyle.Top;
            panelStatusFilter.Location = new Point(10, 10);
            panelStatusFilter.Name = "panelStatusFilter";
            panelStatusFilter.Size = new Size(1088, 30);
            panelStatusFilter.TabIndex = 0;
            // 
            // cmbAdvancedFilter
            // 
            cmbAdvancedFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAdvancedFilter.FlatStyle = FlatStyle.Flat;
            cmbAdvancedFilter.Font = new Font("Segoe UI", 8F);
            cmbAdvancedFilter.FormattingEnabled = true;
            cmbAdvancedFilter.Items.AddRange(new object[] { "Advanced Filters", "By Category", "By Fuel Type", "By Transmission" });
            cmbAdvancedFilter.Location = new Point(60, 3);
            cmbAdvancedFilter.Name = "cmbAdvancedFilter";
            cmbAdvancedFilter.Size = new Size(150, 25);
            cmbAdvancedFilter.TabIndex = 1;
            // 
            // lblStatusFilter
            // 
            lblStatusFilter.AutoSize = true;
            lblStatusFilter.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblStatusFilter.ForeColor = Color.FromArgb(30, 60, 90);
            lblStatusFilter.Location = new Point(10, 6);
            lblStatusFilter.Name = "lblStatusFilter";
            lblStatusFilter.Size = new Size(49, 20);
            lblStatusFilter.TabIndex = 0;
            lblStatusFilter.Text = "Filter:";
            // 
            // panelVehicleDetails
            // 
            panelVehicleDetails.BackColor = Color.White;
            panelVehicleDetails.Controls.Add(panelFeatures);
            panelVehicleDetails.Controls.Add(panelVehicleInfo);
            panelVehicleDetails.Controls.Add(panelPreviewHeader);
            panelVehicleDetails.Controls.Add(picVehiclePreview);
            panelVehicleDetails.Dock = DockStyle.Fill;
            panelVehicleDetails.Location = new Point(10, 10);
            panelVehicleDetails.Name = "panelVehicleDetails";
            panelVehicleDetails.Size = new Size(355, 650);
            panelVehicleDetails.TabIndex = 0;
            // 
            // panelFeatures
            // 
            panelFeatures.AutoScroll = true;
            panelFeatures.BackColor = Color.White;
            panelFeatures.Controls.Add(flowLayoutPanelFeatures);
            panelFeatures.Controls.Add(lblFeaturesTitle);
            panelFeatures.Dock = DockStyle.Fill;
            panelFeatures.Location = new Point(0, 530);
            panelFeatures.Name = "panelFeatures";
            panelFeatures.Padding = new Padding(10, 10, 10, 5);
            panelFeatures.Size = new Size(355, 120);
            panelFeatures.TabIndex = 7;
            // 
            // flowLayoutPanelFeatures
            // 
            flowLayoutPanelFeatures.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelFeatures.AutoScroll = true;
            flowLayoutPanelFeatures.AutoSize = true;
            flowLayoutPanelFeatures.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanelFeatures.BackColor = Color.Transparent;
            flowLayoutPanelFeatures.Location = new Point(10, 35);
            flowLayoutPanelFeatures.MaximumSize = new Size(330, 80);
            flowLayoutPanelFeatures.MinimumSize = new Size(330, 30);
            flowLayoutPanelFeatures.Name = "flowLayoutPanelFeatures";
            flowLayoutPanelFeatures.Padding = new Padding(0, 0, 0, 5);
            flowLayoutPanelFeatures.Size = new Size(330, 30);
            flowLayoutPanelFeatures.TabIndex = 1;
            // 
            // lblFeaturesTitle
            // 
            lblFeaturesTitle.AutoSize = true;
            lblFeaturesTitle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblFeaturesTitle.ForeColor = Color.FromArgb(30, 60, 90);
            lblFeaturesTitle.Location = new Point(10, 10);
            lblFeaturesTitle.Name = "lblFeaturesTitle";
            lblFeaturesTitle.Size = new Size(75, 23);
            lblFeaturesTitle.TabIndex = 0;
            lblFeaturesTitle.Text = "Features";
            // 
            // panelVehicleInfo
            // 
            panelVehicleInfo.BackColor = Color.White;
            panelVehicleInfo.Controls.Add(lblMileageValue);
            panelVehicleInfo.Controls.Add(lblMileage);
            panelVehicleInfo.Controls.Add(lblPlateValue);
            panelVehicleInfo.Controls.Add(lblPlate);
            panelVehicleInfo.Controls.Add(lblDailyRateValue);
            panelVehicleInfo.Controls.Add(lblDailyRate);
            panelVehicleInfo.Controls.Add(lblYearColorValue);
            panelVehicleInfo.Controls.Add(lblYearColor);
            panelVehicleInfo.Controls.Add(lblCategoryValue);
            panelVehicleInfo.Controls.Add(lblStatusValue);
            panelVehicleInfo.Controls.Add(lblStatus);
            panelVehicleInfo.Controls.Add(lblCategory);
            panelVehicleInfo.Controls.Add(lblMakeModel);
            panelVehicleInfo.Controls.Add(lblDetailsTitle);
            panelVehicleInfo.Dock = DockStyle.Top;
            panelVehicleInfo.Location = new Point(0, 290);
            panelVehicleInfo.Name = "panelVehicleInfo";
            panelVehicleInfo.Padding = new Padding(10);
            panelVehicleInfo.Size = new Size(355, 240);
            panelVehicleInfo.TabIndex = 6;
            // 
            // lblMileageValue
            // 
            lblMileageValue.AutoSize = true;
            lblMileageValue.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblMileageValue.ForeColor = Color.FromArgb(30, 60, 90);
            lblMileageValue.Location = new Point(85, 200);
            lblMileageValue.Name = "lblMileageValue";
            lblMileageValue.Size = new Size(79, 20);
            lblMileageValue.TabIndex = 13;
            lblMileageValue.Text = "25,450 km";
            // 
            // lblMileage
            // 
            lblMileage.AutoSize = true;
            lblMileage.Font = new Font("Segoe UI", 8.5F);
            lblMileage.ForeColor = Color.FromArgb(100, 100, 100);
            lblMileage.Location = new Point(10, 200);
            lblMileage.Name = "lblMileage";
            lblMileage.Size = new Size(66, 20);
            lblMileage.TabIndex = 12;
            lblMileage.Text = "Mileage:";
            // 
            // lblPlateValue
            // 
            lblPlateValue.AutoSize = true;
            lblPlateValue.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblPlateValue.ForeColor = Color.FromArgb(30, 60, 90);
            lblPlateValue.Location = new Point(85, 170);
            lblPlateValue.Name = "lblPlateValue";
            lblPlateValue.Size = new Size(74, 20);
            lblPlateValue.TabIndex = 11;
            lblPlateValue.Text = "ABC-1234";
            // 
            // lblPlate
            // 
            lblPlate.AutoSize = true;
            lblPlate.Font = new Font("Segoe UI", 8.5F);
            lblPlate.ForeColor = Color.FromArgb(100, 100, 100);
            lblPlate.Location = new Point(10, 170);
            lblPlate.Name = "lblPlate";
            lblPlate.Size = new Size(72, 20);
            lblPlate.TabIndex = 10;
            lblPlate.Text = "Plate No.:";
            // 
            // lblDailyRateValue
            // 
            lblDailyRateValue.AutoSize = true;
            lblDailyRateValue.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblDailyRateValue.ForeColor = Color.FromArgb(46, 204, 113);
            lblDailyRateValue.Location = new Point(85, 140);
            lblDailyRateValue.Name = "lblDailyRateValue";
            lblDailyRateValue.Size = new Size(53, 20);
            lblDailyRateValue.TabIndex = 9;
            lblDailyRateValue.Text = "$65.00";
            // 
            // lblDailyRate
            // 
            lblDailyRate.AutoSize = true;
            lblDailyRate.Font = new Font("Segoe UI", 8.5F);
            lblDailyRate.ForeColor = Color.FromArgb(100, 100, 100);
            lblDailyRate.Location = new Point(10, 140);
            lblDailyRate.Name = "lblDailyRate";
            lblDailyRate.Size = new Size(80, 20);
            lblDailyRate.TabIndex = 8;
            lblDailyRate.Text = "Daily Rate:";
            // 
            // lblYearColorValue
            // 
            lblYearColorValue.AutoSize = true;
            lblYearColorValue.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblYearColorValue.ForeColor = Color.FromArgb(30, 60, 90);
            lblYearColorValue.Location = new Point(85, 110);
            lblYearColorValue.Name = "lblYearColorValue";
            lblYearColorValue.Size = new Size(74, 20);
            lblYearColorValue.TabIndex = 7;
            lblYearColorValue.Text = "2024/Red";
            // 
            // lblYearColor
            // 
            lblYearColor.AutoSize = true;
            lblYearColor.Font = new Font("Segoe UI", 8.5F);
            lblYearColor.ForeColor = Color.FromArgb(100, 100, 100);
            lblYearColor.Location = new Point(10, 110);
            lblYearColor.Name = "lblYearColor";
            lblYearColor.Size = new Size(82, 20);
            lblYearColor.TabIndex = 6;
            lblYearColor.Text = "Year/Color:";
            // 
            // lblCategoryValue
            // 
            lblCategoryValue.AutoSize = true;
            lblCategoryValue.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblCategoryValue.ForeColor = Color.FromArgb(30, 60, 90);
            lblCategoryValue.Location = new Point(85, 80);
            lblCategoryValue.Name = "lblCategoryValue";
            lblCategoryValue.Size = new Size(51, 20);
            lblCategoryValue.TabIndex = 5;
            lblCategoryValue.Text = "Sedan";
            // 
            // lblStatusValue
            // 
            lblStatusValue.AutoSize = true;
            lblStatusValue.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblStatusValue.ForeColor = Color.FromArgb(231, 76, 60);
            lblStatusValue.Location = new Point(85, 50);
            lblStatusValue.Name = "lblStatusValue";
            lblStatusValue.Size = new Size(57, 20);
            lblStatusValue.TabIndex = 4;
            lblStatusValue.Text = "Rented";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 8.5F);
            lblStatus.ForeColor = Color.FromArgb(100, 100, 100);
            lblStatus.Location = new Point(10, 50);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(52, 20);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Status:";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 8.5F);
            lblCategory.ForeColor = Color.FromArgb(100, 100, 100);
            lblCategory.Location = new Point(10, 80);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(72, 20);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Category:";
            // 
            // lblMakeModel
            // 
            lblMakeModel.AutoSize = true;
            lblMakeModel.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblMakeModel.ForeColor = Color.FromArgb(44, 62, 80);
            lblMakeModel.Location = new Point(10, 15);
            lblMakeModel.Name = "lblMakeModel";
            lblMakeModel.Size = new Size(131, 25);
            lblMakeModel.TabIndex = 1;
            lblMakeModel.Text = "Toyota Camry";
            // 
            // lblDetailsTitle
            // 
            lblDetailsTitle.AutoSize = true;
            lblDetailsTitle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblDetailsTitle.ForeColor = Color.FromArgb(30, 60, 90);
            lblDetailsTitle.Location = new Point(10, -10);
            lblDetailsTitle.Name = "lblDetailsTitle";
            lblDetailsTitle.Size = new Size(0, 23);
            lblDetailsTitle.TabIndex = 0;
            // 
            // panelPreviewHeader
            // 
            panelPreviewHeader.BackColor = Color.FromArgb(248, 249, 250);
            panelPreviewHeader.Controls.Add(lblVehicleDetails);
            panelPreviewHeader.Dock = DockStyle.Top;
            panelPreviewHeader.Location = new Point(0, 250);
            panelPreviewHeader.Name = "panelPreviewHeader";
            panelPreviewHeader.Size = new Size(355, 40);
            panelPreviewHeader.TabIndex = 5;
            // 
            // lblVehicleDetails
            // 
            lblVehicleDetails.Dock = DockStyle.Fill;
            lblVehicleDetails.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblVehicleDetails.ForeColor = Color.FromArgb(30, 60, 90);
            lblVehicleDetails.Location = new Point(0, 0);
            lblVehicleDetails.Name = "lblVehicleDetails";
            lblVehicleDetails.Size = new Size(355, 40);
            lblVehicleDetails.TabIndex = 0;
            lblVehicleDetails.Text = "🚗 Vehicle Details";
            lblVehicleDetails.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picVehiclePreview
            // 
            picVehiclePreview.BackColor = Color.White;
            picVehiclePreview.BorderStyle = BorderStyle.FixedSingle;
            picVehiclePreview.Dock = DockStyle.Top;
            picVehiclePreview.Location = new Point(0, 0);
            picVehiclePreview.Name = "picVehiclePreview";
            picVehiclePreview.Size = new Size(355, 250);
            picVehiclePreview.SizeMode = PictureBoxSizeMode.Zoom;
            picVehiclePreview.TabIndex = 0;
            picVehiclePreview.TabStop = false;
            // 
            // VehiclesView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(splitContainerMain);
            Controls.Add(panelToolbar);
            Controls.Add(panelHeader);
            Name = "VehiclesView";
            Size = new Size(1491, 800);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelToolbar.ResumeLayout(false);
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            panelVehicleList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVehicles).EndInit();
            panelStatusFilter.ResumeLayout(false);
            panelStatusFilter.PerformLayout();
            panelVehicleDetails.ResumeLayout(false);
            panelFeatures.ResumeLayout(false);
            panelFeatures.PerformLayout();
            panelVehicleInfo.ResumeLayout(false);
            panelVehicleInfo.PerformLayout();
            panelPreviewHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picVehiclePreview).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label label1;
        private Panel panelToolbar;
        private SplitContainer splitContainerMain;
        private Panel panelVehicleList;
        private DataGridView dgvVehicles;
        private Panel panelVehicleDetails;
        private PictureBox picVehiclePreview;
        private Panel panelStatusFilter;
        private Label lblStatusFilter;
        private Button btnAdd;
        private Button btnEdit;
        private ComboBox cmbStatusFilter;
        private Panel panelSearch;
        private TextBox txtSearch;
        private Label lblVehicleCount;
        private Panel panelPreviewHeader;
        private Label lblVehicleDetails;
        private Panel panelVehicleInfo;
        private Label lblMakeModel;
        private Label lblDetailsTitle;
        private Label lblMileageValue;
        private Label lblMileage;
        private Label lblPlateValue;
        private Label lblPlate;
        private Label lblDailyRateValue;
        private Label lblDailyRate;
        private Label lblYearColorValue;
        private Label lblYearColor;
        private Label lblCategoryValue;
        private Label lblStatusValue;
        private Label lblStatus;
        private Label lblCategory;
        private Panel panelFeatures;
        private Label lblFeaturesTitle;
        private FlowLayoutPanel flowLayoutPanelFeatures;
        private Button btnAddCategory;
        private ComboBox cmbAdvancedFilter;
        private Button btnUnderMaintenance;
    }
}