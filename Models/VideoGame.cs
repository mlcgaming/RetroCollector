using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroCollector.Models {
    public class VideoGame : Product {
        private string title;
        private GameCompany developer;
        private GameCompany publisher;
        private DateTime releaseDate;
        private ProductQuality quality;
        private ProductCompleteness completion;
        private ProductRegion region;

        public string Title {
            get { return title; }
        }
        public GameCompany Developer {
            get { return developer; }
        }
        public GameCompany Publisher {
            get { return publisher; }
        }
        public DateTime Released {
            get { return releaseDate; }
        }
        public ProductQuality Quality {
            get { return quality; }
        }
        public ProductCompleteness Completion {
            get { return completion; }
        }
        public ProductRegion Region {
            get { return region; }
        }

        public VideoGame(int id, string title, decimal cost, decimal price, ProductQuality quality, ProductCompleteness completion, ProductRegion region,
            string description = "", GameCompany developer = null, GameCompany publisher = null, DateTime releaseDate = default) {

            this.id = id;
            this.description = description;
            this.title = title;
            this.cost = cost;
            this.price = price;
            this.quality = quality;
            this.completion = completion;
            this.region = region;
            this.developer = developer;
            this.publisher = publisher;
            this.releaseDate = releaseDate;
        }
    }
}
