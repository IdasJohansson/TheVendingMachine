using System;
using TheVendingMachine.Interfaces;

namespace TheVendingMachine.Items
{
	public class Raspberry : IProduct
	{
        public void AddProductInfo()
        {
            // Creating a Berry objekt
            Product product = null;
            product = Product.CreateProduct("Berry");

            // Getting a Berry objekt of the type Raspberry
            IProduct iproduct = null;
            iproduct = product.GetProduct("Raspberry");

            // Giving the LemonSorbet objekt values
            product.ProductId = 5;
            product.ProductName = "Raspberry";
            product.ProductInfo = "200g";
            product.ProductCost = 40;

            // Objekt to List of products 
            Product.products.Add(product);
        }

        public void Description ()
        {
            Console.WriteLine("This is a handpicked berry"); 
        }
        public void Buy()
        { }
        public void Use()
        { }

    }
}

