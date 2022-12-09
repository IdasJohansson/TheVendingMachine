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

        // Metod som returnerar en ny instans av en produktkategori, anropas när man ska skapa en produkt och tilldela den värden. 
        public static Product CreateProduct(string ProductCategory)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Helper.ReturnMenuMessage();
                return null;
            }
        }

        // Metod som returnerar en instans av respektove produkt
        public IProduct GetProduct(string ProductItemType)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Helper.ReturnMenuMessage();
                return null;
            }
        }

        // Adderar info till alla produkter som ska säljas i maskinen
        public static void AddProductInfoWrapper()
        {
            try
            {
                AppleSoda appleSoda = new AppleSoda();
                appleSoda.AddProductInfo();
                BlackcurrantSoda blackcurrantSoda = new BlackcurrantSoda();
                blackcurrantSoda.AddProductInfo();
                CherrySoda cherrySoda = new CherrySoda();
                cherrySoda.AddProductInfo();
                ElderberrySorbet elderberrySorbet = new ElderberrySorbet();
                elderberrySorbet.AddProductInfo();
                LemonSorbet lemonSorbet = new LemonSorbet();
                lemonSorbet.AddProductInfo();
                MangoSorbet mangoSorbet = new MangoSorbet();
                mangoSorbet.AddProductInfo();
                Raspberry raspberry = new Raspberry();
                raspberry.AddProductInfo();
                Strawberry strawberry = new Strawberry();
                strawberry.AddProductInfo();
                Wildberry wildberry = new Wildberry();
                wildberry.AddProductInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Helper.ReturnMenuMessage();
            }
        }

    }
}

