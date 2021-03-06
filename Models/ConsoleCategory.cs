using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroCollector.Models {
    public class ConsoleCategory {
        private int id;
        private string name;
        private string developer;

        public int ID {
            get => id;
        }
        public string Name {
            get => name;
        }
        public string Developer {
            get => developer;
        }

        public ConsoleCategory(int id, string name, string developer) {
            this.id = id;
            this.name = name;
            this.developer = developer;
        }

        public override string ToString() {
            return $"[{id}] {name} : {developer}";
        }
    }
}
