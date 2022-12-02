﻿using System;
using TheVendingMachine.Interfaces;

namespace TheVendingMachine.Items
{
	public class CherrySoda : Product, IProduct
    {
		// Try to use the constructor here

		//Product product = Product.CreateProduct("Soda");

        public override int ProductId { get; set; }
        public override string ProductName { get; set; }
        public override string ProductInfo { get; set; }
        public override int ProductCost { get; set; }

        //Soda soda = new Soda(10,"Cherry", "3liter", 20);

        public CherrySoda()
		{ }

        public CherrySoda(int productId, string productName, string productInfo, int productCost)
        {
			ProductId = 20;
			ProductName = "CherrySoda";
			ProductInfo = "330ml";
			ProductCost = 15; 
        }



        public Soda CreateSoda()
		{
			return new Soda(10, "ApelsinSoda", "3liter", 20); 
		}



        public void Description()
		{ }

		public void Buy(int productCost)
		{ }

		public void Use()
		{ }

        public override IProduct GetProduct(string Product)
        {
            throw new NotImplementedException();
        }
    }
}

