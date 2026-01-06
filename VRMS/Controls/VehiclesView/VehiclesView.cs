using System;
using System.Windows.Forms;
using VRMS.Forms; // Import the Forms namespace

namespace VRMS.Controls
{
    public partial class VehiclesView : UserControl
    {
        public VehiclesView()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Create a new instance of the Add form
            using (AddVehicleForm addForm = new AddVehicleForm())
            {
                // Show as a Modal Dialog (centers over the current application)
                addForm.StartPosition = FormStartPosition.CenterParent;

                if (addForm.ShowDialog(this) == DialogResult.OK)
                {
                    // TODO: Refresh your DataGridView/list here after adding
                    MessageBox.Show("Vehicle added successfully!");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Ensure a vehicle is selected in your Grid before editing
            // Example: if (dgvVehicles.SelectedRows.Count > 0)

            using (EditVehicleForm editForm = new EditVehicleForm())
            {
                editForm.StartPosition = FormStartPosition.CenterParent;

                if (editForm.ShowDialog(this) == DialogResult.OK)
                {
                    // TODO: Refresh your DataGridView/list here after editing
                    MessageBox.Show("Vehicle updated successfully!");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Standard confirmation before deletion
            var result = MessageBox.Show("Are you sure you want to delete this vehicle?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // TODO: Add deletion logic here
            }
        }
    }
}