namespace VRMS.UI.Controls.Rental_ReservationCalendar
{
    partial class CalendarView
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            dtpMonthYear = new DateTimePicker();
            btnNextMonth = new Button();
            btnPrevMonth = new Button();
            lblTitle = new Label();
            cmbFilter = new ComboBox();
            cmbSort = new ComboBox();
            btnList = new Button();
            btnNewRental = new Button();
            pnlMain = new Panel();
            splitContainer = new SplitContainer();
            pnlVehicleList = new Panel();
            dgvVehicles = new DataGridView();
            colYear = new DataGridViewTextBoxColumn();
            colLicense = new DataGridViewTextBoxColumn();
            colModel = new DataGridViewTextBoxColumn();
            pnlCalendarCanvas = new Panel();
            toolTip = new ToolTip(components);
            pnlHeader.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            pnlVehicleList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVehicles).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlHeader.Controls.Add(dtpMonthYear);
            pnlHeader.Controls.Add(btnNextMonth);
            pnlHeader.Controls.Add(btnPrevMonth);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(cmbFilter);
            pnlHeader.Controls.Add(cmbSort);
            pnlHeader.Controls.Add(btnList);
            pnlHeader.Controls.Add(btnNewRental);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1371, 66);
            pnlHeader.TabIndex = 0;
            // 
            // dtpMonthYear
            // 
            dtpMonthYear.CustomFormat = "MMMM yyyy";
            dtpMonthYear.Format = DateTimePickerFormat.Custom;
            dtpMonthYear.Location = new Point(171, 17);
            dtpMonthYear.Margin = new Padding(3, 4, 3, 4);
            dtpMonthYear.Name = "dtpMonthYear";
            dtpMonthYear.ShowUpDown = true;
            dtpMonthYear.Size = new Size(171, 27);
            dtpMonthYear.TabIndex = 7;
            // 
            // btnNextMonth
            // 
            btnNextMonth.Location = new Point(350, 17);
            btnNextMonth.Margin = new Padding(3, 4, 3, 4);
            btnNextMonth.Name = "btnNextMonth";
            btnNextMonth.Size = new Size(34, 31);
            btnNextMonth.TabIndex = 6;
            btnNextMonth.Text = ">";
            btnNextMonth.UseVisualStyleBackColor = true;
            // 
            // btnPrevMonth
            // 
            btnPrevMonth.Location = new Point(130, 17);
            btnPrevMonth.Margin = new Padding(3, 4, 3, 4);
            btnPrevMonth.Name = "btnPrevMonth";
            btnPrevMonth.Size = new Size(34, 31);
            btnPrevMonth.TabIndex = 5;
            btnPrevMonth.Text = "<";
            btnPrevMonth.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(11, 13);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(104, 32);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "Rentals ";
            // 
            // cmbFilter
            // 
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.FormattingEnabled = true;
            cmbFilter.Items.AddRange(new object[] { "Small Category", "Medium Category", "Large Category", "All Categories" });
            cmbFilter.Location = new Point(400, 17);
            cmbFilter.Margin = new Padding(3, 4, 3, 4);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(137, 28);
            cmbFilter.TabIndex = 3;
            // 
            // cmbSort
            // 
            cmbSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSort.FormattingEnabled = true;
            cmbSort.Items.AddRange(new object[] { "Category", "License Plate", "Year", "Model" });
            cmbSort.Location = new Point(549, 17);
            cmbSort.Margin = new Padding(3, 4, 3, 4);
            cmbSort.Name = "cmbSort";
            cmbSort.Size = new Size(137, 28);
            cmbSort.TabIndex = 2;
            // 
            // btnList
            // 
            btnList.Location = new Point(697, 16);
            btnList.Margin = new Padding(3, 4, 3, 4);
            btnList.Name = "btnList";
            btnList.Size = new Size(86, 31);
            btnList.TabIndex = 1;
            btnList.Text = "List View";
            btnList.UseVisualStyleBackColor = true;
            // 
            // btnNewRental
            // 
            btnNewRental.BackColor = Color.SteelBlue;
            btnNewRental.FlatStyle = FlatStyle.Flat;
            btnNewRental.ForeColor = Color.White;
            btnNewRental.Location = new Point(800, 16);
            btnNewRental.Margin = new Padding(3, 4, 3, 4);
            btnNewRental.Name = "btnNewRental";
            btnNewRental.Size = new Size(114, 31);
            btnNewRental.TabIndex = 0;
            btnNewRental.Text = "New Rental";
            btnNewRental.UseVisualStyleBackColor = false;
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(splitContainer);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 66);
            pnlMain.Margin = new Padding(3, 4, 3, 4);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1371, 734);
            pnlMain.TabIndex = 1;
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.FixedPanel = FixedPanel.Panel1;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Margin = new Padding(3, 4, 3, 4);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(pnlVehicleList);
            splitContainer.Panel1MinSize = 250;
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(pnlCalendarCanvas);
            splitContainer.Size = new Size(1371, 734);
            splitContainer.SplitterDistance = 286;
            splitContainer.SplitterWidth = 5;
            splitContainer.TabIndex = 0;
            // 
            // pnlVehicleList
            // 
            pnlVehicleList.Controls.Add(dgvVehicles);
            pnlVehicleList.Dock = DockStyle.Fill;
            pnlVehicleList.Location = new Point(0, 0);
            pnlVehicleList.Margin = new Padding(3, 4, 3, 4);
            pnlVehicleList.Name = "pnlVehicleList";
            pnlVehicleList.Padding = new Padding(6, 7, 6, 7);
            pnlVehicleList.Size = new Size(286, 734);
            pnlVehicleList.TabIndex = 0;
            // 
            // dgvVehicles
            // 
            dgvVehicles.AllowUserToAddRows = false;
            dgvVehicles.AllowUserToDeleteRows = false;
            dgvVehicles.AllowUserToResizeRows = false;
            dgvVehicles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVehicles.BackgroundColor = Color.White;
            dgvVehicles.BorderStyle = BorderStyle.None;
            dgvVehicles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVehicles.ColumnHeadersVisible = false;
            dgvVehicles.Columns.AddRange(new DataGridViewColumn[] { colYear, colLicense, colModel });
            dgvVehicles.Dock = DockStyle.Fill;
            dgvVehicles.Location = new Point(6, 7);
            dgvVehicles.Margin = new Padding(3, 4, 3, 4);
            dgvVehicles.MultiSelect = false;
            dgvVehicles.Name = "dgvVehicles";
            dgvVehicles.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvVehicles.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvVehicles.RowHeadersVisible = false;
            dgvVehicles.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = Color.WhiteSmoke;
            dgvVehicles.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvVehicles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehicles.Size = new Size(274, 720);
            dgvVehicles.TabIndex = 0;
            // 
            // colYear
            // 
            colYear.DataPropertyName = "Year";
            colYear.FillWeight = 30F;
            colYear.HeaderText = "Year";
            colYear.MinimumWidth = 6;
            colYear.Name = "colYear";
            colYear.ReadOnly = true;
            // 
            // colLicense
            // 
            colLicense.DataPropertyName = "LicensePlate";
            colLicense.FillWeight = 40F;
            colLicense.HeaderText = "License";
            colLicense.MinimumWidth = 6;
            colLicense.Name = "colLicense";
            colLicense.ReadOnly = true;
            // 
            // colModel
            // 
            colModel.DataPropertyName = "Model";
            colModel.FillWeight = 60F;
            colModel.HeaderText = "Model";
            colModel.MinimumWidth = 6;
            colModel.Name = "colModel";
            colModel.ReadOnly = true;
            // 
            // pnlCalendarCanvas
            // 
            pnlCalendarCanvas.BackColor = Color.White;
            pnlCalendarCanvas.Dock = DockStyle.Fill;
            pnlCalendarCanvas.Location = new Point(0, 0);
            pnlCalendarCanvas.Margin = new Padding(3, 4, 3, 4);
            pnlCalendarCanvas.Name = "pnlCalendarCanvas";
            pnlCalendarCanvas.Size = new Size(1080, 734);
            pnlCalendarCanvas.TabIndex = 0;
            pnlCalendarCanvas.Paint += pnlCalendarCanvas_Paint;
            pnlCalendarCanvas.Resize += pnlCalendarCanvas_Resize;
            // 
            // CalendarView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pnlMain);
            Controls.Add(pnlHeader);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CalendarView";
            Size = new Size(1371, 800);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlMain.ResumeLayout(false);
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            pnlVehicleList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVehicles).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.DateTimePicker dtpMonthYear;
        private System.Windows.Forms.Button btnNextMonth;
        private System.Windows.Forms.Button btnPrevMonth;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Button btnNewRental;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel pnlVehicleList;
        private System.Windows.Forms.DataGridView dgvVehicles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLicense;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModel;
        private System.Windows.Forms.Panel pnlCalendarCanvas;
        private System.Windows.Forms.ToolTip toolTip;
    }
}