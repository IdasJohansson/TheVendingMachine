using System;
using TheVendingMachine.Interfaces;
using TheVendingMachine.MoneyHandler;
using TheVendingMachine.Services;

namespace TheVendingMachine.Items
{
    // Produkten ärver från den abstrakta klassen Product och använder interfacet Iproduct
    public class Raspberry : Product, IProduct
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

        // Denna metod lägger till information om produkten
        // Skapar en produkt i kategorin Berry, tilldelar den värden och lägger in den i listan av produkter
        public void AddProductInfo()
        {
            Product product = Product.CreateProduct("Berry");
            product.ProductId = 7;
            product.ProductName = "Raspberry";
            product.ProductInfo = "200g";
            product.ProductCost = 40;
            Product.products.Add(product);
        }

        // Metod som finns i interfacet, innehåller en description om produkten
        // metoden anropas och visas innan användaren väljer att bekräfta sitt köp.
        public void Description ()
        {
            DateTime date = DateTime.Now;
            DateTime bestBefore = date.AddDays(7);
            string info = $"Theese berries are handpicked in the southern of Sweden. Best-before date: {bestBefore.ToString("yyyy-MM-dd")} ";
            Console.WriteLine();
            Console.WriteLine(info);
        }

        // Metod som finns i interfacet,
        // Anropas när efter att produktens description har visats upp.
        // Tar in kostnaden på produkten och användaren kan välja att antingen bekräfta köpet eller avbryta
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
                    Menus.StartMenu();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Helper.ReturnMenuMessage();
            }
        }

        // Metod som finns i interfacet, anropas efter att köpet av produkten har gått igenom och innebär att användaren använder produkten
        public void Use()
        {
            Console.Clear();
            Console.WriteLine("Purchase confirmed");
            Helper.RasberrySymbol(); 
            Console.WriteLine("Yum yum yum, tastes like summer!");
            Helper.ReturnMenuMessage();
        }

    }
}

