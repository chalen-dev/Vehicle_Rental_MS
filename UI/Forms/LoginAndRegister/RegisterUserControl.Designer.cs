namespace VRMS.Controls
{
    partial class RegisterUserControl
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
            pnlMain = new Panel();
            lblSub = new Label();
            lblTitle = new Label();
            label1 = new Label();
            txtUsername = new TextBox();
            label4 = new Label();
            txtEmail = new TextBox();
            label2 = new Label();
            txtPassword = new TextBox();
            label3 = new Label();
            txtConfirmPass = new TextBox();
            btnRegister = new Button();
            btnCancel = new Button();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.White;
            pnlMain.Controls.Add(lblSub);
            pnlMain.Controls.Add(lblTitle);
            pnlMain.Controls.Add(label1);
            pnlMain.Controls.Add(txtUsername);
            pnlMain.Controls.Add(label4);
            pnlMain.Controls.Add(txtEmail);
            pnlMain.Controls.Add(label2);
            pnlMain.Controls.Add(txtPassword);
            pnlMain.Controls.Add(label3);
            pnlMain.Controls.Add(txtConfirmPass);
            pnlMain.Controls.Add(btnRegister);
            pnlMain.Controls.Add(btnCancel);
            pnlMain.Location = new Point(57, 27);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(503, 674);
            pnlMain.TabIndex = 0;
            // 
            // lblSub
            // 
            lblSub.AutoSize = true;
            lblSub.Font = new Font("Segoe UI", 9F);
            lblSub.ForeColor = Color.Gray;
            lblSub.Location = new Point(38, 84);
            lblSub.Name = "lblSub";
            lblSub.Size = new Size(233, 20);
            lblSub.TabIndex = 1;
            lblSub.Text = "Join the VRMS management team";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitle.Location = new Point(33, 31);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(232, 41);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Create Account";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label1.Location = new Point(41, 135);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 3;
            label1.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.Location = new Point(38, 158);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(422, 30);
            txtUsername.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label4.Location = new Point(38, 205);
            label4.Name = "label4";
            label4.Size = new Size(104, 20);
            label4.TabIndex = 5;
            label4.Text = "Email Address";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(41, 228);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(422, 30);
            txtEmail.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label2.Location = new Point(39, 327);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 7;
            label2.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(42, 358);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(422, 30);
            txtPassword.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label3.Location = new Point(39, 412);
            label3.Name = "label3";
            label3.Size = new Size(132, 20);
            label3.TabIndex = 9;
            label3.Text = "Confirm Password";
            // 
            // txtConfirmPass
            // 
            txtConfirmPass.Font = new Font("Segoe UI", 10F);
            txtConfirmPass.Location = new Point(42, 443);
            txtConfirmPass.Name = "txtConfirmPass";
            txtConfirmPass.PasswordChar = '●';
            txtConfirmPass.Size = new Size(422, 30);
            txtConfirmPass.TabIndex = 10;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(46, 204, 113);
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(41, 518);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(423, 55);
            btnRegister.TabIndex = 11;
            btnRegister.Text = "Register Account";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnCancel
            // 
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(149, 165, 166);
            btnCancel.Location = new Point(172, 603);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(149, 40);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Back to Login";
            btnCancel.Click += btnCancel_Click;
            // 
            // RegisterUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            Controls.Add(pnlMain);
            Name = "RegisterUserControl";
            Size = new Size(617, 732);
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private Label lblTitle;
        private Label lblSub;
        private Label label1;
        private TextBox txtUsername;
        private Label label4;
        private TextBox txtEmail;
        private Label label2;
        private TextBox txtPassword;
        private Label label3;
        private TextBox txtConfirmPass;
        private Button btnRegister;
        private Button btnCancel;
    }
}
