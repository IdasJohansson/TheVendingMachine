using System;
using TheVendingMachine.Interfaces;
using TheVendingMachine.MoneyHandler;
using TheVendingMachine.Services;

namespace TheVendingMachine.Items
{
    // Produkten ärver från den abstrakta klassen Product och använder interfacet Iproduct
    public class ElderberrySorbet : Product, IProduct
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
        // Skapar en produkt i kategorin Sorbet, tilldelar den värden och lägger in den i listan av produkter
        public void AddProductInfo()
        {
            Product product = Product.CreateProduct("Sorbet");
            product.ProductId = 4;
            product.ProductName = "ElderberrySorbet";
            product.ProductInfo = "250ml";
            product.ProductCost = 25;
            Product.products.Add(product);
        }

        // Metod som finns i interfacet, innehåller en description om produkten
        // metoden anropas och visas innan användaren väljer att bekräfta sitt köp.
        public void Description()
        {
            Console.WriteLine();
            DateTime date = DateTime.Now;
            DateTime bestBefore = date.AddMonths(1);
            Console.WriteLine($"This sorbet is made of sugar and fruitjuice extracted from Elderberries harvested in the southern of Sweden. Best-before date: {bestBefore.ToString("yyyy-MM-dd")} ");

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
            Helper.SorbetSymbol();
            Console.WriteLine("Num num num...Cold and refreshing!");
            Helper.ReturnMenuMessage();
        }

    }
}

