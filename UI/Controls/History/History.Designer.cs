namespace VRMS.UI.Controls.History
{
    partial class History
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label lblSummary;

        // ===== MAIN SPLIT CONTAINER =====
        private SplitContainer splitContainerMain;

        // LEFT PANEL - HISTORY LIST
        private Panel panelHistoryList;

        // RIGHT PANEL - DETAILS AREA
        private Panel panelDetailsArea;
        private Panel panelNoSelection;
        private Label lblNoSelection;
        private Panel panelDetailsContent;
        private Panel panelVehicleInfo;
        private PictureBox picVehicle;
        private Label lblVehicleName;
        private Panel panelInfoGrid;
        private Label lblReservationIdTitle;
        private Label lblReservationIdValue;
        private Label lblStatusTitle;
        private Label lblStatusValue;
        private Label lblDatesTitle;
        private Label lblDatesValue;
        private Label lblAmountTitle;
        private Label lblAmountValue;
        private Label lblCustomerTitle;
        private Label lblCustomerValue;
        private Label lblPaymentTitle;
        private Label lblPaymentValue;
        private Label lblCreatedTitle;
        private Label lblCreatedValue;

        // ACTION BUTTONS (Always visible)
        private Panel panelActions;
        private Button btnRefund;
        private Button btnViewReceipt;

        private Panel panelDetailsHeader;
        private Label lblDetailsTitle;
        private ToolTip toolTip;

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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lblSummary = new Label();
            splitContainerMain = new SplitContainer();
            panelHistoryList = new Panel();
            panelDetailsArea = new Panel();
            panelActions = new Panel();
            btnViewReceipt = new Button();
            btnRefund = new Button();
            panelDetailsContent = new Panel();
            panelInfoGrid = new Panel();
            lblCreatedValue = new Label();
            lblCreatedTitle = new Label();
            lblPaymentValue = new Label();
            lblPaymentTitle = new Label();
            lblCustomerValue = new Label();
            lblCustomerTitle = new Label();
            lblAmountValue = new Label();
            lblAmountTitle = new Label();
            lblDatesValue = new Label();
            lblDatesTitle = new Label();
            lblStatusValue = new Label();
            lblStatusTitle = new Label();
            lblReservationIdValue = new Label();
            lblReservationIdTitle = new Label();
            panelVehicleInfo = new Panel();
            lblVehicleName = new Label();
            picVehicle = new PictureBox();
            panelDetailsHeader = new Panel();
            lblDetailsTitle = new Label();
            panelNoSelection = new Panel();
            lblNoSelection = new Label();
            toolTip = new ToolTip(components);
            panelHeader = new Panel();
            dgvRentals = new DataGridView();
            colRentalId = new DataGridViewTextBoxColumn();
            colRentalVehicle = new DataGridViewTextBoxColumn();
            colRentalDates = new DataGridViewTextBoxColumn();
            colRentalStatus = new DataGridViewTextBoxColumn();
            colRentalAmount = new DataGridViewTextBoxColumn();
            colRentalOdo = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            panelHistoryList.SuspendLayout();
            panelDetailsArea.SuspendLayout();
            panelActions.SuspendLayout();
            panelDetailsContent.SuspendLayout();
            panelInfoGrid.SuspendLayout();
            panelVehicleInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picVehicle).BeginInit();
            panelDetailsHeader.SuspendLayout();
            panelNoSelection.SuspendLayout();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRentals).BeginInit();
            SuspendLayout();
            // 
            // lblSummary
            // 
            lblSummary.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSummary.Font = new Font("Segoe UI", 10F);
            lblSummary.ForeColor = Color.Black;
            lblSummary.Location = new Point(900, 13);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(280, 40);
            lblSummary.TabIndex = 1;
            lblSummary.Text = "Total: 0 reservations | 0 rentals";
            lblSummary.TextAlign = ContentAlignment.MiddleRight;
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 70);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(panelHistoryList);
            splitContainerMain.Panel1.Padding = new Padding(10);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(panelDetailsArea);
            splitContainerMain.Panel2.Padding = new Padding(10);
            splitContainerMain.Size = new Size(1200, 730);
            splitContainerMain.SplitterDistance = 800;
            splitContainerMain.SplitterWidth = 1;
            splitContainerMain.TabIndex = 1;
            // 
            // panelHistoryList
            // 
            panelHistoryList.BackColor = Color.White;
            panelHistoryList.Controls.Add(dgvRentals);
            panelHistoryList.Dock = DockStyle.Fill;
            panelHistoryList.Location = new Point(10, 10);
            panelHistoryList.Name = "panelHistoryList";
            panelHistoryList.Size = new Size(780, 710);
            panelHistoryList.TabIndex = 0;
            // 
            // panelDetailsArea
            // 
            panelDetailsArea.BackColor = Color.White;
            panelDetailsArea.Controls.Add(panelActions);
            panelDetailsArea.Controls.Add(panelDetailsContent);
            panelDetailsArea.Controls.Add(panelNoSelection);
            panelDetailsArea.Dock = DockStyle.Fill;
            panelDetailsArea.Location = new Point(10, 10);
            panelDetailsArea.Name = "panelDetailsArea";
            panelDetailsArea.Size = new Size(379, 710);
            panelDetailsArea.TabIndex = 0;
            // 
            // panelActions
            // 
            panelActions.BackColor = Color.FromArgb(248, 249, 250);
            panelActions.Controls.Add(btnViewReceipt);
            panelActions.Controls.Add(btnRefund);
            panelActions.Dock = DockStyle.Bottom;
            panelActions.Location = new Point(0, 587);
            panelActions.Name = "panelActions";
            panelActions.Padding = new Padding(10);
            panelActions.Size = new Size(379, 123);
            panelActions.TabIndex = 3;
            // 
            // btnViewReceipt
            // 
            btnViewReceipt.BackColor = Color.FromArgb(52, 152, 219);
            btnViewReceipt.Dock = DockStyle.Top;
            btnViewReceipt.FlatAppearance.BorderSize = 0;
            btnViewReceipt.FlatStyle = FlatStyle.Flat;
            btnViewReceipt.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnViewReceipt.ForeColor = Color.White;
            btnViewReceipt.Location = new Point(10, 60);
            btnViewReceipt.Name = "btnViewReceipt";
            btnViewReceipt.Size = new Size(359, 50);
            btnViewReceipt.TabIndex = 2;
            btnViewReceipt.Text = "📄 View Receipt";
            btnViewReceipt.UseVisualStyleBackColor = false;
            btnViewReceipt.Click += BtnViewReceipt_Click;
            // 
            // btnRefund
            // 
            btnRefund.BackColor = Color.FromArgb(231, 76, 60);
            btnRefund.Dock = DockStyle.Top;
            btnRefund.FlatAppearance.BorderSize = 0;
            btnRefund.FlatStyle = FlatStyle.Flat;
            btnRefund.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnRefund.ForeColor = Color.White;
            btnRefund.Location = new Point(10, 10);
            btnRefund.Name = "btnRefund";
            btnRefund.Size = new Size(359, 50);
            btnRefund.TabIndex = 0;
            btnRefund.Text = "💸 Refund";
            btnRefund.UseVisualStyleBackColor = false;
            // 
            // panelDetailsContent
            // 
            panelDetailsContent.BackColor = Color.White;
            panelDetailsContent.Controls.Add(panelInfoGrid);
            panelDetailsContent.Controls.Add(panelVehicleInfo);
            panelDetailsContent.Controls.Add(panelDetailsHeader);
            panelDetailsContent.Dock = DockStyle.Fill;
            panelDetailsContent.Location = new Point(0, 0);
            panelDetailsContent.Name = "panelDetailsContent";
            panelDetailsContent.Size = new Size(379, 710);
            panelDetailsContent.TabIndex = 0;
            panelDetailsContent.Visible = false;
            // 
            // panelInfoGrid
            // 
            panelInfoGrid.BackColor = Color.White;
            panelInfoGrid.Controls.Add(lblCreatedValue);
            panelInfoGrid.Controls.Add(lblCreatedTitle);
            panelInfoGrid.Controls.Add(lblPaymentValue);
            panelInfoGrid.Controls.Add(lblPaymentTitle);
            panelInfoGrid.Controls.Add(lblCustomerValue);
            panelInfoGrid.Controls.Add(lblCustomerTitle);
            panelInfoGrid.Controls.Add(lblAmountValue);
            panelInfoGrid.Controls.Add(lblAmountTitle);
            panelInfoGrid.Controls.Add(lblDatesValue);
            panelInfoGrid.Controls.Add(lblDatesTitle);
            panelInfoGrid.Controls.Add(lblStatusValue);
            panelInfoGrid.Controls.Add(lblStatusTitle);
            panelInfoGrid.Controls.Add(lblReservationIdValue);
            panelInfoGrid.Controls.Add(lblReservationIdTitle);
            panelInfoGrid.Dock = DockStyle.Top;
            panelInfoGrid.Location = new Point(0, 340);
            panelInfoGrid.Name = "panelInfoGrid";
            panelInfoGrid.Padding = new Padding(15);
            panelInfoGrid.Size = new Size(379, 241);
            panelInfoGrid.TabIndex = 2;
            // 
            // lblCreatedValue
            // 
            lblCreatedValue.AutoSize = true;
            lblCreatedValue.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblCreatedValue.ForeColor = Color.FromArgb(30, 60, 90);
            lblCreatedValue.Location = new Point(120, 220);
            lblCreatedValue.Name = "lblCreatedValue";
            lblCreatedValue.Size = new Size(82, 20);
            lblCreatedValue.TabIndex = 13;
            lblCreatedValue.Text = "2024-01-15";
            // 
            // lblCreatedTitle
            // 
            lblCreatedTitle.AutoSize = true;
            lblCreatedTitle.Font = new Font("Segoe UI", 8.5F);
            lblCreatedTitle.ForeColor = Color.FromArgb(100, 100, 100);
            lblCreatedTitle.Location = new Point(15, 220);
            lblCreatedTitle.Name = "lblCreatedTitle";
            lblCreatedTitle.Size = new Size(64, 20);
            lblCreatedTitle.TabIndex = 12;
            lblCreatedTitle.Text = "Created:";
            // 
            // lblPaymentValue
            // 
            lblPaymentValue.AutoSize = true;
            lblPaymentValue.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblPaymentValue.ForeColor = Color.FromArgb(46, 204, 113);
            lblPaymentValue.Location = new Point(120, 190);
            lblPaymentValue.Name = "lblPaymentValue";
            lblPaymentValue.Size = new Size(95, 20);
            lblPaymentValue.TabIndex = 11;
            lblPaymentValue.Text = "Paid - GCash";
            // 
            // lblPaymentTitle
            // 
            lblPaymentTitle.AutoSize = true;
            lblPaymentTitle.Font = new Font("Segoe UI", 8.5F);
            lblPaymentTitle.ForeColor = Color.FromArgb(100, 100, 100);
            lblPaymentTitle.Location = new Point(15, 190);
            lblPaymentTitle.Name = "lblPaymentTitle";
            lblPaymentTitle.Size = new Size(68, 20);
            lblPaymentTitle.TabIndex = 10;
            lblPaymentTitle.Text = "Payment:";
            // 
            // lblCustomerValue
            // 
            lblCustomerValue.AutoSize = true;
            lblCustomerValue.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblCustomerValue.ForeColor = Color.FromArgb(30, 60, 90);
            lblCustomerValue.Location = new Point(120, 160);
            lblCustomerValue.Name = "lblCustomerValue";
            lblCustomerValue.Size = new Size(119, 20);
            lblCustomerValue.TabIndex = 9;
            lblCustomerValue.Text = "John D. (ID: 123)";
            // 
            // lblCustomerTitle
            // 
            lblCustomerTitle.AutoSize = true;
            lblCustomerTitle.Font = new Font("Segoe UI", 8.5F);
            lblCustomerTitle.ForeColor = Color.FromArgb(100, 100, 100);
            lblCustomerTitle.Location = new Point(15, 160);
            lblCustomerTitle.Name = "lblCustomerTitle";
            lblCustomerTitle.Size = new Size(75, 20);
            lblCustomerTitle.TabIndex = 8;
            lblCustomerTitle.Text = "Customer:";
            // 
            // lblAmountValue
            // 
            lblAmountValue.AutoSize = true;
            lblAmountValue.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblAmountValue.ForeColor = Color.FromArgb(46, 204, 113);
            lblAmountValue.Location = new Point(120, 130);
            lblAmountValue.Name = "lblAmountValue";
            lblAmountValue.Size = new Size(74, 20);
            lblAmountValue.TabIndex = 7;
            lblAmountValue.Text = "₱5,000.00";
            // 
            // lblAmountTitle
            // 
            lblAmountTitle.AutoSize = true;
            lblAmountTitle.Font = new Font("Segoe UI", 8.5F);
            lblAmountTitle.ForeColor = Color.FromArgb(100, 100, 100);
            lblAmountTitle.Location = new Point(15, 130);
            lblAmountTitle.Name = "lblAmountTitle";
            lblAmountTitle.Size = new Size(65, 20);
            lblAmountTitle.TabIndex = 6;
            lblAmountTitle.Text = "Amount:";
            // 
            // lblDatesValue
            // 
            lblDatesValue.AutoSize = true;
            lblDatesValue.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblDatesValue.ForeColor = Color.FromArgb(30, 60, 90);
            lblDatesValue.Location = new Point(120, 100);
            lblDatesValue.Name = "lblDatesValue";
            lblDatesValue.Size = new Size(146, 20);
            lblDatesValue.TabIndex = 5;
            lblDatesValue.Text = "Jan 15 - Jan 18, 2024";
            // 
            // lblDatesTitle
            // 
            lblDatesTitle.AutoSize = true;
            lblDatesTitle.Font = new Font("Segoe UI", 8.5F);
            lblDatesTitle.ForeColor = Color.FromArgb(100, 100, 100);
            lblDatesTitle.Location = new Point(15, 100);
            lblDatesTitle.Name = "lblDatesTitle";
            lblDatesTitle.Size = new Size(50, 20);
            lblDatesTitle.TabIndex = 4;
            lblDatesTitle.Text = "Dates:";
            // 
            // lblStatusValue
            // 
            lblStatusValue.AutoSize = true;
            lblStatusValue.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblStatusValue.ForeColor = Color.FromArgb(46, 204, 113);
            lblStatusValue.Location = new Point(120, 70);
            lblStatusValue.Name = "lblStatusValue";
            lblStatusValue.Size = new Size(81, 20);
            lblStatusValue.TabIndex = 3;
            lblStatusValue.Text = "Confirmed";
            // 
            // lblStatusTitle
            // 
            lblStatusTitle.AutoSize = true;
            lblStatusTitle.Font = new Font("Segoe UI", 8.5F);
            lblStatusTitle.ForeColor = Color.FromArgb(100, 100, 100);
            lblStatusTitle.Location = new Point(15, 70);
            lblStatusTitle.Name = "lblStatusTitle";
            lblStatusTitle.Size = new Size(52, 20);
            lblStatusTitle.TabIndex = 2;
            lblStatusTitle.Text = "Status:";
            // 
            // lblReservationIdValue
            // 
            lblReservationIdValue.AutoSize = true;
            lblReservationIdValue.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblReservationIdValue.ForeColor = Color.FromArgb(30, 60, 90);
            lblReservationIdValue.Location = new Point(120, 40);
            lblReservationIdValue.Name = "lblReservationIdValue";
            lblReservationIdValue.Size = new Size(41, 20);
            lblReservationIdValue.TabIndex = 1;
            lblReservationIdValue.Text = "5678";
            // 
            // lblReservationIdTitle
            // 
            lblReservationIdTitle.AutoSize = true;
            lblReservationIdTitle.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblReservationIdTitle.ForeColor = Color.FromArgb(30, 60, 90);
            lblReservationIdTitle.Location = new Point(15, 40);
            lblReservationIdTitle.Name = "lblReservationIdTitle";
            lblReservationIdTitle.Size = new Size(107, 20);
            lblReservationIdTitle.TabIndex = 0;
            lblReservationIdTitle.Text = "Reservation #:";
            // 
            // panelVehicleInfo
            // 
            panelVehicleInfo.BackColor = Color.White;
            panelVehicleInfo.Controls.Add(lblVehicleName);
            panelVehicleInfo.Controls.Add(picVehicle);
            panelVehicleInfo.Dock = DockStyle.Top;
            panelVehicleInfo.Location = new Point(0, 40);
            panelVehicleInfo.Name = "panelVehicleInfo";
            panelVehicleInfo.Padding = new Padding(10);
            panelVehicleInfo.Size = new Size(379, 300);
            panelVehicleInfo.TabIndex = 1;
            // 
            // lblVehicleName
            // 
            lblVehicleName.Dock = DockStyle.Top;
            lblVehicleName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblVehicleName.Location = new Point(10, 260);
            lblVehicleName.Name = "lblVehicleName";
            lblVehicleName.Size = new Size(359, 30);
            lblVehicleName.TabIndex = 1;
            lblVehicleName.Text = "Toyota Camry 2023";
            lblVehicleName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picVehicle
            // 
            picVehicle.BackColor = Color.FromArgb(248, 249, 250);
            picVehicle.BorderStyle = BorderStyle.FixedSingle;
            picVehicle.Dock = DockStyle.Top;
            picVehicle.Location = new Point(10, 10);
            picVehicle.Name = "picVehicle";
            picVehicle.Size = new Size(359, 250);
            picVehicle.SizeMode = PictureBoxSizeMode.Zoom;
            picVehicle.TabIndex = 0;
            picVehicle.TabStop = false;
            // 
            // panelDetailsHeader
            // 
            panelDetailsHeader.BackColor = Color.FromArgb(30, 60, 90);
            panelDetailsHeader.Controls.Add(lblDetailsTitle);
            panelDetailsHeader.Dock = DockStyle.Top;
            panelDetailsHeader.Location = new Point(0, 0);
            panelDetailsHeader.Name = "panelDetailsHeader";
            panelDetailsHeader.Size = new Size(379, 40);
            panelDetailsHeader.TabIndex = 0;
            // 
            // lblDetailsTitle
            // 
            lblDetailsTitle.Dock = DockStyle.Fill;
            lblDetailsTitle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblDetailsTitle.ForeColor = Color.White;
            lblDetailsTitle.Location = new Point(0, 0);
            lblDetailsTitle.Name = "lblDetailsTitle";
            lblDetailsTitle.Size = new Size(379, 40);
            lblDetailsTitle.TabIndex = 0;
            lblDetailsTitle.Text = "📋 Details";
            lblDetailsTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelNoSelection
            // 
            panelNoSelection.BackColor = Color.FromArgb(248, 249, 250);
            panelNoSelection.Controls.Add(lblNoSelection);
            panelNoSelection.Dock = DockStyle.Fill;
            panelNoSelection.Location = new Point(0, 0);
            panelNoSelection.Name = "panelNoSelection";
            panelNoSelection.Size = new Size(379, 710);
            panelNoSelection.TabIndex = 1;
            // 
            // lblNoSelection
            // 
            lblNoSelection.Dock = DockStyle.Fill;
            lblNoSelection.Font = new Font("Segoe UI", 11F);
            lblNoSelection.ForeColor = Color.FromArgb(108, 117, 125);
            lblNoSelection.Location = new Point(0, 0);
            lblNoSelection.Name = "lblNoSelection";
            lblNoSelection.Size = new Size(379, 710);
            lblNoSelection.TabIndex = 0;
            lblNoSelection.Text = "Select a record to view details";
            lblNoSelection.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.White;
            panelHeader.Controls.Add(lblSummary);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1200, 70);
            panelHeader.TabIndex = 0;
            // 
            // dgvRentals
            // 
            dgvRentals.AllowUserToAddRows = false;
            dgvRentals.AllowUserToDeleteRows = false;
            dgvRentals.AllowUserToResizeRows = false;
            dgvRentals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRentals.BackgroundColor = Color.White;
            dgvRentals.BorderStyle = BorderStyle.None;
            dgvRentals.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRentals.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(32, 191, 158);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(32, 191, 158);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvRentals.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvRentals.ColumnHeadersHeight = 40;
            dgvRentals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvRentals.Columns.AddRange(new DataGridViewColumn[] { colRentalId, colRentalVehicle, colRentalDates, colRentalStatus, colRentalAmount, colRentalOdo });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(236, 240, 241);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvRentals.DefaultCellStyle = dataGridViewCellStyle2;
            dgvRentals.Dock = DockStyle.Fill;
            dgvRentals.EnableHeadersVisualStyles = false;
            dgvRentals.GridColor = Color.WhiteSmoke;
            dgvRentals.Location = new Point(0, 0);
            dgvRentals.MultiSelect = false;
            dgvRentals.Name = "dgvRentals";
            dgvRentals.ReadOnly = true;
            dgvRentals.RowHeadersVisible = false;
            dgvRentals.RowHeadersWidth = 51;
            dgvRentals.RowTemplate.Height = 35;
            dgvRentals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRentals.Size = new Size(780, 710);
            dgvRentals.TabIndex = 2;
            // 
            // colRentalId
            // 
            colRentalId.HeaderText = "ID";
            colRentalId.MinimumWidth = 6;
            colRentalId.Name = "colRentalId";
            colRentalId.ReadOnly = true;
            // 
            // colRentalVehicle
            // 
            colRentalVehicle.HeaderText = "Vehicle";
            colRentalVehicle.MinimumWidth = 6;
            colRentalVehicle.Name = "colRentalVehicle";
            colRentalVehicle.ReadOnly = true;
            // 
            // colRentalDates
            // 
            colRentalDates.HeaderText = "Dates";
            colRentalDates.MinimumWidth = 6;
            colRentalDates.Name = "colRentalDates";
            colRentalDates.ReadOnly = true;
            // 
            // colRentalStatus
            // 
            colRentalStatus.HeaderText = "Status";
            colRentalStatus.MinimumWidth = 6;
            colRentalStatus.Name = "colRentalStatus";
            colRentalStatus.ReadOnly = true;
            // 
            // colRentalAmount
            // 
            colRentalAmount.HeaderText = "Amount";
            colRentalAmount.MinimumWidth = 6;
            colRentalAmount.Name = "colRentalAmount";
            colRentalAmount.ReadOnly = true;
            // 
            // colRentalOdo
            // 
            colRentalOdo.HeaderText = "Odometer";
            colRentalOdo.MinimumWidth = 6;
            colRentalOdo.Name = "colRentalOdo";
            colRentalOdo.ReadOnly = true;
            // 
            // History
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(splitContainerMain);
            Controls.Add(panelHeader);
            Name = "History";
            Size = new Size(1200, 800);
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            panelHistoryList.ResumeLayout(false);
            panelDetailsArea.ResumeLayout(false);
            panelActions.ResumeLayout(false);
            panelDetailsContent.ResumeLayout(false);
            panelInfoGrid.ResumeLayout(false);
            panelInfoGrid.PerformLayout();
            panelVehicleInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picVehicle).EndInit();
            panelDetailsHeader.ResumeLayout(false);
            panelNoSelection.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRentals).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelHeader;
        private DataGridView dgvRentals;
        private DataGridViewTextBoxColumn colRentalId;
        private DataGridViewTextBoxColumn colRentalVehicle;
        private DataGridViewTextBoxColumn colRentalDates;
        private DataGridViewTextBoxColumn colRentalStatus;
        private DataGridViewTextBoxColumn colRentalAmount;
        private DataGridViewTextBoxColumn colRentalOdo;
    }
}