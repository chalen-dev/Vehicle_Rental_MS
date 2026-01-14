using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VRMS.UI.Forms.Maintenance
{
    public partial class MaintenanceForm : Form
    {
        // Enums
        public enum VehicleStatus
        {
            Available = 0,
            InUse = 1,
            UnderMaintenance = 2,
            OutOfService = 3
        }

        public enum MaintenanceStatus
        {
            Scheduled = 0,
            InProgress = 1,
            Completed = 2,
            Cancelled = 3
        }

        public enum MaintenanceType
        {
            RoutineService = 0,
            Repair = 1,
            Inspection = 2,
            Emergency = 3,
            Preventive = 4,
            ScheduledMaintenance = 5,
            TireReplacement = 6,
            BrakeService = 7,
            OilChange = 8,
            BatteryReplacement = 9
        }

        // DTO classes
        public class SimpleVehicleDto
        {
            public int Id { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
            public string PlateNo { get; set; }
            public VehicleStatus Status { get; set; }
        }

        public class MaintenanceRecord
        {
            public int Id { get; set; }
            public int VehicleId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public MaintenanceType Type { get; set; }
            public MaintenanceStatus Status { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public decimal Cost { get; set; }
            public string PerformedBy { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
        }

        // Properties
        public bool RecordCreated { get; private set; } = false;
        public bool VehicleStatusUpdated { get; private set; } = false;
        private SimpleVehicleDto currentVehicle;
        private List<MaintenanceRecord> maintenanceRecords = new List<MaintenanceRecord>();

        // Constructor
        public MaintenanceForm()
        {
            InitializeComponent();
            InitializeForm();
        }

        // Overloaded constructor
        public MaintenanceForm(SimpleVehicleDto vehicle) : this()
        {
            currentVehicle = vehicle;
            LoadVehicleInfo();
            LoadComboBoxes();
            LoadHistory();
        }

        private void InitializeForm()
        {
            // Set form properties
            this.Text = "Vehicle Maintenance Manager";

            // Configure DateTimePicker
            dtpStart.Value = DateTime.Today;
            dtpEnd.Value = DateTime.Today;

            // Set status strip
            lblStatusMessage.Text = "Ready";
            lblRecordCount.Text = "0 maintenance records";

            // Update button visibility based on vehicle status
            UpdateMarkAvailableButtonVisibility();
        }

        private void LoadVehicleInfo()
        {
            if (currentVehicle != null)
            {
                lblVehicleMake.Text = $"Make: {currentVehicle.Make}";
                lblVehicleModel.Text = $"Model: {currentVehicle.Model}";
                lblPlateNo.Text = currentVehicle.PlateNo;
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

        private void LoadComboBoxes()
        {
            // Load Maintenance Types
            cmbMaintenanceType.Items.Clear();
            foreach (MaintenanceType type in Enum.GetValues(typeof(MaintenanceType)))
            {
                cmbMaintenanceType.Items.Add(new ComboBoxItem(type.ToString(), (int)type));
            }
            cmbMaintenanceType.SelectedIndex = 0;

            // Load Status
            cmbStatus.Items.Clear();
            foreach (MaintenanceStatus status in Enum.GetValues(typeof(MaintenanceStatus)))
            {
                cmbStatus.Items.Add(new ComboBoxItem(status.ToString(), (int)status));
            }
            cmbStatus.SelectedIndex = 0;
        }

        private void LoadHistory()
        {
            // This would be replaced with actual data loading
            maintenanceRecords.Clear();

            // Sample data for demonstration
            if (currentVehicle != null)
            {
                maintenanceRecords.Add(new MaintenanceRecord
                {
                    Id = 1,
                    VehicleId = currentVehicle.Id,
                    Title = "Oil Change",
                    Type = MaintenanceType.OilChange,
                    Status = MaintenanceStatus.Completed,
                    StartDate = DateTime.Today.AddDays(-30),
                    EndDate = DateTime.Today.AddDays(-30),
                    Cost = 89.99m,
                    PerformedBy = "Auto Service Center",
                    Description = "Regular oil change and filter replacement"
                });

                maintenanceRecords.Add(new MaintenanceRecord
                {
                    Id = 2,
                    VehicleId = currentVehicle.Id,
                    Title = "Brake Inspection",
                    Type = MaintenanceType.Inspection,
                    Status = MaintenanceStatus.Scheduled,
                    StartDate = DateTime.Today.AddDays(7),
                    EndDate = null,
                    Cost = 0,
                    PerformedBy = "TBD",
                    Description = "Scheduled brake system inspection"
                });
            }

            // Bind to DataGridView
            dgvHistory.DataSource = null;
            dgvHistory.DataSource = maintenanceRecords.Select(r => new
            {
                r.Id,
                r.Title,
                Type = r.Type.ToString(),
                Status = r.Status.ToString(),
                StartDate = r.StartDate.ToString("yyyy-MM-dd"),
                EndDate = r.EndDate?.ToString("yyyy-MM-dd") ?? "N/A",
                Cost = $"${r.Cost:F2}",
                r.PerformedBy
            }).ToList();

            // Update status strip
            lblRecordCount.Text = $"{maintenanceRecords.Count} maintenance records";
            lblStatusMessage.Text = $"Loaded history for {currentVehicle?.Make} {currentVehicle?.Model}";
        }

        private void UpdateRecordDetails(MaintenanceRecord record)
        {
            if (record == null)
            {
                lblDetailTitle.Text = "N/A";
                lblDetailType.Text = "N/A";
                lblDetailStatus.Text = "N/A";
                lblDetailStartDate.Text = "N/A";
                lblDetailEndDate.Text = "N/A";
                lblDetailCost.Text = "$0.00";
                txtDetailDescription.Text = "No record selected";
                return;
            }

            lblDetailTitle.Text = record.Title;
            lblDetailType.Text = record.Type.ToString();
            lblDetailStatus.Text = record.Status.ToString();
            lblDetailStartDate.Text = record.StartDate.ToString("yyyy-MM-dd");
            lblDetailEndDate.Text = record.EndDate?.ToString("yyyy-MM-dd") ?? "N/A";
            lblDetailCost.Text = $"${record.Cost:F2}";
            txtDetailDescription.Text = record.Description;
        }

        // Helper class for ComboBox items
        private class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public ComboBoxItem(string text, int value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString()
            {
                return Text;
            }
        }

        // ========== EVENT HANDLERS ==========

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter a title for the maintenance record.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return;
            }

            // Create new record
            var newRecord = new MaintenanceRecord
            {
                VehicleId = currentVehicle?.Id ?? 0,
                Title = txtTitle.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                Type = (MaintenanceType)((ComboBoxItem)cmbMaintenanceType.SelectedItem).Value,
                Status = (MaintenanceStatus)((ComboBoxItem)cmbStatus.SelectedItem).Value,
                StartDate = dtpStart.Value,
                EndDate = chkHasEndDate.Checked ? dtpEnd.Value : (DateTime?)null,
                Cost = nudCost.Value,
               
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            // Add to list (in real app, save to database)
            newRecord.Id = maintenanceRecords.Count > 0 ? maintenanceRecords.Max(r => r.Id) + 1 : 1;
            maintenanceRecords.Add(newRecord);

            // Automatically set vehicle status to UnderMaintenance when creating a new maintenance record
            if (currentVehicle != null)
            {
                currentVehicle.Status = VehicleStatus.UnderMaintenance;
                VehicleStatusUpdated = true;
                UpdateMarkAvailableButtonVisibility();
            }

            // Show success message
            lblStatusMessage.Text = $"Maintenance record '{newRecord.Title}' saved successfully. Vehicle status updated to Under Maintenance.";
            RecordCreated = true;

            // Refresh history
            LoadHistory();

            // Switch to history tab
            tabControlMain.SelectedTab = tabHistory;

            // Clear form
            ClearForm();
        }

        private void btnMarkAvailable_Click(object sender, EventArgs e)
        {
            if (currentVehicle == null)
            {
                MessageBox.Show("No vehicle selected.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"Are you sure you want to mark this vehicle as AVAILABLE?\n\n" +
                $"Vehicle: {currentVehicle.Make} {currentVehicle.Model}\n" +
                $"Plate: {currentVehicle.PlateNo}\n\n" +
                $"This will change the vehicle status from Under Maintenance to Available.",
                "Mark Vehicle Available",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Update vehicle status
                currentVehicle.Status = VehicleStatus.Available;
                VehicleStatusUpdated = true;

                // Update button visibility
                UpdateMarkAvailableButtonVisibility();

                // Show success message
                lblStatusMessage.Text = $"Vehicle '{currentVehicle.Make} {currentVehicle.Model}' marked as AVAILABLE.";

                MessageBox.Show(
                    $"Vehicle status updated successfully!\n\n" +
                    $"Vehicle: {currentVehicle.Make} {currentVehicle.Model}\n" +
                    $"New Status: Available",
                    "Status Updated",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
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

        private void dgvHistory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHistory.SelectedRows.Count > 0)
            {
                int selectedId = Convert.ToInt32(dgvHistory.SelectedRows[0].Cells["Id"].Value);
                var selectedRecord = maintenanceRecords.FirstOrDefault(r => r.Id == selectedId);
                UpdateRecordDetails(selectedRecord);
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

        // Method to get the vehicle ID
        public int GetVehicleId()
        {
            return currentVehicle?.Id ?? 0;
        }
    }
}