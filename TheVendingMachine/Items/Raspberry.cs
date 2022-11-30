using System;
using TheVendingMachine.Interfaces;
using TheVendingMachine.MoneyHandler;
using TheVendingMachine.Services;

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
        {
            // Vid köp av produkt så skall en kontroll ske; att användaren har
            // matat in tillräckligt med pengar till automaten.Om inte så
            // stoppas köpet.

            Wallet.ViewBalance();

            if (true)
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
            else
            {
                Console.WriteLine("Insert more money in machine");
            }
        }

        public void Use()
        {
            Console.WriteLine("Yum yum yum, tastes like summer");
         
        }

    }
}

