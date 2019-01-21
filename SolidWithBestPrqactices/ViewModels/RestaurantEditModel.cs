using SolidWithBestPrqactices.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SolidWithBestPrqactices.ViewModels
{
	public class RestaurantEditModel
	{
		[Required,MaxLength(20)]
		public string Name { get; set; }
		public CuisineType Cusine { get; set; }
	}
}
