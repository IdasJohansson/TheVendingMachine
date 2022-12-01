using System;
using TheVendingMachine.Interfaces;
using TheVendingMachine.MoneyHandler;
using TheVendingMachine.Services;

namespace TheVendingMachine.Items
{
	public class LemonSorbet : IProduct
	{
        public void AddProductInfo()
        {
            // Creating a Sorbet objekt
            Product product = Product.CreateProduct("Sorbet");

            // Getting a Sorbet objekt of the type LemonSorbet
            IProduct iproduct = product.GetProduct("LemonSorbet");

            // Giving the LemonSorbet objekt values
            product.ProductId = 3;
            product.ProductName = "LemonSorbet";
            product.ProductInfo = "250ml";
            product.ProductCost = 25;

            // Add Objekt to List of products 
            Product.products.Add(product);
        }

        public void Description()
        {
            Console.WriteLine();
            DateTime date = DateTime.Now;
            DateTime bestBefore = date.AddMonths(1);
            Console.WriteLine($"This sorbet is made of sugar and fruitjuice extracted from Lemons harvested in the southern of Sweden. Best-before date: {bestBefore.ToString("dd-MM-yyyy")} "); 
        }

        public void Buy()
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
            Console.WriteLine("Num num num...Cold and refreshing!");
            Helper.ReturnMenuMessage();
        }
    }
}

