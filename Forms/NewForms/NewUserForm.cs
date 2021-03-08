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
    public partial class NewUserForm : Form {
        public event EventHandler FormSaved;

        private UserAccount activeUser;
        private UserAccount selectedUser;

        public NewUserForm(UserAccount activeUser, UserAccount selectedUser = null) {
            InitializeComponent();
        }

        // Methods
        private void ResetForm(UserAccount selectedUser = null) {

        }

        private void ValidateForm() {

        }

        // Event Handlers
        private void OnSaveButtonClick(object sender, EventArgs e) {

        }
        private void OnCancelButtonClick(object sender, EventArgs e) {

        }

        private void OnTextChanged(object sender, EventArgs e) {

        }
    }
}
