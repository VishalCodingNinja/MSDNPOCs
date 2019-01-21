using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SolidWithBestPrqactices.Services;

namespace SolidWithBestPrqactices.Pages
{
    public class GreetingModel : PageModel
    {
		private IGreater _greeter;

		public string CurrentGreeting { get; set; }
		public GreetingModel(IGreater greeter )
		{
			_greeter = greeter;
		}
		public void OnGet(string name)
		{
			CurrentGreeting = $"{name}: from razor pages { _greeter.GetGreet()}";
        }
    }
}