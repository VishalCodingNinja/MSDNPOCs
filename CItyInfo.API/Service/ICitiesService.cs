using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CItyInfo.API.Models;

namespace CItyInfo.API.Service
{
	public interface ICitiesService
	{
	 List<City> AllCities { get; }
	}
}
