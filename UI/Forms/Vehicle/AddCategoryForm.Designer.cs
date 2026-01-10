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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabCategoryInfo = new System.Windows.Forms.TabPage();
            this.grpCategoryInfo = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.tabRates = new System.Windows.Forms.TabPage();
            this.panelRates = new System.Windows.Forms.Panel();
            this.grpMonthly = new System.Windows.Forms.GroupBox();
            this.nudMonthlyRate = new System.Windows.Forms.NumericUpDown();
            this.lblMonthly = new System.Windows.Forms.Label();
            this.chkMonthlyEnabled = new System.Windows.Forms.CheckBox();
            this.grpWeekly = new System.Windows.Forms.GroupBox();
            this.nudWeeklyRate = new System.Windows.Forms.NumericUpDown();
            this.lblWeekly = new System.Windows.Forms.Label();
            this.chkWeeklyEnabled = new System.Windows.Forms.CheckBox();
            this.grpDaily = new System.Windows.Forms.GroupBox();
            this.nudDailyRate = new System.Windows.Forms.NumericUpDown();
            this.lblDaily = new System.Windows.Forms.Label();
            this.chkDailyEnabled = new System.Windows.Forms.CheckBox();
            this.grpExistingCategories = new System.Windows.Forms.GroupBox();
            this.panelListButtons = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lstCategories = new System.Windows.Forms.ListBox();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabCategoryInfo.SuspendLayout();
            this.grpCategoryInfo.SuspendLayout();
            this.tabRates.SuspendLayout();
            this.panelRates.SuspendLayout();
            this.grpMonthly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudMonthlyRate).BeginInit();
            this.grpWeekly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudWeeklyRate).BeginInit();
            this.grpDaily.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudDailyRate).BeginInit();
            this.grpExistingCategories.SuspendLayout();
            this.panelListButtons.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(750, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(25, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(333, 46);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Vehicle Category";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Controls.Add(this.tabControl);
            this.panelContent.Controls.Add(this.grpExistingCategories);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 80);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(25);
            this.panelContent.Size = new System.Drawing.Size(750, 600);
            this.panelContent.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabCategoryInfo);
            this.tabControl.Controls.Add(this.tabRates);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.tabControl.Location = new System.Drawing.Point(25, 25);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(700, 280);
            this.tabControl.TabIndex = 2;
            // 
            // tabCategoryInfo
            // 
            this.tabCategoryInfo.BackColor = System.Drawing.Color.White;
            this.tabCategoryInfo.Controls.Add(this.grpCategoryInfo);
            this.tabCategoryInfo.Location = new System.Drawing.Point(4, 31);
            this.tabCategoryInfo.Name = "tabCategoryInfo";
            this.tabCategoryInfo.Padding = new System.Windows.Forms.Padding(15);
            this.tabCategoryInfo.Size = new System.Drawing.Size(692, 245);
            this.tabCategoryInfo.TabIndex = 0;
            this.tabCategoryInfo.Text = "Category Information";
            // 
            // grpCategoryInfo
            // 
            this.grpCategoryInfo.BackColor = System.Drawing.Color.White;
            this.grpCategoryInfo.Controls.Add(this.txtDescription);
            this.grpCategoryInfo.Controls.Add(this.lblDescription);
            this.grpCategoryInfo.Controls.Add(this.txtCategoryName);
            this.grpCategoryInfo.Controls.Add(this.lblCategoryName);
            this.grpCategoryInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCategoryInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpCategoryInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.grpCategoryInfo.Location = new System.Drawing.Point(15, 15);
            this.grpCategoryInfo.Name = "grpCategoryInfo";
            this.grpCategoryInfo.Size = new System.Drawing.Size(662, 215);
            this.grpCategoryInfo.TabIndex = 0;
            this.grpCategoryInfo.TabStop = false;
            this.grpCategoryInfo.Text = "Basic Information";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtDescription.Location = new System.Drawing.Point(25, 135);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(610, 32);
            this.txtDescription.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.lblDescription.Location = new System.Drawing.Point(25, 105);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(110, 25);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description:";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCategoryName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtCategoryName.Location = new System.Drawing.Point(25, 65);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(610, 32);
            this.txtCategoryName.TabIndex = 1;
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblCategoryName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.lblCategoryName.Location = new System.Drawing.Point(25, 35);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(147, 25);
            this.lblCategoryName.TabIndex = 0;
            this.lblCategoryName.Text = "Category Name:";
            // 
            // tabRates
            // 
            this.tabRates.BackColor = System.Drawing.Color.White;
            this.tabRates.Controls.Add(this.panelRates);
            this.tabRates.Location = new System.Drawing.Point(4, 31);
            this.tabRates.Name = "tabRates";
            this.tabRates.Padding = new System.Windows.Forms.Padding(15);
            this.tabRates.Size = new System.Drawing.Size(692, 245);
            this.tabRates.TabIndex = 1;
            this.tabRates.Text = "Rental Rates";
            // 
            // panelRates
            // 
            this.panelRates.BackColor = System.Drawing.Color.White;
            this.panelRates.Controls.Add(this.grpMonthly);
            this.panelRates.Controls.Add(this.grpWeekly);
            this.panelRates.Controls.Add(this.grpDaily);
            this.panelRates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRates.Location = new System.Drawing.Point(15, 15);
            this.panelRates.Name = "panelRates";
            this.panelRates.Size = new System.Drawing.Size(662, 215);
            this.panelRates.TabIndex = 0;
            // 
            // grpMonthly
            // 
            this.grpMonthly.BackColor = System.Drawing.Color.White;
            this.grpMonthly.Controls.Add(this.nudMonthlyRate);
            this.grpMonthly.Controls.Add(this.lblMonthly);
            this.grpMonthly.Controls.Add(this.chkMonthlyEnabled);
            this.grpMonthly.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpMonthly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.grpMonthly.Location = new System.Drawing.Point(440, 10);
            this.grpMonthly.Name = "grpMonthly";
            this.grpMonthly.Size = new System.Drawing.Size(200, 190);
            this.grpMonthly.TabIndex = 2;
            this.grpMonthly.TabStop = false;
            this.grpMonthly.Text = "Monthly Rate";
            // 
            // nudMonthlyRate
            // 
            this.nudMonthlyRate.DecimalPlaces = 2;
            this.nudMonthlyRate.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nudMonthlyRate.Location = new System.Drawing.Point(25, 120);
            this.nudMonthlyRate.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudMonthlyRate.Name = "nudMonthlyRate";
            this.nudMonthlyRate.Size = new System.Drawing.Size(150, 32);
            this.nudMonthlyRate.TabIndex = 2;
            this.nudMonthlyRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMonthlyRate.ThousandsSeparator = true;
            // 
            // lblMonthly
            // 
            this.lblMonthly.AutoSize = true;
            this.lblMonthly.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblMonthly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMonthly.Location = new System.Drawing.Point(25, 90);
            this.lblMonthly.Name = "lblMonthly";
            this.lblMonthly.Size = new System.Drawing.Size(57, 25);
            this.lblMonthly.TabIndex = 1;
            this.lblMonthly.Text = "Rate:";
            // 
            // chkMonthlyEnabled
            // 
            this.chkMonthlyEnabled.AutoSize = true;
            this.chkMonthlyEnabled.Checked = true;
            this.chkMonthlyEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMonthlyEnabled.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.chkMonthlyEnabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkMonthlyEnabled.Location = new System.Drawing.Point(25, 50);
            this.chkMonthlyEnabled.Name = "chkMonthlyEnabled";
            this.chkMonthlyEnabled.Size = new System.Drawing.Size(95, 29);
            this.chkMonthlyEnabled.TabIndex = 0;
            this.chkMonthlyEnabled.Text = "Enabled";
            this.chkMonthlyEnabled.UseVisualStyleBackColor = true;
            this.chkMonthlyEnabled.CheckedChanged += new System.EventHandler(this.chkMonthlyEnabled_CheckedChanged);
            // 
            // grpWeekly
            // 
            this.grpWeekly.BackColor = System.Drawing.Color.White;
            this.grpWeekly.Controls.Add(this.nudWeeklyRate);
            this.grpWeekly.Controls.Add(this.lblWeekly);
            this.grpWeekly.Controls.Add(this.chkWeeklyEnabled);
            this.grpWeekly.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpWeekly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.grpWeekly.Location = new System.Drawing.Point(230, 10);
            this.grpWeekly.Name = "grpWeekly";
            this.grpWeekly.Size = new System.Drawing.Size(200, 190);
            this.grpWeekly.TabIndex = 1;
            this.grpWeekly.TabStop = false;
            this.grpWeekly.Text = "Weekly Rate";
            // 
            // nudWeeklyRate
            // 
            this.nudWeeklyRate.DecimalPlaces = 2;
            this.nudWeeklyRate.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nudWeeklyRate.Location = new System.Drawing.Point(25, 120);
            this.nudWeeklyRate.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudWeeklyRate.Name = "nudWeeklyRate";
            this.nudWeeklyRate.Size = new System.Drawing.Size(150, 32);
            this.nudWeeklyRate.TabIndex = 2;
            this.nudWeeklyRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudWeeklyRate.ThousandsSeparator = true;
            // 
            // lblWeekly
            // 
            this.lblWeekly.AutoSize = true;
            this.lblWeekly.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblWeekly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblWeekly.Location = new System.Drawing.Point(25, 90);
            this.lblWeekly.Name = "lblWeekly";
            this.lblWeekly.Size = new System.Drawing.Size(57, 25);
            this.lblWeekly.TabIndex = 1;
            this.lblWeekly.Text = "Rate:";
            // 
            // chkWeeklyEnabled
            // 
            this.chkWeeklyEnabled.AutoSize = true;
            this.chkWeeklyEnabled.Checked = true;
            this.chkWeeklyEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWeeklyEnabled.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.chkWeeklyEnabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkWeeklyEnabled.Location = new System.Drawing.Point(25, 50);
            this.chkWeeklyEnabled.Name = "chkWeeklyEnabled";
            this.chkWeeklyEnabled.Size = new System.Drawing.Size(95, 29);
            this.chkWeeklyEnabled.TabIndex = 0;
            this.chkWeeklyEnabled.Text = "Enabled";
            this.chkWeeklyEnabled.UseVisualStyleBackColor = true;
            this.chkWeeklyEnabled.CheckedChanged += new System.EventHandler(this.chkWeeklyEnabled_CheckedChanged);
            // 
            // grpDaily
            // 
            this.grpDaily.BackColor = System.Drawing.Color.White;
            this.grpDaily.Controls.Add(this.nudDailyRate);
            this.grpDaily.Controls.Add(this.lblDaily);
            this.grpDaily.Controls.Add(this.chkDailyEnabled);
            this.grpDaily.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpDaily.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.grpDaily.Location = new System.Drawing.Point(20, 10);
            this.grpDaily.Name = "grpDaily";
            this.grpDaily.Size = new System.Drawing.Size(200, 190);
            this.grpDaily.TabIndex = 0;
            this.grpDaily.TabStop = false;
            this.grpDaily.Text = "Daily Rate";
            // 
            // nudDailyRate
            // 
            this.nudDailyRate.DecimalPlaces = 2;
            this.nudDailyRate.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nudDailyRate.Location = new System.Drawing.Point(25, 120);
            this.nudDailyRate.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudDailyRate.Name = "nudDailyRate";
            this.nudDailyRate.Size = new System.Drawing.Size(150, 32);
            this.nudDailyRate.TabIndex = 2;
            this.nudDailyRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudDailyRate.ThousandsSeparator = true;
            // 
            // lblDaily
            // 
            this.lblDaily.AutoSize = true;
            this.lblDaily.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDaily.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDaily.Location = new System.Drawing.Point(25, 90);
            this.lblDaily.Name = "lblDaily";
            this.lblDaily.Size = new System.Drawing.Size(57, 25);
            this.lblDaily.TabIndex = 1;
            this.lblDaily.Text = "Rate:";
            // 
            // chkDailyEnabled
            // 
            this.chkDailyEnabled.AutoSize = true;
            this.chkDailyEnabled.Checked = true;
            this.chkDailyEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDailyEnabled.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.chkDailyEnabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkDailyEnabled.Location = new System.Drawing.Point(25, 50);
            this.chkDailyEnabled.Name = "chkDailyEnabled";
            this.chkDailyEnabled.Size = new System.Drawing.Size(95, 29);
            this.chkDailyEnabled.TabIndex = 0;
            this.chkDailyEnabled.Text = "Enabled";
            this.chkDailyEnabled.UseVisualStyleBackColor = true;
            this.chkDailyEnabled.CheckedChanged += new System.EventHandler(this.chkDailyEnabled_CheckedChanged);
            // 
            // grpExistingCategories
            // 
            this.grpExistingCategories.BackColor = System.Drawing.Color.White;
            this.grpExistingCategories.Controls.Add(this.panelListButtons);
            this.grpExistingCategories.Controls.Add(this.lstCategories);
            this.grpExistingCategories.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpExistingCategories.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpExistingCategories.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.grpExistingCategories.Location = new System.Drawing.Point(25, 320);
            this.grpExistingCategories.Name = "grpExistingCategories";
            this.grpExistingCategories.Size = new System.Drawing.Size(700, 255);
            this.grpExistingCategories.TabIndex = 1;
            this.grpExistingCategories.TabStop = false;
            this.grpExistingCategories.Text = "Existing Categories";
            // 
            // panelListButtons
            // 
            this.panelListButtons.Controls.Add(this.btnDelete);
            this.panelListButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelListButtons.Location = new System.Drawing.Point(3, 217);
            this.panelListButtons.Name = "panelListButtons";
            this.panelListButtons.Padding = new System.Windows.Forms.Padding(10);
            this.panelListButtons.Size = new System.Drawing.Size(694, 35);
            this.panelListButtons.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(10, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 30);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // lstCategories
            // 
            this.lstCategories.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCategories.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lstCategories.FormattingEnabled = true;
            this.lstCategories.ItemHeight = 25;
            this.lstCategories.Location = new System.Drawing.Point(3, 25);
            this.lstCategories.Name = "lstCategories";
            this.lstCategories.Size = new System.Drawing.Size(694, 227);
            this.lstCategories.TabIndex = 0;
            this.lstCategories.SelectedIndexChanged += new System.EventHandler(this.lstCategories_SelectedIndexChanged);
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelFooter.Controls.Add(this.btnCancel);
            this.panelFooter.Controls.Add(this.btnSave);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 680);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Padding = new System.Windows.Forms.Padding(25, 15, 25, 15);
            this.panelFooter.Size = new System.Drawing.Size(750, 100);
            this.panelFooter.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(122)))), ((int)(((byte)(137)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(360, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 55);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(510, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 55);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save Category";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // AddCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(750, 780);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCategoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vehicle Category Management - VRMS";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabCategoryInfo.ResumeLayout(false);
            this.grpCategoryInfo.ResumeLayout(false);
            this.grpCategoryInfo.PerformLayout();
            this.tabRates.ResumeLayout(false);
            this.panelRates.ResumeLayout(false);
            this.grpMonthly.ResumeLayout(false);
            this.grpMonthly.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudMonthlyRate).EndInit();
            this.grpWeekly.ResumeLayout(false);
            this.grpWeekly.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudWeeklyRate).EndInit();
            this.grpDaily.ResumeLayout(false);
            this.grpDaily.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudDailyRate).EndInit();
            this.grpExistingCategories.ResumeLayout(false);
            this.panelListButtons.ResumeLayout(false);
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}