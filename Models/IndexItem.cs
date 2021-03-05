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
        protected string createdBy;
        protected string lastUpdatedBy;

        public int ID {
            get { return id; }
        }
        public DateTime DateCreated {
            get { return dateCreated; }
        }
        public DateTime LastUpdated {
            get { return dateLastUpdated; }
        }
        public string CreatedBy {
            get { return createdBy; }
        }
        public string LastUpdatedBy {
            get { return lastUpdatedBy; }
        }
    }
}
