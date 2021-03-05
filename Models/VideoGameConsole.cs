using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroCollector.Models {
    public class VideoGameConsole : Product {
        private Company developer;
        private DateTime released;
        private ProductQuality quality;
        private ProductCompleteness completion;
        private ProductRegion region;
        private List<string> aliases;

        public Company Developer {
            get => developer;
        }
        public DateTime Released {
            get => released;
        }
        public ProductQuality Quality {
            get => quality;
        }
        public ProductCompleteness Completion {
            get => completion;
        }
        public ProductRegion Region {
            get => region;
        }
        public List<string> Aliases {
            get => aliases;
        }

        public VideoGameConsole(int id, string name, decimal cost, decimal price, Company developer, ProductQuality quality, ProductCompleteness completion,
            ProductRegion region, string description = "", DateTime released = default, DateTime dateCreated = default, DateTime dateLastUpdated = default, 
            string createdBy = null, string lastUpdatedBy = null, List<string> aliases = null) {

            this.id = id;
            this.name = name;
            this.cost = cost;
            this.price = price;
            this.developer = developer;
            this.quality = quality;
            this.completion = completion;
            this.region = region;
            this.description = description;
            this.released = released;
            this.dateCreated = dateCreated;
            this.dateLastUpdated = dateLastUpdated;
            this.createdBy = createdBy;
            this.lastUpdatedBy = lastUpdatedBy;

            if(aliases != null) {
                this.aliases = new List<string>(aliases);
            }
            else {
                this.aliases = new List<string>();
            }
            
        }
    }
}
