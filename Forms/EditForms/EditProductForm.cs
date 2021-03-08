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
    public partial class EditProductForm : Form {
        public event EventHandler FormSaved;

        private UserAccount activeUser;
        private Product selectedProduct;

        public EditProductForm(UserAccount activeUser, Product selectedProduct = null) {
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
            cboxProductType.SelectedItem = ProductManager.GetProductTypeByID(selectedProduct.ProductTypeID);
            cboxProductRegion.SelectedIndex = (int)selectedProduct.Region;
            cboxProductQuality.SelectedIndex = (int)selectedProduct.Quality;
            cboxProductDevelopers.SelectedItem = selectedProduct.Developer;
            cboxProductCompleteness.SelectedIndex = (int)selectedProduct.Completion;
            
            if(selectedProduct.ProductTypeID == ProductManager.GetProductTypeIDByName(DatabaseManager.ID_TYPE_NAME_GAME)) {
                VideoGame selectedGame = selectedProduct as VideoGame;
                cboxProductConsoles.SelectedItem = selectedGame.Console;
            }
            else {
                cboxProductConsoles.SelectedIndex = 0;
                cboxProductConsoles.Enabled = false;
            }

            cboxProductType.Enabled = false;

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

                VideoGame selectedGame = selectedProduct as VideoGame;

                selectedGame.Update(
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
                    selectedGame.DateCreated,
                    DateTime.Now,
                    selectedGame.CreatedBy,
                    activeUser.Username);

                DatabaseManager.UpdateProduct(selectedGame);
            }
            else if(newProductType.ID == ProductManager.GetProductTypeIDByName(DatabaseManager.ID_TYPE_NAME_CONSOLE)) {

                VideoGameConsole console = selectedProduct as VideoGameConsole;

                console.Update(
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
                    console.DateCreated,
                    DateTime.Now,
                    console.CreatedBy,
                    activeUser.Username);

                DatabaseManager.UpdateProduct(console);
            }
            else if(newProductType.ID == ProductManager.GetProductTypeIDByName(DatabaseManager.ID_TYPE_NAME_PERIPHERAL)) {

                Peripheral peripheral = selectedProduct as Peripheral;

                peripheral.Update(
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
                    peripheral.DateCreated,
                    DateTime.Now,
                    peripheral.CreatedBy,
                    activeUser.Username);

                DatabaseManager.UpdateProduct(peripheral);
            }
            else if(newProductType.ID == ProductManager.GetProductTypeIDByName(DatabaseManager.ID_TYPE_NAME_MERCHANDISE)) {

                GameMerchandise merch = selectedProduct as GameMerchandise;

                merch.Update(
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
                    merch.DateCreated,
                    DateTime.Now,
                    merch.CreatedBy,
                    activeUser.Username);

                DatabaseManager.UpdateProduct(merch);
            }
            else if(newProductType.ID == ProductManager.GetProductTypeIDByName(DatabaseManager.ID_TYPE_NAME_SERVICE)) {

                ServiceProduct service = selectedProduct as ServiceProduct;

                service.Update(
                    int.Parse(tboxProductId.Text),
                    tboxProductName.Text,
                    tboxProductDescription.Text,
                    decimal.Parse(tboxProductCost.Text),
                    decimal.Parse(tboxProductPrice.Text),
                    newProductType.ID,
                    service.DateCreated,
                    DateTime.Now,
                    service.CreatedBy,
                    activeUser.Username);

                DatabaseManager.UpdateProduct(service);
            }
            else {
                selectedProduct.Update(
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
                    selectedProduct.DateCreated,
                    DateTime.Now,
                    selectedProduct.CreatedBy,
                    activeUser.Username);

                DatabaseManager.UpdateProduct(selectedProduct);
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
