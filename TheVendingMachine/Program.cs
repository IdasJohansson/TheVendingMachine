using TheVendingMachine.Interfaces;
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

AppleSoda appleSoda = new AppleSoda();
appleSoda.AddProductInfo(); 
BlackcurrantSoda blackcurrantSoda = new BlackcurrantSoda();
blackcurrantSoda.AddProductInfo();
CherrySoda cherrySoda = new CherrySoda();
cherrySoda.AddProductInfo();
ElderberrySorbet elderberrySorbet = new ElderberrySorbet();
elderberrySorbet.AddProductInfo();
LemonSorbet lemonSorbet = new LemonSorbet();
lemonSorbet.AddProductInfo();
MangoSorbet mangoSorbet = new MangoSorbet();
mangoSorbet.AddProductInfo();
Raspberry raspberry = new Raspberry();
raspberry.AddProductInfo();
Strawberry strawberry = new Strawberry();
strawberry.AddProductInfo();
Wildberry wildberry = new Wildberry();
wildberry.AddProductInfo();


// Tar fram startMenyn
Menus.StartMenu();


