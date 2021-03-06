using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroCollector.Models {
    public class ProductType : IndexItem {
        private string name;

        public string Name {
            get => name;
        }

        public ProductType(int id, string name, DateTime dateCreated, DateTime dateLastUpdated, string createdBy, string lastUpdatedBy) {
            this.id = id;
            this.name = name;
            this.dateCreated = dateCreated;
            this.dateLastUpdated = dateLastUpdated;
            this.createdBy = createdBy;
            this.lastUpdatedBy = lastUpdatedBy;
        }
    }
}
