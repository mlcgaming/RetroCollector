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

namespace RetroCollector {
    public partial class AddNewItemToSaleForm : Form {
        public event EventHandler<NewLineItemAddedEventArgs> ItemAdded;

        private Product addedProduct;
        private int transactionId;

        public AddNewItemToSaleForm(Product product, int transactionId) {
            InitializeComponent();

            addedProduct = product;
            this.transactionId = transactionId;
            ResetForm();
        }

        // Methods
        private void ResetForm() {
            // Disable All Events, if any
            btnSaveLineItem.Click -= OnSaveItemClicked;
            btnCancelItem.Click -= OnCancelItemClicked;
            numProductQuantity.ValueChanged -= OnValueChanged;

            // Set Default Values
            tboxProductName.Text = addedProduct.Name;
            numProductQuantity.Value = 1;
            numProductQuantity.Maximum = addedProduct.OnHand;
            tboxProductTotal.Text = $"${numProductQuantity.Value * addedProduct.Price}";

            // Enable Controls
            btnCancelItem.Enabled = true;
            btnSaveLineItem.Enabled = true;

            btnSaveLineItem.Click += OnSaveItemClicked;
            btnCancelItem.Click += OnCancelItemClicked;
            numProductQuantity.ValueChanged += OnValueChanged;
        }

        private void ValidateForm() {
            bool formIsValid = true;

            if(string.IsNullOrWhiteSpace(tboxProductName.Text)) {
                formIsValid = false;
            }

            if(string.IsNullOrWhiteSpace(tboxProductTotal.Text)) {
                formIsValid = false;
            }

            if(numProductQuantity.Value <= 0) {
                formIsValid = false;
            }

            if(formIsValid) {
                btnSaveLineItem.Enabled = true;
            }
            else {
                btnSaveLineItem.Enabled = false;
            }
        }

        // Event Handlers
        private void OnSaveItemClicked(object sender, EventArgs e) {
            TransactionLineItem newLineItem = new TransactionLineItem(transactionId, addedProduct.ID, (int)numProductQuantity.Value, addedProduct.Price);

            ItemAdded?.Invoke(null, new NewLineItemAddedEventArgs(newLineItem));
            Close();
        }
        private void OnCancelItemClicked(object sender, EventArgs e) {
            Close();
        }

        private void OnValueChanged(object sender, EventArgs e) {
            tboxProductTotal.Text = $"${numProductQuantity.Value * addedProduct.Price}";
            ValidateForm();
        }
    }
}
