using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CItyInfo.API.Models;

namespace CItyInfo.API.Service
{
	public class CitiesService:ICitiesService
	{
		private readonly List<City> _list;

		public CitiesService()
		{
			_list = new List<City>()
			{
				new City(){Id = 1,Name = "bareilly",State = "Uttar Pradesh",PointOfInterest = "Bareilly Ka Surma"},
				new City(){Id = 2,Name = "Bangaluru",State ="Karnataka",PointOfInterest = "Waterfalls"},
				new City(){Id = 3,Name = "Kharghar",State ="Maharastra",PointOfInterest = "bollywood Stars"},
				new City(){Id = 4,Name = "Jhashi",State = "Uttar Pradesh",PointOfInterest = "Jhashi Ki Rani"}
			};
		}

		public List<City> AllCities => _list;

		
	}
}
