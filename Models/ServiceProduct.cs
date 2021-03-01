using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroCollector.Models {
    public class ServiceProduct : Product {
        private string name;

        public string Name {
            get => name;
        }

        public ServiceProduct(int id, string name, string description, decimal cost, decimal price,
            DateTime dateCreated = default, DateTime dateLastUpdated = default, UserAccount createdBy = null, UserAccount lastUpdatedBy = null) {

            this.id = id;
            this.name = name;
            this.description = description;
            this.cost = cost;
            this.price = price;
            this.dateCreated = dateCreated;
            this.dateLastUpdated = dateLastUpdated;
            this.createdBy = createdBy;
            this.lastUpdatedBy = lastUpdatedBy;
        }
    }
}
