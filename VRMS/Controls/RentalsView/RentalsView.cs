using System;
using System.Windows.Forms;
using VRMS.Forms;

namespace VRMS.Controls
{
    public partial class RentalsView : System.Windows.Forms.UserControl
    {
        public RentalsView()
        {
            InitializeComponent();
        }

        // This method opens the New Rental form
        private void BtnNewRental_Click(object sender, EventArgs e)
        {
            // Create a new instance of the NewRentalForm
            NewRentalForm newRentalForm = new NewRentalForm();

            // Show the form as a dialog (modal)
            newRentalForm.ShowDialog();

            // Optional: Refresh data after the form closes if needed
            // RefreshRentalData();
        }

        // This method opens the Return Vehicle form
        private void BtnReturn_Click(object sender, EventArgs e)
        {
            // Create a new instance of the ReturnVehicleForm
            ReturnVehicleForm returnForm = new ReturnVehicleForm();

            // Show the form as a dialog (modal)
            returnForm.ShowDialog();

            // Optional: Refresh data after the form closes if needed
            // RefreshRentalData();
        }

        // This method opens the Rental Details form
        private void BtnViewDetails_Click(object sender, EventArgs e)
        {
            // Create a new instance of the RentalDetailsForm
            RentalDetailsForm detailsForm = new RentalDetailsForm();

            // Show the form as a dialog (modal)
            detailsForm.ShowDialog();

            // Optional: You might want to pass rental ID or other data to this form
            // RentalDetailsForm detailsForm = new RentalDetailsForm(rentalId);
        }
    }
}