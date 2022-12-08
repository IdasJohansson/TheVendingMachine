# TheVendingMachine

Inlämningsuppgift VaruAotomat i kursen avancerad OOP.

# Arbetsprocess
Efter att ha läst igenom kraven för denna uppgiften visst jag inte riktigt hur eller vart jag skulle börja.
Som hjälp för att hitta en utgångspunkt valde jag därför att börja med att sätta upp en struktur för att matcha kriterierna
med att skapa en produkt som ärver från en abstrakt klass och har ett interface. Då jag inte arbetat med abstrakta klasser 
tidigare valde jag att utgå från "Abstract factory pattern". I mitt program har jag därför en abstrakt klass som heter Product,
och ett interface som heter IProduct. Som en mellannivå har jag tre klasser med produkt-kategorier (Soda, Berry, Sorbet) som ärven från den abstrakta klassen och sedan en klass per produkt som också ärver från produktklassen samt där interfacet implementeras. 

Kategoriklasserna kom in ganska sent i arbetsprocessen då jag enkelt ville kunna kategorisera de olika produkterna. Från början funderade jag på om produkterna skulle ha en property som var en kategori och dela in dom på det sättet. Men jag valde en annan lösning efter att ha lärt mig använda den inbyggda metoden "GetType().Name". Så när en produkt skapas och får sina värden sker detta genom kategoriklassen. 

![image](https://user-images.githubusercontent.com/89834477/206554880-48b5fc0d-b239-4b8a-9262-a9da30c84b57.png)

Jag har två klasser som sköter hanterar pengar i programmet. Den huvudsakliga klassen Wallet samt en klass som hanterar pengarna som ska returneras, Change. 

# Flödet
När man starta programmet körs en metod som gör att alla produkter som ska säljas i Varuautomaten får värden, dvs ProductId, ProductName, ProductInfo samt ProductCost. Produkterna läggs även till i en statisk lista i Poduktklassen.  
Nästa metoden som körs är en Startmeny metod där man får välja mellan att visa produkter, stoppa i pengar, göra ett köp eller stänga av maskinen. I startmenyn anropas en metod som visar upp hur mycket pengar som finns i plånboken samt hur mycket pengar som finns i maskinen. Menyn är en switch som anropar olika metoder beroende på val.

Väljer man att visa produkter, skickas man först till ett val där man får välja kategori och när kategorins produkter visas upp visas även en annan meny upp där man får välja vad man vill göra härnäst. 


# Olika val 
I mina menyer har jag valt att använda mig av switch cases då användaren i varje meny får tre eller flera val att göra som programet tar in som en input. 
Jag valde att ta in siffror som inputs då det blir det enkelt att sätta upp en switch struktur med ett case per siffra. Mina switchar/menyer ligger också i en try catch och på detta sätt tycker jag att felhanteringen blir lätthanterlig. Om användaren skriver in en siffra som inte är valbar i menyn skickas man till default delen i switchen och om man skriver något som inte är en siffra skickas man in i catchen som genom Exeption message skriver ut att det var ett felaktigt format. 

När något går fel ville jag att detta skulle synas extra tydligt genom att texten ska byta färg till röd. Därför gjorde jag en metod som tar in en textsträng som input och byter färg på denna till röd. Denna metod använder jag på många ställen så istället för att varje gång jag vill byta färg på en text behöva skriva minst tre rader med kod räcker det nu med en rad genom att jag anropar metoden och skickar med textsträngen som ska byta färg. 

En sak som sker ofta är att kosolen ska rensas och användaren ska skickas tillbaka till Start, därför gjorde jag en metod för detta också. 

# Lärdomar 
Jag har bland annat lärt mig nya saker om: 
- Abstrakta klasser kombinerat med interfaces. 
- GetType().Name

# Utmaningar
En utmaning jag hade var att bestämma hur jag skulle skapa mina produkt-objekt och tilldela dem värden. Jag fastnade lite i att från börja göra detta i en metod och även om jag under processens gång tidvis gjorde detta i konstruktorn blev det tillslut ändå i en metod då jag ju bara ville tilldela värdena en gång och inte varje gång man anropade konstruktorn.  

Något som jag gärna hade förvättrat med projektet är att det känns som att det är väldigt mycket upprepande kod i de olika produktklasserna då metoderna där i ser väldigt lika ut bortsett från unika saker som Produktnamn och Description. 

