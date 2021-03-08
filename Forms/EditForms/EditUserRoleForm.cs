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
    public partial class EditUserRoleForm : Form {
        public event EventHandler FormSaved;

        private UserAccount activeUser;
        private UserRole selectedRole;

        public EditUserRoleForm(UserAccount activeUser, UserRole selectedRole = null) {
            InitializeComponent();

            this.activeUser = activeUser;
            this.selectedRole = selectedRole;

            ResetForm(selectedRole);
        }

        // Method
        private void ResetForm(UserRole role = null) {
            // Disable Events
            checkAllowAdminOptions.CheckedChanged -= OnFormChanged;
            checkAllowProcessSales.CheckedChanged -= OnFormChanged;
            checkAllowReporting.CheckedChanged -= OnFormChanged;
            checkAllowCreateProducts.CheckedChanged -= OnFormChanged;
            checkAllowEditProducts.CheckedChanged -= OnFormChanged;
            checkAllowDeleteProducts.CheckedChanged -= OnFormChanged;
            checkAllowCreateUsers.CheckedChanged -= OnFormChanged;
            checkAllowEditUsers.CheckedChanged -= OnFormChanged;
            checkAllowDeleteUsers.CheckedChanged -= OnFormChanged;
            checkAllowCreateRoles.CheckedChanged -= OnFormChanged;
            checkAllowEditRoles.CheckedChanged -= OnFormChanged;
            checkAllowDeleteRoles.CheckedChanged -= OnFormChanged;
            tboxUserRoleName.TextChanged -= OnFormChanged;
            btnFormSave.Click -= OnSaveButtonClick;
            btnFormCancel.Click -= OnCancelButtonClick;

            // Set Control Defaults
            tboxUserRoleId.Text = $"{role?.ID ?? DatabaseManager.GetNewUserRoleID()}";
            tboxUserRoleName.Text = $"{role?.Name ?? ""}";
            tboxUserRoleDescription.Text = $"{role?.Description ?? ""}";

            checkAllowAdminOptions.Checked = (role?.Permissions[UserRole.Permission.AllowAdminControls] ?? false);
            checkAllowProcessSales.Checked = (role?.Permissions[UserRole.Permission.AllowProcessSales] ?? false);
            checkAllowReporting.Checked = (role?.Permissions[UserRole.Permission.AllowReporting] ?? false);
            checkAllowCreateProducts.Checked = (role?.Permissions[UserRole.Permission.AllowCreateProducts] ?? false);
            checkAllowEditProducts.Checked = (role?.Permissions[UserRole.Permission.AllowEditProducts] ?? false);
            checkAllowDeleteProducts.Checked = (role?.Permissions[UserRole.Permission.AllowDeleteProducts] ?? false);
            checkAllowCreateUsers.Checked = (role?.Permissions[UserRole.Permission.AllowCreateUsers] ?? false);
            checkAllowEditUsers.Checked = (role?.Permissions[UserRole.Permission.AllowEditUsers] ?? false);
            checkAllowDeleteUsers.Checked = (role?.Permissions[UserRole.Permission.AllowDeleteUsers] ?? false);
            checkAllowCreateRoles.Checked = (role?.Permissions[UserRole.Permission.AllowCreateRoles] ?? false);
            checkAllowEditRoles.Checked = (role?.Permissions[UserRole.Permission.AllowEditRoles] ?? false);
            checkAllowDeleteRoles.Checked = (role?.Permissions[UserRole.Permission.AllowDeleteRoles] ?? false);

            lblCreatedByValue.Text = $"{role?.CreatedBy ?? activeUser.Username}";
            lblDateCreatedValue.Text = $"{role?.DateCreated ?? DateTime.Now}";
            lblLastUpdatedByValue.Text = $"{role?.LastUpdatedBy ?? activeUser.Username}";
            lblDateLastUpdatedValue.Text = $"{role?.LastUpdated ?? DateTime.Now}";

            // Enable Events
            checkAllowAdminOptions.CheckedChanged += OnFormChanged;
            checkAllowProcessSales.CheckedChanged += OnFormChanged;
            checkAllowReporting.CheckedChanged += OnFormChanged;
            checkAllowCreateProducts.CheckedChanged += OnFormChanged;
            checkAllowEditProducts.CheckedChanged += OnFormChanged;
            checkAllowDeleteProducts.CheckedChanged += OnFormChanged;
            checkAllowCreateUsers.CheckedChanged += OnFormChanged;
            checkAllowEditUsers.CheckedChanged += OnFormChanged;
            checkAllowDeleteUsers.CheckedChanged += OnFormChanged;
            checkAllowCreateRoles.CheckedChanged += OnFormChanged;
            checkAllowEditRoles.CheckedChanged += OnFormChanged;
            checkAllowDeleteRoles.CheckedChanged += OnFormChanged;
            tboxUserRoleName.TextChanged += OnFormChanged;
            btnFormSave.Click += OnSaveButtonClick;
            btnFormCancel.Click += OnCancelButtonClick;
        }

        private void ValidateForm() {
            bool formIsValid = true;

            if(string.IsNullOrWhiteSpace(tboxUserRoleName.Text)) {
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
            Dictionary<UserRole.Permission, bool> permissions = new Dictionary<UserRole.Permission, bool>() {
                {UserRole.Permission.AllowCreateProducts, checkAllowCreateProducts.Checked},
                {UserRole.Permission.AllowEditProducts, checkAllowEditProducts.Checked},
                {UserRole.Permission.AllowDeleteProducts, checkAllowDeleteProducts.Checked},
                {UserRole.Permission.AllowCreateUsers, checkAllowCreateUsers.Checked},
                {UserRole.Permission.AllowEditUsers, checkAllowEditUsers.Checked},
                {UserRole.Permission.AllowDeleteUsers, checkAllowDeleteUsers.Checked},
                {UserRole.Permission.AllowCreateRoles, checkAllowCreateRoles.Checked},
                {UserRole.Permission.AllowEditRoles, checkAllowEditRoles.Checked},
                {UserRole.Permission.AllowDeleteRoles, checkAllowDeleteRoles.Checked},
                {UserRole.Permission.AllowReporting, checkAllowReporting.Checked},
                {UserRole.Permission.AllowProcessSales, checkAllowProcessSales.Checked},
                {UserRole.Permission.AllowAdminControls, checkAllowAdminOptions.Checked},
            };

            selectedRole.Update(int.Parse(tboxUserRoleId.Text), tboxUserRoleName.Text, tboxUserRoleDescription.Text, permissions, selectedRole.DateCreated, DateTime.Now, selectedRole.CreatedBy, activeUser.Username);

            DatabaseManager.UpdateUserRole(selectedRole);

            FormSaved?.Invoke(null, EventArgs.Empty);
            Close();
        }
        private void OnCancelButtonClick(object sender, EventArgs e) {
            Close();
        }

        private void OnFormChanged(object sender, EventArgs e) {
            ValidateForm();
        }
    }
}
