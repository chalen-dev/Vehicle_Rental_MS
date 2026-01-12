namespace VRMS.Controls
{
    partial class CustomersRentalsView
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvRentals = new System.Windows.Forms.DataGridView();
            this.lblEmpty = new System.Windows.Forms.Label();
            this.lblLoading = new System.Windows.Forms.Label();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlSidebarContent = new System.Windows.Forms.Panel();
            this.lblSidebarTitle = new System.Windows.Forms.Label();
            this.pnlPagination = new System.Windows.Forms.Panel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnViewReceipt = new System.Windows.Forms.Button();
            this.btnExtendRental = new System.Windows.Forms.Button();
            this.btnReportDamage = new System.Windows.Forms.Button();
            this.btnReturnVehicle = new System.Windows.Forms.Button();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.chkActiveOnly = new System.Windows.Forms.CheckBox();
            this.cmbSortBy = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblFilterBy = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnNewRental = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.ctxMenuRental = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuViewDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReturnVehicle = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportDamage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExtendRental = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewReceipt = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddReview = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuPrintDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExportDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentals)).BeginInit();
            this.pnlSidebar.SuspendLayout();
            this.pnlPagination.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.ctxMenuRental.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlContent);
            this.pnlMain.Controls.Add(this.pnlSidebar);
            this.pnlMain.Controls.Add(this.pnlPagination);
            this.pnlMain.Controls.Add(this.pnlActions);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 140);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1200, 660);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.dgvRentals);
            this.pnlContent.Controls.Add(this.lblEmpty);
            this.pnlContent.Controls.Add(this.lblLoading);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(0, 0, 320, 0);
            this.pnlContent.Size = new System.Drawing.Size(880, 520);
            this.pnlContent.TabIndex = 0;
            // 
            // dgvRentals
            // 
            this.dgvRentals.AllowUserToAddRows = false;
            this.dgvRentals.AllowUserToDeleteRows = false;
            this.dgvRentals.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.dgvRentals.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRentals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRentals.BackgroundColor = System.Drawing.Color.White;
            this.dgvRentals.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRentals.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRentals.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRentals.ColumnHeadersHeight = 50;
            this.dgvRentals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRentals.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRentals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRentals.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.dgvRentals.Location = new System.Drawing.Point(0, 0);
            this.dgvRentals.MultiSelect = false;
            this.dgvRentals.Name = "dgvRentals";
            this.dgvRentals.ReadOnly = true;
            this.dgvRentals.RowHeadersVisible = false;
            this.dgvRentals.RowTemplate.Height = 45;
            this.dgvRentals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRentals.Size = new System.Drawing.Size(560, 520);
            this.dgvRentals.TabIndex = 0;
            // 
            // lblEmpty
            // 
            this.lblEmpty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmpty.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblEmpty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblEmpty.Location = new System.Drawing.Point(0, 0);
            this.lblEmpty.Name = "lblEmpty";
            this.lblEmpty.Padding = new System.Windows.Forms.Padding(0, 100, 0, 0);
            this.lblEmpty.Size = new System.Drawing.Size(560, 520);
            this.lblEmpty.TabIndex = 1;
            this.lblEmpty.Text = "No rental records found\r\nStart by renting a vehicle!";
            this.lblEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEmpty.Visible = false;
            // 
            // lblLoading
            // 
            this.lblLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoading.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblLoading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblLoading.Location = new System.Drawing.Point(0, 0);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(560, 520);
            this.lblLoading.TabIndex = 2;
            this.lblLoading.Text = "Loading your rentals...";
            this.lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLoading.Visible = false;
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.White;
            this.pnlSidebar.Controls.Add(this.pnlSidebarContent);
            this.pnlSidebar.Controls.Add(this.lblSidebarTitle);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSidebar.Location = new System.Drawing.Point(880, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(320, 520);
            this.pnlSidebar.TabIndex = 1;
            // 
            // pnlSidebarContent
            // 
            this.pnlSidebarContent.AutoScroll = true;
            this.pnlSidebarContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSidebarContent.Location = new System.Drawing.Point(0, 50);
            this.pnlSidebarContent.Name = "pnlSidebarContent";
            this.pnlSidebarContent.Padding = new System.Windows.Forms.Padding(20, 10, 20, 20);
            this.pnlSidebarContent.Size = new System.Drawing.Size(320, 470);
            this.pnlSidebarContent.TabIndex = 1;
            // 
            // lblSidebarTitle
            // 
            this.lblSidebarTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSidebarTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSidebarTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblSidebarTitle.Location = new System.Drawing.Point(0, 0);
            this.lblSidebarTitle.Name = "lblSidebarTitle";
            this.lblSidebarTitle.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblSidebarTitle.Size = new System.Drawing.Size(320, 50);
            this.lblSidebarTitle.TabIndex = 0;
            this.lblSidebarTitle.Text = "Rental Details";
            this.lblSidebarTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlPagination
            // 
            this.pnlPagination.Controls.Add(this.btnPrev);
            this.pnlPagination.Controls.Add(this.lblPageInfo);
            this.pnlPagination.Controls.Add(this.btnNext);
            this.pnlPagination.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPagination.Location = new System.Drawing.Point(0, 520);
            this.pnlPagination.Name = "pnlPagination";
            this.pnlPagination.Size = new System.Drawing.Size(1200, 60);
            this.pnlPagination.TabIndex = 2;
            // 
            // btnPrev
            // 
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPrev.Location = new System.Drawing.Point(20, 15);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(100, 30);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "← Previous";
            this.btnPrev.UseVisualStyleBackColor = true;
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPageInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblPageInfo.Location = new System.Drawing.Point(550, 20);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(67, 19);
            this.lblPageInfo.TabIndex = 1;
            this.lblPageInfo.Text = "Page 1 of 1";
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNext.Location = new System.Drawing.Point(1080, 15);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 30);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next →";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.btnViewReceipt);
            this.pnlActions.Controls.Add(this.btnExtendRental);
            this.pnlActions.Controls.Add(this.btnReportDamage);
            this.pnlActions.Controls.Add(this.btnReturnVehicle);
            this.pnlActions.Controls.Add(this.btnViewDetails);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Location = new System.Drawing.Point(0, 580);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(1200, 80);
            this.pnlActions.TabIndex = 3;
            // 
            // btnViewReceipt
            // 
            this.btnViewReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewReceipt.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewReceipt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(66)))), ((int)(((byte)(193)))));
            this.btnViewReceipt.Location = new System.Drawing.Point(560, 15);
            this.btnViewReceipt.Name = "btnViewReceipt";
            this.btnViewReceipt.Size = new System.Drawing.Size(120, 40);
            this.btnViewReceipt.TabIndex = 4;
            this.btnViewReceipt.Text = "Receipt";
            this.btnViewReceipt.UseVisualStyleBackColor = true;
            // 
            // btnExtendRental
            // 
            this.btnExtendRental.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExtendRental.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExtendRental.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnExtendRental.Location = new System.Drawing.Point(430, 15);
            this.btnExtendRental.Name = "btnExtendRental";
            this.btnExtendRental.Size = new System.Drawing.Size(120, 40);
            this.btnExtendRental.TabIndex = 3;
            this.btnExtendRental.Text = "Extend";
            this.btnExtendRental.UseVisualStyleBackColor = true;
            // 
            // btnReportDamage
            // 
            this.btnReportDamage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportDamage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReportDamage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnReportDamage.Location = new System.Drawing.Point(300, 15);
            this.btnReportDamage.Name = "btnReportDamage";
            this.btnReportDamage.Size = new System.Drawing.Size(120, 40);
            this.btnReportDamage.TabIndex = 2;
            this.btnReportDamage.Text = "Damage";
            this.btnReportDamage.UseVisualStyleBackColor = true;
            // 
            // btnReturnVehicle
            // 
            this.btnReturnVehicle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnVehicle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReturnVehicle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnReturnVehicle.Location = new System.Drawing.Point(170, 15);
            this.btnReturnVehicle.Name = "btnReturnVehicle";
            this.btnReturnVehicle.Size = new System.Drawing.Size(120, 40);
            this.btnReturnVehicle.TabIndex = 1;
            this.btnReturnVehicle.Text = "Return";
            this.btnReturnVehicle.UseVisualStyleBackColor = true;
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnViewDetails.Location = new System.Drawing.Point(20, 15);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(140, 40);
            this.btnViewDetails.TabIndex = 0;
            this.btnViewDetails.Text = "View Details";
            this.btnViewDetails.UseVisualStyleBackColor = true;
            // 
            // pnlFilters
            // 
            this.pnlFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlFilters.Controls.Add(this.btnClearFilters);
            this.pnlFilters.Controls.Add(this.chkActiveOnly);
            this.pnlFilters.Controls.Add(this.cmbSortBy);
            this.pnlFilters.Controls.Add(this.cmbStatus);
            this.pnlFilters.Controls.Add(this.lblFilterBy);
            this.pnlFilters.Controls.Add(this.txtSearch);
            this.pnlFilters.Controls.Add(this.lblSearch);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(0, 70);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(1200, 70);
            this.pnlFilters.TabIndex = 1;
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilters.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClearFilters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnClearFilters.Location = new System.Drawing.Point(1080, 15);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(100, 35);
            this.btnClearFilters.TabIndex = 6;
            this.btnClearFilters.Text = "Clear Filters";
            this.btnClearFilters.UseVisualStyleBackColor = true;
            // 
            // chkActiveOnly
            // 
            this.chkActiveOnly.AutoSize = true;
            this.chkActiveOnly.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkActiveOnly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.chkActiveOnly.Location = new System.Drawing.Point(820, 20);
            this.chkActiveOnly.Name = "chkActiveOnly";
            this.chkActiveOnly.Size = new System.Drawing.Size(97, 23);
            this.chkActiveOnly.TabIndex = 5;
            this.chkActiveOnly.Text = "Active Only";
            this.chkActiveOnly.UseVisualStyleBackColor = true;
            // 
            // cmbSortBy
            // 
            this.cmbSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortBy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbSortBy.FormattingEnabled = true;
            this.cmbSortBy.Items.AddRange(new object[] {
            "Sort by: Newest",
            "Sort by: Oldest",
            "Sort by: Amount",
            "Sort by: Vehicle"});
            this.cmbSortBy.Location = new System.Drawing.Point(650, 15);
            this.cmbSortBy.Name = "cmbSortBy";
            this.cmbSortBy.Size = new System.Drawing.Size(150, 25);
            this.cmbSortBy.TabIndex = 4;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "All Status",
            "Active",
            "Pending",
            "Returned",
            "Overdue",
            "Cancelled",
            "Extended"});
            this.cmbStatus.Location = new System.Drawing.Point(480, 15);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 25);
            this.cmbStatus.TabIndex = 3;
            // 
            // lblFilterBy
            // 
            this.lblFilterBy.AutoSize = true;
            this.lblFilterBy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFilterBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblFilterBy.Location = new System.Drawing.Point(420, 20);
            this.lblFilterBy.Name = "lblFilterBy";
            this.lblFilterBy.Size = new System.Drawing.Size(43, 19);
            this.lblFilterBy.TabIndex = 2;
            this.lblFilterBy.Text = "Filter:";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(150, 15);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Vehicle, plate, location...";
            this.txtSearch.Size = new System.Drawing.Size(250, 25);
            this.txtSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblSearch.Location = new System.Drawing.Point(20, 20);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(124, 19);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search rentals...";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.pnlHeader.Controls.Add(this.btnNewRental);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.btnRefresh);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 70);
            this.pnlHeader.TabIndex = 2;
            // 
            // btnNewRental
            // 
            this.btnNewRental.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewRental.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnNewRental.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewRental.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNewRental.ForeColor = System.Drawing.Color.White;
            this.btnNewRental.Location = new System.Drawing.Point(850, 10);
            this.btnNewRental.Name = "btnNewRental";
            this.btnNewRental.Size = new System.Drawing.Size(150, 40);
            this.btnNewRental.TabIndex = 2;
            this.btnNewRental.Text = "New Rental";
            this.btnNewRental.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(146, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "My Rentals";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1020, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(150, 40);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // ctxMenuRental
            // 
            this.ctxMenuRental.BackColor = System.Drawing.Color.White;
            this.ctxMenuRental.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ctxMenuRental.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewDetails,
            this.menuReturnVehicle,
            this.menuReportDamage,
            this.menuExtendRental,
            this.menuViewReceipt,
            this.menuAddReview,
            this.toolStripSeparator1,
            this.menuPrintDetails,
            this.menuExportDetails});
            this.ctxMenuRental.Name = "ctxMenuRental";
            this.ctxMenuRental.Size = new System.Drawing.Size(181, 208);
            // 
            // menuViewDetails
            // 
            this.menuViewDetails.Name = "menuViewDetails";
            this.menuViewDetails.Size = new System.Drawing.Size(180, 22);
            this.menuViewDetails.Text = "📋 View Details";
            // 
            // menuReturnVehicle
            // 
            this.menuReturnVehicle.Name = "menuReturnVehicle";
            this.menuReturnVehicle.Size = new System.Drawing.Size(180, 22);
            this.menuReturnVehicle.Text = "🔁 Return Vehicle";
            // 
            // menuReportDamage
            // 
            this.menuReportDamage.Name = "menuReportDamage";
            this.menuReportDamage.Size = new System.Drawing.Size(180, 22);
            this.menuReportDamage.Text = "🚨 Report Damage";
            // 
            // menuExtendRental
            // 
            this.menuExtendRental.Name = "menuExtendRental";
            this.menuExtendRental.Size = new System.Drawing.Size(180, 22);
            this.menuExtendRental.Text = "📅 Extend Rental";
            // 
            // menuViewReceipt
            // 
            this.menuViewReceipt.Name = "menuViewReceipt";
            this.menuViewReceipt.Size = new System.Drawing.Size(180, 22);
            this.menuViewReceipt.Text = "🧾 View Receipt";
            // 
            // menuAddReview
            // 
            this.menuAddReview.Name = "menuAddReview";
            this.menuAddReview.Size = new System.Drawing.Size(180, 22);
            this.menuAddReview.Text = "⭐ Add Review";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // menuPrintDetails
            // 
            this.menuPrintDetails.Name = "menuPrintDetails";
            this.menuPrintDetails.Size = new System.Drawing.Size(180, 22);
            this.menuPrintDetails.Text = "🖨️ Print Details";
            // 
            // menuExportDetails
            // 
            this.menuExportDetails.Name = "menuExportDetails";
            this.menuExportDetails.Size = new System.Drawing.Size(180, 22);
            this.menuExportDetails.Text = "💾 Export Details";
            // 
            // CustomersRentalsView
            // 
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "CustomersRentalsView";
            this.Size = new System.Drawing.Size(1200, 800);
            this.pnlMain.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentals)).EndInit();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlPagination.ResumeLayout(false);
            this.pnlPagination.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ctxMenuRental.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvRentals;
        private System.Windows.Forms.Label lblEmpty;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlSidebarContent;
        private System.Windows.Forms.Label lblSidebarTitle;
        private System.Windows.Forms.Panel pnlPagination;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnViewReceipt;
        private System.Windows.Forms.Button btnExtendRental;
        private System.Windows.Forms.Button btnReportDamage;
        private System.Windows.Forms.Button btnReturnVehicle;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.CheckBox chkActiveOnly;
        private System.Windows.Forms.ComboBox cmbSortBy;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblFilterBy;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnNewRental;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ContextMenuStrip ctxMenuRental;
        private System.Windows.Forms.ToolStripMenuItem menuViewDetails;
        private System.Windows.Forms.ToolStripMenuItem menuReturnVehicle;
        private System.Windows.Forms.ToolStripMenuItem menuReportDamage;
        private System.Windows.Forms.ToolStripMenuItem menuExtendRental;
        private System.Windows.Forms.ToolStripMenuItem menuViewReceipt;
        private System.Windows.Forms.ToolStripMenuItem menuAddReview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuPrintDetails;
        private System.Windows.Forms.ToolStripMenuItem menuExportDetails;
    }
}