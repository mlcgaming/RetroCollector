namespace RetroCollector.Models {
    public interface IProduct {
        void UpdateCost(decimal cost);
        void UpdatePrice(decimal price);
        decimal Purchase(decimal amountPaid);
        decimal GetTotalWithTax();
        decimal GetTotalWithTax(float taxRate);
        string ToString();
    }
}
