namespace VRMS.UI.Forms.Customers
{
    partial class CustomerAccountForm
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
            lblTitle = new Label();
            splitContainer = new SplitContainer();
            dgvCustomerAccounts = new DataGridView();
            panelRight = new Panel();
            groupAccountStatus = new GroupBox();
            lblAccountState = new Label();
            chkAccountEnabled = new CheckBox();
            groupCredentials = new GroupBox();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            panelActions = new Panel();
            btnCreate = new Button();
            btnResetPassword = new Button();
            btnDisable = new Button();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomerAccounts).BeginInit();
            panelRight.SuspendLayout();
            groupAccountStatus.SuspendLayout();
            groupCredentials.SuspendLayout();
            panelActions.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(24, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(282, 32);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Customer Login Account";
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(dgvCustomerAccounts);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(panelRight);
            splitContainer.Size = new Size(1195, 660);
            splitContainer.SplitterDistance = 545;
            splitContainer.SplitterWidth = 8;
            splitContainer.TabIndex = 0;
            splitContainer.SplitterMoved += splitContainer_SplitterMoved;
            // 
            // dgvCustomerAccounts
            // 
            dgvCustomerAccounts.AllowUserToAddRows = false;
            dgvCustomerAccounts.AllowUserToDeleteRows = false;
            dgvCustomerAccounts.AllowUserToResizeRows = false;
            dgvCustomerAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomerAccounts.BackgroundColor = SystemColors.Window;
            dgvCustomerAccounts.BorderStyle = BorderStyle.Fixed3D;
            dgvCustomerAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomerAccounts.Dock = DockStyle.Fill;
            dgvCustomerAccounts.Location = new Point(0, 0);
            dgvCustomerAccounts.MultiSelect = false;
            dgvCustomerAccounts.Name = "dgvCustomerAccounts";
            dgvCustomerAccounts.ReadOnly = true;
            dgvCustomerAccounts.RowHeadersVisible = false;
            dgvCustomerAccounts.RowHeadersWidth = 51;
            dgvCustomerAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomerAccounts.Size = new Size(545, 660);
            dgvCustomerAccounts.TabIndex = 0;
            dgvCustomerAccounts.SelectionChanged += dgvCustomerAccounts_SelectionChanged;
            // 
            // panelRight
            // 
            panelRight.Controls.Add(groupAccountStatus);
            panelRight.Controls.Add(groupCredentials);
            panelRight.Controls.Add(panelActions);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(0, 0);
            panelRight.Name = "panelRight";
            panelRight.Padding = new Padding(20);
            panelRight.Size = new Size(642, 660);
            panelRight.TabIndex = 0;
            // 
            // groupAccountStatus
            // 
            groupAccountStatus.Controls.Add(lblAccountState);
            groupAccountStatus.Controls.Add(chkAccountEnabled);
            groupAccountStatus.Font = new Font("Segoe UI Semibold", 10F);
            groupAccountStatus.Location = new Point(20, 20);
            groupAccountStatus.Name = "groupAccountStatus";
            groupAccountStatus.Size = new Size(602, 120);
            groupAccountStatus.TabIndex = 0;
            groupAccountStatus.TabStop = false;
            groupAccountStatus.Text = "Account Status";
            // 
            // lblAccountState
            // 
            lblAccountState.AutoSize = true;
            lblAccountState.Font = new Font("Segoe UI", 9.75F);
            lblAccountState.Location = new Point(20, 40);
            lblAccountState.Name = "lblAccountState";
            lblAccountState.Size = new Size(223, 23);
            lblAccountState.TabIndex = 0;
            lblAccountState.Text = "Login Account: Not Created";
            // 
            // chkAccountEnabled
            // 
            chkAccountEnabled.AutoSize = true;
            chkAccountEnabled.Font = new Font("Segoe UI", 9.75F);
            chkAccountEnabled.Location = new Point(20, 75);
            chkAccountEnabled.Name = "chkAccountEnabled";
            chkAccountEnabled.Size = new Size(161, 27);
            chkAccountEnabled.TabIndex = 1;
            chkAccountEnabled.Text = "Account Enabled";
            // 
            // groupCredentials
            // 
            groupCredentials.Controls.Add(lblUsername);
            groupCredentials.Controls.Add(txtUsername);
            groupCredentials.Controls.Add(lblPassword);
            groupCredentials.Controls.Add(txtPassword);
            groupCredentials.Controls.Add(lblConfirmPassword);
            groupCredentials.Controls.Add(txtConfirmPassword);
            groupCredentials.Font = new Font("Segoe UI Semibold", 10F);
            groupCredentials.Location = new Point(20, 160);
            groupCredentials.Name = "groupCredentials";
            groupCredentials.Size = new Size(602, 280);
            groupCredentials.TabIndex = 1;
            groupCredentials.TabStop = false;
            groupCredentials.Text = "Login Credentials";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(20, 45);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(87, 23);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(20, 70);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(560, 30);
            txtUsername.TabIndex = 0;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(20, 115);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(169, 23);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Temporary Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(20, 140);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(560, 30);
            txtPassword.TabIndex = 1;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Location = new Point(20, 185);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(149, 23);
            lblConfirmPassword.TabIndex = 2;
            lblConfirmPassword.Text = "Confirm Password";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(20, 210);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '●';
            txtConfirmPassword.Size = new Size(560, 30);
            txtConfirmPassword.TabIndex = 2;
            // 
            // panelActions
            // 
            panelActions.Controls.Add(btnCreate);
            panelActions.Controls.Add(btnResetPassword);
            panelActions.Controls.Add(btnDisable);
            panelActions.Controls.Add(btnClose);
            panelActions.Dock = DockStyle.Bottom;
            panelActions.Location = new Point(20, 535);
            panelActions.Name = "panelActions";
            panelActions.Size = new Size(602, 105);
            panelActions.TabIndex = 2;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.FromArgb(46, 204, 113);
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Font = new Font("Segoe UI Semibold", 10F);
            btnCreate.ForeColor = Color.White;
            btnCreate.Location = new Point(20, 25);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(140, 50);
            btnCreate.TabIndex = 0;
            btnCreate.Text = "Create Account";
            btnCreate.UseVisualStyleBackColor = false;
            // 
            // btnResetPassword
            // 
            btnResetPassword.BackColor = Color.FromArgb(52, 152, 219);
            btnResetPassword.FlatStyle = FlatStyle.Flat;
            btnResetPassword.Font = new Font("Segoe UI Semibold", 10F);
            btnResetPassword.ForeColor = Color.White;
            btnResetPassword.Location = new Point(168, 25);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(150, 50);
            btnResetPassword.TabIndex = 1;
            btnResetPassword.Text = "Reset Password";
            btnResetPassword.UseVisualStyleBackColor = false;
            // 
            // btnDisable
            // 
            btnDisable.BackColor = Color.FromArgb(231, 76, 60);
            btnDisable.FlatStyle = FlatStyle.Flat;
            btnDisable.Font = new Font("Segoe UI Semibold", 10F);
            btnDisable.ForeColor = Color.White;
            btnDisable.Location = new Point(325, 25);
            btnDisable.Name = "btnDisable";
            btnDisable.Size = new Size(140, 50);
            btnDisable.TabIndex = 2;
            btnDisable.Text = "Disable";
            btnDisable.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Segoe UI", 10F);
            btnClose.Location = new Point(490, 25);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(90, 50);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            // 
            // CustomerAccountForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1195, 660);
            Controls.Add(splitContainer);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CustomerAccountForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Manage Customer Login Accounts";
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCustomerAccounts).EndInit();
            panelRight.ResumeLayout(false);
            groupAccountStatus.ResumeLayout(false);
            groupAccountStatus.PerformLayout();
            groupCredentials.ResumeLayout(false);
            groupCredentials.PerformLayout();
            panelActions.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dgvCustomerAccounts;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.GroupBox groupAccountStatus;
        private System.Windows.Forms.Label lblAccountState;
        private System.Windows.Forms.CheckBox chkAccountEnabled;
        private System.Windows.Forms.GroupBox groupCredentials;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Button btnDisable;
        private System.Windows.Forms.Button btnClose;
    }
}