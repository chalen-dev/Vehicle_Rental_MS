namespace VRMS.UI.Controls.CustomerVehicleCatalog
{
    partial class CustomerVehicleCatalog
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // ===== HEADER =====
        private Panel panelHeader;
        private Label lblTitle;
        private Label lblVehicleCount;

        // ===== TOOLBAR =====
        private Panel panelToolbar;
        private Panel panelSearch;
        private TextBox txtSearch;
        private ComboBox cmbSort;
        private CheckBox chkAvailableOnly;
        private Button btnRent;

        // ===== MAIN SPLIT =====
        private SplitContainer splitContainerMain;

        // LEFT – VEHICLE LIST
        private Panel panelVehicleList;
        private DataGridView dgvVehicles;
        private Panel panelFilterBar;
        private Label lblStatusFilter;
        private ComboBox cmbStatus;
        private Label lblCategoryFilter;
        private ComboBox cmbCategory;
        private Button btnClearFilters;

        // RIGHT – PREVIEW
        private Panel panelVehicleDetails;
        private Panel panelPreviewHeader;
        private Label lblVehicleDetails;
        private PictureBox picVehicle;
        private Panel panelVehicleInfo;
        private Label lblMakeModel;
        private Label lblStatusTitle;
        private Label lblStatusValue;
        private Label lblCategoryTitle;
        private Label lblCategoryValue;
        private Label lblRateTitle;
        private Label lblRateValue;
        private Label lblPlateTitle;
        private Label lblPlateValue;
        private Label lblYearTitle;
        private Label lblYearValue;
        private Button btnRentNow;
        private Panel panelNoSelection;
        private Label lblNoSelection;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblVehicleCount = new System.Windows.Forms.Label();
            this.panelToolbar = new System.Windows.Forms.Panel();
            this.btnRent = new System.Windows.Forms.Button();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.chkAvailableOnly = new System.Windows.Forms.CheckBox();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.panelVehicleList = new System.Windows.Forms.Panel();
            this.dgvVehicles = new System.Windows.Forms.DataGridView();
            this.panelFilterBar = new System.Windows.Forms.Panel();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategoryFilter = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatusFilter = new System.Windows.Forms.Label();
            this.panelVehicleDetails = new System.Windows.Forms.Panel();
            this.btnRentNow = new System.Windows.Forms.Button();
            this.panelVehicleInfo = new System.Windows.Forms.Panel();
            this.lblYearValue = new System.Windows.Forms.Label();
            this.lblYearTitle = new System.Windows.Forms.Label();
            this.lblPlateValue = new System.Windows.Forms.Label();
            this.lblPlateTitle = new System.Windows.Forms.Label();
            this.lblRateValue = new System.Windows.Forms.Label();
            this.lblRateTitle = new System.Windows.Forms.Label();
            this.lblCategoryValue = new System.Windows.Forms.Label();
            this.lblCategoryTitle = new System.Windows.Forms.Label();
            this.lblStatusValue = new System.Windows.Forms.Label();
            this.lblStatusTitle = new System.Windows.Forms.Label();
            this.lblMakeModel = new System.Windows.Forms.Label();
            this.panelPreviewHeader = new System.Windows.Forms.Panel();
            this.lblVehicleDetails = new System.Windows.Forms.Label();
            this.picVehicle = new System.Windows.Forms.PictureBox();
            this.panelNoSelection = new System.Windows.Forms.Panel();
            this.lblNoSelection = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelToolbar.SuspendLayout();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.panelVehicleList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).BeginInit();
            this.panelFilterBar.SuspendLayout();
            this.panelVehicleDetails.SuspendLayout();
            this.panelVehicleInfo.SuspendLayout();
            this.panelPreviewHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVehicle)).BeginInit();
            this.panelNoSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.lblVehicleCount);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1200, 70);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(225, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🚗 Vehicle Catalog";
            // 
            // lblVehicleCount
            // 
            this.lblVehicleCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVehicleCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblVehicleCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblVehicleCount.Location = new System.Drawing.Point(990, 15);
            this.lblVehicleCount.Name = "lblVehicleCount";
            this.lblVehicleCount.Size = new System.Drawing.Size(180, 40);
            this.lblVehicleCount.TabIndex = 1;
            this.lblVehicleCount.Text = "Total: 0 vehicles";
            this.lblVehicleCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelToolbar
            // 
            this.panelToolbar.BackColor = System.Drawing.Color.White;
            this.panelToolbar.Controls.Add(this.btnRent);
            this.panelToolbar.Controls.Add(this.panelSearch);
            this.panelToolbar.Controls.Add(this.cmbSort);
            this.panelToolbar.Controls.Add(this.chkAvailableOnly);
            this.panelToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolbar.Location = new System.Drawing.Point(0, 70);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.panelToolbar.Size = new System.Drawing.Size(1200, 60);
            this.panelToolbar.TabIndex = 1;
            // 
            // btnRent
            // 
            this.btnRent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnRent.FlatAppearance.BorderSize = 0;
            this.btnRent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRent.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRent.ForeColor = System.Drawing.Color.White;
            this.btnRent.Location = new System.Drawing.Point(1075, 10);
            this.btnRent.Name = "btnRent";
            this.btnRent.Size = new System.Drawing.Size(110, 40);
            this.btnRent.TabIndex = 7;
            this.btnRent.Text = "\U0001f6d2 Rent Now";
            this.btnRent.UseVisualStyleBackColor = false;
            // 
            // panelSearch
            // 
            this.panelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSearch.Controls.Add(this.txtSearch);
            this.panelSearch.Location = new System.Drawing.Point(15, 10);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(350, 40);
            this.panelSearch.TabIndex = 6;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearch.Location = new System.Drawing.Point(15, 8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "🔍 Search vehicles...";
            this.txtSearch.Size = new System.Drawing.Size(320, 23);
            this.txtSearch.TabIndex = 1;
            // 
            // cmbSort
            // 
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbSort.FormattingEnabled = true;
            this.cmbSort.Items.AddRange(new object[] {
            "🔤 Name (A-Z)",
            "🔤 Name (Z-A)",
            "💰 Price (Low to High)",
            "💰 Price (High to Low)",
            "📅 Year (Newest First)",
            "📅 Year (Oldest First)"});
            this.cmbSort.Location = new System.Drawing.Point(390, 18);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(200, 28);
            this.cmbSort.TabIndex = 5;
            // 
            // chkAvailableOnly
            // 
            this.chkAvailableOnly.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkAvailableOnly.Location = new System.Drawing.Point(610, 18);
            this.chkAvailableOnly.Name = "chkAvailableOnly";
            this.chkAvailableOnly.Size = new System.Drawing.Size(180, 25);
            this.chkAvailableOnly.TabIndex = 2;
            this.chkAvailableOnly.Text = "✅ Available only";
            this.chkAvailableOnly.UseVisualStyleBackColor = true;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 130);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.panelVehicleList);
            this.splitContainerMain.Panel1.Controls.Add(this.panelFilterBar);
            this.splitContainerMain.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.panelVehicleDetails);
            this.splitContainerMain.Panel2.Controls.Add(this.panelNoSelection);
            this.splitContainerMain.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainerMain.Size = new System.Drawing.Size(1200, 670);
            this.splitContainerMain.SplitterDistance = 840;
            this.splitContainerMain.SplitterWidth = 1;
            this.splitContainerMain.TabIndex = 2;
            // 
            // panelVehicleList
            // 
            this.panelVehicleList.BackColor = System.Drawing.Color.White;
            this.panelVehicleList.Controls.Add(this.dgvVehicles);
            this.panelVehicleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVehicleList.Location = new System.Drawing.Point(10, 40);
            this.panelVehicleList.Name = "panelVehicleList";
            this.panelVehicleList.Padding = new System.Windows.Forms.Padding(10);
            this.panelVehicleList.Size = new System.Drawing.Size(820, 620);
            this.panelVehicleList.TabIndex = 1;
            // 
            // dgvVehicles
            // 
            this.dgvVehicles.AllowUserToAddRows = false;
            this.dgvVehicles.AllowUserToDeleteRows = false;
            this.dgvVehicles.AllowUserToResizeRows = false;
            this.dgvVehicles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVehicles.BackgroundColor = System.Drawing.Color.White;
            this.dgvVehicles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVehicles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvVehicles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVehicles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVehicles.ColumnHeadersHeight = 40;
            this.dgvVehicles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVehicles.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVehicles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVehicles.EnableHeadersVisualStyles = false;
            this.dgvVehicles.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvVehicles.Location = new System.Drawing.Point(10, 10);
            this.dgvVehicles.MultiSelect = false;
            this.dgvVehicles.Name = "dgvVehicles";
            this.dgvVehicles.ReadOnly = true;
            this.dgvVehicles.RowHeadersVisible = false;
            this.dgvVehicles.RowHeadersWidth = 51;
            this.dgvVehicles.RowTemplate.Height = 35;
            this.dgvVehicles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVehicles.Size = new System.Drawing.Size(800, 600);
            this.dgvVehicles.TabIndex = 0;
            // 
            // panelFilterBar
            // 
            this.panelFilterBar.BackColor = System.Drawing.Color.White;
            this.panelFilterBar.Controls.Add(this.btnClearFilters);
            this.panelFilterBar.Controls.Add(this.cmbCategory);
            this.panelFilterBar.Controls.Add(this.lblCategoryFilter);
            this.panelFilterBar.Controls.Add(this.cmbStatus);
            this.panelFilterBar.Controls.Add(this.lblStatusFilter);
            this.panelFilterBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilterBar.Location = new System.Drawing.Point(10, 10);
            this.panelFilterBar.Name = "panelFilterBar";
            this.panelFilterBar.Size = new System.Drawing.Size(820, 30);
            this.panelFilterBar.TabIndex = 0;
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilters.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClearFilters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnClearFilters.Location = new System.Drawing.Point(690, 3);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(120, 25);
            this.btnClearFilters.TabIndex = 4;
            this.btnClearFilters.Text = "Clear Filters";
            this.btnClearFilters.UseVisualStyleBackColor = true;
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "🚗 All Categories",
            "🏎️ Sports Car",
            "🚙 SUV",
            "🚗 Sedan",
            "🚐 Van",
            "🚚 Truck",
            "🛵 Motorcycle"});
            this.cmbCategory.Location = new System.Drawing.Point(360, 3);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(150, 25);
            this.cmbCategory.TabIndex = 3;
            // 
            // lblCategoryFilter
            // 
            this.lblCategoryFilter.AutoSize = true;
            this.lblCategoryFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCategoryFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.lblCategoryFilter.Location = new System.Drawing.Point(290, 6);
            this.lblCategoryFilter.Name = "lblCategoryFilter";
            this.lblCategoryFilter.Size = new System.Drawing.Size(72, 20);
            this.lblCategoryFilter.TabIndex = 2;
            this.lblCategoryFilter.Text = "Category:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "📋 All Status",
            "✅ Available",
            "🔧 Under Maintenance",
            "🚗 Rented",
            "📅 Reserved"});
            this.cmbStatus.Location = new System.Drawing.Point(60, 3);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 25);
            this.cmbStatus.TabIndex = 1;
            // 
            // lblStatusFilter
            // 
            this.lblStatusFilter.AutoSize = true;
            this.lblStatusFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStatusFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.lblStatusFilter.Location = new System.Drawing.Point(10, 6);
            this.lblStatusFilter.Name = "lblStatusFilter";
            this.lblStatusFilter.Size = new System.Drawing.Size(52, 20);
            this.lblStatusFilter.TabIndex = 0;
            this.lblStatusFilter.Text = "Status:";
            // 
            // panelVehicleDetails
            // 
            this.panelVehicleDetails.BackColor = System.Drawing.Color.White;
            this.panelVehicleDetails.Controls.Add(this.btnRentNow);
            this.panelVehicleDetails.Controls.Add(this.panelVehicleInfo);
            this.panelVehicleDetails.Controls.Add(this.panelPreviewHeader);
            this.panelVehicleDetails.Controls.Add(this.picVehicle);
            this.panelVehicleDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVehicleDetails.Location = new System.Drawing.Point(10, 10);
            this.panelVehicleDetails.Name = "panelVehicleDetails";
            this.panelVehicleDetails.Size = new System.Drawing.Size(329, 650);
            this.panelVehicleDetails.TabIndex = 0;
            this.panelVehicleDetails.Visible = false;
            // 
            // btnRentNow
            // 
            this.btnRentNow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnRentNow.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRentNow.FlatAppearance.BorderSize = 0;
            this.btnRentNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRentNow.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRentNow.ForeColor = System.Drawing.Color.White;
            this.btnRentNow.Location = new System.Drawing.Point(0, 610);
            this.btnRentNow.Name = "btnRentNow";
            this.btnRentNow.Size = new System.Drawing.Size(329, 40);
            this.btnRentNow.TabIndex = 8;
            this.btnRentNow.Text = "\U0001f6d2 Rent Now";
            this.btnRentNow.UseVisualStyleBackColor = false;
            // 
            // panelVehicleInfo
            // 
            this.panelVehicleInfo.BackColor = System.Drawing.Color.White;
            this.panelVehicleInfo.Controls.Add(this.lblYearValue);
            this.panelVehicleInfo.Controls.Add(this.lblYearTitle);
            this.panelVehicleInfo.Controls.Add(this.lblPlateValue);
            this.panelVehicleInfo.Controls.Add(this.lblPlateTitle);
            this.panelVehicleInfo.Controls.Add(this.lblRateValue);
            this.panelVehicleInfo.Controls.Add(this.lblRateTitle);
            this.panelVehicleInfo.Controls.Add(this.lblCategoryValue);
            this.panelVehicleInfo.Controls.Add(this.lblCategoryTitle);
            this.panelVehicleInfo.Controls.Add(this.lblStatusValue);
            this.panelVehicleInfo.Controls.Add(this.lblStatusTitle);
            this.panelVehicleInfo.Controls.Add(this.lblMakeModel);
            this.panelVehicleInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelVehicleInfo.Location = new System.Drawing.Point(0, 290);
            this.panelVehicleInfo.Name = "panelVehicleInfo";
            this.panelVehicleInfo.Padding = new System.Windows.Forms.Padding(10);
            this.panelVehicleInfo.Size = new System.Drawing.Size(329, 240);
            this.panelVehicleInfo.TabIndex = 7;
            // 
            // lblYearValue
            // 
            this.lblYearValue.AutoSize = true;
            this.lblYearValue.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblYearValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.lblYearValue.Location = new System.Drawing.Point(85, 170);
            this.lblYearValue.Name = "lblYearValue";
            this.lblYearValue.Size = new System.Drawing.Size(37, 20);
            this.lblYearValue.TabIndex = 11;
            this.lblYearValue.Text = "2023";
            // 
            // lblYearTitle
            // 
            this.lblYearTitle.AutoSize = true;
            this.lblYearTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblYearTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblYearTitle.Location = new System.Drawing.Point(10, 170);
            this.lblYearTitle.Name = "lblYearTitle";
            this.lblYearTitle.Size = new System.Drawing.Size(42, 20);
            this.lblYearTitle.TabIndex = 10;
            this.lblYearTitle.Text = "Year:";
            // 
            // lblPlateValue
            // 
            this.lblPlateValue.AutoSize = true;
            this.lblPlateValue.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPlateValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.lblPlateValue.Location = new System.Drawing.Point(85, 140);
            this.lblPlateValue.Name = "lblPlateValue";
            this.lblPlateValue.Size = new System.Drawing.Size(74, 20);
            this.lblPlateValue.TabIndex = 9;
            this.lblPlateValue.Text = "ABC-1234";
            // 
            // lblPlateTitle
            // 
            this.lblPlateTitle.AutoSize = true;
            this.lblPlateTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPlateTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblPlateTitle.Location = new System.Drawing.Point(10, 140);
            this.lblPlateTitle.Name = "lblPlateTitle";
            this.lblPlateTitle.Size = new System.Drawing.Size(72, 20);
            this.lblPlateTitle.TabIndex = 8;
            this.lblPlateTitle.Text = "Plate No.:";
            // 
            // lblRateValue
            // 
            this.lblRateValue.AutoSize = true;
            this.lblRateValue.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblRateValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblRateValue.Location = new System.Drawing.Point(85, 110);
            this.lblRateValue.Name = "lblRateValue";
            this.lblRateValue.Size = new System.Drawing.Size(80, 20);
            this.lblRateValue.TabIndex = 7;
            this.lblRateValue.Text = "₱2,500/day";
            // 
            // lblRateTitle
            // 
            this.lblRateTitle.AutoSize = true;
            this.lblRateTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblRateTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblRateTitle.Location = new System.Drawing.Point(10, 110);
            this.lblRateTitle.Name = "lblRateTitle";
            this.lblRateTitle.Size = new System.Drawing.Size(80, 20);
            this.lblRateTitle.TabIndex = 6;
            this.lblRateTitle.Text = "Daily Rate:";
            // 
            // lblCategoryValue
            // 
            this.lblCategoryValue.AutoSize = true;
            this.lblCategoryValue.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCategoryValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.lblCategoryValue.Location = new System.Drawing.Point(85, 80);
            this.lblCategoryValue.Name = "lblCategoryValue";
            this.lblCategoryValue.Size = new System.Drawing.Size(51, 20);
            this.lblCategoryValue.TabIndex = 5;
            this.lblCategoryValue.Text = "Sedan";
            // 
            // lblCategoryTitle
            // 
            this.lblCategoryTitle.AutoSize = true;
            this.lblCategoryTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCategoryTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblCategoryTitle.Location = new System.Drawing.Point(10, 80);
            this.lblCategoryTitle.Name = "lblCategoryTitle";
            this.lblCategoryTitle.Size = new System.Drawing.Size(72, 20);
            this.lblCategoryTitle.TabIndex = 4;
            this.lblCategoryTitle.Text = "Category:";
            // 
            // lblStatusValue
            // 
            this.lblStatusValue.AutoSize = true;
            this.lblStatusValue.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStatusValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblStatusValue.Location = new System.Drawing.Point(85, 50);
            this.lblStatusValue.Name = "lblStatusValue";
            this.lblStatusValue.Size = new System.Drawing.Size(70, 20);
            this.lblStatusValue.TabIndex = 3;
            this.lblStatusValue.Text = "Available";
            // 
            // lblStatusTitle
            // 
            this.lblStatusTitle.AutoSize = true;
            this.lblStatusTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStatusTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblStatusTitle.Location = new System.Drawing.Point(10, 50);
            this.lblStatusTitle.Name = "lblStatusTitle";
            this.lblStatusTitle.Size = new System.Drawing.Size(52, 20);
            this.lblStatusTitle.TabIndex = 2;
            this.lblStatusTitle.Text = "Status:";
            // 
            // lblMakeModel
            // 
            this.lblMakeModel.AutoSize = true;
            this.lblMakeModel.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblMakeModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblMakeModel.Location = new System.Drawing.Point(10, 15);
            this.lblMakeModel.Name = "lblMakeModel";
            this.lblMakeModel.Size = new System.Drawing.Size(131, 25);
            this.lblMakeModel.TabIndex = 1;
            this.lblMakeModel.Text = "Toyota Camry";
            // 
            // panelPreviewHeader
            // 
            this.panelPreviewHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelPreviewHeader.Controls.Add(this.lblVehicleDetails);
            this.panelPreviewHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPreviewHeader.Location = new System.Drawing.Point(0, 250);
            this.panelPreviewHeader.Name = "panelPreviewHeader";
            this.panelPreviewHeader.Size = new System.Drawing.Size(329, 40);
            this.panelPreviewHeader.TabIndex = 6;
            // 
            // lblVehicleDetails
            // 
            this.lblVehicleDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVehicleDetails.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblVehicleDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.lblVehicleDetails.Location = new System.Drawing.Point(0, 0);
            this.lblVehicleDetails.Name = "lblVehicleDetails";
            this.lblVehicleDetails.Size = new System.Drawing.Size(329, 40);
            this.lblVehicleDetails.TabIndex = 0;
            this.lblVehicleDetails.Text = "🚗 Vehicle Details";
            this.lblVehicleDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picVehicle
            // 
            this.picVehicle.BackColor = System.Drawing.Color.White;
            this.picVehicle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picVehicle.Dock = System.Windows.Forms.DockStyle.Top;
            this.picVehicle.Location = new System.Drawing.Point(0, 0);
            this.picVehicle.Name = "picVehicle";
            this.picVehicle.Size = new System.Drawing.Size(329, 250);
            this.picVehicle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picVehicle.TabIndex = 0;
            this.picVehicle.TabStop = false;
            // 
            // panelNoSelection
            // 
            this.panelNoSelection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelNoSelection.Controls.Add(this.lblNoSelection);
            this.panelNoSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNoSelection.Location = new System.Drawing.Point(10, 10);
            this.panelNoSelection.Name = "panelNoSelection";
            this.panelNoSelection.Size = new System.Drawing.Size(329, 650);
            this.panelNoSelection.TabIndex = 1;
            // 
            // lblNoSelection
            // 
            this.lblNoSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNoSelection.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNoSelection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblNoSelection.Location = new System.Drawing.Point(0, 0);
            this.lblNoSelection.Name = "lblNoSelection";
            this.lblNoSelection.Size = new System.Drawing.Size(329, 650);
            this.lblNoSelection.TabIndex = 0;
            this.lblNoSelection.Text = "Select a vehicle to view details";
            this.lblNoSelection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CustomerVehicleCatalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.panelToolbar);
            this.Controls.Add(this.panelHeader);
            this.Name = "CustomerVehicleCatalog";
            this.Size = new System.Drawing.Size(1200, 800);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelToolbar.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.panelVehicleList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).EndInit();
            this.panelFilterBar.ResumeLayout(false);
            this.panelFilterBar.PerformLayout();
            this.panelVehicleDetails.ResumeLayout(false);
            this.panelVehicleInfo.ResumeLayout(false);
            this.panelVehicleInfo.PerformLayout();
            this.panelPreviewHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picVehicle)).EndInit();
            this.panelNoSelection.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}