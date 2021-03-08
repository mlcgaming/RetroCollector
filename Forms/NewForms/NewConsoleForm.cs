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
    public partial class NewConsoleForm : Form {
        public event EventHandler FormSaved;

        private UserAccount activeUser;
        private ConsoleCategory selectedConsole;

        public NewConsoleForm(UserAccount activeUser, ConsoleCategory selectedConsole = null) {
            InitializeComponent();

            this.activeUser = activeUser;
            this.selectedConsole = selectedConsole;

            ResetForm(selectedConsole);
        }

        // Methods
        private void ResetForm(ConsoleCategory console = null) {
            // Disable Events
            tboxConsoleName.TextChanged -= OnTextChanged;
            btnFormSave.Click -= OnSaveButtonClick;
            btnFormCancel.Click -= OnCancelButtonClick;

            // Set Control Defaults
            tboxConsoleId.Text = $"{console?.ID ?? DatabaseManager.GetNewConsoleTypeID()}";
            tboxConsoleName.Text = $"{console?.Name ?? ""}";

            // Populate Lists
            cboxConsoleDevelopers.DataSource = DatabaseManager.Companies;
            cboxConsoleDevelopers.SelectedIndex = 0;

            // Enable Events
            tboxConsoleName.TextChanged += OnTextChanged;
            btnFormSave.Click += OnSaveButtonClick;
            btnFormCancel.Click += OnCancelButtonClick;
        }

        private void ValidateForm() {
            bool formIsValid = true;

            if(string.IsNullOrWhiteSpace(tboxConsoleName.Text)) {
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
            Company developer = cboxConsoleDevelopers.SelectedItem as Company;
            ConsoleCategory newConsole = new ConsoleCategory(int.Parse(tboxConsoleId.Text), tboxConsoleName.Text, developer.Name);

            DatabaseManager.AddNewConsoleType(newConsole);

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
