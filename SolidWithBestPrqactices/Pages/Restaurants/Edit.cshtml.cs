using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SolidWithBestPrqactices.Models;
using SolidWithBestPrqactices.Services;

namespace SolidWithBestPrqactices.Pages.Restaurants
{
	public class EditModel : PageModel
	{
		private IRestaurantData _restaurantData;

		[BindProperty]//when form will arrive it will merge here 
		public Restaurant Restaurant { get; set; }
		public EditModel(IRestaurantData restaurantData)
		{
			_restaurantData = restaurantData;
		}
        public IActionResult OnGet(int id)
        {
			Restaurant = _restaurantData.GetRestaurant(id);
			if(Restaurant==null)
			{
				return RedirectToAction("Index", "Home");
			}
			return Page();//return view associated with this model
        }
		public IActionResult OnPost(int id)
		{
			if(ModelState.IsValid)
			{
				_restaurantData.Update(Restaurant);
				return RedirectToAction("Details", "Home", new {id=Restaurant.Id });
			}
			return Page();
			//Restaurant = _restaurantData.GetRestaurant(id);
			//if(Restaurant==null)
			//{
			//	return RedirectToAction("Index", "Home");
			//}
			//return Page();
		}
    }
}