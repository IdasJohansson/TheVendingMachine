# TheVendingMachine

Inlämningsuppgift Automat Konsol i kursen avancerad OOP HT 2022. 

# Bakgrund
Uppgiften går ut på att skriva ett program som är en konsol applikation som fungerar som en varuautomat för att öva på att skriva ett program efter en enkel kravspecifikation. 

Kraven innefattar kortfattat följande: 

Funktionalitet:
- Automaten ska erbjuda produkter i tre olika kategorier med minst tre produkter i varje kategori. 
- Användaren ska kunna se information om varje produkt innan köp samt kunna köpa och använda produkten. 
- Varje produkt ska ha en kostnad som ska visas innan man köper produkten.
- Användaren ska kunna avbryta köpet och gå tillbaka till menyn. Eller skickas tillbaka till menyn efter genomfört köp.
- Vid genomförande av köp ska programmet kontrollera att det finns tillräckligt med pengar i maskinen.
- Användaren ska ha en plånbok med 10 enkronor, 10 femkronor samt 10 tiokronor. 
- Användaren ska genom ett menyval kunna mata in pengar i maskinen, samt se hur mycket som finns i maskinen respektive i plånboken. 
- Användaren ska genom ett menyval kunna avsluta programmet och kvarvarande pengar ska returneras i högsta möjliga valörer (1, 5, 10, 20, 50, 100)

Struktur: 
- Varje produkt ska ha en egen klass men ett interface och ärver från samma abstrakta klass.
- Den abstrakta klassen ska innehålla attribut för namn, kostnad samt beskrivning. 
- Interfacet ska innehålla metoderna Description, Buy() och Use(). 
- Plånboken ska vara en egen klass, där användarens pengar sparas och uppdateras. 

# Arbetsprocess
Som hjälp för att hitta en utgångspunkt valde jag att börja med att sätta upp en struktur för att matcha kriterierna
med att skapa en produkt som ärver från en abstrakt klass och har ett interface. Då jag inte arbetat med abstrakta klasser 
tidigare valde jag att utgå från "Abstract factory pattern". I mitt program har jag därför en abstrakt klass som heter Product,
och ett interface som heter IProduct. Som en mellannivå har jag tre klasser med produkt-kategorier (Soda, Berry, Sorbet) som ärven från den abstrakta klassen och sedan en klass per produkt som också ärver från produktklassen samt där interfacet implementeras. 

Kategoriklasserna var de klasser som jag skapade sist i min arbetsprocess utav klasserna. Från början funderade jag på om produkterna skulle ha en property som var en kategori och dela in dom på det sättet. Men jag valde en annan lösning efter att ha lärt mig använda den inbyggda metoden "GetType().Name" för att komma åt namnet på den kategorin som produkten tillhör. När en produkt skapas och får sina värden sker detta genom dess kategoriklass. 

Efter att ha satt grundstrukturen med Abstrakt klass, interface och produkter adderade jag två service klasser, Helper och Menus. Menus eftersom jag visste att jag skulle behöva flertalet menyer och en Helper-klass där jag ville lägga övriga medtoder som mest hade med visuella effekter i konsollen att göra. Denna innehåller därför metoder som byter färg på text samt ascii-art. 

För att kunna köpa produkter i maskinen skapade jag två klasser som hanterar pengar i programmet. Den huvudsakliga klassen Wallet samt en klass som hanterar pengarna som ska returneras, Change. I min Wallet började jag med att skapa tre variabler med utgånsvärdena för vilka mynt den skulle innehålla, en variabel som summerar deras värden, en variabel som lagrar pengar som matas in i maskinen samt en variabel som lagrar de pengar som användaren har handlat för. Dessa variabler uppdateras under programmets gång i de olika metoderna i plånboken. 

Detta är mapp/fil-strukturen i projektet: 

![image](https://user-images.githubusercontent.com/89834477/206554880-48b5fc0d-b239-4b8a-9262-a9da30c84b57.png) 

# Flödet
När man starta programmet körs en metod som gör att alla produkter som ska säljas i Varuautomaten får värden, dvs ProductId, ProductName, ProductInfo samt ProductCost. Produkterna läggs även till i en statisk lista i Poduktklassen.  
Nästa metoden som körs är en Startmeny metod där man får välja mellan att visa produkter, stoppa i pengar, göra ett köp eller stänga av maskinen. I startmenyn anropas en metod som visar upp hur mycket pengar som finns i plånboken samt hur mycket pengar som finns i maskinen. Menyn är en switch som anropar olika metoder beroende på användarens val.

Väljer man att visa produkter, skickas man först till en meny där man får välja kategori och när kategorins produkter visas upp visas även en annan meny upp där man får välja vad man vill göra härnäst. Då kan man välja mellan att sätta i pengar, göra ett köp, gå tillbaka till start eller stänga av programmet. Både valet att lägga i pengar eller köpa en produkt skickar vidare till metoden att lägga i pengar i maskinen om variabeln som lagrar pengar i maskinen är mindre än 15. Eftersom plånboken enbart innehåller en kronor, femkronor och tiokronor är det bara dessa valörer som användaren kan mata in i maskinen. 

Om man har lagt i minst 15kr, vilket är den lägsta produktkostnaden, i maskinen skickas man vidare till metoden där man kan välja produkt och genomföra ett köp. Det första som händer i den metoden är att användaren får välja en produkt och sedan kollar en metod som returnerar en bool av om användaren matat i tillräckligt med pengar i maskinen. Om inte skickas den till tidigare nämda metod där man får lägga i pengar. Om det finns tillräckligt med pengar skrivs produktens information ut och användaren för välja att bekräfta köpet eller återgå till menyn. Väljer man att bekräfta köpet så används produkten och användaren blir efter detta returnerad till Startmenyn där det återigen går att välja om man vill se produkter, lägga i pengar, göra ett köp eller stänga av maskinen. 

När användaren väljer att stänga av maskinen ska pengar returneras i högsta möjliga valör. Denna uträkning sker i klassen Changes konstruktor. Där man genom division och modulus räknar ut hur många utav varje valör som eventuellt ska returneras till användaren. 

# Olika val 
I mina menyer har jag valt att använda mig av switch cases då användaren i varje meny får tre eller flera val att göra som programet tar in som en input. 
Jag valde att ta in siffror som inputs då det blir det enkelt att sätta upp en switch struktur med ett case per siffra. Mina switchar/menyer ligger också i en try catch och på detta sätt tycker jag att felhanteringen blir lätthanterlig. Om användaren skriver in en siffra som inte är valbar i menyn skickas man till default delen i switchen och om man skriver något som inte är en siffra skickas man in i catchen som genom Exeption message skriver ut att det var ett felaktigt format. 

När något går fel ville jag att detta skulle synas extra tydligt genom att texten ska byta färg till röd. Därför gjorde jag en metod som tar in en textsträng som input och byter färg på denna till röd. Denna metod använder jag på många ställen så istället för att varje gång jag vill byta färg på en text behöva skriva minst tre rader med kod räcker det nu med en rad genom att jag anropar metoden och skickar med textsträngen som ska byta färg. 

En sak som sker ofta är att konsolen ska rensas och användaren ska skickas tillbaka till Start, därför gjorde jag en metod för detta också. 

I min abstrakta klass valde jag utöver de properties som mina produkter skulle ha att använda mig av en statisk lista där alla produkter lagras. Den är statisk för att vara lätt att komma åt i alla delar av programmet genom produktklassen. 

# Lärdomar 
Jag har bland annat lärt mig nya saker om: 
- Abstrakta klasser kombinerat med interfaces. 
- GetType().Name
- Konstruktorer

# Utmaningar
En utmaning jag hade var att bestämma hur jag skulle skapa mina produkt-objekt och tilldela dem värden. Jag fastnade lite i att från börja göra detta i en metod och även om jag under processens gång tidvis gjorde detta i konstruktorn blev det tillslut ändå i en metod då jag bara ville tilldela värdena en gång och inte varje gång man anropade konstruktorn.  

Något som jag gärna hade förbättrat med projektet är att det känns som att det är väldigt mycket upprepande kod i de olika produktklasserna då metoderna där i ser väldigt lika ut bortsett från unika saker som Produktnamn och Description. 
En annan sak jag har funderat över är hur "effektiv" koden är skriven, tex hur lång tid olika kommandon tar osv. Detta hade jag också gärna förbättrat men vet i nuläget inte hur jag skulle gå tillväga för att göra. 

# Källor

https://www.programiz.com/csharp-programming/abstract-class
![image](https://user-images.githubusercontent.com/89834477/206686411-3f5a0de2-3bd5-4897-a007-5974fd52f680.png)

https://www.geeksforgeeks.org/c-sharp-abstract-classes/
![image](https://user-images.githubusercontent.com/89834477/206686452-8cf26708-47d7-46b4-9cca-ae5bc91e0a17.png)

https://patorjk.com/software/taag/#p=display&f=Graffiti&t=Type%20Something%20

https://www.oocities.org/spunk1111/food.htm
