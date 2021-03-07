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

namespace RetroCollector {
    public partial class DatabaseSettingsForm : Form {
        public event EventHandler FormSaved;

        private string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Night Owl Software\\RetroCollector");
        private string filename = "db.xml";

        public DatabaseSettingsForm() {
            InitializeComponent();

            ResetForm();
        }

        // Methods
        private void ResetForm() {
            XDocument dbXml = XDocument.Load(DatabaseManager.FilePath);

            // Disable Events, if any
            tboxServerName.TextChanged -= OnTextChanged;
            tboxPort.TextChanged -= OnTextChanged;
            tboxDatabase.TextChanged -= OnTextChanged;
            tboxUsername.TextChanged -= OnTextChanged;
            tboxPassword.TextChanged -= OnTextChanged;
            btnTestConnection.Click -= OnTestConnectionClick;
            btnSaveDBDetails.Click -= OnSaveButtonClick;
            btnDBReinitialize.Click -= OnInitializeClick;

            // Set Default Values
            tboxServerName.Text = dbXml?.Element("Connection").Element("Address").Value ?? "127.0.0.1";
            tboxPort.Text = dbXml?.Element("Connection").Element("Port").Value ?? "3306";
            tboxDatabase.Text = dbXml?.Element("Connection").Element("Name").Value ?? "retrocollector";
            tboxUsername.Text = dbXml?.Element("Connection").Element("Username").Value ?? "root";
            tboxPassword.Text = dbXml?.Element("Connection").Element("Password").Value ?? "";
            btnSaveDBDetails.Enabled = false;
            btnTestConnection.Enabled = true;
            grpInitialieDatabase.Enabled = false;

            // Subscribe to Events
            tboxServerName.TextChanged += OnTextChanged;
            tboxPort.TextChanged += OnTextChanged;
            tboxDatabase.TextChanged += OnTextChanged;
            tboxUsername.TextChanged += OnTextChanged;
            tboxPassword.TextChanged += OnTextChanged;
            btnTestConnection.Click += OnTestConnectionClick;
            btnSaveDBDetails.Click += OnSaveButtonClick;
            btnDBReinitialize.Click += OnInitializeClick;
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
        private void OnInitializeClick(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("This will completely re-initialize the database, deleting all current data and inserting default, test values. Do you wish to continue?", "THIS IS NOT A REVERSIBLE ACTION", MessageBoxButtons.YesNo);

            if(result == DialogResult.Yes) {
                // Save Current Settings to File
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

                // PURGE AND INITIALIZE
                DatabaseManager.ReinitializeDatabase(this);
            }
        }
        private void OnTestConnectionClick(object sender, EventArgs e) {
            string dbAddress = tboxServerName.Text;
            int dbPort = int.Parse(tboxPort.Text);
            string dbUser = tboxUsername.Text;
            string dbPass = tboxPassword.Text;

            string dbConnString = $"Server={dbAddress};Port={dbPort};Uid={dbUser};Pwd={dbPass};";
            MySqlConnection dbConn = new MySqlConnection(dbConnString);

            try {
                dbConn.Open();
                btnSaveDBDetails.Enabled = true;
                grpInitialieDatabase.Enabled = true;
            }
            catch(MySqlException ex) {
                btnSaveDBDetails.Enabled = false;
                MessageBox.Show(ex.Message);
            }
            finally {
                dbConn.Close();
            }
        }
        private void OnSaveButtonClick(object sender, EventArgs e) {
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
