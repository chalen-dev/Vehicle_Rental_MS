using System;
using System.Windows.Forms;

namespace VRMS.Forms
{
    // Ensure you have ": Form" inheritance here!
    public partial class AddVehicleForm : Form
    {
        public AddVehicleForm()
        {
            InitializeComponent();
        }

        // Add these logic placeholders manually or double-click buttons in Designer
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Perform your database save logic here

            // 2. If successful, set DialogResult to OK and close
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Simply close without doing anything
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void btnSelectImage_Click(object sender, EventArgs e) { }
    }
}