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
            Product product = Product.CreateProduct("Soda");

            // Getting a Soda objekt of the type AppleSoda
            IProduct iproduct = product.GetProduct("AppleSoda");

            // Giving the AppleSoda objekt values
            product.ProductId = 1;
            product.ProductName = "AppleSoda";
            product.ProductInfo = "330ml";
            product.ProductCost = 15;

            // Add produkt Objekt to List of products (in Product class)
            Product.products.Add(product);
        }

        public void Description()
        {
            DateTime date = DateTime.Now;
            DateTime bestBefore = date.AddYears(1);
            string info = $"Product information: This softdrink contains carbonated soda, sugar and fruitjuice extracted from Apples harvested in the southern of Sweden. Best-before date: {bestBefore.ToString("dd-MM-yyyy")} ";
            Console.WriteLine();
            Console.WriteLine(info);
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
            Console.WriteLine("Klunk klunk klunk...Oh so Fresh!");
            Helper.ReturnMenuMessage();
        }
    }
}

