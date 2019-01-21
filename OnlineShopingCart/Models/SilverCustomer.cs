using System;

namespace CustomerManagementSystem.Models
{
	public class SilverCustomer:Customer
	{
		public override int Discount
		{
			get => TotalPurchase - 150;
			set
			{
				if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
				Discount = value;
			}
		}
	}
}
