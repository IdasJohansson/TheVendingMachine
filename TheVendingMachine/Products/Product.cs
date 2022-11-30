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

    }
}

