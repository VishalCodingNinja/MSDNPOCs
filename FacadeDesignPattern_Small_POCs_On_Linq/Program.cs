using System;
using ConsoleApp1.Facade;
using ConsoleApp1.Facade_Folder;
namespace ConsoleApp1
{

	public class Surveyor//client
	{
		static void Main(string[] args)
		{
			
			Console.WriteLine("Survey of the company Employees");
			GetFormation();
			IFacadeServiceLayer facade = LazySingleton.FacadeInstance;//get instance of subsystem
			Console.WriteLine(facade.GetAgeGroupOfEmployees());
			Console.WriteLine(facade.GetFavoriteCafeInTheCity());
			Console.WriteLine(facade.GetIncomeRange());
			GetFormation();

		}

		private static void GetFormation()
		{
			Console.WriteLine("-----------------------------------------");
		}
	}
}
