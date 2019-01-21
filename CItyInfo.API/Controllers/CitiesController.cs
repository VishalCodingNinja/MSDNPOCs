using System.Linq;
using CItyInfo.API.Models;
using CItyInfo.API.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CItyInfo.API.Controllers
{
	[Route("api/cities")]
	public class CitiesController : Controller
	{
		private readonly ICitiesService _mockService;

		public CitiesController(ICitiesService mockService)
		{
			_mockService = mockService;
		}
		// GET: /<controller>/
		[HttpGet()]
		public IActionResult GetCities()
		{
			return Ok(_mockService.AllCities);
		}

		[HttpGet("{id?}",Name = "GetCity")]
		public IActionResult GetCity(int id)
		{
			var city = _mockService.AllCities.First(c => c.Id == id);
			if(city==null)
			{
				return NotFound();
			}

			return Ok(city);
		}

		[HttpPost("/CreateCity")]
		public IActionResult CreateCity([FromBody] City city)
		{
			if (city == null)
				return BadRequest();
			if (ModelState.IsValid)
			{
				var cityToBeSaved = new City()
				{
					Id = city.Id,
					Name = city.Name,
					State = city.State,
					PointOfInterest = city.PointOfInterest
				};
				_mockService.AllCities.Add(cityToBeSaved);
				return CreatedAtRoute("GetCity", new { id = city.Id }, city);
			}
			ModelState.AddModelError("Discription","Please enter valid value");
			return BadRequest(ModelState);
		}

		[HttpPut("/Update/{id}")]
		public IActionResult UpdateCity(int id, [FromBody] UpdatingCityDTO cityNew)
		{
			if (cityNew == null) return BadRequest();
			if (!ModelState.IsValid) return BadRequest();
			var OldCity = _mockService.AllCities.FirstOrDefault(c => c.Id == id);
			if (OldCity == null) return NotFound();
			return null;
		}
	}
}
