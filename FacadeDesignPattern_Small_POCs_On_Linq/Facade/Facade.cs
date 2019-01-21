using ConsoleApp1.Classes;
using ConsoleApp1.Facade;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Facade_Folder
{
	public class FacadeServiceLayer:IFacadeServiceLayer
	{
		static private List<IEmployee> _employeesList = new List<IEmployee>() {
		new SoftwareEngineer{ Age=21,Income=200000,Name="Vishal",FavoriteCafe="CaskaCafe"},
		new SoftwareEngineer{Age=22,Income=200000,Name="Prasobh",FavoriteCafe="BlueMango"},
		new ProjectManager{Age=22,Income=30000,Name="Sumit",FavoriteCafe="Priyadarshini"},
		new ProjectManager{Age=28,Income=40000,Name="Rishal",FavoriteCafe="Gordenly"},
		new HR{Age=25,Income=20000,Name="jasmine",FavoriteCafe="Los Pareira"},
		new SoftwareEngineer{Age=29,Income=30000,Name="Ankur",FavoriteCafe="CaskaCafe"}
		};
		
		public void ShowEmployees()
		{
			foreach (var item in _employeesList)
			{
				Console.WriteLine(item.Name);
			}
		}

		public string GetAgeGroupOfEmployees()
		{
			int StartAge = _employeesList
							.Min(e => e.Age);
			int EndAge = _employeesList.Max(e=>e.Age);
			return "Age Group from " + StartAge + "   To " + EndAge;
		}

		public string GetIncomeRange()
		{
			var StartIncome = _employeesList.Min(e=>e.Income);
			var EndIncome = _employeesList.Max(e=>e.Income);
			return "Age Group from " + StartIncome + "   To " + EndIncome;
		}
		public string GetFavoriteCafeInTheCity()
		{
			var query = (from l in _employeesList
						group l by l.FavoriteCafe into gr
						orderby gr.Count() descending
						select gr.Key).First();
			return "Favrite Cafe in the City is :"+query;
		}
	}

	class LazySingleton
	{
		
		private LazySingleton()
		{

		}
		public static IFacadeServiceLayer FacadeInstance
		{
			get { return Nested._instance; }
		}
		private class Nested
		{
			static Nested()
			{ }
			internal static readonly IFacadeServiceLayer _instance = new FacadeServiceLayer();
		}
	}
}
