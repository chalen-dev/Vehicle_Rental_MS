namespace VRMS.UI.Controls.Reports
{
    partial class ReportsView
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            btnExportPDF = new Button();
            btnExportExcel = new Button();
            lblTitle = new Label();
            tcReports = new TabControl();
            tpFleet = new TabPage();
            dgvReportData = new DataGridView();
            tpRevenue = new TabPage();
            tpPerformance = new TabPage();
            pnlFilters = new Panel();
            btnApplyFilter = new Button();
            dtpEnd = new DateTimePicker();
            dtpStart = new DateTimePicker();
            lblDateTo = new Label();
            lblDateFrom = new Label();
            pnlHeader.SuspendLayout();
            tcReports.SuspendLayout();
            tpFleet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReportData).BeginInit();
            pnlFilters.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.WhiteSmoke;
            pnlHeader.Controls.Add(btnExportPDF);
            pnlHeader.Controls.Add(btnExportExcel);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1000, 100);
            pnlHeader.TabIndex = 0;
            // 
            // btnExportPDF
            // 
            btnExportPDF.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportPDF.BackColor = Color.FromArgb(231, 76, 60);
            btnExportPDF.FlatAppearance.BorderSize = 0;
            btnExportPDF.FlatStyle = FlatStyle.Flat;
            btnExportPDF.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnExportPDF.ForeColor = Color.White;
            btnExportPDF.Location = new Point(840, 25);
            btnExportPDF.Margin = new Padding(3, 4, 3, 4);
            btnExportPDF.Name = "btnExportPDF";
            btnExportPDF.Size = new Size(140, 50);
            btnExportPDF.TabIndex = 1;
            btnExportPDF.Text = "📄 Export PDF";
            btnExportPDF.UseVisualStyleBackColor = false;
            btnExportPDF.Click += btnExportPDF_Click;
            // 
            // btnExportExcel
            // 
            btnExportExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportExcel.BackColor = Color.FromArgb(39, 174, 96);
            btnExportExcel.FlatAppearance.BorderSize = 0;
            btnExportExcel.FlatStyle = FlatStyle.Flat;
            btnExportExcel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnExportExcel.ForeColor = Color.White;
            btnExportExcel.Location = new Point(690, 25);
            btnExportExcel.Margin = new Padding(3, 4, 3, 4);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(140, 50);
            btnExportExcel.TabIndex = 2;
            btnExportExcel.Text = "📊 Export Excel";
            btnExportExcel.UseVisualStyleBackColor = false;
            btnExportExcel.Click += btnExportExcel_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitle.Location = new Point(20, 19);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(375, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Analytics & Reporting";
            // 
            // tcReports
            // 
            tcReports.Controls.Add(tpFleet);
            tcReports.Controls.Add(tpRevenue);
            tcReports.Controls.Add(tpPerformance);
            tcReports.Dock = DockStyle.Fill;
            tcReports.Font = new Font("Segoe UI", 10F);
            tcReports.ItemSize = new Size(180, 40);
            tcReports.Location = new Point(0, 175);
            tcReports.Margin = new Padding(3, 4, 3, 4);
            tcReports.Name = "tcReports";
            tcReports.SelectedIndex = 0;
            tcReports.Size = new Size(1000, 700);
            tcReports.SizeMode = TabSizeMode.Fixed;
            tcReports.TabIndex = 2;
            // 
            // tpFleet
            // 
            tpFleet.Controls.Add(dgvReportData);
            tpFleet.Location = new Point(4, 44);
            tpFleet.Margin = new Padding(3, 4, 3, 4);
            tpFleet.Name = "tpFleet";
            tpFleet.Padding = new Padding(10, 12, 10, 12);
            tpFleet.Size = new Size(992, 652);
            tpFleet.TabIndex = 0;
            tpFleet.Text = "Fleet Utilization";
            tpFleet.UseVisualStyleBackColor = true;
            // 
            // dgvReportData
            // 
            dgvReportData.AllowUserToAddRows = false;
            dgvReportData.AllowUserToDeleteRows = false;
            dgvReportData.AllowUserToResizeRows = false;
            dgvReportData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReportData.BackgroundColor = Color.White;
            dgvReportData.BorderStyle = BorderStyle.None;
            dgvReportData.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvReportData.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(32, 191, 158);
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(32, 191, 158);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvReportData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvReportData.ColumnHeadersHeight = 40;
            dgvReportData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle4.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(236, 240, 241);
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvReportData.DefaultCellStyle = dataGridViewCellStyle4;
            dgvReportData.Dock = DockStyle.Fill;
            dgvReportData.EnableHeadersVisualStyles = false;
            dgvReportData.GridColor = Color.WhiteSmoke;
            dgvReportData.Location = new Point(10, 12);
            dgvReportData.Margin = new Padding(3, 4, 3, 4);
            dgvReportData.MultiSelect = false;
            dgvReportData.Name = "dgvReportData";
            dgvReportData.ReadOnly = true;
            dgvReportData.RowHeadersVisible = false;
            dgvReportData.RowHeadersWidth = 51;
            dgvReportData.RowTemplate.Height = 35;
            dgvReportData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReportData.Size = new Size(972, 628);
            dgvReportData.TabIndex = 0;
            // 
            // tpRevenue
            // 
            tpRevenue.Location = new Point(4, 44);
            tpRevenue.Margin = new Padding(3, 4, 3, 4);
            tpRevenue.Name = "tpRevenue";
            tpRevenue.Size = new Size(992, 652);
            tpRevenue.TabIndex = 1;
            tpRevenue.Text = "Revenue Analysis";
            tpRevenue.UseVisualStyleBackColor = true;
            // 
            // tpPerformance
            // 
            tpPerformance.Location = new Point(4, 44);
            tpPerformance.Margin = new Padding(3, 4, 3, 4);
            tpPerformance.Name = "tpPerformance";
            tpPerformance.Size = new Size(992, 652);
            tpPerformance.TabIndex = 2;
            tpPerformance.Text = "KPIs & Metrics";
            tpPerformance.UseVisualStyleBackColor = true;
            // 
            // pnlFilters
            // 
            pnlFilters.BackColor = Color.White;
            pnlFilters.Controls.Add(btnApplyFilter);
            pnlFilters.Controls.Add(dtpEnd);
            pnlFilters.Controls.Add(dtpStart);
            pnlFilters.Controls.Add(lblDateTo);
            pnlFilters.Controls.Add(lblDateFrom);
            pnlFilters.Dock = DockStyle.Top;
            pnlFilters.Location = new Point(0, 100);
            pnlFilters.Margin = new Padding(3, 4, 3, 4);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Size = new Size(1000, 75);
            pnlFilters.TabIndex = 1;
            // 
            // btnApplyFilter
            // 
            btnApplyFilter.BackColor = Color.FromArgb(52, 152, 219);
            btnApplyFilter.FlatAppearance.BorderSize = 0;
            btnApplyFilter.FlatStyle = FlatStyle.Flat;
            btnApplyFilter.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnApplyFilter.ForeColor = Color.White;
            btnApplyFilter.Location = new Point(460, 18);
            btnApplyFilter.Margin = new Padding(3, 4, 3, 4);
            btnApplyFilter.Name = "btnApplyFilter";
            btnApplyFilter.Size = new Size(120, 40);
            btnApplyFilter.TabIndex = 4;
            btnApplyFilter.Text = "Generate";
            btnApplyFilter.UseVisualStyleBackColor = false;
            // 
            // dtpEnd
            // 
            dtpEnd.Format = DateTimePickerFormat.Short;
            dtpEnd.Location = new Point(285, 22);
            dtpEnd.Margin = new Padding(3, 4, 3, 4);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(150, 27);
            dtpEnd.TabIndex = 3;
            // 
            // dtpStart
            // 
            dtpStart.Format = DateTimePickerFormat.Short;
            dtpStart.Location = new Point(75, 22);
            dtpStart.Margin = new Padding(3, 4, 3, 4);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(150, 27);
            dtpStart.TabIndex = 1;
            // 
            // lblDateTo
            // 
            lblDateTo.AutoSize = true;
            lblDateTo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblDateTo.Location = new Point(250, 25);
            lblDateTo.Name = "lblDateTo";
            lblDateTo.Size = new Size(29, 20);
            lblDateTo.TabIndex = 2;
            lblDateTo.Text = "To:";
            // 
            // lblDateFrom
            // 
            lblDateFrom.AutoSize = true;
            lblDateFrom.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblDateFrom.Location = new Point(25, 25);
            lblDateFrom.Name = "lblDateFrom";
            lblDateFrom.Size = new Size(49, 20);
            lblDateFrom.TabIndex = 0;
            lblDateFrom.Text = "From:";
            // 
            // ReportsView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(tcReports);
            Controls.Add(pnlFilters);
            Controls.Add(pnlHeader);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ReportsView";
            Size = new Size(1000, 875);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            tcReports.ResumeLayout(false);
            tpFleet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReportData).EndInit();
            pnlFilters.ResumeLayout(false);
            pnlFilters.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnExportPDF;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.TabControl tcReports;
        private System.Windows.Forms.TabPage tpFleet;
        private System.Windows.Forms.TabPage tpRevenue;
        private System.Windows.Forms.TabPage tpPerformance;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.DataGridView dgvReportData;
    }
}