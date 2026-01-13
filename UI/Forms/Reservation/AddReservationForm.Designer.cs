namespace VRMS.UI.Forms.Reservation
{
    partial class AddReservationForm
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
            dtpStart = new DateTimePicker();
            dtpEnd = new DateTimePicker();
            lblTotal = new Label();
            txtNotes = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            pnlHeader = new Panel();
            lblHeaderTitle = new Label();
            panelCustomer = new Panel();
            btnSelectCustomer = new Button();
            lblSelectedCustomer = new Label();
            btnClearCustomer = new Button();
            panelVehicle = new Panel();
            btnSelectVehicle = new Button();
            lblSelectedVehicle = new Label();
            btnClearVehicle = new Button();
            pnlHeader.SuspendLayout();
            panelCustomer.SuspendLayout();
            panelVehicle.SuspendLayout();
            SuspendLayout();
            // 
            // dtpStart
            // 
            dtpStart.Font = new Font("Segoe UI", 10F);
            dtpStart.Format = DateTimePickerFormat.Short;
            dtpStart.Location = new Point(23, 293);
            dtpStart.Margin = new Padding(3, 4, 3, 4);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(269, 30);
            dtpStart.TabIndex = 6;
            // 
            // dtpEnd
            // 
            dtpEnd.Font = new Font("Segoe UI", 10F);
            dtpEnd.Format = DateTimePickerFormat.Short;
            dtpEnd.Location = new Point(341, 293);
            dtpEnd.Margin = new Padding(3, 4, 3, 4);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(268, 30);
            dtpEnd.TabIndex = 8;
            // 
            // lblTotal
            // 
            lblTotal.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(46, 204, 113);
            lblTotal.Location = new Point(23, 507);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(469, 53);
            lblTotal.TabIndex = 11;
            lblTotal.Text = "Total: ₱0.00";
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtNotes
            // 
            txtNotes.Font = new Font("Segoe UI", 10F);
            txtNotes.Location = new Point(23, 373);
            txtNotes.Margin = new Padding(3, 4, 3, 4);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(586, 105);
            txtNotes.TabIndex = 10;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(392, 586);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(217, 60);
            btnSave.TabIndex = 12;
            btnSave.Text = "Save Reservation";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(189, 195, 199);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(44, 62, 80);
            btnCancel.Location = new Point(230, 586);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(137, 60);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(23, 100);
            label1.Name = "label1";
            label1.Size = new Size(123, 20);
            label1.TabIndex = 1;
            label1.Text = "Select Customer:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(23, 180);
            label2.Name = "label2";
            label2.Size = new Size(106, 20);
            label2.TabIndex = 3;
            label2.Text = "Select Vehicle:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label3.ForeColor = Color.DimGray;
            label3.Location = new Point(23, 267);
            label3.Name = "label3";
            label3.Size = new Size(95, 20);
            label3.TabIndex = 5;
            label3.Text = "Pickup Date:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label4.ForeColor = Color.DimGray;
            label4.Location = new Point(341, 267);
            label4.Name = "label4";
            label4.Size = new Size(75, 20);
            label4.TabIndex = 7;
            label4.Text = "End Date:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label5.ForeColor = Color.DimGray;
            label5.Location = new Point(23, 347);
            label5.Name = "label5";
            label5.Size = new Size(53, 20);
            label5.TabIndex = 9;
            label5.Text = "Notes:";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(52, 73, 94);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(632, 80);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(17, 20);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(235, 37);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "New Reservation";
            // 
            // panelCustomer
            // 
            panelCustomer.BackColor = Color.White;
            panelCustomer.BorderStyle = BorderStyle.FixedSingle;
            panelCustomer.Controls.Add(btnSelectCustomer);
            panelCustomer.Controls.Add(lblSelectedCustomer);
            panelCustomer.Controls.Add(btnClearCustomer);
            panelCustomer.Location = new Point(23, 124);
            panelCustomer.Margin = new Padding(5, 4, 5, 4);
            panelCustomer.Name = "panelCustomer";
            panelCustomer.Size = new Size(586, 42);
            panelCustomer.TabIndex = 25;
            // 
            // btnSelectCustomer
            // 
            btnSelectCustomer.BackColor = Color.FromArgb(52, 152, 219);
            btnSelectCustomer.FlatAppearance.BorderSize = 0;
            btnSelectCustomer.FlatStyle = FlatStyle.Flat;
            btnSelectCustomer.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnSelectCustomer.ForeColor = Color.White;
            btnSelectCustomer.Location = new Point(0, 0);
            btnSelectCustomer.Margin = new Padding(5, 4, 5, 4);
            btnSelectCustomer.Name = "btnSelectCustomer";
            btnSelectCustomer.Size = new Size(160, 43);
            btnSelectCustomer.TabIndex = 18;
            btnSelectCustomer.Text = "Select Customer";
            btnSelectCustomer.UseVisualStyleBackColor = false;
            btnSelectCustomer.Click += btnSelectCustomer_Click;
            // 
            // lblSelectedCustomer
            // 
            lblSelectedCustomer.AutoSize = true;
            lblSelectedCustomer.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSelectedCustomer.ForeColor = Color.FromArgb(44, 62, 80);
            lblSelectedCustomer.Location = new Point(167, 8);
            lblSelectedCustomer.Margin = new Padding(5, 0, 5, 0);
            lblSelectedCustomer.Name = "lblSelectedCustomer";
            lblSelectedCustomer.Size = new Size(118, 23);
            lblSelectedCustomer.TabIndex = 19;
            lblSelectedCustomer.Text = "Not selected...";
            lblSelectedCustomer.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnClearCustomer
            // 
            btnClearCustomer.BackColor = Color.FromArgb(231, 76, 60);
            btnClearCustomer.FlatAppearance.BorderSize = 0;
            btnClearCustomer.FlatStyle = FlatStyle.Flat;
            btnClearCustomer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClearCustomer.ForeColor = Color.White;
            btnClearCustomer.Location = new Point(434, 0);
            btnClearCustomer.Margin = new Padding(5, 4, 5, 4);
            btnClearCustomer.Name = "btnClearCustomer";
            btnClearCustomer.Size = new Size(152, 43);
            btnClearCustomer.TabIndex = 22;
            btnClearCustomer.Text = "Clear Selection";
            btnClearCustomer.UseVisualStyleBackColor = false;
            btnClearCustomer.Visible = false;
            btnClearCustomer.Click += btnClearCustomer_Click;
            // 
            // panelVehicle
            // 
            panelVehicle.BackColor = Color.White;
            panelVehicle.BorderStyle = BorderStyle.FixedSingle;
            panelVehicle.Controls.Add(btnSelectVehicle);
            panelVehicle.Controls.Add(lblSelectedVehicle);
            panelVehicle.Controls.Add(btnClearVehicle);
            panelVehicle.Location = new Point(23, 204);
            panelVehicle.Margin = new Padding(5, 4, 5, 4);
            panelVehicle.Name = "panelVehicle";
            panelVehicle.Size = new Size(586, 42);
            panelVehicle.TabIndex = 26;
            // 
            // btnSelectVehicle
            // 
            btnSelectVehicle.BackColor = Color.FromArgb(52, 152, 219);
            btnSelectVehicle.FlatAppearance.BorderSize = 0;
            btnSelectVehicle.FlatStyle = FlatStyle.Flat;
            btnSelectVehicle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnSelectVehicle.ForeColor = Color.White;
            btnSelectVehicle.Location = new Point(0, 0);
            btnSelectVehicle.Margin = new Padding(5, 4, 5, 4);
            btnSelectVehicle.Name = "btnSelectVehicle";
            btnSelectVehicle.Size = new Size(160, 43);
            btnSelectVehicle.TabIndex = 20;
            btnSelectVehicle.Text = "Select Vehicle";
            btnSelectVehicle.UseVisualStyleBackColor = false;
            btnSelectVehicle.Click += btnSelectVehicle_Click;
            // 
            // lblSelectedVehicle
            // 
            lblSelectedVehicle.AutoSize = true;
            lblSelectedVehicle.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSelectedVehicle.ForeColor = Color.FromArgb(44, 62, 80);
            lblSelectedVehicle.Location = new Point(167, 8);
            lblSelectedVehicle.Margin = new Padding(5, 0, 5, 0);
            lblSelectedVehicle.Name = "lblSelectedVehicle";
            lblSelectedVehicle.Size = new Size(118, 23);
            lblSelectedVehicle.TabIndex = 21;
            lblSelectedVehicle.Text = "Not selected...";
            lblSelectedVehicle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnClearVehicle
            // 
            btnClearVehicle.BackColor = Color.FromArgb(231, 76, 60);
            btnClearVehicle.FlatAppearance.BorderSize = 0;
            btnClearVehicle.FlatStyle = FlatStyle.Flat;
            btnClearVehicle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClearVehicle.ForeColor = Color.White;
            btnClearVehicle.Location = new Point(434, 0);
            btnClearVehicle.Margin = new Padding(5, 4, 5, 4);
            btnClearVehicle.Name = "btnClearVehicle";
            btnClearVehicle.Size = new Size(152, 43);
            btnClearVehicle.TabIndex = 23;
            btnClearVehicle.Text = "Clear Selection";
            btnClearVehicle.UseVisualStyleBackColor = false;
            btnClearVehicle.Visible = false;
            btnClearVehicle.Click += btnClearVehicle_Click;
            // 
            // AddReservationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(632, 693);
            Controls.Add(panelVehicle);
            Controls.Add(panelCustomer);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(lblTotal);
            Controls.Add(txtNotes);
            Controls.Add(label5);
            Controls.Add(dtpEnd);
            Controls.Add(label4);
            Controls.Add(dtpStart);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddReservationForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Reservation Management";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            panelCustomer.ResumeLayout(false);
            panelCustomer.PerformLayout();
            panelVehicle.ResumeLayout(false);
            panelVehicle.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private Panel panelCustomer;
        private Button btnSelectCustomer;
        private Label lblSelectedCustomer;
        private Button btnClearCustomer;
        private Panel panelVehicle;
        private Button btnSelectVehicle;
        private Label lblSelectedVehicle;
        private Button btnClearVehicle;
    }
}