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
    public partial class ProductListForm : Form {
        private UserAccount activeUser;

        public ProductListForm(UserAccount activeUser) {
            InitializeComponent();

            this.activeUser = activeUser;

            ResetForm();
        }

        // Methods
        private void ResetForm() {
            // Disable Events
            btnNew.Click -= OnNewButtonClicked;
            btnEdit.Click -= OnEditButtonClicked;
            btnDelete.Click -= OnDeleteButtonClicked;
            tboxSearchNames.TextChanged -= OnSearchTextChanged;
            listAllProducts.SelectedIndexChanged -= OnSelectionIndexChanged;

            // Set Control Defaults
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnNew.Enabled = true;

            // Populate Lists
            listAllProducts.Items.Clear();

            foreach(var customer in ProductManager.Products) {
                listAllProducts.Items.Add(customer);
            }

            // Enable Events
            btnNew.Click += OnNewButtonClicked;
            btnEdit.Click += OnEditButtonClicked;
            btnDelete.Click += OnDeleteButtonClicked;
            tboxSearchNames.TextChanged += OnSearchTextChanged;
            listAllProducts.SelectedIndexChanged += OnSelectionIndexChanged;
        }

        // Event Handlers
        private void OnNewButtonClicked(object sender, EventArgs e) {

        }
        private void OnEditButtonClicked(object sender, EventArgs e) {

        }
        private void OnDeleteButtonClicked(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Delete the Product?", "This is an irreversible action.", MessageBoxButtons.YesNo);

            if(result == DialogResult.Yes) {
                Product product = listAllProducts.SelectedItem as Product;

                DatabaseManager.DeleteProduct(product);
            }
        }

        private void OnSearchTextChanged(object sender, EventArgs e) {
            // Disable Events
            btnNew.Click -= OnNewButtonClicked;
            btnEdit.Click -= OnEditButtonClicked;
            btnDelete.Click -= OnDeleteButtonClicked;
            tboxSearchNames.TextChanged -= OnSearchTextChanged;
            listAllProducts.SelectedIndexChanged -= OnSelectionIndexChanged;

            // Set Control Defaults
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnNew.Enabled = true;

            // Populate Lists
            listAllProducts.Items.Clear();

            IEnumerable<Customer> filteredCustomers =
                from c in DatabaseManager.Customers
                where c.FullName.ToUpper().Contains(tboxSearchNames.Text.ToUpper())
                select c;

            foreach(var customer in filteredCustomers) {
                listAllProducts.Items.Add(customer);
            }

            // Enable Events
            btnNew.Click += OnNewButtonClicked;
            btnEdit.Click += OnEditButtonClicked;
            btnDelete.Click += OnDeleteButtonClicked;
            tboxSearchNames.TextChanged += OnSearchTextChanged;
            listAllProducts.SelectedIndexChanged += OnSelectionIndexChanged;
        }
        private void OnSelectionIndexChanged(object sender, EventArgs e) {
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void OnFormSaved(object sender, EventArgs e) {
            ResetForm();
        }
    }
}
