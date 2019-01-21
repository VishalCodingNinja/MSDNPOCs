using System;
using System.Collections.Generic;

namespace SolidPrinciplesPOCs
{
	public class Customer
	{
		public int Id { get; set; }
		public string Name { get; set; }
		private ILogger _obj = null;
		
		public Customer(int id, string name, int total, ILogger obj)
		{
			Id = id;
			Name = name;
			TotalPurchase = total;
			_obj = obj;
		
		}

		public int TotalPurchase { get; set; }
		public List<Item> Items { get; set; }
	}

	internal class SilverCustomer : Customer, IDiscount, IDatabase
	{

		public SilverCustomer(int id, string name, int total, ILogger obj) : base(id, name, total, obj)
		{

		}
		public double GetDiscount(double total)
		{
			return total - 50;
		}
		public virtual void AddItemToCartAndDataBase(string item)
		{
			Console.WriteLine("Item added to the cart and database");
		}
	}

	class GoldCustomer : Customer, IDiscount, IDatabase
	{
		public GoldCustomer(int id, string name, int total, ILogger obj) : base(id, name, total, obj)
		{

		}
		public double GetDiscount(double total)
		{
			return total - 100;
		}
		public virtual void AddItemToCartAndDataBase(string item)
		{
			Console.WriteLine("Item added to the cart and database");
		}
	}
}
