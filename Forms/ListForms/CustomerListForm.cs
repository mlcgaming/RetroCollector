using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RetroCollector.Models;
using RetroCollector.Data.Management;

namespace RetroCollector {
    public partial class CustomerListForm : Form {
        private UserAccount activeUser;

        public CustomerListForm(UserAccount activeUser) {
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
            listAllCustomers.SelectedIndexChanged -= OnCustomerSelectionIndexChanged;

            // Set Control Defaults
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnNew.Enabled = true;

            // Populate Lists
            listAllCustomers.Items.Clear();

            foreach(var customer in DatabaseManager.Customers) {
                listAllCustomers.Items.Add(customer);
            }

            // Enable Events
            btnNew.Click += OnNewButtonClicked;
            btnEdit.Click += OnEditButtonClicked;
            btnDelete.Click += OnDeleteButtonClicked;
            tboxSearchNames.TextChanged += OnSearchTextChanged;
            listAllCustomers.SelectedIndexChanged += OnCustomerSelectionIndexChanged;
        }

        // Event Handlers
        private void OnNewButtonClicked(object sender, EventArgs e) {
            NewCustomerForm newForm = new NewCustomerForm(activeUser);
            newForm.FormSaved += OnFormSaved;
            newForm.ShowDialog();
        }
        private void OnEditButtonClicked(object sender, EventArgs e) {
            Customer selectedCustomer = listAllCustomers.SelectedItem as Customer;
            EditCustomerForm editForm = new EditCustomerForm(activeUser, selectedCustomer);
            editForm.FormSaved += OnFormSaved;
            editForm.ShowDialog();
        }
        private void OnDeleteButtonClicked(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Delete the Customer?", "This is an irreversible action.", MessageBoxButtons.YesNo);

            if(result == DialogResult.Yes) {
                Customer customer = listAllCustomers.SelectedItem as Customer;

                DatabaseManager.DeleteCustomer(customer);

                ResetForm();
            }
        }

        private void OnSearchTextChanged(object sender, EventArgs e) {
            // Disable Events
            btnNew.Click -= OnNewButtonClicked;
            btnEdit.Click -= OnEditButtonClicked;
            btnDelete.Click -= OnDeleteButtonClicked;
            tboxSearchNames.TextChanged -= OnSearchTextChanged;
            listAllCustomers.SelectedIndexChanged -= OnCustomerSelectionIndexChanged;

            // Set Control Defaults
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnNew.Enabled = true;

            // Populate Lists
            listAllCustomers.Items.Clear();

            IEnumerable<Customer> filteredCustomers =
                from c in DatabaseManager.Customers
                where c.FullName.ToUpper().Contains(tboxSearchNames.Text.ToUpper())
                select c;

            foreach(var customer in filteredCustomers) {
                listAllCustomers.Items.Add(customer);
            }

            // Enable Events
            btnNew.Click += OnNewButtonClicked;
            btnEdit.Click += OnEditButtonClicked;
            btnDelete.Click += OnDeleteButtonClicked;
            tboxSearchNames.TextChanged += OnSearchTextChanged;
            listAllCustomers.SelectedIndexChanged += OnCustomerSelectionIndexChanged;
        }
        private void OnCustomerSelectionIndexChanged(object sender, EventArgs e) {
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void OnFormSaved(object sender, EventArgs e) {
            ResetForm();
        }
    }
}
