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
    public partial class MainForm : Form {
        private UserAccount activeUser = null;
        
        public UserAccount ActiveUser {
            get => activeUser;
        }

        public MainForm() {
            InitializeComponent();

            DatabaseManager.Initialize();

            LoginForm userLogin = new LoginForm();
            userLogin.UserLoggedIn += OnUserLoggedIn;
            userLogin.FormClosed += OnLoginFormClosing;
            userLogin.ShowDialog();
        }

        // Event Handlers
        private void OnUserLoggedIn(object sender, UserLoggedInEventArgs e) {
            activeUser = e.User;
        }
        private void OnLoginFormClosing(object sender, EventArgs e) {
            if(activeUser == null) {
                MessageBox.Show("No User Logged In. Closing.");
                Application.Exit();
            }
            else {
                listAllProducts.DataSource = ProductManager.Products;
            }
        }
    }
}
