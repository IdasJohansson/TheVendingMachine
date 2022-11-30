using System;
using TheVendingMachine.Items;
using TheVendingMachine.Services; 
namespace TheVendingMachine.MoneyHandler
{
    public class Wallet
    {
        //private int oneSEK = 1 * 10;
        //private int fiveSEK = 5 * 10;
        //private int tenSEK = 10 * 10;

        //public int OneSEK
        //{
        //    get { return oneSEK; }
        //    set { oneSEK = value; }
        //}

        //public int FiveSEK
        //{
        //    get { return fiveSEK; }
        //    set { fiveSEK = value; }
        //}

        //public int TenSEK
        //{
        //    get { return tenSEK; }
        //    set { tenSEK = value; }
        //}

        public static int oneSek = 10 * 1;
        public static int fiveSek = 10 * 5;
        public static int tenSek = 10 * 10;

        public static List<int> moneyInMachine = new List<int>();

        public static int moneyInWallet = oneSek + fiveSek + tenSek; 

        public static void ViewBalance()
        {
            Console.WriteLine($"Money in wallet: {moneyInWallet}");
            Console.WriteLine($"Money in machine: {moneyInMachine.Sum()}");
        }

        public static bool CheckBalance(int productCost)
        {
            var sumInMachine = moneyInMachine.Sum();
            //var productCost = Product.products[0].ProductCost; 

            Console.WriteLine("Current money inserted in machine:");
            Console.WriteLine(sumInMachine);
            Console.WriteLine("Product cost:");
            Console.WriteLine(productCost);

            if (sumInMachine > productCost)
            {
                return true; 
            }
            else
            {
                return false; 
            }
          
        }

        public static void InsertMoney()
        {
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
                    if (moneyInWallet > insertedAmount)
                    {
                        moneyInWallet = moneyInWallet - insertedAmount;
                        moneyInMachine.Add(insertedAmount);
                        ViewBalance();

                    }
                    // Om man inte har tillräckligt med pengar i plånboken
                    else
                    {
                        Console.WriteLine("You don't have that amount in your wallet");
                        Console.WriteLine("Press a key to return to menu");
                        Console.ReadLine();
                        Menus.StartMenu();
                    }
                }
                // För att gå tillbaka till menyn
                else if (insertedAmount == 0)
                {
                    Console.Clear(); 
                    loop = false;
                }
                // Om användaren väljer ett annat belopp än 1, 5 eller 10
                else
                {
                    Console.Clear();
                    Console.WriteLine("Insert a valid amount ");
                }

            }
        }
    }
}

