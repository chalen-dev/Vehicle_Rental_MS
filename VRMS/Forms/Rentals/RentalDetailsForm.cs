using System;
using System.Windows.Forms;

namespace VRMS.Forms
{
    public partial class RentalDetailsForm : Form
    {
        public RentalDetailsForm()
        {
            InitializeComponent();

            // Link the close button to the form close action
            btnClose.Click += (s, e) => this.Close();
        }
    }
}