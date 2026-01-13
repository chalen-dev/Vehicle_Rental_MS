using VRMS.Services.Customer;

namespace VRMS.UI.Forms.Select
{
    public partial class SelectCustomerForm : Form
    {
        private readonly CustomerService _customerService;
        private List<Models.Customers.Customer> _customers;
        private Models.Customers.Customer _selectedCustomer;
        private bool _isClosing = false; // Flag to prevent multiple close attempts

        public Models.Customers.Customer SelectedCustomer => _selectedCustomer;

        public SelectCustomerForm(CustomerService customerService)
        {
            InitializeComponent();
            _customerService = customerService;
            _customers = new List<Models.Customers.Customer>();
            _selectedCustomer = null;
            _isClosing = false;

            // Wire up events in constructor (only once)
            btnSelect.Click += btnSelect_Click;
            dgvCustomers.CellDoubleClick += dgvCustomers_CellDoubleClick;
            dgvCustomers.SelectionChanged += dgvCustomers_SelectionChanged;
            txtSearch.TextChanged += txtSearch_TextChanged;
        }

        private void SelectCustomerForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers(string searchTerm = "")
        {
            try
            {
                // Get all customers
                var allCustomers = _customerService.GetAllCustomers();

                // Apply search filter if provided
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    searchTerm = searchTerm.ToLower();
                    _customers = allCustomers
                        .Where(c =>
                            c.FirstName.ToLower().Contains(searchTerm) ||
                            c.LastName.ToLower().Contains(searchTerm) ||
                            c.Email?.ToLower().Contains(searchTerm) == true ||
                            c.Phone?.ToLower().Contains(searchTerm) == true)
                        .ToList();
                }
                else
                {
                    _customers = allCustomers;
                }

                // Bind to DataGridView with only name column
                dgvCustomers.DataSource = null;

                // Create a simple list with just the ID and FullName for display
                var displayList = _customers.Select(c => new
                {
                    c.Id,
                    FullName = $"{c.FirstName} {c.LastName}"
                }).ToList();

                dgvCustomers.DataSource = displayList;

                // Clear selection
                dgvCustomers.ClearSelection();
                _selectedCustomer = null;
                UpdateSelectButtonState();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadCustomers(txtSearch.Text);
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                // Get the selected row's ID
                var selectedRow = dgvCustomers.SelectedRows[0];
                if (selectedRow.DataBoundItem != null)
                {
                    // Get the ID from the displayed anonymous object
                    var displayItem = selectedRow.DataBoundItem;
                    var idProperty = displayItem.GetType().GetProperty("Id");
                    if (idProperty != null)
                    {
                        int selectedId = (int)idProperty.GetValue(displayItem);
                        // Find the actual customer object
                        _selectedCustomer = _customers.FirstOrDefault(c => c.Id == selectedId);
                    }
                }
            }
            else
            {
                _selectedCustomer = null;
            }

            UpdateSelectButtonState();
        }

        private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
            if (_selectedCustomer == null || _isClosing) return;

            _isClosing = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void UpdateSelectButtonState()
        {
            btnSelect.Enabled = (_selectedCustomer != null);
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