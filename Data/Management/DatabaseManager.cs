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

        private static List<UserRole> allRoles = new List<UserRole>();
        private static List<UserAccount> allUsers = new List<UserAccount>();
        private static List<ConsoleCategory> allConsoleTypes = new List<ConsoleCategory>();
        private static List<Company> allCompanies = new List<Company>();
        private static List<Customer> allCustomers = new List<Customer>();
        private static List<TransactionLineItem> allLineItems = new List<TransactionLineItem>();
        private static List<TransactionSale> allTransactions = new List<TransactionSale>();

        public static string FilePath {
            get => (Path.Combine(directory, filename));
        }
        public static string DBConnectionString {
            get => GetConnectionString();
        }
        public static List<UserRole> Roles {
            get => allRoles;
        }
        public static List<UserAccount> Users {
            get => allUsers;
        }
        public static List<ConsoleCategory> ConsoleTypes {
            get => allConsoleTypes;
        }
        public static List<Company> Companies {
            get => allCompanies;
        }
        public static List<Customer> Customers {
            get => allCustomers;
        }
        public static List<TransactionSale> Transactions {
            get => allTransactions;
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
            return $"SERVER={databaseAddress};PORT={databasePort};UID={databaseUser};PWD={databasePassword};";
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
            MySqlConnection dbConn = new MySqlConnection(DBConnectionString);

            // Load All User Roles
            GetAllUserRoles(dbConn);

            // Load All Users
            GetAllUsers(dbConn);

            // Load All Console Types
            GetAllConsoleTypes(dbConn);

            // Load all Companies
            GetAllCompanies(dbConn);

            // Load All Customers
            GetAllCustomers(dbConn);

            // Load all Product Types
            GetAllProductTypes(dbConn);

            // Load all Products
            GetAllProducts(dbConn);

            // Load all Transaction Line Items
            GetAllTransactionItems(dbConn);

            // Load all Transactions
            GetAllTransactions(dbConn);
        }
        private static void InsertDefaultData() {
            // Create Default Companies
            string defaultCompanies =
                $"INSERT INTO {databaseName}.companies VALUES(0, 'RetroWave Collections', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO {databaseName}.companies VALUES(1, 'Nintendo', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO {databaseName}.companies VALUES(2, 'Sega', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO {databaseName}.companies VALUES(3, 'Sony', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO {databaseName}.companies VALUES(4, 'Insomniac Games', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO {databaseName}.companies VALUES(5, 'Zener Works', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');";

            string defaultProductTypes =
                $"INSERT INTO {databaseName}.producttypes VALUES(0, 'Video Game', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO {databaseName}.producttypes VALUES(1, 'Console', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO {databaseName}.producttypes VALUES(2, 'Merchandise', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO {databaseName}.producttypes VALUES(3, 'Peripheral', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO {databaseName}.producttypes VALUES(4, 'Service', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');";

            string defaultConsoles =
                $"INSERT INTO {databaseName}.consoles VALUES(0, 'NONE', 'NONE');" +
                $"INSERT INTO {databaseName}.consoles VALUES(1, 'Nintendo 64', 'Nintendo');" +
                $"INSERT INTO {databaseName}.consoles VALUES(2, 'Sony Playstation (PSX)', 'Sony');" +
                $"INSERT INTO {databaseName}.consoles VALUES(3, 'Super Nintendo', 'Nintendo');" +
                $"INSERT INTO {databaseName}.consoles VALUES(4, 'Original Gameboy', 'Nintendo');" +
                $"INSERT INTO {databaseName}.consoles VALUES(5, 'Sega Genesis', 'Sega');" +
                $"INSERT INTO {databaseName}.consoles VALUES(6, 'Playstation 2', 'Sony');";

            string defaultProducts =
                $"INSERT INTO {databaseName}.products VALUES(0, 'Super Nintendo Entertainment System [CIB]', 3, 1, '1991-8-23 00:00:00', 0, 2, 1, 1, 35.00, 45.99, 3, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin', '');" +
                $"INSERT INTO {databaseName}.products VALUES(1, 'Nintendo 64 System [Loose]', 1, 1, '1996-9-29 00:00:00', 0, 1, 1, 1, 45.00, 55.99, 4, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin', '');" +
                $"INSERT INTO {databaseName}.products VALUES(2, 'Super Mario World', 3, 1, '1991-8-23 00:00:00', 0, 1, 1, 0, 30.79, 49.99, 8, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin', '');" +
                $"INSERT INTO {databaseName}.products VALUES(3, 'Donkey Kong 64', 1, 1, '1999-11-4 00:00:00', 0, 1, 1, 0, 34.99, 44.95, 5, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin', '');" +
                $"INSERT INTO {databaseName}.products VALUES(4, 'Spyro the Dragon', 2, 4, '1998-9-9 00:00:00', 0, 1, 1, 0, 12.95, 17.99, 2, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin', '');" +
                $"INSERT INTO {databaseName}.products VALUES(5, 'Okage Shadow King', 6, 5, '2001-10-1 00:00:00', 0, 1, 1, 0, 19.69, 24.95, 1, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin', '');" +
                $"INSERT INTO {databaseName}.products VALUES(6, 'Mario Kart 64', 1, 1, '1997-2-10 00:00:00', 0, 1, 1, 0, 24.99, 39.99, 1, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin', '');" +
                $"INSERT INTO {databaseName}.products VALUES(7, 'Nintendo 64 Controller (Blue)', 1, 1, '1996-9-29 00:00:00', 0, 1, 1, 3, 15.99, 21.95, 3, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin', '');" +
                $"INSERT INTO {databaseName}.products VALUES(8, 'Pikachu Plush (1998)', NULL, 1, '1998-1-1 00:00:00', 0, 1, 1, 2, 23.95, 34.99, 1, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin', '1998 Original Plush of Pikachu');" +
                $"INSERT INTO {databaseName}.products VALUES(9, 'Console Repair Service', NULL, 0, '1998-1-1 00:00:00', 0, 1, 1, 4, 15.00, 75.00, 0, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin', 'Diagnostics and Repair of Console -- Parts not included');";

            string defaultUserRoles =
                $"INSERT INTO {databaseName}.userroles VALUES(0, 'Admin', 'Built-In Administrator Account', true, true, true, true, true, true, true, true, true, true, true, true, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO {databaseName}.userroles VALUES(1, 'User', 'Built-In Standard User Account', true, true, false, false, false, false, false, false, false, false, true, false, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');";

            string defaultUsers =
                $"INSERT INTO {databaseName}.users VALUES(0, 'Admin', '', 'Admin', 'Y3NhN68hLclf9oCLY6U89OFat3a+HsVYATg8WjxnydFM2w74m80x5mLfVbR9h8N0wpWECopUesKSyuG2oV+j9w==', 'TNsO+JvNMeZi31W0fYfDdMKVhAqKVHrCksrhtqFfo/c=', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin', 0);";

            string defaultCustomers =
                $"INSERT INTO {databaseName}.customers VALUES(0, 'Guest', 'Customer', '', '', '', '', '', '', '', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO {databaseName}.customers VALUES(1, 'John', 'Smith', '123 N Broadway', 'Suite 103', 'Rochester', 'MN', '55906', '111-222-3333', 'jsmith@everyman.com', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');";

            string defaultTransactions =
                $"INSERT INTO {databaseName}.transactions VALUES (0, 'Sample Sale', '2021-1-1 08:00:00', 0, 1, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');";

            string defaultTransactionLineItems =
                $"INSERT INTO {databaseName}.transactionLineItems VALUES (0, 0, 1, 45.99);" +
                $"INSERT INTO {databaseName}.transactionLineItems VALUES(0, 1, 1, 60.00);";

            string[] defaultCommands = new string[] {
                defaultCompanies,
                defaultProductTypes,
                defaultConsoles,
                defaultProducts,
                defaultUserRoles,
                defaultUsers,
                defaultCustomers,
                defaultTransactions,
                defaultTransactionLineItems
            };

            MySqlConnection dbConn = new MySqlConnection(DBConnectionString);

            try {
                dbConn.Open();

                for(int i = 0; i < defaultCommands.Length; i++) {
                    MySqlCommand command = new MySqlCommand(defaultCommands[i], dbConn);
                    int statementCount = command.ExecuteNonQuery();
                }

                MessageBox.Show($"Tables All Populated with Default Data");
            }
            catch(MySqlException ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                dbConn.Close();
            }
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

                    allRoles.Add(newRole);
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
        private static void GetAllConsoleTypes(MySqlConnection dbConn) {

            // Load Console Types
            try {
                dbConn.Open();

                MySqlCommand getConsolesCommand = new MySqlCommand($"SELECT * FROM {databaseName}.consoles", dbConn);
                MySqlDataReader reader = getConsolesCommand.ExecuteReader();

                while(reader.Read()) {
                    ConsoleCategory newConsole = new ConsoleCategory(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));

                    allConsoleTypes.Add(newConsole);
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

                MySqlCommand getCustomersCommand = new MySqlCommand($"SELECT * FROM {databaseName}.customers", dbConn);
                MySqlDataReader reader = getCustomersCommand.ExecuteReader();

                while(reader.Read()) {
                    Customer newCustomer = new Customer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(9), reader.GetString(3), reader.GetString(4), reader.GetString(5),
                        reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetDateTime(10), reader.GetDateTime(11), reader.GetString(12), reader.GetString(13));

                    allCustomers.Add(newCustomer);
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

                MySqlCommand getCompaniesCommand = new MySqlCommand($"SELECT * FROM {databaseName}.companies", dbConn);
                MySqlDataReader reader = getCompaniesCommand.ExecuteReader();

                while(reader.Read()) {
                    Company newCompany = new Company(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetDateTime(3), reader.GetString(4), reader.GetString(5));

                    allCompanies.Add(newCompany);
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

                MySqlCommand getTypesCommand = new MySqlCommand($"SELECT * FROM {databaseName}.producttypes", dbConn);
                MySqlDataReader reader = getTypesCommand.ExecuteReader();

                while(reader.Read()) {
                    ProductType newType = new ProductType(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetDateTime(3), reader.GetString(4), reader.GetString(5));

                    ProductManager.ProductTypes.Add(newType);
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

                int columnID = 0;
                int columnName = 1;
                int columnConsoleType = 2;
                int columnDeveloperID = 3;
                int columnReleaseDate = 4;
                int columnQuality = 5;
                int columnCompleteness = 6;
                int columnRegion = 7;
                int columnProductType = 8;
                int columnCost = 9;
                int columnPrice = 10;
                int columnOnHand = 11;
                int columnDateCreated = 12;
                int columnDateUpdated = 13;
                int columnCreatedBy = 14;
                int columnUpdatedBy = 15;
                int columnDescription = 16;

                MySqlCommand getProductsCommand = new MySqlCommand($"SELECT * FROM {databaseName}.products", dbConn);
                MySqlDataReader reader = getProductsCommand.ExecuteReader();

                while(reader.Read()) {
                    int typeId = reader.GetInt32(columnProductType);

                    if(typeId == GetProductTypeIDByName("Video Game")) {
                        VideoGame newVideoGame = new VideoGame(
                            reader.GetInt32(columnID), 
                            reader.GetString(columnName), 
                            reader.GetDecimal(columnCost), 
                            reader.GetDecimal(columnPrice), 
                            reader.GetInt32(columnOnHand), 
                            (Product.ProductQuality)(reader.GetInt32(columnQuality)),
                            (Product.ProductCompleteness)(reader.GetInt32(columnCompleteness)), 
                            (Product.ProductRegion)(reader.GetInt32(columnRegion)),
                            reader.GetInt32(columnProductType),
                            GetConsoleByID(reader.GetInt32(columnConsoleType)),
                            reader.GetString(columnDescription), 
                            GetCompanyById(reader.GetInt32(columnDeveloperID)), 
                            reader.GetDateTime(columnReleaseDate),
                            reader.GetDateTime(columnDateCreated), 
                            reader.GetDateTime(columnDateUpdated), 
                            reader.GetString(columnCreatedBy), 
                            reader.GetString(columnUpdatedBy));

                        ProductManager.Products.Add(newVideoGame);
                    }
                    else if(typeId == GetProductTypeIDByName("Console")) {
                        VideoGameConsole newConsole = new VideoGameConsole(
                            reader.GetInt32(columnID), 
                            reader.GetString(columnName), 
                            reader.GetDecimal(columnCost), 
                            reader.GetDecimal(columnPrice), 
                            reader.GetInt32(columnOnHand), 
                            GetCompanyById(reader.GetInt32(columnDeveloperID)),
                            (Product.ProductQuality)(reader.GetInt32(columnQuality)), 
                            (Product.ProductCompleteness)(reader.GetInt32(columnCompleteness)), 
                            (Product.ProductRegion)(reader.GetInt32(columnRegion)),
                            reader.GetInt32(columnProductType),
                            reader.GetString(columnDescription),
                            reader.GetDateTime(columnReleaseDate),
                            reader.GetDateTime(columnDateCreated),
                            reader.GetDateTime(columnDateUpdated), 
                            reader.GetString(columnCreatedBy), 
                            reader.GetString(columnUpdatedBy));

                        ProductManager.Products.Add(newConsole);
                    }
                    else if(typeId == GetProductTypeIDByName("Merchandise")) {
                        GameMerchandise newMerchandise = new GameMerchandise(
                            reader.GetInt32(columnID),
                            reader.GetString(columnName),
                            reader.GetDecimal(columnCost),
                            reader.GetDecimal(columnPrice),
                            reader.GetInt32(columnOnHand),
                            GetCompanyById(reader.GetInt32(columnDeveloperID)),
                            (Product.ProductQuality)(reader.GetInt32(columnQuality)),
                            (Product.ProductCompleteness)(reader.GetInt32(columnCompleteness)),
                            (Product.ProductRegion)(reader.GetInt32(columnRegion)),
                            reader.GetInt32(columnProductType),
                            reader.GetString(columnDescription),
                            reader.GetDateTime(columnReleaseDate),
                            reader.GetDateTime(columnDateCreated),
                            reader.GetDateTime(columnDateUpdated),
                            reader.GetString(columnCreatedBy),
                            reader.GetString(columnUpdatedBy));

                        ProductManager.Products.Add(newMerchandise);
                    }
                    else if(typeId == GetProductTypeIDByName("Peripheral")) {
                        Peripheral newPeripheral = new Peripheral(
                            reader.GetInt32(columnID),
                            reader.GetString(columnName),
                            reader.GetDecimal(columnCost),
                            reader.GetDecimal(columnPrice),
                            reader.GetInt32(columnOnHand),
                            GetCompanyById(reader.GetInt32(columnDeveloperID)),
                            (Product.ProductQuality)(reader.GetInt32(columnQuality)),
                            (Product.ProductCompleteness)(reader.GetInt32(columnCompleteness)),
                            (Product.ProductRegion)(reader.GetInt32(columnRegion)),
                            reader.GetInt32(columnProductType),
                            reader.GetString(columnDescription),
                            reader.GetDateTime(columnReleaseDate),
                            reader.GetDateTime(columnDateCreated),
                            reader.GetDateTime(columnDateUpdated),
                            reader.GetString(columnCreatedBy),
                            reader.GetString(columnUpdatedBy));

                        ProductManager.Products.Add(newPeripheral);
                    }
                    else if(typeId == GetProductTypeIDByName("Service")) {
                        ServiceProduct newService = new ServiceProduct(
                            reader.GetInt32(columnID),
                            reader.GetString(columnName),
                            reader.GetString(columnDescription),
                            reader.GetDecimal(columnCost),
                            reader.GetDecimal(columnPrice),
                            reader.GetInt32(columnProductType),
                            reader.GetDateTime(columnDateCreated),
                            reader.GetDateTime(columnDateUpdated),
                            reader.GetString(columnCreatedBy),
                            reader.GetString(columnUpdatedBy));

                        ProductManager.Products.Add(newService);
                    }
                    else {
                        // Generic Product
                        Product newProduct = null;

                        ProductManager.Products.Add(newProduct);
                    }
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

                MySqlCommand getItemsCommand = new MySqlCommand($"SELECT * FROM {databaseName}.transactionlineitems", dbConn);
                MySqlDataReader reader = getItemsCommand.ExecuteReader();

                while(reader.Read()) {
                    TransactionLineItem newItem = new TransactionLineItem(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDecimal(3));

                    allLineItems.Add(newItem);
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

                MySqlCommand getTransactionsCommand = new MySqlCommand($"SELECT * FROM {databaseName}.transactions", dbConn);
                MySqlDataReader reader = getTransactionsCommand.ExecuteReader();

                while(reader.Read()) {
                    TransactionSale newSale = new TransactionSale(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetInt32(3), reader.GetInt32(4),
                        reader.GetDateTime(5), reader.GetDateTime(6), reader.GetString(7), reader.GetString(8));

                    foreach(var item in allLineItems) {
                        if(item.TransactionID == newSale.ID) {
                            newSale.AddLineItem(item);
                        }
                    }

                    allTransactions.Add(newSale);
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
        private static void InitializeSchema() {
            // Create Schema Command
            string createSchema = $"CREATE SCHEMA `{databaseName}`;";

            // Create Companies Table Command
            string createCompaniesTable =
                $"CREATE TABLE `{databaseName}`.`companies` (" +
                $"`companyId` INT NOT NULL," +
                $"`name` VARCHAR(45) NOT NULL," +
                $"`dateCreated` DATETIME NULL," +
                $"`dateLastUpdated` DATETIME NULL," +
                $"`createdBy` VARCHAR(45) NULL," +
                $"`lastUpdatedBy` VARCHAR(45) NULL," +
                $"  PRIMARY KEY (`companyId`)," +
                $"  UNIQUE INDEX `companyId_UNIQUE` (`companyId` ASC) VISIBLE);";

            // Create Product Types Table Command
            string createProductTypesTable =
                $"CREATE TABLE `{databaseName}`.`producttypes` (" +
                $"`productTypeId` INT NOT NULL," +
                $"`name` VARCHAR(45) NOT NULL," +
                $"`dateCreated` DATETIME NULL," +
                $"`dateLastUpdated` DATETIME NULL," +
                $"`createdBy` VARCHAR(45) NULL," +
                $"`lastUpdatedBy` VARCHAR(45) NULL," +
                $"  PRIMARY KEY(`productTypeId`)," +
                $"  UNIQUE INDEX `productTypeId_UNIQUE` (`productTypeId` ASC) VISIBLE," +
                $"  UNIQUE INDEX `name_UNIQUE` (`name` ASC) VISIBLE);";

            // Create Products Table Command
            string createProductsTable =
                $"CREATE TABLE `{databaseName}`.`products` (" +
                $"`productId` INT NOT NULL," +
                $"`name` VARCHAR(45) NOT NULL," +
                $"`consoleId` INT NULL," +
                $"`developerId` INT NOT NULL," +
                $"`dateReleased` DATETIME NULL," +
                $"`quality` INT NULL," +
                $"`completion` INT NULL," +
                $"`region` INT NULL," +
                $"`productTypeId` INT NOT NULL," +
                $"`cost` DECIMAL NOT NULL," +
                $"`price` DECIMAL NOT NULL," +
                $"`onHand` INT NOT NULL," +
                $"`dateCreated` DATETIME NULL," +
                $"`dateLastUpdated` DATETIME NULL," +
                $"`createdBy` VARCHAR(45) NULL," +
                $"`lastUpdatedBy` VARCHAR(45) NULL," +
                $"`description` VARCHAR(100) NULL," +
                $"  PRIMARY KEY(`productId`)," +
                $"  UNIQUE INDEX `productId_UNIQUE` (`productId` ASC) VISIBLE," +
                $"  INDEX `productDeveloperId_idx` (`developerId` ASC) VISIBLE," +
                $"  INDEX `productTypeId_idx` (`productTypeId` ASC) VISIBLE," +
                $"  CONSTRAINT `productDeveloperId`" +
                $"  FOREIGN KEY(`developerId`)" +
                $"  REFERENCES `{databaseName}`.`companies` (`companyId`)" +
                $"  ON DELETE NO ACTION" +
                $"  ON UPDATE NO ACTION," +
                $"  CONSTRAINT `productTypeId`" +
                $"  FOREIGN KEY(`productTypeId`)" +
                $"  REFERENCES `{databaseName}`.`producttypes` (`productTypeId`)" +
                $"  ON DELETE RESTRICT" +
                $"  ON UPDATE NO ACTION);";

            // Create Customers Table Command
            string createCustomersTable =
                $"CREATE TABLE `{databaseName}`.`customers` (" +
                $"  `customerId` INT NOT NULL," +
                $"  `firstName` VARCHAR(45) NULL," +
                $"  `lastName` VARCHAR(45) NULL," +
                $"  `address1` VARCHAR(45) NULL," +
                $"  `address2` VARCHAR(45) NULL," +
                $"  `city` VARCHAR(45) NULL," +
                $"  `stateAbbr` VARCHAR(2) NULL," +
                $"  `zipCode` VARCHAR(5) NULL," +
                $"  `phoneNumber` VARCHAR(14) NULL," +
                $"  `email` VARCHAR(45) NOT NULL," +
                $"  `dateCreated` DATETIME NULL," +
                $"  `dateLastUpdated` DATETIME NULL," +
                $"  `createdBy` VARCHAR(45) NULL," +
                $"  `lastUpdatedBy` VARCHAR(45) NULL," +
                $"  PRIMARY KEY(`customerId`)," +
                $"  UNIQUE INDEX `customerId_UNIQUE` (`customerId` ASC) VISIBLE);";

            // Create User Roles Table Command
            string createRolesTable =
                $"CREATE TABLE `{databaseName}`.`userroles` (" +
                $"  `roleId` INT NOT NULL," +
                $"  `name` VARCHAR(45) NOT NULL," +
                $"  `description` VARCHAR(45) NULL," +
                $"  `allowCreateProducts` TINYINT NOT NULL," +
                $"  `allowEditProducts` TINYINT NOT NULL," +
                $"  `allowDeleteProducts` TINYINT NOT NULL," +
                $"  `allowCreateUsers` TINYINT NOT NULL," +
                $"  `allowEditUsers` TINYINT NOT NULL," +
                $"  `allowDeleteUsers` TINYINT NOT NULL," +
                $"  `allowCreateRoles` TINYINT NOT NULL," +
                $"  `allowEditRoles` TINYINT NOT NULL," +
                $"  `allowDeleteRoles` TINYINT NOT NULL," +
                $"  `allowReporting` TINYINT NOT NULL," +
                $"  `allowProcessSales` TINYINT NOT NULL," +
                $"  `allowAdminOptions` TINYINT NOT NULL," +
                $"  `dateCreated` DATETIME NULL," +
                $"  `dateLastUpdated` DATETIME NULL," +
                $"  `createdBy` VARCHAR(45) NULL," +
                $"  `lastUpdatedBy` VARCHAR(45) NULL," +
                $"  PRIMARY KEY(`roleId`)," +
                $"  UNIQUE INDEX `roleId_UNIQUE` (`roleId` ASC) VISIBLE);";

            // Create Users Table Command
            string createUsersTable =
                $"CREATE TABLE `{databaseName}`.`users` (" +
                $"  `userId` INT NOT NULL," +
                $"  `firstName` VARCHAR(45) NOT NULL," +
                $"  `lastName` VARCHAR(45) NOT NULL," +
                $"  `userName` VARCHAR(45) NOT NULL," +
                $"  `passHash` VARCHAR(256) NOT NULL," +
                $"  `passSalt` VARCHAR(100) NOT NULL," +
                $"  `dateCreated` DATETIME NULL," +
                $"  `dateLastUpdated` DATETIME NULL," +
                $"  `createdBy` VARCHAR(45) NULL," +
                $"  `lastUpdatedBy` VARCHAR(45) NULL," +
                $"  `roleId` INT NOT NULL," +
                $"  PRIMARY KEY(`userId`)," +
                $"  UNIQUE INDEX `userId_UNIQUE` (`userId` ASC) VISIBLE," +
                $"  UNIQUE INDEX `userName_UNIQUE` (`userName` ASC) VISIBLE," +
                $"  CONSTRAINT `userrolekey`" +
                $"    FOREIGN KEY(`roleId`)" +
                $"    REFERENCES `{databaseName}`.`userroles` (`roleId`)" +
                $"    ON DELETE NO ACTION" +
                $"    ON UPDATE NO ACTION);";

            // Create Transactions Table Command
            string createTransactionsTable =
                $"CREATE TABLE `{databaseName}`.`transactions` (" +
                $"  `transactionId` INT NOT NULL," +
                $"  `description` VARCHAR(45) NULL," +
                $"  `dateOfSale` DATETIME NOT NULL," +
                $"  `salesRepId` INT NOT NULL," +
                $"  `customerId` INT NOT NULL," +
                $"  `dateCreated` DATETIME NULL," +
                $"  `dateLastUpdated` DATETIME NULL," +
                $"  `createdBy` VARCHAR(45) NULL," +
                $"  `lastUpdatedBy` VARCHAR(45) NULL," +
                $"  PRIMARY KEY(`transactionId`)," +
                $"  UNIQUE INDEX `transactionId_UNIQUE` (`transactionId` ASC) VISIBLE," +
                $"  INDEX `transactionSalesRepId_idx` (`salesRepId` ASC) VISIBLE," +
                $"  INDEX `transactionCustomerId_idx` (`customerId` ASC) VISIBLE," +
                $"  CONSTRAINT `transactionSalesRepId`" +
                $"    FOREIGN KEY(`salesRepId`)" +
                $"    REFERENCES `{databaseName}`.`users` (`userId`)" +
                $"    ON DELETE NO ACTION" +
                $"    ON UPDATE NO ACTION," +
                $"  CONSTRAINT `transactionCustomerId`" +
                $"    FOREIGN KEY(`customerId`)" +
                $"    REFERENCES `{databaseName}`.`customers` (`customerId`)" +
                $"    ON DELETE NO ACTION" +
                $"    ON UPDATE NO ACTION);";

            // Create Transaction Line Items Table Command
            string createTransactionLineItemsTable =
                $"CREATE TABLE `{databaseName}`.`transactionlineitems` (" +
                $"  `transactionId` INT NOT NULL," +
                $"  `productId` INT NOT NULL," +
                $"  `quantity` INT NULL," +
                $"  `pricePerProduct` DECIMAL NULL," +
                $"  PRIMARY KEY(`transactionId`, `productId`)," +
                $"  INDEX `lineItemProductId_idx` (`productId` ASC) VISIBLE," +
                $"  CONSTRAINT `lineItemTransactionId`" +
                $"    FOREIGN KEY(`transactionId`)" +
                $"    REFERENCES `{databaseName}`.`transactions` (`transactionId`)" +
                $"    ON DELETE NO ACTION" +
                $"    ON UPDATE NO ACTION," +
                $"  CONSTRAINT `lineItemProductId`" +
                $"    FOREIGN KEY(`productId`)" +
                $"    REFERENCES `{databaseName}`.`products` (`productId`)" +
                $"    ON DELETE NO ACTION" +
                $"    ON UPDATE NO ACTION);";

            // Create Consoles Table Command
            string createConsolesTable =
                $"CREATE TABLE `{databaseName}`.`consoles` (" +
                $"  `consoleId` INT NOT NULL," +
                $"  `name` VARCHAR(45) NOT NULL," +
                $"  `developerName` VARCHAR(45) NULL," +
                $"  PRIMARY KEY(`consoleId`)," +
                $"  UNIQUE INDEX `consoleId_UNIQUE` (`consoleId` ASC) VISIBLE);";

            string[] mysqlCommandStrings = new string[] {
                createSchema,
                createCompaniesTable,
                createProductTypesTable,
                createProductsTable,
                createCustomersTable,
                createRolesTable,
                createUsersTable,
                createTransactionsTable,
                createTransactionLineItemsTable,
                createConsolesTable };

            MySqlConnection dbConn = new MySqlConnection(DBConnectionString);

            try {
                dbConn.Open();

                for(int i = 0; i < mysqlCommandStrings.Length; i++) {
                    MySqlCommand command = new MySqlCommand(mysqlCommandStrings[i], dbConn);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show($"Schema Initialized with Database Name \"{databaseName}\"");
            }
            catch(MySqlException ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                dbConn.Close();
            }
        }

        public static int GetProductTypeIDByName(string name) {
            foreach(var type in ProductManager.ProductTypes) {
                if(type.Name == name) {
                    return type.ID;
                }
            }

            return 9999; // 9999 is a failsafe, it refers to the Default option in Product loading of GetAllProducts
        }
        public static UserAccount GetUserByUsername(string username) {
            foreach(var user in Users) {
                if(user.Username == username) {
                    return user;
                }
            }

            return null;
        }
        public static ConsoleCategory GetConsoleByID(int id) {
            foreach(var console in allConsoleTypes) {
                if(console.ID == id) {
                    return console;
                }
            }

            return null;
        }
        public static Company GetCompanyById(int id) {
            foreach(var company in allCompanies) {
                if(company.ID == id) {
                    return company;
                }
            }

            return null;
        }

        private static void OnDbSetupSaved(object sender, EventArgs e) {
            InitializeDBSettings();
            InitializeSchema();
            InsertDefaultData();
            LoadFromDatabase();
        }
    }
}
