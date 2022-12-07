using System;
using TheVendingMachine.Interfaces;
using TheVendingMachine.Services;

namespace TheVendingMachine.Items
{
	public class OrangeSoda : Soda, IProduct
	{


        public override int ProductId { get; set; }
        public override string ProductName { get; set; }
        public override string ProductInfo { get; set; }
        public override int ProductCost { get; set; }

        // Try to use the constructor here

        //Product product = Product.CreateProduct("Soda");
        //Soda soda = new Soda(10,"Cherry", "3liter", 20);


    

        public OrangeSoda()
        { }

        public OrangeSoda(int productId, string productName, string productInfo, int productCost)
        {
            this.ProductId = 20;
            this.ProductName = "OrangeSoda";
            this.ProductInfo = "330ml";
            this.ProductCost = 15;
            products.Add(this);
        }



        public Soda CreateSoda()
        {
            return new Soda(10, "Apelsin-soda", "300 liter", 20);
        }

        public void Description()
        { }

        public void Buy(int productCost)
        { }

        public void Use()
        { }

       
    }
}

