using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace SolidPrinciplesPOCs
{
	class UI
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Welcome to Euromonitor Internationals Signup");
			new ServiceLayer().RegisterUser();
		}
	}
	
	
	interface IDiscount//base can replace the derived class
	{
		 double GetDiscount(double total);
	}
	interface IDatabase
	{
		void AddItemToCartAndDataBase(string item);
	}

	internal interface IDatabaseV1:IDatabase
	{
		void Read();
	}
	
	

}
