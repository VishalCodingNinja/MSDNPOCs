using CustomerManagementSystem.Interfaces;

namespace CustomerManagementSystem.Models
{
	public class Enquiry : IEnquiry
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public virtual int Discount { get; set; }
		public int TotalPurchase { get; set; }
		public string ItemPurchase { get; set; }

	}
}
