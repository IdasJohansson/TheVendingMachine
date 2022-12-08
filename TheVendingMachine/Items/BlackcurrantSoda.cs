using System;
using TheVendingMachine.Interfaces;
using TheVendingMachine.MoneyHandler;
using TheVendingMachine.Services;

namespace TheVendingMachine.Items
{
	public class BlackcurrantSoda : Product, IProduct
	{
        public override int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        public override string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public override string ProductInfo
        {
            get { return productInfo; }
            set { productInfo = value; }
        }

        public override int ProductCost
        {
            get { return productCost; }
            set { productCost = value; }
        }

        public BlackcurrantSoda()
        {
            Product product = Product.CreateProduct("Soda");
            // Giving the Blackcurrent objekt values
            product.ProductId = 2;
            product.ProductName = "BlackcurrantSoda";
            product.ProductInfo = "330ml";
            product.ProductCost = 15;

            // Add produkt Objekt to List of products (in Product class)
            if (!Product.products.Contains(product))
            {
                Product.products.Add(product);
            }
        }

        public void Description()
        {
            DateTime date = DateTime.Now;
            DateTime bestBefore = date.AddYears(1);
            string info = $"Product information: This softdrink contains carbonated soda, sugar and fruitjuice extracted from Blackcurrant harvested in the southern of Sweden. Best-before date: {bestBefore.ToString("dd-MM-yyyy")} ";
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
                Console.WriteLine("Press [1] to confirm or [0] to return to menu.");
                Console.WriteLine();

                int confirm = Convert.ToInt32(Console.ReadLine());
                if (confirm == 1)
                {
                    // Tar bort produktkostnaden från pengarna som är isatta i maskinen och flyttar över dem
                    // till en annan variabel för att registreras som "använda"
                    Wallet.moneyInMachine -= cost;
                    Wallet.usedMoneyInMachine += cost;

                    // Vid köpa av produkt ska produkten köpas och användas
                    // Användaren tas tillbaka till menyn vid avslutat köp:
                    Use();
                }
                else
                {
                    Console.Clear();
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
            Helper.SodaSymbol();
            Console.WriteLine("Klunk klunk klunk...Oh so Fresh!");
            Helper.ReturnMenuMessage();
        }
    }
}

