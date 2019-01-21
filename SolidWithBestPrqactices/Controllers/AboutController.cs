using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidWithBestPrqactices.Controllers
{
	//[Route("[Controller]")]
	[Route("EuromonitorInternational/[Controller]/[Action]")]//much more better
	public class AboutController
	{
		//[Route("[Action]")]
		public string Phone()
		{
			return "9458425389";
		}
		//[Route("Address")]
		//[Route("[Action]")]
		public string Address()
		{
			return "Bareilly,Uttar Pradesh";
		}
	}
}
