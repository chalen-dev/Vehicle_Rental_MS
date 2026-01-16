using System;
using System.Windows.Forms;
using VRMS.Enums;
using VRMS.Models.Accounts;
using VRMS.Services.Account;
using VRMS.UI.ApplicationService;
using VRMS.UI.Config.Support;


namespace VRMS.UI.Controls.Admin
{
    public partial class AdminUserManagement : UserControl
    {
        private readonly UserService _userService =
            ApplicationServices.UserService;

        private List<User> _users = new();
        private User? _selectedUser;

        public AdminUserManagement()
        {
            InitializeComponent();
        }

        // =====================================================
        // LIFECYCLE
        // =====================================================

        private void AdminUserManagement_Load(object sender, EventArgs e)
        {
            LoadUsers();
            ClearUserDetails();
        }
        // =====================================================
        // HEADER
        // =====================================================

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string term = txtSearch.Text.Trim().ToLower();

            dgvUsers.DataSource = _users
                .Where(u =>
                    (u.Username?.ToLower().Contains(term) ?? false) ||
                    (u.FullName?.ToLower().Contains(term) ?? false) ||
                    (u.Email?.ToLower().Contains(term) ?? false))
                .Select(u => new
                {
                    u.Id,
                    u.Username,
                    FullName = u.FullName ?? "-",
                    Email = u.Email ?? "-",
                    Role = u.Role.ToString(),
                    Status = u.Status.ToString()
                })

                .ToList();
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadUsers();
            ClearUserDetails();
        }

        private void LoadUsers()
        {
            try
            {
                _users = _userService.ListUsers().ToList();

                dgvUsers.AutoGenerateColumns = false;
                dgvUsers.DataSource = null;
                dgvUsers.DataSource = _users.Select(u => new
                {
                    u.Id,
                    u.Username,
                    FullName = u.FullName ?? "-",
                    Email = u.Email ?? "-",
                    Role = u.Role.ToString(),
                    Status = u.Status.ToString()
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to load users:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        
        private void DisplayUserDetails(User user)
        {
            lblUserId.Text = user.Id.ToString();
            lblFullName.Text = user.FullName ?? "-";
            lblEmail.Text = user.Email ?? "-";
            lblRole.Text = user.Role.ToString();
            lblStatus.Text = user.Status.ToString();
            lblLastLogin.Text = "-";
            lblCreatedDate.Text = "-";

            // ==============================
            // BUTTON STATE LOGIC
            // ==============================

            bool isSelf =
                Session.CurrentUser != null &&
                Session.CurrentUser.Id == user.Id;

            // Disable self-lockout
            btnDisableAccount.Enabled =
                user.Status == AccountStatus.Active && !isSelf;

            btnEnableAccount.Enabled =
                user.Status == AccountStatus.Disabled;
            
            btnRemoveAccount.Enabled = !isSelf;
        }

        
        private void ClearUserDetails()
        {
            lblUserId.Text = "-";
            lblFullName.Text = "-";
            lblEmail.Text = "-";
            lblRole.Text = "-";
            lblStatus.Text = "-";
            lblLastLogin.Text = "-";
            lblCreatedDate.Text = "-";

            btnEnableAccount.Enabled = false;
            btnDisableAccount.Enabled = false;
        }


        // =====================================================
        // DATAGRIDVIEW
        // =====================================================

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Placeholder
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Placeholder
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                ClearUserDetails();
                return;
            }

            int userId =
                Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["colID"].Value);

            _selectedUser =
                _users.FirstOrDefault(u => u.Id == userId);

            if (_selectedUser == null)
                return;

            DisplayUserDetails(_selectedUser);
        }

        // =====================================================
        // ACTION BUTTONS
        // =====================================================

        private void btnEnableAccount_Click(object sender, EventArgs e)
        {
            if (_selectedUser == null)
                return;

            if (_selectedUser.Status != AccountStatus.Disabled)
                return;

            var confirm = MessageBox.Show(
                $"Are you sure you want to ENABLE the account:\n\n{_selectedUser.Username}?",
                "Confirm Enable",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes)
                return;

            _userService.UpdateAccountStatus(
                _selectedUser.Id,
                AccountStatus.Active
            );

            LoadUsers();

            _selectedUser = _users.FirstOrDefault(u => u.Id == _selectedUser.Id);
            if (_selectedUser != null)
                DisplayUserDetails(_selectedUser);

            LoadUsers();

            _selectedUser = _users.FirstOrDefault(u => u.Id == _selectedUser.Id);
            if (_selectedUser != null)
                DisplayUserDetails(_selectedUser);
        }



        private void btnDisableAccount_Click(object sender, EventArgs e)
        {
            if (_selectedUser.Status != AccountStatus.Active)
                return;

            var confirm = MessageBox.Show(
                $"Are you sure you want to DISABLE the account:\n\n{_selectedUser.Username}?",
                "Confirm Disable",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes)
                return;

            _userService.UpdateAccountStatus(
                _selectedUser.Id,
                AccountStatus.Disabled
            );

            LoadUsers();

            _selectedUser = _users.FirstOrDefault(u => u.Id == _selectedUser.Id);
            if (_selectedUser != null)
                DisplayUserDetails(_selectedUser);

        }

        
        private void btnRemoveAccount_Click(object sender, EventArgs e)
        {
            if (_selectedUser == null)
                return;

            var confirm = MessageBox.Show(
                $"Remove this account permanently?\n\nUsername: {_selectedUser.Username}",
                "Confirm Remove",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes)
                return;

            _userService.UpdateAccountStatus(
                _selectedUser.Id,
                AccountStatus.Removed
            );

            LoadUsers();
            ClearUserDetails();
            _selectedUser = null;
        }


        // =====================================================
        // CONTEXT MENU
        // =====================================================

        private void enableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnEnableAccount_Click(sender, e);
        }

        private void disableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDisableAccount_Click(sender, e);
        }


        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Placeholder
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Placeholder
        }
    }
}
