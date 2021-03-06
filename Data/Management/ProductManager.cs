using System.Linq;
using System.Collections.Generic;
using RetroCollector.Models;

namespace RetroCollector.Data.Management {
    public static class ProductManager {
        private static List<IProduct> products = new List<IProduct>();
        private static List<ProductType> productTypes = new List<ProductType>();

        public static List<IProduct> Products {
            get => products;
        }
        public static List<ProductType> ProductTypes {
            get => productTypes;
        }

        public static List<VideoGame> GetVideoGames() {
            IEnumerable<VideoGame> filteredProducts =
                from p in products
                where p.GetType() == typeof(VideoGame)
                select p as VideoGame;

            return filteredProducts.ToList();
        }
        public static List<VideoGameConsole> GetConsoles() {
            IEnumerable<VideoGameConsole> filteredProducts =
                from p in products
                where p.GetType() == typeof(VideoGameConsole)
                select p as VideoGameConsole;

            return filteredProducts.ToList();
        }
        public static List<GameMerchandise> GetMerchandise() {
            IEnumerable<GameMerchandise> filteredProducts =
                from p in products
                where p.GetType() == typeof(GameMerchandise)
                select p as GameMerchandise;

            return filteredProducts.ToList();
        }
        public static List<Peripheral> GetPeripherals() {
            IEnumerable<Peripheral> filteredProducts =
                from p in products
                where p.GetType() == typeof(Peripheral)
                select p as Peripheral;

            return filteredProducts.ToList();
        }
        public static List<ServiceProduct> GetServices() {
            IEnumerable<ServiceProduct> filteredProducts =
                from p in products
                where p.GetType() == typeof(ServiceProduct)
                select p as ServiceProduct;

            return filteredProducts.ToList();
        }

        public static List<VideoGame> GetGamesByConsole(ConsoleCategory console) {
            IEnumerable<VideoGame> videoGames =
                from vg in products
                where vg.GetType() == typeof(VideoGame)
                select vg as VideoGame;

            IEnumerable<VideoGame> filteredGames =
                from vg in videoGames
                where vg.Console == console
                select vg;

            return filteredGames.ToList();
        }
        public static VideoGameConsole GetConsoleContainingName(string name) {
            IEnumerable<VideoGameConsole> consoles =
                from c in products
                where c.GetType() == typeof(VideoGameConsole)
                select c as VideoGameConsole;

            foreach(var c in consoles) {
                if(c.Name.Contains(name)) {
                    return c;
                }
            }

            return null;
        }
        public static List<Product> GetProductsByCompany(Company company) {
            IEnumerable<Product> allProducts =
                from p in products
                select p as Product;

            IEnumerable<Product> filteredProducts =
                from p in allProducts
                where p.Developer == company
                select p;

            return filteredProducts.ToList();
        }
        public static List<IProduct> GetProductsUnderMaxPrice(decimal maxPrice) {
            IEnumerable<Product> allProducts =
                from p in products
                select p as Product;

            IEnumerable<IProduct> filteredProducts =
                from p in allProducts
                where p.Price <= maxPrice
                select p;

            return filteredProducts.ToList();
        }

        public static List<IProduct> GetProductListByType(ProductType type) {

            IEnumerable<IProduct> prods =
                from p in products
                where p.GetProductTypeID() == type.ID
                select p;

            return prods.ToList();
        }

        public static decimal GetTotalValueByProductType(ProductType type) {

            IEnumerable<IProduct> prods =
                from p in products
                where p.GetProductTypeID() == type.ID
                select p;

            decimal totalValue = 0M;

            foreach(Product p in prods) {
                totalValue += (p.Price - p.Cost);
            }

            return totalValue;
        }

        public static int GetProductTypeIDByName(string name) {
            foreach(var type in ProductTypes) {
                if(type.Name == name) {
                    return type.ID;
                }
            }

            return 9999; // 9999 is a failsafe, it refers to the Default option in Product loading of GetAllProducts
        }
        public static ProductType GetProductTypeByID(int id) {
            foreach(var type in ProductTypes) {
                if(type.ID == id) {
                    return type;
                }
            }

            return null;
        }
    }
}
