using System;
using TheVendingMachine.Interfaces;
using TheVendingMachine.Items;
using TheVendingMachine.MoneyHandler;
using TheVendingMachine.Services; 
namespace TheVendingMachine.MoneyHandler
{
    public class Wallet
    {
        // När programet startas finns det 10 mynt av enkronor, femkronor och tiokornor vardera i plånboken
        private static int oneSek = 10 * 1;
        private static int fiveSek = 10 * 5;
        private static int tenSek = 10 * 10;

        // moneyInMachine får ett värde när pengar matas in maskinen
        public static int moneyInMachine;
        // usedMoneyINmachine får ett värde när man handlar för pengar man matat in i maskinen 
        public static int usedMoneyInMachine;

        // Summering av pengarna i plånboken (160 kr)
        public static int moneyInWallet = oneSek + fiveSek + tenSek; 

        // Visar upp saldot i plånboken respektive pengar man har att handla för i maskinen
        public static void ViewBalance()
        {
            try
            {
            Console.WriteLine($"Money in wallet: {moneyInWallet}");
            Console.WriteLine($"Money in machine: {moneyInMachine}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Helper.ReturnMenuMessage();
            }
        }

        // Denna metod kollar så att det finns tillräckligt med inmatade pengar i maskinen för att kunna handla
        public static bool CheckBalance(int productCost)
        {
            try
            {
            Console.WriteLine();
            Console.Write("Current money inserted in machine: ");
            Console.WriteLine(moneyInMachine);
            Console.Write("Product cost: ");
            Console.WriteLine(productCost);

            // Kollar så att pengarna som går att använda i maskinen är större än produktkostnaden
            // returnerar true om det är tillräckligt, annars false. 
            if (moneyInMachine >= productCost)
            {
                return true; 
            }
            else
            {
                return false; 
            }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Helper.ReturnMenuMessage();
                return false;
            }
        }

        // Nedan metod innehåller de steg som behöver genomgås för att kunna genomföra ett köp
        public static void MakePurchase()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Enter number of the product you want to Buy to see product description and continue:  ");
                Console.WriteLine("(Press [0] to return)");
                int buyThis = Convert.ToInt32(Console.ReadLine());

                // Backa tillbaka till produktmenyn om man ångrar sig
                if (buyThis == 0)
                {
                    Console.Clear();
                    Menus.ViewProductsMenu();
                }

                // Går in i listan med produkter och hämtar objektet med id't som användaren har angett
                var productToBuy = Product.products.Find(x => x.ProductId == buyThis);

                // Lagrar kategorinamnet på den valda produkten i variabeln category
                var category = productToBuy.GetType().Name;

                // Instansierar ett objekt av produktkategorin
                Product product = Product.CreateProduct(category);

                // Skapar ett objekt av namnet på den hämtade produkten.
                IProduct iproduct = product.GetProduct(productToBuy.ProductName);

                // Vid köp av produkt så skall en kontroll ske; att användaren har
                // matat in tillräckligt med pengar till automaten.Om inte så
                // stoppas köpet.
                var cost = productToBuy.ProductCost;
                var checkbalance = CheckBalance(cost);

                if (checkbalance == true)
                {
                    // Vid val av produkt ska användaren kunnas e produktens beskrivning innan man väljer att köpa varan:
                    iproduct.Description();

                    // Användaren ska kunna acceptera köpet eller välja att gå tillbaka till menyn
                    iproduct.Buy(cost);
                }
                else
                {
                    Helper.ErrorColor("You need to enter more money...Press a key to continue");
                    Console.ReadKey();
                    // Skickar direkt vidare till metoden för att sätta in mer pengar
                    InsertMoney();
                }
            }
            catch (Exception e)
            {
                Helper.ErrorColor(e.Message);
                Helper.ReturnMenuMessage();
            }
        }

        // Metod som kollar att man måste ha lagt i minst 15 kr för att kunna komma till alternativet att göra ett köp
        public static void CheckIfMoneyInserted()
        {
            if (moneyInMachine < 15)
            {
                Console.WriteLine("Please feed the machine to make a purchase");
                Console.WriteLine("Press a key to continue");
                Console.ReadKey();
                Wallet.InsertMoney();
            }
            else
            {
                // Visar lista av produktkategorier
                Menus.ViewCategories();
                // Skickar vidare till Villkoren för att genomföra ett köp
                Wallet.MakePurchase();
            }

        }

        // Metod för att mata i pengar i maskinen
        public static void InsertMoney()
        {
            try
            {
                Console.Clear(); 
                bool loop = true;
                Console.WriteLine("How much do you want to insert?");
                Console.WriteLine("Accepted values are: 1, 5, 10 coins");
                while (loop == true)
                {
                    Console.WriteLine("Feed the machine or press [0] to return to menu.");
                    int insertedAmount = Convert.ToInt32(Console.ReadLine());

                    if (insertedAmount == 1 || insertedAmount == 5 || insertedAmount == 10)
                    {
                        // Kollar om plånboken innehåller summan man vill lägga in i maskinen 
                        if (moneyInWallet >= insertedAmount)
                        {
                            // Det bara går att lägga in 10 mynt av varje sort av eftersom plånboken bara innehåller det
                            TenCoinLimit(insertedAmount);
                            // Den isatta pengen dras bort från plånboken
                            moneyInWallet -= insertedAmount;
                            // Adderas i maskinen
                            moneyInMachine += insertedAmount;
                            // Visar upp hur mkt man har i plånboken, respektive hur mycket man har att handla för
                            ViewBalance();
                        }
                        // Om man inte har tillräckligt med pengar i plånboken
                        else
                        {
                            Helper.ErrorColor("You don't have that amount in your wallet");
                            Helper.ReturnMenuMessage(); 
                        }
                    }
                    // För att gå tillbaka till menyn
                    else if (insertedAmount == 0)
                    {
                        Console.Clear();
                        loop = false;
                        Menus.StartMenu();
                    }
                    // Om användaren väljer ett annat belopp än 1, 5 eller 10
                    else
                    {
                        Console.Clear();
                        Helper.ErrorColor("Insert a valid amout (1, 5 or 10)");
                    }
                 }
            }
            // Om användaren skriver en bokstav eller annat tecken istället för en int
            catch (Exception e)
            {
                Helper.ErrorColor(e.Message);
                Helper.ReturnMenuMessage(); 
            }

            }

        // Eftersom plånboken bara innehåller 10 mynt av varje, går det bara att lägga i max 10 tiokronor, max 10 femkronor och max 10 enkronor. TenCoinLimit håller koll på det. 
        public static void TenCoinLimit(int insertedAmount)
        {
            try
            {
            switch (insertedAmount)
            {
                case 10:
                    tenSek -= 10;
                    if (tenSek == 0)
                    Helper.ErrorColor("You are out of Tens, insert another coin"); 
                    break;
                case 5:
                    fiveSek -= 5;
                    if (fiveSek == 0)
                    Helper.ErrorColor("You are out of Fives, insert another coin"); 
                    break;
                case 1:
                    oneSek -= 1;
                    if (oneSek == 0)
                    Helper.ErrorColor("You are out of Ones, insert another coin"); 
                    break; 
                default:
                    Helper.ErrorColor("Something went wrong with TenCoinLimit");
                    Helper.ReturnMenuMessage();
                    break;
            }

            }
            catch (Exception ex)
            {
                Helper.ErrorColor(ex.Message);
                Helper.ReturnMenuMessage(); 
            }
        }
       
    }
}

