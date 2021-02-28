using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroCollector.Models {
    public class GameCompany : IndexItem {
        private string name;
        private Country country;

        public string Name {
            get { return name; }
        }
        public Country CountryOfOrigin {
            get { return country; }
        }

        public GameCompany(int id, string name, Country country) {
            this.id = id;
            this.name = name;
            this.country = country;
        }
    }
}
