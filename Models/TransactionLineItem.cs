using RetroCollector.Data.Management;

namespace RetroCollector.Models {
    public class TransactionLineItem {
        private int transactionId;
        private int productId;
        private int quantity;
        private decimal pricePerProduct;
        
        public int TransactionID {
            get => transactionId;
        }
        public int ProductID {
            get => productId;
        }
        public int Quantity {
            get => quantity;
        }
        public decimal PricePerProduct {
            get => pricePerProduct;
        } 
        public decimal TotalPrice {
            get => (pricePerProduct * quantity);
        }

        public TransactionLineItem(int transactionId, int productId, int quantity, decimal pricePerProduct) {
            this.transactionId = transactionId;
            this.productId = productId;
            this.quantity = quantity;
            this.pricePerProduct = pricePerProduct;
        }

        public override string ToString() {
            return $"{ProductManager.GetProductById(productId).Name} (x{quantity})  ${quantity * pricePerProduct}";
        }
    }
}
