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
        public static event EventHandler DatabaseReinitialized;

        private const string ID_TYPE_NAME_GAME = "Video Game";
        private const string ID_TYPE_NAME_CONSOLE = "Console";
        private const string ID_TYPE_NAME_PERIPHERAL = "Peripheral";
        private const string ID_TYPE_NAME_MERCHANDISE = "Merchandise";
        private const string ID_TYPE_NAME_SERVICE = "Service";

        public const string DB_TABLES_COMPANIES = "companies";
        public const string DB_TABLES_CONSOLES = "consoles";
        public const string DB_TABLES_CUSTOMERS = "customers";
        public const string DB_TABLES_PRODUCTS = "products";
        public const string DB_TABLES_PRODUCTTYPES = "producttypes";
        public const string DB_TABLES_LINEITEMS = "transactionlineitems";
        public const string DB_TABLES_TRANSACTIONS = "transactions";
        public const string DB_TABLES_USERROLES = "userroles";
        public const string DB_TABLES_USERS = "users";

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

        // Methods
        public static void Initialize() {
            if(File.Exists(FilePath) == false) {
                CreateDatabaseSettings();
            }
            else {
                InitializeDBSettings();
                LoadFromDatabase();
            }
        }
        public static void ReinitializeDatabase(DatabaseSettingsForm form) {
            // Initialize DB Settings
            InitializeDBSettings();

            // Drop Schema from Database
            string dropString = $"DROP SCHEMA {databaseName};";

            MySqlConnection dbConn = new MySqlConnection($"Server={databaseAddress};Port={databasePort};Uid={databaseUser};Pwd={databasePassword};");
            MySqlCommand dropCommand = new MySqlCommand(dropString, dbConn);

            try {
                dbConn.Open();
                dropCommand.ExecuteNonQuery();
            }
            catch(MySqlException ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                dbConn.Close();
            }

            // Empty Lists
            allCompanies.Clear();
            allConsoleTypes.Clear();
            allCustomers.Clear();
            allLineItems.Clear();
            allTransactions.Clear();
            allUsers.Clear();
            allRoles.Clear();
            ProductManager.ProductTypes.Clear();
            ProductManager.Products.Clear();

            // Perform Initial Setups
            InitializeSchema();
            InsertDefaultData();

            // Force Application Logout
            MessageBox.Show("Returning to Login");
            form.Close();

            Initialize();

            DatabaseReinitialized?.Invoke(null, EventArgs.Empty);
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
                $"CREATE TABLE `{databaseName}`.`{DB_TABLES_COMPANIES}` (" +
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
                $"CREATE TABLE `{databaseName}`.`{DB_TABLES_PRODUCTTYPES}` (" +
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
                $"CREATE TABLE `{databaseName}`.`{DB_TABLES_PRODUCTS}` (" +
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
                $"CREATE TABLE `{databaseName}`.`{DB_TABLES_CUSTOMERS}` (" +
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
                $"CREATE TABLE `{databaseName}`.`{DB_TABLES_USERROLES}` (" +
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
                $"CREATE TABLE `{databaseName}`.`{DB_TABLES_USERS}` (" +
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
                $"CREATE TABLE `{databaseName}`.`{DB_TABLES_TRANSACTIONS}` (" +
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
                $"CREATE TABLE `{databaseName}`.`{DB_TABLES_LINEITEMS}` (" +
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
                $"CREATE TABLE `{databaseName}`.`{DB_TABLES_CONSOLES}` (" +
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
                $"INSERT INTO {databaseName}.{DB_TABLES_COMPANIES} VALUES(0, 'RetroWave Collections', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO {databaseName}.{DB_TABLES_COMPANIES} VALUES(1, 'Nintendo', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO {databaseName}.{DB_TABLES_COMPANIES} VALUES(2, 'Sega', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO {databaseName}.{DB_TABLES_COMPANIES} VALUES(3, 'Sony', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO {databaseName}.{DB_TABLES_COMPANIES} VALUES(4, 'Insomniac Games', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO {databaseName}.{DB_TABLES_COMPANIES} VALUES(5, 'Zener Works', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');";

            string defaultProductTypes =
                $"INSERT INTO {databaseName}.{DB_TABLES_PRODUCTTYPES} VALUES(0, 'Video Game', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO {databaseName}.{DB_TABLES_PRODUCTTYPES} VALUES(1, 'Console', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO {databaseName}.{DB_TABLES_PRODUCTTYPES} VALUES(2, 'Merchandise', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO {databaseName}.{DB_TABLES_PRODUCTTYPES} VALUES(3, 'Peripheral', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO {databaseName}.{DB_TABLES_PRODUCTTYPES} VALUES(4, 'Service', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');";

            string defaultConsoles =
                $"INSERT INTO {databaseName}.{DB_TABLES_CONSOLES} VALUES(0, 'NONE', 'NONE');" +
                $"INSERT INTO {databaseName}.{DB_TABLES_CONSOLES} VALUES(1, 'Nintendo 64', 'Nintendo');" +
                $"INSERT INTO {databaseName}.{DB_TABLES_CONSOLES} VALUES(2, 'Sony Playstation (PSX)', 'Sony');" +
                $"INSERT INTO {databaseName}.{DB_TABLES_CONSOLES} VALUES(3, 'Super Nintendo', 'Nintendo');" +
                $"INSERT INTO {databaseName}.{DB_TABLES_CONSOLES} VALUES(4, 'Original Gameboy', 'Nintendo');" +
                $"INSERT INTO {databaseName}.{DB_TABLES_CONSOLES} VALUES(5, 'Sega Genesis', 'Sega');" +
                $"INSERT INTO {databaseName}.{DB_TABLES_CONSOLES} VALUES(6, 'Playstation 2', 'Sony');";

            string defaultProducts =
                $"INSERT INTO {databaseName}.{DB_TABLES_PRODUCTS} VALUES(0, 'Super Nintendo Entertainment System [CIB]', 3, 1, '1991-8-23 00:00:00', 0, 2, 1, 1, 35.00, 45.99, 3, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin', '');" +
                $"INSERT INTO {databaseName}.{DB_TABLES_PRODUCTS} VALUES(1, 'Nintendo 64 System [Loose]', 1, 1, '1996-9-29 00:00:00', 0, 1, 1, 1, 45.00, 55.99, 4, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin', '');" +
                $"INSERT INTO {databaseName}.{DB_TABLES_PRODUCTS} VALUES(2, 'Super Mario World', 3, 1, '1991-8-23 00:00:00', 0, 1, 1, 0, 30.79, 49.99, 8, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin', '');" +
                $"INSERT INTO {databaseName}.{DB_TABLES_PRODUCTS} VALUES(3, 'Donkey Kong 64', 1, 1, '1999-11-4 00:00:00', 0, 1, 1, 0, 34.99, 44.95, 5, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin', '');" +
                $"INSERT INTO {databaseName}.{DB_TABLES_PRODUCTS} VALUES(4, 'Spyro the Dragon', 2, 4, '1998-9-9 00:00:00', 0, 1, 1, 0, 12.95, 17.99, 2, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin', '');" +
                $"INSERT INTO {databaseName}.{DB_TABLES_PRODUCTS} VALUES(5, 'Okage Shadow King', 6, 5, '2001-10-1 00:00:00', 0, 1, 1, 0, 19.69, 24.95, 1, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin', '');" +
                $"INSERT INTO {databaseName}.{DB_TABLES_PRODUCTS} VALUES(6, 'Mario Kart 64', 1, 1, '1997-2-10 00:00:00', 0, 1, 1, 0, 24.99, 39.99, 1, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin', '');" +
                $"INSERT INTO {databaseName}.{DB_TABLES_PRODUCTS} VALUES(7, 'Nintendo 64 Controller (Blue)', 1, 1, '1996-9-29 00:00:00', 0, 1, 1, 3, 15.99, 21.95, 3, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin', '');" +
                $"INSERT INTO {databaseName}.{DB_TABLES_PRODUCTS} VALUES(8, 'Pikachu Plush (1998)', NULL, 1, '1998-1-1 00:00:00', 0, 1, 1, 2, 23.95, 34.99, 1, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin', '1998 Original Plush of Pikachu');" +
                $"INSERT INTO {databaseName}.{DB_TABLES_PRODUCTS} VALUES(9, 'Console Repair Service', NULL, 0, '1998-1-1 00:00:00', 0, 1, 1, 4, 15.00, 75.00, 0, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin', 'Diagnostics and Repair of Console -- Parts not included');";

            string defaultUserRoles =
                $"INSERT INTO {databaseName}.{DB_TABLES_USERROLES} VALUES(0, 'Admin', 'Built-In Administrator Account', true, true, true, true, true, true, true, true, true, true, true, true, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO {databaseName}.{DB_TABLES_USERROLES} VALUES(1, 'User', 'Built-In Standard User Account', true, true, false, false, false, false, false, false, false, false, true, false, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');";

            string defaultUsers =
                $"INSERT INTO {databaseName}.{DB_TABLES_USERS} VALUES(0, 'Admin', '', 'Admin', 'Y3NhN68hLclf9oCLY6U89OFat3a+HsVYATg8WjxnydFM2w74m80x5mLfVbR9h8N0wpWECopUesKSyuG2oV+j9w==', 'TNsO+JvNMeZi31W0fYfDdMKVhAqKVHrCksrhtqFfo/c=', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin', 0);";

            string defaultCustomers =
                $"INSERT INTO {databaseName}.{DB_TABLES_CUSTOMERS} VALUES(0, 'Guest', 'Customer', '', '', '', '', '', '', '', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO {databaseName}.{DB_TABLES_CUSTOMERS} VALUES(1, 'John', 'Smith', '123 N Broadway', 'Suite 103', 'Rochester', 'MN', '55906', '111-222-3333', 'jsmith@everyman.com', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');";

            string defaultTransactions =
                $"INSERT INTO {databaseName}.{DB_TABLES_TRANSACTIONS} VALUES (0, 'Sample Sale', '2021-1-1 08:00:00', 0, 1, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');";

            string defaultTransactionLineItems =
                $"INSERT INTO {databaseName}.{DB_TABLES_LINEITEMS} VALUES (0, 0, 1, 45.99);" +
                $"INSERT INTO {databaseName}.{DB_TABLES_LINEITEMS} VALUES(0, 1, 1, 60.00);";

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

                MySqlCommand getUserRolesCommand = new MySqlCommand($"SELECT * FROM {databaseName}.{DB_TABLES_USERROLES}", dbConn);
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

                MySqlCommand getUsersCommand = new MySqlCommand($"SELECT * FROM {databaseName}.{DB_TABLES_USERS}", dbConn);
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

                MySqlCommand getConsolesCommand = new MySqlCommand($"SELECT * FROM {databaseName}.{DB_TABLES_CONSOLES}", dbConn);
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

                MySqlCommand getCustomersCommand = new MySqlCommand($"SELECT * FROM {databaseName}.{DB_TABLES_CUSTOMERS}", dbConn);
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

                MySqlCommand getCompaniesCommand = new MySqlCommand($"SELECT * FROM {databaseName}.{DB_TABLES_COMPANIES}", dbConn);
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

                MySqlCommand getTypesCommand = new MySqlCommand($"SELECT * FROM {databaseName}.{DB_TABLES_PRODUCTTYPES}", dbConn);
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

                MySqlCommand getProductsCommand = new MySqlCommand($"SELECT * FROM {databaseName}.{DB_TABLES_PRODUCTS}", dbConn);
                MySqlDataReader reader = getProductsCommand.ExecuteReader();

                while(reader.Read()) {
                    int typeId = reader.GetInt32(columnProductType);

                    if(typeId == ProductManager.GetProductTypeIDByName(ID_TYPE_NAME_GAME)) {
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
                    else if(typeId == ProductManager.GetProductTypeIDByName(ID_TYPE_NAME_CONSOLE)) {
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
                    else if(typeId == ProductManager.GetProductTypeIDByName(ID_TYPE_NAME_MERCHANDISE)) {
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
                    else if(typeId == ProductManager.GetProductTypeIDByName(ID_TYPE_NAME_PERIPHERAL)) {
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
                    else if(typeId == ProductManager.GetProductTypeIDByName(ID_TYPE_NAME_SERVICE)) {
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

                MySqlCommand getItemsCommand = new MySqlCommand($"SELECT * FROM {databaseName}.{DB_TABLES_LINEITEMS}", dbConn);
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

                MySqlCommand getTransactionsCommand = new MySqlCommand($"SELECT * FROM {databaseName}.{DB_TABLES_TRANSACTIONS}", dbConn);
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

        public static int GetNewUserID() {
            return allUsers.ElementAt(allUsers.Count - 1).ID + 1;
        }
        public static int GetNewUserRoleID() {
            return allRoles.ElementAt(allRoles.Count - 1).ID + 1;
        }
        public static int GetNewConsoleTypeID() {
            return allConsoleTypes.ElementAt(allConsoleTypes.Count - 1).ID + 1;
        }
        public static int GetNewCustomerID() {
            return allCustomers.ElementAt(allCustomers.Count - 1).ID + 1;
        }
        public static int GetNewCompanyID() {
            return allCompanies.ElementAt(allCompanies.Count - 1).ID + 1;
        }
        public static int GetNewProductTypeID() {
            return ProductManager.ProductTypes.ElementAt(ProductManager.ProductTypes.Count - 1).ID + 1;
        }
        public static int GetNewProductID() {
            Product lastProduct = ProductManager.Products.ElementAt(ProductManager.Products.Count - 1) as Product;
            return lastProduct.ID + 1;
        }
        public static int GetNewTransactionID() {
            return allTransactions.ElementAt(allTransactions.Count - 1).ID + 1;
        }

        public static void AddNewCustomer(Customer customer) {
            string customerValues = GetNewCustomerValuesString(customer);

            AddNewItemToDatabase(DB_TABLES_CUSTOMERS, customerValues);

            allCustomers.Add(customer);
        }
        public static void AddNewProduct(Product product) {
            string productValues = GetNewProductValuesString(product);

            AddNewItemToDatabase(DB_TABLES_PRODUCTS, productValues);

            ProductManager.Products.Add(product);
        }
        public static void AddNewProductType(ProductType type) {
            string typeValues = GetNewProductTypeValuesString(type);

            AddNewItemToDatabase(DB_TABLES_PRODUCTTYPES, typeValues);

            ProductManager.ProductTypes.Add(type);
        }
        public static void AddNewUser(UserAccount user) {
            string userValues = GetNewUserValuesString(user);

            AddNewItemToDatabase(DB_TABLES_USERS, userValues);

            allUsers.Add(user);
        }
        public static void AddNewUserRole(UserRole role) {
            string roleValues = GetNewUserRoleValuesString(role);

            AddNewItemToDatabase(DB_TABLES_USERROLES, roleValues);

            allRoles.Add(role);
        }
        public static void AddNewCompany(Company company) {
            string companyValues = GetNewCompanyValuesString(company);

            AddNewItemToDatabase(DB_TABLES_COMPANIES, companyValues);

            allCompanies.Add(company);
        }
        public static void AddNewConsoleType(ConsoleCategory console) {
            string consoleValues = GetNewConsoleValuesString(console);

            AddNewItemToDatabase(DB_TABLES_CONSOLES, consoleValues);

            allConsoleTypes.Add(console);
        }
        public static void AddNewTransaction(TransactionSale sale) {
            string transactionValuesString = GetNewTransactionValuesString(sale);

            AddNewItemToDatabase(DB_TABLES_TRANSACTIONS, transactionValuesString);

            foreach(var lineItem in sale.Items) {
                AddNewTransactionLineItem(lineItem);
            }

            allTransactions.Add(sale);
        }
        public static void AddNewTransactionLineItem(TransactionLineItem item) {
            string lineItemValues = GetNewTransactionItemValuesString(item);

            AddNewItemToDatabase(DB_TABLES_LINEITEMS, lineItemValues);

            allLineItems.Add(item);
        }

        private static string GetNewCustomerValuesString(Customer customer) {
            string customerValues =
                $"{customer.ID}," +
                $"'{customer.FirstName}'," +
                $"'{customer.LastName}'," +
                $"'{customer.Address1}'," +
                $"'{customer.Address2}'," +
                $"'{customer.City}'," +
                $"'{customer.StateAbbr}'," +
                $"'{customer.ZipCode}'," +
                $"'{customer.Phone}'," +
                $"'{customer.Email}'," +
                $"'{customer.DateCreated.ToUniversalTime():yyyy-MM-dd HH:mm:ss}'," +
                $"'{customer.LastUpdated.ToUniversalTime():yyyy-MM-dd HH:mm:ss}'," +
                $"'{customer.CreatedBy}'," +
                $"'{customer.LastUpdatedBy}";

            return customerValues;
        }
        private static string GetNewProductValuesString(Product product) {
            string productValues =
                $"{product.ID}," +
                $"'{product.Name}',";

            if(product.ProductTypeID == ProductManager.GetProductTypeIDByName(ID_TYPE_NAME_GAME)) {
                VideoGame game = product as VideoGame;
                productValues += $"{game.Console.ID},";
            }
            else {
                productValues += $"0,";
            }

            productValues = productValues +
                $"{product.Developer.ID},";

            if(product.ProductTypeID == ProductManager.GetProductTypeIDByName(ID_TYPE_NAME_GAME)) {
                VideoGame game = product as VideoGame;

                productValues +=
                    $"'{game.Released.ToUniversalTime():yyyy-MM-dd HH:mm:ss}',";
            }
            else if(product.ProductTypeID == ProductManager.GetProductTypeIDByName(ID_TYPE_NAME_CONSOLE)) {
                VideoGameConsole console = product as VideoGameConsole;

                productValues +=
                    $"'{console.Released.ToUniversalTime():yyyy-MM-dd HH:mm:ss}',";
            }
            else if(product.ProductTypeID == ProductManager.GetProductTypeIDByName(ID_TYPE_NAME_PERIPHERAL)) {
                Peripheral peripheral = product as Peripheral;

                productValues +=
                    $"'{peripheral.Released.ToUniversalTime():yyyy-MM-dd HH:mm:ss}',";
            }
            else if(product.ProductTypeID == ProductManager.GetProductTypeIDByName(ID_TYPE_NAME_MERCHANDISE)) {
                GameMerchandise merch = product as GameMerchandise;

                productValues +=
                    $"'{merch.Released.ToUniversalTime():yyyy-MM-dd HH:mm:ss}',";
            }
            else {
                productValues +=
                    $"'{DateTime.Now.ToUniversalTime():yyyy-MM-dd HH:mm:ss}',";
            }

            productValues = productValues +
                $"{(int)product.Quality}," +
                $"{(int)product.Completion}," +
                $"{(int)product.Region}," +
                $"{product.ProductTypeID}," +
                $"{product.Cost}," +
                $"{product.Price}," +
                $"{product.OnHand}," +
                $"'{product.DateCreated.ToUniversalTime():yyyy-MM-dd HH:mm:ss}'," +
                $"'{product.LastUpdated.ToUniversalTime():yyyy-MM-dd HH:mm:ss}'," +
                $"'{product.CreatedBy}'," +
                $"'{product.LastUpdatedBy}'," +
                $"'{product.Description}'";

            return productValues;
        }
        private static string GetNewProductTypeValuesString(ProductType type) {
            string typeValues =
                $"{type.ID}," +
                $"{type.Name}," +
                $"'{type.DateCreated.ToUniversalTime():yyyy-MM-dd HH:mm:ss}'," +
                $"'{type.LastUpdated.ToUniversalTime():yyyy-MM-dd HH:mm:ss}'," +
                $"'{type.CreatedBy}'," +
                $"'{type.LastUpdatedBy}";

            return typeValues;
        }
        private static string GetNewUserValuesString(UserAccount user) {
            string userValues =
                $"{user.ID}," +
                $"{user.FirstName}," +
                $"{user.LastName}," +
                $"{user.Username}," +
                $"{user.PassHash}," +
                $"{user.Salt}," +
                $"'{user.DateCreated.ToUniversalTime():yyyy-MM-dd HH:mm:ss}'," +
                $"'{user.LastUpdated.ToUniversalTime():yyyy-MM-dd HH:mm:ss}'," +
                $"'{user.CreatedBy}'," +
                $"'{user.LastUpdatedBy}";

            return userValues;
        }
        private static string GetNewUserRoleValuesString(UserRole role) {
            string roleValues =
                $"{role.ID}," +
                $"{role.Name}," +
                $"{role.Description}," +
                $"{role.Permissions[UserRole.Permission.AllowCreateProducts]}," +
                $"{role.Permissions[UserRole.Permission.AllowEditProducts]}," +
                $"{role.Permissions[UserRole.Permission.AllowDeleteProducts]}," +
                $"{role.Permissions[UserRole.Permission.AllowCreateUsers]}," +
                $"{role.Permissions[UserRole.Permission.AllowEditUsers]}," +
                $"{role.Permissions[UserRole.Permission.AllowDeleteUsers]}," +
                $"{role.Permissions[UserRole.Permission.AllowCreateRoles]}," +
                $"{role.Permissions[UserRole.Permission.AllowEditRoles]}," +
                $"{role.Permissions[UserRole.Permission.AllowDeleteRoles]}," +
                $"{role.Permissions[UserRole.Permission.AllowReporting]}," +
                $"{role.Permissions[UserRole.Permission.AllowProcessSales]}," +
                $"{role.Permissions[UserRole.Permission.AllowAdminControls]}," +
                $"'{role.DateCreated.ToUniversalTime():yyyy-MM-dd HH:mm:ss}'," +
                $"'{role.LastUpdated.ToUniversalTime():yyyy-MM-dd HH:mm:ss}'," +
                $"'{role.CreatedBy}'," +
                $"'{role.LastUpdatedBy}";

            return roleValues;
        }
        private static string GetNewCompanyValuesString(Company company) {
            string companyValues =
                $"{company.ID}," +
                $"{company.Name}," +
                $"'{company.DateCreated.ToUniversalTime():yyyy-MM-dd HH:mm:ss}'," +
                $"'{company.LastUpdated.ToUniversalTime():yyyy-MM-dd HH:mm:ss}'," +
                $"'{company.CreatedBy}'," +
                $"'{company.LastUpdatedBy}";

            return companyValues;
        }
        private static string GetNewConsoleValuesString(ConsoleCategory console) {
            string consoleValues =
                $"{console.ID}," +
                $"{console.Name}," +
                $"{console.Developer}";

            return consoleValues;
        }
        private static string GetNewTransactionValuesString(TransactionSale sale) {
            string transactionValues =
                $"{sale.ID}," +
                $"'{sale.Description}'," +
                $"'{sale.DateOfSale.ToUniversalTime():yyyy-MM-dd HH:mm:ss}'," +
                $"{sale.SalesRepID}," +
                $"{sale.CustomerID}," +
                $"'{sale.DateCreated.ToUniversalTime():yyyy-MM-dd HH:mm:ss}'," +
                $"'{sale.LastUpdated.ToUniversalTime():yyyy-MM-dd HH:mm:ss}'," +
                $"'{sale.CreatedBy}'," +
                $"'{sale.LastUpdatedBy}'";

            return transactionValues;
        }
        private static string GetNewTransactionItemValuesString(TransactionLineItem item) {
            string lineItemValues =
                $"{item.TransactionID}," +
                $"{item.ProductID}," +
                $"{item.Quantity}," +
                $"{item.PricePerProduct}";

            return lineItemValues;
        }

        public static void UpdateCustomer(Customer customer) {
            string customerValues = GetUpdateCustomerValuesString(customer);
            string where = $"customerId={customer.ID}";

            UpdateItemInDatebase(DB_TABLES_CUSTOMERS, customerValues, where);
        }
        public static void UpdateProduct(Product product) {
            string productValues = GetUpdateProductValuesString(product);
            string where = $"productId={product.ID}";

            UpdateItemInDatebase(DB_TABLES_PRODUCTS, productValues, where);
        }
        public static void UpdateProductType(ProductType type) {
            string typeValues = GetUpdateProductTypeValuesString(type);
            string where = $"productTypeId={type.ID}";

            UpdateItemInDatebase(DB_TABLES_PRODUCTTYPES, typeValues, where);
        }
        public static void UpdateUser(UserAccount user) {
            string userValues = GetUpdateUserValuesString(user);
            string where = $"userId={user.ID}";

            UpdateItemInDatebase(DB_TABLES_USERS, userValues, where);
        }
        public static void UpdateUserRole(UserRole role) {
            string roleValues = GetUpdateUserRoleValuesString(role);
            string where = $"roleId={role.ID}";

            UpdateItemInDatebase(DB_TABLES_USERROLES, roleValues, where);
        }
        public static void UpdateCompany(Company company) {
            string companyValues = GetUpdateCompanyValuesString(company);
            string where = $"companyId={company.ID}";

            UpdateItemInDatebase(DB_TABLES_COMPANIES, companyValues, where);
        }
        public static void UpdateConsoleType(ConsoleCategory console) {
            string consoleValues = GetUpdateConsoleValuesString(console);
            string where = $"consoleId={console.ID}";

            UpdateItemInDatebase(DB_TABLES_CONSOLES, consoleValues, where);
        }
        public static void UpdateTransaction(TransactionSale sale) {
            string transactionValuesString = GetUpdateTransactionValuesString(sale);
            string where = $"transactionId={sale.ID}";

            UpdateItemInDatebase(DB_TABLES_TRANSACTIONS, transactionValuesString, where);

            foreach(var lineItem in sale.Items) {
                UpdateTransactionLineItem(lineItem);
            }
        }
        public static void UpdateTransactionLineItem(TransactionLineItem item) {
            string lineItemValues = GetUpdateTransactionItemValuesString(item);
            string where = $"transactionId={item.TransactionID} AND productId={item.ProductID}";

            UpdateItemInDatebase(DB_TABLES_LINEITEMS, lineItemValues, where);
        }

        private static string GetUpdateCustomerValuesString(Customer customer) {
            string customerValues =
                $"customerId={customer.ID}," +
                $"firstName='{customer.FirstName}'," +
                $"lastName='{customer.LastName}'," +
                $"address1='{customer.Address1}'," +
                $"address2='{customer.Address2}'," +
                $"city='{customer.City}'," +
                $"stateAbbr='{customer.StateAbbr}'," +
                $"zipCode='{customer.ZipCode}'," +
                $"phoneNumber='{customer.Phone}'," +
                $"email='{customer.Email}'," +
                $"dateCreated='{customer.DateCreated.ToUniversalTime():yyyy-MM-dd HH:mm:ss}'," +
                $"dateLastUpdated='{customer.LastUpdated.ToUniversalTime():yyyy-MM-dd HH:mm:ss}'," +
                $"createdBy='{customer.CreatedBy}'," +
                $"lastUpdatedBy='{customer.LastUpdatedBy}";

            return customerValues;
        }
        private static string GetUpdateProductValuesString(Product product) {
            string productValues =
                $"productId={product.ID}," +
                $"name='{product.Name}',";

            if(product.ProductTypeID == ProductManager.GetProductTypeIDByName(ID_TYPE_NAME_GAME)) {
                VideoGame game = product as VideoGame;
                productValues += $"consoleId={game.Console.ID},";
            }
            else {
                productValues += $"consoleId=0,";
            }

            productValues = productValues +
                $"developerId={product.Developer.ID},";

            if(product.ProductTypeID == ProductManager.GetProductTypeIDByName(ID_TYPE_NAME_GAME)) {
                VideoGame game = product as VideoGame;

                productValues +=
                    $"dateReleased='{game.Released.ToUniversalTime():yyyy-MM-dd HH:mm:ss}',";
            }
            else if(product.ProductTypeID == ProductManager.GetProductTypeIDByName(ID_TYPE_NAME_CONSOLE)) {
                VideoGameConsole console = product as VideoGameConsole;

                productValues +=
                    $"dateReleased='{console.Released.ToUniversalTime():yyyy-MM-dd HH:mm:ss}',";
            }
            else if(product.ProductTypeID == ProductManager.GetProductTypeIDByName(ID_TYPE_NAME_PERIPHERAL)) {
                Peripheral peripheral = product as Peripheral;

                productValues +=
                    $"dateReleased='{peripheral.Released.ToUniversalTime():yyyy-MM-dd HH:mm:ss}',";
            }
            else if(product.ProductTypeID == ProductManager.GetProductTypeIDByName(ID_TYPE_NAME_MERCHANDISE)) {
                GameMerchandise merch = product as GameMerchandise;

                productValues +=
                    $"dateReleased='{merch.Released.ToUniversalTime():yyyy-MM-dd HH:mm:ss}',";
            }
            else {
                productValues +=
                    $"dateReleased='{DateTime.Now.ToUniversalTime():yyyy-MM-dd HH:mm:ss}',";
            }

            productValues = productValues +
                $"quality={(int)product.Quality}," +
                $"completion={(int)product.Completion}," +
                $"region={(int)product.Region}," +
                $"productTypeId={product.ProductTypeID}," +
                $"cost={product.Cost}," +
                $"price={product.Price}," +
                $"onHand={product.OnHand}," +
                $"dateCreated='{product.DateCreated.ToUniversalTime():yyyy-MM-dd HH:mm:ss}'," +
                $"dateLastUpdated='{product.LastUpdated.ToUniversalTime():yyyy-MM-dd HH:mm:ss}'," +
                $"createdBy='{product.CreatedBy}'," +
                $"lastUpdatedBy='{product.LastUpdatedBy}'," +
                $"description='{product.Description}'";

            return productValues;
        }
        private static string GetUpdateProductTypeValuesString(ProductType type) {
            string typeValues =
                $"productTypeId={type.ID}," +
                $"name={type.Name}," +
                $"dateCreated='{type.DateCreated.ToUniversalTime():yyyy-MM-dd HH:mm:ss}'," +
                $"dateLastUpdated='{type.LastUpdated.ToUniversalTime():yyyy-MM-dd HH:mm:ss}'," +
                $"createdBy='{type.CreatedBy}'," +
                $"lastUpdatedBy='{type.LastUpdatedBy}";

            return typeValues;
        }
        private static string GetUpdateUserValuesString(UserAccount user) {
            string userValues = 
                $"userId={user.ID}," +
                $"firstName={user.FirstName}," +
                $"lastName={user.LastName}," +
                $"username={user.Username}," +
                $"passHash={user.PassHash}," +
                $"passSalt={user.Salt}," +
                $"dateCreated='{user.DateCreated.ToUniversalTime():yyyy-MM-dd HH:mm:ss}'," +
                $"dateLastUpdated='{user.LastUpdated.ToUniversalTime():yyyy-MM-dd HH:mm:ss}'," +
                $"createdBy='{user.CreatedBy}'," +
                $"lastUpdatedBy='{user.LastUpdatedBy}";

            return userValues;
        }
        private static string GetUpdateUserRoleValuesString(UserRole role) {
            string roleValues = 
                $"roleId={role.ID}," +
                $"name={role.Name}," +
                $"description={role.Description}," +
                $"allowCreateProducts={role.Permissions[UserRole.Permission.AllowCreateProducts]}," +
                $"allowEditProducts={role.Permissions[UserRole.Permission.AllowEditProducts]}," +
                $"allowDeleteProducts={role.Permissions[UserRole.Permission.AllowDeleteProducts]}," +
                $"allowCreateUsers={role.Permissions[UserRole.Permission.AllowCreateUsers]}," +
                $"allowEditUsers={role.Permissions[UserRole.Permission.AllowEditUsers]}," +
                $"allowDeleteUsers={role.Permissions[UserRole.Permission.AllowDeleteUsers]}," +
                $"allowCreateRoles={role.Permissions[UserRole.Permission.AllowCreateRoles]}," +
                $"allowEditRoles={role.Permissions[UserRole.Permission.AllowEditRoles]}," +
                $"allowDeleteRoles={role.Permissions[UserRole.Permission.AllowDeleteRoles]}," +
                $"allowReporting={role.Permissions[UserRole.Permission.AllowReporting]}," +
                $"allowProcessSales={role.Permissions[UserRole.Permission.AllowProcessSales]}," +
                $"allowAdminOptions={role.Permissions[UserRole.Permission.AllowAdminControls]}," +
                $"dateCreated='{role.DateCreated.ToUniversalTime():yyyy-MM-dd HH:mm:ss}'," +
                $"dateLastUpdated='{role.LastUpdated.ToUniversalTime():yyyy-MM-dd HH:mm:ss}'," +
                $"createdBy='{role.CreatedBy}'," +
                $"lastUpdatedBy='{role.LastUpdatedBy}";

            return roleValues;
        }
        private static string GetUpdateCompanyValuesString(Company company) {
            string companyValues = 
                $"companyId={company.ID}," +
                $"name={company.Name}," +
                $"dateCreated='{company.DateCreated.ToUniversalTime():yyyy-MM-dd HH:mm:ss}'," +
                $"dateLastUpdated='{company.LastUpdated.ToUniversalTime():yyyy-MM-dd HH:mm:ss}'," +
                $"createdBy='{company.CreatedBy}'," +
                $"lastUpdatedBy='{company.LastUpdatedBy}";

            return companyValues;
        }
        private static string GetUpdateConsoleValuesString(ConsoleCategory console) {
            string consoleValues =
                $"consoleId={console.ID}," +
                $"name={console.Name}," +
                $"developerName={console.Developer}";

            return consoleValues;
        }
        private static string GetUpdateTransactionValuesString(TransactionSale sale) {
            string transactionValues = 
                $"transactionId={sale.ID}," +
                $"description={sale.Description}," +
                $"dateOfSale={sale.DateOfSale.ToUniversalTime():yyyy-MM-dd HH:mm:ss}," +
                $"salesRepId={sale.SalesRepID}," +
                $"customerId={sale.CustomerID}," +
                $"dateCreated='{sale.DateCreated.ToUniversalTime():yyyy-MM-dd HH:mm:ss}'," +
                $"dateLastUpdated='{sale.LastUpdated.ToUniversalTime():yyyy-MM-dd HH:mm:ss}'," +
                $"createdBy='{sale.CreatedBy}'," +
                $"lastUpdatedBy='{sale.LastUpdatedBy}";

            return transactionValues;
        }
        private static string GetUpdateTransactionItemValuesString(TransactionLineItem item) {
            string lineItemValues =
                $"transactionId={item.TransactionID}," +
                $"productId={item.ProductID}," +
                $"quantity={item.Quantity}," +
                $"pricePerProduct={item.PricePerProduct}";

            return lineItemValues;
        }

        public static void DeleteCustomer(Customer customer) {

        }
        public static void DeleteProduct(Product product) {

        }
        public static void DeleteProductType(ProductType type) {

        }
        public static void DeleteUser(UserAccount user) {


        }
        public static void DeleteUserRole(UserRole role) {
            if(role.ID == 0 || role.ID == 1) {
                MessageBox.Show($"Cannot Delete Built-In Roles");
            }
            else {
                DeleteItemsFromDatabase(DB_TABLES_USERROLES, $"roleId={role.ID}");

                foreach(UserAccount user in allUsers) {
                    // Check for Users with this role and re-assign them to Standard Role

                }

                allRoles.Remove(role);
            }
        }
        public static void DeleteCompany(Company company) {
            DeleteItemsFromDatabase(DB_TABLES_COMPANIES, $"companyId={company.ID}");

            allCompanies.Remove(company);
        }
        public static void DeleteConsoleType(ConsoleCategory console) {
            DeleteItemsFromDatabase(DB_TABLES_CONSOLES, $"consoleId={console.ID}");

            allConsoleTypes.Remove(console);
        }
        public static void DeleteTransaction(TransactionSale transaction) {
            DeleteItemsFromDatabase(DB_TABLES_TRANSACTIONS, $"transactionId={transaction.ID}");

            foreach(var lineItem in transaction.Items) {
                DeleteTransactionLineItem(lineItem);
            }

            allTransactions.Remove(transaction);
        }
        private static void DeleteTransactionLineItem(TransactionLineItem lineItem) {
            DeleteItemsFromDatabase(DB_TABLES_LINEITEMS, $"transactionId={lineItem.TransactionID}");
            allLineItems.Remove(lineItem);
        }

        private static void AddNewItemToDatabase(string tableName, string values) {
            string addString = $"INSERT INTO {databaseName}.{tableName} VALUES({values});";

            MessageBox.Show($"Running following command: \r\n\r\n{addString}");

            MySqlConnection dbConn = new MySqlConnection(DBConnectionString);

            try {
                dbConn.Open();

                MySqlCommand insertCommand = new MySqlCommand(addString, dbConn);
                int count = insertCommand.ExecuteNonQuery();

                if(count > 0) {
                    MessageBox.Show("Database Updated Successful");
                }
            }
            catch(MySqlException ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                dbConn.Close();
            }
        }
        public static void UpdateItemInDatebase(string tableName, string where, string values) {
            string updateString = $"UPDATE {databaseName}.{tableName} SET ({values}) WHERE {where};";

            MySqlConnection dbConn = new MySqlConnection(DBConnectionString);

            try {
                dbConn.Open();

                MySqlCommand updateCommand = new MySqlCommand(updateString, dbConn);
                int count = updateCommand.ExecuteNonQuery();

                if(count > 0) {
                    MessageBox.Show("Database Updated Successful");
                }
            }
            catch(MySqlException ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                dbConn.Close();
            }
        }
        public static void DeleteItemsFromDatabase(string tableName, string where) {
            string deleteString = $"DELETE FROM {databaseName}.{tableName} WHERE {where};";

            MySqlConnection dbConn = new MySqlConnection(DBConnectionString);

            try {
                dbConn.Open();

                MySqlCommand deleteCommand = new MySqlCommand(deleteString, dbConn);
                int count = deleteCommand.ExecuteNonQuery();

                if(count > 0) {
                    MessageBox.Show("Database Updated Successful");
                }
            }
            catch(MySqlException ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                dbConn.Close();
            }
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
        public static Customer GetCustomerById(int id) {
            foreach(var c in allCustomers) {
                if(c.ID == id) {
                    return c;
                }
            }

            return null;
        }

        // Test Methods
        public static int GetRowCount(string tableName) {
            MySqlConnection dbConn = new MySqlConnection(DBConnectionString);
            MySqlCommand command = new MySqlCommand($"SELECT COUNT(*) FROM {databaseName}.{tableName};", dbConn);

            try {
                dbConn.Open();

                return Convert.ToInt32(command.ExecuteScalar());
            }
            catch(MySqlException ex) {
                MessageBox.Show(ex.Message);
                return 0;
            }
            finally {
                dbConn.Close();
            }
        }

        // Event Handlers
        private static void OnDbSetupSaved(object sender, EventArgs e) {
            InitializeDBSettings();
            InitializeSchema();
            InsertDefaultData();
            LoadFromDatabase();
        }
    }
}
