using System;
using TheVendingMachine.Interfaces;
using TheVendingMachine.Services;

namespace TheVendingMachine.Items
{
	public class Berry : Product
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

      
        public override IProduct GetProduct(string ProductItemType)
        {
            if (ProductItemType.Equals("Raspberry"))
                return new Raspberry();
            if (ProductItemType.Equals("Strawberry"))
                return new Strawberry();
            if (ProductItemType.Equals("Wildberry"))
                return new Wildberry();
            else
                Helper.ErrorColor("Something went wrong with Berries.");
                Helper.ReturnMenuMessage(); 
                return null;
        }


    }
}

