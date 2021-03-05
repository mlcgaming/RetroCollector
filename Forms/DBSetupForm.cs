using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using RetroCollector.Data.Management;
using RetroCollector.Models;

namespace RetroCollector {
    public partial class DBSetupForm : Form {
        public event EventHandler FormSaved;

        private string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Night Owl Software\\RetroCollector");
        private string filename = "db.xml";

        public DBSetupForm() {
            InitializeComponent();

            ResetForm();
        }

        public DBSetupForm(XDocument dbXml) {
            InitializeComponent();

            ResetForm(dbXml);
        }

        private void ResetForm(XDocument dbXml = null) {
            // Disable Events, if any
            tboxServerName.TextChanged -= OnTextChanged;
            tboxPort.TextChanged -= OnTextChanged;
            tboxDatabase.TextChanged -= OnTextChanged;
            tboxUsername.TextChanged -= OnTextChanged;
            tboxPassword.TextChanged -= OnTextChanged;
            btnTestConnection.Click -= OnTestConnectionPressed;
            btnSaveDBDetails.Click -= OnSaveButtonPressed;

            // Set Default Values
            tboxServerName.Text = dbXml?.Element("Connection").Element("Address").Value ?? "127.0.0.1";
            tboxPort.Text = dbXml?.Element("Connection").Element("Port").Value ?? "3306";
            tboxDatabase.Text = dbXml?.Element("Connection").Element("Name").Value ?? "retrocollector";
            tboxUsername.Text = dbXml?.Element("Connection").Element("Username").Value ?? "root";
            tboxPassword.Text = dbXml?.Element("Connection").Element("Password").Value ?? "";
            btnSaveDBDetails.Enabled = false;
            btnTestConnection.Enabled = false;

            // Subscribe to Events
            tboxServerName.TextChanged += OnTextChanged;
            tboxPort.TextChanged += OnTextChanged;
            tboxDatabase.TextChanged += OnTextChanged;
            tboxUsername.TextChanged += OnTextChanged;
            tboxPassword.TextChanged += OnTextChanged;
            btnTestConnection.Click += OnTestConnectionPressed;
            btnSaveDBDetails.Click += OnSaveButtonPressed;
        }

        private void ValidateForm() {
            bool formIsValid = true;

            if(string.IsNullOrWhiteSpace(tboxServerName.Text)) {
                formIsValid = false;
            }

            if(string.IsNullOrWhiteSpace(tboxPort.Text)) {
                formIsValid = false;
            }
            else {
                bool portTextIsNumber = int.TryParse(tboxPort.Text, out int n);

                if(!portTextIsNumber || n <= 0 || n > 65535) {
                    formIsValid = false;
                }
            }

            if(string.IsNullOrWhiteSpace(tboxDatabase.Text)) {
                formIsValid = false;
            }

            if(string.IsNullOrWhiteSpace(tboxUsername.Text)) {
                formIsValid = false;
            }

            if(string.IsNullOrWhiteSpace(tboxPassword.Text)) {
                formIsValid = false;
            }

            if(formIsValid) {
                btnTestConnection.Enabled = true;
            }
            else {
                btnTestConnection.Enabled = false;
                btnSaveDBDetails.Enabled = false;
            }
        }

        // Event Handlers
        private void OnTextChanged(object sender, EventArgs e) {
            ValidateForm();
        }

        private void OnTestConnectionPressed(object sender, EventArgs e) {
            string dbAddress = tboxServerName.Text;
            int dbPort = int.Parse(tboxPort.Text);
            string dbName = tboxDatabase.Text;
            string dbUser = tboxUsername.Text;
            string dbPass = tboxPassword.Text;

            string dbConnString = $"Server={dbAddress};Port={dbPort};Database={dbName};Uid={dbUser};Pwd={dbPass};";
            MySqlConnection dbConn = new MySqlConnection(dbConnString);

            try {
                dbConn.Open();
                btnSaveDBDetails.Enabled = true;
            }
            catch(MySqlException ex) {
                btnSaveDBDetails.Enabled = false;
                MessageBox.Show(ex.Message);
            }
            finally {
                dbConn.Close();
            }
        }

        private void OnSaveButtonPressed(object sender, EventArgs e) {
            string filePath = Path.Combine(directory, filename);

            Directory.CreateDirectory(directory);

            XDocument dbXml = new XDocument();
            XElement connectionElement = new XElement("Connection");

            XElement dbAddress = new XElement("Address", tboxServerName.Text);
            XElement dbPort = new XElement("Port", tboxPort.Text);
            XElement dbName = new XElement("Name", tboxDatabase.Text);
            XElement dbUser = new XElement("Username", tboxUsername.Text);
            XElement dbPass = new XElement("Password", tboxPassword.Text);

            connectionElement.Add(dbAddress);
            connectionElement.Add(dbPort);
            connectionElement.Add(dbName);
            connectionElement.Add(dbUser);
            connectionElement.Add(dbPass);

            dbXml.Add(connectionElement);

            dbXml.Save(filePath);

            FormSaved?.Invoke(null, EventArgs.Empty);
            Close();
        }
    }
}
