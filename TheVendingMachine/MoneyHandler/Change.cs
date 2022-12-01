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

		public Change(int moneyToReturn)
		{
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
            //moneyToReturn %= 1;
        }

		public static void ReturnMoney(int returnSum)
		{
            Change change = new Change(returnSum);
            Console.WriteLine($"Hundreds: {change.Hundred} (* 100 kr)");
            Console.WriteLine($"Hundreds: {change.Fifty} (* 50 kr)");
            Console.WriteLine($"Hundreds: {change.Twenty} (* 20 kr)");
            Console.WriteLine($"Hundreds: {change.Ten} (* 10 kr)");
            Console.WriteLine($"Hundreds: {change.Five} (* 5 kr)");
            Console.WriteLine($"Hundreds: {change.One} (* 1 kr)");
            Console.WriteLine($"Sum returned:{returnSum}");
        }


	}
}

