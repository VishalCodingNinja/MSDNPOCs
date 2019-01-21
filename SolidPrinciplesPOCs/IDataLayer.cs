using System;
using System.Collections.Generic;
using System.Linq;
namespace SolidPrinciplesPOCs
{
	interface IDataLayer
	{
	   CustomersContext GetUniqueInstance { get; set; }
	}
	public class DataLayer
	{
		private static readonly Lazy<CustomersContext> lazy = new Lazy<CustomersContext>(() => new CustomersContext(), true);
		private DataLayer()
		{

		}
		public static CustomersContext GetUniqueInstance
		{
			get
			{
				return lazy.Value;
			}
		}
		public static void RegisterUserWithMenu()
		{
			Console.WriteLine("Enter you details");
			Console.WriteLine("Enter your name");
			string name = Console.ReadLine();
			
			List<Item> items= ItemsYouWillPurchase(new List<Item>());
			using (var db=new CustomersContext())
			{
				db?.Customers.Add(new CustomerPOCO {Name="Sudha",TotalPurchase=1000 });
				db?.SaveChanges();
			} 
		}

		private static List<Item> ItemsYouWillPurchase(List<Item> _item)
		{
			List<Item> _listOfitems = new List<Item>() {
				new Item(){ ItemId=1,ItemName="Colgate",Price=98},
				new Item(){ ItemId=2,ItemName="bajradanti",Price=90},
				new Item(){ItemId=3,ItemName="Vikotermaric",Price=45},
				new Item(){ItemId=4,ItemName="dantkranti",Price=90}
			};
			int choice = 0;
			do
			{
				Console.Clear();
				Console.WriteLine("Add items in cart");
				Console.WriteLine("1. for Colgate");
				Console.WriteLine("2. for bajradanti");
				Console.WriteLine("3. for Vikotermaric");
				Console.WriteLine("4. for dantkranti");
				Console.WriteLine("0. to exit");
				choice = int.Parse(Console.ReadLine());
				switch (choice)
				{
					case 1:
						_item?.Add(_listOfitems.Where(e => e.ItemName == "Colgate").FirstOrDefault());
						break;
					case 2:
						_item?.Add(_listOfitems.Where(e => e.ItemName == "bajradanti").FirstOrDefault());
						break;
					case 3:
						_item?.Add(_listOfitems.Where(e => e.ItemName == "Vikotermaric").FirstOrDefault());
						break;
					case 4:
						_item?.Add(_listOfitems.Where(e => e.ItemName == "dantkranti").FirstOrDefault());
						break;
					default:
						break;
				}
			} while (choice!=0);
			return _item;
		}
	}
}
