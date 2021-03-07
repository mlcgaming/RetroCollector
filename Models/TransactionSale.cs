using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetroCollector.Data.Management;

namespace RetroCollector.Models {
    public class TransactionSale : IndexItem {
        private string description;
        private DateTime dateOfSale;
        private int salesRepId;
        private int customerId;
        private List<TransactionLineItem> items;

        public string Description {
            get => description;
        }
        public DateTime DateOfSale {
            get => dateOfSale;
        }
        public int SalesRepID {
            get => salesRepId;
        }
        public int CustomerID {
            get => customerId;
        }
        public List<TransactionLineItem> Items {
            get => items;
        }
        public decimal SubTotal {
            get => GetSubtotal();
        }
        public decimal Total {
            get => GetTotal();
        }

        public TransactionSale(int id, string description, DateTime dateOfSale, int salesRepId, int customerId, DateTime dateCreated, DateTime dateLastUpdated, string createdBy, string lastUpdatedBy) {
            this.id = id;
            this.description = description;
            this.dateOfSale = dateOfSale;
            this.salesRepId = salesRepId;
            this.customerId = customerId;
            this.dateCreated = dateCreated;
            this.dateLastUpdated = dateLastUpdated;
            this.createdBy = createdBy;
            this.lastUpdatedBy = lastUpdatedBy;

            items = new List<TransactionLineItem>();
        }

        public void AddLineItem(TransactionLineItem item) {
            Items.Add(item);
        }
        public void RemoveLineItem(TransactionLineItem item) {
            Items.Remove(item);
        }

        public decimal GetSubtotal() {
            if(Items.Count == 0) {
                return 0M;
            }
            else {
                decimal total = 0M;
                foreach(var item in Items) {
                    total += item.TotalPrice;
                }

                return total;
            }
        }
        public decimal GetTotal(float taxRate = 0.0815f) {
            if(Items.Count == 0) {
                return 0M;
            }
            else {
                decimal total = 0M;
                foreach(var item in Items) {
                    total += item.TotalPrice;
                }

                return (decimal)((float)total * taxRate);
            }
        }

        public override string ToString() {
            return $"[{DateOfSale.Date}] Customer:{DatabaseManager.GetCustomerById(customerId)?.FullName ?? "GUEST"} Total Items:{Items.Count}  Total Sale:{GetTotal()}";
        }
    }
}
