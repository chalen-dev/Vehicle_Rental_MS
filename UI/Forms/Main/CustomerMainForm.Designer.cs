namespace VRMS.UI.Forms.Main
{
    partial class CustomerMainForm
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
            sidePanel = new Panel();
            navButtonsPanel = new FlowLayoutPanel();
            btnVehicles = new Button();
            btnRentals = new Button();
            btnLogout = new Button();
            headerPanel = new Panel();
            lblWelcome = new Label();
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
            navButtonsPanel.Controls.Add(btnVehicles);
            navButtonsPanel.Controls.Add(btnRentals);
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
            // btnVehicles
            // 
            btnVehicles.BackColor = Color.Transparent;
            btnVehicles.FlatAppearance.BorderSize = 0;
            btnVehicles.FlatAppearance.MouseOverBackColor = Color.FromArgb(44, 62, 80);
            btnVehicles.FlatStyle = FlatStyle.Flat;
            btnVehicles.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnVehicles.ForeColor = Color.White;
            btnVehicles.Location = new Point(19, 20);
            btnVehicles.Margin = new Padding(5, 4, 5, 4);
            btnVehicles.Name = "btnVehicles";
            btnVehicles.Size = new Size(251, 67);
            btnVehicles.TabIndex = 1;
            btnVehicles.Text = "🚗 Browse Vehicles";
            btnVehicles.TextAlign = ContentAlignment.MiddleLeft;
            btnVehicles.UseVisualStyleBackColor = false;
            btnVehicles.Click += btnVehicles_Click;
            // 
            // btnRentals
            // 
            btnRentals.BackColor = Color.Transparent;
            btnRentals.FlatAppearance.BorderSize = 0;
            btnRentals.FlatAppearance.MouseOverBackColor = Color.FromArgb(44, 62, 80);
            btnRentals.FlatStyle = FlatStyle.Flat;
            btnRentals.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRentals.ForeColor = Color.White;
            btnRentals.Location = new Point(19, 95);
            btnRentals.Margin = new Padding(5, 4, 5, 4);
            btnRentals.Name = "btnRentals";
            btnRentals.Size = new Size(251, 67);
            btnRentals.TabIndex = 3;
            btnRentals.Text = "📋 My Rentals";
            btnRentals.TextAlign = ContentAlignment.MiddleLeft;
            btnRentals.UseVisualStyleBackColor = false;
            btnRentals.Click += btnRentals_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(231, 76, 60);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 57, 43);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(19, 170);
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
            headerPanel.Controls.Add(lblWelcome);
            headerPanel.Controls.Add(logoPictureBox);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Margin = new Padding(5, 4, 5, 4);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(297, 133);
            headerPanel.TabIndex = 0;
            // 
            // lblWelcome
            // 
            lblWelcome.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(97, 20);
            lblWelcome.Margin = new Padding(5, 0, 5, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(183, 93);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Welcome,\r\nCustomer Name\r\n(Customer)";
            lblWelcome.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // logoPictureBox
            // 
            logoPictureBox.Location = new Point(17, 20);
            logoPictureBox.Margin = new Padding(5, 4, 5, 4);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new Size(69, 93);
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
            // CustomerMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1591, 1055);
            Controls.Add(contentPanel);
            Controls.Add(mainHeader);
            Controls.Add(sidePanel);
            Margin = new Padding(5, 4, 5, 4);
            MinimumSize = new Size(1140, 918);
            Name = "CustomerMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Vehicle Rental System - Customer Portal";
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
        private System.Windows.Forms.Label lblWelcome; // CHANGED FROM lbluserInfo TO lblWelcome
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Button btnVehicles;
        private System.Windows.Forms.Button btnRentals;
        private System.Windows.Forms.Button btnLogout;
        private VRMS.Controls.MainHeaderControl mainHeader;
    }
}