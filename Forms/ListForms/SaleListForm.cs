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
    public partial class SaleListForm : Form {
        private UserAccount activeUser;

        public SaleListForm(UserAccount activeUser) {
            InitializeComponent();

            this.activeUser = activeUser;

            ResetForm();
        }

        // Methosd
        private void ResetForm() {
            // Disable Events, if any
            listAllSales.SelectedIndexChanged -= OnNewSaleSelected;
            dtpFromDate.ValueChanged -= OnNewDateSelected;
            dtpToDate.ValueChanged -= OnNewDateSelected;
            btnNew.Click -= OnNewSaleClicked;
            btnEdit.Click -= OnEditSaleClicked;
            btnDelete.Click -= OnDeleteSaleClicked;
            btnSearchDate.Click -= OnSearchButtonClicked;

            // Set Control Defaults
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnNew.Enabled = true;

            // Populate Main List
            listAllSales.Items.Clear();

            foreach(var sale in DatabaseManager.Transactions) {
                listAllSales.Items.Add(sale);
            }

            // Enable All Events
            listAllSales.SelectedIndexChanged += OnNewSaleSelected;
            dtpFromDate.ValueChanged += OnNewDateSelected;
            dtpToDate.ValueChanged += OnNewDateSelected;
            btnNew.Click += OnNewSaleClicked;
            btnEdit.Click += OnEditSaleClicked;
            btnDelete.Click += OnDeleteSaleClicked;
            btnSearchDate.Click += OnSearchButtonClicked;
        }

        private void ValidateForm() {
            bool formIsValid = true;

            if(dtpFromDate.Value > dtpToDate.Value) {
                formIsValid = false;
            }

            if(formIsValid) {
                btnSearchDate.Enabled = true;
            }
            else {
                btnSearchDate.Enabled = false;
            }
        }

        // Event Handlers
        private void OnSearchButtonClicked(object sender, EventArgs e) {

        }
        private void OnNewSaleClicked(object sender, EventArgs e) {
            NewSaleForm newSaleForm = new NewSaleForm(activeUser);
            newSaleForm.FormSaved += OnSaleFormSaved;
            newSaleForm.ShowDialog();
        }
        private void OnEditSaleClicked(object sender, EventArgs e) {
            TransactionSale selectedSale = listAllSales.SelectedItem as TransactionSale;
            EditSaleForm editSaleForm = new EditSaleForm(activeUser, selectedSale);
            editSaleForm.FormSaved += OnSaleFormSaved;
            editSaleForm.ShowDialog();
        }
        private void OnDeleteSaleClicked(object sender, EventArgs e) {
            TransactionSale selectedSale = listAllSales.SelectedItem as TransactionSale;

            DialogResult result = MessageBox.Show("Permanently Delete Sale?", "This is irreversible.", MessageBoxButtons.YesNo);

            if(result == DialogResult.Yes) {
                DatabaseManager.DeleteTransaction(selectedSale);

                ResetForm();
            }
        }
        
        private void OnNewSaleSelected(object sender, EventArgs e) {
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
        }
        private void OnNewDateSelected(object sender, EventArgs e) {

        }

        private void OnSaleFormSaved(object sender, EventArgs e) {
            ResetForm();
        }
    }
}
