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
    public partial class NewProductForm : Form {
        public event EventHandler FormSaved;

        private UserAccount activeUser;
        private Product selectedProduct;

        public NewProductForm(UserAccount activeUser, Product selectedProduct = null) {
            InitializeComponent();

            this.activeUser = activeUser;
            this.selectedProduct = selectedProduct;

            ResetForm(selectedProduct);
        }

        // Methods
        private void ResetForm(Product selectedProduct = null) {
            // Disable Events
            btnFormSave.Click -= OnSaveButtonClick;
            btnFormCancel.Click -= OnCancelButtonClick;
            tboxProductName.TextChanged -= OnFormChanged;
            tboxProductCost.TextChanged -= OnFormChanged;
            tboxProductPrice.TextChanged -= OnFormChanged;
            tboxProductOnHand.TextChanged -= OnFormChanged;
            cboxProductType.SelectedIndexChanged -= OnProductTypeChanged;

            // Populate Lists
            cboxProductType.Items.Clear();
            cboxProductConsoles.Items.Clear();
            cboxProductDevelopers.Items.Clear();
            cboxProductQuality.Items.Clear();
            cboxProductRegion.Items.Clear();
            cboxProductCompleteness.Items.Clear();

            cboxProductCompleteness.DataSource = Enum.GetNames(typeof(Product.ProductCompleteness));
            cboxProductRegion.DataSource = Enum.GetNames(typeof(Product.ProductRegion));
            cboxProductQuality.DataSource = Enum.GetNames(typeof(Product.ProductQuality));
            
            foreach(var type in ProductManager.ProductTypes) {
                cboxProductType.Items.Add(type);
            }

            foreach(var developer in DatabaseManager.Companies) {
                cboxProductDevelopers.Items.Add(developer);
            }

            ResetConsoleList();

            // Set Control Defaults
            cboxProductType.SelectedIndex = 0;
            cboxProductRegion.SelectedIndex = 0;
            cboxProductQuality.SelectedIndex = 0;
            cboxProductDevelopers.SelectedIndex = 0;
            cboxProductConsoles.SelectedIndex = 0;
            cboxProductCompleteness.SelectedIndex = 0;

            tboxProductId.Text = $"{selectedProduct?.ID ?? DatabaseManager.GetNewProductID()}";
            tboxProductName.Text = $"{selectedProduct?.Name ?? ""}";
            tboxProductDescription.Text = $"{selectedProduct?.Description ?? ""}";
            tboxProductCost.Text = $"{selectedProduct?.Cost}";
            tboxProductPrice.Text = $"{selectedProduct?.Price}";
            tboxProductOnHand.Text = $"{selectedProduct?.OnHand}";

            lblCreatedByValue.Text = $"{selectedProduct?.CreatedBy ?? ""}";
            lblDateCreatedValue.Text = $"{selectedProduct?.DateCreated ?? DateTime.Now}";
            lblLastUpdatedByValue.Text = $"{selectedProduct?.LastUpdatedBy ?? ""}";
            lblDateLastUpdatedValue.Text = $"{selectedProduct?.LastUpdated ?? DateTime.Now}";

            // Enable Events
            btnFormSave.Click += OnSaveButtonClick;
            btnFormCancel.Click += OnCancelButtonClick;
            tboxProductName.TextChanged += OnFormChanged;
            tboxProductCost.TextChanged += OnFormChanged;
            tboxProductPrice.TextChanged += OnFormChanged;
            tboxProductOnHand.TextChanged += OnFormChanged;
            cboxProductType.SelectedIndexChanged += OnProductTypeChanged;
        }

        private void ValidateForm() {
            bool formIsValid = true;

            if(string.IsNullOrWhiteSpace(tboxProductName.Text)) {
                formIsValid = false;
            }

            if(string.IsNullOrWhiteSpace(tboxProductCost.Text)) {
                formIsValid = false;
            }
            else {
                if(decimal.TryParse(tboxProductCost.Text, out decimal cost) == false) {
                    formIsValid = false;
                }
            }

            if(string.IsNullOrWhiteSpace(tboxProductPrice.Text)) {
                formIsValid = false;
            }
            else {
                if(decimal.TryParse(tboxProductPrice.Text, out decimal price) == false) {
                    formIsValid = false;
                }
            }

            if(string.IsNullOrWhiteSpace(tboxProductOnHand.Text)) {
                formIsValid = false;
            }
            else {
                if(int.TryParse(tboxProductOnHand.Text, out int onHand) == false) {
                    formIsValid = false;
                }
            }

            if(formIsValid) {
                btnFormSave.Enabled = true;
            }
            else {
                btnFormSave.Enabled = false;
            }
        }

        private void ResetConsoleList() {
            cboxProductConsoles.Items.Clear();

            foreach(var console in DatabaseManager.ConsoleTypes) {
                cboxProductConsoles.Items.Add(console);
            }

            cboxProductConsoles.SelectedIndex = 0;
        }

        // Event Handlers
        private void OnSaveButtonClick(object sender, EventArgs e) {
            ProductType newProductType = cboxProductType.SelectedItem as ProductType;

            Company developer = cboxProductDevelopers.SelectedItem as Company;

            Product.ProductQuality quality = (Product.ProductQuality)Enum.Parse(typeof(Product.ProductQuality), cboxProductQuality.SelectedValue.ToString());
            Product.ProductCompleteness completion = (Product.ProductCompleteness)Enum.Parse(typeof(Product.ProductCompleteness), cboxProductCompleteness.SelectedValue.ToString());
            Product.ProductRegion region = (Product.ProductRegion)Enum.Parse(typeof(Product.ProductRegion), cboxProductRegion.SelectedValue.ToString());

            if(newProductType.ID == ProductManager.GetProductTypeIDByName(DatabaseManager.ID_TYPE_NAME_GAME)) {
                ConsoleCategory console = cboxProductConsoles.SelectedItem as ConsoleCategory;

                VideoGame newGame = new VideoGame(
                    int.Parse(tboxProductId.Text), 
                    tboxProductName.Text, 
                    decimal.Parse(tboxProductCost.Text), 
                    decimal.Parse(tboxProductPrice.Text), 
                    int.Parse(tboxProductOnHand.Text),
                    quality, 
                    completion, 
                    region, 
                    newProductType.ID, 
                    console, 
                    tboxProductDescription.Text, 
                    developer, 
                    dtpProductReleaseDate.Value, 
                    DateTime.Now, 
                    DateTime.Now, 
                    activeUser.Username, 
                    activeUser.Username);

                DatabaseManager.AddNewProduct(newGame);
            }
            else if(newProductType.ID == ProductManager.GetProductTypeIDByName(DatabaseManager.ID_TYPE_NAME_CONSOLE)) {

                VideoGameConsole newConsole = new VideoGameConsole(
                    int.Parse(tboxProductId.Text), 
                    tboxProductName.Text, 
                    decimal.Parse(tboxProductCost.Text), 
                    decimal.Parse(tboxProductPrice.Text), 
                    int.Parse(tboxProductOnHand.Text),
                    developer, 
                    quality, 
                    completion, 
                    region, 
                    newProductType.ID, 
                    tboxProductDescription.Text, 
                    dtpProductReleaseDate.Value,
                    DateTime.Now,
                    DateTime.Now,
                    activeUser.Username, 
                    activeUser.Username);

                DatabaseManager.AddNewProduct(newConsole);
            }
            else if(newProductType.ID == ProductManager.GetProductTypeIDByName(DatabaseManager.ID_TYPE_NAME_PERIPHERAL)) {

                Peripheral newPeripheral = new Peripheral(
                    int.Parse(tboxProductId.Text),
                    tboxProductName.Text,
                    decimal.Parse(tboxProductCost.Text),
                    decimal.Parse(tboxProductPrice.Text),
                    int.Parse(tboxProductOnHand.Text),
                    developer,
                    quality,
                    completion,
                    region,
                    newProductType.ID, 
                    tboxProductDescription.Text,
                    dtpProductReleaseDate.Value,
                    DateTime.Now, 
                    DateTime.Now, 
                    activeUser.Username, 
                    activeUser.Username);

                DatabaseManager.AddNewProduct(newPeripheral);
            }
            else if(newProductType.ID == ProductManager.GetProductTypeIDByName(DatabaseManager.ID_TYPE_NAME_MERCHANDISE)) {

                GameMerchandise newMerch = new GameMerchandise(
                    int.Parse(tboxProductId.Text),
                    tboxProductName.Text,
                    decimal.Parse(tboxProductCost.Text),
                    decimal.Parse(tboxProductPrice.Text),
                    int.Parse(tboxProductOnHand.Text),
                    developer,
                    quality,
                    completion,
                    region,
                    newProductType.ID,
                    tboxProductDescription.Text,
                    dtpProductReleaseDate.Value,
                    DateTime.Now,
                    DateTime.Now,
                    activeUser.Username,
                    activeUser.Username);

                DatabaseManager.AddNewProduct(newMerch);
            }
            else if(newProductType.ID == ProductManager.GetProductTypeIDByName(DatabaseManager.ID_TYPE_NAME_SERVICE)) {

                ServiceProduct newService = new ServiceProduct(
                    int.Parse(tboxProductId.Text),
                    tboxProductName.Text,
                    tboxProductDescription.Text,
                    decimal.Parse(tboxProductCost.Text),
                    decimal.Parse(tboxProductPrice.Text),
                    newProductType.ID,
                    DateTime.Now,
                    DateTime.Now,
                    activeUser.Username,
                    activeUser.Username);

                DatabaseManager.AddNewProduct(newService);
            }
            else {
                Product newProduct = new Product(
                    int.Parse(tboxProductId.Text),
                    tboxProductName.Text,
                    tboxProductDescription.Text,
                    decimal.Parse(tboxProductCost.Text),
                    decimal.Parse(tboxProductPrice.Text),
                    int.Parse(tboxProductOnHand.Text),
                    developer,
                    quality,
                    completion,
                    region,
                    newProductType.ID,
                    DateTime.Now,
                    DateTime.Now,
                    activeUser.Username,
                    activeUser.Username);

                DatabaseManager.AddNewProduct(newProduct);
            }


            FormSaved?.Invoke(null, EventArgs.Empty);
            Close();
        }
        private void OnCancelButtonClick(object sender, EventArgs e) {
            Close();
        }

        private void OnProductTypeChanged(object sender, EventArgs e) {
            ProductType type = cboxProductType.SelectedItem as ProductType;

            if(type.ID == ProductManager.GetProductTypeIDByName(DatabaseManager.ID_TYPE_NAME_GAME)) {
                cboxProductConsoles.Enabled = true;
                ResetConsoleList();
            }
            else {
                cboxProductConsoles.Enabled = false;
            }
        }

        private void OnFormChanged(object sender, EventArgs e) {
            ValidateForm();
        }
    }
}
