using SolidWithBestPrqactices.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SolidWithBestPrqactices.Services
{
	public class InMemoryRestaurant:IRestaurantData
	{
		private List<Restaurant> _restaurants;

		public InMemoryRestaurant()
		{
			_restaurants = new List<Restaurant>
			{
				new Restaurant{Id=1,Name="Vishal pizza place"},
				new Restaurant{Id=2,Name="Dhaba Restaurant"},
				new Restaurant{Id=3,Name="Chaska"},
				new Restaurant{Id=4,Name="Funny Dhaba"},
				new Restaurant{Id=5,Name="Bangalore Swad"}
			};
		}

		public Restaurant Add(Restaurant newRestaurent)
		{
			newRestaurent.Id = _restaurants.Max(r => r.Id) + 1;
			_restaurants.Add(newRestaurent);
			return newRestaurent;
		}

		public IEnumerable<Restaurant> GetAll()
		{
			return _restaurants.OrderBy(r=>r.Name).ToList();
		}


		public Restaurant GetRestaurant(int id)
		{
			return _restaurants.FirstOrDefault(r => r.Id == id);
		}

		public Restaurant Update(Restaurant restaurant)
		{
			throw new NotImplementedException();
		}
	}
}
