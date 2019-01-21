using Microsoft.AspNetCore.Mvc;
using SolidWithBestPrqactices.Models;
using SolidWithBestPrqactices.Services;
using SolidWithBestPrqactices.ViewModels;

namespace SolidWithBestPrqactices.Controllers
{
	//[Route("[Controller]/[Action]")]
	public class HomeController:Controller
	{
		private IRestaurantData _restaurantData;
		private IGreater _greet;

		public HomeController(IRestaurantData restaurantData,IGreater greet)
		{
			_restaurantData = restaurantData;
			_greet = greet;
		}
		public IActionResult Index()
		{

			//var model = new Restaurant { Id = 1, Name = "Vishal" };
			var model = new HomeIndexViewModel();
			 model.Restaurants = _restaurantData.GetAll();
			model.CurrentMessage = _greet.GetGreet();
			return View(model);
		}
		public IActionResult Details(int id)
		{
			var model = _restaurantData.GetRestaurant(id);
			if(model==null)
			{
				return NotFound();//RedirectToAction(nameof(Index)); //NotFound();//redirect() //redirectionToAction()
			}
			return View(model);
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();	
		}

		[HttpPost]
		public IActionResult Create(RestaurantEditModel model)
		{
			if (ModelState.IsValid)
			{
				var newRestaurent = new Restaurant();
				newRestaurent.Name = model.Name;
				newRestaurent.Cuisine = model.Cusine;
				newRestaurent = _restaurantData.Add(newRestaurent);
				return View("Details", newRestaurent);
			}
			else
			{
				return View();
			}
		}
	}
}
