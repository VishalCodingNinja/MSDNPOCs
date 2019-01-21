using System.ComponentModel.DataAnnotations;

namespace CustomerManagementSystem.ViewModel
{
	public class CustomerEditModel
	{
		public int Id { get; set; }
		[Display(Name = "Customer Name")]
		[Required, MaxLength(50)]
		public string Name { get; set; }

		[Required, MaxLength(50)]
		public string Address { get; set; }
		[Required]
		public virtual int Discount { get; set; }
		[Required]
		public int TotalPurchase { get; set; }
		[Required, MaxLength(50)]
		public string ItemPurchase { get; set; }
		[Required, MaxLength(50)]
		public string AddToCartAndDatabase { get; set; }
	}
}
