using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroCollector.Models {
    public class AdminUserRole : UserRole {

        public AdminUserRole(int id = 0, string name = "SystemAdmin", string description = "Built-in Administrator Role", Dictionary<Permission, bool> permissions = null, 
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
                { Permission.AllowAdminControls, true },
                { Permission.AllowCreateProducts, true },
                { Permission.AllowCreateRoles, true },
                { Permission.AllowCreateUsers, true },
                { Permission.AllowEditProducts, true },
                { Permission.AllowEditRoles, true },
                { Permission.AllowEditUsers, true },
                { Permission.AllowDeleteProducts, true },
                { Permission.AllowDeleteRoles, true },
                { Permission.AllowDeleteUsers, true },
                { Permission.AllowReporting, true },
                { Permission.AllowProcessSales, true },
            };
        }
    }
}
