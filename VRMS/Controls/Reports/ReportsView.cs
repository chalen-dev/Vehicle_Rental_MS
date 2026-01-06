using System;
using System.Windows.Forms;

namespace VRMS.Controls
{
    public partial class ReportsView : UserControl
    {
        public ReportsView()
        {
            InitializeComponent();
            SetupDesign();
        }

        private void SetupDesign()
        {
         
            dgvReportData.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            dgvReportData.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            dgvReportData.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvReportData.EnableHeadersVisualStyles = false;
        }

      
        private void btnApplyFilter_Click(object sender, EventArgs e) { }
        private void btnExportExcel_Click(object sender, EventArgs e) { }
        private void btnExportPDF_Click(object sender, EventArgs e) { }
    }
}