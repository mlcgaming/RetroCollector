using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroCollector.Models {
    public class ServiceProduct : Product {

        public ServiceProduct(int id, string name, string description, decimal cost, decimal price, int productTypeId,
            DateTime dateCreated = default, DateTime dateLastUpdated = default, string createdBy = null, string lastUpdatedBy = null) :
            base(id, name, description, cost, price, 9999, null, ProductQuality.New, ProductCompleteness.New, ProductRegion.OTHER, productTypeId, dateCreated, dateLastUpdated, createdBy, lastUpdatedBy) {
        }
    }
}
