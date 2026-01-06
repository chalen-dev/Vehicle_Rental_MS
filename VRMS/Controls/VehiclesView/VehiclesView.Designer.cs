namespace VRMS.Controls
{
    partial class VehiclesView
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
            label1 = new Label();
            pnlButtons = new Panel();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            picVehiclePreview = new PictureBox();
            lblVehicleDetails = new Label();
            dgvVehicles = new DataGridView();
            splitContainer1 = new SplitContainer();
            pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picVehiclePreview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVehicles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(44, 62, 80);
            label1.Location = new Point(14, 26);
            label1.Name = "label1";
            label1.Size = new Size(174, 54);
            label1.TabIndex = 0;
            label1.Text = "Vehicles";
            // 
            // pnlButtons
            // 
            pnlButtons.BackColor = Color.WhiteSmoke;
            pnlButtons.Controls.Add(btnDelete);
            pnlButtons.Controls.Add(label1);
            pnlButtons.Controls.Add(btnEdit);
            pnlButtons.Controls.Add(btnAdd);
            pnlButtons.Dock = DockStyle.Top;
            pnlButtons.Location = new Point(0, 0);
            pnlButtons.Margin = new Padding(3, 4, 3, 4);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(1000, 134);
            pnlButtons.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = SystemColors.ControlLightLight;
            btnDelete.Location = new Point(829, 44);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 56);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "🗑 Delete Vehicle";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.BackColor = Color.FromArgb(243, 156, 18);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEdit.ForeColor = SystemColors.ControlLightLight;
            btnEdit.Location = new Point(673, 44);
            btnEdit.Margin = new Padding(3, 4, 3, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(150, 56);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "✏ Edit Vehicle";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.BackColor = Color.FromArgb(41, 128, 185);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = SystemColors.ControlLightLight;
            btnAdd.Location = new Point(517, 44);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 56);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "+ Add Vehicle";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // picVehiclePreview
            // 
            picVehiclePreview.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            picVehiclePreview.BackColor = Color.White;
            picVehiclePreview.BorderStyle = BorderStyle.FixedSingle;
            picVehiclePreview.Location = new Point(20, 70);
            picVehiclePreview.Margin = new Padding(3, 4, 3, 4);
            picVehiclePreview.Name = "picVehiclePreview";
            picVehiclePreview.Size = new Size(262, 250);
            picVehiclePreview.SizeMode = PictureBoxSizeMode.Zoom;
            picVehiclePreview.TabIndex = 3;
            picVehiclePreview.TabStop = false;
            picVehiclePreview.Visible = false;
            // 
            // lblVehicleDetails
            // 
            lblVehicleDetails.BackColor = Color.WhiteSmoke;
            lblVehicleDetails.Dock = DockStyle.Top;
            lblVehicleDetails.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVehicleDetails.ForeColor = Color.DimGray;
            lblVehicleDetails.Location = new Point(10, 12);
            lblVehicleDetails.Name = "lblVehicleDetails";
            lblVehicleDetails.Padding = new Padding(0, 6, 0, 6);
            lblVehicleDetails.Size = new Size(281, 50);
            lblVehicleDetails.TabIndex = 4;
            lblVehicleDetails.Text = "Selected Vehicle Preview";
            lblVehicleDetails.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvVehicles
            // 
            dgvVehicles.AllowUserToAddRows = false;
            dgvVehicles.AllowUserToResizeRows = false;
            dgvVehicles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVehicles.BackgroundColor = Color.White;
            dgvVehicles.BorderStyle = BorderStyle.None;
            dgvVehicles.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvVehicles.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(26, 188, 156);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(26, 188, 156);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvVehicles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvVehicles.ColumnHeadersHeight = 40;
            dgvVehicles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(236, 240, 241);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvVehicles.DefaultCellStyle = dataGridViewCellStyle2;
            dgvVehicles.Dock = DockStyle.Fill;
            dgvVehicles.EnableHeadersVisualStyles = false;
            dgvVehicles.GridColor = Color.WhiteSmoke;
            dgvVehicles.Location = new Point(0, 0);
            dgvVehicles.Margin = new Padding(3, 4, 3, 4);
            dgvVehicles.MultiSelect = false;
            dgvVehicles.Name = "dgvVehicles";
            dgvVehicles.ReadOnly = true;
            dgvVehicles.RowHeadersVisible = false;
            dgvVehicles.RowHeadersWidth = 51;
            dgvVehicles.RowTemplate.Height = 35;
            dgvVehicles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehicles.Size = new Size(695, 741);
            dgvVehicles.TabIndex = 2;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 134);
            splitContainer1.Margin = new Padding(3, 4, 3, 4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvVehicles);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.White;
            splitContainer1.Panel2.Controls.Add(picVehiclePreview);
            splitContainer1.Panel2.Controls.Add(lblVehicleDetails);
            splitContainer1.Panel2.Padding = new Padding(10, 12, 10, 12);
            splitContainer1.Size = new Size(1000, 741);
            splitContainer1.SplitterDistance = 695;
            splitContainer1.TabIndex = 5;
            // 
            // VehiclesView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(splitContainer1);
            Controls.Add(pnlButtons);
            Margin = new Padding(3, 4, 3, 4);
            Name = "VehiclesView";
            Size = new Size(1000, 875);
            pnlButtons.ResumeLayout(false);
            pnlButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picVehiclePreview).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVehicles).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.PictureBox picVehiclePreview;
        private System.Windows.Forms.Label lblVehicleDetails;
        private System.Windows.Forms.DataGridView dgvVehicles;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}