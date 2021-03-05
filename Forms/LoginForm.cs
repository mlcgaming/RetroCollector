using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetroCollector {
    public partial class LoginForm : Form {
        public LoginForm() {
            InitializeComponent();

            ResetForm();
        }

        private void ResetForm() {
            // Unsubscribe from Events if needed
            tboxUsername.TextChanged -= OnTextChanged;
            tboxPassword.TextChanged -= OnTextChanged;
            btnLogin.Click -= OnLoginButtonClick;

            tboxPassword.Text = "";
            tboxUsername.Text = "";
            btnLogin.Enabled = false;

            // Subscribe from Events if needed
            tboxUsername.TextChanged += OnTextChanged;
            tboxPassword.TextChanged += OnTextChanged;
            btnLogin.Click += OnLoginButtonClick;
        }


        private void ValidateForm() {
            bool formIsValid = true;

            if(string.IsNullOrWhiteSpace(tboxPassword.Text)) {
                formIsValid = false;
            }

            if(string.IsNullOrWhiteSpace(tboxUsername.Text)) {
                formIsValid = false;
            }

            if(formIsValid) {
                btnLogin.Enabled = true;
            }
            else {
                btnLogin.Enabled = false;
            }
        }

        private void OnTextChanged(object sender, EventArgs e) {
            ValidateForm();
        }

        private void OnLoginButtonClick(object sender, EventArgs e) {

        }
    }
}
