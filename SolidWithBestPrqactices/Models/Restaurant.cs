using System.ComponentModel.DataAnnotations;
namespace SolidWithBestPrqactices.Models
{
	public class Restaurant
	{
		public int Id { get; set; }
		[Display(Name="Enter Restaurent Name")]
		[Required,MaxLength(80)]
		public string Name { get; set; }
		public CuisineType Cuisine { get; set; }
	}
}