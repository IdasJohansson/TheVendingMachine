using System;
using TheVendingMachine.Interfaces;
using TheVendingMachine.Items;

namespace TheVendingMachine.Services
{
	public class Menus
	{
		public static void StartMenu()
		{
            Console.WriteLine("WELCOME TO THIS SUPERAMAZING VENDING MACHINE");
            Console.WriteLine();

            Console.WriteLine("Please select one of below options: ");
            Console.WriteLine("[1] Display items");
            Console.WriteLine("[2] Insert money");
            Console.WriteLine("[3] Purchase");
            Console.WriteLine("[0] Turn machine off");
            Console.WriteLine();

            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    Console.Clear();
                    Product.ViewProductList();
                    ViewProductsMenu();
                    break;
                case 3:
                    Product.ViewProductList();
                    Console.WriteLine("Enter product number: ");
                    int buyThis = Convert.ToInt32(Console.ReadLine());

                    var productToBuy = Product.products.Find(x => x.ProductId == buyThis);

                    // Fetching the category name
                    var category = productToBuy.GetType().Name;

                    Product product = Product.CreateProduct(category);
                    IProduct iproduct = product.GetProduct(productToBuy.ProductName);

                    iproduct.Buy();
                    iproduct.Description();
                    Console.WriteLine("Are you sure you want to buy this product? ");
                    Console.WriteLine("Press 1 to confirm and 0 to return to menu.");
                    int confirm = Convert.ToInt32(Console.ReadLine());
                    if (confirm == 1)
                    {
                        iproduct.Use();
                    }
                    else
                    {
                        StartMenu(); 
                    }

                    break; 
            }
        }


        public static void ViewProductsMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] Insert money");
            Console.WriteLine("[2] Purchase");
            Console.WriteLine("[3] Return to start");
            Console.WriteLine("[0] Turn machine off");

            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    Console.WriteLine("Insert money");
                    break;
                case 2:
                    Product.ViewProductList();
                    Console.WriteLine("Enter product number: ");
                    int buyThis = 1;

                    var productToBuy = Product.products.Find(x => x.ProductId == buyThis);

                    var category = productToBuy.GetType().Name;
                    Console.WriteLine(category);

                    Product product = Product.CreateProduct(category);
                    IProduct iproduct = product.GetProduct(productToBuy.ProductName);

                    iproduct.Buy();
                    iproduct.Description();
                    iproduct.Use();
                    break;
                default: 
                    break; 
            }
        }


    }
}

