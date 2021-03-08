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
    public partial class NewUserRoleForm : Form {
        public event EventHandler FormSaved;

        private UserAccount activeUser;
        private UserRole selectedRole;

        public NewUserRoleForm(UserAccount activeUser, UserRole selectedRole = null) {
            InitializeComponent();
        }

        // Methods
        private void ResetForm(UserRole selectedRole = null) {

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
