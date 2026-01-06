namespace VRMS.Forms
{
    partial class ReturnVehicleForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCustomerInfo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtReturns = new System.Windows.Forms.DateTimePicker();
            this.txtOdometers = new System.Windows.Forms.TextBox();
            this.cbFuels = new System.Windows.Forms.ComboBox();
            this.txtConditions = new System.Windows.Forms.TextBox();
            this.lblVehicleInfo = new System.Windows.Forms.Label();
            this.btnConfirms = new System.Windows.Forms.Button();
            this.btnCancels = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numLateFee = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numDamages = new System.Windows.Forms.NumericUpDown();
            this.dgvDamages = new System.Windows.Forms.DataGridView();
            this.btnAddDamage = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLateFee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDamages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDamages)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vehicle Return";
            // 
            // lblVehicleInfo
            // 
            this.lblVehicleInfo.AutoSize = true;
            this.lblVehicleInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblVehicleInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblVehicleInfo.Location = new System.Drawing.Point(23, 75);
            this.lblVehicleInfo.Name = "lblVehicleInfo";
            this.lblVehicleInfo.Size = new System.Drawing.Size(73, 23);
            this.lblVehicleInfo.TabIndex = 10;
            this.lblVehicleInfo.Text = "Vehicle: ";
            // 
            // lblCustomerInfo
            // 
            this.lblCustomerInfo.AutoSize = true;
            this.lblCustomerInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblCustomerInfo.Location = new System.Drawing.Point(23, 105);
            this.lblCustomerInfo.Name = "lblCustomerInfo";
            this.lblCustomerInfo.Size = new System.Drawing.Size(94, 23);
            this.lblCustomerInfo.TabIndex = 1;
            this.lblCustomerInfo.Text = "Customer: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(23, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Return Date:";
            // 
            // dtReturns
            // 
            this.dtReturns.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtReturns.Location = new System.Drawing.Point(27, 180);
            this.dtReturns.Name = "dtReturns";
            this.dtReturns.Size = new System.Drawing.Size(452, 27);
            this.dtReturns.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(23, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Final Odometer Reading:";
            // 
            // txtOdometers
            // 
            this.txtOdometers.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtOdometers.Location = new System.Drawing.Point(27, 245);
            this.txtOdometers.Name = "txtOdometers";
            this.txtOdometers.Size = new System.Drawing.Size(452, 27);
            this.txtOdometers.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(23, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Fuel Level:";
            // 
            // cbFuels
            // 
            this.cbFuels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFuels.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbFuels.Items.AddRange(new object[] { "Empty", "1/4", "1/2", "3/4", "Full" });
            this.cbFuels.Location = new System.Drawing.Point(27, 310);
            this.cbFuels.Name = "cbFuels";
            this.cbFuels.Size = new System.Drawing.Size(452, 28);
            this.cbFuels.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(23, 350);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Final Condition / Notes:";
            // 
            // txtConditions
            // 
            this.txtConditions.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtConditions.Location = new System.Drawing.Point(27, 375);
            this.txtConditions.Multiline = true;
            this.txtConditions.Name = "txtConditions";
            this.txtConditions.Size = new System.Drawing.Size(452, 73);
            this.txtConditions.TabIndex = 9;
            // 
            // btnAddDamage
            // 
            this.btnAddDamage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnAddDamage.FlatAppearance.BorderSize = 0;
            this.btnAddDamage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDamage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddDamage.ForeColor = System.Drawing.Color.White;
            this.btnAddDamage.Location = new System.Drawing.Point(516, 25);
            this.btnAddDamage.Name = "btnAddDamage";
            this.btnAddDamage.Size = new System.Drawing.Size(174, 45);
            this.btnAddDamage.TabIndex = 15;
            this.btnAddDamage.Text = "+ Add Damage";
            this.btnAddDamage.UseVisualStyleBackColor = false;
            // 
            // dgvDamages
            // 
            this.dgvDamages.AllowUserToAddRows = false;
            this.dgvDamages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDamages.BackgroundColor = System.Drawing.Color.White;
            this.dgvDamages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDamages.ColumnHeadersHeight = 35;
            this.dgvDamages.Location = new System.Drawing.Point(516, 85);
            this.dgvDamages.Name = "dgvDamages";
            this.dgvDamages.RowHeadersVisible = false;
            this.dgvDamages.Size = new System.Drawing.Size(561, 430);
            this.dgvDamages.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.numLateFee);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numDamages);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(27, 465);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 137);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fees and Billing";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(15, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 20);
            this.label7.TabIndex = 3;
            this.label7.Text = "Late Fees ( ₱):";
            // 
            // numLateFee
            // 
            this.numLateFee.DecimalPlaces = 2;
            this.numLateFee.Location = new System.Drawing.Point(18, 55);
            this.numLateFee.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numLateFee.Name = "numLateFee";
            this.numLateFee.Size = new System.Drawing.Size(180, 30);
            this.numLateFee.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(220, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Damage Fees ( ₱):";
            // 
            // numDamages
            // 
            this.numDamages.DecimalPlaces = 2;
            this.numDamages.Location = new System.Drawing.Point(223, 55);
            this.numDamages.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numDamages.Name = "numDamages";
            this.numDamages.Size = new System.Drawing.Size(180, 30);
            this.numDamages.TabIndex = 0;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblTotal.Location = new System.Drawing.Point(12, 95);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(139, 32);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "Total: ₱ 0.0";
            // 
            // btnCancels
            // 
            this.btnCancels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.btnCancels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancels.Location = new System.Drawing.Point(516, 615);
            this.btnCancels.Name = "btnCancels";
            this.btnCancels.Size = new System.Drawing.Size(200, 55);
            this.btnCancels.TabIndex = 12;
            this.btnCancels.Text = "Cancel";
            // 
            // btnConfirms
            // 
            this.btnConfirms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnConfirms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirms.ForeColor = System.Drawing.Color.White;
            this.btnConfirms.Location = new System.Drawing.Point(740, 615);
            this.btnConfirms.Name = "btnConfirms";
            this.btnConfirms.Size = new System.Drawing.Size(337, 55);
            this.btnConfirms.TabIndex = 11;
            this.btnConfirms.Text = "Complete Return Process";
            // 
            // ReturnVehicleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1127, 703);
            this.Controls.Add(this.btnAddDamage);
            this.Controls.Add(this.dgvDamages);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancels);
            this.Controls.Add(this.btnConfirms);
            this.Controls.Add(this.lblVehicleInfo);
            this.Controls.Add(this.txtConditions);
            this.Controls.Add(this.cbFuels);
            this.Controls.Add(this.txtOdometers);
            this.Controls.Add(this.dtReturns);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCustomerInfo);
            this.Controls.Add(this.label1);
            this.Name = "ReturnVehicleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Return Vehicle";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLateFee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDamages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDamages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCustomerInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtReturns;
        private System.Windows.Forms.TextBox txtOdometers;
        private System.Windows.Forms.ComboBox cbFuels;
        private System.Windows.Forms.TextBox txtConditions;
        private System.Windows.Forms.Label lblVehicleInfo;
        private System.Windows.Forms.Button btnConfirms;
        private System.Windows.Forms.Button btnCancels;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numDamages;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numLateFee;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvDamages;
        private System.Windows.Forms.Button btnAddDamage;
    }
}