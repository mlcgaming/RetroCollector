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
    public partial class SalesByRepOptionsForm : Form {
        public SalesByRepOptionsForm() {
            InitializeComponent();

            ResetForm();
        }

        // Method
        private void ResetForm() {
            // Disable Events
            btnClose.Click -= OnCloseButtonClick;
            btnRun.Click -= OnGenerateButtonClick;

            // Populate Lists
            foreach(var user in DatabaseManager.Users) {
                cboxSalesRep.Items.Add(user);
            }

            // Set Control Defaults
            cboxSalesRep.SelectedIndex = 0;
            btnClose.Enabled = true;
            btnRun.Enabled = true;

            // Enable Events
            btnClose.Click += OnCloseButtonClick;
            btnRun.Click += OnGenerateButtonClick;
        }

        private void RunReport() {
            UserAccount salesRep = cboxSalesRep.SelectedItem as UserAccount;

            List<TransactionSale> filteredSales = new List<TransactionSale>();

            foreach(var sale in DatabaseManager.Transactions) {
                if(sale.SalesRepID == salesRep.ID) {
                    filteredSales.Add(sale);
                }
            }

            ReportForm newReportForm = new ReportForm($"Sales by {salesRep.FullName}", filteredSales);
            newReportForm.ShowDialog();
        }

        // Event Handlers
        private void OnCloseButtonClick(object sender, EventArgs e) {
            Close();
        }
        private void OnGenerateButtonClick(object sender, EventArgs e) {
            RunReport();
        }
    }
}
