using System;
using System.Windows.Forms;
using VRMS.Models.Fleet;
using VRMS.Models.Billing;
using VRMS.Services.Fleet;

namespace VRMS.UI.Forms
{
    public partial class AddCategoryForm : Form
    {
        private readonly VehicleService _vehicleService;
        private VehicleCategory? _currentCategory;
        private bool _isLoading;

        public int CreatedCategoryId { get; private set; }

        public AddCategoryForm(VehicleService vehicleService)
        {
            InitializeComponent();
            _vehicleService = vehicleService;

            HookEvents();
            LoadCategories();
            ClearFields();
        }

        // =====================================================
        // EVENT WIRING (FIXED)
        // =====================================================

        private void HookEvents()
        {
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (_, __) => Close();
            btnDelete.Click += BtnDelete_Click;

            // 🔴 EXPLICITLY WIRE THIS (CRITICAL FIX)
            lstCategories.SelectedIndexChanged +=
                lstCategories_SelectedIndexChanged;

            chkDailyEnabled.CheckedChanged += (_, __) =>
                nudDailyRate.Enabled = chkDailyEnabled.Checked;

            chkWeeklyEnabled.CheckedChanged += (_, __) =>
                nudWeeklyRate.Enabled = chkWeeklyEnabled.Checked;

            chkMonthlyEnabled.CheckedChanged += (_, __) =>
                nudMonthlyRate.Enabled = chkMonthlyEnabled.Checked;

            chkSecurityDepositEnabled.CheckedChanged += (_, __) =>
                nudSecurityDeposit.Enabled =
                    chkSecurityDepositEnabled.Checked;
        }

        // =====================================================
        // LOAD CATEGORIES (FIXED)
        // =====================================================

        private void LoadCategories()
        {
            _isLoading = true;

            try
            {
                lstCategories.DataSource = null;
                lstCategories.DataSource =
                    _vehicleService.GetAllCategories();

                lstCategories.DisplayMember = "Name";
                lstCategories.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to load categories:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                _isLoading = false;
            }
        }

        // =====================================================
        // CATEGORY SELECTION → POPULATE (FIXED)
        // =====================================================

        private void lstCategories_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (_isLoading)
                return;

            if (lstCategories.SelectedItem is not VehicleCategory category)
                return;

            _currentCategory = category;

            // ---------- BASIC INFO ----------
            txtCategoryName.Text = category.Name;
            txtDescription.Text = category.Description ?? "";

            // ---------- SECURITY DEPOSIT ----------
            chkSecurityDepositEnabled.Checked =
                category.SecurityDeposit > 0;

            nudSecurityDeposit.Value =
                category.SecurityDeposit;

            // ---------- RATES ----------
            LoadCategoryRates(category.Id);

            // ---------- UI MODE ----------
            lblTitle.Text = "Edit Vehicle Category";
            btnSave.Text = "Update Category";
            btnSave.Enabled = true;
        }

        private void LoadCategoryRates(int categoryId)
        {
            var rates =
                _vehicleService.GetCategoryRates(categoryId);

            if (rates == null)
            {
                chkDailyEnabled.Checked = false;
                chkWeeklyEnabled.Checked = false;
                chkMonthlyEnabled.Checked = false;

                nudDailyRate.Value = 0;
                nudWeeklyRate.Value = 0;
                nudMonthlyRate.Value = 0;
                return;
            }

            chkDailyEnabled.Checked = rates.DailyRate > 0;
            nudDailyRate.Value = rates.DailyRate;

            chkWeeklyEnabled.Checked = rates.WeeklyRate > 0;
            nudWeeklyRate.Value = rates.WeeklyRate;

            chkMonthlyEnabled.Checked = rates.MonthlyRate > 0;
            nudMonthlyRate.Value = rates.MonthlyRate;
        }

        // =====================================================
        // SAVE (UNCHANGED)
        // =====================================================

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var name = txtCategoryName.Text.Trim();
            var description = txtDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Category name is required.");
                tabControl.SelectedTab = tabCategoryInfo;
                txtCategoryName.Focus();
                return;
            }

            try
            {
                var deposit =
                    chkSecurityDepositEnabled.Checked
                        ? nudSecurityDeposit.Value
                        : 0m;

                if (_currentCategory == null)
                {
                    CreatedCategoryId =
                        _vehicleService.CreateCategory(
                            name,
                            string.IsNullOrWhiteSpace(description)
                                ? null
                                : description,
                            deposit);

                    SaveRates(CreatedCategoryId);
                }
                else
                {
                    _vehicleService.UpdateCategory(
                        _currentCategory.Id,
                        name,
                        string.IsNullOrWhiteSpace(description)
                            ? null
                            : description,
                        deposit);

                    SaveRates(_currentCategory.Id);
                }

                ClearFields();
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveRates(int categoryId)
        {
            var daily =
                chkDailyEnabled.Checked ? nudDailyRate.Value : 0m;
            var weekly =
                chkWeeklyEnabled.Checked ? nudWeeklyRate.Value : 0m;
            var monthly =
                chkMonthlyEnabled.Checked ? nudMonthlyRate.Value : 0m;

            var hourly =
                daily > 0 ? Math.Round(daily / 24m, 2) : 0m;

            _vehicleService.UpsertCategoryRates(
                categoryId,
                daily,
                weekly,
                monthly,
                hourly,
                0m,
                0m);
        }

        // =====================================================
        // DELETE (UNCHANGED)
        // =====================================================

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_currentCategory == null)
                return;

            if (MessageBox.Show(
                $"Delete '{_currentCategory.Name}'?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            _vehicleService.DeleteCategory(_currentCategory.Id);
            ClearFields();
            LoadCategories();
        }

        // =====================================================
        // RESET (FIXED)
        // =====================================================

        private void ClearFields()
        {
            _currentCategory = null;

            txtCategoryName.Clear();
            txtDescription.Clear();

            chkDailyEnabled.Checked = true;
            chkWeeklyEnabled.Checked = true;
            chkMonthlyEnabled.Checked = true;
            chkSecurityDepositEnabled.Checked = true;

            nudDailyRate.Value = 0;
            nudWeeklyRate.Value = 0;
            nudMonthlyRate.Value = 0;
            nudSecurityDeposit.Value = 0;

            lblTitle.Text = "Vehicle Category";
            btnSave.Text = "Save Category";
            btnSave.Enabled = false;

            
        }
    }
}
