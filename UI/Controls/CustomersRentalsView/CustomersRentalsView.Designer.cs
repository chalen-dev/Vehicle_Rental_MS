namespace VRMS.Controls
{
    partial class CustomersRentalsView
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
            lblTitle = new Label();
            btnRefresh = new Button();
            dgvRentals = new DataGridView();
            splitContainer1 = new SplitContainer();
            pbVehicle = new PictureBox();
            lblDetailVehicle = new Label();
            lblDetailDates = new Label();
            lblDetailAmount = new Label();
            btnProceedRent = new Button();
            btnViewDetails = new Button();
            txtSearch = new TextBox();
            cbStatusFilter = new ComboBox();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvRentals).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbVehicle).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitle.Location = new Point(16, 20);
            lblTitle.Margin = new Padding(5, 0, 5, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(200, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "My Rentals";
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(46, 204, 113);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(25, 85);
            btnRefresh.Margin = new Padding(5);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(185, 51);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "🔄 Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // dgvRentals
            // 
            dgvRentals.AllowUserToAddRows = false;
            dgvRentals.AllowUserToResizeRows = false;
            dgvRentals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRentals.BackgroundColor = Color.White;
            dgvRentals.BorderStyle = BorderStyle.None;
            dgvRentals.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRentals.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(26, 188, 156);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(26, 188, 156);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvRentals.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvRentals.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(236, 240, 241);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvRentals.DefaultCellStyle = dataGridViewCellStyle2;
            dgvRentals.Dock = DockStyle.Fill;
            dgvRentals.EnableHeadersVisualStyles = false;
            dgvRentals.GridColor = Color.WhiteSmoke;
            dgvRentals.Location = new Point(0, 0);
            dgvRentals.Margin = new Padding(5);
            dgvRentals.MultiSelect = false;
            dgvRentals.Name = "dgvRentals";
            dgvRentals.ReadOnly = true;
            dgvRentals.RowHeadersVisible = false;
            dgvRentals.RowHeadersWidth = 51;
            dgvRentals.RowTemplate.Height = 35;
            dgvRentals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRentals.Size = new Size(914, 749);
            dgvRentals.TabIndex = 3;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 144);
            splitContainer1.Margin = new Padding(5);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvRentals);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.White;
            splitContainer1.Panel2.Controls.Add(lblDetailAmount);
            splitContainer1.Panel2.Controls.Add(lblDetailDates);
            splitContainer1.Panel2.Controls.Add(lblDetailVehicle);
            splitContainer1.Panel2.Controls.Add(pbVehicle);
            splitContainer1.Panel2.Controls.Add(btnProceedRent);
            splitContainer1.Panel2.Padding = new Padding(16, 19, 16, 19);
            splitContainer1.Size = new Size(1371, 749);
            splitContainer1.SplitterDistance = 914;
            splitContainer1.SplitterWidth = 17;
            splitContainer1.TabIndex = 4;
            // 
            // pbVehicle
            // 
            pbVehicle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pbVehicle.BackColor = Color.WhiteSmoke;
            pbVehicle.BorderStyle = BorderStyle.FixedSingle;
            pbVehicle.Location = new Point(18, 21);
            pbVehicle.Margin = new Padding(5);
            pbVehicle.Name = "pbVehicle";
            pbVehicle.Size = new Size(395, 287);
            pbVehicle.SizeMode = PictureBoxSizeMode.Zoom;
            pbVehicle.TabIndex = 0;
            pbVehicle.TabStop = false;
            // 
            // lblDetailVehicle
            // 
            lblDetailVehicle.AutoSize = true;
            lblDetailVehicle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblDetailVehicle.ForeColor = Color.FromArgb(41, 128, 185);
            lblDetailVehicle.Location = new Point(24, 325);
            lblDetailVehicle.Margin = new Padding(5, 0, 5, 0);
            lblDetailVehicle.Name = "lblDetailVehicle";
            lblDetailVehicle.Size = new Size(168, 32);
            lblDetailVehicle.TabIndex = 1;
            lblDetailVehicle.Text = "Vehicle Name";
            // 
            // lblDetailDates
            // 
            lblDetailDates.AutoSize = true;
            lblDetailDates.Font = new Font("Segoe UI", 10F);
            lblDetailDates.ForeColor = Color.DimGray;
            lblDetailDates.Location = new Point(27, 375);
            lblDetailDates.Margin = new Padding(5, 0, 5, 0);
            lblDetailDates.Name = "lblDetailDates";
            lblDetailDates.Size = new Size(156, 23);
            lblDetailDates.TabIndex = 3;
            lblDetailDates.Text = "Period: Select entry";
            // 
            // lblDetailAmount
            // 
            lblDetailAmount.AutoSize = true;
            lblDetailAmount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDetailAmount.ForeColor = Color.FromArgb(46, 204, 113);
            lblDetailAmount.Location = new Point(27, 425);
            lblDetailAmount.Margin = new Padding(5, 0, 5, 0);
            lblDetailAmount.Name = "lblDetailAmount";
            lblDetailAmount.Size = new Size(109, 25);
            lblDetailAmount.TabIndex = 4;
            lblDetailAmount.Text = "Total: ₱ 0.0";
            // 
            // btnProceedRent
            // 
            btnProceedRent.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnProceedRent.BackColor = Color.FromArgb(155, 89, 182);
            btnProceedRent.FlatAppearance.BorderSize = 0;
            btnProceedRent.FlatStyle = FlatStyle.Flat;
            btnProceedRent.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnProceedRent.ForeColor = Color.White;
            btnProceedRent.Location = new Point(18, 680);
            btnProceedRent.Margin = new Padding(5);
            btnProceedRent.Name = "btnProceedRent";
            btnProceedRent.Size = new Size(395, 48);
            btnProceedRent.TabIndex = 5;
            btnProceedRent.Text = "🚗 Proceed Rent";
            btnProceedRent.UseVisualStyleBackColor = false;
            // 
            // btnViewDetails
            // 
            btnViewDetails.BackColor = Color.FromArgb(52, 152, 219);
            btnViewDetails.FlatAppearance.BorderSize = 0;
            btnViewDetails.FlatStyle = FlatStyle.Flat;
            btnViewDetails.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnViewDetails.ForeColor = Color.White;
            btnViewDetails.Location = new Point(216, 85);
            btnViewDetails.Margin = new Padding(5);
            btnViewDetails.Name = "btnViewDetails";
            btnViewDetails.Size = new Size(185, 51);
            btnViewDetails.TabIndex = 2;
            btnViewDetails.Text = "🔍 View Details";
            btnViewDetails.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(1097, 48);
            txtSearch.Margin = new Padding(5);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search vehicle name or plate...";
            txtSearch.Size = new Size(251, 30);
            txtSearch.TabIndex = 4;
            // 
            // cbStatusFilter
            // 
            cbStatusFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatusFilter.Font = new Font("Segoe UI", 10F);
            cbStatusFilter.FormattingEnabled = true;
            cbStatusFilter.Location = new Point(1097, 93);
            cbStatusFilter.Margin = new Padding(5);
            cbStatusFilter.Name = "cbStatusFilter";
            cbStatusFilter.Size = new Size(251, 31);
            cbStatusFilter.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(btnViewDetails);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(cbStatusFilter);
            panel1.Controls.Add(lblTitle);
            panel1.Controls.Add(btnRefresh);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1371, 144);
            panel1.TabIndex = 5;
            // 
            // CustomersRentalsView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(splitContainer1);
            Controls.Add(panel1);
            Margin = new Padding(5);
            Name = "CustomersRentalsView";
            Size = new Size(1371, 893);
            ((System.ComponentModel.ISupportInitialize)dgvRentals).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbVehicle).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Button btnRefresh;
        private DataGridView dgvRentals;
        private SplitContainer splitContainer1;
        private PictureBox pbVehicle;
        private Label lblDetailVehicle;
        private Label lblDetailDates;
        private Label lblDetailAmount;
        private Button btnProceedRent;
        private Panel panel1;
        private Button btnViewDetails;
        private TextBox txtSearch;
        private ComboBox cbStatusFilter;
    }
}