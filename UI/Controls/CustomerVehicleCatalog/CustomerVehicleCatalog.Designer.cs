namespace VRMS.UI.Controls.CustomerVehicleCatalog
{
    partial class CustomerVehicleCatalog
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelHeader;
        private Label lblTitle;

        private Panel panelToolbar;
        private Panel panelSearch;
        private TextBox txtSearch;

        private Panel panelStatusFilter;
        private Button btnAll;
        private Button btnAvailable;
        private Button btnRented;

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
            panelStatusFilter = new Panel();
            btnAll = new Button();
            btnAvailable = new Button();
            btnRented = new Button();
            flpCatalog = new FlowLayoutPanel();
            panelHeader.SuspendLayout();
            panelToolbar.SuspendLayout();
            panelSearch.SuspendLayout();
            panelStatusFilter.SuspendLayout();
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
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(271, 48);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Vehicle Catalog";
            // 
            // panelToolbar
            // 
            panelToolbar.BackColor = Color.White;
            panelToolbar.Controls.Add(panelSearch);
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
            panelSearch.Location = new Point(0, 0);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(350, 40);
            panelSearch.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(10, 8);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "🔍 Search vehicles...";
            txtSearch.Size = new Size(330, 27);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += FilterVehicles;
            // 
            // panelStatusFilter
            // 
            panelStatusFilter.BackColor = Color.White;
            panelStatusFilter.Controls.Add(btnAll);
            panelStatusFilter.Controls.Add(btnAvailable);
            panelStatusFilter.Controls.Add(btnRented);
            panelStatusFilter.Dock = DockStyle.Top;
            panelStatusFilter.Location = new Point(0, 130);
            panelStatusFilter.Name = "panelStatusFilter";
            panelStatusFilter.Padding = new Padding(10);
            panelStatusFilter.Size = new Size(1132, 35);
            panelStatusFilter.TabIndex = 1;
            // 
            // btnAll
            // 
            btnAll.Location = new Point(0, 0);
            btnAll.Name = "btnAll";
            btnAll.Size = new Size(75, 23);
            btnAll.TabIndex = 0;
            // 
            // btnAvailable
            // 
            btnAvailable.Location = new Point(0, 0);
            btnAvailable.Name = "btnAvailable";
            btnAvailable.Size = new Size(75, 23);
            btnAvailable.TabIndex = 1;
            // 
            // btnRented
            // 
            btnRented.Location = new Point(0, 0);
            btnRented.Name = "btnRented";
            btnRented.Size = new Size(75, 23);
            btnRented.TabIndex = 2;
            // 
            // flpCatalog
            // 
            flpCatalog.AutoScroll = true;
            flpCatalog.BackColor = Color.FromArgb(245, 246, 248);
            flpCatalog.Dock = DockStyle.Fill;
            flpCatalog.Location = new Point(0, 165);
            flpCatalog.Name = "flpCatalog";
            flpCatalog.Padding = new Padding(20);
            flpCatalog.Size = new Size(1132, 635);
            flpCatalog.TabIndex = 0;
            // 
            // CustomerVehicleCatalog
            // 
            BackColor = Color.White;
            Controls.Add(flpCatalog);
            Controls.Add(panelStatusFilter);
            Controls.Add(panelToolbar);
            Controls.Add(panelHeader);
            Name = "CustomerVehicleCatalog";
            Size = new Size(1132, 800);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelToolbar.ResumeLayout(false);
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panelStatusFilter.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Button CreateFilterButton(string text, Color color)
        {
            return new Button
            {
                Text = text,
                BackColor = color,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                Height = 26,
                Width = 100,
                Margin = new Padding(5, 0, 0, 0)
            };
        }
    }
}
