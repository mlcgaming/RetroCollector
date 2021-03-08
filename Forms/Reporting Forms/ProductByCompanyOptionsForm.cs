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
    public partial class ProductByCompanyOptionsForm : Form {
        public ProductByCompanyOptionsForm() {
            InitializeComponent();

            ResetForm();
        }

        // Methods
        private void ResetForm() {
            // Disable Events
            btnClose.Click -= OnCloseButtonClick;
            btnRun.Click -= OnRunButtonClick;

            // Populate Lists
            foreach(var company in DatabaseManager.Companies) {
                cboxDevelopers.Items.Add(company);
            }

            // Set Control Defaults
            cboxDevelopers.SelectedIndex = 0;
            btnClose.Enabled = true;
            btnRun.Enabled = true;

            // Enable Events;
            btnClose.Click += OnCloseButtonClick;
            btnRun.Click += OnRunButtonClick;
        }

        private void RunReport(Company developer) {
            listReportedItems.Items.Clear();

            foreach(var p in ProductManager.Products) {
                Product product = p as Product;

                if(product.Developer == developer) {
                    listReportedItems.Items.Add(product);
                }
            }
        }

        // Event Handlers
        private void OnCloseButtonClick(object sender, EventArgs e) {
            Close();
        }
        private void OnRunButtonClick(object sender, EventArgs e) {
            Company developer = cboxDevelopers.SelectedItem as Company;
            RunReport(developer);
        }
    }
}
