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
    public partial class EditSaleForm : Form {
        public event EventHandler FormSaved;

        private UserAccount activeUser;
        private UserAccount salesRep;

        public EditSaleForm(UserAccount activeUser, TransactionSale selectedSale) {
            InitializeComponent();

            this.activeUser = activeUser;

            ResetForm(selectedSale);
        }

        // Methods
        private void ResetForm(TransactionSale sale) {
            // Disable All Events
            btnSaleCancel.Click -= OnCancelSaleClicked;
            btnSaleProcess.Click -= OnProcessSaleClicked;

            // Set Default Control States
            btnRemoveSaleItem.Enabled = false;
            btnSaleProcess.Enabled = false;
            grpAllProducts.Enabled = false;
            grpSaleItems.Enabled = false;
            grpSaleTotals.Enabled = false;
            grpSalePayment.Enabled = false;

            tboxSalesRep.Text = salesRep?.Username ?? "";
            tboxSaleDescription.Text = sale.Description;
            tboxSaleId.Text = $"{sale.ID}";
            tboxSaleDate.Text = $"{sale.DateOfSale.Date:yyyy-MM-dd}";


            // Configure DropDowns and Lists
            listAllProducts.Items.Clear();
            listAllSaleItems.Items.Clear();

            foreach(var p in ProductManager.Products) {
                Product prod = p as Product;
                listAllProducts.Items.Add(prod);
            }
            foreach(var lineItem in sale.Items) {
                listAllSaleItems.Items.Add(lineItem);
            }

            foreach(var customer in DatabaseManager.Customers) {
                cboxSalesCustomers.Items.Add(customer);
            }

            cboxSalesCustomers.SelectedItem = DatabaseManager.GetCustomerById(sale.CustomerID);

            lblCreatedByValue.Text = salesRep?.Username ?? "";
            lblDateCreatedValue.Text = $"{sale.DateCreated.Date:yyyy-MM-dd}";
            lblLastUpdatedByValue.Text = activeUser.Username;
            lblDateLastUpdatedValue.Text = $"{DateTime.Now.Date:yyyy-MM-dd}";

            CalculateLineItemTotals();

            ValidateForm();

            // Enable All Events
            btnSaleCancel.Click += OnCancelSaleClicked;
            btnSaleProcess.Click += OnProcessSaleClicked;
        }
        private void ValidateForm() {
            bool formIsValid = true;

            if(string.IsNullOrWhiteSpace(tboxSaleId.Text)) {
                formIsValid = false;
            }

            if(string.IsNullOrWhiteSpace(tboxSalesRep.Text)) {
                formIsValid = false;
            }

            if(decimal.TryParse(tboxSalesTenderedAmount.Text, out decimal amtTendered) == false) {
                formIsValid = false;
            }
            else {
                if(decimal.Parse(tboxSalesTenderedAmount.Text) < decimal.Parse(tboxSalesTotal.Text)) {
                    formIsValid = false;
                }
            }

            if(formIsValid) {
                btnSaleProcess.Enabled = true;

                decimal changeDue = (decimal.Parse(tboxSalesTenderedAmount.Text) - decimal.Parse(tboxSalesTotal.Text));
                tboxSalesChangeDue.Text = $"{changeDue}";
            }
            else {
                btnSaleProcess.Enabled = false;
                tboxSalesChangeDue.Text = "";
            }
        }
        private void CalculateLineItemTotals() {
            decimal subTotal = 0M;

            foreach(var item in listAllSaleItems.Items) {
                TransactionLineItem lineItem = item as TransactionLineItem;

                subTotal += (lineItem.PricePerProduct * lineItem.Quantity);
            }

            tboxSaleSubtotal.Text = $"{string.Format("{0:.##}", subTotal)}";

            tboxTaxTotal.Text = $"{string.Format("{0:.##}", subTotal * 0.0815M)}";

            tboxSalesTotal.Text = $"{decimal.Parse(tboxSaleSubtotal.Text) + decimal.Parse(tboxTaxTotal.Text)}";
        }

        // Event Handlers
        private void OnProcessSaleClicked(object sender, EventArgs e) {
            int id = int.Parse(tboxSaleId.Text);
            string description = tboxSaleDescription.Text;
            DateTime dateOfSale = DateTime.Now;
            int salesRepId = salesRep.ID;
            Customer selectedCustomer = cboxSalesCustomers.SelectedItem as Customer;
            int customerId = selectedCustomer.ID;
            DateTime dateCreated = DateTime.Now;
            DateTime dateLastUpdated = DateTime.Now;
            string createdBy = salesRep.Username;
            string lastUpdatedBy = salesRep.Username;

            TransactionSale newSale = new TransactionSale(id, description, dateOfSale, salesRepId, customerId, dateCreated, dateLastUpdated, createdBy, lastUpdatedBy);

            foreach(var item in listAllSaleItems.Items) {
                TransactionLineItem newItem = item as TransactionLineItem;
                newSale.AddLineItem(newItem);
            }

            DatabaseManager.AddNewTransaction(newSale);

            FormSaved?.Invoke(null, EventArgs.Empty);
            Close();
        }
        private void OnCancelSaleClicked(object sender, EventArgs e) {
            Close();
        }
        private void OnAddItemClicked(object sender, EventArgs e) {
            Product selectedProduct = listAllProducts.SelectedItem as Product;

            AddNewItemToSaleForm newItemForm = new AddNewItemToSaleForm(selectedProduct, int.Parse(tboxSaleId.Text));
            newItemForm.ItemAdded += OnNewItemAdded;
            newItemForm.ShowDialog();
        }
        private void OnRemoveItemClicked(object sender, EventArgs e) {
            TransactionLineItem selectedItem = listAllSaleItems.SelectedItem as TransactionLineItem;
            listAllSaleItems.Items.Remove(selectedItem);
            OnLineItemCountChanged();
        }
        private void OnNewCustomerClicked(object sender, EventArgs e) {

        }

        private void OnSearchTextChanged(object sender, EventArgs e) {
            // Disable Component Events
            tboxProductSearch.TextChanged -= OnSearchTextChanged;
            listAllProducts.SelectedIndexChanged -= OnProductItemSelectedChanged;

            // Create Unfiltered Product List using Specified Product Type
            List<Product> unfilteredProducts = new List<Product>();

            foreach(var p in ProductManager.Products) {
                unfilteredProducts.Add(p as Product);
            }

            // Create Filtered Products List
            List<Product> filteredProducts = new List<Product>();

            foreach(var product in unfilteredProducts) {
                if(product.Name.ToUpper().Contains(tboxProductSearch.Text.ToUpper())) {
                    filteredProducts.Add(product);
                }
            }

            // Clear the Current Items List and Fill with Filtered Results
            listAllProducts.Items.Clear();
            foreach(var p in filteredProducts) {
                listAllProducts.Items.Add(p);
            }

            // Enable Component Events
            tboxProductSearch.TextChanged += OnSearchTextChanged;
            listAllProducts.SelectedIndexChanged += OnProductItemSelectedChanged;
        }
        private void OnAmountTenderedChanged(object sender, EventArgs e) {
            ValidateForm();
        }

        private void OnLineItemSelectedChanged(object sender, EventArgs e) {
            btnRemoveSaleItem.Enabled = true;
        }
        private void OnProductItemSelectedChanged(object sender, EventArgs e) {
            btnAddProductToItems.Enabled = true;
        }
        private void OnLineItemCountChanged() {
            if(listAllSaleItems.Items.Count > 0) {
                CalculateLineItemTotals();
                ValidateForm();
            }
        }

        private void OnNewItemAdded(object sender, NewLineItemAddedEventArgs e) {
            listAllSaleItems.Items.Add(e.LineItem);
            OnLineItemCountChanged();
        }
        private void OnFormSaved(object sender, EventArgs e) {

        }
    }
}
