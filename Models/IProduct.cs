namespace RetroCollector.Models {
    public interface IProduct {
        int GetProductTypeID();
        void UpdateCost(decimal cost);
        void UpdatePrice(decimal price);
        void Purchase(int quantity);
        decimal GetTotalWithTax();
        decimal GetTotalWithTax(float taxRate);
        string ToString();
    }
}
