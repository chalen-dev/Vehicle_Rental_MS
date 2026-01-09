namespace VRMS.Controls
{
    partial class CustomersView
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            splitContainer1 = new SplitContainer();
            dgvCustomers = new DataGridView();
            panel1 = new Panel();
            txtSearch = new TextBox();
            panel2 = new Panel();
            btnSave = new Button();
            btnManageAccount = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label13 = new Label();
            lblAgeCheck = new Label();
            dtpDOB = new DateTimePicker();
            btnCamera = new Button();
            btnUploadPhoto = new Button();
            label12 = new Label();
            txtLastName = new TextBox();
            groupBox1 = new GroupBox();
            label7 = new Label();
            label6 = new Label();
            txtEmergencyPhone = new TextBox();
            txtEmergencyName = new TextBox();
            txtPhone = new TextBox();
            label5 = new Label();
            txtEmail = new TextBox();
            label4 = new Label();
            txtAddress = new TextBox();
            label3 = new Label();
            txtFirstName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            picCustomerPhoto = new PictureBox();
            tabPage2 = new TabPage();
            groupBox3 = new GroupBox();
            checkBox1 = new CheckBox();
            button1 = new Button();
            btnCaptureLicense = new Button();
            groupBox2 = new GroupBox();
            label11 = new Label();
            txtLicenseNum = new TextBox();
            label10 = new Label();
            txtLicenseState = new TextBox();
            label9 = new Label();
            label8 = new Label();
            dtpExpiryDate = new DateTimePicker();
            dtpIssueDate = new DateTimePicker();
            tabPage3 = new TabPage();
            dgvHistory = new DataGridView();
            groupBox5 = new GroupBox();
            lblDamageHistory = new Label();
            lblTotalSpent = new Label();
            lblTotalRentals = new Label();
            groupBox4 = new GroupBox();
            chkBlacklist = new CheckBox();
            chkLoyalty = new CheckBox();
            cbCustomerType = new ComboBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCustomerPhoto).BeginInit();
            tabPage2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(4, 5, 4, 5);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvCustomers);
            splitContainer1.Panel1.Controls.Add(panel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel2);
            splitContainer1.Panel2.Controls.Add(tabControl1);
            splitContainer1.Size = new Size(1333, 1078);
            splitContainer1.SplitterDistance = 400; // Reduced from 450 for better laptop display
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 0;
            // 
            // dgvCustomers
            // 
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToResizeRows = false;
            dgvCustomers.BackgroundColor = Color.White;
            dgvCustomers.BorderStyle = BorderStyle.None;
            dgvCustomers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCustomers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(26, 188, 156);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCustomers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCustomers.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(236, 240, 241);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvCustomers.DefaultCellStyle = dataGridViewCellStyle2;
            dgvCustomers.Dock = DockStyle.Fill;
            dgvCustomers.EnableHeadersVisualStyles = false;
            dgvCustomers.GridColor = Color.WhiteSmoke;
            dgvCustomers.Location = new Point(0, 92);
            dgvCustomers.Margin = new Padding(4, 5, 4, 5);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.RowHeadersVisible = false;
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.RowTemplate.Height = 35;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.Size = new Size(400, 986);
            dgvCustomers.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(txtSearch);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 92);
            panel1.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(20, 28);
            txtSearch.Margin = new Padding(4, 5, 4, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(355, 30);
            txtSearch.TabIndex = 0;
            txtSearch.Text = "Search Customer...";
            // 
            // panel2
            // 
            panel2.BackColor = Color.WhiteSmoke;
            panel2.Controls.Add(btnSave);
            panel2.Controls.Add(btnManageAccount);
            panel2.Controls.Add(btnDelete);
            panel2.Controls.Add(btnClear);
            panel2.Dock = DockStyle.Bottom; // Changed to DockStyle.Bottom
            panel2.Location = new Point(0, 907);
            panel2.Margin = new Padding(13, 15, 13, 15);
            panel2.Name = "panel2";
            panel2.Size = new Size(928, 171); // Adjusted size
            panel2.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(20, 38);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(180, 60);
            btnSave.TabIndex = 0;
            btnSave.Text = "💾 Save Changes";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnManageAccount
            // 
            btnManageAccount.BackColor = Color.FromArgb(52, 73, 94);
            btnManageAccount.FlatAppearance.BorderSize = 0;
            btnManageAccount.FlatStyle = FlatStyle.Flat;
            btnManageAccount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnManageAccount.ForeColor = Color.White;
            btnManageAccount.Location = new Point(235, 38);
            btnManageAccount.Margin = new Padding(3, 4, 3, 4);
            btnManageAccount.Name = "btnManageAccount";
            btnManageAccount.Size = new Size(180, 60);
            btnManageAccount.TabIndex = 3;
            btnManageAccount.Text = "🔐 Manage Account";
            btnManageAccount.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(451, 38);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(180, 60);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "🗑️ Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClear.BackColor = Color.FromArgb(149, 165, 166);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(668, 38); // Adjusted position
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(180, 60);
            btnClear.TabIndex = 2;
            btnClear.Text = "\U0001f9f9 Clear / New";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Font = new Font("Segoe UI", 10F);
            tabControl1.ItemSize = new Size(0, 45); // Changed to 0 width for auto-sizing
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(4, 5, 4, 5);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(928, 894); // Adjusted size
            tabControl1.SizeMode = TabSizeMode.Normal; // Changed from Fixed to Normal
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.AutoScroll = true; // Added for scrolling
            tabPage1.Controls.Add(label13);
            tabPage1.Controls.Add(lblAgeCheck);
            tabPage1.Controls.Add(dtpDOB);
            tabPage1.Controls.Add(btnCamera);
            tabPage1.Controls.Add(btnUploadPhoto);
            tabPage1.Controls.Add(label12);
            tabPage1.Controls.Add(txtLastName);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Controls.Add(txtPhone);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(txtEmail);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(txtAddress);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(txtFirstName);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(picCustomerPhoto);
            tabPage1.Location = new Point(4, 49);
            tabPage1.Margin = new Padding(3, 4, 3, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(10, 12, 10, 12);
            tabPage1.Size = new Size(920, 841); // Adjusted size
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Personal Profile";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label13.Location = new Point(29, 339);
            label13.Name = "label13";
            label13.Size = new Size(108, 23);
            label13.TabIndex = 17;
            label13.Text = "Date of Birth";
            // 
            // lblAgeCheck
            // 
            lblAgeCheck.AutoSize = true;
            lblAgeCheck.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblAgeCheck.ForeColor = Color.DimGray;
            lblAgeCheck.Location = new Point(350, 369);
            lblAgeCheck.Name = "lblAgeCheck";
            lblAgeCheck.Size = new Size(49, 23);
            lblAgeCheck.TabIndex = 16;
            lblAgeCheck.Text = "Age: ";
            // 
            // dtpDOB
            // 
            dtpDOB.Font = new Font("Segoe UI", 10F);
            dtpDOB.Location = new Point(30, 370);
            dtpDOB.Margin = new Padding(3, 4, 3, 4);
            dtpDOB.Name = "dtpDOB";
            dtpDOB.Size = new Size(291, 30);
            dtpDOB.TabIndex = 15;
            // 
            // btnCamera
            // 
            btnCamera.FlatStyle = FlatStyle.Flat;
            btnCamera.Location = new Point(261, 219);
            btnCamera.Margin = new Padding(3, 4, 3, 4);
            btnCamera.Name = "btnCamera";
            btnCamera.Size = new Size(100, 44);
            btnCamera.TabIndex = 14;
            btnCamera.Text = "📷 Camera";
            btnCamera.UseVisualStyleBackColor = true;
            // 
            // btnUploadPhoto
            // 
            btnUploadPhoto.BackColor = Color.FromArgb(52, 152, 219);
            btnUploadPhoto.FlatStyle = FlatStyle.Flat;
            btnUploadPhoto.ForeColor = SystemColors.ButtonHighlight;
            btnUploadPhoto.Location = new Point(261, 168);
            btnUploadPhoto.Margin = new Padding(3, 4, 3, 4);
            btnUploadPhoto.Name = "btnUploadPhoto";
            btnUploadPhoto.Size = new Size(100, 44);
            btnUploadPhoto.TabIndex = 13;
            btnUploadPhoto.Text = "📂 Upload";
            btnUploadPhoto.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label12.Location = new Point(393, 268);
            label12.Name = "label12";
            label12.Size = new Size(84, 20);
            label12.TabIndex = 12;
            label12.Text = "Last Name:";
            // 
            // txtLastName
            // 
            txtLastName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtLastName.Font = new Font("Segoe UI", 10F);
            txtLastName.Location = new Point(399, 292);
            txtLastName.Margin = new Padding(3, 4, 3, 4);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(480, 30); // Adjusted size
            txtLastName.TabIndex = 11;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtEmergencyPhone);
            groupBox1.Controls.Add(txtEmergencyName);
            groupBox1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            groupBox1.Location = new Point(20, 645);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(860, 122); // Adjusted size
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Emergency Contact";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label7.Location = new Point(381, 31);
            label7.Name = "label7";
            label7.Size = new Size(57, 20);
            label7.TabIndex = 5;
            label7.Text = "Phone:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label6.Location = new Point(29, 31);
            label6.Name = "label6";
            label6.Size = new Size(54, 20);
            label6.TabIndex = 4;
            label6.Text = "Name:";
            // 
            // txtEmergencyPhone
            // 
            txtEmergencyPhone.Font = new Font("Segoe UI", 10F);
            txtEmergencyPhone.Location = new Point(385, 61);
            txtEmergencyPhone.Margin = new Padding(3, 4, 3, 4);
            txtEmergencyPhone.Name = "txtEmergencyPhone";
            txtEmergencyPhone.Size = new Size(291, 30);
            txtEmergencyPhone.TabIndex = 1;
            // 
            // txtEmergencyName
            // 
            txtEmergencyName.Font = new Font("Segoe UI", 10F);
            txtEmergencyName.Location = new Point(33, 61);
            txtEmergencyName.Margin = new Padding(3, 4, 3, 4);
            txtEmergencyName.Name = "txtEmergencyName";
            txtEmergencyName.Size = new Size(291, 30);
            txtEmergencyName.TabIndex = 0;
            // 
            // txtPhone
            // 
            txtPhone.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(24, 597);
            txtPhone.Margin = new Padding(3, 4, 3, 4);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(855, 30); // Adjusted size
            txtPhone.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label5.Location = new Point(23, 573);
            label5.Name = "label5";
            label5.Size = new Size(119, 20);
            label5.TabIndex = 8;
            label5.Text = "Phone Number:";
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(24, 537);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(855, 30); // Adjusted size
            txtEmail.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label4.Location = new Point(23, 513);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 6;
            label4.Text = "Email:";
            // 
            // txtAddress
            // 
            txtAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.Location = new Point(27, 435);
            txtAddress.Margin = new Padding(3, 4, 3, 4);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(852, 70); // Adjusted size
            txtAddress.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label3.Location = new Point(23, 411);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 4;
            label3.Text = "Address:";
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 10F);
            txtFirstName.Location = new Point(27, 292);
            txtFirstName.Margin = new Padding(3, 4, 3, 4);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(337, 30);
            txtFirstName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label2.Location = new Point(27, 268);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 2;
            label2.Text = "First Name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(27, 22);
            label1.Name = "label1";
            label1.Size = new Size(135, 23);
            label1.TabIndex = 1;
            label1.Text = "Customer Photo";
            // 
            // picCustomerPhoto
            // 
            picCustomerPhoto.BackColor = Color.WhiteSmoke;
            picCustomerPhoto.BorderStyle = BorderStyle.FixedSingle;
            picCustomerPhoto.Location = new Point(27, 56);
            picCustomerPhoto.Margin = new Padding(3, 4, 3, 4);
            picCustomerPhoto.Name = "picCustomerPhoto";
            picCustomerPhoto.Size = new Size(226, 204);
            picCustomerPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            picCustomerPhoto.TabIndex = 0;
            picCustomerPhoto.TabStop = false;
            // 
            // tabPage2
            // 
            tabPage2.AutoScroll = true; // Added for scrolling
            tabPage2.Controls.Add(groupBox3);
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Location = new Point(4, 49);
            tabPage2.Margin = new Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(10, 12, 10, 12);
            tabPage2.Size = new Size(920, 841); // Adjusted size
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Driver's License & Verification";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(checkBox1);
            groupBox3.Controls.Add(button1);
            groupBox3.Controls.Add(btnCaptureLicense);
            groupBox3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            groupBox3.Location = new Point(27, 349);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(860, 249); // Adjusted size
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "Verification Actions";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 9F);
            checkBox1.Location = new Point(44, 180);
            checkBox1.Margin = new Padding(3, 4, 3, 4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(174, 24);
            checkBox1.TabIndex = 2;
            checkBox1.Text = "International License?";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F);
            button1.Location = new Point(44, 120);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(268, 49);
            button1.TabIndex = 1;
            button1.Text = "🛡️ Check Driving Record";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnCaptureLicense
            // 
            btnCaptureLicense.Font = new Font("Segoe UI", 9F);
            btnCaptureLicense.Location = new Point(44, 54);
            btnCaptureLicense.Margin = new Padding(3, 4, 3, 4);
            btnCaptureLicense.Name = "btnCaptureLicense";
            btnCaptureLicense.Size = new Size(268, 52);
            btnCaptureLicense.TabIndex = 0;
            btnCaptureLicense.Text = "📷 Capture License Photo";
            btnCaptureLicense.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(txtLicenseNum);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(txtLicenseState);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(dtpExpiryDate);
            groupBox2.Controls.Add(dtpIssueDate);
            groupBox2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            groupBox2.Location = new Point(27, 31);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(860, 298); // Adjusted size
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "License Details";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label11.Location = new Point(31, 49);
            label11.Name = "label11";
            label11.Size = new Size(124, 20);
            label11.TabIndex = 7;
            label11.Text = "License Number:";
            // 
            // txtLicenseNum
            // 
            txtLicenseNum.Font = new Font("Segoe UI", 10F);
            txtLicenseNum.Location = new Point(44, 80);
            txtLicenseNum.Margin = new Padding(3, 4, 3, 4);
            txtLicenseNum.Name = "txtLicenseNum";
            txtLicenseNum.Size = new Size(267, 30);
            txtLicenseNum.TabIndex = 6;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label10.Location = new Point(31, 195);
            label10.Name = "label10";
            label10.Size = new Size(109, 20);
            label10.TabIndex = 5;
            label10.Text = "State/Country:";
            // 
            // txtLicenseState
            // 
            txtLicenseState.Font = new Font("Segoe UI", 10F);
            txtLicenseState.Location = new Point(44, 225);
            txtLicenseState.Margin = new Padding(3, 4, 3, 4);
            txtLicenseState.Name = "txtLicenseState";
            txtLicenseState.Size = new Size(267, 30);
            txtLicenseState.TabIndex = 4;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label9.Location = new Point(332, 122);
            label9.Name = "label9";
            label9.Size = new Size(93, 20);
            label9.TabIndex = 3;
            label9.Text = "Expiry Date:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label8.Location = new Point(27, 122);
            label8.Name = "label8";
            label8.Size = new Size(82, 20);
            label8.TabIndex = 2;
            label8.Text = "Issue Date:";
            // 
            // dtpExpiryDate
            // 
            dtpExpiryDate.Font = new Font("Segoe UI", 10F);
            dtpExpiryDate.Location = new Point(351, 152);
            dtpExpiryDate.Margin = new Padding(3, 4, 3, 4);
            dtpExpiryDate.Name = "dtpExpiryDate";
            dtpExpiryDate.Size = new Size(264, 30);
            dtpExpiryDate.TabIndex = 1;
            // 
            // dtpIssueDate
            // 
            dtpIssueDate.Font = new Font("Segoe UI", 10F);
            dtpIssueDate.Location = new Point(44, 152);
            dtpIssueDate.Margin = new Padding(3, 4, 3, 4);
            dtpIssueDate.Name = "dtpIssueDate";
            dtpIssueDate.Size = new Size(267, 30);
            dtpIssueDate.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.AutoScroll = true; // Added for scrolling
            tabPage3.Controls.Add(dgvHistory);
            tabPage3.Controls.Add(groupBox5);
            tabPage3.Controls.Add(groupBox4);
            tabPage3.Location = new Point(4, 49);
            tabPage3.Margin = new Padding(3, 4, 3, 4);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(10, 12, 10, 12);
            tabPage3.Size = new Size(920, 841); // Adjusted size
            tabPage3.TabIndex = 2;
            tabPage3.Text = "History & Status";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvHistory
            // 
            dgvHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHistory.BackgroundColor = Color.White;
            dgvHistory.BorderStyle = BorderStyle.None;
            dgvHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(26, 188, 156);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvHistory.ColumnHeadersHeight = 35;
            dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(236, 240, 241);
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvHistory.DefaultCellStyle = dataGridViewCellStyle4;
            dgvHistory.EnableHeadersVisualStyles = false;
            dgvHistory.Location = new Point(28, 429);
            dgvHistory.Margin = new Padding(3, 4, 3, 4);
            dgvHistory.Name = "dgvHistory";
            dgvHistory.ReadOnly = true;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.RowHeadersWidth = 51;
            dgvHistory.RowTemplate.Height = 30;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.Size = new Size(860, 388); // Adjusted size
            dgvHistory.TabIndex = 2;
            // 
            // groupBox5
            // 
            groupBox5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox5.Controls.Add(lblDamageHistory);
            groupBox5.Controls.Add(lblTotalSpent);
            groupBox5.Controls.Add(lblTotalRentals);
            groupBox5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            groupBox5.Location = new Point(27, 251);
            groupBox5.Margin = new Padding(3, 4, 3, 4);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(3, 4, 3, 4);
            groupBox5.Size = new Size(860, 169); // Adjusted size
            groupBox5.TabIndex = 1;
            groupBox5.TabStop = false;
            groupBox5.Text = "Rental History";
            // 
            // lblDamageHistory
            // 
            lblDamageHistory.AutoSize = true;
            lblDamageHistory.ForeColor = Color.FromArgb(192, 57, 43);
            lblDamageHistory.Location = new Point(32, 132);
            lblDamageHistory.Name = "lblDamageHistory";
            lblDamageHistory.Size = new Size(166, 23);
            lblDamageHistory.TabIndex = 2;
            lblDamageHistory.Text = "Damage Incidents: 0";
            // 
            // lblTotalSpent
            // 
            lblTotalSpent.AutoSize = true;
            lblTotalSpent.Location = new Point(32, 86);
            lblTotalSpent.Name = "lblTotalSpent";
            lblTotalSpent.Size = new Size(150, 23);
            lblTotalSpent.TabIndex = 1;
            lblTotalSpent.Text = "Total Spent:  ₱0.00";
            // 
            // lblTotalRentals
            // 
            lblTotalRentals.AutoSize = true;
            lblTotalRentals.Location = new Point(32, 39);
            lblTotalRentals.Name = "lblTotalRentals";
            lblTotalRentals.Size = new Size(104, 23);
            lblTotalRentals.TabIndex = 0;
            lblTotalRentals.Text = "Total Trips: 0";
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox4.Controls.Add(chkBlacklist);
            groupBox4.Controls.Add(chkLoyalty);
            groupBox4.Controls.Add(cbCustomerType);
            groupBox4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            groupBox4.Location = new Point(27, 31);
            groupBox4.Margin = new Padding(3, 4, 3, 4);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 4, 3, 4);
            groupBox4.Size = new Size(860, 211); // Adjusted size
            groupBox4.TabIndex = 0;
            groupBox4.TabStop = false;
            groupBox4.Text = "Classification";
            // 
            // chkBlacklist
            // 
            chkBlacklist.AutoSize = true;
            chkBlacklist.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            chkBlacklist.ForeColor = Color.Red;
            chkBlacklist.Location = new Point(32, 161);
            chkBlacklist.Margin = new Padding(3, 4, 3, 4);
            chkBlacklist.Name = "chkBlacklist";
            chkBlacklist.Size = new Size(148, 27);
            chkBlacklist.TabIndex = 2;
            chkBlacklist.Text = "⚠️ Blacklisted";
            chkBlacklist.UseVisualStyleBackColor = true;
            // 
            // chkLoyalty
            // 
            chkLoyalty.AutoSize = true;
            chkLoyalty.Location = new Point(32, 106);
            chkLoyalty.Margin = new Padding(3, 4, 3, 4);
            chkLoyalty.Name = "chkLoyalty";
            chkLoyalty.Size = new Size(228, 27);
            chkLoyalty.TabIndex = 1;
            chkLoyalty.Text = "Frequent Renter Program";
            chkLoyalty.UseVisualStyleBackColor = true;
            // 
            // cbCustomerType
            // 
            cbCustomerType.Font = new Font("Segoe UI", 10F);
            cbCustomerType.FormattingEnabled = true;
            cbCustomerType.Location = new Point(27, 39);
            cbCustomerType.Margin = new Padding(3, 4, 3, 4);
            cbCustomerType.Name = "cbCustomerType";
            cbCustomerType.Size = new Size(219, 31);
            cbCustomerType.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // CustomersView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CustomersView";
            Size = new Size(1333, 1078);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picCustomerPhoto).EndInit();
            tabPage2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox picCustomerPhoto;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmergencyPhone;
        private System.Windows.Forms.TextBox txtEmergencyName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpExpiryDate;
        private System.Windows.Forms.DateTimePicker dtpIssueDate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCaptureLicense;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtLicenseState;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkLoyalty;
        private System.Windows.Forms.ComboBox cbCustomerType;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblDamageHistory;
        private System.Windows.Forms.Label lblTotalSpent;
        private System.Windows.Forms.Label lblTotalRentals;
        private System.Windows.Forms.CheckBox chkBlacklist;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnManageAccount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtLicenseNum;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Button btnCamera;
        private System.Windows.Forms.Button btnUploadPhoto;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblAgeCheck;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.DataGridView dgvHistory;
    }
}