using System;
using System.Text.RegularExpressions;
using TheVendingMachine.Interfaces;
using TheVendingMachine.MoneyHandler;
using TheVendingMachine.Services;

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
            Console.Write("Product description: ");
            Console.WriteLine("This is a soda made of Apples");
            Console.WriteLine();
        }

        public void Buy()
        {
            // Visar hur mycket pengar det finns i plånboken samt i maskinen
            Wallet.ViewBalance();

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
            Console.WriteLine("Drink this soda!");

        }
    }
}

