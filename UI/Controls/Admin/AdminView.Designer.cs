namespace VRMS.UI.Controls.Admin
{
    partial class AdminUserManagement
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            txtSearch = new TextBox();
            btnRefresh = new Button();
            pnlMain = new Panel();
            splitContainer = new SplitContainer();
            pnlUserList = new Panel();
            dgvUsers = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colUsername = new DataGridViewTextBoxColumn();
            colFullName = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colRole = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            contextMenuActions = new ContextMenuStrip(components);
            enableToolStripMenuItem = new ToolStripMenuItem();
            disableToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            removeToolStripMenuItem = new ToolStripMenuItem();
            pnlUserDetails = new Panel();
            gbUserActions = new GroupBox();
            btnRemoveAccount = new Button();
            btnDisableAccount = new Button();
            btnEnableAccount = new Button();
            gbUserInfo = new GroupBox();
            lblCreatedDate = new Label();
            lblLastLogin = new Label();
            lblStatus = new Label();
            lblRole = new Label();
            lblEmail = new Label();
            lblFullName = new Label();
            lblUserId = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            labelFullName = new Label();
            colLastLogin = new DataGridViewTextBoxColumn();
            colCreatedDate = new DataGridViewTextBoxColumn();
            toolTip = new ToolTip(components);
            pnlHeader.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            pnlUserList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            contextMenuActions.SuspendLayout();
            pnlUserDetails.SuspendLayout();
            gbUserActions.SuspendLayout();
            gbUserInfo.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlHeader.Controls.Add(txtSearch);
            pnlHeader.Controls.Add(btnRefresh);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1371, 66);
            pnlHeader.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.Location = new Point(850, 19);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search users...";
            txtSearch.Size = new Size(320, 27);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.SteelBlue;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(1185, 16);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(114, 31);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(splitContainer);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 66);
            pnlMain.Margin = new Padding(3, 4, 3, 4);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1371, 734);
            pnlMain.TabIndex = 1;
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Margin = new Padding(3, 4, 3, 4);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(pnlUserList);
            splitContainer.Panel1MinSize = 400;
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(pnlUserDetails);
            splitContainer.Panel2MinSize = 350;
            splitContainer.Size = new Size(1371, 734);
            splitContainer.SplitterDistance = 850;
            splitContainer.SplitterWidth = 5;
            splitContainer.TabIndex = 0;
            // 
            // pnlUserList
            // 
            pnlUserList.Controls.Add(dgvUsers);
            pnlUserList.Dock = DockStyle.Fill;
            pnlUserList.Location = new Point(0, 0);
            pnlUserList.Margin = new Padding(3, 4, 3, 4);
            pnlUserList.Name = "pnlUserList";
            pnlUserList.Padding = new Padding(6, 7, 6, 7);
            pnlUserList.Size = new Size(850, 734);
            pnlUserList.TabIndex = 0;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AllowUserToResizeRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.BorderStyle = BorderStyle.None;
            dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(32, 191, 158);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.Padding = new Padding(5, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(32, 191, 158);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvUsers.ColumnHeadersHeight = 50;
            dgvUsers.Columns.AddRange(new DataGridViewColumn[] { colID, colUsername, colFullName, colEmail, colRole, colStatus });
            dgvUsers.ContextMenuStrip = contextMenuActions;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.GridColor = Color.Gainsboro;
            dgvUsers.Location = new Point(6, 7);
            dgvUsers.Margin = new Padding(3, 4, 3, 4);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.Padding = new Padding(5, 0, 0, 0);
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowHeadersWidth = 51;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle6.Padding = new Padding(5, 0, 0, 0);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(240, 245, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(64, 64, 64);
            dgvUsers.RowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvUsers.RowTemplate.Height = 40;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(838, 720);
            dgvUsers.TabIndex = 0;
            dgvUsers.CellClick += dgvUsers_CellClick;
            dgvUsers.CellContentClick += dgvUsers_CellContentClick;
            dgvUsers.SelectionChanged += dgvUsers_SelectionChanged;
            // 
            // colID
            // 
            colID.DataPropertyName = "Id";
            colID.FillWeight = 60F;
            colID.HeaderText = "ID";
            colID.MinimumWidth = 60;
            colID.Name = "colID";
            colID.ReadOnly = true;
            // 
            // colUsername
            // 
            colUsername.DataPropertyName = "Username";
            colUsername.HeaderText = "Username";
            colUsername.MinimumWidth = 100;
            colUsername.Name = "colUsername";
            colUsername.ReadOnly = true;
            // 
            // colFullName
            // 
            colFullName.DataPropertyName = "FullName";
            colFullName.FillWeight = 120F;
            colFullName.HeaderText = "Full Name";
            colFullName.MinimumWidth = 120;
            colFullName.Name = "colFullName";
            colFullName.ReadOnly = true;
            // 
            // colEmail
            // 
            colEmail.DataPropertyName = "Email";
            colEmail.FillWeight = 150F;
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 150;
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // colRole
            // 
            colRole.DataPropertyName = "Role";
            colRole.FillWeight = 80F;
            colRole.HeaderText = "Role";
            colRole.MinimumWidth = 80;
            colRole.Name = "colRole";
            colRole.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.DataPropertyName = "Status";
            colStatus.FillWeight = 80F;
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 80;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // contextMenuActions
            // 
            contextMenuActions.ImageScalingSize = new Size(20, 20);
            contextMenuActions.Items.AddRange(new ToolStripItem[] { enableToolStripMenuItem, disableToolStripMenuItem, editToolStripMenuItem, removeToolStripMenuItem });
            contextMenuActions.Name = "contextMenuActions";
            contextMenuActions.Size = new Size(191, 100);
            // 
            // enableToolStripMenuItem
            // 
            enableToolStripMenuItem.BackColor = Color.FromArgb(40, 167, 69);
            enableToolStripMenuItem.ForeColor = Color.White;
            enableToolStripMenuItem.Name = "enableToolStripMenuItem";
            enableToolStripMenuItem.Size = new Size(190, 24);
            enableToolStripMenuItem.Text = "Enable Account";
            enableToolStripMenuItem.Click += enableToolStripMenuItem_Click;
            // 
            // disableToolStripMenuItem
            // 
            disableToolStripMenuItem.BackColor = Color.FromArgb(255, 193, 7);
            disableToolStripMenuItem.Name = "disableToolStripMenuItem";
            disableToolStripMenuItem.Size = new Size(190, 24);
            disableToolStripMenuItem.Text = "Disable Account";
            disableToolStripMenuItem.Click += disableToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.BackColor = Color.SteelBlue;
            editToolStripMenuItem.ForeColor = Color.White;
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(190, 24);
            editToolStripMenuItem.Text = "Edit User";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // removeToolStripMenuItem
            // 
            removeToolStripMenuItem.BackColor = Color.FromArgb(220, 53, 69);
            removeToolStripMenuItem.ForeColor = Color.White;
            removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            removeToolStripMenuItem.Size = new Size(190, 24);
            removeToolStripMenuItem.Text = "Remove Account";
            removeToolStripMenuItem.Click += removeToolStripMenuItem_Click;
            // 
            // pnlUserDetails
            // 
            pnlUserDetails.BackColor = Color.White;
            pnlUserDetails.Controls.Add(gbUserActions);
            pnlUserDetails.Controls.Add(gbUserInfo);
            pnlUserDetails.Dock = DockStyle.Fill;
            pnlUserDetails.Location = new Point(0, 0);
            pnlUserDetails.Margin = new Padding(3, 4, 3, 4);
            pnlUserDetails.Name = "pnlUserDetails";
            pnlUserDetails.Padding = new Padding(12);
            pnlUserDetails.Size = new Size(516, 734);
            pnlUserDetails.TabIndex = 0;
            // 
            // gbUserActions
            // 
            gbUserActions.Controls.Add(btnRemoveAccount);
            gbUserActions.Controls.Add(btnDisableAccount);
            gbUserActions.Controls.Add(btnEnableAccount);
            gbUserActions.Dock = DockStyle.Bottom;
            gbUserActions.Location = new Point(12, 530);
            gbUserActions.Margin = new Padding(3, 4, 3, 4);
            gbUserActions.Name = "gbUserActions";
            gbUserActions.Padding = new Padding(3, 4, 3, 4);
            gbUserActions.Size = new Size(492, 192);
            gbUserActions.TabIndex = 1;
            gbUserActions.TabStop = false;
            gbUserActions.Text = "User Actions";
            // 
            // btnRemoveAccount
            // 
            btnRemoveAccount.BackColor = Color.FromArgb(220, 53, 69);
            btnRemoveAccount.FlatStyle = FlatStyle.Flat;
            btnRemoveAccount.ForeColor = Color.White;
            btnRemoveAccount.Location = new Point(268, 78);
            btnRemoveAccount.Margin = new Padding(3, 4, 3, 4);
            btnRemoveAccount.Name = "btnRemoveAccount";
            btnRemoveAccount.Size = new Size(218, 45);
            btnRemoveAccount.TabIndex = 3;
            btnRemoveAccount.Text = "Remove Account";
            btnRemoveAccount.UseVisualStyleBackColor = false;
            btnRemoveAccount.Click += btnRemoveAccount_Click;
            // 
            // btnDisableAccount
            // 
            btnDisableAccount.BackColor = Color.FromArgb(255, 193, 7);
            btnDisableAccount.FlatStyle = FlatStyle.Flat;
            btnDisableAccount.ForeColor = Color.Black;
            btnDisableAccount.Location = new Point(29, 107);
            btnDisableAccount.Margin = new Padding(3, 4, 3, 4);
            btnDisableAccount.Name = "btnDisableAccount";
            btnDisableAccount.Size = new Size(218, 45);
            btnDisableAccount.TabIndex = 2;
            btnDisableAccount.Text = "Disable Account";
            btnDisableAccount.UseVisualStyleBackColor = false;
            btnDisableAccount.Click += btnDisableAccount_Click;
            // 
            // btnEnableAccount
            // 
            btnEnableAccount.BackColor = Color.FromArgb(40, 167, 69);
            btnEnableAccount.FlatStyle = FlatStyle.Flat;
            btnEnableAccount.ForeColor = Color.White;
            btnEnableAccount.Location = new Point(29, 43);
            btnEnableAccount.Margin = new Padding(3, 4, 3, 4);
            btnEnableAccount.Name = "btnEnableAccount";
            btnEnableAccount.Size = new Size(218, 45);
            btnEnableAccount.TabIndex = 1;
            btnEnableAccount.Text = "Enable Account";
            btnEnableAccount.UseVisualStyleBackColor = false;
            btnEnableAccount.Click += btnEnableAccount_Click;
            // 
            // gbUserInfo
            // 
            gbUserInfo.Controls.Add(lblCreatedDate);
            gbUserInfo.Controls.Add(lblLastLogin);
            gbUserInfo.Controls.Add(lblStatus);
            gbUserInfo.Controls.Add(lblRole);
            gbUserInfo.Controls.Add(lblEmail);
            gbUserInfo.Controls.Add(lblFullName);
            gbUserInfo.Controls.Add(lblUserId);
            gbUserInfo.Controls.Add(label7);
            gbUserInfo.Controls.Add(label6);
            gbUserInfo.Controls.Add(label5);
            gbUserInfo.Controls.Add(label4);
            gbUserInfo.Controls.Add(label3);
            gbUserInfo.Controls.Add(label2);
            gbUserInfo.Controls.Add(label1);
            gbUserInfo.Controls.Add(labelFullName);
            gbUserInfo.Dock = DockStyle.Top;
            gbUserInfo.Location = new Point(12, 12);
            gbUserInfo.Margin = new Padding(3, 4, 3, 4);
            gbUserInfo.Name = "gbUserInfo";
            gbUserInfo.Padding = new Padding(3, 4, 3, 4);
            gbUserInfo.Size = new Size(492, 500);
            gbUserInfo.TabIndex = 0;
            gbUserInfo.TabStop = false;
            gbUserInfo.Text = "User Information";
            // 
            // lblCreatedDate
            // 
            lblCreatedDate.AutoSize = true;
            lblCreatedDate.Font = new Font("Segoe UI", 10F);
            lblCreatedDate.Location = new Point(170, 440);
            lblCreatedDate.Name = "lblCreatedDate";
            lblCreatedDate.Size = new Size(17, 23);
            lblCreatedDate.TabIndex = 13;
            lblCreatedDate.Text = "-";
            // 
            // lblLastLogin
            // 
            lblLastLogin.AutoSize = true;
            lblLastLogin.Font = new Font("Segoe UI", 10F);
            lblLastLogin.Location = new Point(170, 385);
            lblLastLogin.Name = "lblLastLogin";
            lblLastLogin.Size = new Size(17, 23);
            lblLastLogin.TabIndex = 12;
            lblLastLogin.Text = "-";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatus.Location = new Point(170, 330);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(17, 23);
            lblStatus.TabIndex = 11;
            lblStatus.Text = "-";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 10F);
            lblRole.Location = new Point(170, 275);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(17, 23);
            lblRole.TabIndex = 10;
            lblRole.Text = "-";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F);
            lblEmail.Location = new Point(170, 165);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(17, 23);
            lblEmail.TabIndex = 9;
            lblEmail.Text = "-";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFullName.Location = new Point(170, 110);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(17, 23);
            lblFullName.TabIndex = 8;
            lblFullName.Text = "-";
            // 
            // lblUserId
            // 
            lblUserId.AutoSize = true;
            lblUserId.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUserId.Location = new Point(170, 55);
            lblUserId.Name = "lblUserId";
            lblUserId.Size = new Size(17, 23);
            lblUserId.TabIndex = 7;
            lblUserId.Text = "-";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label7.Location = new Point(13, 440);
            label7.Name = "label7";
            label7.Size = new Size(121, 23);
            label7.TabIndex = 6;
            label7.Text = "Created Date:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.Location = new Point(13, 385);
            label6.Name = "label6";
            label6.Size = new Size(97, 23);
            label6.TabIndex = 5;
            label6.Text = "Last Login:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.Location = new Point(13, 330);
            label5.Name = "label5";
            label5.Size = new Size(65, 23);
            label5.TabIndex = 4;
            label5.Text = "Status:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(13, 275);
            label4.Name = "label4";
            label4.Size = new Size(50, 23);
            label4.TabIndex = 3;
            label4.Text = "Role:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(13, 220);
            label3.Name = "label3";
            label3.Size = new Size(79, 23);
            label3.TabIndex = 2;
            label3.Text = "Phone #:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(13, 165);
            label2.Name = "label2";
            label2.Size = new Size(59, 23);
            label2.TabIndex = 1;
            label2.Text = "Email:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.Location = new Point(13, 55);
            label1.Name = "label1";
            label1.Size = new Size(73, 23);
            label1.TabIndex = 0;
            label1.Text = "User ID:";
            // 
            // labelFullName
            // 
            labelFullName.AutoSize = true;
            labelFullName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelFullName.Location = new Point(13, 110);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new Size(96, 23);
            labelFullName.TabIndex = 8;
            labelFullName.Text = "Full Name:";
            // 
            // colLastLogin
            // 
            colLastLogin.DataPropertyName = "LastLogin";
            colLastLogin.FillWeight = 120F;
            colLastLogin.HeaderText = "Last Login";
            colLastLogin.MinimumWidth = 120;
            colLastLogin.Name = "colLastLogin";
            colLastLogin.ReadOnly = true;
            colLastLogin.Width = 125;
            // 
            // colCreatedDate
            // 
            colCreatedDate.DataPropertyName = "CreatedDate";
            colCreatedDate.FillWeight = 120F;
            colCreatedDate.HeaderText = "Created Date";
            colCreatedDate.MinimumWidth = 120;
            colCreatedDate.Name = "colCreatedDate";
            colCreatedDate.ReadOnly = true;
            colCreatedDate.Width = 125;
            // 
            // AdminUserManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pnlMain);
            Controls.Add(pnlHeader);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AdminUserManagement";
            Size = new Size(1371, 800);
            Load += AdminUserManagement_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlMain.ResumeLayout(false);
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            pnlUserList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            contextMenuActions.ResumeLayout(false);
            pnlUserDetails.ResumeLayout(false);
            gbUserActions.ResumeLayout(false);
            gbUserInfo.ResumeLayout(false);
            gbUserInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private TextBox txtSearch;
        private Button btnRefresh;
        private Panel pnlMain;
        private SplitContainer splitContainer;
        private Panel pnlUserList;
        private DataGridView dgvUsers;
        private Panel pnlUserDetails;
        private ToolTip toolTip;
        private GroupBox gbUserInfo;
        private Label lblCreatedDate;
        private Label lblLastLogin;
        private Label lblStatus;
        private Label lblRole;
        private Label lblEmail;
        private Label lblFullName;
        private Label lblUserId;
        private Label labelFullName;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private GroupBox gbUserActions;
        private Button btnRemoveAccount;
        private Button btnDisableAccount;
        private Button btnEnableAccount;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn colUsername;
        private DataGridViewTextBoxColumn colFullName;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colRole;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colLastLogin;
        private DataGridViewTextBoxColumn colCreatedDate;
        private ContextMenuStrip contextMenuActions;
        private ToolStripMenuItem enableToolStripMenuItem;
        private ToolStripMenuItem disableToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem removeToolStripMenuItem;
    }
}