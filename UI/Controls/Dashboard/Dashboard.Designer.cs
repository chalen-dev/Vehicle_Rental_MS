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
            lblDashboardTitle = new Label();
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
            pnlCardRevenue = new Panel();
            lblRevenueValue = new Label();
            lblRevenueTitle = new Label();
            pnlCardOverdue = new Panel();
            lblOverdueValue = new Label();
            lblOverdueTitle = new Label();
            pnlCardMaintenance = new Panel();
            lblMaintenanceValue = new Label();
            lblMaintenanceTitle = new Label();
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
            pnlCardRevenue.SuspendLayout();
            pnlCardOverdue.SuspendLayout();
            pnlCardMaintenance.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(dateRangePicker);
            pnlHeader.Controls.Add(btnRefresh);
            pnlHeader.Controls.Add(lblDashboardTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(4, 4, 4, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(18, 20, 18, 20);
            pnlHeader.Size = new Size(1500, 100);
            pnlHeader.TabIndex = 0;
            // 
            // dateRangePicker
            // 
            dateRangePicker.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateRangePicker.Font = new Font("Segoe UI", 9F);
            dateRangePicker.Format = DateTimePickerFormat.Short;
            dateRangePicker.Location = new Point(986, 26);
            dateRangePicker.Margin = new Padding(4, 4, 4, 4);
            dateRangePicker.Name = "dateRangePicker";
            dateRangePicker.Size = new Size(175, 31);
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
            btnRefresh.Location = new Point(1171, 20);
            btnRefresh.Margin = new Padding(4, 4, 4, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(142, 54);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // lblDashboardTitle
            // 
            lblDashboardTitle.AutoSize = true;
            lblDashboardTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblDashboardTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblDashboardTitle.Location = new Point(18, 20);
            lblDashboardTitle.Margin = new Padding(4, 0, 4, 0);
            lblDashboardTitle.Name = "lblDashboardTitle";
            lblDashboardTitle.Size = new Size(315, 48);
            lblDashboardTitle.TabIndex = 0;
            lblDashboardTitle.Text = "VRMS Dashboard";
            // 
            // mainContainer
            // 
            mainContainer.Controls.Add(rightPanel);
            mainContainer.Controls.Add(leftPanel);
            mainContainer.Dock = DockStyle.Fill;
            mainContainer.Location = new Point(0, 100);
            mainContainer.Margin = new Padding(4, 4, 4, 4);
            mainContainer.Name = "mainContainer";
            mainContainer.Padding = new Padding(14, 16, 14, 16);
            mainContainer.Size = new Size(1500, 1034);
            mainContainer.TabIndex = 1;
            // 
            // rightPanel
            // 
            rightPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            rightPanel.Controls.Add(splitRight);
            rightPanel.Location = new Point(986, 16);
            rightPanel.Margin = new Padding(4, 4, 4, 4);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size(500, 1000);
            rightPanel.TabIndex = 1;
            // 
            // splitRight
            // 
            splitRight.Dock = DockStyle.Fill;
            splitRight.Location = new Point(0, 0);
            splitRight.Margin = new Padding(4, 4, 4, 4);
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
            splitRight.Size = new Size(500, 1000);
            splitRight.SplitterDistance = 500;
            splitRight.SplitterWidth = 16;
            splitRight.TabIndex = 0;
            // 
            // pnlTodaySchedule
            // 
            pnlTodaySchedule.BackColor = Color.White;
            pnlTodaySchedule.Controls.Add(dgvTodaySchedule);
            pnlTodaySchedule.Controls.Add(lblTodayScheduleTitle);
            pnlTodaySchedule.Dock = DockStyle.Fill;
            pnlTodaySchedule.Location = new Point(0, 0);
            pnlTodaySchedule.Margin = new Padding(4, 4, 4, 4);
            pnlTodaySchedule.Name = "pnlTodaySchedule";
            pnlTodaySchedule.Padding = new Padding(14, 16, 14, 16);
            pnlTodaySchedule.Size = new Size(500, 500);
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
            dgvTodaySchedule.Location = new Point(14, 59);
            dgvTodaySchedule.Margin = new Padding(4, 4, 4, 4);
            dgvTodaySchedule.Name = "dgvTodaySchedule";
            dgvTodaySchedule.ReadOnly = true;
            dgvTodaySchedule.RowHeadersVisible = false;
            dgvTodaySchedule.RowHeadersWidth = 51;
            dgvTodaySchedule.RowTemplate.Height = 28;
            dgvTodaySchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTodaySchedule.Size = new Size(471, 425);
            dgvTodaySchedule.TabIndex = 0;
            // 
            // lblTodayScheduleTitle
            // 
            lblTodayScheduleTitle.AutoSize = true;
            lblTodayScheduleTitle.Dock = DockStyle.Top;
            lblTodayScheduleTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTodayScheduleTitle.ForeColor = Color.FromArgb(41, 128, 185);
            lblTodayScheduleTitle.Location = new Point(14, 16);
            lblTodayScheduleTitle.Margin = new Padding(4, 0, 4, 15);
            lblTodayScheduleTitle.Name = "lblTodayScheduleTitle";
            lblTodayScheduleTitle.Padding = new Padding(0, 0, 0, 9);
            lblTodayScheduleTitle.Size = new Size(301, 39);
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
            pnlAlerts.Margin = new Padding(4, 4, 4, 4);
            pnlAlerts.Name = "pnlAlerts";
            pnlAlerts.Padding = new Padding(14, 16, 14, 16);
            pnlAlerts.Size = new Size(500, 484);
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
            dgvAlerts.Location = new Point(14, 59);
            dgvAlerts.Margin = new Padding(4, 4, 4, 4);
            dgvAlerts.Name = "dgvAlerts";
            dgvAlerts.ReadOnly = true;
            dgvAlerts.RowHeadersVisible = false;
            dgvAlerts.RowHeadersWidth = 51;
            dgvAlerts.RowTemplate.Height = 28;
            dgvAlerts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlerts.Size = new Size(471, 409);
            dgvAlerts.TabIndex = 0;
            // 
            // lblAlertsTitle
            // 
            lblAlertsTitle.AutoSize = true;
            lblAlertsTitle.Dock = DockStyle.Top;
            lblAlertsTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAlertsTitle.ForeColor = Color.FromArgb(192, 57, 43);
            lblAlertsTitle.Location = new Point(14, 16);
            lblAlertsTitle.Margin = new Padding(4, 0, 4, 15);
            lblAlertsTitle.Name = "lblAlertsTitle";
            lblAlertsTitle.Padding = new Padding(0, 0, 0, 9);
            lblAlertsTitle.Size = new Size(112, 39);
            lblAlertsTitle.TabIndex = 2;
            lblAlertsTitle.Text = "⚠️ Alerts";
            // 
            // leftPanel
            // 
            leftPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            leftPanel.Controls.Add(pnlChartArea);
            leftPanel.Controls.Add(pnlCards);
            leftPanel.Location = new Point(14, 16);
            leftPanel.Margin = new Padding(4, 4, 4, 4);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(964, 1000);
            leftPanel.TabIndex = 0;
            // 
            // pnlChartArea
            // 
            pnlChartArea.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlChartArea.BackColor = Color.White;
            pnlChartArea.Controls.Add(lblChartTitle);
            pnlChartArea.Location = new Point(0, 242);
            pnlChartArea.Margin = new Padding(4, 4, 4, 4);
            pnlChartArea.Name = "pnlChartArea";
            pnlChartArea.Padding = new Padding(14, 16, 14, 16);
            pnlChartArea.Size = new Size(964, 758);
            pnlChartArea.TabIndex = 1;
            // 
            // lblChartTitle
            // 
            lblChartTitle.AutoSize = true;
            lblChartTitle.Dock = DockStyle.Top;
            lblChartTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblChartTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblChartTitle.Location = new Point(14, 16);
            lblChartTitle.Margin = new Padding(4, 0, 4, 15);
            lblChartTitle.Name = "lblChartTitle";
            lblChartTitle.Padding = new Padding(0, 0, 0, 11);
            lblChartTitle.Size = new Size(344, 43);
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
            pnlCards.Controls.Add(pnlCardRevenue);
            pnlCards.Controls.Add(pnlCardOverdue);
            pnlCards.Controls.Add(pnlCardMaintenance);
            pnlCards.Location = new Point(0, 0);
            pnlCards.Margin = new Padding(4, 4, 4, 4);
            pnlCards.Name = "pnlCards";
            pnlCards.Size = new Size(964, 252);
            pnlCards.TabIndex = 0;
            // 
            // pnlCardTotal
            // 
            pnlCardTotal.BackColor = Color.FromArgb(52, 73, 94);
            pnlCardTotal.Controls.Add(lblTotalValue);
            pnlCardTotal.Controls.Add(lblTotalTitle);
            pnlCardTotal.Cursor = Cursors.Hand;
            pnlCardTotal.ForeColor = Color.White;
            pnlCardTotal.Location = new Point(8, 9);
            pnlCardTotal.Margin = new Padding(8, 9, 8, 9);
            pnlCardTotal.Name = "pnlCardTotal";
            pnlCardTotal.Padding = new Padding(14, 16, 14, 16);
            pnlCardTotal.Size = new Size(186, 216);
            pnlCardTotal.TabIndex = 0;
            // 
            // lblTotalValue
            // 
            lblTotalValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTotalValue.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblTotalValue.Location = new Point(14, 84);
            lblTotalValue.Margin = new Padding(4, 0, 4, 0);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(158, 84);
            lblTotalValue.TabIndex = 0;
            lblTotalValue.Text = "0";
            lblTotalValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.AutoSize = true;
            lblTotalTitle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblTotalTitle.ForeColor = Color.Gainsboro;
            lblTotalTitle.Location = new Point(14, 16);
            lblTotalTitle.Margin = new Padding(4, 0, 4, 0);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(100, 25);
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
            pnlCardAvailable.Location = new Point(210, 9);
            pnlCardAvailable.Margin = new Padding(8, 9, 8, 9);
            pnlCardAvailable.Name = "pnlCardAvailable";
            pnlCardAvailable.Padding = new Padding(14, 16, 14, 16);
            pnlCardAvailable.Size = new Size(186, 216);
            pnlCardAvailable.TabIndex = 1;
            // 
            // lblAvailableValue
            // 
            lblAvailableValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblAvailableValue.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblAvailableValue.Location = new Point(14, 84);
            lblAvailableValue.Margin = new Padding(4, 0, 4, 0);
            lblAvailableValue.Name = "lblAvailableValue";
            lblAvailableValue.Size = new Size(158, 84);
            lblAvailableValue.TabIndex = 0;
            lblAvailableValue.Text = "0";
            lblAvailableValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAvailableTitle
            // 
            lblAvailableTitle.AutoSize = true;
            lblAvailableTitle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblAvailableTitle.ForeColor = Color.Gainsboro;
            lblAvailableTitle.Location = new Point(14, 16);
            lblAvailableTitle.Margin = new Padding(4, 0, 4, 0);
            lblAvailableTitle.Name = "lblAvailableTitle";
            lblAvailableTitle.Size = new Size(157, 25);
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
            pnlCardRented.Location = new Point(412, 9);
            pnlCardRented.Margin = new Padding(8, 9, 8, 9);
            pnlCardRented.Name = "pnlCardRented";
            pnlCardRented.Padding = new Padding(14, 16, 14, 16);
            pnlCardRented.Size = new Size(186, 216);
            pnlCardRented.TabIndex = 2;
            // 
            // lblRentedValue
            // 
            lblRentedValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblRentedValue.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblRentedValue.Location = new Point(14, 84);
            lblRentedValue.Margin = new Padding(4, 0, 4, 0);
            lblRentedValue.Name = "lblRentedValue";
            lblRentedValue.Size = new Size(158, 84);
            lblRentedValue.TabIndex = 0;
            lblRentedValue.Text = "0";
            lblRentedValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRentedTitle
            // 
            lblRentedTitle.AutoSize = true;
            lblRentedTitle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblRentedTitle.ForeColor = Color.Gainsboro;
            lblRentedTitle.Location = new Point(14, 16);
            lblRentedTitle.Margin = new Padding(4, 0, 4, 0);
            lblRentedTitle.Name = "lblRentedTitle";
            lblRentedTitle.Size = new Size(118, 25);
            lblRentedTitle.TabIndex = 1;
            lblRentedTitle.Text = "Active Rents";
            // 
            // pnlCardRevenue
            // 
            pnlCardRevenue.BackColor = Color.FromArgb(142, 68, 173);
            pnlCardRevenue.Controls.Add(lblRevenueValue);
            pnlCardRevenue.Controls.Add(lblRevenueTitle);
            pnlCardRevenue.Cursor = Cursors.Hand;
            pnlCardRevenue.ForeColor = Color.White;
            pnlCardRevenue.Location = new Point(614, 9);
            pnlCardRevenue.Margin = new Padding(8, 9, 8, 9);
            pnlCardRevenue.Name = "pnlCardRevenue";
            pnlCardRevenue.Padding = new Padding(14, 16, 14, 16);
            pnlCardRevenue.Size = new Size(186, 216);
            pnlCardRevenue.TabIndex = 3;
            // 
            // lblRevenueValue
            // 
            lblRevenueValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblRevenueValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblRevenueValue.Location = new Point(14, 91);
            lblRevenueValue.Margin = new Padding(4, 0, 4, 0);
            lblRevenueValue.Name = "lblRevenueValue";
            lblRevenueValue.Size = new Size(158, 75);
            lblRevenueValue.TabIndex = 0;
            lblRevenueValue.Text = "₱0";
            lblRevenueValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRevenueTitle
            // 
            lblRevenueTitle.AutoSize = true;
            lblRevenueTitle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblRevenueTitle.ForeColor = Color.Gainsboro;
            lblRevenueTitle.Location = new Point(14, 16);
            lblRevenueTitle.Margin = new Padding(4, 0, 4, 0);
            lblRevenueTitle.Name = "lblRevenueTitle";
            lblRevenueTitle.Size = new Size(160, 25);
            lblRevenueTitle.TabIndex = 1;
            lblRevenueTitle.Text = "Revenue (Month)";
            // 
            // pnlCardOverdue
            // 
            pnlCardOverdue.BackColor = Color.FromArgb(192, 57, 43);
            pnlCardOverdue.Controls.Add(lblOverdueValue);
            pnlCardOverdue.Controls.Add(lblOverdueTitle);
            pnlCardOverdue.Cursor = Cursors.Hand;
            pnlCardOverdue.ForeColor = Color.White;
            pnlCardOverdue.Location = new Point(8, 243);
            pnlCardOverdue.Margin = new Padding(8, 9, 8, 9);
            pnlCardOverdue.Name = "pnlCardOverdue";
            pnlCardOverdue.Padding = new Padding(14, 16, 14, 16);
            pnlCardOverdue.Size = new Size(186, 216);
            pnlCardOverdue.TabIndex = 4;
            // 
            // lblOverdueValue
            // 
            lblOverdueValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblOverdueValue.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblOverdueValue.Location = new Point(14, 84);
            lblOverdueValue.Margin = new Padding(4, 0, 4, 0);
            lblOverdueValue.Name = "lblOverdueValue";
            lblOverdueValue.Size = new Size(158, 84);
            lblOverdueValue.TabIndex = 0;
            lblOverdueValue.Text = "₱0";
            lblOverdueValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblOverdueTitle
            // 
            lblOverdueTitle.AutoSize = true;
            lblOverdueTitle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblOverdueTitle.ForeColor = Color.Gainsboro;
            lblOverdueTitle.Location = new Point(14, 16);
            lblOverdueTitle.Margin = new Padding(4, 0, 4, 0);
            lblOverdueTitle.Name = "lblOverdueTitle";
            lblOverdueTitle.Size = new Size(85, 25);
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
            pnlCardMaintenance.Location = new Point(210, 243);
            pnlCardMaintenance.Margin = new Padding(8, 9, 8, 9);
            pnlCardMaintenance.Name = "pnlCardMaintenance";
            pnlCardMaintenance.Padding = new Padding(14, 16, 14, 16);
            pnlCardMaintenance.Size = new Size(186, 216);
            pnlCardMaintenance.TabIndex = 5;
            // 
            // lblMaintenanceValue
            // 
            lblMaintenanceValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblMaintenanceValue.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblMaintenanceValue.Location = new Point(14, 84);
            lblMaintenanceValue.Margin = new Padding(4, 0, 4, 0);
            lblMaintenanceValue.Name = "lblMaintenanceValue";
            lblMaintenanceValue.Size = new Size(158, 84);
            lblMaintenanceValue.TabIndex = 0;
            lblMaintenanceValue.Text = "0";
            lblMaintenanceValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMaintenanceTitle
            // 
            lblMaintenanceTitle.AutoSize = true;
            lblMaintenanceTitle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblMaintenanceTitle.ForeColor = Color.Gainsboro;
            lblMaintenanceTitle.Location = new Point(0, 16);
            lblMaintenanceTitle.Margin = new Padding(4, 0, 4, 0);
            lblMaintenanceTitle.Name = "lblMaintenanceTitle";
            lblMaintenanceTitle.Size = new Size(181, 25);
            lblMaintenanceTitle.TabIndex = 1;
            lblMaintenanceTitle.Text = "Under Maintenance";
            // 
            // DashboardView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 243, 244);
            Controls.Add(mainContainer);
            Controls.Add(pnlHeader);
            Margin = new Padding(4, 4, 4, 4);
            MinimumSize = new Size(1286, 1000);
            Name = "DashboardView";
            Size = new Size(1500, 1134);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
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
            pnlCardRevenue.ResumeLayout(false);
            pnlCardRevenue.PerformLayout();
            pnlCardOverdue.ResumeLayout(false);
            pnlCardOverdue.PerformLayout();
            pnlCardMaintenance.ResumeLayout(false);
            pnlCardMaintenance.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private DateTimePicker dateRangePicker;
        private Button btnRefresh;
        private Label lblDashboardTitle;
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