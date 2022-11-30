using System;
namespace TheVendingMachine.Interfaces
{
	public interface IProduct
	{
        public string Description(); 

        public void Buy();
        public void Use();
    }
}

