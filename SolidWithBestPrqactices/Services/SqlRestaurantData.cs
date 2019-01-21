using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SolidWithBestPrqactices.Data;
using SolidWithBestPrqactices.Models;

namespace SolidWithBestPrqactices.Services
{
	public class SqlRestaurantData : IRestaurantData
	{
		private SolidDbContext _context;

		public SqlRestaurantData(SolidDbContext context)
		{
			_context = context;
		}
		public Restaurant Add(Restaurant newRestaurent)
		{
			_context.Restaurants.Add(newRestaurent);
			_context.SaveChanges();
			return newRestaurent;	 
		}

		public IEnumerable<Restaurant> GetAll()
		{
			return _context.Restaurants.OrderBy(r => r.Name);
		}

		public Restaurant GetRestaurant(int id)
		{
			return _context.Restaurants.FirstOrDefault(e => e.Id == id);
		}

		public Restaurant Update(Restaurant restaurant)
		{
			_context.Attach(restaurant).State = EntityState.Modified;
			_context.SaveChanges();
			return restaurant;
		}
	}
}
