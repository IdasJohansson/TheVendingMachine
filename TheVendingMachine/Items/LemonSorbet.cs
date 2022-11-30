using System;
using TheVendingMachine.Interfaces;
using TheVendingMachine.Services;

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
            Console.WriteLine("Lets buy this product");
            // Användaren ska kunna acceptera köpet eller välja att gå tillbaka till menyn
            Console.WriteLine("Are you sure you want to buy this product? ");
            Console.WriteLine("Press 1 to confirm and 0 to return to menu.");
            int confirm = Convert.ToInt32(Console.ReadLine());
            if (confirm == 1)
            {
                // Vid köpa av produkt ska produkten köpas och användas
                Use();
                Console.WriteLine("Press a key to return to menu");
                Console.ReadKey();

                // Användaren tas tillbaka till menyn vid avslutat köp:
                Menus.StartMenu();
            }
            else
            {
                // Användaren ska kunna acceptera köpet eller välja att gå tillbaka till menyn
                Menus.StartMenu();
            }

        }

        public void Use()
        {
            Console.WriteLine("*Eating this good sorbet*");
     
        }
    }
}

