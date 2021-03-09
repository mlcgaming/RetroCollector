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
    public partial class SalesByDateOptionsForm : Form {
        public SalesByDateOptionsForm() {
            InitializeComponent();

            ResetForm();
        }

        // Methods
        private void ResetForm() {
            // Disable Events
            btnClose.Click -= OnCloseButtonClick;
            btnRun.Click -= OnGenerateButtonClick;
            dtpFromDate.ValueChanged -= OnDatesChanged;
            dtpToDate.ValueChanged -= OnDatesChanged;

            // Set Control Defaults
            dtpFromDate.Value = DateTime.Now;
            dtpToDate.Value = DateTime.Now;
            btnClose.Enabled = true;
            btnRun.Enabled = false;

            // Enable Events
            btnClose.Click += OnCloseButtonClick;
            btnRun.Click += OnGenerateButtonClick;
            dtpFromDate.ValueChanged += OnDatesChanged;
            dtpToDate.ValueChanged += OnDatesChanged;
        }

        private void ValidateForm() {
            bool formIsValid = true;

            if(dtpFromDate.Value > dtpToDate.Value) {
                formIsValid = false;
            }

            if(formIsValid) {
                btnRun.Enabled = true;
            }
            else {
                btnRun.Enabled = false;
            }
        }

        // Event Handlers
        private void OnDatesChanged(object sender, EventArgs e) {
            ValidateForm();
        }
        private void OnGenerateButtonClick(object sender, EventArgs e) {
            List<TransactionSale> filteredSales = new List<TransactionSale>();

            foreach(var sale in DatabaseManager.Transactions) {
                if(sale.DateOfSale.Date >= dtpFromDate.Value.Date &&
                    sale.DateOfSale.Date <= dtpToDate.Value.Date) {

                    filteredSales.Add(sale);
                }
            }

            ReportForm newReportForm = new ReportForm($"Sales Between {dtpFromDate.Value:MMM dd yyyy} and {dtpToDate.Value:MMM dd yyyy}", filteredSales);
            newReportForm.ShowDialog();
        }
        private void OnCloseButtonClick(object sender, EventArgs e) {
            Close();
        }
    }
}
