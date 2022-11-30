using System;
using TheVendingMachine.Interfaces;

namespace TheVendingMachine.Items
{
	public class LemonSorbet : IProduct
	{
        public void AddProductInfo()
        {
            // Creating a Sorbet objekt
            Product product = null;
            product = Product.CreateProduct("Sorbet");

            // Getting a Sorbet objekt of the type LemonSorbet
            IProduct iproduct = null;
            iproduct = product.GetProduct("LemonSorbet");

            // Giving the LemonSorbet objekt values
            product.ProductId = 3;
            product.ProductName = "LemonSorbet";
            product.ProductInfo = "250ml";
            product.ProductCost = 25;

            // Objekt to List of products 
            Product.products.Add(product);
        }

        public void Description()
        {
            Console.WriteLine("This is cold sorbet");
        }

        public void Buy()
        {

        }

        public void Use()
        {

        }
    }
}

