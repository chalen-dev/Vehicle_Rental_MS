using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VRMS.Enums;
using VRMS.Services.Customer;
using VRMS.Services.Damage;
using VRMS.Services.Fleet;
using VRMS.Services.Rental;
using VRMS.UI.ApplicationService;

namespace VRMS.Forms
{
    public partial class RentalDetailsForm : Form
    {
        // =====================================================
        // STATE
        // =====================================================

        private readonly int _rentalId;

        private readonly RentalService _rentalService;
        private readonly CustomerService _customerService;
        private readonly VehicleService _vehicleService;
        private readonly DamageService _damageService;

        private static readonly string PlaceholderImagePath =
            Path.Combine(
                AppContext.BaseDirectory,
                "Assets",
                "img_placeholder.png");

        // =====================================================
        // CONSTRUCTOR (RUNTIME)
        // =====================================================

        public RentalDetailsForm(int rentalId)
        {
            InitializeComponent();

            _rentalId = rentalId;

            _rentalService = ApplicationServices.RentalService;
            _customerService = ApplicationServices.CustomerService;
            _vehicleService = ApplicationServices.VehicleService;
            _damageService = ApplicationServices.DamageService;

            Load += RentalDetailsForm_Load;
            btnClose.Click += (_, __) => Close();

            dgvDamages.CellClick += DgvDamages_CellClick;
        }

        // =====================================================
        // DESIGNER CONSTRUCTOR (DO NOT REMOVE)
        // =====================================================

        public RentalDetailsForm()
        {
            InitializeComponent();
            btnClose.Click += (_, __) => Close();
        }

        // =====================================================
        // FORM LOAD
        // =====================================================

        private void RentalDetailsForm_Load(object sender, EventArgs e)
        {
            ConfigureDamageGrid();
            LoadRentalDetails();
        }

        // =====================================================
        // LOAD RENTAL DETAILS
        // =====================================================

        private void LoadRentalDetails()
        {
            var rental = _rentalService.GetRentalById(_rentalId);
            var vehicle = _vehicleService.GetVehicleById(rental.VehicleId);

            string customerName = "Walk-in";

            if (rental.CustomerId.HasValue)
            {
                var customer =
                    _customerService.GetCustomerById(
                        rental.CustomerId.Value);

                customerName =
                    $"{customer.FirstName} {customer.LastName}";
            }

            lblRentalID.Text = $"Rental ID: {rental.Id}";
            lblCustomer.Text = $"Customer: {customerName}";
            lblVehicle.Text =
                $"Vehicle: {vehicle.Make} {vehicle.Model} ({vehicle.LicensePlate})";

            lblTotalDate.Text =
                rental.Status == RentalStatus.Completed ||
                rental.Status == RentalStatus.Late
                    ? $"Returned: {rental.ActualReturnDate:MMM dd, yyyy}"
                    : $"Expected Return: {rental.ExpectedReturnDate:MMM dd, yyyy}";

            LoadDamages();
            LoadPlaceholder();
        }

        // =====================================================
        // DAMAGE GRID CONFIG
        // =====================================================

        private void ConfigureDamageGrid()
        {
            dgvDamages.AutoGenerateColumns = false;
            dgvDamages.Columns.Clear();
            dgvDamages.ReadOnly = true;
            dgvDamages.MultiSelect = false;
            dgvDamages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvDamages.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DamageId",
                Visible = false
            });

            dgvDamages.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Description",
                HeaderText = "Description",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvDamages.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EstimatedCost",
                HeaderText = "Estimated Cost",
                Width = 150,
                DefaultCellStyle = { Format = "₱ #,##0.00" }
            });
        }

        // =====================================================
        // LOAD DAMAGES
        // =====================================================

        private void LoadDamages()
        {
            dgvDamages.Rows.Clear();

            var damages =
                _damageService.GetDamagesByRental(_rentalId);

            foreach (var damage in damages)
            {
                dgvDamages.Rows.Add(
                    damage.Id,
                    damage.Description,
                    damage.EstimatedCost
                );
            }
        }

        // =====================================================
        // DAMAGE ROW CLICK
        // =====================================================

        private void DgvDamages_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (dgvDamages.CurrentRow == null)
                return;

            int damageId =
                Convert.ToInt32(
                    dgvDamages.CurrentRow.Cells["DamageId"].Value);

            LoadDamagePhotos(damageId);
        }

        // =====================================================
        // LOAD DAMAGE PHOTOS (SAFE)
        // =====================================================

        private void LoadDamagePhotos(int damageId)
        {
            ClearImages();

            var reports =
                _damageService.GetReportsByDamage(damageId);

            bool firstLoaded = false;

            foreach (var report in reports)
            {
                if (string.IsNullOrWhiteSpace(report.PhotoPath))
                    continue;

                string fullPath =
                    Path.Combine(
                        AppContext.BaseDirectory,
                        "Storage",
                        report.PhotoPath);

                if (!File.Exists(fullPath))
                    continue;

                var thumb = new PictureBox
                {
                    Width = 100,
                    Height = 100,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.FixedSingle,
                    Cursor = Cursors.Hand,
                    Margin = new Padding(5)
                };

                using (var fs = new FileStream(
                           fullPath,
                           FileMode.Open,
                           FileAccess.Read,
                           FileShare.ReadWrite))
                {
                    thumb.Image = Image.FromStream(fs);
                }

                thumb.Click += (_, __) =>
                    ShowMainImage(fullPath);

                flpEvidence.Controls.Add(thumb);

                if (!firstLoaded)
                {
                    ShowMainImage(fullPath);
                    firstLoaded = true;
                }
            }

            if (!firstLoaded)
                LoadPlaceholder();
        }

        // =====================================================
        // MAIN IMAGE (CRASH-SAFE)
        // =====================================================

        private void ShowMainImage(string path)
        {
            if (!File.Exists(path))
                return;

            // DO NOT DISPOSE OLD IMAGE (CRITICAL)
            pbEvidence.Image = null;

            using var fs = new FileStream(
                path,
                FileMode.Open,
                FileAccess.Read,
                FileShare.ReadWrite);

            pbEvidence.Image = Image.FromStream(fs);
        }

        // =====================================================
        // PLACEHOLDER
        // =====================================================

        private void LoadPlaceholder()
        {
            ClearImages();

            if (!File.Exists(PlaceholderImagePath))
                return;

            using var fs = new FileStream(
                PlaceholderImagePath,
                FileMode.Open,
                FileAccess.Read,
                FileShare.ReadWrite);

            pbEvidence.Image = Image.FromStream(fs);
        }

        // =====================================================
        // CLEANUP (SAFE)
        // =====================================================

        private void ClearImages()
        {
            // DO NOT dispose pbEvidence.Image
            pbEvidence.Image = null;

            foreach (Control c in flpEvidence.Controls)
            {
                if (c is PictureBox pb)
                {
                    pb.Image = null;
                    pb.Dispose();
                }
            }

            flpEvidence.Controls.Clear();
        }
    }
}
