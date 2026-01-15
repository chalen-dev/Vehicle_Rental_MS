namespace VRMS.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            sidePanel = new Panel();
            navButtonsPanel = new FlowLayoutPanel();
            btnDashboard = new Button();
            btnVehicles = new Button();
            btnCustomers = new Button();
            btnReservation = new Button();
            btnRentals = new Button();
            btnRentalsCalendar = new Button();
            btnReports = new Button();
            btnHistory = new Button();
            btnAdmin = new Button();
            btnLogout = new Button();
            headerPanel = new Panel();
            lbluserInfo = new Label();
            logoPictureBox = new PictureBox();
            contentPanel = new Panel();
            mainHeader = new VRMS.Controls.MainHeaderControl();
            sidePanel.SuspendLayout();
            navButtonsPanel.SuspendLayout();
            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            SuspendLayout();
            // 
            // sidePanel
            // 
            sidePanel.BackColor = Color.FromArgb(52, 73, 94);
            sidePanel.Controls.Add(navButtonsPanel);
            sidePanel.Controls.Add(headerPanel);
            sidePanel.Dock = DockStyle.Left;
            sidePanel.Location = new Point(0, 0);
            sidePanel.Margin = new Padding(5, 4, 5, 4);
            sidePanel.Name = "sidePanel";
            sidePanel.Size = new Size(297, 1055);
            sidePanel.TabIndex = 0;
            // 
            // navButtonsPanel
            // 
            navButtonsPanel.BackColor = Color.Transparent;
            navButtonsPanel.Controls.Add(btnDashboard);
            navButtonsPanel.Controls.Add(btnVehicles);
            navButtonsPanel.Controls.Add(btnCustomers);
            navButtonsPanel.Controls.Add(btnReservation);
            navButtonsPanel.Controls.Add(btnRentals);
            navButtonsPanel.Controls.Add(btnRentalsCalendar);
            navButtonsPanel.Controls.Add(btnReports);
            navButtonsPanel.Controls.Add(btnHistory);
            navButtonsPanel.Controls.Add(btnAdmin);
            navButtonsPanel.Controls.Add(btnLogout);
            navButtonsPanel.Dock = DockStyle.Fill;
            navButtonsPanel.FlowDirection = FlowDirection.TopDown;
            navButtonsPanel.Location = new Point(0, 133);
            navButtonsPanel.Margin = new Padding(5, 4, 5, 4);
            navButtonsPanel.Name = "navButtonsPanel";
            navButtonsPanel.Padding = new Padding(14, 16, 14, 16);
            navButtonsPanel.Size = new Size(297, 922);
            navButtonsPanel.TabIndex = 1;
            navButtonsPanel.WrapContents = false;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.Transparent;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatAppearance.MouseOverBackColor = Color.FromArgb(44, 62, 80);
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(19, 20);
            btnDashboard.Margin = new Padding(5, 4, 5, 4);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(251, 67);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "🏠 Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = false;
            // 
            // btnVehicles
            // 
            btnVehicles.BackColor = Color.Transparent;
            btnVehicles.FlatAppearance.BorderSize = 0;
            btnVehicles.FlatAppearance.MouseOverBackColor = Color.FromArgb(44, 62, 80);
            btnVehicles.FlatStyle = FlatStyle.Flat;
            btnVehicles.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnVehicles.ForeColor = Color.White;
            btnVehicles.Location = new Point(19, 95);
            btnVehicles.Margin = new Padding(5, 4, 5, 4);
            btnVehicles.Name = "btnVehicles";
            btnVehicles.Size = new Size(251, 67);
            btnVehicles.TabIndex = 1;
            btnVehicles.Text = "🚗 Vehicles";
            btnVehicles.TextAlign = ContentAlignment.MiddleLeft;
            btnVehicles.UseVisualStyleBackColor = false;
            // 
            // btnCustomers
            // 
            btnCustomers.BackColor = Color.Transparent;
            btnCustomers.FlatAppearance.BorderSize = 0;
            btnCustomers.FlatAppearance.MouseOverBackColor = Color.FromArgb(44, 62, 80);
            btnCustomers.FlatStyle = FlatStyle.Flat;
            btnCustomers.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCustomers.ForeColor = Color.White;
            btnCustomers.Location = new Point(19, 170);
            btnCustomers.Margin = new Padding(5, 4, 5, 4);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Size = new Size(251, 67);
            btnCustomers.TabIndex = 2;
            btnCustomers.Text = "👥 Customers";
            btnCustomers.TextAlign = ContentAlignment.MiddleLeft;
            btnCustomers.UseVisualStyleBackColor = false;
            // 
            // btnReservation
            // 
            btnReservation.BackColor = Color.Transparent;
            btnReservation.FlatAppearance.BorderSize = 0;
            btnReservation.FlatAppearance.MouseOverBackColor = Color.FromArgb(44, 62, 80);
            btnReservation.FlatStyle = FlatStyle.Flat;
            btnReservation.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReservation.ForeColor = Color.White;
            btnReservation.Location = new Point(19, 245);
            btnReservation.Margin = new Padding(5, 4, 5, 4);
            btnReservation.Name = "btnReservation";
            btnReservation.Size = new Size(251, 67);
            btnReservation.TabIndex = 7;
            btnReservation.Text = "✏ Reservation";
            btnReservation.TextAlign = ContentAlignment.MiddleLeft;
            btnReservation.UseVisualStyleBackColor = false;
            // 
            // btnRentals
            // 
            btnRentals.BackColor = Color.Transparent;
            btnRentals.FlatAppearance.BorderSize = 0;
            btnRentals.FlatAppearance.MouseOverBackColor = Color.FromArgb(44, 62, 80);
            btnRentals.FlatStyle = FlatStyle.Flat;
            btnRentals.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRentals.ForeColor = Color.White;
            btnRentals.Location = new Point(19, 320);
            btnRentals.Margin = new Padding(5, 4, 5, 4);
            btnRentals.Name = "btnRentals";
            btnRentals.Size = new Size(251, 67);
            btnRentals.TabIndex = 3;
            btnRentals.Text = "📋 Rentals";
            btnRentals.TextAlign = ContentAlignment.MiddleLeft;
            btnRentals.UseVisualStyleBackColor = false;
            // 
            // btnRentalsCalendar
            // 
            btnRentalsCalendar.BackColor = Color.Transparent;
            btnRentalsCalendar.FlatAppearance.BorderSize = 0;
            btnRentalsCalendar.FlatAppearance.MouseOverBackColor = Color.FromArgb(44, 62, 80);
            btnRentalsCalendar.FlatStyle = FlatStyle.Flat;
            btnRentalsCalendar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRentalsCalendar.ForeColor = Color.White;
            btnRentalsCalendar.Location = new Point(19, 395);
            btnRentalsCalendar.Margin = new Padding(5, 4, 5, 4);
            btnRentalsCalendar.Name = "btnRentalsCalendar";
            btnRentalsCalendar.Size = new Size(251, 67);
            btnRentalsCalendar.TabIndex = 9;
            btnRentalsCalendar.Text = "🗓️ Rentals Calendar";
            btnRentalsCalendar.TextAlign = ContentAlignment.MiddleLeft;
            btnRentalsCalendar.UseVisualStyleBackColor = false;
            // 
            // btnReports
            // 
            btnReports.BackColor = Color.Transparent;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatAppearance.MouseOverBackColor = Color.FromArgb(44, 62, 80);
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReports.ForeColor = Color.White;
            btnReports.Location = new Point(19, 470);
            btnReports.Margin = new Padding(5, 4, 5, 4);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(251, 67);
            btnReports.TabIndex = 4;
            btnReports.Text = "📊 Reports";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.UseVisualStyleBackColor = false;
            // 
            // btnHistory
            // 
            btnHistory.BackColor = Color.Transparent;
            btnHistory.FlatAppearance.BorderSize = 0;
            btnHistory.FlatAppearance.MouseOverBackColor = Color.FromArgb(44, 62, 80);
            btnHistory.FlatStyle = FlatStyle.Flat;
            btnHistory.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHistory.ForeColor = Color.White;
            btnHistory.Location = new Point(19, 545);
            btnHistory.Margin = new Padding(5, 4, 5, 4);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(251, 67);
            btnHistory.TabIndex = 8;
            btnHistory.Text = "⏱️ History";
            btnHistory.TextAlign = ContentAlignment.MiddleLeft;
            btnHistory.UseVisualStyleBackColor = false;
            // 
            // btnAdmin
            // 
            btnAdmin.BackColor = Color.Transparent;
            btnAdmin.FlatAppearance.BorderSize = 0;
            btnAdmin.FlatAppearance.MouseOverBackColor = Color.FromArgb(44, 62, 80);
            btnAdmin.FlatStyle = FlatStyle.Flat;
            btnAdmin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdmin.ForeColor = Color.White;
            btnAdmin.Location = new Point(19, 620);
            btnAdmin.Margin = new Padding(5, 4, 5, 4);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(251, 67);
            btnAdmin.TabIndex = 5;
            btnAdmin.Text = "👑 Admin";
            btnAdmin.TextAlign = ContentAlignment.MiddleLeft;
            btnAdmin.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(231, 76, 60);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 57, 43);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(19, 695);
            btnLogout.Margin = new Padding(5, 4, 5, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(251, 67);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "🚪 Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(44, 62, 80);
            headerPanel.Controls.Add(lbluserInfo);
            headerPanel.Controls.Add(logoPictureBox);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Margin = new Padding(5, 4, 5, 4);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(297, 133);
            headerPanel.TabIndex = 0;
            // 
            // lbluserInfo
            // 
            lbluserInfo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lbluserInfo.ForeColor = Color.White;
            lbluserInfo.Location = new Point(114, 20);
            lbluserInfo.Margin = new Padding(5, 0, 5, 0);
            lbluserInfo.Name = "lbluserInfo";
            lbluserInfo.Size = new Size(183, 93);
            lbluserInfo.TabIndex = 1;
            lbluserInfo.Text = "Welcome,\r\nUser Name\r\n(Role)";
            lbluserInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // logoPictureBox
            // 
            logoPictureBox.Location = new Point(17, 20);
            logoPictureBox.Margin = new Padding(5, 4, 5, 4);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new Size(87, 93);
            logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            logoPictureBox.TabIndex = 0;
            logoPictureBox.TabStop = false;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.White;
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(297, 133);
            contentPanel.Margin = new Padding(5, 4, 5, 4);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(1294, 922);
            contentPanel.TabIndex = 2;
            // 
            // mainHeader
            // 
            mainHeader.BackColor = Color.FromArgb(52, 73, 94);
            mainHeader.Dock = DockStyle.Top;
            mainHeader.Location = new Point(297, 0);
            mainHeader.Margin = new Padding(6, 4, 6, 4);
            mainHeader.Name = "mainHeader";
            mainHeader.Size = new Size(1294, 133);
            mainHeader.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1591, 1055);
            Controls.Add(contentPanel);
            Controls.Add(mainHeader);
            Controls.Add(sidePanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 4, 5, 4);
            MinimumSize = new Size(1140, 918);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Vehicle Rental System";
            WindowState = FormWindowState.Maximized;
            sidePanel.ResumeLayout(false);
            navButtonsPanel.ResumeLayout(false);
            headerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.FlowLayoutPanel navButtonsPanel;
        private System.Windows.Forms.Label lbluserInfo;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnVehicles;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnReservation;
        private System.Windows.Forms.Button btnRentals;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnLogout;
        private VRMS.Controls.MainHeaderControl mainHeader;
        private Button btnHistory;
        private Button btnRentalsCalendar;
    }
}