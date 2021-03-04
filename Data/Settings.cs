using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroCollector.Data {
    public static class Settings {
        private static string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Night Owl Software\\RetroCollector");
        private static string filename = "settings.xml";

        public static string FilePath {
            get => Path.Combine(directory, filename);
        }

        public static void Initialize() {

        }
        private static void CreateDefaults() {

        }
        private static void LoadFromXML() {

        }
    }
}
