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
    public partial class EditUserForm : Form {
        public event EventHandler FormSaved;

        private UserAccount activeUser;
        private UserAccount selectedUser;

        public EditUserForm(UserAccount activeUser, UserAccount selectedUser = null) {
            InitializeComponent();

            this.activeUser = activeUser;
            this.selectedUser = selectedUser;

            ResetForm(selectedUser);
        }

        // Methods
        private void ResetForm(UserAccount selectedUser = null) {
            // Disable Events
            tboxUserFirstName.TextChanged -= OnTextChanged;
            tboxUserLastName.TextChanged -= OnTextChanged;
            tboxUserLoginName.TextChanged -= OnTextChanged;
            tboxUserPassword.TextChanged -= OnTextChanged;
            btnFormCancel.Click -= OnCancelButtonClick;
            btnFormSave.Click -= OnSaveButtonClick;

            // Set Control Defaults
            tboxUserId.Text = $"{selectedUser?.ID ?? DatabaseManager.GetNewUserID()}";
            tboxUserFirstName.Text = $"{selectedUser?.FirstName ?? ""}";
            tboxUserLastName.Text = $"{selectedUser?.LastName ?? ""}";
            tboxUserLoginName.Text = $"{selectedUser?.Username ?? ""}";
            tboxUserPassword.Text = "";

            lblCreatedByValue.Text = $"{selectedUser?.CreatedBy ?? activeUser.Username}";
            lblDateCreatedValue.Text = $"{selectedUser?.DateCreated ?? DateTime.Now}";
            lblLastUpdatedByValue.Text = $"{selectedUser?.LastUpdatedBy ?? activeUser.Username}";
            lblDateLastUpdatedValue.Text = $"{selectedUser?.LastUpdated ?? DateTime.Now}";

            // Populate Lists
            foreach(var role in DatabaseManager.Roles) {
                cboxUserRoles.Items.Add(role);
            }
            cboxUserRoles.SelectedItem = selectedUser.Role;

            // Enable Events
            tboxUserFirstName.TextChanged += OnTextChanged;
            tboxUserLastName.TextChanged += OnTextChanged;
            tboxUserLoginName.TextChanged += OnTextChanged;
            tboxUserPassword.TextChanged += OnTextChanged;
            btnFormCancel.Click += OnCancelButtonClick;
            btnFormSave.Click += OnSaveButtonClick;
        }

        private void ValidateForm() {
            bool formIsValid = true;

            if(string.IsNullOrWhiteSpace(tboxUserFirstName.Text)) {
                formIsValid = false;
            }
            if(string.IsNullOrWhiteSpace(tboxUserLastName.Text)) {
                formIsValid = false;
            }
            if(string.IsNullOrWhiteSpace(tboxUserLoginName.Text)) {
                formIsValid = false;
            }
            if(string.IsNullOrWhiteSpace(tboxUserPassword.Text)) {
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
            UserRole userRole = cboxUserRoles.SelectedItem as UserRole;

            byte[] passwordSalt = PasswordManager.GenerateSaltHash();
            string[] passwordHashed = PasswordManager.GeneratePasswordHash(passwordSalt, tboxUserPassword.Text);

            string passSalt = Convert.ToBase64String(passwordSalt);
            string passHash = passwordHashed[1];

            selectedUser.Update(int.Parse(tboxUserId.Text), tboxUserFirstName.Text, tboxUserLastName.Text, tboxUserLoginName.Text, passHash, passSalt, userRole.ID, DateTime.Now, DateTime.Now, activeUser.Username, activeUser.Username);

            DatabaseManager.UpdateUser(selectedUser);

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
