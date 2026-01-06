using System;
using System.Windows.Forms;
using VRMS.Forms; 

namespace VRMS.Controls
{
    public partial class ReservationsView : UserControl
    {
        public ReservationsView()
        {
            InitializeComponent();
        }

        private void BtnNewReservation_Click(object sender, EventArgs e)
        {
            // Create the form instance
            using (AddReservationForm addResForm = new AddReservationForm())
            {
                // Center the form relative to the MainForm
                addResForm.StartPosition = FormStartPosition.CenterParent;

                // Show the form and check if the user saved successfully
                if (addResForm.ShowDialog(this) == DialogResult.OK)
                {
                    // TODO: Refresh your dgvReservations here to show the new record
                    MessageBox.Show("Reservation created successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // Logic to cancel a selected reservation from dgvReservations
            if (dgvReservations.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Are you sure you want to cancel this reservation?",
                    "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // TODO: Update database status to 'Cancelled'
                }
            }
        }

        private void dgvReservations_SelectionChanged(object sender, EventArgs e) { }
    }
}