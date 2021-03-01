using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroCollector.Models {
    public abstract class Product : IndexItem, IProduct {
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

        protected string description;
        protected decimal cost;
        protected decimal price;

        public string Description {
            get { return description; }
            set { description = value; }
        }
        public decimal Cost {
            get { return cost; }
        }
        public decimal Price {
            get { return price; }
        }

        public void UpdateCost(decimal cost) {
            this.cost = cost;
        }
        public void UpdatePrice(decimal price) {
            this.price = price;
        }
        public decimal Purchase(decimal amountPaid) {
            try {
                decimal change = (amountPaid - price);

                if(change < 0M) {
                    throw new InvalidPurchaseReturnAmountException();
                }
                else {
                    return change;
                }
            }
            catch (InvalidPurchaseReturnAmountException) {
                return default;
            }
        }
        public decimal GetTotalWithTax() {
            return (decimal)((float)price * 1.0815f);
        }
        public decimal GetTotalWithTax(float taxRate) {
            return (decimal)((float)price * taxRate);
        }
    }
}
