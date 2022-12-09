using System;
namespace TheVendingMachine.MoneyHandler
{
	public class Change
	{
        public int Hundred { get; }
		public int Fifty { get; }
		public int Twenty { get; }
		public int Ten { get; }
		public int Five { get; }
		public int One { get; }

        // Konstruktorn tar in summan av pengarna som är isatta i maskinen men inte är använda 
		public Change(int moneyToReturn)
		{
            // Räknar ut hur många av respektive valör det går att få ut av summan som är kvar i maskinen
			Hundred = (moneyToReturn / 100);
			moneyToReturn %= 100;
            Fifty = (moneyToReturn / 50);
            moneyToReturn %= 50;
            Twenty = (moneyToReturn / 20);
            moneyToReturn %= 20;
            Ten = (moneyToReturn / 10);
            moneyToReturn %= 10;
            Five = (moneyToReturn / 5);
            moneyToReturn %= 5;
            One = (moneyToReturn / 1);
        }

        // Denna funktion anropas när användaren har valt att stänga av maskinen och skriver ut hur mycket och i vilken valör användaren får tillbaka när
        // I metoden anropas Change konstruktorn
        public static void ReturnMoney(int returnSum)
		{
            Console.WriteLine();
            Console.WriteLine("If you inserted money that you didn't use, they will be returned below: ");
            // Skapar ett change objekt, skickar med retursumman och skriver ut den i de olika valörerna efter att uträkningarna har skett i konstruktorn
            Change change = new Change(returnSum);
            Console.WriteLine($"Hundreds: {change.Hundred} (* 100 kr)");
            Console.WriteLine($"Fiftys: {change.Fifty} (* 50 kr)");
            Console.WriteLine($"Twentys: {change.Twenty} (* 20 kr)");
            Console.WriteLine($"Tens: {change.Ten} (* 10 kr)");
            Console.WriteLine($"Fives: {change.Five} (* 5 kr)");
            Console.WriteLine($"Ones: {change.One} (* 1 kr)");
            Console.WriteLine();
            Console.WriteLine($"Sum returned: {returnSum} kr");
        }


	}
}

