﻿using TheVendingMachine.Interfaces;
using TheVendingMachine.Items;
using TheVendingMachine.Services;


//// Create the Sodafactory object by passing the factory type as Soda
//// Abstract factory
//Product product = null;
//product = Product.CreateProduct("Soda");
//Console.WriteLine("Product type: " + product.GetType().Name);

//// Get AppleSoda object by passing the soda type as AppleSoda
//// interface 
//IProduct iproduct = null;
//iproduct = product.GetProduct("AppleSoda");
//Console.WriteLine("Soda type: " + iproduct.GetType().Name);
//var apple = iproduct.GetType().Name;

//// Method
//string description = null;
//// Reach the Applesodas methods if its with returntype string
//description = iproduct.Description();
//Console.WriteLine(apple + " " + description);

//product.ProductId = 1;
//product.ProductName = "AppleSoda";
//product.ProductInfo = "330ml"; 
//product.ProductCost = 15;

// Skapar alla produkter
AppleSoda appleSoda = new AppleSoda();
BlackcurrantSoda blackcurrantSoda = new BlackcurrantSoda();
CherrySoda cherrySoda = new CherrySoda();
ElderberrySorbet elderberrySorbet = new ElderberrySorbet();
LemonSorbet lemonSorbet = new LemonSorbet();
MangoSorbet mangoSorbet = new MangoSorbet();
Raspberry raspberry = new Raspberry();
Strawberry strawberry = new Strawberry();
Wildberry wildberry = new Wildberry();

// Tar fram startMenyn
Menus.StartMenu();


