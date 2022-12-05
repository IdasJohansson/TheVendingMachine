using System;
using TheVendingMachine.Interfaces;
using TheVendingMachine.Services;

namespace TheVendingMachine.Items
{
    public class Soda : Product
    {
        public override int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        public override string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public override string ProductInfo
        {
            get { return productInfo; }
            set { productInfo = value; }
        }

        public override int ProductCost
        {
            get { return productCost; }
            set { productCost = value; }
        }

        public Soda()
        {

        }

        public Soda(int productId, string productName, string productInfo, int productCost )
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.ProductInfo = productInfo;
            this.ProductCost = productCost;
            products.Add(this); 
        }

        // Använder ej denna metod atm 
        public override IProduct GetProduct(string ProductItemType)
        {
            // Addera toUpper för att förbättra
            if (ProductItemType.Equals("AppleSoda"))
                return new AppleSoda();
            if (ProductItemType.Equals("BlackcurrantSoda"))
                return new BlackcurrantSoda();
            if (ProductItemType.Equals("CherrySoda"))
                return new CherrySoda();
            else
                Helper.ErrorColor("Something went wrong.");
                Helper.ReturnMenuMessage();
            return null;
        }

    }
}

