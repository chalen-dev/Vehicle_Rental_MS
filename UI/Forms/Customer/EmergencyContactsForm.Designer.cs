namespace VRMS.UI.Forms.Customer
{
    partial class EmergencyContactsForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            panelHeader = new Panel();
            lblTitle = new Label();
            panelContent = new Panel();
            splitContainer = new SplitContainer();
            panelContactList = new Panel();
            dgvContacts = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colFullName = new DataGridViewTextBoxColumn();
            colRelationship = new DataGridViewTextBoxColumn();
            colPhoneCount = new DataGridViewTextBoxColumn();
            colActions = new DataGridViewButtonColumn();
            panelListHeader = new Panel();
            lblContactCount = new Label();
            lblCustomerName = new Label();
            panelContactDetails = new Panel();
            panelContactActions = new Panel();
            btnClear = new Button();
            btnDeleteContact = new Button();
            btnUpdateContact = new Button();
            btnSaveContact = new Button();
            panelPhoneNumbers = new Panel();
            dgvPhoneNumbers = new DataGridView();
            colPhoneId = new DataGridViewTextBoxColumn();
            colPhoneType = new DataGridViewComboBoxColumn();
            colPhoneNumber = new DataGridViewTextBoxColumn();
            colPrimary = new DataGridViewCheckBoxColumn();
            colRemovePhone = new DataGridViewButtonColumn();
            btnAddPhone = new Button();
            lblPhoneNumbers = new Label();
            panelContactForm = new Panel();
            txtNotes = new TextBox();
            lblNotes = new Label();
            cmbRelationship = new ComboBox();
            lblRelationship = new Label();
            txtLastName = new TextBox();
            lblLastName = new Label();
            txtFirstName = new TextBox();
            lblFirstName = new Label();
            panelDetailsHeader = new Panel();
            lblDetailsTitle = new Label();
            panelFooter = new Panel();
            btnAddNew = new Button();
            btnClose = new Button();
            panelHeader.SuspendLayout();
            panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            panelContactList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContacts).BeginInit();
            panelListHeader.SuspendLayout();
            panelContactDetails.SuspendLayout();
            panelContactActions.SuspendLayout();
            panelPhoneNumbers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhoneNumbers).BeginInit();
            panelContactForm.SuspendLayout();
            panelDetailsHeader.SuspendLayout();
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
            panelHeader.Size = new Size(1400, 100);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(40, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(390, 54);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Emergency Contacts";
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.White;
            panelContent.Controls.Add(splitContainer);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 100);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(30);
            panelContent.Size = new Size(1400, 722);
            panelContent.TabIndex = 1;
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(30, 30);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(panelContactList);
            splitContainer.Panel1.Controls.Add(panelListHeader);
            splitContainer.Panel1.Padding = new Padding(0, 0, 15, 0);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(panelContactDetails);
            splitContainer.Panel2.Padding = new Padding(15, 0, 0, 0);
            splitContainer.Size = new Size(1340, 662);
            splitContainer.SplitterDistance = 700;
            splitContainer.SplitterWidth = 20;
            splitContainer.TabIndex = 0;
            // 
            // panelContactList
            // 
            panelContactList.Controls.Add(dgvContacts);
            panelContactList.Dock = DockStyle.Fill;
            panelContactList.Location = new Point(0, 90);
            panelContactList.Name = "panelContactList";
            panelContactList.Size = new Size(685, 572);
            panelContactList.TabIndex = 1;
            // 
            // dgvContacts
            // 
            dgvContacts.AllowUserToAddRows = false;
            dgvContacts.AllowUserToDeleteRows = false;
            dgvContacts.AllowUserToResizeRows = false;
            dgvContacts.BackgroundColor = Color.White;
            dgvContacts.BorderStyle = BorderStyle.None;
            dgvContacts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvContacts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 249, 250);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(30, 60, 90);
            dataGridViewCellStyle1.Padding = new Padding(20, 15, 20, 15);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(248, 249, 250);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(30, 60, 90);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvContacts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvContacts.ColumnHeadersHeight = 65;
            dgvContacts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvContacts.Columns.AddRange(new DataGridViewColumn[] { colId, colFullName, colRelationship, colPhoneCount, colActions });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.Padding = new Padding(20, 10, 20, 10);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(240, 245, 250);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(30, 60, 90);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvContacts.DefaultCellStyle = dataGridViewCellStyle2;
            dgvContacts.Dock = DockStyle.Fill;
            dgvContacts.EnableHeadersVisualStyles = false;
            dgvContacts.GridColor = Color.FromArgb(240, 240, 240);
            dgvContacts.Location = new Point(0, 0);
            dgvContacts.MultiSelect = false;
            dgvContacts.Name = "dgvContacts";
            dgvContacts.ReadOnly = true;
            dgvContacts.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvContacts.RowHeadersVisible = false;
            dgvContacts.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle3.Padding = new Padding(20, 12, 20, 12);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(240, 245, 250);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(30, 60, 90);
            dgvContacts.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvContacts.RowTemplate.Height = 60;
            dgvContacts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvContacts.Size = new Size(685, 572);
            dgvContacts.TabIndex = 0;
            // 
            // colId
            // 
            colId.DataPropertyName = "Id";
            colId.HeaderText = "ID";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            colId.Width = 150;
            // 
            // colFullName
            // 
            colFullName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colFullName.DataPropertyName = "FullName";
            colFullName.FillWeight = 40F;
            colFullName.HeaderText = "CONTACT NAME";
            colFullName.MinimumWidth = 300;
            colFullName.Name = "colFullName";
            colFullName.ReadOnly = true;
            colFullName.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colRelationship
            // 
            colRelationship.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colRelationship.DataPropertyName = "Relationship";
            colRelationship.FillWeight = 30F;
            colRelationship.HeaderText = "RELATIONSHIP";
            colRelationship.MinimumWidth = 220;
            colRelationship.Name = "colRelationship";
            colRelationship.ReadOnly = true;
            colRelationship.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colPhoneCount
            // 
            colPhoneCount.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPhoneCount.DataPropertyName = "PhoneCount";
            colPhoneCount.FillWeight = 20F;
            colPhoneCount.HeaderText = "PHONE NUMBERS";
            colPhoneCount.MinimumWidth = 180;
            colPhoneCount.Name = "colPhoneCount";
            colPhoneCount.ReadOnly = true;
            colPhoneCount.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colActions
            // 
            colActions.FillWeight = 10F;
            colActions.HeaderText = "";
            colActions.MinimumWidth = 100;
            colActions.Name = "colActions";
            colActions.ReadOnly = true;
            colActions.Resizable = DataGridViewTriState.True;
            colActions.SortMode = DataGridViewColumnSortMode.Automatic;
            colActions.Text = "Select";
            colActions.UseColumnTextForButtonValue = true;
            colActions.Width = 150;
            // 
            // panelListHeader
            // 
            panelListHeader.BackColor = Color.White;
            panelListHeader.Controls.Add(lblContactCount);
            panelListHeader.Controls.Add(lblCustomerName);
            panelListHeader.Dock = DockStyle.Top;
            panelListHeader.Location = new Point(0, 0);
            panelListHeader.Name = "panelListHeader";
            panelListHeader.Padding = new Padding(0, 0, 15, 0);
            panelListHeader.Size = new Size(685, 90);
            panelListHeader.TabIndex = 0;
            // 
            // lblContactCount
            // 
            lblContactCount.AutoSize = true;
            lblContactCount.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContactCount.ForeColor = Color.FromArgb(108, 122, 137);
            lblContactCount.Location = new Point(40, 50);
            lblContactCount.Name = "lblContactCount";
            lblContactCount.Size = new Size(195, 25);
            lblContactCount.TabIndex = 1;
            lblContactCount.Text = "0 emergency contacts";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustomerName.ForeColor = Color.FromArgb(30, 60, 90);
            lblCustomerName.Location = new Point(40, 15);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(216, 37);
            lblCustomerName.TabIndex = 0;
            lblCustomerName.Text = "Customer Name";
            // 
            // panelContactDetails
            // 
            panelContactDetails.Controls.Add(panelContactActions);
            panelContactDetails.Controls.Add(panelPhoneNumbers);
            panelContactDetails.Controls.Add(panelContactForm);
            panelContactDetails.Controls.Add(panelDetailsHeader);
            panelContactDetails.Dock = DockStyle.Fill;
            panelContactDetails.Location = new Point(15, 0);
            panelContactDetails.Name = "panelContactDetails";
            panelContactDetails.Size = new Size(605, 662);
            panelContactDetails.TabIndex = 0;
            // 
            // panelContactActions
            // 
            panelContactActions.BackColor = Color.White;
            panelContactActions.Controls.Add(btnClear);
            panelContactActions.Controls.Add(btnDeleteContact);
            panelContactActions.Controls.Add(btnUpdateContact);
            panelContactActions.Controls.Add(btnSaveContact);
            panelContactActions.Dock = DockStyle.Bottom;
            panelContactActions.Location = new Point(0, 512);
            panelContactActions.Name = "panelContactActions";
            panelContactActions.Padding = new Padding(20, 15, 20, 15);
            panelContactActions.Size = new Size(605, 150);
            panelContactActions.TabIndex = 3;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(108, 122, 137);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(20, 15);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(120, 50);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // btnDeleteContact
            // 
            btnDeleteContact.BackColor = Color.FromArgb(231, 76, 60);
            btnDeleteContact.FlatAppearance.BorderSize = 0;
            btnDeleteContact.FlatStyle = FlatStyle.Flat;
            btnDeleteContact.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeleteContact.ForeColor = Color.White;
            btnDeleteContact.Location = new Point(150, 15);
            btnDeleteContact.Name = "btnDeleteContact";
            btnDeleteContact.Size = new Size(120, 50);
            btnDeleteContact.TabIndex = 2;
            btnDeleteContact.Text = "Delete";
            btnDeleteContact.UseVisualStyleBackColor = false;
            // 
            // btnUpdateContact
            // 
            btnUpdateContact.BackColor = Color.FromArgb(243, 156, 18);
            btnUpdateContact.FlatAppearance.BorderSize = 0;
            btnUpdateContact.FlatStyle = FlatStyle.Flat;
            btnUpdateContact.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUpdateContact.ForeColor = Color.White;
            btnUpdateContact.Location = new Point(280, 15);
            btnUpdateContact.Name = "btnUpdateContact";
            btnUpdateContact.Size = new Size(140, 50);
            btnUpdateContact.TabIndex = 1;
            btnUpdateContact.Text = "Update";
            btnUpdateContact.UseVisualStyleBackColor = false;
            // 
            // btnSaveContact
            // 
            btnSaveContact.BackColor = Color.FromArgb(46, 204, 113);
            btnSaveContact.FlatAppearance.BorderSize = 0;
            btnSaveContact.FlatStyle = FlatStyle.Flat;
            btnSaveContact.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSaveContact.ForeColor = Color.White;
            btnSaveContact.Location = new Point(430, 15);
            btnSaveContact.Name = "btnSaveContact";
            btnSaveContact.Size = new Size(155, 50);
            btnSaveContact.TabIndex = 0;
            btnSaveContact.Text = "Save New";
            btnSaveContact.UseVisualStyleBackColor = false;
            // 
            // panelPhoneNumbers
            // 
            panelPhoneNumbers.BackColor = Color.White;
            panelPhoneNumbers.Controls.Add(dgvPhoneNumbers);
            panelPhoneNumbers.Controls.Add(btnAddPhone);
            panelPhoneNumbers.Controls.Add(lblPhoneNumbers);
            panelPhoneNumbers.Dock = DockStyle.Top;
            panelPhoneNumbers.Location = new Point(0, 360);
            panelPhoneNumbers.Name = "panelPhoneNumbers";
            panelPhoneNumbers.Padding = new Padding(20, 20, 20, 15);
            panelPhoneNumbers.Size = new Size(605, 280);
            panelPhoneNumbers.TabIndex = 2;
            // 
            // dgvPhoneNumbers
            // 
            dgvPhoneNumbers.AllowUserToAddRows = false;
            dgvPhoneNumbers.AllowUserToDeleteRows = false;
            dgvPhoneNumbers.AllowUserToResizeRows = false;
            dgvPhoneNumbers.BackgroundColor = Color.White;
            dgvPhoneNumbers.BorderStyle = BorderStyle.None;
            dgvPhoneNumbers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPhoneNumbers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(248, 249, 250);
            dataGridViewCellStyle4.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(30, 60, 90);
            dataGridViewCellStyle4.Padding = new Padding(12);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(248, 249, 250);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(30, 60, 90);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvPhoneNumbers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvPhoneNumbers.ColumnHeadersHeight = 55;
            dgvPhoneNumbers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPhoneNumbers.Columns.AddRange(new DataGridViewColumn[] { colPhoneId, colPhoneType, colPhoneNumber, colPrimary, colRemovePhone });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 11F);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle5.Padding = new Padding(12);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(240, 245, 250);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(30, 60, 90);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvPhoneNumbers.DefaultCellStyle = dataGridViewCellStyle5;
            dgvPhoneNumbers.Dock = DockStyle.Fill;
            dgvPhoneNumbers.EnableHeadersVisualStyles = false;
            dgvPhoneNumbers.GridColor = Color.FromArgb(240, 240, 240);
            dgvPhoneNumbers.Location = new Point(20, 70);
            dgvPhoneNumbers.Name = "dgvPhoneNumbers";
            dgvPhoneNumbers.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvPhoneNumbers.RowHeadersVisible = false;
            dgvPhoneNumbers.RowHeadersWidth = 51;
            dataGridViewCellStyle6.Padding = new Padding(12);
            dgvPhoneNumbers.RowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvPhoneNumbers.RowTemplate.Height = 50;
            dgvPhoneNumbers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhoneNumbers.Size = new Size(565, 140);
            dgvPhoneNumbers.TabIndex = 2;
            // 
            // colPhoneId
            // 
            colPhoneId.HeaderText = "ID";
            colPhoneId.MinimumWidth = 6;
            colPhoneId.Name = "colPhoneId";
            colPhoneId.Visible = false;
            colPhoneId.Width = 150;
            // 
            // colPhoneType
            // 
            colPhoneType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPhoneType.FillWeight = 35F;
            colPhoneType.HeaderText = "TYPE";
            colPhoneType.Items.AddRange(new object[] { "Mobile", "Home", "Work", "Other" });
            colPhoneType.MinimumWidth = 150;
            colPhoneType.Name = "colPhoneType";
            // 
            // colPhoneNumber
            // 
            colPhoneNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPhoneNumber.FillWeight = 55F;
            colPhoneNumber.HeaderText = "PHONE NUMBER";
            colPhoneNumber.MinimumWidth = 250;
            colPhoneNumber.Name = "colPhoneNumber";
            // 
            // colPrimary
            // 
            colPrimary.FillWeight = 15F;
            colPrimary.HeaderText = "Primary";
            colPrimary.MinimumWidth = 90;
            colPrimary.Name = "colPrimary";
            colPrimary.Width = 150;
            // 
            // colRemovePhone
            // 
            colRemovePhone.FillWeight = 10F;
            colRemovePhone.HeaderText = "";
            colRemovePhone.MinimumWidth = 80;
            colRemovePhone.Name = "colRemovePhone";
            colRemovePhone.Resizable = DataGridViewTriState.True;
            colRemovePhone.SortMode = DataGridViewColumnSortMode.Automatic;
            colRemovePhone.Text = "X";
            colRemovePhone.UseColumnTextForButtonValue = true;
            colRemovePhone.Width = 150;
            // 
            // btnAddPhone
            // 
            btnAddPhone.BackColor = Color.FromArgb(52, 152, 219);
            btnAddPhone.Dock = DockStyle.Bottom;
            btnAddPhone.FlatAppearance.BorderSize = 0;
            btnAddPhone.FlatStyle = FlatStyle.Flat;
            btnAddPhone.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddPhone.ForeColor = Color.White;
            btnAddPhone.Location = new Point(20, 210);
            btnAddPhone.Name = "btnAddPhone";
            btnAddPhone.Size = new Size(565, 55);
            btnAddPhone.TabIndex = 1;
            btnAddPhone.Text = "➕ Add Phone Number";
            btnAddPhone.UseVisualStyleBackColor = false;
            // 
            // lblPhoneNumbers
            // 
            lblPhoneNumbers.Dock = DockStyle.Top;
            lblPhoneNumbers.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPhoneNumbers.ForeColor = Color.FromArgb(30, 60, 90);
            lblPhoneNumbers.Location = new Point(20, 20);
            lblPhoneNumbers.Name = "lblPhoneNumbers";
            lblPhoneNumbers.Size = new Size(565, 50);
            lblPhoneNumbers.TabIndex = 0;
            lblPhoneNumbers.Text = "Phone Numbers";
            lblPhoneNumbers.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelContactForm
            // 
            panelContactForm.BackColor = Color.White;
            panelContactForm.Controls.Add(txtNotes);
            panelContactForm.Controls.Add(lblNotes);
            panelContactForm.Controls.Add(cmbRelationship);
            panelContactForm.Controls.Add(lblRelationship);
            panelContactForm.Controls.Add(txtLastName);
            panelContactForm.Controls.Add(lblLastName);
            panelContactForm.Controls.Add(txtFirstName);
            panelContactForm.Controls.Add(lblFirstName);
            panelContactForm.Dock = DockStyle.Top;
            panelContactForm.Location = new Point(0, 60);
            panelContactForm.Name = "panelContactForm";
            panelContactForm.Padding = new Padding(20);
            panelContactForm.Size = new Size(605, 300);
            panelContactForm.TabIndex = 1;
            // 
            // txtNotes
            // 
            txtNotes.BorderStyle = BorderStyle.FixedSingle;
            txtNotes.Dock = DockStyle.Top;
            txtNotes.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNotes.Location = new Point(20, 217);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.PlaceholderText = "Additional information (optional)";
            txtNotes.Size = new Size(565, 45);
            txtNotes.TabIndex = 7;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Dock = DockStyle.Top;
            lblNotes.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNotes.ForeColor = Color.FromArgb(64, 64, 64);
            lblNotes.Location = new Point(20, 192);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(65, 25);
            lblNotes.TabIndex = 6;
            lblNotes.Text = "Notes:";
            // 
            // cmbRelationship
            // 
            cmbRelationship.Dock = DockStyle.Top;
            cmbRelationship.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRelationship.FlatStyle = FlatStyle.Flat;
            cmbRelationship.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbRelationship.FormattingEnabled = true;
            cmbRelationship.Items.AddRange(new object[] { "Spouse", "Parent", "Child", "Sibling", "Friend", "Colleague", "Other" });
            cmbRelationship.Location = new Point(20, 159);
            cmbRelationship.Name = "cmbRelationship";
            cmbRelationship.Size = new Size(565, 33);
            cmbRelationship.TabIndex = 5;
            // 
            // lblRelationship
            // 
            lblRelationship.AutoSize = true;
            lblRelationship.Dock = DockStyle.Top;
            lblRelationship.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRelationship.ForeColor = Color.FromArgb(64, 64, 64);
            lblRelationship.Location = new Point(20, 134);
            lblRelationship.Name = "lblRelationship";
            lblRelationship.Size = new Size(119, 25);
            lblRelationship.TabIndex = 4;
            lblRelationship.Text = "Relationship:";
            // 
            // txtLastName
            // 
            txtLastName.BorderStyle = BorderStyle.FixedSingle;
            txtLastName.Dock = DockStyle.Top;
            txtLastName.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLastName.Location = new Point(20, 102);
            txtLastName.Name = "txtLastName";
            txtLastName.PlaceholderText = "Last name";
            txtLastName.Size = new Size(565, 32);
            txtLastName.TabIndex = 3;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Dock = DockStyle.Top;
            lblLastName.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLastName.ForeColor = Color.FromArgb(64, 64, 64);
            lblLastName.Location = new Point(20, 77);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(104, 25);
            lblLastName.TabIndex = 2;
            lblLastName.Text = "Last Name:";
            // 
            // txtFirstName
            // 
            txtFirstName.BorderStyle = BorderStyle.FixedSingle;
            txtFirstName.Dock = DockStyle.Top;
            txtFirstName.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFirstName.Location = new Point(20, 45);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.PlaceholderText = "First name";
            txtFirstName.Size = new Size(565, 32);
            txtFirstName.TabIndex = 1;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Dock = DockStyle.Top;
            lblFirstName.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFirstName.ForeColor = Color.FromArgb(64, 64, 64);
            lblFirstName.Location = new Point(20, 20);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(106, 25);
            lblFirstName.TabIndex = 0;
            lblFirstName.Text = "First Name:";
            // 
            // panelDetailsHeader
            // 
            panelDetailsHeader.BackColor = Color.FromArgb(248, 249, 250);
            panelDetailsHeader.Controls.Add(lblDetailsTitle);
            panelDetailsHeader.Dock = DockStyle.Top;
            panelDetailsHeader.Location = new Point(0, 0);
            panelDetailsHeader.Name = "panelDetailsHeader";
            panelDetailsHeader.Padding = new Padding(20, 15, 20, 15);
            panelDetailsHeader.Size = new Size(605, 60);
            panelDetailsHeader.TabIndex = 0;
            // 
            // lblDetailsTitle
            // 
            lblDetailsTitle.AutoSize = true;
            lblDetailsTitle.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDetailsTitle.ForeColor = Color.FromArgb(30, 60, 90);
            lblDetailsTitle.Location = new Point(20, 15);
            lblDetailsTitle.Name = "lblDetailsTitle";
            lblDetailsTitle.Size = new Size(189, 35);
            lblDetailsTitle.TabIndex = 0;
            lblDetailsTitle.Text = "Contact Details";
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.FromArgb(248, 249, 250);
            panelFooter.Controls.Add(btnAddNew);
            panelFooter.Controls.Add(btnClose);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(0, 822);
            panelFooter.Name = "panelFooter";
            panelFooter.Padding = new Padding(30, 20, 30, 20);
            panelFooter.Size = new Size(1400, 149);
            panelFooter.TabIndex = 2;
            // 
            // btnAddNew
            // 
            btnAddNew.BackColor = Color.FromArgb(46, 204, 113);
            btnAddNew.FlatAppearance.BorderSize = 0;
            btnAddNew.FlatStyle = FlatStyle.Flat;
            btnAddNew.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddNew.ForeColor = Color.White;
            btnAddNew.Location = new Point(30, 20);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.Size = new Size(200, 60);
            btnAddNew.TabIndex = 0;
            btnAddNew.Text = "➕ New Contact";
            btnAddNew.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(108, 122, 137);
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1230, 20);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(140, 60);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // EmergencyContactsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(1400, 971);
            Controls.Add(panelContent);
            Controls.Add(panelFooter);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(1418, 1018);
            Name = "EmergencyContactsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Emergency Contacts - VRMS";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelContent.ResumeLayout(false);
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            panelContactList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvContacts).EndInit();
            panelListHeader.ResumeLayout(false);
            panelListHeader.PerformLayout();
            panelContactDetails.ResumeLayout(false);
            panelContactActions.ResumeLayout(false);
            panelPhoneNumbers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPhoneNumbers).EndInit();
            panelContactForm.ResumeLayout(false);
            panelContactForm.PerformLayout();
            panelDetailsHeader.ResumeLayout(false);
            panelDetailsHeader.PerformLayout();
            panelFooter.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel panelContactList;
        private System.Windows.Forms.DataGridView dgvContacts;
        private System.Windows.Forms.Panel panelListHeader;
        private System.Windows.Forms.Label lblContactCount;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Panel panelContactDetails;
        private System.Windows.Forms.Panel panelContactActions;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDeleteContact;
        private System.Windows.Forms.Button btnUpdateContact;
        private System.Windows.Forms.Button btnSaveContact;
        private System.Windows.Forms.Panel panelPhoneNumbers;
        private System.Windows.Forms.DataGridView dgvPhoneNumbers;
        private System.Windows.Forms.Button btnAddPhone;
        private System.Windows.Forms.Label lblPhoneNumbers;
        private System.Windows.Forms.Panel panelContactForm;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.ComboBox cmbRelationship;
        private System.Windows.Forms.Label lblRelationship;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Panel panelDetailsHeader;
        private System.Windows.Forms.Label lblDetailsTitle;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRelationship;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhoneCount;
        private System.Windows.Forms.DataGridViewButtonColumn colActions;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhoneId;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPhoneType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhoneNumber;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colPrimary;
        private System.Windows.Forms.DataGridViewButtonColumn colRemovePhone;
    }
}