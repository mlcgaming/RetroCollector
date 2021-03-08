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
    public partial class ProductTypeListForm : Form {
        private UserAccount activeUser;

        public ProductTypeListForm(UserAccount activeUser) {
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
            listAllTypes.SelectedIndexChanged -= OnSelectionIndexChanged;

            // Set Control Defaults
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnNew.Enabled = true;

            // Populate Lists
            listAllTypes.Items.Clear();

            foreach(var type in ProductManager.ProductTypes) {
                listAllTypes.Items.Add(type);
            }

            // Enable Events
            btnNew.Click += OnNewButtonClicked;
            btnEdit.Click += OnEditButtonClicked;
            btnDelete.Click += OnDeleteButtonClicked;
            tboxSearchNames.TextChanged += OnSearchTextChanged;
            listAllTypes.SelectedIndexChanged += OnSelectionIndexChanged;
        }

        // Event Handlers
        private void OnNewButtonClicked(object sender, EventArgs e) {

        }
        private void OnEditButtonClicked(object sender, EventArgs e) {

        }
        private void OnDeleteButtonClicked(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Delete the Product Type?", "This is an irreversible action.", MessageBoxButtons.YesNo);

            if(result == DialogResult.Yes) {
                ProductType type = listAllTypes.SelectedItem as ProductType;

                DatabaseManager.DeleteProductType(type);
            }
        }

        private void OnSearchTextChanged(object sender, EventArgs e) {
            // Disable Events
            btnNew.Click -= OnNewButtonClicked;
            btnEdit.Click -= OnEditButtonClicked;
            btnDelete.Click -= OnDeleteButtonClicked;
            tboxSearchNames.TextChanged -= OnSearchTextChanged;
            listAllTypes.SelectedIndexChanged -= OnSelectionIndexChanged;

            // Set Control Defaults
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnNew.Enabled = true;

            // Populate Lists
            listAllTypes.Items.Clear();

            IEnumerable<ProductType> filteredItems =
                from type in ProductManager.ProductTypes
                where type.Name.ToUpper().Contains(tboxSearchNames.Text.ToUpper())
                select type;

            foreach(var type in filteredItems) {
                listAllTypes.Items.Add(type);
            }

            // Enable Events
            btnNew.Click += OnNewButtonClicked;
            btnEdit.Click += OnEditButtonClicked;
            btnDelete.Click += OnDeleteButtonClicked;
            tboxSearchNames.TextChanged += OnSearchTextChanged;
            listAllTypes.SelectedIndexChanged += OnSelectionIndexChanged;
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
