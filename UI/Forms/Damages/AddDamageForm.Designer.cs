namespace VRMS.Forms
{
    partial class AddDamageForm
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
            pnlHeader = new Panel();
            lblHeaderSubtitle = new Label();
            lblHeaderTitle = new Label();
            pnlContent = new Panel();
            pnlRightColumn = new Panel();
            gbPhotoEvidence = new GroupBox();
            flpEvidence = new FlowLayoutPanel();
            pnlPhotoControls = new Panel();
            btnAddPhoto = new Button();
            lblNoPhotos = new Label();
            gbCostEstimation = new GroupBox();
            numEstimatedCost = new NumericUpDown();
            lblCostHint = new Label();
            lblEstimatedCost = new Label();
            pnlLeftColumn = new Panel();
            gbDamageDetails = new GroupBox();
            pnlSeverity = new Panel();
            rbSeverityCritical = new RadioButton();
            rbSeverityMajor = new RadioButton();
            rbSeverityMinor = new RadioButton();
            lblSeverity = new Label();
            txtDescription = new TextBox();
            lblDescription = new Label();
            cbDamageType = new ComboBox();
            lblDamageType = new Label();
            gbVehicleInfo = new GroupBox();
            txtPlateNumber = new TextBox();
            lblPlateNumber = new Label();
            txtRentalNumber = new TextBox();
            lblRentalNumber = new Label();
            txtVehicleModel = new TextBox();
            lblVehicleModel = new Label();
            pnlActionBar = new Panel();
            btnSave = new Button();
            btnCancel = new Button();
            pnlHeader.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlRightColumn.SuspendLayout();
            gbPhotoEvidence.SuspendLayout();
            pnlPhotoControls.SuspendLayout();
            gbCostEstimation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numEstimatedCost).BeginInit();
            pnlLeftColumn.SuspendLayout();
            gbDamageDetails.SuspendLayout();
            pnlSeverity.SuspendLayout();
            gbVehicleInfo.SuspendLayout();
            pnlActionBar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(52, 73, 94);
            pnlHeader.Controls.Add(lblHeaderSubtitle);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(900, 100);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHeaderSubtitle.ForeColor = Color.Silver;
            lblHeaderSubtitle.Location = new Point(25, 56);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(296, 20);
            lblHeaderSubtitle.TabIndex = 1;
            lblHeaderSubtitle.Text = "Toyota Vios • Plate GAS-123 • Rental #1042";
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(20, 19);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(324, 38);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Report Vehicle Damage";
            // 
            // pnlContent
            // 
            pnlContent.AutoScroll = true;
            pnlContent.BackColor = Color.WhiteSmoke;
            pnlContent.Controls.Add(pnlRightColumn);
            pnlContent.Controls.Add(pnlLeftColumn);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 100);
            pnlContent.Margin = new Padding(3, 4, 3, 4);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(20, 25, 20, 25);
            pnlContent.Size = new Size(900, 650);
            pnlContent.TabIndex = 1;
            // 
            // pnlRightColumn
            // 
            pnlRightColumn.Controls.Add(gbPhotoEvidence);
            pnlRightColumn.Controls.Add(gbCostEstimation);
            pnlRightColumn.Dock = DockStyle.Fill;
            pnlRightColumn.Location = new Point(460, 25);
            pnlRightColumn.Margin = new Padding(3, 4, 3, 4);
            pnlRightColumn.Name = "pnlRightColumn";
            pnlRightColumn.Size = new Size(420, 600);
            pnlRightColumn.TabIndex = 3;
            // 
            // gbPhotoEvidence
            // 
            gbPhotoEvidence.BackColor = Color.White;
            gbPhotoEvidence.Controls.Add(flpEvidence);
            gbPhotoEvidence.Controls.Add(pnlPhotoControls);
            gbPhotoEvidence.Controls.Add(lblNoPhotos);
            gbPhotoEvidence.Dock = DockStyle.Top;
            gbPhotoEvidence.FlatStyle = FlatStyle.Flat;
            gbPhotoEvidence.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbPhotoEvidence.Location = new Point(0, 0);
            gbPhotoEvidence.Margin = new Padding(3, 4, 3, 4);
            gbPhotoEvidence.Name = "gbPhotoEvidence";
            gbPhotoEvidence.Padding = new Padding(3, 4, 3, 4);
            gbPhotoEvidence.Size = new Size(420, 375);
            gbPhotoEvidence.TabIndex = 0;
            gbPhotoEvidence.TabStop = false;
            gbPhotoEvidence.Text = "Photo Evidence";
            // 
            // flpEvidence
            // 
            flpEvidence.AutoScroll = true;
            flpEvidence.BackColor = Color.WhiteSmoke;
            flpEvidence.BorderStyle = BorderStyle.FixedSingle;
            flpEvidence.Dock = DockStyle.Fill;
            flpEvidence.Location = new Point(3, 252);
            flpEvidence.Margin = new Padding(3, 4, 3, 4);
            flpEvidence.Name = "flpEvidence";
            flpEvidence.Padding = new Padding(5, 6, 5, 6);
            flpEvidence.Size = new Size(414, 57);
            flpEvidence.TabIndex = 4;
            // 
            // pnlPhotoControls
            // 
            pnlPhotoControls.Controls.Add(btnAddPhoto);
            pnlPhotoControls.Dock = DockStyle.Bottom;
            pnlPhotoControls.Location = new Point(3, 309);
            pnlPhotoControls.Margin = new Padding(3, 4, 3, 4);
            pnlPhotoControls.Name = "pnlPhotoControls";
            pnlPhotoControls.Size = new Size(414, 62);
            pnlPhotoControls.TabIndex = 3;
            // 
            // btnAddPhoto
            // 
            btnAddPhoto.BackColor = Color.FromArgb(46, 204, 113);
            btnAddPhoto.FlatAppearance.BorderSize = 0;
            btnAddPhoto.FlatStyle = FlatStyle.Flat;
            btnAddPhoto.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddPhoto.ForeColor = Color.White;
            btnAddPhoto.Location = new Point(155, 12);
            btnAddPhoto.Margin = new Padding(3, 4, 3, 4);
            btnAddPhoto.Name = "btnAddPhoto";
            btnAddPhoto.Size = new Size(110, 38);
            btnAddPhoto.TabIndex = 0;
            btnAddPhoto.Text = "Add Photo";
            btnAddPhoto.UseVisualStyleBackColor = false;
            // 
            // lblNoPhotos
            // 
            lblNoPhotos.Dock = DockStyle.Top;
            lblNoPhotos.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblNoPhotos.ForeColor = Color.Gray;
            lblNoPhotos.Location = new Point(3, 27);
            lblNoPhotos.Name = "lblNoPhotos";
            lblNoPhotos.Size = new Size(414, 225);
            lblNoPhotos.TabIndex = 1;
            lblNoPhotos.Text = "No photos added yet";
            lblNoPhotos.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gbCostEstimation
            // 
            gbCostEstimation.BackColor = Color.White;
            gbCostEstimation.Controls.Add(numEstimatedCost);
            gbCostEstimation.Controls.Add(lblCostHint);
            gbCostEstimation.Controls.Add(lblEstimatedCost);
            gbCostEstimation.Dock = DockStyle.Bottom;
            gbCostEstimation.FlatStyle = FlatStyle.Flat;
            gbCostEstimation.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbCostEstimation.Location = new Point(0, 400);
            gbCostEstimation.Margin = new Padding(3, 4, 3, 4);
            gbCostEstimation.Name = "gbCostEstimation";
            gbCostEstimation.Padding = new Padding(3, 4, 3, 4);
            gbCostEstimation.Size = new Size(420, 200);
            gbCostEstimation.TabIndex = 1;
            gbCostEstimation.TabStop = false;
            gbCostEstimation.Text = "Cost Estimation";
            // 
            // numEstimatedCost
            // 
            numEstimatedCost.DecimalPlaces = 2;
            numEstimatedCost.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numEstimatedCost.Location = new Point(20, 75);
            numEstimatedCost.Margin = new Padding(3, 4, 3, 4);
            numEstimatedCost.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numEstimatedCost.Name = "numEstimatedCost";
            numEstimatedCost.Size = new Size(360, 34);
            numEstimatedCost.TabIndex = 0;
            numEstimatedCost.ThousandsSeparator = true;
            // 
            // lblCostHint
            // 
            lblCostHint.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCostHint.ForeColor = Color.Gray;
            lblCostHint.Location = new Point(20, 125);
            lblCostHint.Name = "lblCostHint";
            lblCostHint.Size = new Size(360, 50);
            lblCostHint.TabIndex = 2;
            lblCostHint.Text = "This is an estimate. Final charges require approval.";
            // 
            // lblEstimatedCost
            // 
            lblEstimatedCost.AutoSize = true;
            lblEstimatedCost.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEstimatedCost.ForeColor = Color.DimGray;
            lblEstimatedCost.Location = new Point(17, 44);
            lblEstimatedCost.Name = "lblEstimatedCost";
            lblEstimatedCost.Size = new Size(181, 20);
            lblEstimatedCost.TabIndex = 1;
            lblEstimatedCost.Text = "Estimated Repair Cost (₱):";
            // 
            // pnlLeftColumn
            // 
            pnlLeftColumn.Controls.Add(gbDamageDetails);
            pnlLeftColumn.Controls.Add(gbVehicleInfo);
            pnlLeftColumn.Dock = DockStyle.Left;
            pnlLeftColumn.Location = new Point(20, 25);
            pnlLeftColumn.Margin = new Padding(3, 4, 3, 4);
            pnlLeftColumn.Name = "pnlLeftColumn";
            pnlLeftColumn.Size = new Size(440, 600);
            pnlLeftColumn.TabIndex = 2;
            // 
            // gbDamageDetails
            // 
            gbDamageDetails.BackColor = Color.White;
            gbDamageDetails.Controls.Add(pnlSeverity);
            gbDamageDetails.Controls.Add(lblSeverity);
            gbDamageDetails.Controls.Add(txtDescription);
            gbDamageDetails.Controls.Add(lblDescription);
            gbDamageDetails.Controls.Add(cbDamageType);
            gbDamageDetails.Controls.Add(lblDamageType);
            gbDamageDetails.Dock = DockStyle.Fill;
            gbDamageDetails.FlatStyle = FlatStyle.Flat;
            gbDamageDetails.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbDamageDetails.Location = new Point(0, 250);
            gbDamageDetails.Margin = new Padding(3, 4, 3, 4);
            gbDamageDetails.Name = "gbDamageDetails";
            gbDamageDetails.Padding = new Padding(3, 4, 3, 4);
            gbDamageDetails.Size = new Size(440, 350);
            gbDamageDetails.TabIndex = 1;
            gbDamageDetails.TabStop = false;
            gbDamageDetails.Text = "Damage Details";
            // 
            // pnlSeverity
            // 
            pnlSeverity.Controls.Add(rbSeverityCritical);
            pnlSeverity.Controls.Add(rbSeverityMajor);
            pnlSeverity.Controls.Add(rbSeverityMinor);
            pnlSeverity.Location = new Point(20, 275);
            pnlSeverity.Margin = new Padding(3, 4, 3, 4);
            pnlSeverity.Name = "pnlSeverity";
            pnlSeverity.Size = new Size(400, 38);
            pnlSeverity.TabIndex = 5;
            // 
            // rbSeverityCritical
            // 
            rbSeverityCritical.AutoSize = true;
            rbSeverityCritical.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbSeverityCritical.Location = new Point(290, 6);
            rbSeverityCritical.Margin = new Padding(3, 4, 3, 4);
            rbSeverityCritical.Name = "rbSeverityCritical";
            rbSeverityCritical.Size = new Size(76, 24);
            rbSeverityCritical.TabIndex = 2;
            rbSeverityCritical.TabStop = true;
            rbSeverityCritical.Text = "Critical";
            rbSeverityCritical.UseVisualStyleBackColor = true;
            // 
            // rbSeverityMajor
            // 
            rbSeverityMajor.AutoSize = true;
            rbSeverityMajor.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbSeverityMajor.Location = new Point(155, 6);
            rbSeverityMajor.Margin = new Padding(3, 4, 3, 4);
            rbSeverityMajor.Name = "rbSeverityMajor";
            rbSeverityMajor.Size = new Size(69, 24);
            rbSeverityMajor.TabIndex = 1;
            rbSeverityMajor.TabStop = true;
            rbSeverityMajor.Text = "Major";
            rbSeverityMajor.UseVisualStyleBackColor = true;
            // 
            // rbSeverityMinor
            // 
            rbSeverityMinor.AutoSize = true;
            rbSeverityMinor.Checked = true;
            rbSeverityMinor.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbSeverityMinor.Location = new Point(20, 6);
            rbSeverityMinor.Margin = new Padding(3, 4, 3, 4);
            rbSeverityMinor.Name = "rbSeverityMinor";
            rbSeverityMinor.Size = new Size(69, 24);
            rbSeverityMinor.TabIndex = 0;
            rbSeverityMinor.TabStop = true;
            rbSeverityMinor.Text = "Minor";
            rbSeverityMinor.UseVisualStyleBackColor = true;
            // 
            // lblSeverity
            // 
            lblSeverity.AutoSize = true;
            lblSeverity.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSeverity.ForeColor = Color.DimGray;
            lblSeverity.Location = new Point(17, 250);
            lblSeverity.Name = "lblSeverity";
            lblSeverity.Size = new Size(64, 20);
            lblSeverity.TabIndex = 4;
            lblSeverity.Text = "Severity:";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescription.Location = new Point(20, 156);
            txtDescription.Margin = new Padding(3, 4, 3, 4);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(400, 86);
            txtDescription.TabIndex = 3;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription.ForeColor = Color.DimGray;
            lblDescription.Location = new Point(17, 131);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(358, 20);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Describe location, size, and condition of the damage";
            // 
            // cbDamageType
            // 
            cbDamageType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDamageType.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbDamageType.FormattingEnabled = true;
            cbDamageType.Items.AddRange(new object[] { "Scratch", "Dent", "Crack", "Broken", "Missing Part", "Interior Damage", "Glass Damage", "Paint Damage", "Tire Damage", "Mechanical Issue", "Electrical Issue", "Body Damage", "Bumper Damage", "Light Damage", "Mirror Damage" });
            cbDamageType.Location = new Point(20, 75);
            cbDamageType.Margin = new Padding(3, 4, 3, 4);
            cbDamageType.Name = "cbDamageType";
            cbDamageType.Size = new Size(400, 31);
            cbDamageType.TabIndex = 1;
            // 
            // lblDamageType
            // 
            lblDamageType.AutoSize = true;
            lblDamageType.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDamageType.ForeColor = Color.DimGray;
            lblDamageType.Location = new Point(17, 44);
            lblDamageType.Name = "lblDamageType";
            lblDamageType.Size = new Size(104, 20);
            lblDamageType.TabIndex = 0;
            lblDamageType.Text = "Damage Type:";
            // 
            // gbVehicleInfo
            // 
            gbVehicleInfo.BackColor = Color.White;
            gbVehicleInfo.Controls.Add(txtPlateNumber);
            gbVehicleInfo.Controls.Add(lblPlateNumber);
            gbVehicleInfo.Controls.Add(txtRentalNumber);
            gbVehicleInfo.Controls.Add(lblRentalNumber);
            gbVehicleInfo.Controls.Add(txtVehicleModel);
            gbVehicleInfo.Controls.Add(lblVehicleModel);
            gbVehicleInfo.Dock = DockStyle.Top;
            gbVehicleInfo.FlatStyle = FlatStyle.Flat;
            gbVehicleInfo.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbVehicleInfo.Location = new Point(0, 0);
            gbVehicleInfo.Margin = new Padding(3, 4, 3, 4);
            gbVehicleInfo.Name = "gbVehicleInfo";
            gbVehicleInfo.Padding = new Padding(3, 4, 3, 4);
            gbVehicleInfo.Size = new Size(440, 250);
            gbVehicleInfo.TabIndex = 0;
            gbVehicleInfo.TabStop = false;
            gbVehicleInfo.Text = "Vehicle Information";
            // 
            // txtPlateNumber
            // 
            txtPlateNumber.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPlateNumber.Location = new Point(20, 181);
            txtPlateNumber.Margin = new Padding(3, 4, 3, 4);
            txtPlateNumber.Name = "txtPlateNumber";
            txtPlateNumber.Size = new Size(400, 30);
            txtPlateNumber.TabIndex = 5;
            // 
            // lblPlateNumber
            // 
            lblPlateNumber.AutoSize = true;
            lblPlateNumber.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPlateNumber.ForeColor = Color.DimGray;
            lblPlateNumber.Location = new Point(17, 156);
            lblPlateNumber.Name = "lblPlateNumber";
            lblPlateNumber.Size = new Size(103, 20);
            lblPlateNumber.TabIndex = 4;
            lblPlateNumber.Text = "Plate Number:";
            // 
            // txtRentalNumber
            // 
            txtRentalNumber.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRentalNumber.Location = new Point(20, 112);
            txtRentalNumber.Margin = new Padding(3, 4, 3, 4);
            txtRentalNumber.Name = "txtRentalNumber";
            txtRentalNumber.Size = new Size(400, 30);
            txtRentalNumber.TabIndex = 3;
            // 
            // lblRentalNumber
            // 
            lblRentalNumber.AutoSize = true;
            lblRentalNumber.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRentalNumber.ForeColor = Color.DimGray;
            lblRentalNumber.Location = new Point(17, 88);
            lblRentalNumber.Name = "lblRentalNumber";
            lblRentalNumber.Size = new Size(112, 20);
            lblRentalNumber.TabIndex = 2;
            lblRentalNumber.Text = "Rental Number:";
            // 
            // txtVehicleModel
            // 
            txtVehicleModel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtVehicleModel.Location = new Point(20, 44);
            txtVehicleModel.Margin = new Padding(3, 4, 3, 4);
            txtVehicleModel.Name = "txtVehicleModel";
            txtVehicleModel.Size = new Size(400, 30);
            txtVehicleModel.TabIndex = 1;
            // 
            // lblVehicleModel
            // 
            lblVehicleModel.AutoSize = true;
            lblVehicleModel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVehicleModel.ForeColor = Color.DimGray;
            lblVehicleModel.Location = new Point(17, 19);
            lblVehicleModel.Name = "lblVehicleModel";
            lblVehicleModel.Size = new Size(106, 20);
            lblVehicleModel.TabIndex = 0;
            lblVehicleModel.Text = "Vehicle Model:";
            // 
            // pnlActionBar
            // 
            pnlActionBar.BackColor = Color.WhiteSmoke;
            pnlActionBar.Controls.Add(btnSave);
            pnlActionBar.Controls.Add(btnCancel);
            pnlActionBar.Dock = DockStyle.Bottom;
            pnlActionBar.Location = new Point(0, 750);
            pnlActionBar.Margin = new Padding(3, 4, 3, 4);
            pnlActionBar.Name = "pnlActionBar";
            pnlActionBar.Padding = new Padding(20, 25, 20, 25);
            pnlActionBar.Size = new Size(900, 125);
            pnlActionBar.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.Dock = DockStyle.Right;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(700, 25);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(180, 75);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save Damage Report";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(189, 195, 199);
            btnCancel.Dock = DockStyle.Left;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(20, 25);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(180, 75);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // AddDamageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 875);
            Controls.Add(pnlContent);
            Controls.Add(pnlActionBar);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddDamageForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Damage Report";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlContent.ResumeLayout(false);
            pnlRightColumn.ResumeLayout(false);
            gbPhotoEvidence.ResumeLayout(false);
            pnlPhotoControls.ResumeLayout(false);
            gbCostEstimation.ResumeLayout(false);
            gbCostEstimation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numEstimatedCost).EndInit();
            pnlLeftColumn.ResumeLayout(false);
            gbDamageDetails.ResumeLayout(false);
            gbDamageDetails.PerformLayout();
            pnlSeverity.ResumeLayout(false);
            pnlSeverity.PerformLayout();
            gbVehicleInfo.ResumeLayout(false);
            gbVehicleInfo.PerformLayout();
            pnlActionBar.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderSubtitle;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlLeftColumn;
        private System.Windows.Forms.GroupBox gbDamageDetails;
        private System.Windows.Forms.Panel pnlSeverity;
        private System.Windows.Forms.RadioButton rbSeverityCritical;
        private System.Windows.Forms.RadioButton rbSeverityMajor;
        private System.Windows.Forms.RadioButton rbSeverityMinor;
        private System.Windows.Forms.Label lblSeverity;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ComboBox cbDamageType;
        private System.Windows.Forms.Label lblDamageType;
        private System.Windows.Forms.GroupBox gbVehicleInfo;
        private System.Windows.Forms.TextBox txtPlateNumber;
        private System.Windows.Forms.Label lblPlateNumber;
        private System.Windows.Forms.TextBox txtRentalNumber;
        private System.Windows.Forms.Label lblRentalNumber;
        private System.Windows.Forms.TextBox txtVehicleModel;
        private System.Windows.Forms.Label lblVehicleModel;
        private System.Windows.Forms.Panel pnlRightColumn;
        private System.Windows.Forms.GroupBox gbPhotoEvidence;
        private System.Windows.Forms.FlowLayoutPanel flpEvidence;
        private System.Windows.Forms.Panel pnlPhotoControls;
        private System.Windows.Forms.Button btnAddPhoto;
        private System.Windows.Forms.Label lblNoPhotos;
        private System.Windows.Forms.GroupBox gbCostEstimation;
        private System.Windows.Forms.NumericUpDown numEstimatedCost;
        private System.Windows.Forms.Label lblCostHint;
        private System.Windows.Forms.Label lblEstimatedCost;
        private System.Windows.Forms.Panel pnlActionBar;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}