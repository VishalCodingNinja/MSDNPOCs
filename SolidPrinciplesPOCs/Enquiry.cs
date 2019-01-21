using System;
using System.Collections.Generic;
using System.Text;

namespace SolidPrinciplesPOCs
{
	class Enquiry : IDiscount
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int TotalPurchase { get; set; }
		public ILogger Ilog { get; set; }
		public Enquiry(int id, string name, int totalPurchase, ILogger obj)
		{
			Id = id;
			Name = name;
			TotalPurchase = totalPurchase;
			Ilog = obj;
		}

		public double GetDiscount(double total)
		{
			return total - 10;
		}
	}
}
