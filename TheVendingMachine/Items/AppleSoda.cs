using System;
using TheVendingMachine.Interfaces;

namespace TheVendingMachine.Items
{
	public class AppleSoda : IProduct
    {
        public void AddProductInfo()
        {
            // Creating a Soda objekt
            Product product = null;
            product = Product.CreateProduct("Soda");

            // Getting a Soda objekt of the type AppleSoda
            IProduct iproduct = null;
            iproduct = product.GetProduct("AppleSoda");

            // Giving the AppleSoda objekt values
            product.ProductId = 1;
            product.ProductName = "AppleSoda";
            product.ProductInfo = "330ml";
            product.ProductCost = 15;

            // Objekt to List of products 
            Product.products.Add(product);

        }

        public void Description()
        {
            Console.WriteLine("This is a soda made of Apples");
        }
        public void Buy()
        {
            Console.WriteLine("Lets buy this product");
        }
        public void Use()
        {
            Console.WriteLine("Drink this soda!");
        }
    }
}

