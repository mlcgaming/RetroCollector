using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RetroCollector.Models;
using RetroCollector.Data.Management;

namespace RetroCollector {
    public partial class ReportForm : Form {
        private List<Product> reportedProducts = new List<Product>();
        private List<TransactionSale> reportedSales = new List<TransactionSale>();
        private bool isReportingProducts;
        private string reportTitle;

        public ReportForm(string reportTitle, List<Product> reportedProducts) {
            InitializeComponent();

            this.reportedProducts = reportedProducts;
            isReportingProducts = true;
            this.reportTitle = reportTitle;

            ResetForm();
        }

        public ReportForm(string reportTitle, List<TransactionSale> reportedSales) {
            InitializeComponent();

            this.reportedSales = reportedSales;
            isReportingProducts = false;
            this.reportTitle = reportTitle;

            ResetForm();
        }

        // Methods
        private void ResetForm() {
            // Disable Events
            btnClose.Click -= OnCloseButtonClick;

            // Set Report DataGrid
            if(isReportingProducts) {
                dgvReportItems.DataSource = reportedProducts;
            }
            else {
                dgvReportItems.DataSource = reportedSales;
            }

            // Set Control Defaults
            btnClose.Enabled = true;
            lblReportDate.Text = $"Report Date: {DateTime.Now.Date:dd MMM yyyy}";
            lblReportTitle.Text = $"{reportTitle}";

            // Enable Events
            btnClose.Click += OnCloseButtonClick;
        }


        // Event Handlers
        private void OnCloseButtonClick(object sender, EventArgs e) {
            Close();
        }
    }
}
