using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using RetroCollector.Models;
using MySql.Data.MySqlClient;

namespace RetroCollector.Data.Management {
    public static class DatabaseManager {
        private static string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Night Owl Software\\RetroCollector");
        private static string filename = "db.xml";
        private static string databaseAddress;
        private static string databaseName;
        private static int databasePort;
        private static string databaseUser;
        private static string databasePassword;

        private static List<UserRole> roles = new List<UserRole>();
        private static List<UserAccount> users = new List<UserAccount>();

        public static string FilePath {
            get => (Path.Combine(directory, filename));
        }
        public static string DBConnectionString {
            get => GetConnectionString();
        }
        public static List<UserRole> Roles {
            get => roles;
        }
        public static List<UserAccount> Users {
            get => users;
        }

        public static void Initialize() {
            if(File.Exists(FilePath) == false) {
                CreateDatabaseSettings();
            }
            else {
                InitializeDBSettings();
                LoadFromDatabase();
            }
        }
        private static string GetConnectionString() {
            return $"SERVER={databaseAddress};DATABASE={databaseName};PORT={databasePort};UID={databaseUser};PWD={databasePassword};";
        }
        private static void InitializeDBSettings() {
            XDocument dbXml = XDocument.Load(FilePath);

            databaseAddress = dbXml.Element("Connection").Element("Address").Value;
            databasePort = int.Parse(dbXml.Element("Connection").Element("Port").Value);
            databaseName = dbXml.Element("Connection").Element("Name").Value;
            databaseUser = dbXml.Element("Connection").Element("Username").Value;
            databasePassword = dbXml.Element("Connection").Element("Password").Value;
        }
        private static void LoadFromDatabase() {
            // Set Connection Details
            MySqlConnection dbConn = new MySqlConnection(GetConnectionString());

            // Load All User Roles
            GetAllUserRoles(dbConn);

            // Load All Users
            GetAllUsers(dbConn);

            // Load All Customers
            GetAllCustomers(dbConn);

            // Load all Companies
            GetAllCompanies(dbConn);

            // Load all Product Types
            GetAllProductTypes(dbConn);

            // Load all Products
            GetAllProducts(dbConn);

            // Load all Transaction Line Items
            GetAllTransactionItems(dbConn);

            // Load all Transactions
            GetAllTransactions(dbConn);
        }

        private static void GetAllUserRoles(MySqlConnection dbConn) {
            // Load User Roles
            try {
                dbConn.Open();

                MySqlCommand getUserRolesCommand = new MySqlCommand($"SELECT * FROM {databaseName}.userroles", dbConn);
                MySqlDataReader reader = getUserRolesCommand.ExecuteReader();

                while(reader.Read()) {
                    UserRole newRole = new UserRole(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), new Dictionary<UserRole.Permission, bool>() {
                        { UserRole.Permission.AllowCreateProducts, reader.GetBoolean(3) },
                        { UserRole.Permission.AllowEditProducts, reader.GetBoolean(4) },
                        { UserRole.Permission.AllowDeleteProducts, reader.GetBoolean(5) },
                        { UserRole.Permission.AllowCreateUsers, reader.GetBoolean(6) },
                        { UserRole.Permission.AllowEditUsers, reader.GetBoolean(7) },
                        { UserRole.Permission.AllowDeleteUsers, reader.GetBoolean(8) },
                        { UserRole.Permission.AllowCreateRoles, reader.GetBoolean(9) },
                        { UserRole.Permission.AllowEditRoles, reader.GetBoolean(10) },
                        { UserRole.Permission.AllowDeleteRoles, reader.GetBoolean(11) },
                        { UserRole.Permission.AllowReporting, reader.GetBoolean(12) },
                        { UserRole.Permission.AllowProcessSales, reader.GetBoolean(13) },
                        { UserRole.Permission.AllowAdminControls, reader.GetBoolean(14) },
                    }, reader.GetDateTime(15), reader.GetDateTime(16), reader.GetString(17), reader.GetString(18));

                    roles.Add(newRole);
                }
            }
            catch(MySqlException ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                dbConn.Close();
            }
        }
        private static void GetAllUsers(MySqlConnection dbConn) {

            // Load Users
            try {
                dbConn.Open();

                MySqlCommand getUsersCommand = new MySqlCommand($"SELECT * FROM {databaseName}.users", dbConn);
                MySqlDataReader reader = getUsersCommand.ExecuteReader();

                while(reader.Read()) {
                    UserAccount newUser = new UserAccount(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4),
                        reader.GetString(5), reader.GetInt32(10), reader.GetDateTime(6), reader.GetDateTime(7), reader.GetString(8), reader.GetString(9));

                    Users.Add(newUser);
                }
            }
            catch(MySqlException ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                dbConn.Close();
            }
        }
        private static void GetAllCustomers(MySqlConnection dbConn) {

            // Load Customers
            try {
                dbConn.Open();

                MySqlCommand getUsersCommand = new MySqlCommand($"SELECT * FROM {databaseName}.customers", dbConn);
                MySqlDataReader reader = getUsersCommand.ExecuteReader();

                while(reader.Read()) {
                    
                }
            }
            catch(MySqlException ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                dbConn.Close();
            }
        }
        private static void GetAllCompanies(MySqlConnection dbConn) {

            // Load Companies
            try {
                dbConn.Open();

                MySqlCommand getUsersCommand = new MySqlCommand($"SELECT * FROM {databaseName}.companies", dbConn);
                MySqlDataReader reader = getUsersCommand.ExecuteReader();

                while(reader.Read()) {

                }
            }
            catch(MySqlException ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                dbConn.Close();
            }
        }
        private static void GetAllProductTypes(MySqlConnection dbConn) {

            // Load Product Types
            try {
                dbConn.Open();

                MySqlCommand getUsersCommand = new MySqlCommand($"SELECT * FROM {databaseName}.producttypes", dbConn);
                MySqlDataReader reader = getUsersCommand.ExecuteReader();

                while(reader.Read()) {

                }
            }
            catch(MySqlException ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                dbConn.Close();
            }
        }
        private static void GetAllProducts(MySqlConnection dbConn) {

            // Load Products
            try {
                dbConn.Open();

                MySqlCommand getUsersCommand = new MySqlCommand($"SELECT * FROM {databaseName}.products", dbConn);
                MySqlDataReader reader = getUsersCommand.ExecuteReader();

                while(reader.Read()) {

                }
            }
            catch(MySqlException ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                dbConn.Close();
            }
        }
        private static void GetAllTransactionItems(MySqlConnection dbConn) {

            // Load Transaction Items
            try {
                dbConn.Open();

                MySqlCommand getUsersCommand = new MySqlCommand($"SELECT * FROM {databaseName}.transactionitems", dbConn);
                MySqlDataReader reader = getUsersCommand.ExecuteReader();

                while(reader.Read()) {

                }
            }
            catch(MySqlException ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                dbConn.Close();
            }
        }
        private static void GetAllTransactions(MySqlConnection dbConn) {

            // Load Transactions
            try {
                dbConn.Open();

                MySqlCommand getUsersCommand = new MySqlCommand($"SELECT * FROM {databaseName}.transactions", dbConn);
                MySqlDataReader reader = getUsersCommand.ExecuteReader();

                while(reader.Read()) {

                }
            }
            catch(MySqlException ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                dbConn.Close();
            }
        }

        private static void CreateDatabaseSettings() {
            DBSetupForm newDbSetupForm = new DBSetupForm();
            newDbSetupForm.FormSaved += OnDbSetupSaved;
            newDbSetupForm.ShowDialog();
        }

        public static UserAccount GetUserByUsername(string username) {
            foreach(var user in Users) {
                if(user.Username == username) {
                    return user;
                }
            }

            return null;
        }

        private static void OnDbSetupSaved(object sender, EventArgs e) {
            InitializeDBSettings();
            LoadFromDatabase();
        }
    }
}
