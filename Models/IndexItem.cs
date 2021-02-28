using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroCollector.Models {
    public abstract class IndexItem {
        protected int id;
        protected DateTime dateCreated;
        protected DateTime dateLastUpdated;
        protected UserAccount createdBy;
        protected UserAccount lastUpdatedBy;

        public int ID {
            get { return id; }
        }
        public DateTime DateCreated {
            get { return dateCreated; }
        }
        public DateTime LastUpdated {
            get { return dateLastUpdated; }
        }
        public UserAccount CreatedBy {
            get { return createdBy; }
        }
        public UserAccount LastUpdatedBy {
            get { return lastUpdatedBy; }
        }
    }
}
