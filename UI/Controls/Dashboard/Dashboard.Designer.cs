namespace VRMS.Controls
{
    partial class DashboardView
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            dateRangePicker = new DateTimePicker();
            btnRefresh = new Button();
            mainContainer = new Panel();
            rightPanel = new Panel();
            splitRight = new SplitContainer();
            pnlTodaySchedule = new Panel();
            dgvTodaySchedule = new DataGridView();
            lblTodayScheduleTitle = new Label();
            pnlAlerts = new Panel();
            dgvAlerts = new DataGridView();
            lblAlertsTitle = new Label();
            leftPanel = new Panel();
            pnlChartArea = new Panel();
            lblChartTitle = new Label();
            pnlCards = new FlowLayoutPanel();
            pnlCardTotal = new Panel();
            lblTotalValue = new Label();
            lblTotalTitle = new Label();
            pnlCardAvailable = new Panel();
            lblAvailableValue = new Label();
            lblAvailableTitle = new Label();
            pnlCardRented = new Panel();
            lblRentedValue = new Label();
            lblRentedTitle = new Label();
            pnlCardOverdue = new Panel();
            lblOverdueValue = new Label();
            lblOverdueTitle = new Label();
            pnlCardMaintenance = new Panel();
            lblMaintenanceValue = new Label();
            lblMaintenanceTitle = new Label();
            pnlCardRevenue = new Panel();
            lblRevenueValue = new Label();
            lblRevenueTitle = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            pnlHeader.SuspendLayout();
            mainContainer.SuspendLayout();
            rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitRight).BeginInit();
            splitRight.Panel1.SuspendLayout();
            splitRight.Panel2.SuspendLayout();
            splitRight.SuspendLayout();
            pnlTodaySchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTodaySchedule).BeginInit();
            pnlAlerts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlerts).BeginInit();
            leftPanel.SuspendLayout();
            pnlChartArea.SuspendLayout();
            pnlCards.SuspendLayout();
            pnlCardTotal.SuspendLayout();
            pnlCardAvailable.SuspendLayout();
            pnlCardRented.SuspendLayout();
            pnlCardOverdue.SuspendLayout();
            pnlCardMaintenance.SuspendLayout();
            pnlCardRevenue.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(dateRangePicker);
            pnlHeader.Controls.Add(btnRefresh);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(14, 16, 14, 16);
            pnlHeader.Size = new Size(1589, 80);
            pnlHeader.TabIndex = 0;
            // 
            // dateRangePicker
            // 
            dateRangePicker.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateRangePicker.CustomFormat = "MMMM yyyy";
            dateRangePicker.Font = new Font("Segoe UI", 9F);
            dateRangePicker.Format = DateTimePickerFormat.Custom;
            dateRangePicker.Location = new Point(1260, 21);
            dateRangePicker.Name = "dateRangePicker";
            dateRangePicker.ShowUpDown = true;
            dateRangePicker.Size = new Size(185, 27);
            dateRangePicker.TabIndex = 2;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.FromArgb(52, 152, 219);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(1452, 15);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(114, 43);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // mainContainer
            // 
            mainContainer.Controls.Add(rightPanel);
            mainContainer.Controls.Add(leftPanel);
            mainContainer.Dock = DockStyle.Fill;
            mainContainer.Location = new Point(0, 80);
            mainContainer.Name = "mainContainer";
            mainContainer.Padding = new Padding(11, 13, 11, 13);
            mainContainer.Size = new Size(1589, 827);
            mainContainer.TabIndex = 1;
            // 
            // rightPanel
            // 
            rightPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            rightPanel.Controls.Add(splitRight);
            rightPanel.Location = new Point(1178, 13);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size(400, 800);
            rightPanel.TabIndex = 1;
            // 
            // splitRight
            // 
            splitRight.Dock = DockStyle.Fill;
            splitRight.Location = new Point(0, 0);
            splitRight.Name = "splitRight";
            splitRight.Orientation = Orientation.Horizontal;
            // 
            // splitRight.Panel1
            // 
            splitRight.Panel1.Controls.Add(pnlTodaySchedule);
            splitRight.Panel1MinSize = 150;
            // 
            // splitRight.Panel2
            // 
            splitRight.Panel2.Controls.Add(pnlAlerts);
            splitRight.Panel2MinSize = 150;
            splitRight.Size = new Size(400, 800);
            splitRight.SplitterDistance = 400;
            splitRight.SplitterWidth = 13;
            splitRight.TabIndex = 0;
            // 
            // pnlTodaySchedule
            // 
            pnlTodaySchedule.BackColor = Color.White;
            pnlTodaySchedule.Controls.Add(dgvTodaySchedule);
            pnlTodaySchedule.Controls.Add(lblTodayScheduleTitle);
            pnlTodaySchedule.Dock = DockStyle.Fill;
            pnlTodaySchedule.Location = new Point(0, 0);
            pnlTodaySchedule.Name = "pnlTodaySchedule";
            pnlTodaySchedule.Padding = new Padding(11, 13, 11, 13);
            pnlTodaySchedule.Size = new Size(400, 400);
            pnlTodaySchedule.TabIndex = 0;
            // 
            // dgvTodaySchedule
            // 
            dgvTodaySchedule.AllowUserToAddRows = false;
            dgvTodaySchedule.AllowUserToResizeRows = false;
            dgvTodaySchedule.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTodaySchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTodaySchedule.BackgroundColor = Color.White;
            dgvTodaySchedule.BorderStyle = BorderStyle.None;
            dgvTodaySchedule.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTodaySchedule.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvTodaySchedule.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTodaySchedule.ColumnHeadersHeight = 32;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(236, 240, 241);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvTodaySchedule.DefaultCellStyle = dataGridViewCellStyle2;
            dgvTodaySchedule.EnableHeadersVisualStyles = false;
            dgvTodaySchedule.GridColor = Color.WhiteSmoke;
            dgvTodaySchedule.Location = new Point(11, 47);
            dgvTodaySchedule.Name = "dgvTodaySchedule";
            dgvTodaySchedule.ReadOnly = true;
            dgvTodaySchedule.RowHeadersVisible = false;
            dgvTodaySchedule.RowHeadersWidth = 51;
            dgvTodaySchedule.RowTemplate.Height = 28;
            dgvTodaySchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTodaySchedule.Size = new Size(377, 340);
            dgvTodaySchedule.TabIndex = 0;
            // 
            // lblTodayScheduleTitle
            // 
            lblTodayScheduleTitle.AutoSize = true;
            lblTodayScheduleTitle.Dock = DockStyle.Top;
            lblTodayScheduleTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTodayScheduleTitle.ForeColor = Color.FromArgb(41, 128, 185);
            lblTodayScheduleTitle.Location = new Point(11, 13);
            lblTodayScheduleTitle.Margin = new Padding(3, 0, 3, 12);
            lblTodayScheduleTitle.Name = "lblTodayScheduleTitle";
            lblTodayScheduleTitle.Padding = new Padding(0, 0, 0, 7);
            lblTodayScheduleTitle.Size = new Size(256, 32);
            lblTodayScheduleTitle.TabIndex = 1;
            lblTodayScheduleTitle.Text = "📅 Today's Pickups/Returns";
            // 
            // pnlAlerts
            // 
            pnlAlerts.BackColor = Color.White;
            pnlAlerts.Controls.Add(dgvAlerts);
            pnlAlerts.Controls.Add(lblAlertsTitle);
            pnlAlerts.Dock = DockStyle.Fill;
            pnlAlerts.Location = new Point(0, 0);
            pnlAlerts.Name = "pnlAlerts";
            pnlAlerts.Padding = new Padding(11, 13, 11, 13);
            pnlAlerts.Size = new Size(400, 387);
            pnlAlerts.TabIndex = 0;
            // 
            // dgvAlerts
            // 
            dgvAlerts.AllowUserToAddRows = false;
            dgvAlerts.AllowUserToResizeRows = false;
            dgvAlerts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAlerts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAlerts.BackgroundColor = Color.White;
            dgvAlerts.BorderStyle = BorderStyle.None;
            dgvAlerts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAlerts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(231, 76, 60);
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 76, 60);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvAlerts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvAlerts.ColumnHeadersHeight = 32;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(236, 240, 241);
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvAlerts.DefaultCellStyle = dataGridViewCellStyle4;
            dgvAlerts.EnableHeadersVisualStyles = false;
            dgvAlerts.GridColor = Color.WhiteSmoke;
            dgvAlerts.Location = new Point(11, 47);
            dgvAlerts.Name = "dgvAlerts";
            dgvAlerts.ReadOnly = true;
            dgvAlerts.RowHeadersVisible = false;
            dgvAlerts.RowHeadersWidth = 51;
            dgvAlerts.RowTemplate.Height = 28;
            dgvAlerts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlerts.Size = new Size(377, 327);
            dgvAlerts.TabIndex = 0;
            // 
            // lblAlertsTitle
            // 
            lblAlertsTitle.AutoSize = true;
            lblAlertsTitle.Dock = DockStyle.Top;
            lblAlertsTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAlertsTitle.ForeColor = Color.FromArgb(192, 57, 43);
            lblAlertsTitle.Location = new Point(11, 13);
            lblAlertsTitle.Margin = new Padding(3, 0, 3, 12);
            lblAlertsTitle.Name = "lblAlertsTitle";
            lblAlertsTitle.Padding = new Padding(0, 0, 0, 7);
            lblAlertsTitle.Size = new Size(91, 32);
            lblAlertsTitle.TabIndex = 2;
            lblAlertsTitle.Text = "⚠️ Alerts";
            // 
            // leftPanel
            // 
            leftPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            leftPanel.Controls.Add(pnlChartArea);
            leftPanel.Controls.Add(pnlCards);
            leftPanel.Location = new Point(11, 13);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(1160, 800);
            leftPanel.TabIndex = 0;
            // 
            // pnlChartArea
            // 
            pnlChartArea.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlChartArea.BackColor = Color.White;
            pnlChartArea.Controls.Add(lblChartTitle);
            pnlChartArea.Location = new Point(0, 194);
            pnlChartArea.Name = "pnlChartArea";
            pnlChartArea.Padding = new Padding(11, 13, 11, 13);
            pnlChartArea.Size = new Size(1160, 606);
            pnlChartArea.TabIndex = 1;
            // 
            // lblChartTitle
            // 
            lblChartTitle.AutoSize = true;
            lblChartTitle.Dock = DockStyle.Top;
            lblChartTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblChartTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblChartTitle.Location = new Point(11, 13);
            lblChartTitle.Margin = new Padding(3, 0, 3, 12);
            lblChartTitle.Name = "lblChartTitle";
            lblChartTitle.Padding = new Padding(0, 0, 0, 9);
            lblChartTitle.Size = new Size(286, 37);
            lblChartTitle.TabIndex = 0;
            lblChartTitle.Text = "📊 Fleet Performance Trends";
            // 
            // pnlCards
            // 
            pnlCards.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlCards.BackColor = Color.Transparent;
            pnlCards.Controls.Add(pnlCardTotal);
            pnlCards.Controls.Add(pnlCardAvailable);
            pnlCards.Controls.Add(pnlCardRented);
            pnlCards.Controls.Add(pnlCardOverdue);
            pnlCards.Controls.Add(pnlCardMaintenance);
            pnlCards.Controls.Add(pnlCardRevenue);
            pnlCards.Location = new Point(0, 0);
            pnlCards.Name = "pnlCards";
            pnlCards.Size = new Size(1160, 202);
            pnlCards.TabIndex = 0;
            // 
            // pnlCardTotal
            // 
            pnlCardTotal.BackColor = Color.FromArgb(52, 73, 94);
            pnlCardTotal.Controls.Add(lblTotalValue);
            pnlCardTotal.Controls.Add(lblTotalTitle);
            pnlCardTotal.Cursor = Cursors.Hand;
            pnlCardTotal.ForeColor = Color.White;
            pnlCardTotal.Location = new Point(6, 7);
            pnlCardTotal.Margin = new Padding(6, 7, 6, 7);
            pnlCardTotal.Name = "pnlCardTotal";
            pnlCardTotal.Padding = new Padding(11, 13, 11, 13);
            pnlCardTotal.Size = new Size(149, 173);
            pnlCardTotal.TabIndex = 0;
            // 
            // lblTotalValue
            // 
            lblTotalValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTotalValue.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblTotalValue.Location = new Point(11, 67);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(126, 67);
            lblTotalValue.TabIndex = 0;
            lblTotalValue.Text = "0";
            lblTotalValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.AutoSize = true;
            lblTotalTitle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblTotalTitle.ForeColor = Color.Gainsboro;
            lblTotalTitle.Location = new Point(11, 13);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(85, 21);
            lblTotalTitle.TabIndex = 1;
            lblTotalTitle.Text = "Total Fleet";
            // 
            // pnlCardAvailable
            // 
            pnlCardAvailable.BackColor = Color.FromArgb(39, 174, 96);
            pnlCardAvailable.Controls.Add(lblAvailableValue);
            pnlCardAvailable.Controls.Add(lblAvailableTitle);
            pnlCardAvailable.Cursor = Cursors.Hand;
            pnlCardAvailable.ForeColor = Color.White;
            pnlCardAvailable.Location = new Point(167, 7);
            pnlCardAvailable.Margin = new Padding(6, 7, 6, 7);
            pnlCardAvailable.Name = "pnlCardAvailable";
            pnlCardAvailable.Padding = new Padding(11, 13, 11, 13);
            pnlCardAvailable.Size = new Size(149, 173);
            pnlCardAvailable.TabIndex = 1;
            // 
            // lblAvailableValue
            // 
            lblAvailableValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblAvailableValue.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblAvailableValue.Location = new Point(11, 67);
            lblAvailableValue.Name = "lblAvailableValue";
            lblAvailableValue.Size = new Size(126, 67);
            lblAvailableValue.TabIndex = 0;
            lblAvailableValue.Text = "0";
            lblAvailableValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAvailableTitle
            // 
            lblAvailableTitle.AutoSize = true;
            lblAvailableTitle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblAvailableTitle.ForeColor = Color.Gainsboro;
            lblAvailableTitle.Location = new Point(11, 13);
            lblAvailableTitle.Name = "lblAvailableTitle";
            lblAvailableTitle.Size = new Size(132, 21);
            lblAvailableTitle.TabIndex = 1;
            lblAvailableTitle.Text = "Vehicle Available";
            // 
            // pnlCardRented
            // 
            pnlCardRented.BackColor = Color.FromArgb(41, 128, 185);
            pnlCardRented.Controls.Add(lblRentedValue);
            pnlCardRented.Controls.Add(lblRentedTitle);
            pnlCardRented.Cursor = Cursors.Hand;
            pnlCardRented.ForeColor = Color.White;
            pnlCardRented.Location = new Point(328, 7);
            pnlCardRented.Margin = new Padding(6, 7, 6, 7);
            pnlCardRented.Name = "pnlCardRented";
            pnlCardRented.Padding = new Padding(11, 13, 11, 13);
            pnlCardRented.Size = new Size(149, 173);
            pnlCardRented.TabIndex = 2;
            // 
            // lblRentedValue
            // 
            lblRentedValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblRentedValue.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblRentedValue.Location = new Point(11, 67);
            lblRentedValue.Name = "lblRentedValue";
            lblRentedValue.Size = new Size(126, 67);
            lblRentedValue.TabIndex = 0;
            lblRentedValue.Text = "0";
            lblRentedValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRentedTitle
            // 
            lblRentedTitle.AutoSize = true;
            lblRentedTitle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblRentedTitle.ForeColor = Color.Gainsboro;
            lblRentedTitle.Location = new Point(11, 13);
            lblRentedTitle.Name = "lblRentedTitle";
            lblRentedTitle.Size = new Size(101, 21);
            lblRentedTitle.TabIndex = 1;
            lblRentedTitle.Text = "Active Rents";
            // 
            // pnlCardOverdue
            // 
            pnlCardOverdue.BackColor = Color.FromArgb(192, 57, 43);
            pnlCardOverdue.Controls.Add(lblOverdueValue);
            pnlCardOverdue.Controls.Add(lblOverdueTitle);
            pnlCardOverdue.Cursor = Cursors.Hand;
            pnlCardOverdue.ForeColor = Color.White;
            pnlCardOverdue.Location = new Point(489, 7);
            pnlCardOverdue.Margin = new Padding(6, 7, 6, 7);
            pnlCardOverdue.Name = "pnlCardOverdue";
            pnlCardOverdue.Padding = new Padding(11, 13, 11, 13);
            pnlCardOverdue.Size = new Size(149, 173);
            pnlCardOverdue.TabIndex = 4;
            // 
            // lblOverdueValue
            // 
            lblOverdueValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblOverdueValue.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblOverdueValue.Location = new Point(11, 67);
            lblOverdueValue.Name = "lblOverdueValue";
            lblOverdueValue.Size = new Size(126, 67);
            lblOverdueValue.TabIndex = 0;
            lblOverdueValue.Text = "₱0";
            lblOverdueValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblOverdueTitle
            // 
            lblOverdueTitle.AutoSize = true;
            lblOverdueTitle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblOverdueTitle.ForeColor = Color.Gainsboro;
            lblOverdueTitle.Location = new Point(11, 13);
            lblOverdueTitle.Name = "lblOverdueTitle";
            lblOverdueTitle.Size = new Size(73, 21);
            lblOverdueTitle.TabIndex = 1;
            lblOverdueTitle.Text = "Overdue";
            // 
            // pnlCardMaintenance
            // 
            pnlCardMaintenance.BackColor = Color.FromArgb(230, 126, 34);
            pnlCardMaintenance.Controls.Add(lblMaintenanceValue);
            pnlCardMaintenance.Controls.Add(lblMaintenanceTitle);
            pnlCardMaintenance.Cursor = Cursors.Hand;
            pnlCardMaintenance.ForeColor = Color.White;
            pnlCardMaintenance.Location = new Point(650, 7);
            pnlCardMaintenance.Margin = new Padding(6, 7, 6, 7);
            pnlCardMaintenance.Name = "pnlCardMaintenance";
            pnlCardMaintenance.Padding = new Padding(11, 13, 11, 13);
            pnlCardMaintenance.Size = new Size(149, 173);
            pnlCardMaintenance.TabIndex = 5;
            // 
            // lblMaintenanceValue
            // 
            lblMaintenanceValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblMaintenanceValue.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblMaintenanceValue.Location = new Point(11, 67);
            lblMaintenanceValue.Name = "lblMaintenanceValue";
            lblMaintenanceValue.Size = new Size(126, 67);
            lblMaintenanceValue.TabIndex = 0;
            lblMaintenanceValue.Text = "0";
            lblMaintenanceValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMaintenanceTitle
            // 
            lblMaintenanceTitle.AutoSize = true;
            lblMaintenanceTitle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblMaintenanceTitle.ForeColor = Color.Gainsboro;
            lblMaintenanceTitle.Location = new Point(0, 13);
            lblMaintenanceTitle.Name = "lblMaintenanceTitle";
            lblMaintenanceTitle.Size = new Size(153, 21);
            lblMaintenanceTitle.TabIndex = 1;
            lblMaintenanceTitle.Text = "Under Maintenance";
            // 
            // pnlCardRevenue
            // 
            pnlCardRevenue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlCardRevenue.BackColor = Color.FromArgb(142, 68, 173);
            pnlCardRevenue.Controls.Add(lblRevenueValue);
            pnlCardRevenue.Controls.Add(lblRevenueTitle);
            pnlCardRevenue.Cursor = Cursors.Hand;
            pnlCardRevenue.ForeColor = Color.White;
            pnlCardRevenue.Location = new Point(811, 7);
            pnlCardRevenue.Margin = new Padding(6, 7, 6, 7);
            pnlCardRevenue.Name = "pnlCardRevenue";
            pnlCardRevenue.Padding = new Padding(11, 13, 11, 13);
            pnlCardRevenue.Size = new Size(343, 173);
            pnlCardRevenue.TabIndex = 3;
            // 
            // lblRevenueValue
            // 
            lblRevenueValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblRevenueValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblRevenueValue.Location = new Point(11, 73);
            lblRevenueValue.Name = "lblRevenueValue";
            lblRevenueValue.Size = new Size(320, 60);
            lblRevenueValue.TabIndex = 0;
            lblRevenueValue.Text = "₱0";
            lblRevenueValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRevenueTitle
            // 
            lblRevenueTitle.AutoSize = true;
            lblRevenueTitle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblRevenueTitle.ForeColor = Color.Gainsboro;
            lblRevenueTitle.Location = new Point(11, 13);
            lblRevenueTitle.Name = "lblRevenueTitle";
            lblRevenueTitle.Size = new Size(136, 21);
            lblRevenueTitle.TabIndex = 1;
            lblRevenueTitle.Text = "Revenue (Month)";
            // 
            // DashboardView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 243, 244);
            Controls.Add(mainContainer);
            Controls.Add(pnlHeader);
            MinimumSize = new Size(1029, 800);
            Name = "DashboardView";
            Size = new Size(1589, 907);
            pnlHeader.ResumeLayout(false);
            mainContainer.ResumeLayout(false);
            rightPanel.ResumeLayout(false);
            splitRight.Panel1.ResumeLayout(false);
            splitRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitRight).EndInit();
            splitRight.ResumeLayout(false);
            pnlTodaySchedule.ResumeLayout(false);
            pnlTodaySchedule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTodaySchedule).EndInit();
            pnlAlerts.ResumeLayout(false);
            pnlAlerts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlerts).EndInit();
            leftPanel.ResumeLayout(false);
            pnlChartArea.ResumeLayout(false);
            pnlChartArea.PerformLayout();
            pnlCards.ResumeLayout(false);
            pnlCardTotal.ResumeLayout(false);
            pnlCardTotal.PerformLayout();
            pnlCardAvailable.ResumeLayout(false);
            pnlCardAvailable.PerformLayout();
            pnlCardRented.ResumeLayout(false);
            pnlCardRented.PerformLayout();
            pnlCardOverdue.ResumeLayout(false);
            pnlCardOverdue.PerformLayout();
            pnlCardMaintenance.ResumeLayout(false);
            pnlCardMaintenance.PerformLayout();
            pnlCardRevenue.ResumeLayout(false);
            pnlCardRevenue.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private DateTimePicker dateRangePicker;
        private Button btnRefresh;
        private Panel mainContainer;
        private Panel rightPanel;
        private SplitContainer splitRight;
        private Panel pnlTodaySchedule;
        private DataGridView dgvTodaySchedule;
        private Label lblTodayScheduleTitle;
        private Panel pnlAlerts;
        private DataGridView dgvAlerts;
        private Label lblAlertsTitle;
        private Panel leftPanel;
        private Panel pnlChartArea;
        private Label lblChartTitle;
        private FlowLayoutPanel pnlCards;
        private Panel pnlCardTotal;
        private Label lblTotalValue;
        private Label lblTotalTitle;
        private Panel pnlCardAvailable;
        private Label lblAvailableValue;
        private Label lblAvailableTitle;
        private Panel pnlCardRented;
        private Label lblRentedValue;
        private Label lblRentedTitle;
        private Panel pnlCardRevenue;
        private Label lblRevenueValue;
        private Label lblRevenueTitle;
        private Panel pnlCardOverdue;
        private Label lblOverdueValue;
        private Label lblOverdueTitle;
        private Panel pnlCardMaintenance;
        private Label lblMaintenanceValue;
        private Label lblMaintenanceTitle;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}