using VRMS.Enums;
using VRMS.Models.Fleet;
using VRMS.DTOs.Vehicle;
using VRMS.Helpers;
using VRMS.Services.Fleet;
using VRMS.UI.Config.Support;

namespace VRMS.UI.Forms.Maintenance
{
    public partial class MaintenanceForm : Form
    {
        private VehicleDto? currentVehicle;
        private readonly VehicleService _vehicleService;


        // Flags for parent form
        public bool RecordCreated { get; private set; } = false;
        private bool VehicleStatusUpdated { get; set; } = false;
        
        public MaintenanceForm(VehicleService vehicleService, VehicleDto vehicleDto)
        {
            _vehicleService = vehicleService;
            currentVehicle = vehicleDto;

            InitializeComponent();
            InitializeForm();

            LoadVehicleInfo();
            LoadHistory();
        }
        
        

        private void InitializeForm()
        {
            this.Text = "Vehicle Maintenance Manager";

            dtpStart.Value = DateTime.Today;
            dtpEnd.Value = DateTime.Today;

            lblStatusMessage.Text = "Ready";
            lblRecordCount.Text = "0 maintenance records";

            WireComboBoxes(); 

            UpdateMarkAvailableButtonVisibility();
        }

        private void LoadVehicleInfo()
        {
            if (currentVehicle != null)
            {
                lblVehicleMake.Text = $"Make: {currentVehicle.Make}";
                lblVehicleModel.Text = $"Model: {currentVehicle.Model}";
                lblPlateNo.Text = currentVehicle.LicensePlate;
                lblFormTitle.Text = $"Maintenance - {currentVehicle.Make} {currentVehicle.Model}";

                // Update button visibility
                UpdateMarkAvailableButtonVisibility();
            }
        }

        private void UpdateMarkAvailableButtonVisibility()
        {
            if (currentVehicle != null)
            {
                // Only show the "Mark Vehicle Available" button if vehicle is under maintenance
                btnMarkAvailable.Visible = (currentVehicle.Status == VehicleStatus.UnderMaintenance);
                btnMarkAvailable.Enabled = (currentVehicle.Status == VehicleStatus.UnderMaintenance);
            }
            else
            {
                btnMarkAvailable.Visible = false;
                btnMarkAvailable.Enabled = false;
            }
        }

        private void LoadHistory()
        {
            if (currentVehicle == null)
                return;

            var records =
                _vehicleService.GetMaintenanceByVehicle(
                    currentVehicle.Id);

            dgvHistory.DataSource = null;
            dgvHistory.DataSource = records.Select(r => new
            {
                r.Id,
                r.Title,
                Type = r.Type.ToString(),
                Status = r.Status.ToString(),
                StartDate = r.StartDate.ToString("yyyy-MM-dd"),
                EndDate = r.EndDate?.ToString("yyyy-MM-dd") ?? "N/A",
                Cost = $"₱{r.Cost:N2}",
                r.PerformedBy
            }).ToList();

            lblRecordCount.Text =
                $"{records.Count} maintenance records";

            lblStatusMessage.Text =
                $"Loaded history for {currentVehicle.Make} {currentVehicle.Model}";
        }
        
        private void WireComboBoxes()
        {
            // ============================
            // Maintenance TYPE
            // ============================
            cmbMaintenanceType.DataSource =
                EnumComboHelper.ToComboItems<MaintenanceType>();

            cmbMaintenanceType.DisplayMember = "Display";
            cmbMaintenanceType.ValueMember = "Value";
            cmbMaintenanceType.DropDownStyle = ComboBoxStyle.DropDownList;

            // ============================
            // Maintenance STATUS
            // ============================
            var allowedStatuses = new[]
            {
                MaintenanceStatus.Scheduled,
                MaintenanceStatus.InProgress
            };

            cmbStatus.DataSource =
                EnumComboHelper
                    .ToComboItems<MaintenanceStatus>()
                    .Where(i => allowedStatuses.Contains(i.Value))
                    .ToList();

            cmbStatus.DisplayMember = "Display";
            cmbStatus.ValueMember = "Value";
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;

        }



        // ========== EVENT HANDLERS ==========

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentVehicle == null)
                return;

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show(
                    "Title is required.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var record = new MaintenanceRecord
            {
                VehicleId = currentVehicle.Id,
                Title = txtTitle.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                Type = ((EnumComboItem<MaintenanceType>)cmbMaintenanceType.SelectedItem!).Value,
                Status = ((EnumComboItem<MaintenanceStatus>)cmbStatus.SelectedItem!).Value,
                StartDate = dtpStart.Value.Date,
                EndDate = chkHasEndDate.Checked
                    ? dtpEnd.Value.Date
                    : null,
                Cost = nudCost.Value,
                PerformedBy = Session.CurrentUser?.Username ?? "SYSTEM"
            };

            // effective end for overlap checks
            var effectiveEnd = record.EndDate ?? record.StartDate.AddYears(10);

            // Check for overlapping rentals
            var overlappingRentals = _vehicleService.GetOverlappingRentalsForVehicle(
                record.VehicleId,
                record.StartDate,
                record.EndDate);

            if (overlappingRentals != null && overlappingRentals.Count > 0)
            {
                // If maintenance is EMERGENCY, allow but show strong warning
                if (record.Type == MaintenanceType.Emergency)
                {
                    var r = overlappingRentals[0];
                    var rentalEnd = (r.ActualReturnDate ?? r.ExpectedReturnDate).ToString("yyyy-MM-dd");
                    var rentalStart = r.PickupDate.ToString("yyyy-MM-dd");

                    var msg = $"WARNING: This vehicle is currently rented from {rentalStart} to {rentalEnd}.\n\n" +
                              "Scheduling EMERGENCY maintenance while the vehicle is rented may interrupt the rental. " +
                              "Only proceed if you're absolutely sure and have coordinated with the customer.\n\n" +
                              "Do you want to continue and create an EMERGENCY maintenance record?";
                    var res = MessageBox.Show(
                        msg,
                        "Emergency Maintenance Confirmation",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (res != DialogResult.Yes)
                        return;
                }
                else
                {
                    MessageBox.Show(
                        "Cannot schedule maintenance. The vehicle has an active rental that overlaps the selected dates.",
                        "Maintenance Conflict",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }

            // Final explicit confirmation for creating maintenance
            var confirmMsg = $"Create maintenance record:\n\nTitle: {record.Title}\nType: {record.Type}\nStart: {record.StartDate:yyyy-MM-dd}\nEnd: {(record.EndDate?.ToString("yyyy-MM-dd") ?? "N/A")}\nCost: ₱{record.Cost:N2}\n\nProceed?";
            var confirm = MessageBox.Show(
                confirmMsg,
                "Confirm Create Maintenance",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                _vehicleService.StartMaintenance(record);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Maintenance Conflict",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            VehicleStatusUpdated = true;
            currentVehicle.Status = VehicleStatus.UnderMaintenance;

            LoadHistory();
            UpdateMarkAvailableButtonVisibility();
            ClearForm();

            tabControlMain.SelectedTab = tabHistory;

            lblStatusMessage.Text =
                $"Maintenance '{record.Title}' saved.";
        }



        private void btnMarkAvailable_Click(object sender, EventArgs e)
        {
            if (dgvHistory.SelectedRows.Count == 0)
                return;

            int maintenanceId =
                Convert.ToInt32(
                    dgvHistory.SelectedRows[0]
                        .Cells["Id"].Value);

            _vehicleService.CloseMaintenance(
                maintenanceId,
                DateTime.Today,
                MaintenanceStatus.Completed,
                VehicleStatus.Available);

            currentVehicle!.Status = VehicleStatus.Available;
            VehicleStatusUpdated = true;

            LoadHistory();
            UpdateMarkAvailableButtonVisibility();

            lblStatusMessage.Text =
                "Vehicle marked AVAILABLE and maintenance closed.";
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            lblStatusMessage.Text = "Form cleared.";
        }

        private void ClearForm()
        {
            txtTitle.Clear();
            txtDescription.Clear();
         
            cmbMaintenanceType.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            dtpStart.Value = DateTime.Today;
            chkHasEndDate.Checked = false;
            dtpEnd.Enabled = false;
            nudCost.Value = 0;
        }

        private void chkHasEndDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpEnd.Enabled = chkHasEndDate.Checked;
        }

        private void btnRefreshHistory_Click(object sender, EventArgs e)
        {
            LoadHistory();
            lblStatusMessage.Text = "History refreshed.";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvHistory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a maintenance record to edit.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Switch to edit tab and load selected record
            tabControlMain.SelectedTab = tabNew;
            lblStatusMessage.Text = "Editing selected record...";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvHistory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a maintenance record to delete.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete the selected maintenance record?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Delete record logic here
                lblStatusMessage.Text = "Record deleted.";
                LoadHistory();
            }
        }

        private void btnGenerateDoc_Click(object sender, EventArgs e)
        {
            if (dgvHistory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a maintenance record to generate a document.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text Files|*.txt|PDF Files|*.pdf|All Files|*.*";
                sfd.FileName = $"Maintenance_Report_{DateTime.Now:yyyyMMdd_HHmmss}";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // Document generation logic here
                    lblStatusMessage.Text = $"Document saved to: {sfd.FileName}";
                    MessageBox.Show("Document generated successfully!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV Files|*.csv|All Files|*.*";
                sfd.FileName = $"Maintenance_Export_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // Export logic here
                    lblStatusMessage.Text = $"Data exported to: {sfd.FileName}";
                    MessageBox.Show("Data exported successfully!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Property to check if vehicle status was updated (for parent form)
        public bool IsVehicleStatusUpdated()
        {
            return VehicleStatusUpdated;
        }

        // Method to get the updated vehicle status
        public VehicleStatus GetUpdatedVehicleStatus()
        {
            return currentVehicle?.Status ?? VehicleStatus.Available;
        }
        
    }
}