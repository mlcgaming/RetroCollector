using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetroCollector.Data.Management;

namespace RetroCollector.Models {
    public class Product : IndexItem, IProduct {
        public enum ProductCompleteness {
            Loose,
            Complete,
            New,
            BoxOnly,
            ManualOnly
        }
        public enum ProductQuality {
            Acceptable,
            Worn,
            Good,
            New
        }
        public enum ProductRegion {
            NTSCJ,
            NTSCU,
            PAL,
            AUSTRALIA,
            OTHER
        }

        protected string name;
        protected string description;
        protected decimal cost;
        protected decimal price;
        protected int onHand;
        protected Company developer;
        protected ProductQuality quality;
        protected ProductCompleteness completion;
        protected ProductRegion region;
        protected int productTypeId;

        public string Name {
            get => name;
        }
        public string Description {
            get => description;
            set => description = value;
        }
        public decimal Cost {
            get => cost;
        }
        public decimal Price {
            get => price;
        }
        public int OnHand {
            get => onHand;
        }
        public Company Developer {
            get => developer;
        }
        public ProductQuality Quality {
            get { return quality; }
        }
        public ProductCompleteness Completion {
            get { return completion; }
        }
        public ProductRegion Region {
            get { return region; }
        }
        public int ProductTypeID {
            get => productTypeId;
        }

        public Product(int id, string name, string description, decimal cost, decimal price, int onHand, Company developer, ProductQuality quality, ProductCompleteness completion, ProductRegion region, int productTypeId, DateTime dateCreated, DateTime dateLastUpdated, string createdBy, string lastUpdatedBy) {
            this.id = id;
            this.name = name;
            this.description = description;
            this.cost = cost;
            this.price = price;
            this.onHand = onHand;
            this.developer = developer;
            this.quality = quality;
            this.completion = completion;
            this.region = region;
            this.productTypeId = productTypeId;
            this.dateCreated = dateCreated;
            this.dateLastUpdated = dateLastUpdated;
            this.createdBy = createdBy;
            this.lastUpdatedBy = lastUpdatedBy;
        }

        public virtual void Update(int id, string name, string description, decimal cost, decimal price, int onHand, Company developer, ProductQuality quality, ProductCompleteness completion, ProductRegion region, int productTypeId, DateTime dateCreated, DateTime dateLastUpdated, string createdBy, string lastUpdatedBy) {
            this.id = id;
            this.name = name;
            this.description = description;
            this.cost = cost;
            this.price = price;
            this.onHand = onHand;
            this.developer = developer;
            this.quality = quality;
            this.completion = completion;
            this.region = region;
            this.productTypeId = productTypeId;
            this.dateCreated = dateCreated;
            this.dateLastUpdated = dateLastUpdated;
            this.createdBy = createdBy;
            this.lastUpdatedBy = lastUpdatedBy;
        }

        public int GetProductTypeID() {
            return productTypeId;
        }
        public void UpdateCost(decimal cost) {
            this.cost = cost;
        }
        public void UpdatePrice(decimal price) {
            this.price = price;
        }
        public void Purchase(int quantity) {
            onHand = onHand - quantity;
        }
        public decimal GetTotalWithTax() {
            return (decimal)((float)price * 1.0815f);
        }
        public decimal GetTotalWithTax(float taxRate) {
            return (decimal)((float)price * taxRate);
        }
        public override string ToString() {
            return ($"[{onHand} Available] {Name} ${Price}");
        }
    }
}
