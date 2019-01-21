using System;

namespace SolidPrinciplesPOCs
{
	class NewCustomer : Customer, IDatabase, IDatabaseV1
	{
		public NewCustomer(int id, string name, int total, ILogger obj) : base(id, name, total, obj)
		{

		}
		public void AddItemToCartAndDataBase(string item)
		{
			Console.WriteLine("Add to database");
		}

		public void Read()
		{
			Console.WriteLine("Reading all data");
		}
	}
}
