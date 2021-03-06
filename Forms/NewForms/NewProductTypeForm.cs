﻿using System;
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
    public partial class NewProductTypeForm : Form {
        public event EventHandler FormSaved;

        private UserAccount activeUser;
        private ProductType selectedType;

        public NewProductTypeForm(UserAccount activeUser, ProductType selectedType = null) {
            InitializeComponent();

            this.activeUser = activeUser;
            this.selectedType = selectedType;

            ResetForm(selectedType);
        }

        // Methods
        private void ResetForm(ProductType type = null) {
            // Disable Events
            tboxTypeName.TextChanged -= OnTextChanged;
            btnFormCancel.Click -= OnCancelButtonClick;
            btnFormSave.Click -= OnSaveButtonClick;

            // Set Control Defaults
            btnFormSave.Enabled = false;
            tboxTypeId.Text = $"{DatabaseManager.GetNewProductTypeID()}";
            tboxTypeName.Text = $"{type?.Name ?? ""}";
            lblCreatedByValue.Text = $"{type?.CreatedBy ?? activeUser.Username}";
            lblLastUpdatedByValue.Text = $"{type?.LastUpdatedBy ?? activeUser.Username}";
            lblDateCreatedValue.Text = $"{type?.DateCreated ?? DateTime.Now}";
            lblDateLastUpdatedValue.Text = $"{type?.LastUpdated ?? DateTime.Now}";

            // Enable Events
            tboxTypeName.TextChanged += OnTextChanged;
            btnFormCancel.Click += OnCancelButtonClick;
            btnFormSave.Click += OnSaveButtonClick;
        }

        private void ValidateForm() {
            bool formIsValid = true;

            if(string.IsNullOrWhiteSpace(tboxTypeName.Text)) {
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
            ProductType type = new ProductType(int.Parse(tboxTypeId.Text), tboxTypeName.Text, DateTime.Now, DateTime.Now, activeUser.Username, activeUser.Username);

            DatabaseManager.AddNewProductType(type);

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
