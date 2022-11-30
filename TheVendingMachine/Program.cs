﻿using TheVendingMachine.Interfaces;
using TheVendingMachine.Items;



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






AppleSoda soda = new AppleSoda();
soda.AddProductInfo();
LemonSorbet sorbet = new LemonSorbet();
sorbet.AddProductInfo();
Raspberry berry = new Raspberry();
berry.AddProductInfo();

// writes out the added products previously added products in the list
// Product.ViewProductList();

//soda.Description();
//soda.Buy();
//soda.Use();


int buyThis = 1;

var productToBuy = Product.products.Find(x => x.ProductId == buyThis);

var category = productToBuy.GetType().Name;
Console.WriteLine(category);

Product product = Product.CreateProduct(category);


IProduct iproduct = product.GetProduct(productToBuy.ProductName);

iproduct.Buy(); 

