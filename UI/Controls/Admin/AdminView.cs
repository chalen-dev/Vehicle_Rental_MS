using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VRMS.Enums;
using VRMS.Models.Accounts;
using VRMS.Repositories.Accounts;
using VRMS.Services.Account;

namespace VRMS.Controls
{
    public partial class AdminView : UserControl
    {
        private readonly UserService _userService;

        // UI controls added programmatically
        private CheckBox chkShowInactive;
        private ComboBox cmbRoleFilter;
        
        public AdminView()
            : this(new UserService(new UserRepository()))
        {
        }
        
        public AdminView(UserService userService)
        {
            InitializeComponent();
            SetupGrids();

            _userService = userService
                           ?? throw new ArgumentNullException(nameof(userService));

            AddUserFilters();
            WireEvents();
        }

        // ----------------------------
        // UI SETUP
        // ----------------------------

        private void SetupGrids()
        {
            dgvUsers.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 245, 245);

            dgvLogs.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 245, 245);

            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.Columns.Clear();

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID",
                DataPropertyName = nameof(User.Id),
                Width = 60
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Username",
                DataPropertyName = nameof(User.Username),
                Width = 200
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Full Name",
                DataPropertyName = nameof(User.FullName),
                Width = 220
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Role",
                DataPropertyName = nameof(User.Role),
                Width = 120
            });

            dgvUsers.Columns.Add(new DataGridViewCheckBoxColumn
            {
                HeaderText = "Active",
                DataPropertyName = nameof(User.IsActive),
                Width = 60
            });
        }

        private void AddUserFilters()
        {
            chkShowInactive = new CheckBox
            {
                Text = "Show inactive users",
                Location = new Point(520, 25),
                AutoSize = true
            };

            cmbRoleFilter = new ComboBox
            {
                Location = new Point(720, 22),
                Width = 180,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            cmbRoleFilter.Items.Add("All");
            cmbRoleFilter.Items.AddRange(
                Enum.GetNames(typeof(UserRole)));

            cmbRoleFilter.SelectedIndex = 0;

            tpUsers.Controls.Add(chkShowInactive);
            tpUsers.Controls.Add(cmbRoleFilter);
        }

        private void WireEvents()
        {
            Load += (_, __) => ReloadUsers();

            chkShowInactive.CheckedChanged += (_, __) => ReloadUsers();
            cmbRoleFilter.SelectedIndexChanged += (_, __) => ReloadUsers();

            btnAddUser.Click += btnAddUser_Click;
            btnEditUser.Click += btnEditUser_Click;
            btnDeleteUser.Click += btnDeleteUser_Click;
        }

        // ----------------------------
        // DATA LOADING
        // ----------------------------

        private void ReloadUsers()
        {
            IEnumerable<User> users;

            // Base set
            if (chkShowInactive.Checked)
                users = _userService.ListUsers();
            else
                users = _userService.ListActiveUsers();

            // Role filter
            if (cmbRoleFilter.SelectedItem is string roleText &&
                roleText != "All")
            {
                var role = Enum.Parse<UserRole>(roleText);
                users = users.Where(u => u.Role == role);
            }

            dgvUsers.DataSource = users.ToList();
        }

        // ----------------------------
        // BUTTON HANDLERS (STUBS FOR NEXT STEP)
        // ----------------------------

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add User wiring is next.", "Info");
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Edit User wiring is next.", "Info");
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow?.DataBoundItem is not User user)
                return;

            if (MessageBox.Show(
                    $"Deactivate user '{user.Username}'?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            _userService.Deactivate(user.Id);
            ReloadUsers();
        }

        private void btnClearLogs_Click(object sender, EventArgs e) { }
        private void btnSaveSettings_Click(object sender, EventArgs e) { }
    }
}
