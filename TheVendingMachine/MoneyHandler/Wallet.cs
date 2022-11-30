using System;
using TheVendingMachine.Services; 
namespace TheVendingMachine.MoneyHandler
{
	public class Wallet
	{
        private int oneSEK = 1 * 10;
        private int fiveSEK = 5 * 10;
        private int tenSEK = 10 * 10;
        private int machineBalance;
        private int walletBalance;

        public int OneSEK
        {
            get { return oneSEK; }
            set { oneSEK = value; }
        }

        public int FiveSEK
        {
            get { return fiveSEK; }
            set { fiveSEK = value; }
        }

        public int TenSEK
        {
            get { return tenSEK; }
            set { tenSEK = value; }
        }


        public static List<int> moneyInMachine = new List<int>();

        public static int moneyInWallet = 30; 

        public static void InsertMoney(int amount)
        {
            // If wallet contains > amount
            if (moneyInWallet > amount)
            {
                moneyInWallet = moneyInWallet - amount; 
                moneyInMachine.Add(amount);
                Console.WriteLine($"Wallet contains: {moneyInWallet}");
            
            }
            // else "You don't have that amount in your wallet"
            else
            {
                Console.WriteLine("You don't have that amount in your wallet");
                Console.WriteLine("Press a key to return to menu");
                Console.ReadLine();
                Console.Clear(); 
                Menus.StartMenu(); 
            }
            
        }
    }
}

