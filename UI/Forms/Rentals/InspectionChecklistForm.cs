using System;
using System.Windows.Forms;
using VRMS.Services.Rental;
using VRMS.Models.Damages;

namespace VRMS.UI.Forms.Rentals
{
    public partial class InspectionChecklistForm : Form
    {
        private readonly int _rentalId;
        private readonly RentalService _rentalService;

        private int _inspectionId;
        private VehicleInspection? _inspection;

        public InspectionChecklistForm(int rentalId, RentalService rentalService)
        {
            InitializeComponent();

            _rentalId = rentalId;
            _rentalService = rentalService ?? throw new ArgumentNullException(nameof(rentalService));

            // wire buttons and events
            Load += InspectionChecklistForm_Load;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (_, __) => Close();
        }

        private void InspectionChecklistForm_Load(object? sender, EventArgs e)
        {
            try
            {
                // Ensure a return inspection exists and load it
                _inspectionId = _rentalService.CreateOrGetReturnInspection(_rentalId);
                _inspection = _rentalService.GetInspectionById(_inspectionId);

                // Populate simple fields we have in DB (notes + cleanliness)
                txtInspectionNotes.Text = _inspection?.Notes ?? string.Empty;

                // Cleanliness stored as string in table. Try to select the combobox item if present.
                if (!string.IsNullOrWhiteSpace(_inspection?.Cleanliness))
                {
                    var idx = cmbInteriorCleanliness.FindStringExact(_inspection!.Cleanliness);
                    if (idx >= 0) cmbInteriorCleanliness.SelectedIndex = idx;
                }

                // Update header: show rental id + small hint.
                lblVehicleInfo.Text = $"Rental #{_rentalId} • Inspection #{_inspectionId}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Load Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Close();
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                // We only persist notes + cleanliness (DB has only those columns).
                var notes = txtInspectionNotes.Text.Trim();
                var cleanliness = cmbInteriorCleanliness.SelectedItem?.ToString() ?? string.Empty;

                _rentalService.UpdateReturnInspection(
                    _inspectionId,
                    notes,
                    string.Empty, // fuelLevel not present in this UI; save empty for now
                    cleanliness
                );

                MessageBox.Show(
                    "Inspection saved.",
                    "Saved",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Cannot Save Inspection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
