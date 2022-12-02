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
            else
                return null; 
        }

        public static void ViewCategories()
        {
            Console.WriteLine("Select category:");

            Console.WriteLine("[1] SODA");
            Console.WriteLine("[2] SORBET");
            Console.WriteLine("[3] BERRY");
            int input = Convert.ToInt32(Console.ReadLine());
            string category; 

            switch (input)
            {
                case 1:
                    category = "Soda"; 
                    ViewProductList(category); 
                    break;
                case 2:
                    category = "Sorbet";
                    ViewProductList(category);
                    break;
                case 3:
                    category = "Berry";
                    ViewProductList(category);
                    break; 
                default:
                    break;
            }
        }


        public static void ViewProductList(string category)
        {
            Console.Clear(); 
            foreach (var item in products)
            {
                var productCategory = item.GetType().Name;

                if (category == productCategory)
                {
                    Console.Write($"{item.ProductId} {item.ProductName} - ");
                    Console.Write($"{item.ProductCost} kr - ");
                    Console.WriteLine($"{item.ProductInfo} ");
                }
            }
        }
    }
}

