using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroCollector.Models {
    public class VideoGame : Product {
        private ConsoleCategory console;
        private DateTime releaseDate;

        public string Title {
            get { return base.name; }
        }
        public ConsoleCategory Console {
            get => console;
        }
        public DateTime Released {
            get { return releaseDate; }
        }

        public VideoGame(int id, string title, decimal cost, decimal price, int onHand, ProductQuality quality, ProductCompleteness completion, ProductRegion region, int productTypeId,
            ConsoleCategory console = null, string description = "", Company developer = null, DateTime releaseDate = default, DateTime dateCreated = default, DateTime dateLastUpdated = default,
            string createdBy = "", string lastUpdatedBy = "") : base(id, title, description, cost, price, onHand, developer, quality, completion, region, productTypeId, dateCreated, dateLastUpdated, createdBy, lastUpdatedBy) {

            this.console = console;
            this.releaseDate = releaseDate;
        }

        public override string ToString() {
            return $"[Game] {Title} ({Developer}) {Price}";
        }
    }
}
