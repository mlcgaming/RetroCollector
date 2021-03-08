using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetroCollector.Data.Management;

namespace RetroCollector.Models {
    public class UserAccount : IndexItem {
        private string firstName;
        private string lastName;
        private string username;
        private string passHash;
        private byte[] passSalt;
        private UserRole role;

        public string FirstName {
            get => firstName;
        }
        public string LastName {
            get => lastName;
        }
        public string FullName {
            get => $"{firstName} {lastName}";
        }
        public string Username {
            get => username;
        }
        public string PassHash {
            get => passHash;
        }
        public byte[] Salt {
            get => passSalt;
        }

        public UserAccount(int id, string firstName, string lastName, string username, string passHash, string passSalt, int roleId, DateTime dateCreated, DateTime dateLastUpdated, string createdBy, string lastUpdatedBy) {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = username;
            this.passHash = passHash;
            this.passSalt = Convert.FromBase64String(passSalt);
            
            foreach(var r in DatabaseManager.Roles) {
                if(r.ID == roleId) {
                    role = r;
                    break;
                }
            }

            this.dateCreated = dateCreated;
            this.dateLastUpdated = dateLastUpdated;
            this.createdBy = createdBy;
            this.lastUpdatedBy = lastUpdatedBy;
        }

        public void Update(int id, string firstName, string lastName, string username, string passHash, string passSalt, int roleId, DateTime dateCreated, DateTime dateLastUpdated, string createdBy, string lastUpdatedBy) {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = username;
            this.passHash = passHash;
            this.passSalt = Convert.FromBase64String(passSalt);

            foreach(var r in DatabaseManager.Roles) {
                if(r.ID == roleId) {
                    role = r;
                    break;
                }
            }

            this.dateCreated = dateCreated;
            this.dateLastUpdated = dateLastUpdated;
            this.createdBy = createdBy;
            this.lastUpdatedBy = lastUpdatedBy;
        }

        public bool IsAllowed(UserRole.Permission permission) {
            return role.Permissions[permission];
        }
    }
}
