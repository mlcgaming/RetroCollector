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

            productsByCompanyToolStripMenuItem.Click -= OnProductByCompanyMenuItemClick;
            salesByRepToolStripMenuItem.Click -= OnSalesByRepMenuItemClick;
            salesByDateToolStripMenuItem.Click -= OnSalesByDateMenuItemClick;
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

            btnProductAdd.Enabled = activeUser.IsAllowed(UserRole.Permission.AllowCreateProducts);
            btnProductEdit.Enabled = false;
            btnProductDelete.Enabled = false;

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
            btnControlConsoles.Click += OnControlConsolesClick;
            btnControlCustomers.Click += OnControlCustomersClick;
            btnControlProduct.Click += OnControlProductsClick;
            btnControlUser.Click += OnControlUsersClick;

            // Enable MenuItem Events
            databaseSettingsToolStripMenuItem.Click += OnDatabaseSettingsClick;
            productsByCompanyToolStripMenuItem.Click += OnProductByCompanyMenuItemClick;
            salesByRepToolStripMenuItem.Click += OnSalesByRepMenuItemClick;
            salesByDateToolStripMenuItem.Click += OnSalesByDateMenuItemClick;
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
            NewProductForm newForm = new NewProductForm(ActiveUser);
            newForm.FormSaved += OnProductsUpdated;
            newForm.ShowDialog();
        }
        private void OnEditProductClick(object sender, EventArgs e) {
            Product selectedProduct = listProducts.SelectedItem as Product;
            EditProductForm editForm = new EditProductForm(ActiveUser, selectedProduct);
            editForm.FormSaved += OnProductsUpdated;
            editForm.ShowDialog();
        }
        private void OnDeleteProductClick(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Delete the Product?", "This is an irreversible action.", MessageBoxButtons.YesNo);

            if(result == DialogResult.Yes) {
                Product product = listProducts.SelectedItem as Product;

                DatabaseManager.DeleteProduct(product);

                ResetForm();
            }
        }
        private void OnControlUsersClick(object sender, EventArgs e) {
            UserListForm listForm = new UserListForm(ActiveUser);
            listForm.ShowDialog();
        }
        private void OnControlCompaniesClick(object sender, EventArgs e) {
            CompanyListForm listForm = new CompanyListForm(ActiveUser);
            listForm.ShowDialog();
        }
        private void OnControlProductsClick(object sender, EventArgs e) {
            ProductListForm listForm = new ProductListForm(ActiveUser);
            listForm.ProductsUpdated += OnProductsUpdated;
            listForm.ShowDialog();
        }
        private void OnControlCustomersClick(object sender, EventArgs e) {
            CustomerListForm listForm = new CustomerListForm(ActiveUser);
            listForm.ShowDialog();
        }
        private void OnControlSalesClick(object sender, EventArgs e) {
            SaleListForm listForm = new SaleListForm(ActiveUser);
            listForm.ShowDialog();
        }
        private void OnControlConsolesClick(object sender, EventArgs e) {
            ConsoleListForm listForm = new ConsoleListForm(ActiveUser);
            listForm.ShowDialog();
        }

        private void OnProductByCompanyMenuItemClick(object sender, EventArgs e) {
            ProductByCompanyOptionsForm optionsForm = new ProductByCompanyOptionsForm();
            optionsForm.ShowDialog();
        }
        private void OnSalesByRepMenuItemClick(object sender, EventArgs e) {
            SalesByRepOptionsForm optionsForm = new SalesByRepOptionsForm();
            optionsForm.ShowDialog();
        }
        private void OnSalesByDateMenuItemClick(object sender, EventArgs e) {
            SalesByDateOptionsForm optionsForm = new SalesByDateOptionsForm();
            optionsForm.ShowDialog();
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
            btnProductDelete.Enabled = activeUser.IsAllowed(UserRole.Permission.AllowDeleteProducts);
            btnProductEdit.Enabled = activeUser.IsAllowed(UserRole.Permission.AllowEditProducts);
        }

        private void OnProductsUpdated(object sender, EventArgs e) {
            ResetForm();
        }
    }
}
