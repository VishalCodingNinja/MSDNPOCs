namespace CustomerManagementSystem.Models
{
	public  class GoldCustomer : Customer
	{
		public override int Discount => TotalPurchase - 100;
	}
}
