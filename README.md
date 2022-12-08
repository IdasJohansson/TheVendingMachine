# TheVendingMachine

Inlämningsuppgift VaruAotomat i kursen avancerad OOP.

Efter att ha läst igenom kraven för denna uppgiften visst jag inte riktigt hur eller vart jag skulle börja.
Som hjälp för att hitta en utgångspunkt valde jag därför att börja med att sätta upp en struktur för att matcha kriterierna
med att skapa en produkt som ärver från en abstrakt klass och har ett interface. Då jag inte arbetat med abstrakta klasser 
tidigare valde jag att utgå från "Abstract factory pattern". I mitt program har jag därför en abstrakt klass som heter Product,
och ett interface som heter IProduct. Som en mellan nivå har jag tre klasser med produkt-kategorier som ärven från den abstrakta klassen 
och i varje produktklass implementeras interfacet. 



# Lärdomar 
Abstrakta klasser kombinerat med interfaces. 

# Utmaningar
En utmaning jag hade var att bestämma hur jag skulle skapa mina produkt-objekt och tilldela dem värden. 
Först gjorde jag en metod för varje produkt som tilldelade den värden till dess properties men då detta kändes oeffektivt landade jag sedan i 
att tilldela varje produkts properties värden i dess konstruktor. 
