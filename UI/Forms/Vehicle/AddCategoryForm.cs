using System;
using System.Windows.Forms;
using VRMS.Models.Fleet;
using VRMS.Services.Vehicle;

namespace VRMS.UI.Forms
{
    public partial class AddCategoryForm : Form
    {
        private readonly VehicleService _vehicleService;

        // ✅ This is what AddVehicleForm will read
        public int CreatedCategoryId { get; private set; }

        public AddCategoryForm(VehicleService vehicleService)
        {
            InitializeComponent();

            _vehicleService = vehicleService;

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (_, __) => Close();

            LoadCategories();
        }

        // -------------------------------------------------
        // LOAD CATEGORIES
        // -------------------------------------------------
        private void LoadCategories()
        {
            var categories = _vehicleService.GetAllCategories();

            lstCategories.DataSource = null;
            lstCategories.DataSource = categories;
            lstCategories.DisplayMember = "Name";
            lstCategories.ValueMember = "Id";
        }

        // -------------------------------------------------
        // ADD CATEGORY
        // -------------------------------------------------
        private void BtnSave_Click(object sender, EventArgs e)
        {
            var name = txtCategoryName.Text.Trim();
            var description = txtDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show(
                    "Category name is required.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                CreatedCategoryId = _vehicleService.CreateCategory(
                    name,
                    string.IsNullOrWhiteSpace(description) ? null : description
                );

                MessageBox.Show(
                    "Category added successfully.\n\n" +
                    "Remember to configure rates for this category.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to add category.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // -------------------------------------------------
        // DELETE CATEGORY (OPTIONAL)
        // -------------------------------------------------
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lstCategories.SelectedItem == null)
            {
                MessageBox.Show(
                    "Please select a category to delete.",
                    "No Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var category = (VehicleCategory)lstCategories.SelectedItem;

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete \"{category.Name}\"?\n\n" +
                "This action cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                _vehicleService.DeleteCategory(category.Id);

                MessageBox.Show(
                    "Category deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadCategories();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Cannot Delete Category",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to delete category.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
