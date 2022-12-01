﻿using System;
using TheVendingMachine.Interfaces;
using TheVendingMachine.Items;
using TheVendingMachine.Services; 
namespace TheVendingMachine.MoneyHandler
{
    public class Wallet
    {
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

        public static void MakePurchase()
        {
            try
            {
            Console.WriteLine();
            Console.WriteLine("Enter number of the product you want to Buy: ");
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
            var checkbalance = CheckBalance(cost);

            if (checkbalance == true)
            {
                // Vid val av produkt ska användaren kunnas e produktens beskrivning innan man väljer att köpa varan:
                iproduct.Description();

                // Användaren ska kunna acceptera köpet eller välja att gå tillbaka till menyn
                iproduct.Buy();
            }
            else
            {
                Helper.ErrorColor("You need to enter more money...Press a key to continue");
                Console.ReadKey(); 
                InsertMoney();
            }
            }
            catch (Exception e)
            {
                Helper.ErrorColor(e.Message);
                Helper.ReturnMenuMessage(); 
            }
        }

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
                            moneyInWallet = moneyInWallet - insertedAmount;
                            moneyInMachine.Add(insertedAmount);
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
            catch (Exception e)
            {
                Helper.ErrorColor(e.Message);
                Helper.ReturnMenuMessage(); 
            }

            }
       
    }
}

