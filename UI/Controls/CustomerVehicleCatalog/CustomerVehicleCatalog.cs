using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace VRMS.UI.Controls.CustomerVehicleCatalog
{
    public partial class CustomerVehicleCatalog : UserControl
    {
        private List<VehicleItem> _vehicles = new();

        public CustomerVehicleCatalog()
        {
            InitializeComponent();
            LoadMockData();
            WireEvents();
            Render();
        }

        // =========================
        // Mock data lang ni for UI testing
        // =========================
        private void LoadMockData()
        {
            _vehicles = new List<VehicleItem>
            {
                new VehicleItem("Toyota Vios", "Sedan", "Available", 1800),
                new VehicleItem("Ford Ranger", "Pickup", "Rented", 3200),
                new VehicleItem("Honda Click 125", "Motorcycle", "Available", 700),
                new VehicleItem("Mitsubishi Xpander", "MPV", "Rented", 2500),
                new VehicleItem("Toyota HiAce", "Van", "Maintenance", 2800),
            };
        }

        // =========================
        // I-wire tanan dropdowns ug checkbox
        // =========================
        private void WireEvents()
        {
            txtSearch.TextChanged += FilterVehicles;
            cbStatus.SelectedIndexChanged += FilterVehicles;
            cbCategory.SelectedIndexChanged += FilterVehicles;
            cbSort.SelectedIndexChanged += FilterVehicles;
            chkAvailableOnly.CheckedChanged += FilterVehicles;
        }

        // =========================
        // Main render sa catalog
        // =========================
        private void Render()
        {
            flpCatalog.Controls.Clear();

            string status = cbStatus.SelectedItem?.ToString() ?? "All";
            string category = cbCategory.SelectedItem?.ToString() ?? "All";

            IEnumerable<VehicleItem> filtered = _vehicles;

            // Filter by status
            if (status != "All")
                filtered = filtered.Where(v => v.Status == status);

            // Filter by category
            if (category != "All")
                filtered = filtered.Where(v => v.Category == category);

            // Available only checkbox
            if (chkAvailableOnly.Checked)
                filtered = filtered.Where(v => v.Status == "Available");

            // Search filter
            filtered = filtered.Where(v =>
                v.Name.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase));

            // Sorting
            filtered = cbSort.SelectedIndex switch
            {
                1 => filtered.OrderBy(v => v.Rate),
                2 => filtered.OrderByDescending(v => v.Rate),
                _ => filtered.OrderBy(v => v.Name)
            };

            foreach (var v in filtered)
            {
                flpCatalog.Controls.Add(CreateCard(v));
            }
        }

        // =========================
        // Shared event handler
        // =========================
        private void FilterVehicles(object sender, EventArgs e)
        {
            Render();
        }

        // =========================
        // Vehicle card UI
        // =========================
        private Panel CreateCard(VehicleItem v)
        {
            var card = new Panel
            {
                Width = 240,
                Height = 200,
                BackColor = Color.White,
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle
            };

            var lblName = new Label
            {
                Text = v.Name,
                Font = new Font("Segoe UI Semibold", 10F),
                Location = new Point(10, 10),
                AutoSize = true
            };

            Color statusColor = v.Status switch
            {
                "Available" => Color.FromArgb(46, 204, 113),
                "Rented" => Color.FromArgb(231, 76, 60),
                "Maintenance" => Color.FromArgb(243, 156, 18),
                _ => Color.Gray
            };

            var lblStatus = new Label
            {
                Text = v.Status,
                ForeColor = statusColor,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                Location = new Point(10, 40),
                AutoSize = true
            };

            var lblRate = new Label
            {
                Text = $"₱ {v.Rate:N0} / day",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 60, 90),
                Location = new Point(10, 70),
                AutoSize = true
            };

            var btnView = new Button
            {
                Text = "View Details",
                Width = 200,
                Height = 30,
                Location = new Point(10, 150),
                BackColor = Color.FromArgb(30, 60, 90),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnView.FlatAppearance.BorderSize = 0;

            btnView.Click += (_, _) =>
            {
                MessageBox.Show(
                    $"{v.Name}\n" +
                    $"Category: {v.Category}\n" +
                    $"Status: {v.Status}\n" +
                    $"Rate: ₱ {v.Rate:N0} / day",
                    "Vehicle Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            };

            card.Controls.Add(lblName);
            card.Controls.Add(lblStatus);
            card.Controls.Add(lblRate);
            card.Controls.Add(btnView);

            return card;
        }
    }

    // =========================
    // Simple vehicle model
    // =========================
    internal class VehicleItem
    {
        public string Name { get; }
        public string Category { get; }
        public string Status { get; }
        public decimal Rate { get; }

        public VehicleItem(string name, string category, string status, decimal rate)
        {
            Name = name;
            Category = category;
            Status = status;
            Rate = rate;
        }
    }
}
