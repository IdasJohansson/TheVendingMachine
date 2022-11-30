using System;
using TheVendingMachine.Interfaces;

namespace TheVendingMachine.Items
{
	public class AppleSoda : IProduct
    {

        public AppleSoda(int id, string name, string info, int cost)
        {
           
        }



        

        public string Description()
        {
            return "This is a soda made of Apples"; 
        }
        public void Buy()
        { }
        public void Use()
        { }
    }
}

