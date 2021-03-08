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
    public partial class ConsoleListForm : Form {
        private UserAccount activeUser;

        public ConsoleListForm(UserAccount activeUser) {
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
            listAllConsoles.SelectedIndexChanged -= OnSelectionIndexChanged;

            // Set Control Defaults
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnNew.Enabled = true;

            // Populate Lists
            listAllConsoles.Items.Clear();

            foreach(var console in DatabaseManager.ConsoleTypes) {
                listAllConsoles.Items.Add(console);
            }

            // Enable Events
            btnNew.Click += OnNewButtonClicked;
            btnEdit.Click += OnEditButtonClicked;
            btnDelete.Click += OnDeleteButtonClicked;
            tboxSearchNames.TextChanged += OnSearchTextChanged;
            listAllConsoles.SelectedIndexChanged += OnSelectionIndexChanged;
        }

        // Event Handlers
        private void OnNewButtonClicked(object sender, EventArgs e) {
            NewConsoleForm newForm = new NewConsoleForm(activeUser);
            newForm.FormSaved += OnFormSaved;
            newForm.ShowDialog();
        }
        private void OnEditButtonClicked(object sender, EventArgs e) {
            ConsoleCategory selectedConsole = listAllConsoles.SelectedItem as ConsoleCategory;
            EditConsoleForm editForm = new EditConsoleForm(activeUser, selectedConsole);
            editForm.FormSaved += OnFormSaved;
            editForm.ShowDialog();
        }
        private void OnDeleteButtonClicked(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Delete the Console Type?", "This is an irreversible action.", MessageBoxButtons.YesNo);

            if(result == DialogResult.Yes) {
                ConsoleCategory console = listAllConsoles.SelectedItem as ConsoleCategory;

                DatabaseManager.DeleteConsoleType(console);

                ResetForm();
            }
        }

        private void OnSearchTextChanged(object sender, EventArgs e) {
            // Disable Events
            btnNew.Click -= OnNewButtonClicked;
            btnEdit.Click -= OnEditButtonClicked;
            btnDelete.Click -= OnDeleteButtonClicked;
            tboxSearchNames.TextChanged -= OnSearchTextChanged;
            listAllConsoles.SelectedIndexChanged -= OnSelectionIndexChanged;

            // Set Control Defaults
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnNew.Enabled = true;

            // Populate Lists
            listAllConsoles.Items.Clear();

            IEnumerable<ConsoleCategory> filteredItems =
                from console in DatabaseManager.ConsoleTypes
                where console.Name.ToUpper().Contains(tboxSearchNames.Text.ToUpper())
                select console;

            foreach(var console in filteredItems) {
                listAllConsoles.Items.Add(console);
            }

            // Enable Events
            btnNew.Click += OnNewButtonClicked;
            btnEdit.Click += OnEditButtonClicked;
            btnDelete.Click += OnDeleteButtonClicked;
            tboxSearchNames.TextChanged += OnSearchTextChanged;
            listAllConsoles.SelectedIndexChanged += OnSelectionIndexChanged;
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
