using SolidWithBestPrqactices.Models;
using System.Collections.Generic;

namespace SolidWithBestPrqactices.ViewModels
{
	public class HomeIndexViewModel
	{
		public IEnumerable<Restaurant> Restaurants { get; set; }
		public string CurrentMessage { get; set; }
	}
}
