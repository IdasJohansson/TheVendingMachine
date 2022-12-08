using System;
using TheVendingMachine.Interfaces;
using TheVendingMachine.MoneyHandler;
using TheVendingMachine.Services;

namespace TheVendingMachine.Items
{
	public class Strawberry : Product, IProduct
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

        public Strawberry()
        {
            // Creating a Berry objekt
            Product product = Product.CreateProduct("Berry");

            // Giving the LemonSorbet objekt values
            product.ProductId = 8;
            product.ProductName = "Strawberry";
            product.ProductInfo = "200g";
            product.ProductCost = 40;

            // Objekt to List of products 
            if (!Product.products.Contains(product))
            {
                Product.products.Add(product);
            }
        }

        public void Description()
        {
            DateTime date = DateTime.Now;
            DateTime bestBefore = date.AddDays(7);
            string info = $"Theese berries are handpicked in the southern of Sweden. Best-before date: {bestBefore.ToString("dd-MM-yyyy")} ";
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
            Helper.StrawberrySymbol();
            Console.WriteLine("Yum yum yum, tastes like summer!");
            Helper.ReturnMenuMessage();
        }
    }
}

