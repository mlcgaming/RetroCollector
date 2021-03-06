﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroCollector.Models {
    public class UserRole : IndexItem, IUserRole {
        public enum Permission {
            AllowCreateProducts,
            AllowEditProducts,
            AllowDeleteProducts,
            AllowCreateUsers,
            AllowEditUsers,
            AllowDeleteUsers,
            AllowCreateRoles,
            AllowEditRoles,
            AllowDeleteRoles,
            AllowReporting,
            AllowProcessSales,
            AllowAdminControls
        }

        protected string name;
        protected string description;
        protected Dictionary<Permission, bool> permissions;

        public string Name {
            get => name;
        }
        public string Description {
            get => description;
        }
        public Dictionary<Permission, bool> Permissions {
            get => permissions;
        }

        public UserRole(int id, string name, string description = "", Dictionary<Permission, bool> permissions = null, DateTime dateCreated = default, DateTime dateLastUpdated = default, string createdBy = "", string lastUpdatedBy = "") {
            this.id = id;
            this.name = name;
            this.description = description;
            this.permissions = new Dictionary<Permission, bool>(permissions);
            this.dateCreated = dateCreated;
            this.dateLastUpdated = dateLastUpdated;
            this.createdBy = createdBy;
            this.lastUpdatedBy = lastUpdatedBy;
        }

        public void Update(int id, string name, string description = "", Dictionary<Permission, bool> permissions = null, DateTime dateCreated = default, DateTime dateLastUpdated = default, string createdBy = "", string lastUpdatedBy = "") {
            this.id = id;
            this.name = name;
            this.description = description;
            this.permissions = new Dictionary<Permission, bool>(permissions);
            this.dateCreated = dateCreated;
            this.dateLastUpdated = dateLastUpdated;
            this.createdBy = createdBy;
            this.lastUpdatedBy = lastUpdatedBy;
        }

        public virtual void CreateDefaultPermissions() {
            permissions = new Dictionary<Permission, bool>() {
                { Permission.AllowAdminControls, false },
                { Permission.AllowCreateProducts, false },
                { Permission.AllowCreateRoles, false },
                { Permission.AllowCreateUsers, false },
                { Permission.AllowEditProducts, false },
                { Permission.AllowEditRoles, false },
                { Permission.AllowEditUsers, false },
                { Permission.AllowDeleteProducts, false },
                { Permission.AllowDeleteRoles, false },
                { Permission.AllowDeleteUsers, false },
                { Permission.AllowReporting, false },
                { Permission.AllowProcessSales, true },
            };
        }

        public override string ToString() {
            return $"{name}";
        }
    }
}
