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
        private static void InsertDefaultData() {
            // Create Default Companies
            string defaultCompanies =
                $"INSERT INTO retrocollector.companies VALUES(0, 'RetroWave Collections', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO retrocollector.companies VALUES(1, 'Nintendo', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO retrocollector.companies VALUES(2, 'Sega', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO retrocollector.companies VALUES(3, 'Sony', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO retrocollector.companies VALUES(4, 'Insomniac Games', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO retrocollector.companies VALUES(5, 'Zener Works', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');";

            string defaultProductTypes =
                $"INSERT INTO retrocollector.producttypes VALUES(0, 'Video Game');" +
                $"INSERT INTO retrocollector.producttypes VALUES(1, 'Console');" +
                $"INSERT INTO retrocollector.producttypes VALUES(2, 'Merchandise');" +
                $"INSERT INTO retrocollector.producttypes VALUES(3, 'Peripheral');" +
                $"INSERT INTO retrocollector.producttypes VALUES(4, 'Service');";

            string defaultConsoles =
                $"INSERT INTO retrocollector.consoles VALUES(0, 'NONE', 'NONE');" +
                $"INSERT INTO retrocollector.consoles VALUES(1, 'Nintendo 64', 'Nintendo');" +
                $"INSERT INTO retrocollector.consoles VALUES(2, 'Sony Playstation (PSX)', 'Sony');" +
                $"INSERT INTO retrocollector.consoles VALUES(3, 'Super Nintendo', 'Nintendo');" +
                $"INSERT INTO retrocollector.consoles VALUES(4, 'Original Gameboy', 'Nintendo');" +
                $"INSERT INTO retrocollector.consoles VALUES(5, 'Sega Genesis', 'Sega');" +
                $"INSERT INTO retrocollector.consoles VALUES(6, 'Playstation 2', 'Sony');";

            string defaultProducts =
                $"INSERT INTO retrocollector.products VALUES(0, 'Super Nintendo Entertainment System [CIB]', 3, 1, '1991-8-23 00:00:00', 0, 2, 1, 1, 35.00, 45.99, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO retrocollector.products VALUES(1, 'Nintendo 64 System [Loose]', 1, 1, '1996-9-29 00:00:00', 0, 1, 1, 1, 45.00, 55.99, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO retrocollector.products VALUES(2, 'Super Mario World', 3, 1, '1991-8-23 00:00:00', 0, 1, 1, 0, 30.79, 49.99, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO retrocollector.products VALUES(3, 'Donkey Kong 64', 1, 1, '1999-11-4 00:00:00', 0, 1, 1, 0, 34.99, 44.95, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO retrocollector.products VALUES(4, 'Spyro the Dragon', 2, 4, '1998-9-9 00:00:00', 0, 1, 1, 0, 12.95, 17.99, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO retrocollector.products VALUES(5, 'Okage Shadow King', 6, 5, '2001-10-1 00:00:00', 0, 1, 1, 0, 19.69, 24.95, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO retrocollector.products VALUES(6, 'Mario Kart 64', 1, 1, '1997-2-10 00:00:00', 0, 1, 1, 0, 24.99, 39.99, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO retrocollector.products VALUES(7, 'Nintendo 64 Controller (Blue)', 1, 1, '1996-9-29 00:00:00', 0, 1, 1, 3, 15.99, 21.95, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO retrocollector.products VALUES(8, 'Pikachu Plush (1998)', NULL, 1, '1998-1-1 00:00:00', 0, 1, 1, 2, 23.95, 34.99, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO retrocollector.products VALUES(9, 'Console Repair Service', NULL, 0, '1998-1-1 00:00:00', 0, 1, 1, 4, 15.00, 75.00, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');";

            string defaultUserRoles =
                $"INSERT INTO retrocollector.userroles VALUES(0, 'Admin', 'Built-In Administrator Account', true, true, true, true, true, true, true, true, true, true, true, true, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');" +
                $"INSERT INTO retrocollector.userroles VALUES(1, 'User', 'Built-In Standard User Account', true, true, false, false, false, false, false, false, false, false, true, false, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');";

            string defaultUsers =
                $"INSERT INTO retrocollector.users VALUES(0, 'Admin', '', 'Admin', 'Y3NhN68hLclf9oCLY6U89OFat3a+HsVYATg8WjxnydFM2w74m80x5mLfVbR9h8N0wpWECopUesKSyuG2oV+j9w==', 'TNsO+JvNMeZi31W0fYfDdMKVhAqKVHrCksrhtqFfo/c=', '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin', 0);";

            string defaultCustomers =
                $"INSERT INTO retrocollector.customers VALUES(0, 'Guest', 'Customer', '', '', '', '', '', '', '');" +
                $"INSERT INTO retrocollector.customers VALUES(1, 'John', 'Smith', '123 N Broadway', 'Suite 103', 'Rochester', 'MN', '55906', '111-222-3333', 'jsmith@everyman.com');";

            string defaultTransactions =
                $"INSERT INTO retrocollector.transactions VALUES (0, 'Sample Sale', '2021-1-1 08:00:00', 0, 1, '2021-03-01 00:00:00', '2021-03-01 00:00:00', 'Built-In Admin', 'Built-In Admin');";

            string defaultTransactionLineItems =
                $"INSERT INTO retrocollector.transactionLineItems VALUES (0, 0, 1, 45.99);" +
                $"INSERT INTO retrocollector.transactionLineItems VALUES(0, 1, 1, 60.00);";

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

                    if(statementCount == 0) {
                        // Statement Did not Run

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
        private static void InitializeSchema() {
            // Create Schema Command
            string createSchema = $"CREATE SCHEMA `retrocollector`;";

            // Create Companies Table Command
            string createCompaniesTable =
                $"CREATE TABLE `retrocollector`.`companies` (" +
                $"`companyId` INT NOT NULL," +
                $"`name` VARCHAR(45) NOT NULL," +
                $"`dateCreated` DATETIME NULL," +
                $"`dateLastUpdated` DATETIME NULL," +
                $"`createdBy` VARCHAR(45) NULL," +
                $"`lastUpdatedBy` VARCHAR(45) NULL," +
                $"PRIMARY KEY (`companyId`)," +
                $"UNIQUE INDEX `companyId_UNIQUE` (`companyId` ASC) VISIBLE);";

            // Create Product Types Table Command
            string createProductTypesTable =
                $"CREATE TABLE `retrocollector`.`producttypes` (" +
                $"`productTypeId` INT NOT NULL," +
                $"`name` VARCHAR(45) NOT NULL," +
                $"PRIMARY KEY(`productTypeId`)," +
                $"UNIQUE INDEX `productTypeId_UNIQUE` (`productTypeId` ASC) VISIBLE," +
                $"UNIQUE INDEX `name_UNIQUE` (`name` ASC) VISIBLE);";

            // Create Products Table Command
            string createProductsTable =
                $"CREATE TABLE `retrocollector`.`products` (" +
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
                $"`dateCreated` DATETIME NULL," +
                $"`dateLastUpdated` DATETIME NULL," +
                $"`createdBy` VARCHAR(45) NULL," +
                $"`lastUpdatedBy` VARCHAR(45) NULL," +
                $"PRIMARY KEY(`productId`)," +
                $"UNIQUE INDEX `productId_UNIQUE` (`productId` ASC) VISIBLE," +
                $"INDEX `productDeveloperId_idx` (`developerId` ASC) VISIBLE," +
                $"INDEX `productTypeId_idx` (`productTypeId` ASC) VISIBLE," +
                $"CONSTRAINT `productDeveloperId`" +
                $"FOREIGN KEY(`developerId`)" +
                $"REFERENCES `retrocollector`.`companies` (`companyId`)" +
                $"ON DELETE NO ACTION" +
                $"ON UPDATE NO ACTION," +
                $"CONSTRAINT `productTypeId`" +
                $"FOREIGN KEY(`productTypeId`)" +
                $"REFERENCES `retrocollector`.`producttypes` (`productTypeId`)" +
                $"ON DELETE RESTRICT" +
                $"ON UPDATE NO ACTION);";

            // Create Customers Table Command
            string createCustomersTable =
                $"CREATE TABLE `retrocollector`.`customers` (" +
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
                $"  PRIMARY KEY(`customerId`)," +
                $"  UNIQUE INDEX `customerId_UNIQUE` (`customerId` ASC) VISIBLE);";

            // Create User Roles Table Command
            string createRolesTable =
                $"CREATE TABLE `retrocollector`.`userroles` (" +
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
                $"CREATE TABLE `retrocollector`.`users` (" +
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
                $"    REFERENCES `retrocollector`.`userroles` (`roleId`)" +
                $"    ON DELETE NO ACTION" +
                $"    ON UPDATE NO ACTION);";

            // Create Transactions Table Command
            string createTransactionsTable =
                $"CREATE TABLE `retrocollector`.`transactions` (" +
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
                $"    REFERENCES `retrocollector`.`users` (`userId`)" +
                $"    ON DELETE NO ACTION" +
                $"    ON UPDATE NO ACTION," +
                $"  CONSTRAINT `transactionCustomerId`" +
                $"    FOREIGN KEY(`customerId`)" +
                $"    REFERENCES `retrocollector`.`customers` (`customerId`)" +
                $"    ON DELETE NO ACTION" +
                $"    ON UPDATE NO ACTION);";

            // Create Transaction Line Items Table Command
            string createTransactionLineItemsTable =
                $"CREATE TABLE `retrocollector`.`transactionlineitems` (" +
                $"  `transactionId` INT NOT NULL," +
                $"  `productId` INT NOT NULL," +
                $"  `quantity` INT NULL," +
                $"  `pricePerProduct` DECIMAL NULL," +
                $"  PRIMARY KEY(`transactionId`, `productId`)," +
                $"  INDEX `lineItemProductId_idx` (`productId` ASC) VISIBLE," +
                $"  CONSTRAINT `lineItemTransactionId`" +
                $"    FOREIGN KEY(`transactionId`)" +
                $"    REFERENCES `retrocollector`.`transactions` (`transactionId`)" +
                $"    ON DELETE NO ACTION" +
                $"    ON UPDATE NO ACTION," +
                $"  CONSTRAINT `lineItemProductId`" +
                $"    FOREIGN KEY(`productId`)" +
                $"    REFERENCES `retrocollector`.`products` (`productId`)" +
                $"    ON DELETE NO ACTION" +
                $"    ON UPDATE NO ACTION);";

            // Create Consoles Table Command
            string createConsolesTable =
                $"CREATE TABLE `retrocollector`.`consoles` (" +
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
                    int statementCount = command.ExecuteNonQuery();

                    if(statementCount == 0) {
                        // Statement Did Not Run
                        MessageBox.Show($"Issue running command. No statements were processed.\r\n\r\n Statement In Question:\r\n\r\n{mysqlCommandStrings[i]}");
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
