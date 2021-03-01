using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroCollector.Models {
    public class CustomUserRole : UserRole {

        public CustomUserRole(int id, string name, DateTime dateCreated, DateTime dateLastUpdated, UserAccount createdBy, 
            UserAccount lastUpdatedBy, Dictionary<Permission, bool> permissions = null, string description = "") {
            this.id = id;
            this.name = name;
            this.description = description;

            this.dateCreated = dateCreated;
            this.dateLastUpdated = dateLastUpdated;
            this.createdBy = createdBy;
            this.lastUpdatedBy = lastUpdatedBy;

            if(permissions == null) {
                CreateDefaultPermissions();
            }
            else {
                this.permissions = new Dictionary<Permission, bool>(permissions);
            }
        }
    }
}
