using System;
using System.Text.RegularExpressions;
using TheVendingMachine.Interfaces;
using TheVendingMachine.Items;
using TheVendingMachine.MoneyHandler;

namespace TheVendingMachine.Services
{
	public class Menus
	{
		public static void StartMenu()
		{
            Console.WriteLine("WELCOME TO THIS SUPERAMAZING VENDING MACHINE");
            Console.WriteLine();

            Console.WriteLine("Please select one of below options: ");
            Console.WriteLine("[1] Display items");
            Console.WriteLine("[2] Insert money");
            Console.WriteLine("[3] Purchase");
            Console.WriteLine("[0] Turn machine off");
            Console.WriteLine();

            Wallet.ViewBalance(); 

            int input = Convert.ToInt32(Console.ReadLine());

            bool loop = true; 
            switch (input)
            {
                case 1:
                    Console.Clear();
                    Product.ViewProductList();
                    ViewProductsMenu();
                    break;
                case 2:
                    Wallet.InsertMoney();
                    ViewProductsMenu(); 
                    break;
                case 3:
                    Console.Clear();
                    // Visar lista av alla produkter: 
                    Product.ViewProductList();
                    Console.WriteLine("Enter product number: ");
                    int buyThis = Convert.ToInt32(Console.ReadLine());

                    // Går in i listan med produkter och hämtar objektet med id't som användaren har angett?
                    var productToBuy = Product.products.Find(x => x.ProductId == buyThis);

                    // Hämtar kategorinamnet
                    var category = productToBuy.GetType().Name;

                    // Instansierar ett objekt av produktkategorin
                    Product product = Product.CreateProduct(category);

                    // skapar ett objekt med namnet på den hämtade produkten.....ish 
                    IProduct iproduct = product.GetProduct(productToBuy.ProductName);

                    // Vid köp av produkt så skall en kontroll ske; att användaren har
                    // matat in tillräckligt med pengar till automaten.Om inte så
                    // stoppas köpet.
                    var cost = productToBuy.ProductCost;
                    var checkbalance = Wallet.CheckBalance(cost);
                    if (checkbalance)
                    {
                        // Vid val av produkt ska användaren kunnas e produktens beskrivning innan man väljer att köpa varan:
                        iproduct.Description();

                        // Användaren ska kunna acceptera köpet eller välja att gå tillbaka till menyn
                        iproduct.Buy();
                    }
                    else
                    {
                        Console.WriteLine("You need to insert more money");
                    }
                    break;
                case 0:
                    EndMessage(); 
                    break;
                default:
                    break; 
            }
        }


        public static void ViewProductsMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] Insert money");
            Console.WriteLine("[2] Purchase");
            Console.WriteLine("[3] Return to start");
            Console.WriteLine("[0] Turn machine off");

            int input = Convert.ToInt32(Console.ReadLine());
   
            switch (input)
            {
                case 1:
                    Wallet.InsertMoney();
                    ViewProductsMenu();
                    break; 
                case 2:
                    Console.Clear();
                    Product.ViewProductList();
                    Console.WriteLine("Enter product number: ");
                    int buyThis = Convert.ToInt32(Console.ReadLine());

                    // Går in i listan med producter och hämtar det objekt med samma id som användaren har skrivit in
                    var productToBuy = Product.products.Find(x => x.ProductId == buyThis);

                    // Hämtar kategori namnet på den valda produkten
                    var category = productToBuy.GetType().Name;

                    // Instansierar ett objekt av produktkategorin
                    Product product = Product.CreateProduct(category);

                    // 
                    IProduct iproduct = product.GetProduct(productToBuy.ProductName);

                    // Vid köp av produkt så skall en kontroll ske; att användaren har
                    // matat in tillräckligt med pengar till automaten.Om inte så
                    // stoppas köpet.

                

                    // Vid val av produkt ska användaren kunnas se produktens beskrivning innan man väljer att köpa varan:
                    iproduct.Description();

                    // Användaren ska kunna acceptera köpet eller välja att gå tillbaka till menyn
                    iproduct.Buy();
                    break;
                case 3:
                    Console.Clear(); 
                    Menus.StartMenu(); 
                    break;
                case 0:
                    EndMessage(); 
                    break; 
                default: 
                    break; 
            }
        }

        public static void EndMessage()
        {
            Console.Clear(); 
            Console.WriteLine("Thank you for using this SUPER AMAZING VENDING MACHINE");
            Console.WriteLine("Press a key to turn me off");
            Console.ReadKey();

            // ----> Kvar att göra :) 
            // När användaren väljer att avsluta programmet skall kvarstående
            // pengar i automaten returneras till avsändaren. Skriv ut hur
            // mycket pengar som returneras samt i vilken valör.
        }
    }
}

