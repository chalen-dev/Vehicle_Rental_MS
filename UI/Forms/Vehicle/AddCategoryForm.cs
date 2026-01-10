using System;
using System.Windows.Forms;
using VRMS.Models.Fleet;
using VRMS.Services.Vehicle;

namespace VRMS.UI.Forms
{
    public partial class AddCategoryForm : Form
    {
        private readonly VehicleService _vehicleService;

        // This property allows the parent form to retrieve the newly created ID
        public int CreatedCategoryId { get; private set; }

        public AddCategoryForm(VehicleService vehicleService)
        {
            InitializeComponent();
            _vehicleService = vehicleService;

            HookEvents();
            LoadCategories();
        }

        private void HookEvents()
        {
            // Main button actions
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (_, __) => Close();
            btnDelete.Click += BtnDelete_Click;

            // Note: SelectedIndexChanged and CheckedChanged are hooked 
            // via the Designer file to match your InitializeComponent()
        }

        private void LoadCategories()
        {
            try
            {
                var categories = _vehicleService.GetAllCategories();
                lstCategories.DataSource = null;
                lstCategories.DataSource = categories;
                lstCategories.DisplayMember = "Name";
                lstCategories.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // DESIGNER COMPATIBILITY HANDLERS
        // =====================================================

        // Fixed lowercase 'l' to match the CS1061 Designer error
        private void lstCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Selection logic (Optional: Populate fields for editing)
        }

        private void chkDailyEnabled_CheckedChanged(object sender, EventArgs e)
            => nudDailyRate.Enabled = chkDailyEnabled.Checked;

        private void chkWeeklyEnabled_CheckedChanged(object sender, EventArgs e)
            => nudWeeklyRate.Enabled = chkWeeklyEnabled.Checked;

        private void chkMonthlyEnabled_CheckedChanged(object sender, EventArgs e)
            => nudMonthlyRate.Enabled = chkMonthlyEnabled.Checked;

        // =====================================================
        // CRUD LOGIC
        // =====================================================

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var name = txtCategoryName.Text.Trim();
            var description = txtDescription.Text.Trim();

            // Validation
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Category name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl.SelectedTab = tabCategoryInfo; // Ensure user sees the name field
                txtCategoryName.Focus();
                return;
            }

            try
            {
                // Create Category
                CreatedCategoryId = _vehicleService.CreateCategory(
                    name,
                    string.IsNullOrWhiteSpace(description) ? null : description
                );

                // Placeholder for saving rates from tabRates
                // Example: SaveRates(CreatedCategoryId);

                MessageBox.Show("Category added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (!(lstCategories.SelectedItem is VehicleCategory category)) return;

            var confirm = MessageBox.Show($"Delete category '{category.Name}'?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _vehicleService.DeleteCategory(category.Id);
                    LoadCategories();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}