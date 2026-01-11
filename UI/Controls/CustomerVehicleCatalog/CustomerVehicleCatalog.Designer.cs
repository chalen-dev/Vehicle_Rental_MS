namespace VRMS.UI.Controls.CustomerVehicleCatalog
{
    partial class CustomerVehicleCatalog
    {
        private System.ComponentModel.IContainer components = null;

        // ===== HEADER =====
        private Panel panelHeader;
        private Label lblTitle;

        // ===== TOOLBAR =====
        private Panel panelToolbar;
        private Panel panelSearch;
        private TextBox txtSearch;

        // Sorting ug quick toggle
        private ComboBox cbSort;
        private CheckBox chkAvailableOnly;

        // ===== FILTER BAR (DROPDOWNS) =====
        private Panel panelFilterBar;
        private Label lblStatus;
        private ComboBox cbStatus;
        private Label lblCategory;
        private ComboBox cbCategory;

        // ===== CATALOG GRID =====
        private FlowLayoutPanel flpCatalog;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblTitle = new Label();
            panelToolbar = new Panel();
            panelSearch = new Panel();
            txtSearch = new TextBox();
            cbSort = new ComboBox();
            chkAvailableOnly = new CheckBox();
            panelFilterBar = new Panel();
            lblStatus = new Label();
            cbStatus = new ComboBox();
            lblCategory = new Label();
            cbCategory = new ComboBox();
            flpCatalog = new FlowLayoutPanel();
            panelHeader.SuspendLayout();
            panelToolbar.SuspendLayout();
            panelSearch.SuspendLayout();
            panelFilterBar.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(30, 60, 90);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1132, 70);
            panelHeader.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(307, 48);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Available Vehicles";
            // 
            // panelToolbar
            // 
            panelToolbar.BackColor = Color.White;
            panelToolbar.Controls.Add(panelSearch);
            panelToolbar.Controls.Add(cbSort);
            panelToolbar.Controls.Add(chkAvailableOnly);
            panelToolbar.Dock = DockStyle.Top;
            panelToolbar.Location = new Point(0, 70);
            panelToolbar.Name = "panelToolbar";
            panelToolbar.Padding = new Padding(15, 10, 15, 10);
            panelToolbar.Size = new Size(1132, 60);
            panelToolbar.TabIndex = 2;
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.FromArgb(248, 249, 250);
            panelSearch.BorderStyle = BorderStyle.FixedSingle;
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Location = new Point(15, 10);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(300, 40);
            panelSearch.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(10, 8);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "🔍 Search vehicles...";
            txtSearch.Size = new Size(280, 27);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += FilterVehicles;
            // 
            // cbSort
            // 
            cbSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSort.Font = new Font("Segoe UI", 9F);
            cbSort.Items.AddRange(new object[] { "Sort: Name (A–Z)", "Sort: Price (Low → High)", "Sort: Price (High → Low)" });
            cbSort.Location = new Point(330, 16);
            cbSort.Name = "cbSort";
            cbSort.Size = new Size(190, 33);
            cbSort.TabIndex = 1;
            // 
            // chkAvailableOnly
            // 
            chkAvailableOnly.AutoSize = true;
            chkAvailableOnly.Font = new Font("Segoe UI", 9F);
            chkAvailableOnly.Location = new Point(540, 18);
            chkAvailableOnly.Name = "chkAvailableOnly";
            chkAvailableOnly.Size = new Size(148, 29);
            chkAvailableOnly.TabIndex = 2;
            chkAvailableOnly.Text = "Available only";
            // 
            // panelFilterBar
            // 
            panelFilterBar.BackColor = Color.White;
            panelFilterBar.Controls.Add(lblStatus);
            panelFilterBar.Controls.Add(cbStatus);
            panelFilterBar.Controls.Add(lblCategory);
            panelFilterBar.Controls.Add(cbCategory);
            panelFilterBar.Dock = DockStyle.Top;
            panelFilterBar.Location = new Point(0, 130);
            panelFilterBar.Name = "panelFilterBar";
            panelFilterBar.Padding = new Padding(15, 8, 15, 8);
            panelFilterBar.Size = new Size(1132, 45);
            panelFilterBar.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(30, 60, 90);
            lblStatus.Location = new Point(15, 12);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(67, 25);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Status:";
            // 
            // cbStatus
            // 
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.Font = new Font("Segoe UI", 9F);
            cbStatus.Items.AddRange(new object[] { "All", "Available", "Rented", "Maintenance" });
            cbStatus.Location = new Point(70, 8);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(150, 33);
            cbStatus.TabIndex = 1;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblCategory.ForeColor = Color.FromArgb(30, 60, 90);
            lblCategory.Location = new Point(240, 12);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(92, 25);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Category:";
            
            // 
            // cbCategory
            // 
            cbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCategory.Font = new Font("Segoe UI", 9F);
            cbCategory.Items.AddRange(new object[] { "All", "Sedan", "SUV", "Van", "Motorcycle", "Pickup", "MPV" });
            cbCategory.Location = new Point(351, 6);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(160, 33);
            cbCategory.TabIndex = 3;
            // 
            // flpCatalog
            // 
            flpCatalog.AutoScroll = true;
            flpCatalog.BackColor = Color.FromArgb(245, 246, 248);
            flpCatalog.Dock = DockStyle.Fill;
            flpCatalog.Location = new Point(0, 175);
            flpCatalog.Name = "flpCatalog";
            flpCatalog.Padding = new Padding(20);
            flpCatalog.Size = new Size(1132, 625);
            flpCatalog.TabIndex = 0;
            // 
            // CustomerVehicleCatalog
            // 
            BackColor = Color.White;
            Controls.Add(flpCatalog);
            Controls.Add(panelFilterBar);
            Controls.Add(panelToolbar);
            Controls.Add(panelHeader);
            Name = "CustomerVehicleCatalog";
            Size = new Size(1132, 800);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelToolbar.ResumeLayout(false);
            panelToolbar.PerformLayout();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panelFilterBar.ResumeLayout(false);
            panelFilterBar.PerformLayout();
            ResumeLayout(false);
        }
    }
}
