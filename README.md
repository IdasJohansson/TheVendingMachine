# TheVendingMachine

Inlämningsuppgift VaruAotomat i kursen avancerad OOP.

# Arbetsprocess
Efter att ha läst igenom kraven för denna uppgiften visst jag inte riktigt hur eller vart jag skulle börja.
Som hjälp för att hitta en utgångspunkt valde jag därför att börja med att sätta upp en struktur för att matcha kriterierna
med att skapa en produkt som ärver från en abstrakt klass och har ett interface. Då jag inte arbetat med abstrakta klasser 
tidigare valde jag att utgå från "Abstract factory pattern". I mitt program har jag därför en abstrakt klass som heter Product,
och ett interface som heter IProduct. Som en mellannivå har jag tre klasser med produkt-kategorier (Soda, Berry, Sorbet) som ärven från den abstrakta klassen och sedan en klass per produkt som också ärver från produktklassen samt där interfacet implementeras. 

Jag valde att göra tre separata klasser för kategoriera för att enkelt kunna skilja de olika produkterna åt. Så när en produkt skapas och får sina värden sker detta genom kategoriklassen. 

# Flödet
När man starta programmet körs en metod som gör att alla produkter som ska säljas i Varuautomaten får värden, dvs ProductId, ProductName, ProductInfo samt ProductCost. Produkterna läggs även till i en statisk lista i Poduktklassen.  
Nästa metoden som körs är en Startmeny metod där man får välja mellan att visa produkter, stoppa i pengar, göra ett köp eller stänga av maskinen. I startmenyn anropas en metod som visar upp hur mycket pengar som finns i plånboken samt hur mycket pengar som finns i maskinen. Menyn är en switch som anropar olika metoder beroende på val.

Väljer man att visa produkter, skickas man först till ett val där man får välja kategori och när kategorins produkter visas upp visas även en annan meny upp där man får välja vad man vill göra härnäst. 


# Val av 
I mina menyer har jag valt att använda mig av switch cases då användaren i varje meny får tre eller flera val att göra som programet tar in som en input. 
Jag valde att ta in siffror som inputs då det blir det enkelt att sätta upp en switch struktur med ett case per siffra. Mina switchar/menyer ligger också i en try catch och på detta sätt tycker jag att felhanteringen blir lätthanterlig. Om användaren skriver in en siffra som inte är valbar i menyn skickas man till default delen i switchen och om man skriver något som inte är en siffra skickas man in i catchen som genom Exeption message skriver ut att det var ett felaktigt format. 

När något går fel ville jag att detta skulle synas extra tydligt genom att texten ska byta färg till röd. Därför gjorde jag en metod som tar in en text sträng som input och byter färg på denna till röd. Denna metod använder jag på många ställen så istället för att varje gång jag vill byta färg på en text behöva skriva minst tre rader med kod räcker det nu med enrad genom att jag anropar metoden och skickar med textsträngen som ska byta färg. 

# Lärdomar 
Abstrakta klasser kombinerat med interfaces. 

# Utmaningar
En utmaning jag hade var att bestämma hur jag skulle skapa mina produkt-objekt och tilldela dem värden. 

Något som jag gärna hade förvättrat med projektet är att det känns som att det är väldigt mycket upprepande kod i de olika produktklasserna då metoderna där i ser väldigt lika ut bortsett från unika saker som Produktnamn och Description. 

