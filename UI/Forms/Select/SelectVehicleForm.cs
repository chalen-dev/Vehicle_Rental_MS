using VRMS.Enums;
using VRMS.Models.Fleet;
using VRMS.Services.Fleet;

namespace VRMS.UI.Forms.Select
{
    public partial class SelectVehicleForm : Form
    {
        private readonly VehicleService _vehicleService;
        private List<Vehicle> _vehicles;
        private Vehicle _selectedVehicle;
        private bool _isClosing = false; // Flag to prevent multiple close attempts

        public Vehicle SelectedVehicle => _selectedVehicle;

        public SelectVehicleForm(VehicleService vehicleService)
        {
            InitializeComponent();
            _vehicleService = vehicleService;
            _vehicles = new List<Vehicle>();
            _selectedVehicle = null;
            _isClosing = false;

            // Wire up events in constructor (only once)
            btnSelect.Click += btnSelect_Click;
            dgvVehicles.CellDoubleClick += dgvVehicles_CellDoubleClick;
            dgvVehicles.SelectionChanged += dgvVehicles_SelectionChanged;
            txtSearch.TextChanged += txtSearch_TextChanged;
        }

        private void SelectVehicleForm_Load(object sender, EventArgs e)
        {
            LoadVehicles();
        }

        private void LoadVehicles(string searchTerm = "")
        {
            try
            {
                // Get all available vehicles
                var allVehicles = _vehicleService.GetAllVehicles()
                    .FindAll(v => v.Status == VehicleStatus.Available);

                // Apply search filter if provided
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    searchTerm = searchTerm.ToLower();
                    _vehicles = allVehicles
                        .Where(v =>
                            v.Make.ToLower().Contains(searchTerm) ||
                            v.Model.ToLower().Contains(searchTerm) ||
                            v.LicensePlate.ToLower().Contains(searchTerm) ||
                            v.VehicleCode.ToLower().Contains(searchTerm))
                        .ToList();
                }
                else
                {
                    _vehicles = allVehicles;
                }

                // Bind to DataGridView with just the display name
                dgvVehicles.DataSource = null;

                // Create a simple list with just the ID and display name
                var displayList = _vehicles.Select(v => new
                {
                    v.Id,
                    DisplayName = $"{v.Make} {v.Model} - {v.LicensePlate}"
                }).ToList();

                dgvVehicles.DataSource = displayList;

                // Clear selection
                dgvVehicles.ClearSelection();
                _selectedVehicle = null;
                UpdateSelectButtonState();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading vehicles: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadVehicles(txtSearch.Text);
        }

        private void dgvVehicles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVehicles.SelectedRows.Count > 0)
            {
                // Get the selected row's ID
                var selectedRow = dgvVehicles.SelectedRows[0];
                if (selectedRow.DataBoundItem != null)
                {
                    // Get the ID from the displayed anonymous object
                    var displayItem = selectedRow.DataBoundItem;
                    var idProperty = displayItem.GetType().GetProperty("Id");
                    if (idProperty != null)
                    {
                        int selectedId = (int)idProperty.GetValue(displayItem);
                        // Find the actual vehicle object
                        _selectedVehicle = _vehicles.FirstOrDefault(v => v.Id == selectedId);
                    }
                }
            }
            else
            {
                _selectedVehicle = null;
            }

            UpdateSelectButtonState();
        }

        private void dgvVehicles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !_isClosing)
            {
                _isClosing = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (_selectedVehicle == null || _isClosing) return;

            _isClosing = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void UpdateSelectButtonState()
        {
            btnSelect.Enabled = (_selectedVehicle != null);
        }

        // Prevent accidental closure without selection
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // If user clicks X button, set Cancel result
            if (e.CloseReason == CloseReason.UserClosing && this.DialogResult != DialogResult.OK)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}