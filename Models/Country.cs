namespace RetroCollector.Models {
    public class Country : IndexItem {
        private string name;

        public string Name {
            get { return name; }
        }

        public Country(string name) {
            this.name = name;
        }
    }
}