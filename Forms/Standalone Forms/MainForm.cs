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
    public partial class MainForm : Form {
        private UserAccount activeUser = null;
        
        public UserAccount ActiveUser {
            get => activeUser;
        }

        public MainForm() {
            InitializeComponent();

            DatabaseManager.Initialize();
            DatabaseManager.DatabaseReinitialized += OnDatabaseReinitialized;

            LoginForm userLogin = new LoginForm();
            userLogin.UserLoggedIn += OnUserLoggedIn;
            userLogin.FormClosed += OnLoginFormClosing;
            userLogin.ShowDialog();
        }

        // Methods
        private void ResetForm() {
            // Disable Events, if any
            btnProductAdd.Click -= OnNewProductClick;
            btnProductEdit.Click -= OnEditProductClick;
            btnProductDelete.Click -= OnDeleteProductClick;
            tboxSearchItems.TextChanged -= OnSearchTextChanged;
            cboxProductType.SelectedIndexChanged -= OnGroupDropDownIndexChanged;
            listProducts.SelectedIndexChanged -= OnNewItemSelected;

            btnControlSales.Click -= OnControlSalesClick;
            btnControlCompanies.Click -= OnControlCompaniesClick;
            btnControlConsoles.Click -= OnControlCompaniesClick;
            btnControlCustomers.Click -= OnControlCustomersClick;
            btnControlProduct.Click -= OnControlProductsClick;
            btnControlUser.Click -= OnControlUsersClick;

            // Disable MenuItem Events, if any
            databaseSettingsToolStripMenuItem.Click -= OnDatabaseSettingsClick;

            // Clear Items
            cboxProductType.Items.Clear();
            listProducts.Items.Clear();
            tboxSearchItems.Text = "";
            btnProductEdit.Enabled = false;
            btnProductDelete.Enabled = false;

            // Fill Dropdowns and Lists
            foreach(var type in ProductManager.ProductTypes) {
                cboxProductType.Items.Add(type);
            }
            cboxProductType.Items.Add("All"); // Additional Entry that will show ALL Products, rather than category
            cboxProductType.SelectedIndex = 0;

            foreach(var p in ProductManager.GetProductListByType(ProductManager.GetProductTypeByID(0))) {
                listProducts.Items.Add(p);
            }

            // Run SubMethods
            CalculateInventoryValue();

            // Set Default Enabled/Disabled
            adminToolStripMenuItem.Enabled = false;
            reportingToolStripMenuItem.Enabled = false;

            // Block Controls by Permissions
            if(activeUser.IsAllowed(UserRole.Permission.AllowAdminControls)) {
                adminToolStripMenuItem.Enabled = true;
            }

            if(activeUser.IsAllowed(UserRole.Permission.AllowReporting)) {
                reportingToolStripMenuItem.Enabled = true;
            }

            if(activeUser.IsAllowed(UserRole.Permission.AllowCreateProducts) ||
                activeUser.IsAllowed(UserRole.Permission.AllowEditProducts) ||
                activeUser.IsAllowed(UserRole.Permission.AllowDeleteProducts)) {

                btnProductAdd.Enabled = true;

                if(activeUser.IsAllowed(UserRole.Permission.AllowCreateProducts)) {
                    btnProductAdd.Enabled = true;
                }
                else {
                    btnProductAdd.Enabled = false;
                }
            }
            else {
                btnProductAdd.Enabled = false;
            }

            if(activeUser.IsAllowed(UserRole.Permission.AllowProcessSales)) {
                btnControlSales.Enabled = true;
            }
            else {
                btnControlSales.Enabled = false;
            }

            if(activeUser.IsAllowed(UserRole.Permission.AllowCreateUsers) ||
                activeUser.IsAllowed(UserRole.Permission.AllowEditUsers) ||
                activeUser.IsAllowed(UserRole.Permission.AllowDeleteUsers) ||
                activeUser.IsAllowed(UserRole.Permission.AllowCreateRoles) ||
                activeUser.IsAllowed(UserRole.Permission.AllowEditRoles) ||
                activeUser.IsAllowed(UserRole.Permission.AllowDeleteRoles)) {

                btnControlUser.Enabled = true;
            }
            else {
                btnControlUser.Enabled = false;
            }

            btnControlCompanies.Enabled = true;
            btnControlConsoles.Enabled = true;
            btnControlCustomers.Enabled = true;

            // Enable Events
            btnProductAdd.Click += OnNewProductClick;
            btnProductEdit.Click += OnEditProductClick;
            btnProductDelete.Click += OnDeleteProductClick;
            tboxSearchItems.TextChanged += OnSearchTextChanged;
            cboxProductType.SelectedIndexChanged += OnGroupDropDownIndexChanged;
            listProducts.SelectedIndexChanged += OnNewItemSelected;

            btnControlSales.Click += OnControlSalesClick;
            btnControlCompanies.Click += OnControlCompaniesClick;
            btnControlConsoles.Click += OnControlCompaniesClick;
            btnControlCustomers.Click += OnControlCustomersClick;
            btnControlProduct.Click += OnControlProductsClick;
            btnControlUser.Click += OnControlUsersClick;

            // Enable MenuItem Events
            databaseSettingsToolStripMenuItem.Click += OnDatabaseSettingsClick;
        }

        

        private void CalculateInventoryValue() {
            decimal totalGamesValue = ProductManager.GetTotalValueByProductType(ProductManager.GetProductTypeByID(0));
            decimal totalConsolesValue = ProductManager.GetTotalValueByProductType(ProductManager.GetProductTypeByID(1));
            decimal totalPeripheralValue = ProductManager.GetTotalValueByProductType(ProductManager.GetProductTypeByID(3));
            decimal totalMerchandiseValue = ProductManager.GetTotalValueByProductType(ProductManager.GetProductTypeByID(2));
            decimal totalValue = totalGamesValue + totalConsolesValue + totalPeripheralValue + totalMerchandiseValue;

            tboxTotalGameValue.Text = $"${totalGamesValue}";
            tboxTotalConsoleValue.Text = $"${totalConsolesValue}";
            tboxTotalPeripheralValue.Text = $"${totalPeripheralValue}";
            tboxTotalMerchValue.Text = $"${totalMerchandiseValue}";
            tboxTotalInventoryValue.Text = $"${totalValue}";
        }

        // Event Handlers
        private void OnUserLoggedIn(object sender, UserLoggedInEventArgs e) {
            activeUser = e.User;
        }
        private void OnLoginFormClosing(object sender, EventArgs e) {
            if(activeUser == null) {
                MessageBox.Show("No User Logged In. Closing.");
                Application.Exit();
            }
            else {
                ResetForm();
            }
        }
        private void OnDatabaseReinitialized(object sender, EventArgs e) {
            ResetForm();

            activeUser = null;

            LoginForm userLogin = new LoginForm();
            userLogin.UserLoggedIn += OnUserLoggedIn;
            userLogin.FormClosed += OnLoginFormClosing;
            userLogin.ShowDialog();
        }
        private void OnNewProductClick(object sender, EventArgs e) {

        }
        private void OnEditProductClick(object sender, EventArgs e) {

        }
        private void OnDeleteProductClick(object sender, EventArgs e) {

        }
        private void OnControlUsersClick(object sender, EventArgs e) {

        }
        private void OnControlCompaniesClick(object sender, EventArgs e) {

        }
        private void OnControlProductsClick(object sender, EventArgs e) {

        }
        private void OnControlCustomersClick(object sender, EventArgs e) {

        }
        private void OnControlSalesClick(object sender, EventArgs e) {
            SaleListForm listForm = new SaleListForm(ActiveUser);
            listForm.ShowDialog();
        }
        private void OnControlConsolesClick(object sender, EventArgs e) {

        }

        private void OnDatabaseSettingsClick(object sender, EventArgs e) {
            DatabaseSettingsForm dbSettings = new DatabaseSettingsForm();
            dbSettings.ShowDialog();
        }

        private void OnGroupDropDownIndexChanged(object sender, EventArgs e) {
            // Disable Component Events
            btnProductAdd.Click -= OnNewProductClick;
            btnProductEdit.Click -= OnEditProductClick;
            btnProductDelete.Click -= OnDeleteProductClick;
            tboxSearchItems.TextChanged -= OnSearchTextChanged;
            cboxProductType.SelectedIndexChanged -= OnGroupDropDownIndexChanged;
            listProducts.SelectedIndexChanged -= OnNewItemSelected;

            if(cboxProductType.SelectedIndex == cboxProductType.Items.Count - 1) {
                // Last Item Chosen, Which is ALL
                listProducts.Items.Clear();

                foreach(var p in ProductManager.Products) {
                    listProducts.Items.Add(p);
                }
            }
            else {
                // Clear Item List
                listProducts.Items.Clear();

                // Get Product Type
                ProductType type = cboxProductType.SelectedItem as ProductType;
                foreach(var p in ProductManager.GetProductListByType(type)) {
                    listProducts.Items.Add(p);
                }
            }

            // Set Defaults Again
            listProducts.SelectedIndex = default;
            btnProductDelete.Enabled = false;
            btnProductEdit.Enabled = false;

            // Enable Component Events
            btnProductAdd.Click += OnNewProductClick;
            btnProductEdit.Click += OnEditProductClick;
            btnProductDelete.Click += OnDeleteProductClick;
            tboxSearchItems.TextChanged += OnSearchTextChanged;
            cboxProductType.SelectedIndexChanged += OnGroupDropDownIndexChanged;
            listProducts.SelectedIndexChanged += OnNewItemSelected;
        }
        private void OnSearchTextChanged(object sender, EventArgs e) {
            // Disable Component Events
            btnProductAdd.Click -= OnNewProductClick;
            btnProductEdit.Click -= OnEditProductClick;
            btnProductDelete.Click -= OnDeleteProductClick;
            tboxSearchItems.TextChanged -= OnSearchTextChanged;
            cboxProductType.SelectedIndexChanged -= OnGroupDropDownIndexChanged;
            listProducts.SelectedIndexChanged -= OnNewItemSelected;

            // Create Unfiltered Product List using Specified Product Type
            List<Product> unfilteredProducts = new List<Product>();

            if(cboxProductType.SelectedIndex == cboxProductType.Items.Count - 1) {
                foreach(var p in ProductManager.Products) {
                    unfilteredProducts.Add(p as Product);
                }
            }
            else {
                // Get Product Type
                ProductType type = cboxProductType.SelectedItem as ProductType;
                foreach(var p in ProductManager.GetProductListByType(type)) {
                    unfilteredProducts.Add(p as Product);
                }
            }

            // Set Defaults Again
            btnProductDelete.Enabled = false;
            btnProductEdit.Enabled = false;

            // Create Filtered Products List
            List<Product> filteredProducts = new List<Product>();

            foreach(var product in unfilteredProducts) {
                if(product.Name.Contains(tboxSearchItems.Text)) {
                    filteredProducts.Add(product);
                }
            }

            // Clear the Current Items List and Fill with Filtered Results
            listProducts.Items.Clear();
            foreach(var p in filteredProducts) {
                listProducts.Items.Add(p);
            }

            // Enable Component Events
            btnProductAdd.Click += OnNewProductClick;
            btnProductEdit.Click += OnEditProductClick;
            btnProductDelete.Click += OnDeleteProductClick;
            tboxSearchItems.TextChanged += OnSearchTextChanged;
            cboxProductType.SelectedIndexChanged += OnGroupDropDownIndexChanged;
            listProducts.SelectedIndexChanged += OnNewItemSelected;
        }
        private void OnNewItemSelected(object sender, EventArgs e) {
            btnProductDelete.Enabled = true;
            btnProductEdit.Enabled = true;
        }
    }
}
