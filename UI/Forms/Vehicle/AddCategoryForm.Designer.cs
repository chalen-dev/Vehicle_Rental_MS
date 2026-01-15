namespace VRMS.UI.Forms
{
    partial class AddCategoryForm
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
            panelHeader = new Panel();
            lblTitle = new Label();
            panelContent = new Panel();
            tabControl = new TabControl();
            tabCategoryInfo = new TabPage();
            grpCategoryInfo = new GroupBox();
            txtDescription = new TextBox();
            lblDescription = new Label();
            txtCategoryName = new TextBox();
            lblCategoryName = new Label();
            tabRates = new TabPage();
            panelRates = new Panel();
            groupBox1 = new GroupBox();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            checkBox1 = new CheckBox();
            grpSecurityDeposit = new GroupBox();
            numMileageOverage = new NumericUpDown();
            lblSecurityDeposit = new Label();
            chkMileageOverage = new CheckBox();
            grpMonthly = new GroupBox();
            nudMonthlyRate = new NumericUpDown();
            lblMonthly = new Label();
            chkMonthlyEnabled = new CheckBox();
            grpWeekly = new GroupBox();
            nudWeeklyRate = new NumericUpDown();
            lblWeekly = new Label();
            chkWeeklyEnabled = new CheckBox();
            grpDaily = new GroupBox();
            nudDailyRate = new NumericUpDown();
            lblDaily = new Label();
            chkDailyEnabled = new CheckBox();
            grpExistingCategories = new GroupBox();
            panelListButtons = new Panel();
            btnDelete = new Button();
            lstCategories = new ListBox();
            panelFooter = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            panelHeader.SuspendLayout();
            panelContent.SuspendLayout();
            tabControl.SuspendLayout();
            tabCategoryInfo.SuspendLayout();
            grpCategoryInfo.SuspendLayout();
            tabRates.SuspendLayout();
            panelRates.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            grpSecurityDeposit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMileageOverage).BeginInit();
            grpMonthly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudMonthlyRate).BeginInit();
            grpWeekly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudWeeklyRate).BeginInit();
            grpDaily.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDailyRate).BeginInit();
            grpExistingCategories.SuspendLayout();
            panelListButtons.SuspendLayout();
            panelFooter.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(30, 60, 90);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(955, 80);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(25, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(279, 46);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Vehicle Category";
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.White;
            panelContent.Controls.Add(tabControl);
            panelContent.Controls.Add(grpExistingCategories);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 80);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(25);
            panelContent.Size = new Size(955, 650);
            panelContent.TabIndex = 1;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabCategoryInfo);
            tabControl.Controls.Add(tabRates);
            tabControl.Dock = DockStyle.Top;
            tabControl.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            tabControl.Location = new Point(25, 25);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(905, 320);
            tabControl.TabIndex = 2;
            // 
            // tabCategoryInfo
            // 
            tabCategoryInfo.BackColor = Color.White;
            tabCategoryInfo.Controls.Add(grpCategoryInfo);
            tabCategoryInfo.Location = new Point(4, 32);
            tabCategoryInfo.Name = "tabCategoryInfo";
            tabCategoryInfo.Padding = new Padding(15);
            tabCategoryInfo.Size = new Size(897, 284);
            tabCategoryInfo.TabIndex = 0;
            tabCategoryInfo.Text = "Category Information";
            // 
            // grpCategoryInfo
            // 
            grpCategoryInfo.BackColor = Color.White;
            grpCategoryInfo.Controls.Add(txtDescription);
            grpCategoryInfo.Controls.Add(lblDescription);
            grpCategoryInfo.Controls.Add(txtCategoryName);
            grpCategoryInfo.Controls.Add(lblCategoryName);
            grpCategoryInfo.Dock = DockStyle.Fill;
            grpCategoryInfo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpCategoryInfo.ForeColor = Color.FromArgb(30, 60, 90);
            grpCategoryInfo.Location = new Point(15, 15);
            grpCategoryInfo.Name = "grpCategoryInfo";
            grpCategoryInfo.Size = new Size(867, 254);
            grpCategoryInfo.TabIndex = 0;
            grpCategoryInfo.TabStop = false;
            grpCategoryInfo.Text = "Basic Information";
            // 
            // txtDescription
            // 
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 11F);
            txtDescription.Location = new Point(25, 135);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(660, 32);
            txtDescription.TabIndex = 3;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblDescription.ForeColor = Color.FromArgb(30, 60, 90);
            lblDescription.Location = new Point(25, 105);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(115, 25);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Description:";
            // 
            // txtCategoryName
            // 
            txtCategoryName.BorderStyle = BorderStyle.FixedSingle;
            txtCategoryName.Font = new Font("Segoe UI", 11F);
            txtCategoryName.Location = new Point(25, 65);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(660, 32);
            txtCategoryName.TabIndex = 1;
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblCategoryName.ForeColor = Color.FromArgb(30, 60, 90);
            lblCategoryName.Location = new Point(25, 35);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(153, 25);
            lblCategoryName.TabIndex = 0;
            lblCategoryName.Text = "Category Name:";
            // 
            // tabRates
            // 
            tabRates.BackColor = Color.White;
            tabRates.Controls.Add(panelRates);
            tabRates.Location = new Point(4, 32);
            tabRates.Name = "tabRates";
            tabRates.Padding = new Padding(15);
            tabRates.Size = new Size(897, 284);
            tabRates.TabIndex = 1;
            tabRates.Text = "Rental Rates & Deposit";
            // 
            // panelRates
            // 
            panelRates.BackColor = Color.White;
            panelRates.Controls.Add(groupBox1);
            panelRates.Controls.Add(grpSecurityDeposit);
            panelRates.Controls.Add(grpMonthly);
            panelRates.Controls.Add(grpWeekly);
            panelRates.Controls.Add(grpDaily);
            panelRates.Dock = DockStyle.Fill;
            panelRates.Location = new Point(15, 15);
            panelRates.Name = "panelRates";
            panelRates.Size = new Size(867, 254);
            panelRates.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(numericUpDown1);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            groupBox1.ForeColor = Color.FromArgb(30, 60, 90);
            groupBox1.Location = new Point(471, 10);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(186, 230);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Excess Mileage Rate";
            // 
            // numericUpDown1
            // 
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Font = new Font("Segoe UI", 11F);
            numericUpDown1.Location = new Point(16, 118);
            numericUpDown1.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(145, 32);
            numericUpDown1.TabIndex = 2;
            numericUpDown1.TextAlign = HorizontalAlignment.Right;
            numericUpDown1.ThousandsSeparator = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(25, 90);
            label1.Name = "label1";
            label1.Size = new Size(53, 25);
            label1.TabIndex = 1;
            label1.Text = "Rate:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Font = new Font("Segoe UI", 11F);
            checkBox1.ForeColor = Color.FromArgb(64, 64, 64);
            checkBox1.Location = new Point(25, 50);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(102, 29);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Enabled";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // grpSecurityDeposit
            // 
            grpSecurityDeposit.BackColor = Color.White;
            grpSecurityDeposit.Controls.Add(numMileageOverage);
            grpSecurityDeposit.Controls.Add(lblSecurityDeposit);
            grpSecurityDeposit.Controls.Add(chkMileageOverage);
            grpSecurityDeposit.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpSecurityDeposit.ForeColor = Color.FromArgb(30, 60, 90);
            grpSecurityDeposit.Location = new Point(663, 10);
            grpSecurityDeposit.Name = "grpSecurityDeposit";
            grpSecurityDeposit.Size = new Size(181, 230);
            grpSecurityDeposit.TabIndex = 3;
            grpSecurityDeposit.TabStop = false;
            grpSecurityDeposit.Text = "Security Deposit";
            // 
            // numMileageOverage
            // 
            numMileageOverage.DecimalPlaces = 2;
            numMileageOverage.Font = new Font("Segoe UI", 11F);
            numMileageOverage.Location = new Point(11, 120);
            numMileageOverage.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numMileageOverage.Name = "numMileageOverage";
            numMileageOverage.Size = new Size(156, 32);
            numMileageOverage.TabIndex = 2;
            numMileageOverage.TextAlign = HorizontalAlignment.Right;
            numMileageOverage.ThousandsSeparator = true;
            // 
            // lblSecurityDeposit
            // 
            lblSecurityDeposit.AutoSize = true;
            lblSecurityDeposit.Font = new Font("Segoe UI", 11F);
            lblSecurityDeposit.ForeColor = Color.FromArgb(64, 64, 64);
            lblSecurityDeposit.Location = new Point(25, 90);
            lblSecurityDeposit.Name = "lblSecurityDeposit";
            lblSecurityDeposit.Size = new Size(53, 25);
            lblSecurityDeposit.TabIndex = 1;
            lblSecurityDeposit.Text = "Rate:";
            // 
            // chkMileageOverage
            // 
            chkMileageOverage.AutoSize = true;
            chkMileageOverage.Checked = true;
            chkMileageOverage.CheckState = CheckState.Checked;
            chkMileageOverage.Font = new Font("Segoe UI", 11F);
            chkMileageOverage.ForeColor = Color.FromArgb(64, 64, 64);
            chkMileageOverage.Location = new Point(25, 50);
            chkMileageOverage.Name = "chkMileageOverage";
            chkMileageOverage.Size = new Size(102, 29);
            chkMileageOverage.TabIndex = 0;
            chkMileageOverage.Text = "Enabled";
            chkMileageOverage.UseVisualStyleBackColor = true;
            // 
            // grpMonthly
            // 
            grpMonthly.BackColor = Color.White;
            grpMonthly.Controls.Add(nudMonthlyRate);
            grpMonthly.Controls.Add(lblMonthly);
            grpMonthly.Controls.Add(chkMonthlyEnabled);
            grpMonthly.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpMonthly.ForeColor = Color.FromArgb(30, 60, 90);
            grpMonthly.Location = new Point(320, 10);
            grpMonthly.Name = "grpMonthly";
            grpMonthly.Size = new Size(140, 230);
            grpMonthly.TabIndex = 2;
            grpMonthly.TabStop = false;
            grpMonthly.Text = "Monthly Rate";
            // 
            // nudMonthlyRate
            // 
            nudMonthlyRate.DecimalPlaces = 2;
            nudMonthlyRate.Font = new Font("Segoe UI", 11F);
            nudMonthlyRate.Location = new Point(15, 120);
            nudMonthlyRate.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudMonthlyRate.Name = "nudMonthlyRate";
            nudMonthlyRate.Size = new Size(110, 32);
            nudMonthlyRate.TabIndex = 2;
            nudMonthlyRate.TextAlign = HorizontalAlignment.Right;
            nudMonthlyRate.ThousandsSeparator = true;
            // 
            // lblMonthly
            // 
            lblMonthly.AutoSize = true;
            lblMonthly.Font = new Font("Segoe UI", 11F);
            lblMonthly.ForeColor = Color.FromArgb(64, 64, 64);
            lblMonthly.Location = new Point(15, 90);
            lblMonthly.Name = "lblMonthly";
            lblMonthly.Size = new Size(53, 25);
            lblMonthly.TabIndex = 1;
            lblMonthly.Text = "Rate:";
            // 
            // chkMonthlyEnabled
            // 
            chkMonthlyEnabled.AutoSize = true;
            chkMonthlyEnabled.Checked = true;
            chkMonthlyEnabled.CheckState = CheckState.Checked;
            chkMonthlyEnabled.Font = new Font("Segoe UI", 11F);
            chkMonthlyEnabled.ForeColor = Color.FromArgb(64, 64, 64);
            chkMonthlyEnabled.Location = new Point(15, 50);
            chkMonthlyEnabled.Name = "chkMonthlyEnabled";
            chkMonthlyEnabled.Size = new Size(102, 29);
            chkMonthlyEnabled.TabIndex = 0;
            chkMonthlyEnabled.Text = "Enabled";
            chkMonthlyEnabled.UseVisualStyleBackColor = true;
            // 
            // grpWeekly
            // 
            grpWeekly.BackColor = Color.White;
            grpWeekly.Controls.Add(nudWeeklyRate);
            grpWeekly.Controls.Add(lblWeekly);
            grpWeekly.Controls.Add(chkWeeklyEnabled);
            grpWeekly.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpWeekly.ForeColor = Color.FromArgb(30, 60, 90);
            grpWeekly.Location = new Point(170, 10);
            grpWeekly.Name = "grpWeekly";
            grpWeekly.Size = new Size(140, 230);
            grpWeekly.TabIndex = 1;
            grpWeekly.TabStop = false;
            grpWeekly.Text = "Weekly Rate";
            // 
            // nudWeeklyRate
            // 
            nudWeeklyRate.DecimalPlaces = 2;
            nudWeeklyRate.Font = new Font("Segoe UI", 11F);
            nudWeeklyRate.Location = new Point(15, 120);
            nudWeeklyRate.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudWeeklyRate.Name = "nudWeeklyRate";
            nudWeeklyRate.Size = new Size(110, 32);
            nudWeeklyRate.TabIndex = 2;
            nudWeeklyRate.TextAlign = HorizontalAlignment.Right;
            nudWeeklyRate.ThousandsSeparator = true;
            // 
            // lblWeekly
            // 
            lblWeekly.AutoSize = true;
            lblWeekly.Font = new Font("Segoe UI", 11F);
            lblWeekly.ForeColor = Color.FromArgb(64, 64, 64);
            lblWeekly.Location = new Point(15, 90);
            lblWeekly.Name = "lblWeekly";
            lblWeekly.Size = new Size(53, 25);
            lblWeekly.TabIndex = 1;
            lblWeekly.Text = "Rate:";
            // 
            // chkWeeklyEnabled
            // 
            chkWeeklyEnabled.AutoSize = true;
            chkWeeklyEnabled.Checked = true;
            chkWeeklyEnabled.CheckState = CheckState.Checked;
            chkWeeklyEnabled.Font = new Font("Segoe UI", 11F);
            chkWeeklyEnabled.ForeColor = Color.FromArgb(64, 64, 64);
            chkWeeklyEnabled.Location = new Point(15, 50);
            chkWeeklyEnabled.Name = "chkWeeklyEnabled";
            chkWeeklyEnabled.Size = new Size(102, 29);
            chkWeeklyEnabled.TabIndex = 0;
            chkWeeklyEnabled.Text = "Enabled";
            chkWeeklyEnabled.UseVisualStyleBackColor = true;
            // 
            // grpDaily
            // 
            grpDaily.BackColor = Color.White;
            grpDaily.Controls.Add(nudDailyRate);
            grpDaily.Controls.Add(lblDaily);
            grpDaily.Controls.Add(chkDailyEnabled);
            grpDaily.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpDaily.ForeColor = Color.FromArgb(30, 60, 90);
            grpDaily.Location = new Point(20, 10);
            grpDaily.Name = "grpDaily";
            grpDaily.Size = new Size(140, 230);
            grpDaily.TabIndex = 0;
            grpDaily.TabStop = false;
            grpDaily.Text = "Daily Rate";
            // 
            // nudDailyRate
            // 
            nudDailyRate.DecimalPlaces = 2;
            nudDailyRate.Font = new Font("Segoe UI", 11F);
            nudDailyRate.Location = new Point(15, 120);
            nudDailyRate.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudDailyRate.Name = "nudDailyRate";
            nudDailyRate.Size = new Size(110, 32);
            nudDailyRate.TabIndex = 2;
            nudDailyRate.TextAlign = HorizontalAlignment.Right;
            nudDailyRate.ThousandsSeparator = true;
            // 
            // lblDaily
            // 
            lblDaily.AutoSize = true;
            lblDaily.Font = new Font("Segoe UI", 11F);
            lblDaily.ForeColor = Color.FromArgb(64, 64, 64);
            lblDaily.Location = new Point(15, 90);
            lblDaily.Name = "lblDaily";
            lblDaily.Size = new Size(53, 25);
            lblDaily.TabIndex = 1;
            lblDaily.Text = "Rate:";
            // 
            // chkDailyEnabled
            // 
            chkDailyEnabled.AutoSize = true;
            chkDailyEnabled.Checked = true;
            chkDailyEnabled.CheckState = CheckState.Checked;
            chkDailyEnabled.Font = new Font("Segoe UI", 11F);
            chkDailyEnabled.ForeColor = Color.FromArgb(64, 64, 64);
            chkDailyEnabled.Location = new Point(15, 50);
            chkDailyEnabled.Name = "chkDailyEnabled";
            chkDailyEnabled.Size = new Size(102, 29);
            chkDailyEnabled.TabIndex = 0;
            chkDailyEnabled.Text = "Enabled";
            chkDailyEnabled.UseVisualStyleBackColor = true;
            // 
            // grpExistingCategories
            // 
            grpExistingCategories.BackColor = Color.White;
            grpExistingCategories.Controls.Add(panelListButtons);
            grpExistingCategories.Controls.Add(lstCategories);
            grpExistingCategories.Dock = DockStyle.Bottom;
            grpExistingCategories.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpExistingCategories.ForeColor = Color.FromArgb(30, 60, 90);
            grpExistingCategories.Location = new Point(25, 360);
            grpExistingCategories.Name = "grpExistingCategories";
            grpExistingCategories.Size = new Size(905, 265);
            grpExistingCategories.TabIndex = 1;
            grpExistingCategories.TabStop = false;
            grpExistingCategories.Text = "Existing Categories";
            // 
            // panelListButtons
            // 
            panelListButtons.Controls.Add(btnDelete);
            panelListButtons.Dock = DockStyle.Bottom;
            panelListButtons.Location = new Point(3, 227);
            panelListButtons.Name = "panelListButtons";
            panelListButtons.Padding = new Padding(10);
            panelListButtons.Size = new Size(899, 35);
            panelListButtons.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(10, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 30);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // lstCategories
            // 
            lstCategories.BorderStyle = BorderStyle.FixedSingle;
            lstCategories.Dock = DockStyle.Fill;
            lstCategories.Font = new Font("Segoe UI", 11F);
            lstCategories.FormattingEnabled = true;
            lstCategories.Location = new Point(3, 26);
            lstCategories.Name = "lstCategories";
            lstCategories.Size = new Size(899, 236);
            lstCategories.TabIndex = 0;
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.FromArgb(248, 249, 250);
            panelFooter.Controls.Add(btnCancel);
            panelFooter.Controls.Add(btnSave);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(0, 730);
            panelFooter.Name = "panelFooter";
            panelFooter.Padding = new Padding(25, 15, 25, 15);
            panelFooter.Size = new Size(955, 100);
            panelFooter.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(108, 122, 137);
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(385, 15);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(140, 55);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(535, 15);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(200, 55);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save Category";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // AddCategoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnCancel;
            ClientSize = new Size(955, 830);
            Controls.Add(panelContent);
            Controls.Add(panelFooter);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddCategoryForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Vehicle Category Management - VRMS";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelContent.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabCategoryInfo.ResumeLayout(false);
            grpCategoryInfo.ResumeLayout(false);
            grpCategoryInfo.PerformLayout();
            tabRates.ResumeLayout(false);
            panelRates.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            grpSecurityDeposit.ResumeLayout(false);
            grpSecurityDeposit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMileageOverage).EndInit();
            grpMonthly.ResumeLayout(false);
            grpMonthly.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudMonthlyRate).EndInit();
            grpWeekly.ResumeLayout(false);
            grpWeekly.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudWeeklyRate).EndInit();
            grpDaily.ResumeLayout(false);
            grpDaily.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDailyRate).EndInit();
            grpExistingCategories.ResumeLayout(false);
            panelListButtons.ResumeLayout(false);
            panelFooter.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.GroupBox grpExistingCategories;
        private System.Windows.Forms.ListBox lstCategories;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panelListButtons;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabCategoryInfo;
        private System.Windows.Forms.GroupBox grpCategoryInfo;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.TabPage tabRates;
        private System.Windows.Forms.Panel panelRates;
        private System.Windows.Forms.GroupBox grpDaily;
        private System.Windows.Forms.NumericUpDown nudDailyRate;
        private System.Windows.Forms.Label lblDaily;
        private System.Windows.Forms.CheckBox chkDailyEnabled;
        private System.Windows.Forms.GroupBox grpWeekly;
        private System.Windows.Forms.NumericUpDown nudWeeklyRate;
        private System.Windows.Forms.Label lblWeekly;
        private System.Windows.Forms.CheckBox chkWeeklyEnabled;
        private System.Windows.Forms.GroupBox grpMonthly;
        private System.Windows.Forms.NumericUpDown nudMonthlyRate;
        private System.Windows.Forms.Label lblMonthly;
        private System.Windows.Forms.CheckBox chkMonthlyEnabled;
        private System.Windows.Forms.GroupBox grpSecurityDeposit;
        private System.Windows.Forms.NumericUpDown numMileageOverage;
        private System.Windows.Forms.Label lblSecurityDeposit;
        private System.Windows.Forms.CheckBox chkMileageOverage;
        private GroupBox groupBox1;
        private NumericUpDown numericUpDown1;
        private Label label1;
        private CheckBox checkBox1;
    }
}