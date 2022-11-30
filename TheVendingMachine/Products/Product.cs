using System;
using TheVendingMachine.Interfaces;

namespace TheVendingMachine.Items
{
	public abstract class Product
	{
        protected string productName;
        protected string productInfo;
        protected int productCost;
        protected int productId;

        public abstract int ProductId
        {
            get;
            set;
        }

        public abstract string ProductName
        {
            get;
            set;
        }

        public abstract string ProductInfo
        {
            get;
            set;
        }

        public abstract int ProductCost
        {
            get;
            set;
        }

        // List off all products 
        public static List<Product> products = new List<Product>();

        public abstract IProduct GetProduct(string Product);
     

        public static Product CreateProduct(string ProductCategory)
        {
            if (ProductCategory.Equals("Soda"))
                return new Soda();
            else if (ProductCategory.Equals("Sorbet"))
                return new Sorbet();
            else if (ProductCategory.Equals("Berry"))
                return new Berry(); 
                return null; 
        }

        public static void ViewProductList()
        {
            foreach (var item in products)
            {
                // OM man vill skriva ut varukategori
                var category = item.GetType().Name;
                Console.Write($"{category} {item.ProductId} {item.ProductName} - ");
                Console.Write($"{item.ProductCost} kr - ");
                Console.Write($"{item.ProductInfo} ");
                Console.WriteLine();
            }
        }

    }
}

