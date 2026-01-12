using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VRMS.Services.Customer;

namespace VRMS.UI.Forms.Rentals
{
    public partial class SelectCustomerForm : Form
    {
        private readonly CustomerService _customerService;
        private List<Models.Customers.Customer> _customers;
        private Models.Customers.Customer _selectedCustomer;

        public Models.Customers.Customer SelectedCustomer => _selectedCustomer;

        public SelectCustomerForm(CustomerService customerService)
        {
            InitializeComponent();
            _customerService = customerService;
            _customers = new List<Models.Customers.Customer>();
            _selectedCustomer = null;
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

                // Bind to DataGridView
                dgvCustomers.DataSource = null;
                dgvCustomers.DataSource = _customers;

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
                _selectedCustomer = dgvCustomers.SelectedRows[0].DataBoundItem as Models.Customers.Customer;
            }
            else
            {
                _selectedCustomer = null;
            }

            UpdateSelectButtonState();
        }

        private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateSelectButtonState()
        {
            btnSelect.Enabled = (_selectedCustomer != null);
        }
    }
}