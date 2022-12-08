# TheVendingMachine

Inlämningsuppgift VaruAotomat i kursen avancerad OOP.

Efter att ha läst igenom kraven för denna uppgiften visst jag inte riktigt hur eller vart jag skulle börja.
Som hjälp för att hitta en utgångspunkt valde jag därför att börja med att sätta upp en struktur för att matcha kriterierna
med att skapa en produkt som ärver från en abstrakt klass och har ett interface. Då jag inte arbetat med abstrakta klasser 
tidigare valde jag att utgå från "Abstract factory pattern". I mitt program har jag därför en abstrakt klass som heter Product,
och ett interface som heter IProduct. Som en mellannivå har jag tre klasser med produkt-kategorier som ärven från den abstrakta klassen 
och sedan en klass per produkt som också ärver från produkt klassen samt där interfacet implementeras. 

Jag valde att göra tre separata klasser för kategoriera för att enkelt kunna skilja de olika produkterna åt. Så när en produkt skapas och får sina värden sker detta genom kategoriklassen. 

# Flödet
När man starta programmet körs en metod som gör att alla produkter som ska säljas i Varuautomaten får värden, dvs ProductId, ProductName, ProductInfo samt ProductCost. Produkterna läggs även till i en statisk lista i Poduktklassen.  
Nästa metoden som körs är en Startmeny metod där man får välja mellan att visa produkter, stoppa i pengar, göra ett köp eller stänga av maskinen. 
Väljer man att visa produkter, skickas man först till ett val där man får välja kategori och när kategorins produkter visas upp visas även en annan meny upp där man får välja vad man vill göra härnäst. 

I mina menyer har jag valt att använda mig av switch cases. 





# Lärdomar 
Abstrakta klasser kombinerat med interfaces. 

# Utmaningar
En utmaning jag hade var att bestämma hur jag skulle skapa mina produkt-objekt och tilldela dem värden. 

Något som jag gärna hade förvättrat med projektet är att det känns som att det är väldigt mycket upprepande kod i de olika produktklasserna då metoderna där i ser väldigt lika ut bortsett från unika saker som Produktnamn och Description. 

