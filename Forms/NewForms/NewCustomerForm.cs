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
    public partial class NewCustomerForm : Form {
        public event EventHandler FormSaved;

        private UserAccount activeUser;

        public NewCustomerForm(UserAccount activeUser, Customer customer = null) {
            InitializeComponent();

            this.activeUser = activeUser;

            ResetForm(customer);
        }

        // Methods
        private void ResetForm(Customer customer = null) {
            // Disable Events
            tboxCustomerFirstName.TextChanged -= OnTextChanged;
            tboxCustomerLastName.TextChanged -= OnTextChanged;
            tboxCustomerAddress1.TextChanged -= OnTextChanged;
            tboxCustomerAddress2.TextChanged -= OnTextChanged;
            tboxCustomerCity.TextChanged -= OnTextChanged;
            tboxCustomerStateAbbr.TextChanged -= OnTextChanged;
            tboxCustomerZipCode.TextChanged -= OnTextChanged;
            tboxCustomerPhone.TextChanged -= OnTextChanged;
            tboxCustomerEmail.TextChanged -= OnTextChanged;
            btnFormSave.Click -= OnSaveButtonClick;
            btnFormCancel.Click -= OnCancelButtonClick;

            // Set Control Defaults
            tboxCustomerId.Text = $"{DatabaseManager.GetNewCustomerID()}";
            tboxCustomerFirstName.Text = $"{customer?.FirstName ?? ""}";
            tboxCustomerLastName.Text = $"{customer?.LastName ?? ""}";
            tboxCustomerAddress1.Text = $"{customer?.Address1 ?? ""}";
            tboxCustomerAddress2.Text = $"{customer?.Address2 ?? ""}";
            tboxCustomerCity.Text = $"{customer?.City ?? ""}";
            tboxCustomerStateAbbr.Text = $"{customer?.StateAbbr ?? ""}";
            tboxCustomerZipCode.Text = $"{customer?.ZipCode ?? ""}";
            tboxCustomerPhone.Text = $"{customer?.Phone ?? ""}";
            tboxCustomerEmail.Text = $"{customer?.Email ?? ""}";

            lblCreatedByValue.Text = $"{customer?.CreatedBy ?? activeUser.Username}";
            lblLastUpdatedByValue.Text = $"{customer?.LastUpdatedBy ?? activeUser.Username}";
            lblDateCreatedValue.Text = $"{customer?.DateCreated.Date ?? DateTime.Now.Date:yyyy-MM-dd}";
            lblDateLastUpdatedValue.Text = $"{customer?.LastUpdated.Date ?? DateTime.Now.Date:yyyy-MM-dd}";

            // Enable Events
            tboxCustomerFirstName.TextChanged += OnTextChanged;
            tboxCustomerLastName.TextChanged += OnTextChanged;
            tboxCustomerAddress1.TextChanged += OnTextChanged;
            tboxCustomerAddress2.TextChanged += OnTextChanged;
            tboxCustomerCity.TextChanged += OnTextChanged;
            tboxCustomerStateAbbr.TextChanged += OnTextChanged;
            tboxCustomerZipCode.TextChanged += OnTextChanged;
            tboxCustomerPhone.TextChanged += OnTextChanged;
            tboxCustomerEmail.TextChanged += OnTextChanged;
            btnFormSave.Click += OnSaveButtonClick;
            btnFormCancel.Click += OnCancelButtonClick;
        }

        private void ValidateForm() {
            bool formIsValid = true;

            if(string.IsNullOrWhiteSpace(tboxCustomerFirstName.Text)) {
                formIsValid = false;
            }

            if(string.IsNullOrWhiteSpace(tboxCustomerLastName.Text)) {
                formIsValid = false;
            }

            if(string.IsNullOrWhiteSpace(tboxCustomerAddress1.Text)) {
                formIsValid = false;
            }

            if(string.IsNullOrWhiteSpace(tboxCustomerCity.Text)) {
                formIsValid = false;
            }

            if(string.IsNullOrWhiteSpace(tboxCustomerStateAbbr.Text)) {
                formIsValid = false;
            }

            if(string.IsNullOrWhiteSpace(tboxCustomerZipCode.Text)) {
                formIsValid = false;
            }

            if(string.IsNullOrWhiteSpace(tboxCustomerPhone.Text)) {
                formIsValid = false;
            }

            if(string.IsNullOrWhiteSpace(tboxCustomerEmail.Text)) {
                formIsValid = false;
            }

            if(formIsValid) {
                btnFormSave.Enabled = true;
            }
            else {
                btnFormSave.Enabled = false;
            }
        }

        // Event Handlers
        private void OnSaveButtonClick(object sender, EventArgs e) {
            Customer newCustomer = new Customer(int.Parse(tboxCustomerId.Text), tboxCustomerFirstName.Text, tboxCustomerLastName.Text, tboxCustomerEmail.Text, tboxCustomerAddress1.Text, tboxCustomerAddress2.Text,
                tboxCustomerCity.Text, tboxCustomerStateAbbr.Text, tboxCustomerZipCode.Text, tboxCustomerPhone.Text, DateTime.Now, DateTime.Now, activeUser.Username, activeUser.Username);

            DatabaseManager.AddNewCustomer(newCustomer);

            FormSaved?.Invoke(null, EventArgs.Empty);
            Close();
        }
        private void OnCancelButtonClick(object sender, EventArgs e) {
            Close();
        }

        private void OnTextChanged(object sender, EventArgs e) {
            ValidateForm();
        }
    }
}
