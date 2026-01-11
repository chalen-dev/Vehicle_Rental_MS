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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDamageForm));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderSubtitle = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.gbCostEstimation = new System.Windows.Forms.GroupBox();
            this.lblCostHint = new System.Windows.Forms.Label();
            this.lblEstimatedCost = new System.Windows.Forms.Label();
            this.numEstimatedCost = new System.Windows.Forms.NumericUpDown();
            this.gbPhotoEvidence = new System.Windows.Forms.GroupBox();
            this.flpEvidence = new System.Windows.Forms.FlowLayoutPanel();
            this.lblNoPhotos = new System.Windows.Forms.Label();
            this.btnAddPhoto = new System.Windows.Forms.Button();
            this.gbDamageDetails = new System.Windows.Forms.GroupBox();
            this.pnlSeverity = new System.Windows.Forms.Panel();
            this.rbSeverityCritical = new System.Windows.Forms.RadioButton();
            this.rbSeverityMajor = new System.Windows.Forms.RadioButton();
            this.rbSeverityMinor = new System.Windows.Forms.RadioButton();
            this.lblSeverity = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.cbDamageType = new System.Windows.Forms.ComboBox();
            this.lblDamageType = new System.Windows.Forms.Label();
            this.pnlActionBar = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.gbCostEstimation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEstimatedCost)).BeginInit();
            this.gbPhotoEvidence.SuspendLayout();
            this.gbDamageDetails.SuspendLayout();
            this.pnlSeverity.SuspendLayout();
            this.pnlActionBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlHeader.Controls.Add(this.lblHeaderSubtitle);
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(420, 80);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeaderSubtitle
            // 
            this.lblHeaderSubtitle.AutoSize = true;
            this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.Silver;
            this.lblHeaderSubtitle.Location = new System.Drawing.Point(25, 45);
            this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            this.lblHeaderSubtitle.Size = new System.Drawing.Size(249, 20);
            this.lblHeaderSubtitle.TabIndex = 1;
            this.lblHeaderSubtitle.Text = "Toyota Vios • Plate GAS-123 • Rental #1042";
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(20, 15);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(270, 38);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "Report Vehicle Damage";
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlContent.Controls.Add(this.gbCostEstimation);
            this.pnlContent.Controls.Add(this.gbPhotoEvidence);
            this.pnlContent.Controls.Add(this.gbDamageDetails);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 80);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContent.Size = new System.Drawing.Size(420, 520);
            this.pnlContent.TabIndex = 1;
            // 
            // gbCostEstimation
            // 
            this.gbCostEstimation.BackColor = System.Drawing.Color.White;
            this.gbCostEstimation.Controls.Add(this.lblCostHint);
            this.gbCostEstimation.Controls.Add(this.lblEstimatedCost);
            this.gbCostEstimation.Controls.Add(this.numEstimatedCost);
            this.gbCostEstimation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbCostEstimation.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCostEstimation.Location = new System.Drawing.Point(23, 415);
            this.gbCostEstimation.Name = "gbCostEstimation";
            this.gbCostEstimation.Size = new System.Drawing.Size(374, 140);
            this.gbCostEstimation.TabIndex = 2;
            this.gbCostEstimation.TabStop = false;
            this.gbCostEstimation.Text = "Estimated Repair Cost";
            // 
            // lblCostHint
            // 
            this.lblCostHint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostHint.ForeColor = System.Drawing.Color.Gray;
            this.lblCostHint.Location = new System.Drawing.Point(20, 85);
            this.lblCostHint.Name = "lblCostHint";
            this.lblCostHint.Size = new System.Drawing.Size(330, 40);
            this.lblCostHint.TabIndex = 2;
            this.lblCostHint.Text = "This is an estimate. Final charges require approval.";
            // 
            // lblEstimatedCost
            // 
            this.lblEstimatedCost.AutoSize = true;
            this.lblEstimatedCost.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstimatedCost.ForeColor = System.Drawing.Color.DimGray;
            this.lblEstimatedCost.Location = new System.Drawing.Point(17, 35);
            this.lblEstimatedCost.Name = "lblEstimatedCost";
            this.lblEstimatedCost.Size = new System.Drawing.Size(170, 20);
            this.lblEstimatedCost.TabIndex = 1;
            this.lblEstimatedCost.Text = "Estimated Repair Cost (₱):";
            // 
            // numEstimatedCost
            // 
            this.numEstimatedCost.DecimalPlaces = 2;
            this.numEstimatedCost.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numEstimatedCost.Location = new System.Drawing.Point(20, 58);
            this.numEstimatedCost.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numEstimatedCost.Name = "numEstimatedCost";
            this.numEstimatedCost.Size = new System.Drawing.Size(330, 30);
            this.numEstimatedCost.TabIndex = 0;
            this.numEstimatedCost.ThousandsSeparator = true;
            // 
            // gbPhotoEvidence
            // 
            this.gbPhotoEvidence.BackColor = System.Drawing.Color.White;
            this.gbPhotoEvidence.Controls.Add(this.flpEvidence);
            this.gbPhotoEvidence.Controls.Add(this.lblNoPhotos);
            this.gbPhotoEvidence.Controls.Add(this.btnAddPhoto);
            this.gbPhotoEvidence.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbPhotoEvidence.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPhotoEvidence.Location = new System.Drawing.Point(23, 265);
            this.gbPhotoEvidence.Name = "gbPhotoEvidence";
            this.gbPhotoEvidence.Size = new System.Drawing.Size(374, 140);
            this.gbPhotoEvidence.TabIndex = 1;
            this.gbPhotoEvidence.TabStop = false;
            this.gbPhotoEvidence.Text = "Photo Evidence";
            // 
            // flpEvidence
            // 
            this.flpEvidence.AutoScroll = true;
            this.flpEvidence.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flpEvidence.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpEvidence.Location = new System.Drawing.Point(20, 30);
            this.flpEvidence.Name = "flpEvidence";
            this.flpEvidence.Size = new System.Drawing.Size(330, 60);
            this.flpEvidence.TabIndex = 2;
            // 
            // lblNoPhotos
            // 
            this.lblNoPhotos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoPhotos.ForeColor = System.Drawing.Color.Gray;
            this.lblNoPhotos.Location = new System.Drawing.Point(20, 40);
            this.lblNoPhotos.Name = "lblNoPhotos";
            this.lblNoPhotos.Size = new System.Drawing.Size(330, 40);
            this.lblNoPhotos.TabIndex = 1;
            this.lblNoPhotos.Text = "No photos added yet";
            this.lblNoPhotos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddPhoto
            // 
            this.btnAddPhoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnAddPhoto.FlatAppearance.BorderSize = 0;
            this.btnAddPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPhoto.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPhoto.ForeColor = System.Drawing.Color.White;
            this.btnAddPhoto.Location = new System.Drawing.Point(20, 100);
            this.btnAddPhoto.Name = "btnAddPhoto";
            this.btnAddPhoto.Size = new System.Drawing.Size(330, 30);
            this.btnAddPhoto.TabIndex = 0;
            this.btnAddPhoto.Text = "Add Photo";
            this.btnAddPhoto.UseVisualStyleBackColor = false;
            // 
            // gbDamageDetails
            // 
            this.gbDamageDetails.BackColor = System.Drawing.Color.White;
            this.gbDamageDetails.Controls.Add(this.pnlSeverity);
            this.gbDamageDetails.Controls.Add(this.lblSeverity);
            this.gbDamageDetails.Controls.Add(this.txtDescription);
            this.gbDamageDetails.Controls.Add(this.lblDescription);
            this.gbDamageDetails.Controls.Add(this.cbDamageType);
            this.gbDamageDetails.Controls.Add(this.lblDamageType);
            this.gbDamageDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbDamageDetails.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDamageDetails.Location = new System.Drawing.Point(23, 20);
            this.gbDamageDetails.Name = "gbDamageDetails";
            this.gbDamageDetails.Size = new System.Drawing.Size(374, 235);
            this.gbDamageDetails.TabIndex = 0;
            this.gbDamageDetails.TabStop = false;
            this.gbDamageDetails.Text = "Damage Details";
            // 
            // pnlSeverity
            // 
            this.pnlSeverity.Controls.Add(this.rbSeverityCritical);
            this.pnlSeverity.Controls.Add(this.rbSeverityMajor);
            this.pnlSeverity.Controls.Add(this.rbSeverityMinor);
            this.pnlSeverity.Location = new System.Drawing.Point(20, 145);
            this.pnlSeverity.Name = "pnlSeverity";
            this.pnlSeverity.Size = new System.Drawing.Size(330, 30);
            this.pnlSeverity.TabIndex = 5;
            // 
            // rbSeverityCritical
            // 
            this.rbSeverityCritical.AutoSize = true;
            this.rbSeverityCritical.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSeverityCritical.Location = new System.Drawing.Point(220, 5);
            this.rbSeverityCritical.Name = "rbSeverityCritical";
            this.rbSeverityCritical.Size = new System.Drawing.Size(71, 24);
            this.rbSeverityCritical.TabIndex = 2;
            this.rbSeverityCritical.TabStop = true;
            this.rbSeverityCritical.Text = "Critical";
            this.rbSeverityCritical.UseVisualStyleBackColor = true;
            // 
            // rbSeverityMajor
            // 
            this.rbSeverityMajor.AutoSize = true;
            this.rbSeverityMajor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSeverityMajor.Location = new System.Drawing.Point(115, 5);
            this.rbSeverityMajor.Name = "rbSeverityMajor";
            this.rbSeverityMajor.Size = new System.Drawing.Size(67, 24);
            this.rbSeverityMajor.TabIndex = 1;
            this.rbSeverityMajor.TabStop = true;
            this.rbSeverityMajor.Text = "Major";
            this.rbSeverityMajor.UseVisualStyleBackColor = true;
            // 
            // rbSeverityMinor
            // 
            this.rbSeverityMinor.AutoSize = true;
            this.rbSeverityMinor.Checked = true;
            this.rbSeverityMinor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSeverityMinor.Location = new System.Drawing.Point(5, 5);
            this.rbSeverityMinor.Name = "rbSeverityMinor";
            this.rbSeverityMinor.Size = new System.Drawing.Size(68, 24);
            this.rbSeverityMinor.TabIndex = 0;
            this.rbSeverityMinor.TabStop = true;
            this.rbSeverityMinor.Text = "Minor";
            this.rbSeverityMinor.UseVisualStyleBackColor = true;
            // 
            // lblSeverity
            // 
            this.lblSeverity.AutoSize = true;
            this.lblSeverity.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeverity.ForeColor = System.Drawing.Color.DimGray;
            this.lblSeverity.Location = new System.Drawing.Point(17, 125);
            this.lblSeverity.Name = "lblSeverity";
            this.lblSeverity.Size = new System.Drawing.Size(62, 20);
            this.lblSeverity.TabIndex = 4;
            this.lblSeverity.Text = "Severity:";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(20, 90);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(330, 30);
            this.txtDescription.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.DimGray;
            this.lblDescription.Location = new System.Drawing.Point(17, 70);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(274, 20);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Describe location, size, and condition of the damage";
            // 
            // cbDamageType
            // 
            this.cbDamageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDamageType.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDamageType.FormattingEnabled = true;
            this.cbDamageType.Items.AddRange(new object[] {
            "Scratch",
            "Dent",
            "Crack",
            "Broken",
            "Missing Part",
            "Interior Damage"});
            this.cbDamageType.Location = new System.Drawing.Point(20, 40);
            this.cbDamageType.Name = "cbDamageType";
            this.cbDamageType.Size = new System.Drawing.Size(330, 31);
            this.cbDamageType.TabIndex = 1;
            // 
            // lblDamageType
            // 
            this.lblDamageType.AutoSize = true;
            this.lblDamageType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDamageType.ForeColor = System.Drawing.Color.DimGray;
            this.lblDamageType.Location = new System.Drawing.Point(17, 20);
            this.lblDamageType.Name = "lblDamageType";
            this.lblDamageType.Size = new System.Drawing.Size(99, 20);
            this.lblDamageType.TabIndex = 0;
            this.lblDamageType.Text = "Damage Type:";
            // 
            // pnlActionBar
            // 
            this.pnlActionBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlActionBar.Controls.Add(this.btnSave);
            this.pnlActionBar.Controls.Add(this.btnCancel);
            this.pnlActionBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActionBar.Location = new System.Drawing.Point(0, 600);
            this.pnlActionBar.Name = "pnlActionBar";
            this.pnlActionBar.Padding = new System.Windows.Forms.Padding(20);
            this.pnlActionBar.Size = new System.Drawing.Size(420, 100);
            this.pnlActionBar.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(220, 20);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 60);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save Damage Report";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(20, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(180, 60);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // AddDamageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 700);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlActionBar);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddDamageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Damage Report";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.gbCostEstimation.ResumeLayout(false);
            this.gbCostEstimation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEstimatedCost)).EndInit();
            this.gbPhotoEvidence.ResumeLayout(false);
            this.gbDamageDetails.ResumeLayout(false);
            this.gbDamageDetails.PerformLayout();
            this.pnlSeverity.ResumeLayout(false);
            this.pnlSeverity.PerformLayout();
            this.pnlActionBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderSubtitle;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.GroupBox gbCostEstimation;
        private System.Windows.Forms.Label lblCostHint;
        private System.Windows.Forms.Label lblEstimatedCost;
        private System.Windows.Forms.NumericUpDown numEstimatedCost;
        private System.Windows.Forms.GroupBox gbPhotoEvidence;
        private System.Windows.Forms.FlowLayoutPanel flpEvidence;
        private System.Windows.Forms.Label lblNoPhotos;
        private System.Windows.Forms.Button btnAddPhoto;
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
        private System.Windows.Forms.Panel pnlActionBar;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}