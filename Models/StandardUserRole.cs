using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroCollector.Models {
    public class StandardUserRole : UserRole {

        public StandardUserRole(int id = 1, string name = "Standard User", string description = "Built-in Standard User Role", Dictionary<Permission, bool> permissions = null,
            DateTime dateCreated = default, DateTime dateLastUpdated = default, UserAccount createdBy = null, UserAccount lastUpdatedBy = null) {
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

        protected override void CreateDefaultPermissions() {
            permissions = new Dictionary<Permission, bool>() {
                { Permission.AllowAdminControls, false },
                { Permission.AllowCreateProducts, true },
                { Permission.AllowCreateRoles, false },
                { Permission.AllowCreateUsers, false },
                { Permission.AllowEditProducts, true },
                { Permission.AllowEditRoles, false },
                { Permission.AllowEditUsers, false },
                { Permission.AllowDeleteProducts, false },
                { Permission.AllowDeleteRoles, false },
                { Permission.AllowDeleteUsers, false },
                { Permission.AllowReporting, false },
                { Permission.AllowProcessSales, true },
            };
        }
    }
}
