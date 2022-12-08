
using TheVendingMachine.Interfaces;
using TheVendingMachine.Items;
using TheVendingMachine.MoneyHandler;

namespace TheVendingMachine.Services
{
	public class Menus
	{
        // Denna meny visas upp direkt när programmet startas
		public static void StartMenu()
		{
            try
            {
                Helper.HeadLine();
                Console.WriteLine("WELCOME TO THIS SUPERAMAZING VENDING MACHINE");
                Console.WriteLine("In this machine you can buy Sodas, Sorbets or Berries :)(:");
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
                        // Visar lista av produktkategorier
                        ViewCategories(); 
                        ViewProductsMenu();
                        break;
                    case 2:
                        // Skickar vidare till funktionen för att sätta in pengar
                        Wallet.InsertMoney();
                        // Visar även upp en meny men vad man vill göra härnäst
                        ViewProductsMenu(); 
                        break;
                    case 3:
                        Console.Clear();
                            // Man måste ha lagt i minst 15 kr för att kunna komma till alternativet att genomföra ett köp
                            if (Wallet.moneyInMachine < 15)
                            {
                                Console.WriteLine("Please feed the machine to make a purchase");
                                Console.WriteLine("Press a key to continue");
                                Console.ReadKey(); 
                                Wallet.InsertMoney();
                            }
                            else
                            {
                                // Visar lista av produktkategorier
                                ViewCategories();
                                // Skickar vidare till Villkoren för att genomföra ett köp
                                Wallet.MakePurchase(); 
                            }
                        break;
                    case 0:
                        // Metod som anvluta programmet
                        EndMessage(); 
                        break;
                    default:
                        // Om man skriver fel siffra som input kommer man hit. 
                        Helper.ErrorColor("Invalid input!");
                        Helper.ReturnMenuMessage();
                        break; 
                }
            }
            // Om användaren skriver något annat än siffror skickas man hit
            catch (Exception e)
            {
                Helper.ErrorColor(e.Message);
                Helper.ReturnMenuMessage(); 
            }
        }


        // En vy som visar upp alla kategorier och skickar användaren vidare till en lista med produkter inom vald produktkategori
        public static void ViewCategories()
        {
            try
            {
                Console.WriteLine("Select category:");

                Console.WriteLine("[1] SODA");
                Console.WriteLine("[2] SORBET");
                Console.WriteLine("[3] BERRY");
                Console.WriteLine("(Press [0] to return)");
                int input = Convert.ToInt32(Console.ReadLine());
                string category;

                switch (input)
                {
                    case 1:
                        category = "Soda";
                        ViewProductList(category);
                        break;
                    case 2:
                        category = "Sorbet";
                        ViewProductList(category);
                        break;
                    case 3:
                        category = "Berry";
                        ViewProductList(category);
                        break;
                    case 0:
                        Console.Clear();
                        Menus.ViewProductsMenu();
                        break;
                    default:
                        Helper.ErrorColor("Wrong input, please try again!");
                        Helper.ReturnMenuMessage();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Helper.ReturnMenuMessage();
            }
        }

        // Visar upp en lista med produkter inom vald produktkategori
        public static void ViewProductList(string category)
        {
            Console.Clear();
            var products = Product.products; 
            foreach (var item in products)
            {
                var productCategory = item.GetType().Name;

                if (category == productCategory)
                {
                    Console.Write($"{item.ProductId} {item.ProductName} - ");
                    Console.Write($"{item.ProductCost} kr - ");
                    Console.WriteLine($"{item.ProductInfo} ");
                }
            }
        }


        public static void ViewProductsMenu()
        {
            try
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
                        // Man måste ha lagt i minst 15 kr för att kunna komma till alternativet att genomföra ett köp
                        if (Wallet.moneyInMachine < 15)
                            {
                                Console.WriteLine("Please feed the machine to make a purchase");
                                Console.WriteLine("Press a key to continue");
                                Console.ReadKey();
                                Wallet.InsertMoney();
                            }
                            else
                            {
                                // Skickar vidare till Villkoren för att genomföra ett köp
                                Wallet.MakePurchase();
                            }
                        break;
                    case 3:
                        Console.Clear(); 
                        StartMenu(); 
                        break;
                    case 0:
                        EndMessage(); 
                        break; 
                    default:
                        Helper.ErrorColor("Invalid input!");
                        Helper.ReturnMenuMessage(); 
                        break; 
                }
            }
            catch (Exception e)
            {
                Helper.ErrorColor(e.Message);
                Helper.ReturnMenuMessage();
            }
        }

        public static void EndMessage()
        {
            Console.Clear(); 
            Console.WriteLine("Thank you for using this SUPER AMAZING VENDING MACHINE");
            Console.WriteLine(@"
 ____ ____ ____ 
||B |||Y |||E ||
||__|||__|||__||
|/__\|/__\|/__\|
");

            // Hämtar maskinens pengar summerat
            var returnMoney = Wallet.moneyInMachine; 

            // Om lmaskinen inte innehåller några pengar
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
            }
            Console.WriteLine("Press a key to turn me off");
            Console.WriteLine();
            Console.ReadKey();
            // För att säkerställa att programmet avslutas: 
            Environment.Exit(-1);
        }
    }
}

