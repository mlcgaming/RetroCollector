using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetroCollector.Models;

namespace RetroCollector.Data.Management {
    public static class DatabaseManager {
        private static string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Night Owl Software\\RetroCollector");
        private static string filename = "db.xml";
        private static string databaseAddress;
        private static string databaseName;
        private static int databasePort;
        private static string databaseUser;
        private static string databasePassword;

        public static string FilePath {
            get => (Path.Combine(directory, filename));
        }
        public static string DBConnectionString {
            get => GetConnectionString();
        }

        public static void Initialize() {
            
        }
        private static string GetConnectionString() {
            return $"SERVER={databaseAddress};DATABASE={databaseName};PORT={databasePort};UID={databaseUser};PWD={databasePassword};";
        }
        private static void LoadFromDatabase() {

        }
    }
}
