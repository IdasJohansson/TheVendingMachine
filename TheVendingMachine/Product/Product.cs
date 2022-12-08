using System;
using TheVendingMachine.Interfaces;
using TheVendingMachine.Services;

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

        // Lista med alla produkter
        public static List<Product> products = new List<Product>();

        // Metod som anropas i 
        public IProduct GetProduct(string ProductItemType)
        {
            if (ProductItemType.Equals("AppleSoda"))
                return new AppleSoda();
            else if (ProductItemType.Equals("BlackcurrantSoda"))
                return new BlackcurrantSoda();
            else if (ProductItemType.Equals("CherrySoda"))
                return new CherrySoda();
            else if (ProductItemType.Equals("Raspberry"))
                return new Raspberry();
            else if (ProductItemType.Equals("Strawberry"))
                return new Strawberry();
            else if (ProductItemType.Equals("Wildberry"))
                return new Wildberry();
            else if (ProductItemType.Equals("LemonSorbet"))
                return new LemonSorbet();
            else if (ProductItemType.Equals("ElderberrySorbet"))
                return new ElderberrySorbet();
            else if (ProductItemType.Equals("MangoSorbet"))
                return new MangoSorbet();
            else
                Helper.ErrorColor("Something went wrong when creating products.");
                Helper.ReturnMenuMessage();
            return null;
        }

        // Metod som returnerar en ny instans av en produktkategori, anropas bland annat i alla produkters konstuktorer
        public static Product CreateProduct(string ProductCategory)
        {
            if (ProductCategory.Equals("Soda"))
                return new Soda();
            else if (ProductCategory.Equals("Sorbet"))
                return new Sorbet();
            else if (ProductCategory.Equals("Berry"))
                return new Berry();
            else
                Helper.ErrorColor("Something went wrong when creating product category.");
                Helper.ReturnMenuMessage();
            return null; 
        }

    }
}

