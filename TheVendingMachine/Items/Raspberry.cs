using System;
using TheVendingMachine.Interfaces;

namespace TheVendingMachine.Items
{
	public class Raspberry : IProduct
	{
        public string Description ()
        {
            return "This is a handpicked berry";
        }
        public void Buy()
        { }
        public void Use()
        { }

    }
}

