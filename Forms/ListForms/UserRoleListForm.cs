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
    public partial class UserRoleListForm : Form {
        private UserAccount activeUser;

        public UserRoleListForm(UserAccount activeUser) {
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
            listAllRoles.SelectedIndexChanged -= OnSelectionIndexChanged;

            // Set Control Defaults
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnNew.Enabled = true;

            // Populate Lists
            listAllRoles.Items.Clear();

            foreach(var role in DatabaseManager.Roles) {
                listAllRoles.Items.Add(role);
            }

            // Enable Events
            btnNew.Click += OnNewButtonClicked;
            btnEdit.Click += OnEditButtonClicked;
            btnDelete.Click += OnDeleteButtonClicked;
            tboxSearchNames.TextChanged += OnSearchTextChanged;
            listAllRoles.SelectedIndexChanged += OnSelectionIndexChanged;
        }

        // Event Handlers
        private void OnNewButtonClicked(object sender, EventArgs e) {

        }
        private void OnEditButtonClicked(object sender, EventArgs e) {

        }
        private void OnDeleteButtonClicked(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Delete the User Account?", "This is an irreversible action.", MessageBoxButtons.YesNo);

            if(result == DialogResult.Yes) {
                UserRole role = listAllRoles.SelectedItem as UserRole;

                DatabaseManager.DeleteUserRole(role);

                ResetForm();
            }
        }

        private void OnSearchTextChanged(object sender, EventArgs e) {
            // Disable Events
            btnNew.Click -= OnNewButtonClicked;
            btnEdit.Click -= OnEditButtonClicked;
            btnDelete.Click -= OnDeleteButtonClicked;
            tboxSearchNames.TextChanged -= OnSearchTextChanged;
            listAllRoles.SelectedIndexChanged -= OnSelectionIndexChanged;

            // Set Control Defaults
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnNew.Enabled = true;

            // Populate Lists
            listAllRoles.Items.Clear();

            IEnumerable<UserRole> filteredItems =
                from role in DatabaseManager.Roles
                where role.Name.ToUpper().Contains(tboxSearchNames.Text.ToUpper())
                select role;

            foreach(var role in filteredItems) {
                listAllRoles.Items.Add(role);
            }

            // Enable Events
            btnNew.Click += OnNewButtonClicked;
            btnEdit.Click += OnEditButtonClicked;
            btnDelete.Click += OnDeleteButtonClicked;
            tboxSearchNames.TextChanged += OnSearchTextChanged;
            listAllRoles.SelectedIndexChanged += OnSelectionIndexChanged;
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
