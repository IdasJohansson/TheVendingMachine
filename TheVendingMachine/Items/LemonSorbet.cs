using System;
using TheVendingMachine.Interfaces;
using TheVendingMachine.MoneyHandler;
using TheVendingMachine.Services;

namespace TheVendingMachine.Items
{
	public class LemonSorbet : Product, IProduct
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

        public LemonSorbet()
        {
            // Creating a Sorbet objekt
            Product product = Product.CreateProduct("Sorbet");

            // Giving the LemonSorbet objekt values
            product.ProductId = 5;
            product.ProductName = "LemonSorbet";
            product.ProductInfo = "250ml";
            product.ProductCost = 25;

            // Add Objekt to List of products 
            if (!Product.products.Contains(product))
            {
                Product.products.Add(product);
            }
        }

        public void Description()
        {
            Console.WriteLine();
            DateTime date = DateTime.Now;
            DateTime bestBefore = date.AddMonths(1);
            Console.WriteLine($"This sorbet is made of sugar and fruitjuice extracted from Lemons harvested in the southern of Sweden. Best-before date: {bestBefore.ToString("dd-MM-yyyy")} "); 
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
            Helper.SorbetSymbol();
            Console.WriteLine("Num num num...Cold and refreshing!");
            Helper.ReturnMenuMessage();
        }
    }
}

