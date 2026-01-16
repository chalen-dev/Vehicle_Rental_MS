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

            // --- History grid wiring ---
            dgvHistory.SelectionChanged += dgvHistory_SelectionChanged;
            dgvHistory.MultiSelect = false;
            UpdateRetireButtonUI();
        }

        private void LoadVehicleInfo()
        {
            if (currentVehicle != null)
            {
                lblVehicleMake.Text = $"Make: {currentVehicle.Make}";
                lblVehicleModel.Text = $"Model: {currentVehicle.Model}";
                lblPlateNo.Text = currentVehicle.LicensePlate;

                // Update button visibility
                UpdateMarkAvailableButtonVisibility();
            }
            UpdateRetireButtonUI();
        }

        private void UpdateMarkAvailableButtonVisibility()
        {
            if (currentVehicle == null)
            {
                btnMarkAvailable.Visible = false;
                btnMarkAvailable.Enabled = false;
                return;
            }

            // Button is ALWAYS VISIBLE AND CLICKABLE when vehicle is Under Maintenance
            btnMarkAvailable.Visible = currentVehicle.Status == VehicleStatus.UnderMaintenance;
            btnMarkAvailable.Enabled = currentVehicle.Status == VehicleStatus.UnderMaintenance;
        }

        private void LoadHistory()
        {
            if (currentVehicle == null)
                return;

            var records = _vehicleService.GetMaintenanceByVehicle(currentVehicle.Id);

            dgvHistory.DataSource = null;
            dgvHistory.DataSource = records.Select(r => new
            {
                r.Id,
                r.Title,
                Type = EnumComboHelper.ToDisplay(r.Type),
                Status = EnumComboHelper.ToDisplay(r.Status),
                StartDate = r.StartDate.ToString("yyyy-MM-dd"),
                EndDate = r.EndDate?.ToString("yyyy-MM-dd") ?? "N/A",
                Cost = $"₱{r.Cost:N2}",
                r.PerformedBy
            }).ToList();

            lblRecordCount.Text = $"{records.Count} maintenance records";
            lblStatusMessage.Text = $"Loaded history for {currentVehicle.Make} {currentVehicle.Model}";

            // Select the first row if available
            if (dgvHistory.Rows.Count > 0)
            {
                dgvHistory.Rows[0].Selected = true;
            }
        }

        private void WireComboBoxes()
        {
            // ============================
            // Maintenance TYPE
            // ============================
            cmbMaintenanceType.DataSource = EnumComboHelper.ToComboItems<MaintenanceType>();
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

            cmbStatus.DataSource = EnumComboHelper
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
                EndDate = chkHasEndDate.Checked ? dtpEnd.Value.Date : null,
                Cost = nudCost.Value,
                PerformedBy = Session.CurrentUser?.Username ?? "SYSTEM"
            };

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

            lblStatusMessage.Text = $"Maintenance '{record.Title}' saved.";
        }

        private void dgvHistory_SelectionChanged(object? sender, EventArgs e)
        {
            // Nothing selected → reset detail panel
            if (dgvHistory.SelectedRows.Count == 0)
            {
                ResetRecordDetails();
                return;
            }

            var idCell = dgvHistory.SelectedRows[0].Cells["Id"].Value;
            if (idCell == null)
            {
                ResetRecordDetails();
                return;
            }

            int maintenanceId = Convert.ToInt32(idCell);

            var record = _vehicleService.GetMaintenanceById(maintenanceId);
            if (record == null)
            {
                ResetRecordDetails();
                return;
            }

            // --- Populate detail panel ---
            lblDetailTitle.Text = record.Title;
            lblDetailType.Text = EnumComboHelper.ToDisplay(record.Type);
            lblDetailStatus.Text = EnumComboHelper.ToDisplay(record.Status);
            lblDetailStartDate.Text = record.StartDate.ToString("yyyy-MM-dd");
            lblDetailEndDate.Text = record.EndDate?.ToString("yyyy-MM-dd") ?? "N/A";
            lblDetailCost.Text = $"₱{record.Cost:N2}";
            txtDetailDescription.Text = string.IsNullOrWhiteSpace(record.Description)
                ? "(No description)"
                : record.Description;
        }

        private void ResetRecordDetails()
        {
            lblDetailTitle.Text = "N/A";
            lblDetailType.Text = "N/A";
            lblDetailStatus.Text = "N/A";
            lblDetailStartDate.Text = "N/A";
            lblDetailEndDate.Text = "N/A";
            lblDetailCost.Text = "₱0.00";
            txtDetailDescription.Text = "No record selected";
        }

        private void btnMarkAvailable_Click(object sender, EventArgs e)
        {
            // 1. Validation: Vehicle must be under maintenance
            if (currentVehicle == null || currentVehicle.Status != VehicleStatus.UnderMaintenance)
            {
                MessageBox.Show(
                    "This vehicle is not under maintenance.",
                    "Cannot Mark Available",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // 2. Get ALL active maintenance records for confirmation
            var allActiveMaintenance = _vehicleService.GetMaintenanceByVehicle(currentVehicle.Id)
                .Where(r => r.Status != MaintenanceStatus.Completed)
                .ToList();

            // 3. Show appropriate confirmation message
            string confirmationMessage;

            if (allActiveMaintenance.Count > 0)
            {
                var activeList = string.Join("\n", allActiveMaintenance.Select(r =>
                    $"• {r.Title} ({EnumComboHelper.ToDisplay(r.Status)})"));

                confirmationMessage =
                    $"This will close {allActiveMaintenance.Count} active maintenance record(s) and mark the vehicle as AVAILABLE:\n\n" +
                    $"{activeList}\n\n" +
                    $"Proceed?";
            }
            else
            {
                confirmationMessage =
                    "This vehicle has no active maintenance records.\n\n" +
                    "Do you want to mark it as AVAILABLE?";
            }

            var confirm = MessageBox.Show(
                confirmationMessage,
                "Confirm Mark Available",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                // 4. Close ALL active maintenance records first (if any)
                foreach (var maintenance in allActiveMaintenance)
                {
                    _vehicleService.CloseMaintenance(
                        maintenance.Id,
                        DateTime.Today,
                        MaintenanceStatus.Completed,
                        VehicleStatus.Available);
                }

                // 5. Update vehicle status ONLY if not already Available
                // This prevents the "Available → Available" error
                if (currentVehicle.Status != VehicleStatus.Available)
                {
                    // Only update status if it's actually changing
                    _vehicleService.UpdateVehicleStatus(currentVehicle.Id, VehicleStatus.Available);
                    currentVehicle.Status = VehicleStatus.Available;
                    VehicleStatusUpdated = true;
                }
                else
                {
                    // Vehicle is already Available (edge case)
                    VehicleStatusUpdated = false;
                }

                // 6. Refresh UI
                LoadHistory();
                UpdateMarkAvailableButtonVisibility();

                // 7. Show success message
                if (allActiveMaintenance.Count > 0)
                {
                    lblStatusMessage.Text = $"Vehicle marked AVAILABLE. {allActiveMaintenance.Count} maintenance record(s) closed.";
                    MessageBox.Show(
                        $"Vehicle successfully marked as AVAILABLE.\n" +
                        $"{allActiveMaintenance.Count} maintenance record(s) were closed.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    lblStatusMessage.Text = "Vehicle marked as AVAILABLE.";
                    MessageBox.Show(
                        "Vehicle status updated to AVAILABLE.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Handle specific error messages better
                if (ex.Message.Contains("Illegal vehicle status transition"))
                {
                    MessageBox.Show(
                        "The vehicle is already marked as Available.",
                        "Already Available",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Refresh UI to reflect actual state
                    LoadHistory();
                    UpdateMarkAvailableButtonVisibility();
                }
                else
                {
                    MessageBox.Show(
                        $"Failed to mark vehicle available: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
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

        private void btnRetire_Click(object sender, EventArgs e)
        {
            if (currentVehicle == null)
                return;

            // ==============================
            // RESTORE MODE
            // ==============================
            if (currentVehicle.Status == VehicleStatus.Retired)
            {
                var confirmRestore = MessageBox.Show(
                    "Restore this vehicle back to AVAILABLE?\n\n" +
                    "• Vehicle will be usable again\n" +
                    "Proceed?",
                    "Confirm Restore Vehicle",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmRestore != DialogResult.Yes)
                    return;

                try
                {
                    _vehicleService.RestoreVehicle(currentVehicle.Id);

                    currentVehicle.Status = VehicleStatus.Available;
                    VehicleStatusUpdated = true;

                    UpdateRetireButtonUI();

                    lblStatusMessage.Text = "Vehicle restored and marked AVAILABLE.";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Restore Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                return;
            }

            // ==============================
            // RETIRE MODE
            // ==============================
            if (currentVehicle.Status == VehicleStatus.Rented ||
                currentVehicle.Status == VehicleStatus.Reserved)
            {
                MessageBox.Show(
                    "This vehicle is currently rented or reserved and cannot be retired.",
                    "Retire Blocked",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var confirmRetire = MessageBox.Show(
                "WARNING \n\n" +
                "You are about to RETIRE this vehicle.\n\n" +
                "Proceed?",
                "Confirm Vehicle Retirement",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirmRetire != DialogResult.Yes)
                return;

            try
            {
                _vehicleService.RetireVehicle(currentVehicle.Id);

                currentVehicle.Status = VehicleStatus.Retired;
                VehicleStatusUpdated = true;

                UpdateRetireButtonUI();

                lblStatusMessage.Text = "Vehicle successfully retired.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Retire Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void UpdateRetireButtonUI()
        {
            if (currentVehicle == null)
            {
                btnRetire.Visible = false;
                return;
            }

            btnRetire.Visible = true;

            if (currentVehicle.Status == VehicleStatus.Retired)
            {
                // RESTORE MODE
                btnRetire.Text = "Restore Vehicle";
                btnRetire.BackColor = Color.FromArgb(46, 204, 113); // green
                btnRetire.ForeColor = Color.White;
            }
            else
            {
                // RETIRE MODE
                btnRetire.Text = "Retire";
                btnRetire.BackColor = Color.Black;
                btnRetire.ForeColor = Color.White;
            }
        }
    }
}