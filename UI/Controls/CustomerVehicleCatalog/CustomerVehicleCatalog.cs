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
        private string _currentStatus = "All";

        public CustomerVehicleCatalog()
        {
            InitializeComponent();
            LoadMockData();
            WireEvents();
            Render();
        }

        private void LoadMockData()
        {
            _vehicles = new List<VehicleItem>
            {
                new("Toyota Vios", "Sedan", "Available", 1800),
                new("Ford Ranger", "Pickup", "Rented", 3200),
                new("Honda Click 125", "Motorcycle", "Available", 700),
                new("Mitsubishi Xpander", "MPV", "Rented", 2500),
            };
        }

        private void WireEvents()
        {
            btnAll.Click += (_, _) => { _currentStatus = "All"; Render(); };
            btnAvailable.Click += (_, _) => { _currentStatus = "Available"; Render(); };
            btnRented.Click += (_, _) => { _currentStatus = "Rented"; Render(); };
        }

        private void Render()
        {
            flpCatalog.Controls.Clear();

            var filtered = _vehicles.Where(v =>
                (_currentStatus == "All" || v.Status == _currentStatus) &&
                v.Name.ToLower().Contains(txtSearch.Text.ToLower())
            );

            foreach (var v in filtered)
                flpCatalog.Controls.Add(CreateCard(v));
        }

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

            var lblStatus = new Label
            {
                Text = v.Status,
                ForeColor = v.Status == "Available" ? Color.Green : Color.Red,
                Location = new Point(10, 40)
            };

            var lblRate = new Label
            {
                Text = $"₱ {v.Rate}/day",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Location = new Point(10, 70)
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

            btnView.Click += (_, _) =>
            {
                MessageBox.Show(
                    $"{v.Name}\nStatus: {v.Status}\nRate: ₱{v.Rate}",
                    "Vehicle Details"
                );
            };

            card.Controls.AddRange(new Control[]
            {
                lblName, lblStatus, lblRate, btnView
            });

            return card;
        }

        private void FilterVehicles(object sender, EventArgs e) => Render();
    }

    class VehicleItem
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
