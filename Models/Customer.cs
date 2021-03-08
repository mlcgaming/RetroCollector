using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroCollector.Models {
    public class Customer : IndexItem {
        private string firstName;
        private string lastName;
        private string address1;
        private string address2;
        private string city;
        private string stateAbbr;
        private string zipCode;
        private string phone;
        private string email;

        public string FirstName {
            get => firstName;
        }
        public string LastName {
            get => lastName;
        }
        public string FullName {
            get => $"{firstName} {lastName}";
        }
        public string Address1 {
            get => address1;
        }
        public string Address2 {
            get => address2;
        }
        public string City {
            get => city;
        }
        public string StateAbbr {
            get => stateAbbr;
        }
        public string ZipCode {
            get => zipCode;
        }
        public string Phone {
            get => phone;
        }
        public string Email {
            get => email;
        }

        public Customer(int id, string firstName, string lastName, string email, string address1 = "", string address2 = "", string city = "", string stateAbbr = "", 
            string zipCode = "", string phone = "", DateTime dateCreated = default, DateTime dateLastUpdated = default, string createdBy = "", string lastUpdatedBy = "") {
            
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.address1 = address1;
            this.address2 = address2;
            this.city = city;
            this.stateAbbr = stateAbbr;
            this.zipCode = zipCode;
            this.phone = phone;
            this.dateCreated = dateCreated;
            this.dateLastUpdated = dateLastUpdated;
            this.createdBy = createdBy;
            this.lastUpdatedBy = lastUpdatedBy;
        }

        public void Update(int id, string firstName, string lastName, string email, string address1, string address2, string city, string stateAbbr,
            string zipCode, string phone, DateTime dateCreated, DateTime dateLastUpdated, string createdBy, string lastUpdatedBy) {

            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.address1 = address1;
            this.address2 = address2;
            this.city = city;
            this.stateAbbr = stateAbbr;
            this.zipCode = zipCode;
            this.phone = phone;
            this.dateCreated = dateCreated;
            this.dateLastUpdated = dateLastUpdated;
            this.createdBy = createdBy;
            this.lastUpdatedBy = lastUpdatedBy;
        }

        public override string ToString() {
            return $"{FullName}";
        }
    }
}
