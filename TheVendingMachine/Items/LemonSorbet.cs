using System;
using TheVendingMachine.Interfaces;

namespace TheVendingMachine.Items
{
	public class LemonSorbet : IProduct
	{
        public string Description()
        {
            return "This is cold sorbet";
        }
        public void Buy()
        { }
        public void Use()
        { }
    }
}

