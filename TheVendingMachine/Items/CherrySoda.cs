using System;
using TheVendingMachine.Interfaces;
using TheVendingMachine.MoneyHandler;
using TheVendingMachine.Services;

namespace TheVendingMachine.Items
{
    // Produkten ärver från den abstrakta klassen Product och använder interfacet Iproduct
    public class CherrySoda : Product, IProduct
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
        // Skapar en produkt i kategorin Soda, tilldelar den värden och lägger in den i listan av produkter
        public void AddProductInfo()
        {
            Product product = Product.CreateProduct("Soda");
            product.ProductId = 3;
            product.ProductName = "CherrySoda";
            product.ProductInfo = "330ml";
            product.ProductCost = 15;
            Product.products.Add(product);
        }

        // Metod som finns i interfacet, innehåller en description om produkten
        // metoden anropas och visas innan användaren väljer att bekräfta sitt köp.
        public void Description()
        {
            DateTime date = DateTime.Now;
            DateTime bestBefore = date.AddYears(1);
            string info = $"Product information: This softdrink contains carbonated soda, sugar and fruitjuice extracted from Cherrys harvested in the southern of Sweden. Best-before date: {bestBefore.ToString("yyyy-MM-dd")} ";
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

        // Metod som finns i interfacet, anropas efter att köpet av produkten har gått igenom och innebär att användaren använder produkten
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

