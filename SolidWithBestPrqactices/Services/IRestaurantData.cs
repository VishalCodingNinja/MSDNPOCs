using Microsoft.AspNetCore.Mvc;
using SolidWithBestPrqactices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidWithBestPrqactices.Services
{
	public interface IRestaurantData
	{
		IEnumerable<Restaurant> GetAll();
		Restaurant GetRestaurant(int id);
		Restaurant Add(Restaurant newRestaurent);
		Restaurant Update(Restaurant restaurant);
	}

}
