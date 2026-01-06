using System;
using System.Windows.Forms;

namespace VRMS.Controls
{
    public partial class RegisterUserControl : UserControl
    {
        // 1. Define the event that the Welcome form will listen to
        public event EventHandler GoBackToLoginRequest;

        public RegisterUserControl()
        {
            InitializeComponent();
        }

        // 2. This is linked to btnCancel.Click in the Designer
        private void btnCancel_Click(object sender, EventArgs e)
        {
            GoBackToLogin();
        }

        public void GoBackToLogin()
        {
            // Optional: Clear fields before leaving
            ClearForm();

            // 3. Raise the event to notify the Welcome form
            // The ?. ensures it doesn't crash if no one is listening
            GoBackToLoginRequest?.Invoke(this, EventArgs.Empty);
        }

        private void ClearForm()
        {
            txtUsername.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtConfirmPass.Clear();
            if (cbRole.Items.Count > 0) cbRole.SelectedIndex = 0;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Basic validation example
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPassword.Text != txtConfirmPass.Text)
            {
                MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // TODO: Add your Database Registration Logic here
            MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Auto-return to login after success
            GoBackToLogin();
        }
    }
}