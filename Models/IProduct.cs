using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroCollector.Models {
    public interface IProduct {
        void UpdateCost(decimal cost);
        void UpdatePrice(decimal price);
        decimal Purchase(decimal amountPaid);
        decimal GetTotalWithTax();
        decimal GetTotalWithTax(float taxRate);
    }
}
