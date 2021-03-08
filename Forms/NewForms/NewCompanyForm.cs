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
    public partial class NewCompanyForm : Form {
        public event EventHandler FormSaved;

        private UserAccount activeUser;
        private Company selectedCompany;

        public NewCompanyForm(UserAccount activeUser, Company selectedCompany = null) {
            InitializeComponent();

            this.activeUser = activeUser;
            this.selectedCompany = selectedCompany;

            ResetForm(selectedCompany);
        }

        // Methods
        private void ResetForm(Company selectedCompany = null) {
            // Disable Events
            btnFormCancel.Click -= OnCancelButtonClick;
            btnFormSave.Click -= OnSaveButtonClick;
            tboxCompanyName.TextChanged -= OnTextChanged;

            // Set Control Defaults
            tboxCompanyId.Text = $"{selectedCompany?.ID ?? DatabaseManager.GetNewCompanyID()}";
            tboxCompanyName.Text = $"{selectedCompany?.Name ?? ""}";
            lblDateCreatedValue.Text = $"{selectedCompany?.DateCreated ?? DateTime.Now}";
            lblDateLastUpdatedValue.Text = $"{selectedCompany?.LastUpdated ?? DateTime.Now}";
            lblCreatedByValue.Text = $"{selectedCompany?.CreatedBy ?? activeUser.Username}";
            lblLastUpdatedByValue.Text = $"{selectedCompany?.LastUpdatedBy ?? activeUser.Username}";
            btnFormSave.Enabled = false;

            // Enable Events
            btnFormCancel.Click += OnCancelButtonClick;
            btnFormSave.Click += OnSaveButtonClick;
            tboxCompanyName.TextChanged += OnTextChanged;
        }

        private void ValidateForm() {
            bool formIsValid = true;

            if(string.IsNullOrWhiteSpace(tboxCompanyName.Text)) {
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
            Company newCompany = new Company(int.Parse(tboxCompanyId.Text), tboxCompanyName.Text, DateTime.Now, DateTime.Now, activeUser.Username, activeUser.Username);

            DatabaseManager.AddNewCompany(newCompany);

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
