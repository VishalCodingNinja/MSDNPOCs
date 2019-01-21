using System;
using System.Linq;
using CItyInfo.API.Models;
using CItyInfo.API.Service;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CItyInfo.API.Controllers
{
	[Route("api/cities")]
    public class PointOfInterestController : Controller
    {
	    private readonly ICitiesService _service;
	    private ILogger _logger;

	    public PointOfInterestController(ICitiesService service,ILogger<UpdatingCityDTO> logger)
	    {
		    _service = service;
		    _logger = logger;
	    }

		public ICitiesService Service => _service;

		[HttpGet("{cityId}/GetPointOfInterest")]
		public IActionResult GetPointOfInterest(int id)
	    {
		    try
		    {
			    var city = Service.AllCities.FirstOrDefault(c => c.Id == id);
			    if (city == null)
			    {
				    _logger.LogInformation("City id not found");
				    throw new Exception();
				    // return NotFound();
			    }
			    return Ok(city);
			}
		    catch (Exception e)
		    {
			    _logger.LogCritical($"Exception while getting points");
			    return StatusCode(500, "A problem happned while handling your request");

		    }
		  
	    }

	    [HttpPatch("{cityId}/GetPointOfInterest")]
	    public IActionResult PartiallyUpdatePointOfInterest(int id,
		    [FromBody] JsonPatchDocument<UpdatingCityDTO> patchDoc)
	    {
		    if (patchDoc == null) return NotFound();
		    var city = Service.AllCities.FirstOrDefault(c => c.Id == id);
		    if (city == null) return NotFound();
		    var toBePatchCity = new UpdatingCityDTO()
		    {
			    Name = city.Name
		    };
			patchDoc.ApplyTo(toBePatchCity,ModelState);
		    if (!ModelState.IsValid) return BadRequest();
		    city.Name = toBePatchCity.Name;
		    city.State = toBePatchCity.State;
		    return NoContent();
	    }

	    [HttpDelete("{cityId}/DeletePointOfInterest")]
	    public IActionResult DeletePointOfInterest(int id)
	    {

		    var city = Service.AllCities.FirstOrDefault(e => e.Id == id);
		    if (city == null) return NotFound();
		    Service.AllCities.Remove(city);
		    return NoContent();
	    }
    }
	
}