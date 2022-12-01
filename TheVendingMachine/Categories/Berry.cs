﻿using System;
using TheVendingMachine.Interfaces;

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
            else
                return null;
        }


    }
}
