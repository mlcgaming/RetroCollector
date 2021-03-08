using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroCollector.Models {
    public class Peripheral : Product {
        private DateTime released;

        public DateTime Released {
            get => released;
        }

        public Peripheral(int id, string name, decimal cost, decimal price, int onHand, Company developer, ProductQuality quality, ProductCompleteness completion,
            ProductRegion region, int productTypeId, string description = "", DateTime released = default, DateTime dateCreated = default, DateTime dateLastUpdated = default, string createdBy = null, string lastUpdatedBy = null) :
            base(id, name, description, cost, price, onHand, developer, quality, completion, region, productTypeId, dateCreated, dateLastUpdated, createdBy, lastUpdatedBy) {

            this.released = released;
        }

        public void Update(int id, string name, decimal cost, decimal price, int onHand, Company developer, ProductQuality quality, ProductCompleteness completion,
            ProductRegion region, int productTypeId, string description = "", DateTime released = default, DateTime dateCreated = default, DateTime dateLastUpdated = default, string createdBy = null, string lastUpdatedBy = null) {

            base.Update(id, name, description, cost, price, onHand, developer, quality, completion, region, productTypeId, dateCreated, dateLastUpdated, createdBy, lastUpdatedBy);

            this.released = released;
        }

        public override string ToString() {
            return $"[Peripheral] {Name} ({Developer}) ${Price}";
        }
    }
}
