using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VRMS.Enums;
using VRMS.Models.Accounts;
using VRMS.Services.Account;
using VRMS.UI.ApplicationService;

namespace VRMS.Controls
{
    public partial class AdminView : UserControl
    {
        private readonly UserService _userService;
        private CheckBox chkShowInactive;
        private ComboBox cmbRoleFilter;

        // DEFAULT ctor — production usage
        public AdminView()
            : this(ApplicationServices.UserService)
        {
        }

        // OPTIONAL ctor — unit testing / isolation
        internal AdminView(UserService userService)
        {
            _userService = userService
                ?? throw new ArgumentNullException(nameof(userService));

            InitializeComponent();
            SetupGrids();
            AddUserFilters();
            WireEvents();
        }

        private void SetupGrids()
        {
            dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
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
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 40
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Full Name",
                DataPropertyName = nameof(User.FullName),
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 60
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
            cmbRoleFilter.Items.AddRange(Enum.GetNames(typeof(UserRole)));
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
            btnRefresh.Click += (_, __) => ReloadUsers();
        }

        private void ReloadUsers()
        {
            IEnumerable<User> users = chkShowInactive.Checked
                ? _userService.ListUsers()
                : _userService.ListActiveUsers();

            if (cmbRoleFilter.SelectedItem is string roleText && roleText != "All")
            {
                var role = Enum.Parse<UserRole>(roleText);
                users = users.Where(u => u.Role == role);
            }

            dgvUsers.DataSource = users.ToList();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
            => MessageBox.Show("Add User wiring is next.");

        private void btnEditUser_Click(object sender, EventArgs e)
            => MessageBox.Show("Edit User wiring is next.");

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow?.DataBoundItem is not User user) return;

            if (MessageBox.Show(
                $"Deactivate '{user.Username}'?",
                "Confirm",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _userService.Deactivate(user.Id);
                ReloadUsers();
            }
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                if (!dgvUsers.IsDisposed)
                {
                    dgvUsers.PerformLayout();
                    dgvUsers.Refresh();
                }
            });
        }
    }
}
