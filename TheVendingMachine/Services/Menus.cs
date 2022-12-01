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

            // Visar upp pengarna
            Wallet.ViewBalance(); 

            int input = Convert.ToInt32(Console.ReadLine());

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
                    Wallet.MakePurchase(); 
                    //Console.WriteLine("Enter product number: ");
                    //int buyThis = Convert.ToInt32(Console.ReadLine());

                    //// Går in i listan med produkter och hämtar objektet med id't som användaren har angett?
                    //var productToBuy = Product.products.Find(x => x.ProductId == buyThis);

                    //// Hämtar kategorinamnet
                    //var category = productToBuy.GetType().Name;

                    //// Instansierar ett objekt av produktkategorin
                    //Product product = Product.CreateProduct(category);

                    //// skapar ett objekt med namnet på den hämtade produkten.....ish 
                    //IProduct iproduct = product.GetProduct(productToBuy.ProductName);

                    //// Vid köp av produkt så skall en kontroll ske; att användaren har
                    //// matat in tillräckligt med pengar till automaten.Om inte så
                    //// stoppas köpet.
                    //var cost = productToBuy.ProductCost;
                    //var checkbalance = Wallet.CheckBalance(cost);
                    //if (checkbalance)
                    //{
                    //    // Vid val av produkt ska användaren kunnas e produktens beskrivning innan man väljer att köpa varan:
                    //    iproduct.Description();

                    //    // Användaren ska kunna acceptera köpet eller välja att gå tillbaka till menyn
                    //    iproduct.Buy();
                    //}
                    //else
                    //{
                    //    Console.WriteLine("You need to insert more money");
                    //    Console.WriteLine();
                    //    Wallet.InsertMoney();
                    //}
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
                    Wallet.MakePurchase();
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

            // Hämtar listan med maskinens pengar summerat
            var returnMoney = Wallet.moneyInMachine.Sum();

            // Om listan(maskinen) inte innehåller några pengar
            if (returnMoney == 0)
            {
                Console.WriteLine("Machine contains no money.");
            }
            else
            {
                // När användaren väljer att avsluta programmet skall kvarstående
                // pengar i automaten returneras till avsändaren. Skriv ut hur
                // mycket pengar som returneras samt i vilken valör.

                // När köp är avslutade så återlämnas återstående
                // inmatad summa i högsta valörer möjliga. 1, 5, 10, 20, 50, 100.

                Change.ReturnMoney(returnMoney); 

                // Detta returnerar alla mynt som är isatta i maskinen genom att skriva ut allt i listan var returnMoney = Wallet.moneyInMachine; 
                //Console.WriteLine("Below coins are returned to your wallet: ");
                //// Skriver ut resterande pengar i maskinen
                //foreach (var item in returnMoney)
                //{
                //    Console.WriteLine(item);
                //}
 
            }

            Console.WriteLine("Press a key to turn me off");
            Console.ReadKey();
        }
    }
}

