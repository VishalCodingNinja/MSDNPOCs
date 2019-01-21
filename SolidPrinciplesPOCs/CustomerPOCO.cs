using System.Collections.Generic;

namespace SolidPrinciplesPOCs
{
	public class CustomerPOCO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int TotalPurchase { get; set; }
		public List<Item> Items { get; set; }
	}
}
