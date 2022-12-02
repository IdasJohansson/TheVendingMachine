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
            Product product = Product.CreateProduct("Berry");

            // Getting a Berry objekt of the type Raspberry
            IProduct iproduct = product.GetProduct("Raspberry");

            // Giving the LemonSorbet objekt values
            product.ProductId = 5;
            product.ProductName = "Raspberrries";
            product.ProductInfo = "200g";
            product.ProductCost = 40;

            // Objekt to List of products 
            Product.products.Add(product);
        }

        public void Description ()
        {
            DateTime date = DateTime.Now;
            DateTime bestBefore = date.AddDays(7);
            string info = $"Theese berries are handpicked in the southern of Sweden. Best-before date: {bestBefore.ToString("dd-MM-yyyy")} ";
            Console.WriteLine();
            Console.WriteLine(info);
        }

        public void Buy(int cost)
        {
            try
            {
                // Användaren ska kunna acceptera köpet eller välja att gå tillbaka till menyn
                Console.WriteLine();
                Console.WriteLine("Are you sure you want to buy this product? ");
                Console.WriteLine("Press 1 to confirm and 0 to return to menu.");
                Console.WriteLine();

                int confirm = Convert.ToInt32(Console.ReadLine());
                if (confirm == 1)
                {
                    // Vid köpa av produkt ska produkten köpas och användas
                    // Användaren tas tillbaka till menyn vid avslutat köp:
                    Use();
                }
                else
                {
                    // Användaren ska kunna acceptera köpet eller välja att gå tillbaka till menyn
                    Menus.StartMenu();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Helper.ReturnMenuMessage();
            }
        }

        public void Use()
        {
            Console.Clear();
            Console.WriteLine("Purchase confirmed");
            Console.WriteLine("Yum yum yum, tastes like summer");
            Helper.ReturnMenuMessage();
        }

    }
}

