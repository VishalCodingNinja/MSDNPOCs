using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CItyInfo.API.Models
{
	public class UpdatingCityDTO
	{
		[Required(ErrorMessage = "You should provide the Id")]

		public int Id { get; set; }
		[MinLength(8)]
		public string Name { get; set; }
		public string State { get; set; }
		public string PointOfInterest { get; set; }
	}
}
