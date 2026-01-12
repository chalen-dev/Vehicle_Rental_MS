using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace VRMS.Controls
{
    public partial class CustomersRentalsView : UserControl
    {
        // Data storage
        private List<Rental> rentals = new List<Rental>();
        private List<Rental> filteredRentals = new List<Rental>();
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalPages = 1;
        private Rental selectedRental = null;

        public class Rental
        {
            public int Id { get; set; }
            public string VehicleName { get; set; }
            public string PlateNumber { get; set; }
            public string Category { get; set; }
            public string Transmission { get; set; }
            public string FuelType { get; set; }
            public string PickupLocation { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public decimal DailyRate { get; set; }
            public decimal TotalAmount { get; set; }
            public string Status { get; set; }
            public string PaymentStatus { get; set; }
            public int Odometer { get; set; }
            public string Color { get; set; }
            public int Year { get; set; }
            public bool HasDamageReport { get; set; }
            public bool CanExtend { get; set; }
            public bool CanReview { get; set; }
        }

        public CustomersRentalsView()
        {
            InitializeComponent();
            InitializeData();
            SetupEventHandlers();
        }

        private void InitializeData()
        {
            // Sample rental data
            rentals = new List<Rental>
            {
                new Rental { Id = 1, VehicleName = "Toyota Vios", PlateNumber = "ABC-1001",
                           Category = "Sedan", Transmission = "Automatic", FuelType = "Gasoline",
                           PickupLocation = "Main Branch", StartDate = DateTime.Now.AddDays(-2),
                           EndDate = DateTime.Now.AddDays(5), DailyRate = 1500, TotalAmount = 10500,
                           Status = "Active", PaymentStatus = "Paid", Odometer = 0,
                           Color = "White", Year = 2022, HasDamageReport = false,
                           CanExtend = true, CanReview = false },

                new Rental { Id = 2, VehicleName = "Toyota Innova", PlateNumber = "ABC-1002",
                           Category = "MPV", Transmission = "Automatic", FuelType = "Diesel",
                           PickupLocation = "Mall Branch", StartDate = DateTime.Now.AddDays(-5),
                           EndDate = DateTime.Now.AddDays(-1), DailyRate = 2000, TotalAmount = 10000,
                           Status = "Returned", PaymentStatus = "Paid", Odometer = 250,
                           Color = "Silver", Year = 2021, HasDamageReport = false,
                           CanExtend = false, CanReview = true },

                new Rental { Id = 3, VehicleName = "Mitsubishi Mirage", PlateNumber = "ABC-1003",
                           Category = "Hatchback", Transmission = "Automatic", FuelType = "Gasoline",
                           PickupLocation = "Airport Branch", StartDate = DateTime.Now.AddDays(-3),
                           EndDate = DateTime.Now, DailyRate = 1200, TotalAmount = 3600,
                           Status = "Overdue", PaymentStatus = "Pending", Odometer = 150,
                           Color = "Red", Year = 2022, HasDamageReport = true,
                           CanExtend = false, CanReview = false },

                new Rental { Id = 4, VehicleName = "Toyota Fortuner", PlateNumber = "ABC-1006",
                           Category = "SUV", Transmission = "Automatic", FuelType = "Diesel",
                           PickupLocation = "Main Branch", StartDate = DateTime.Now.AddDays(2),
                           EndDate = DateTime.Now.AddDays(7), DailyRate = 2500, TotalAmount = 12500,
                           Status = "Pending", PaymentStatus = "Paid", Odometer = 0,
                           Color = "Black", Year = 2022, HasDamageReport = false,
                           CanExtend = false, CanReview = false },

                new Rental { Id = 5, VehicleName = "Mitsubishi Montero Sport", PlateNumber = "ABC-1007",
                           Category = "SUV", Transmission = "Automatic", FuelType = "Diesel",
                           PickupLocation = "Mall Branch", StartDate = DateTime.Now.AddDays(-7),
                           EndDate = DateTime.Now.AddDays(14), DailyRate = 2300, TotalAmount = 48300,
                           Status = "Extended", PaymentStatus = "Paid", Odometer = 500,
                           Color = "Gray", Year = 2021, HasDamageReport = false,
                           CanExtend = false, CanReview = false }
            };

            filteredRentals = rentals;
            LoadDataGridView();
            UpdatePagination();
            UpdateEmptyState();
        }

        private void SetupEventHandlers()
        {
            // Filter events
            txtSearch.TextChanged += (s, e) => ApplyFilters();
            cmbStatus.SelectedIndexChanged += (s, e) => ApplyFilters();
            cmbSortBy.SelectedIndexChanged += (s, e) => ApplyFilters();
            chkActiveOnly.CheckedChanged += (s, e) => ApplyFilters();

            // Button events
            btnClearFilters.Click += (s, e) => ClearFilters();
            btnRefresh.Click += (s, e) => RefreshData();
            btnNewRental.Click += (s, e) => NewRental();

            // Pagination events
            btnPrev.Click += (s, e) => NavigateToPage(currentPage - 1);
            btnNext.Click += (s, e) => NavigateToPage(currentPage + 1);

            // Action button events
            btnViewDetails.Click += (s, e) => ViewDetails();
            btnReturnVehicle.Click += (s, e) => ReturnVehicle();
            btnReportDamage.Click += (s, e) => ReportDamage();
            btnExtendRental.Click += (s, e) => ExtendRental();
            btnViewReceipt.Click += (s, e) => ViewReceipt();

            // DataGridView events
            dgvRentals.SelectionChanged += (s, e) => UpdateSelectedRental();
            dgvRentals.CellDoubleClick += (s, e) => ViewDetails();

            // Context menu events
            menuViewDetails.Click += (s, e) => ViewDetails();
            menuReturnVehicle.Click += (s, e) => ReturnVehicle();
            menuReportDamage.Click += (s, e) => ReportDamage();
            menuExtendRental.Click += (s, e) => ExtendRental();
            menuViewReceipt.Click += (s, e) => ViewReceipt();
            menuAddReview.Click += (s, e) => AddReview();
            menuPrintDetails.Click += (s, e) => PrintRentalDetails();
            menuExportDetails.Click += (s, e) => ExportRentalDetails();
        }

        #region FILTER AND SEARCH LOGIC
        private void ApplyFilters()
        {
            try
            {
                filteredRentals = rentals.Where(r => ApplyAllFilters(r)).ToList();

                // Apply sorting
                ApplySorting();

                currentPage = 1;
                LoadDataGridView();
                UpdatePagination();
                UpdateEmptyState();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error applying filters: {ex.Message}", "Filter Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ApplyAllFilters(Rental rental)
        {
            // Text search filter
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                string search = txtSearch.Text.ToLower();
                if (!rental.VehicleName.ToLower().Contains(search) &&
                    !rental.PlateNumber.ToLower().Contains(search) &&
                    !rental.PickupLocation.ToLower().Contains(search) &&
                    !rental.Category.ToLower().Contains(search))
                    return false;
            }

            // Status filter
            if (cmbStatus.SelectedIndex > 0 && cmbStatus.SelectedItem.ToString() != "All Status")
            {
                if (rental.Status != cmbStatus.SelectedItem.ToString())
                    return false;
            }

            // Active Only filter
            if (chkActiveOnly.Checked && rental.Status != "Active")
                return false;

            return true;
        }

        private void ApplySorting()
        {
            switch (cmbSortBy.SelectedIndex)
            {
                case 0: // Newest
                    filteredRentals = filteredRentals.OrderByDescending(r => r.StartDate).ToList();
                    break;
                case 1: // Oldest
                    filteredRentals = filteredRentals.OrderBy(r => r.StartDate).ToList();
                    break;
                case 2: // Amount
                    filteredRentals = filteredRentals.OrderByDescending(r => r.TotalAmount).ToList();
                    break;
                case 3: // Vehicle
                    filteredRentals = filteredRentals.OrderBy(r => r.VehicleName).ToList();
                    break;
            }
        }

        private void ClearFilters()
        {
            txtSearch.Clear();
            cmbStatus.SelectedIndex = 0;
            cmbSortBy.SelectedIndex = 0;
            chkActiveOnly.Checked = false;

            filteredRentals = rentals;
            ApplySorting();
            currentPage = 1;
            LoadDataGridView();
            UpdatePagination();
        }

        private void RefreshData()
        {
            try
            {
                lblLoading.Visible = true;
                lblEmpty.Visible = false;
                dgvRentals.Visible = false;

                // Simulate loading delay
                System.Threading.Thread.Sleep(500);

                ApplyFilters();

                lblLoading.Visible = false;
                dgvRentals.Visible = true;
                UpdateEmptyState();

                MessageBox.Show("Data refreshed successfully!", "Refresh Complete",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing data: {ex.Message}", "Refresh Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lblLoading.Visible = false;
                dgvRentals.Visible = true;
            }
        }

        private void NewRental()
        {
            MessageBox.Show("This would open New Rental form in a real application.",
                          "New Rental", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region DATAGRIDVIEW LOGIC
        private void LoadDataGridView()
        {
            try
            {
                dgvRentals.Rows.Clear();
                dgvRentals.Columns.Clear();

                // Create columns
                var columns = new[]
                {
                    new { Name = "Vehicle", Width = 150 },
                    new { Name = "Plate No.", Width = 100 },
                    new { Name = "Category", Width = 100 },
                    new { Name = "Transmission", Width = 100 },
                    new { Name = "Fuel", Width = 80 },
                    new { Name = "Pickup Location", Width = 120 },
                    new { Name = "Rental Period", Width = 180 },
                    new { Name = "Amount", Width = 100 },
                    new { Name = "Status", Width = 100 },
                    new { Name = "Payment", Width = 100 }
                };

                foreach (var col in columns)
                {
                    dgvRentals.Columns.Add(col.Name, col.Name);
                }

                // Style columns
                dgvRentals.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvRentals.Columns["Amount"].DefaultCellStyle.Format = "₱ #,##0.00";

                dgvRentals.Columns["Rental Period"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                // Calculate pagination
                int startIndex = (currentPage - 1) * pageSize;
                int endIndex = Math.Min(startIndex + pageSize, filteredRentals.Count);
                totalPages = (int)Math.Ceiling((double)filteredRentals.Count / pageSize);

                // Add rows for current page
                for (int i = startIndex; i < endIndex; i++)
                {
                    var rental = filteredRentals[i];

                    // Format rental period
                    string period = $"{rental.StartDate:MMM dd} - {rental.EndDate:MMM dd, yyyy}";

                    // Add row
                    int rowIndex = dgvRentals.Rows.Add(
                        rental.VehicleName,
                        rental.PlateNumber,
                        rental.Category,
                        rental.Transmission,
                        rental.FuelType,
                        rental.PickupLocation,
                        period,
                        rental.TotalAmount,
                        rental.Status,
                        rental.PaymentStatus
                    );

                    // Color code status
                    var row = dgvRentals.Rows[rowIndex];
                    Color statusColor = GetStatusColor(rental.Status);
                    row.Cells["Status"].Style.ForeColor = statusColor;
                    row.Cells["Status"].Style.Font = new Font(dgvRentals.Font, FontStyle.Bold);

                    // Store rental ID in tag
                    row.Tag = rental;
                }

                UpdateActionButtons();
                UpdateSidebarDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Data Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Color GetStatusColor(string status)
        {
            return status switch
            {
                "Active" => Color.FromArgb(40, 167, 69),    // Green
                "Pending" => Color.FromArgb(255, 193, 7),   // Yellow
                "Returned" => Color.FromArgb(108, 117, 125),// Gray
                "Overdue" => Color.FromArgb(220, 53, 69),   // Red
                "Cancelled" => Color.FromArgb(108, 117, 125),// Gray
                "Extended" => Color.FromArgb(0, 123, 255),  // Blue
                _ => Color.Black
            };
        }

        private void UpdateSelectedRental()
        {
            if (dgvRentals.SelectedRows.Count > 0)
            {
                selectedRental = dgvRentals.SelectedRows[0].Tag as Rental;
            }
            else
            {
                selectedRental = null;
            }
            UpdateActionButtons();
            UpdateSidebarDetails();
        }

        private void UpdateSidebarDetails()
        {
            if (selectedRental != null)
            {
                var details = new[]
                {
                    new { Label = "Vehicle:", Value = selectedRental.VehicleName },
                    new { Label = "Status:", Value = selectedRental.Status },
                    new { Label = "Category:", Value = selectedRental.Category },
                    new { Label = "Year/Color:", Value = $"{selectedRental.Year}/{selectedRental.Color}" },
                    new { Label = "Daily Rate:", Value = $"₱{selectedRental.DailyRate:#,##0.00}" },
                    new { Label = "Plate No.:", Value = selectedRental.PlateNumber },
                    new { Label = "Mileage:", Value = $"{selectedRental.Odometer} km" }
                };

                // Update sidebar labels
                // In a real app, you'd update actual controls here
            }
        }

        private void UpdateEmptyState()
        {
            bool isEmpty = filteredRentals.Count == 0;
            lblEmpty.Visible = isEmpty;
            dgvRentals.Visible = !isEmpty;
            pnlPagination.Visible = !isEmpty;
        }
        #endregion

        #region PAGINATION LOGIC
        private void UpdatePagination()
        {
            totalPages = (int)Math.Ceiling((double)filteredRentals.Count / pageSize);

            if (totalPages == 0) totalPages = 1;

            lblPageInfo.Text = $"Page {currentPage} of {totalPages} ({filteredRentals.Count} records)";

            btnPrev.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
        }

        private void NavigateToPage(int page)
        {
            if (page < 1 || page > totalPages) return;

            currentPage = page;
            LoadDataGridView();
            UpdatePagination();

            // Scroll to top
            if (dgvRentals.Rows.Count > 0)
                dgvRentals.FirstDisplayedScrollingRowIndex = 0;
        }
        #endregion

        #region ACTION BUTTONS LOGIC
        private void UpdateActionButtons()
        {
            bool hasSelection = selectedRental != null;

            // Enable/disable based on selection
            btnViewDetails.Enabled = hasSelection;
            btnViewReceipt.Enabled = hasSelection;

            // Enable/disable based on rental status
            if (hasSelection)
            {
                bool isActive = selectedRental.Status == "Active";
                bool isReturned = selectedRental.Status == "Returned";
                bool hasDamage = selectedRental.HasDamageReport;

                btnReturnVehicle.Enabled = isActive;
                btnReportDamage.Enabled = isActive && !hasDamage;
                btnExtendRental.Enabled = isActive && selectedRental.CanExtend;
            }
            else
            {
                btnReturnVehicle.Enabled = false;
                btnReportDamage.Enabled = false;
                btnExtendRental.Enabled = false;
            }
        }

        private void ViewDetails()
        {
            if (selectedRental == null)
            {
                MessageBox.Show("Please select a rental first.", "No Selection",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string details = $"Rental Details:\n\n" +
                           $"Vehicle: {selectedRental.VehicleName}\n" +
                           $"Plate No: {selectedRental.PlateNumber}\n" +
                           $"Category: {selectedRental.Category}\n" +
                           $"Transmission: {selectedRental.Transmission}\n" +
                           $"Fuel: {selectedRental.FuelType}\n" +
                           $"Location: {selectedRental.PickupLocation}\n" +
                           $"Period: {selectedRental.StartDate:MMM dd, yyyy} to {selectedRental.EndDate:MMM dd, yyyy}\n" +
                           $"Daily Rate: ₱{selectedRental.DailyRate:#,##0.00}\n" +
                           $"Total Amount: ₱{selectedRental.TotalAmount:#,##0.00}\n" +
                           $"Status: {selectedRental.Status}\n" +
                           $"Payment: {selectedRental.PaymentStatus}\n" +
                           $"Odometer: {selectedRental.Odometer} km";

            MessageBox.Show(details, "Rental Details",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ReturnVehicle()
        {
            if (selectedRental == null || selectedRental.Status != "Active")
            {
                MessageBox.Show("This rental cannot be returned.", "Cannot Return",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Return vehicle {selectedRental.VehicleName} ({selectedRental.PlateNumber})?\n\n" +
                                       $"Please ensure the vehicle is in good condition before returning.",
                                       "Confirm Return",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Update status
                selectedRental.Status = "Returned";
                selectedRental.CanReview = true;

                // Refresh display
                RefreshData();

                MessageBox.Show("Vehicle returned successfully!\nYou can now leave a review.",
                              "Return Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ReportDamage()
        {
            if (selectedRental == null || selectedRental.Status != "Active")
            {
                MessageBox.Show("Damage can only be reported for active rentals.",
                              "Cannot Report", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedRental.HasDamageReport)
            {
                MessageBox.Show("Damage has already been reported for this rental.",
                              "Already Reported", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var dialog = new Form()
            {
                Text = "Report Damage",
                Size = new Size(400, 300),
                StartPosition = FormStartPosition.CenterParent
            })
            {
                var txtDescription = new TextBox()
                {
                    Multiline = true,
                    Dock = DockStyle.Fill,
                    ScrollBars = ScrollBars.Vertical,
                    PlaceholderText = "Describe the damage...",
                    Font = new Font("Segoe UI", 10)
                };

                var btnSubmit = new Button()
                {
                    Text = "Submit Report",
                    Dock = DockStyle.Bottom,
                    Height = 40,
                    BackColor = Color.FromArgb(220, 53, 69),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };

                btnSubmit.Click += (s, e) =>
                {
                    if (string.IsNullOrWhiteSpace(txtDescription.Text))
                    {
                        MessageBox.Show("Please describe the damage.",
                                      "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    selectedRental.HasDamageReport = true;
                    dialog.DialogResult = DialogResult.OK;
                    dialog.Close();
                };

                dialog.Controls.Add(txtDescription);
                dialog.Controls.Add(btnSubmit);

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Damage report submitted successfully.",
                                  "Report Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateActionButtons();
                }
            }
        }

        private void ExtendRental()
        {
            if (selectedRental == null || !selectedRental.CanExtend)
            {
                MessageBox.Show("This rental cannot be extended.",
                              "Cannot Extend", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var dialog = new Form()
            {
                Text = "Extend Rental",
                Size = new Size(300, 200),
                StartPosition = FormStartPosition.CenterParent
            })
            {
                var numDays = new NumericUpDown()
                {
                    Minimum = 1,
                    Maximum = 30,
                    Value = 1,
                    Dock = DockStyle.Top,
                    Font = new Font("Segoe UI", 12),
                    TextAlign = HorizontalAlignment.Center
                };

                var lblInfo = new Label()
                {
                    Text = $"Current end date: {selectedRental.EndDate:MMM dd, yyyy}\n" +
                           $"Daily rate: ₱{selectedRental.DailyRate:#,##0.00}/day",
                    Dock = DockStyle.Top,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Padding = new Padding(10),
                    Font = new Font("Segoe UI", 10)
                };

                var btnExtend = new Button()
                {
                    Text = $"Extend for {numDays.Value} day(s)",
                    Dock = DockStyle.Bottom,
                    Height = 40,
                    BackColor = Color.FromArgb(241, 196, 15),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };

                numDays.ValueChanged += (s, e) =>
                {
                    decimal additional = selectedRental.DailyRate * (decimal)numDays.Value;
                    btnExtend.Text = $"Extend for {numDays.Value} day(s) - +₱{additional:#,##0.00}";
                };

                btnExtend.Click += (s, e) =>
                {
                    selectedRental.EndDate = selectedRental.EndDate.AddDays((double)numDays.Value);
                    selectedRental.TotalAmount += selectedRental.DailyRate * (decimal)numDays.Value;
                    selectedRental.Status = "Extended";
                    selectedRental.CanExtend = false;

                    dialog.DialogResult = DialogResult.OK;
                    dialog.Close();
                };

                dialog.Controls.Add(btnExtend);
                dialog.Controls.Add(numDays);
                dialog.Controls.Add(lblInfo);

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Rental extended successfully!",
                                  "Extension Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                }
            }
        }

        private void ViewReceipt()
        {
            if (selectedRental == null)
            {
                MessageBox.Show("Please select a rental first.", "No Selection",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string receipt = $"=== RENTAL RECEIPT ===\n\n" +
                           $"Receipt #: R{selectedRental.Id:0000}\n" +
                           $"Date: {DateTime.Now:MMM dd, yyyy hh:mm tt}\n" +
                           $"Customer: [Your Name]\n\n" +
                           $"Vehicle: {selectedRental.VehicleName}\n" +
                           $"Plate: {selectedRental.PlateNumber}\n" +
                           $"Category: {selectedRental.Category}\n" +
                           $"Location: {selectedRental.PickupLocation}\n\n" +
                           $"Rental Period:\n" +
                           $"  Start: {selectedRental.StartDate:MMM dd, yyyy}\n" +
                           $"  End: {selectedRental.EndDate:MMM dd, yyyy}\n\n" +
                           $"Daily Rate: ₱{selectedRental.DailyRate:#,##0.00}\n" +
                           $"Total Amount: ₱{selectedRental.TotalAmount:#,##0.00}\n" +
                           $"Payment Status: {selectedRental.PaymentStatus}\n\n" +
                           $"Thank you for your business!";

            MessageBox.Show(receipt, "Rental Receipt",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AddReview()
        {
            if (selectedRental == null || !selectedRental.CanReview)
            {
                MessageBox.Show("You cannot review this rental yet.",
                              "Cannot Review", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("This would open review form in a real application.",
                          "Add Review", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PrintRentalDetails()
        {
            if (selectedRental == null) return;

            MessageBox.Show($"Printing details for rental #{selectedRental.Id}",
                          "Print Rental", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExportRentalDetails()
        {
            if (selectedRental == null) return;

            SaveFileDialog saveDialog = new SaveFileDialog()
            {
                Filter = "Text Files (*.txt)|*.txt",
                FileName = $"Rental_{selectedRental.Id}_{DateTime.Now:yyyyMMdd}.txt"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string details = $"RENTAL DETAILS\n" +
                               $"==============\n" +
                               $"ID: {selectedRental.Id}\n" +
                               $"Vehicle: {selectedRental.VehicleName}\n" +
                               $"Plate: {selectedRental.PlateNumber}\n" +
                               $"Category: {selectedRental.Category}\n" +
                               $"Transmission: {selectedRental.Transmission}\n" +
                               $"Fuel: {selectedRental.FuelType}\n" +
                               $"Location: {selectedRental.PickupLocation}\n" +
                               $"Start Date: {selectedRental.StartDate:yyyy-MM-dd}\n" +
                               $"End Date: {selectedRental.EndDate:yyyy-MM-dd}\n" +
                               $"Daily Rate: ₱{selectedRental.DailyRate:#,##0.00}\n" +
                               $"Total Amount: ₱{selectedRental.TotalAmount:#,##0.00}\n" +
                               $"Status: {selectedRental.Status}\n" +
                               $"Payment: {selectedRental.PaymentStatus}\n" +
                               $"Export Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}";

                System.IO.File.WriteAllText(saveDialog.FileName, details);

                MessageBox.Show($"Rental details exported successfully!",
                              "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}