using System;
namespace TheVendingMachine.Interfaces
{
	public interface IProduct
	{
        // Alla produkter har detta interface, därför implementeras nedan metoder i varje produkt
        public void Description(); 
        public void Buy(int productCost);
        public void Use();
    }
}

