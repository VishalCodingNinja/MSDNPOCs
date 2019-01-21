using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagementSystem.Interfaces
{
	public interface ICustomer
	{
		int Id { get; set; }
		string Name { get; set; }
		string Address { get; set; }
		int Discount { get; set; }
		int TotalPurchase { get; set; }
		string ItemPurchase { get; set; }
		string AddToCartAndDatabase { get; set; }

	}
}
