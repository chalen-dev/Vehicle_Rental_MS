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
            pnlCards = new FlowLayoutPanel();
            pnlCardTotal = new Panel();
            label1 = new Label();
            lblTotalValue = new Label();
            pnlCardAvailable = new Panel();
            labeltitle = new Label();
            lblAvailableValue = new Label();
            pnlCardRented = new Panel();
            label2 = new Label();
            lblRentedValue = new Label();
            pnlCardRevenue = new Panel();
            label5 = new Label();
            lblRevenueValue = new Label();
            pnlCardOverdue = new Panel();
            label7 = new Label();
            lblOverdueValue = new Label();
            bottomSplit = new TableLayoutPanel();
            chartContainer = new Panel();
            chartLayout = new TableLayoutPanel();
            gridContainer = new Panel();
            dgvOverdue = new DataGridView();
            lblGridTitle = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            pnlCards.SuspendLayout();
            pnlCardTotal.SuspendLayout();
            pnlCardAvailable.SuspendLayout();
            pnlCardRented.SuspendLayout();
            pnlCardRevenue.SuspendLayout();
            pnlCardOverdue.SuspendLayout();
            bottomSplit.SuspendLayout();
            chartContainer.SuspendLayout();
            gridContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOverdue).BeginInit();
            SuspendLayout();
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
            pnlCards.Location = new Point(11, 11);
            pnlCards.Margin = new Padding(4);
            pnlCards.Name = "pnlCards";
            pnlCards.Padding = new Padding(4, 5, 4, 5);
            pnlCards.Size = new Size(910, 161);
            pnlCards.TabIndex = 0;
            // 
            // pnlCardTotal
            // 
            pnlCardTotal.BackColor = Color.FromArgb(52, 73, 94);
            pnlCardTotal.Controls.Add(label1);
            pnlCardTotal.Controls.Add(lblTotalValue);
            pnlCardTotal.ForeColor = Color.White;
            pnlCardTotal.Location = new Point(13, 14);
            pnlCardTotal.Margin = new Padding(9);
            pnlCardTotal.Name = "pnlCardTotal";
            pnlCardTotal.Size = new Size(153, 122);
            pnlCardTotal.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label1.ForeColor = Color.Gainsboro;
            label1.Location = new Point(13, 14);
            label1.Name = "label1";
            label1.Size = new Size(74, 19);
            label1.TabIndex = 1;
            label1.Text = "Total Fleet";
            // 
            // lblTotalValue
            // 
            lblTotalValue.AutoSize = true;
            lblTotalValue.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblTotalValue.Location = new Point(10, 42);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(44, 51);
            lblTotalValue.TabIndex = 0;
            lblTotalValue.Text = "0";
            lblTotalValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlCardAvailable
            // 
            pnlCardAvailable.BackColor = Color.FromArgb(39, 174, 96);
            pnlCardAvailable.Controls.Add(labeltitle);
            pnlCardAvailable.Controls.Add(lblAvailableValue);
            pnlCardAvailable.ForeColor = Color.White;
            pnlCardAvailable.Location = new Point(184, 14);
            pnlCardAvailable.Margin = new Padding(9);
            pnlCardAvailable.Name = "pnlCardAvailable";
            pnlCardAvailable.Size = new Size(153, 122);
            pnlCardAvailable.TabIndex = 1;
            // 
            // labeltitle
            // 
            labeltitle.AutoSize = true;
            labeltitle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            labeltitle.ForeColor = Color.Gainsboro;
            labeltitle.Location = new Point(13, 14);
            labeltitle.Name = "labeltitle";
            labeltitle.Size = new Size(115, 19);
            labeltitle.TabIndex = 1;
            labeltitle.Text = "Vehicle Available";
            // 
            // lblAvailableValue
            // 
            lblAvailableValue.AutoSize = true;
            lblAvailableValue.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblAvailableValue.Location = new Point(10, 42);
            lblAvailableValue.Name = "lblAvailableValue";
            lblAvailableValue.Size = new Size(44, 51);
            lblAvailableValue.TabIndex = 0;
            lblAvailableValue.Text = "0";
            lblAvailableValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlCardRented
            // 
            pnlCardRented.BackColor = Color.FromArgb(41, 128, 185);
            pnlCardRented.Controls.Add(label2);
            pnlCardRented.Controls.Add(lblRentedValue);
            pnlCardRented.ForeColor = Color.White;
            pnlCardRented.Location = new Point(355, 14);
            pnlCardRented.Margin = new Padding(9);
            pnlCardRented.Name = "pnlCardRented";
            pnlCardRented.Size = new Size(153, 122);
            pnlCardRented.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label2.ForeColor = Color.Gainsboro;
            label2.Location = new Point(13, 14);
            label2.Name = "label2";
            label2.Size = new Size(87, 19);
            label2.TabIndex = 1;
            label2.Text = "Active Rents";
            // 
            // lblRentedValue
            // 
            lblRentedValue.AutoSize = true;
            lblRentedValue.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblRentedValue.Location = new Point(10, 42);
            lblRentedValue.Name = "lblRentedValue";
            lblRentedValue.Size = new Size(44, 51);
            lblRentedValue.TabIndex = 0;
            lblRentedValue.Text = "0";
            lblRentedValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlCardRevenue
            // 
            pnlCardRevenue.BackColor = Color.FromArgb(142, 68, 173);
            pnlCardRevenue.Controls.Add(label5);
            pnlCardRevenue.Controls.Add(lblRevenueValue);
            pnlCardRevenue.ForeColor = Color.White;
            pnlCardRevenue.Location = new Point(526, 14);
            pnlCardRevenue.Margin = new Padding(9);
            pnlCardRevenue.Name = "pnlCardRevenue";
            pnlCardRevenue.Size = new Size(166, 122);
            pnlCardRevenue.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label5.ForeColor = Color.Gainsboro;
            label5.Location = new Point(13, 14);
            label5.Name = "label5";
            label5.Size = new Size(118, 19);
            label5.TabIndex = 1;
            label5.Text = "Revenue (Month)";
            // 
            // lblRevenueValue
            // 
            lblRevenueValue.AutoSize = true;
            lblRevenueValue.Cursor = Cursors.Hand;
            lblRevenueValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblRevenueValue.Location = new Point(10, 56);
            lblRevenueValue.Name = "lblRevenueValue";
            lblRevenueValue.Size = new Size(43, 32);
            lblRevenueValue.TabIndex = 0;
            lblRevenueValue.Text = "₱0";
            lblRevenueValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlCardOverdue
            // 
            pnlCardOverdue.BackColor = Color.FromArgb(192, 57, 43);
            pnlCardOverdue.Controls.Add(label7);
            pnlCardOverdue.Controls.Add(lblOverdueValue);
            pnlCardOverdue.ForeColor = Color.White;
            pnlCardOverdue.Location = new Point(710, 14);
            pnlCardOverdue.Margin = new Padding(9);
            pnlCardOverdue.Name = "pnlCardOverdue";
            pnlCardOverdue.Size = new Size(153, 122);
            pnlCardOverdue.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label7.ForeColor = Color.Gainsboro;
            label7.Location = new Point(13, 14);
            label7.Name = "label7";
            label7.Size = new Size(62, 19);
            label7.TabIndex = 1;
            label7.Text = "Overdue";
            // 
            // lblOverdueValue
            // 
            lblOverdueValue.AutoSize = true;
            lblOverdueValue.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblOverdueValue.Location = new Point(10, 42);
            lblOverdueValue.Name = "lblOverdueValue";
            lblOverdueValue.Size = new Size(68, 51);
            lblOverdueValue.TabIndex = 0;
            lblOverdueValue.Text = "₱0";
            lblOverdueValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // bottomSplit
            // 
            bottomSplit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            bottomSplit.BackColor = Color.Transparent;
            bottomSplit.ColumnCount = 2;
            bottomSplit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            bottomSplit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            bottomSplit.Controls.Add(chartContainer, 0, 0);
            bottomSplit.Controls.Add(gridContainer, 1, 0);
            bottomSplit.Location = new Point(11, 185);
            bottomSplit.Margin = new Padding(4);
            bottomSplit.Name = "bottomSplit";
            bottomSplit.Padding = new Padding(11);
            bottomSplit.RowCount = 1;
            bottomSplit.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            bottomSplit.Size = new Size(910, 485);
            bottomSplit.TabIndex = 1;
            // 
            // chartContainer
            // 
            chartContainer.BackColor = Color.White;
            chartContainer.Controls.Add(chartLayout);
            chartContainer.Dock = DockStyle.Fill;
            chartContainer.Location = new Point(15, 15);
            chartContainer.Margin = new Padding(4);
            chartContainer.Name = "chartContainer";
            chartContainer.Padding = new Padding(1);
            chartContainer.Size = new Size(436, 455);
            chartContainer.TabIndex = 0;
            // 
            // chartLayout
            // 
            chartLayout.ColumnCount = 1;
            chartLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            chartLayout.Dock = DockStyle.Fill;
            chartLayout.Location = new Point(1, 1);
            chartLayout.Margin = new Padding(4);
            chartLayout.Name = "chartLayout";
            chartLayout.Padding = new Padding(9, 0, 9, 0);
            chartLayout.RowCount = 3;
            chartLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            chartLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            chartLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            chartLayout.Size = new Size(434, 453);
            chartLayout.TabIndex = 0;
            // 
            // gridContainer
            // 
            gridContainer.BackColor = Color.White;
            gridContainer.Controls.Add(dgvOverdue);
            gridContainer.Controls.Add(lblGridTitle);
            gridContainer.Dock = DockStyle.Fill;
            gridContainer.Location = new Point(459, 15);
            gridContainer.Margin = new Padding(4);
            gridContainer.Name = "gridContainer";
            gridContainer.Padding = new Padding(18, 19, 18, 19);
            gridContainer.Size = new Size(436, 455);
            gridContainer.TabIndex = 1;
            // 
            // dgvOverdue
            // 
            dgvOverdue.AllowUserToAddRows = false;
            dgvOverdue.AllowUserToResizeRows = false;
            dgvOverdue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOverdue.BackgroundColor = Color.White;
            dgvOverdue.BorderStyle = BorderStyle.None;
            dgvOverdue.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvOverdue.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(26, 188, 156);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvOverdue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvOverdue.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(236, 240, 241);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvOverdue.DefaultCellStyle = dataGridViewCellStyle2;
            dgvOverdue.Dock = DockStyle.Fill;
            dgvOverdue.EnableHeadersVisualStyles = false;
            dgvOverdue.GridColor = Color.WhiteSmoke;
            dgvOverdue.Location = new Point(18, 47);
            dgvOverdue.Margin = new Padding(4);
            dgvOverdue.Name = "dgvOverdue";
            dgvOverdue.ReadOnly = true;
            dgvOverdue.RowHeadersVisible = false;
            dgvOverdue.RowHeadersWidth = 51;
            dgvOverdue.RowTemplate.Height = 35;
            dgvOverdue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOverdue.Size = new Size(400, 389);
            dgvOverdue.TabIndex = 1;
            // 
            // lblGridTitle
            // 
            lblGridTitle.AutoSize = true;
            lblGridTitle.Dock = DockStyle.Top;
            lblGridTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGridTitle.ForeColor = Color.FromArgb(192, 57, 43);
            lblGridTitle.Location = new Point(18, 19);
            lblGridTitle.Margin = new Padding(4, 0, 4, 9);
            lblGridTitle.Name = "lblGridTitle";
            lblGridTitle.Padding = new Padding(0, 0, 0, 7);
            lblGridTitle.Size = new Size(164, 28);
            lblGridTitle.TabIndex = 0;
            lblGridTitle.Text = "⚠️ Overdue Returns";
            // 
            // DashboardView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(240, 243, 244);
            Controls.Add(bottomSplit);
            Controls.Add(pnlCards);
            Margin = new Padding(4);
            MinimumSize = new Size(934, 692);
            Name = "DashboardView";
            Size = new Size(934, 692);
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
            bottomSplit.ResumeLayout(false);
            chartContainer.ResumeLayout(false);
            gridContainer.ResumeLayout(false);
            gridContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOverdue).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlCards;
        private System.Windows.Forms.TableLayoutPanel bottomSplit;
        private System.Windows.Forms.Panel chartContainer;
        private System.Windows.Forms.TableLayoutPanel chartLayout;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenue;
        private System.Windows.Forms.Panel gridContainer;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblGridTitle;
        private System.Windows.Forms.DataGridView dgvOverdue;
        private System.Windows.Forms.Panel pnlCardTotal;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlCardAvailable;
        private System.Windows.Forms.Label labeltitle;
        private System.Windows.Forms.Label lblAvailableValue;
        private System.Windows.Forms.Panel pnlCardRented;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRentedValue;
        private System.Windows.Forms.Panel pnlCardRevenue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblRevenueValue;
        private System.Windows.Forms.Panel pnlCardOverdue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblOverdueValue;
    }
}