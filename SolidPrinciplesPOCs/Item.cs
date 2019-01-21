using System.Collections.Generic;

namespace SolidPrinciplesPOCs
{
	public class Item
	{
		public int ItemId { get; set; }
		public int Price { get; set; }
		public string ItemName { get; set; }
		
	}
	public class Order
	{
		public int OrderId { get; set; }
		public int MyProperty { get; set; }
	}
}
