using System;
using System.Collections.Generic;

namespace GenericSortedList
{

	class Program
	{
		
		static void Main(string[] args)
		{
			var _sortedList = GenericList.GetGenericList<int, Employee>();
			ShowMenu(_sortedList);
		}

		private static void ShowMenu(SortedList<int, Employee> _sortedList)
		{
			
			
			int _flow;
			do
			{
				Console.WriteLine("Please Enter The Operations \n");
				Console.WriteLine("----------------------");
				Console.WriteLine("1.To add\n");
				Console.WriteLine("2.To remove\n");
				Console.WriteLine("3.To see list\n");

				Console.WriteLine("0.To exit");
				_flow = int.Parse(Console.ReadLine());
				switch (_flow)
				{
					case 1:
						GenericList.AddObject(_sortedList);
						break;
					case 2:
						GenericList.RemoveObject(_sortedList);
						break;
					case 3:
						GenericList.ToSeeTheList(_sortedList);
						break;
					default:
						break;
				}

			} while (_flow != 0);
			Console.Clear();
			Console.WriteLine("Exited");


		}
		

		

		
	}
	
	
}
