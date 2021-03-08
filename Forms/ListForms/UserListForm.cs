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
    public partial class UserListForm : Form {
        private UserAccount activeUser;

        public UserListForm(UserAccount activeUser) {
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
            listAllUsers.SelectedIndexChanged -= OnSelectionIndexChanged;

            // Set Control Defaults
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnNew.Enabled = true;

            // Populate Lists
            listAllUsers.Items.Clear();

            foreach(var user in DatabaseManager.Users) {
                listAllUsers.Items.Add(user);
            }

            // Enable Events
            btnNew.Click += OnNewButtonClicked;
            btnEdit.Click += OnEditButtonClicked;
            btnDelete.Click += OnDeleteButtonClicked;
            tboxSearchNames.TextChanged += OnSearchTextChanged;
            listAllUsers.SelectedIndexChanged += OnSelectionIndexChanged;
        }

        // Event Handlers
        private void OnNewButtonClicked(object sender, EventArgs e) {

        }
        private void OnEditButtonClicked(object sender, EventArgs e) {

        }
        private void OnDeleteButtonClicked(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Delete the User Account?", "This is an irreversible action.", MessageBoxButtons.YesNo);

            if(result == DialogResult.Yes) {
                UserAccount user = listAllUsers.SelectedItem as UserAccount;

                DatabaseManager.DeleteUser(user);

                ResetForm();
            }
        }

        private void OnSearchTextChanged(object sender, EventArgs e) {
            // Disable Events
            btnNew.Click -= OnNewButtonClicked;
            btnEdit.Click -= OnEditButtonClicked;
            btnDelete.Click -= OnDeleteButtonClicked;
            tboxSearchNames.TextChanged -= OnSearchTextChanged;
            listAllUsers.SelectedIndexChanged -= OnSelectionIndexChanged;

            // Set Control Defaults
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnNew.Enabled = true;

            // Populate Lists
            listAllUsers.Items.Clear();

            IEnumerable<UserAccount> filteredItems =
                from user in DatabaseManager.Users
                where user.Username.ToUpper().Contains(tboxSearchNames.Text.ToUpper()) || user.FullName.ToUpper().Contains(tboxSearchNames.Text.ToUpper())
                select user;

            foreach(var user in filteredItems) {
                listAllUsers.Items.Add(user);
            }

            // Enable Events
            btnNew.Click += OnNewButtonClicked;
            btnEdit.Click += OnEditButtonClicked;
            btnDelete.Click += OnDeleteButtonClicked;
            tboxSearchNames.TextChanged += OnSearchTextChanged;
            listAllUsers.SelectedIndexChanged += OnSelectionIndexChanged;
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
