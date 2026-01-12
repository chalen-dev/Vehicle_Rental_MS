namespace VRMS.UI.Forms.Rentals
{
    partial class NewRentalForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtOdometer = new TextBox();
            label4 = new Label();
            cbFuel = new ComboBox();
            label5 = new Label();
            txtNotes = new TextBox();
            lblTotal = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            label6 = new Label();
            dtPickup = new DateTimePicker();
            label7 = new Label();
            dtReturn = new DateTimePicker();
            pnlHeader = new Panel();
            lblHeaderTitle = new Label();
            btnSelectCustomer = new Button();
            lblSelectedCustomer = new Label();
            btnSelectVehicle = new Button();
            lblSelectedVehicle = new Label();
            btnClearCustomer = new Button();
            btnClearVehicle = new Button();
            panelCustomer = new Panel();
            panelVehicle = new Panel();
            pnlHeader.SuspendLayout();
            panelCustomer.SuspendLayout();
            panelVehicle.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(23, 87);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(96, 15);
            label1.TabIndex = 0;
            label1.Text = "Select Customer:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(23, 156);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 2;
            label2.Text = "Select Vehicle:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label3.ForeColor = Color.DimGray;
            label3.Location = new Point(23, 294);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(106, 15);
            label3.TabIndex = 4;
            label3.Text = "Current Odometer:";
            // 
            // txtOdometer
            // 
            txtOdometer.Font = new Font("Segoe UI", 10F);
            txtOdometer.Location = new Point(23, 317);
            txtOdometer.Margin = new Padding(4, 3, 4, 3);
            txtOdometer.Name = "txtOdometer";
            txtOdometer.ReadOnly = true;
            txtOdometer.Size = new Size(233, 25);
            txtOdometer.TabIndex = 5;
            txtOdometer.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label4.ForeColor = Color.DimGray;
            label4.Location = new Point(280, 294);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 6;
            label4.Text = "Fuel Level:";
            // 
            // cbFuel
            // 
            cbFuel.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFuel.Font = new Font("Segoe UI", 10F);
            cbFuel.FormattingEnabled = true;
            cbFuel.Items.AddRange(new object[] { "Empty", "1/4", "1/2", "3/4", "Full" });
            cbFuel.Location = new Point(280, 317);
            cbFuel.Margin = new Padding(4, 3, 4, 3);
            cbFuel.Name = "cbFuel";
            cbFuel.Size = new Size(256, 25);
            cbFuel.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label5.ForeColor = Color.DimGray;
            label5.Location = new Point(23, 363);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(98, 15);
            label5.TabIndex = 8;
            label5.Text = "Notes/Condition:";
            // 
            // txtNotes
            // 
            txtNotes.Font = new Font("Segoe UI", 10F);
            txtNotes.Location = new Point(23, 387);
            txtNotes.Margin = new Padding(4, 3, 4, 3);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(513, 92);
            txtNotes.TabIndex = 9;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(46, 204, 113);
            lblTotal.Location = new Point(23, 502);
            lblTotal.Margin = new Padding(4, 0, 4, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(157, 32);
            lblTotal.TabIndex = 10;
            lblTotal.Text = "Total: ₱0.00";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.Enabled = false;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(303, 623);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(233, 52);
            btnSave.TabIndex = 11;
            btnSave.Text = "Confirm Rental";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(189, 195, 199);
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(44, 62, 80);
            btnCancel.Location = new Point(140, 623);
            btnCancel.Margin = new Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(140, 52);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label6.ForeColor = Color.DimGray;
            label6.Location = new Point(23, 225);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(74, 15);
            label6.TabIndex = 13;
            label6.Text = "Pickup Date:";
            // 
            // dtPickup
            // 
            dtPickup.Font = new Font("Segoe UI", 10F);
            dtPickup.Format = DateTimePickerFormat.Short;
            dtPickup.Location = new Point(23, 248);
            dtPickup.Margin = new Padding(4, 3, 4, 3);
            dtPickup.Name = "dtPickup";
            dtPickup.Size = new Size(233, 25);
            dtPickup.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label7.ForeColor = Color.DimGray;
            label7.Location = new Point(280, 225);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(73, 15);
            label7.TabIndex = 15;
            label7.Text = "Return Date:";
            // 
            // dtReturn
            // 
            dtReturn.Font = new Font("Segoe UI", 10F);
            dtReturn.Format = DateTimePickerFormat.Short;
            dtReturn.Location = new Point(280, 248);
            dtReturn.Margin = new Padding(4, 3, 4, 3);
            dtReturn.Name = "dtReturn";
            dtReturn.Size = new Size(256, 25);
            dtReturn.TabIndex = 16;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(52, 73, 94);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(4, 3, 4, 3);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(565, 69);
            pnlHeader.TabIndex = 17;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(18, 17);
            lblHeaderTitle.Margin = new Padding(4, 0, 4, 0);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(209, 30);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "New Rental Record";
            // 
            // btnSelectCustomer
            // 
            btnSelectCustomer.BackColor = Color.FromArgb(52, 152, 219);
            btnSelectCustomer.FlatAppearance.BorderSize = 0;
            btnSelectCustomer.FlatStyle = FlatStyle.Flat;
            btnSelectCustomer.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnSelectCustomer.ForeColor = Color.White;
            btnSelectCustomer.Location = new Point(0, 0);
            btnSelectCustomer.Margin = new Padding(4, 3, 4, 3);
            btnSelectCustomer.Name = "btnSelectCustomer";
            btnSelectCustomer.Size = new Size(140, 32);
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
            lblSelectedCustomer.Location = new Point(146, 6);
            lblSelectedCustomer.Margin = new Padding(4, 0, 4, 0);
            lblSelectedCustomer.Name = "lblSelectedCustomer";
            lblSelectedCustomer.Size = new Size(98, 19);
            lblSelectedCustomer.TabIndex = 19;
            lblSelectedCustomer.Text = "Not selected...";
            lblSelectedCustomer.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnSelectVehicle
            // 
            btnSelectVehicle.BackColor = Color.FromArgb(52, 152, 219);
            btnSelectVehicle.FlatAppearance.BorderSize = 0;
            btnSelectVehicle.FlatStyle = FlatStyle.Flat;
            btnSelectVehicle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnSelectVehicle.ForeColor = Color.White;
            btnSelectVehicle.Location = new Point(0, 0);
            btnSelectVehicle.Margin = new Padding(4, 3, 4, 3);
            btnSelectVehicle.Name = "btnSelectVehicle";
            btnSelectVehicle.Size = new Size(140, 32);
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
            lblSelectedVehicle.Location = new Point(146, 6);
            lblSelectedVehicle.Margin = new Padding(4, 0, 4, 0);
            lblSelectedVehicle.Name = "lblSelectedVehicle";
            lblSelectedVehicle.Size = new Size(98, 19);
            lblSelectedVehicle.TabIndex = 21;
            lblSelectedVehicle.Text = "Not selected...";
            lblSelectedVehicle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnClearCustomer
            // 
            btnClearCustomer.BackColor = Color.FromArgb(231, 76, 60);
            btnClearCustomer.FlatAppearance.BorderSize = 0;
            btnClearCustomer.FlatStyle = FlatStyle.Flat;
            btnClearCustomer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClearCustomer.ForeColor = Color.White;
            btnClearCustomer.Location = new Point(380, 0);
            btnClearCustomer.Margin = new Padding(4, 3, 4, 3);
            btnClearCustomer.Name = "btnClearCustomer";
            btnClearCustomer.Size = new Size(133, 32);
            btnClearCustomer.TabIndex = 22;
            btnClearCustomer.Text = "Clear Selection";
            btnClearCustomer.UseVisualStyleBackColor = false;
            btnClearCustomer.Click += btnClearCustomer_Click;
            btnClearCustomer.Visible = false;
            // 
            // btnClearVehicle
            // 
            btnClearVehicle.BackColor = Color.FromArgb(231, 76, 60);
            btnClearVehicle.FlatAppearance.BorderSize = 0;
            btnClearVehicle.FlatStyle = FlatStyle.Flat;
            btnClearVehicle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClearVehicle.ForeColor = Color.White;
            btnClearVehicle.Location = new Point(380, 0);
            btnClearVehicle.Margin = new Padding(4, 3, 4, 3);
            btnClearVehicle.Name = "btnClearVehicle";
            btnClearVehicle.Size = new Size(133, 32);
            btnClearVehicle.TabIndex = 23;
            btnClearVehicle.Text = "Clear Selection";
            btnClearVehicle.UseVisualStyleBackColor = false;
            btnClearVehicle.Click += btnClearVehicle_Click;
            btnClearVehicle.Visible = false;
            // 
            // panelCustomer
            // 
            panelCustomer.BackColor = Color.White;
            panelCustomer.BorderStyle = BorderStyle.FixedSingle;
            panelCustomer.Controls.Add(btnSelectCustomer);
            panelCustomer.Controls.Add(lblSelectedCustomer);
            panelCustomer.Controls.Add(btnClearCustomer);
            panelCustomer.Location = new Point(23, 108);
            panelCustomer.Margin = new Padding(4, 3, 4, 3);
            panelCustomer.Name = "panelCustomer";
            panelCustomer.Size = new Size(513, 32);
            panelCustomer.TabIndex = 24;
            // 
            // panelVehicle
            // 
            panelVehicle.BackColor = Color.White;
            panelVehicle.BorderStyle = BorderStyle.FixedSingle;
            panelVehicle.Controls.Add(btnSelectVehicle);
            panelVehicle.Controls.Add(lblSelectedVehicle);
            panelVehicle.Controls.Add(btnClearVehicle);
            panelVehicle.Location = new Point(23, 177);
            panelVehicle.Margin = new Padding(4, 3, 4, 3);
            panelVehicle.Name = "panelVehicle";
            panelVehicle.Size = new Size(513, 32);
            panelVehicle.TabIndex = 25;
            // 
            // NewRentalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(565, 705);
            Controls.Add(panelVehicle);
            Controls.Add(panelCustomer);
            Controls.Add(pnlHeader);
            Controls.Add(dtReturn);
            Controls.Add(label7);
            Controls.Add(dtPickup);
            Controls.Add(label6);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(lblTotal);
            Controls.Add(txtNotes);
            Controls.Add(label5);
            Controls.Add(cbFuel);
            Controls.Add(label4);
            Controls.Add(txtOdometer);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NewRentalForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Rental Processing";
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

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOdometer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbFuel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtPickup;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtReturn;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Button btnSelectCustomer;
        private System.Windows.Forms.Label lblSelectedCustomer;
        private System.Windows.Forms.Button btnSelectVehicle;
        private System.Windows.Forms.Label lblSelectedVehicle;
        private System.Windows.Forms.Button btnClearCustomer;
        private System.Windows.Forms.Button btnClearVehicle;
        private System.Windows.Forms.Panel panelCustomer;
        private System.Windows.Forms.Panel panelVehicle;
    }
}