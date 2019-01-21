﻿using Microsoft.EntityFrameworkCore;
using SolidWithBestPrqactices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidWithBestPrqactices.Data
{
	public class SolidDbContext:DbContext	
	{
		public SolidDbContext(DbContextOptions options):base(options)
		{

		}
		public  DbSet<Restaurant> Restaurants{ get; set; }

	}
}
