using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSortedList
{

	public class GenericList
	{
		static int _count = 0;
		public static SortedList<TKey, TValue> GetGenericList<TKey, TValue>() where TKey : struct where TValue : class
		{
			var _instance = new SortedList<TKey, TValue>();
			return _instance;

		}
		public static void ToSeeTheList(SortedList<int, Employee> sortedlist)
		{

			

			var _inumerator = sortedlist.GetEnumerator();
			bool value = _inumerator.MoveNext();
			while (value)
			{
				Console.WriteLine("index :" + _inumerator.Current.Key + " Employee details are:" + _inumerator.Current.Value);
				value = _inumerator.MoveNext();
			}
			Console.WriteLine(sortedlist.Count);
		}
		public static void RemoveObject(SortedList<int, Employee> sortedlist)
		{
			foreach (var item in sortedlist)
			{
				Console.WriteLine("index :" + item.Key + " Employee details are:" + item.Value);
			}
			Console.WriteLine("Enter the index of employee you want to delete");
			int i = int.Parse(Console.ReadLine());
			bool _check = sortedlist.Remove(i);
			if (_check)
				Console.WriteLine("Employee remove sucessfully");
			else
				Console.WriteLine("Enter valid index");
		}
		public static void AddObject(SortedList<int, Employee> sortedlist)
		{
			Console.WriteLine("Enter the name of employee");
			string name = Console.ReadLine();
			Console.WriteLine("Enter the address of the employee");
			string address = Console.ReadLine();
			
			sortedlist.Add(_count, new Employee(name, address));

			var _list = sortedlist.Values.ToList();
			_list.Sort();

			foreach (var item in _list)
			{
				Console.WriteLine(item.Name+"           "+item.Address);
			}





			//var orderByName = sortedlist.OrderBy(v => v.Value.Name);
			//Console.Clear();
			//Console.WriteLine("printing");
			
			//var _inumerator = orderByName.GetEnumerator();
			//bool value = _inumerator.MoveNext();
			//sortedlist.Clear();
			//int i = 0;
			//while (value)
			//{
			//	sortedlist.Add(i, new Employee<string>(_inumerator.Current.Value.Name, _inumerator.Current.Value.Name));

			//	//Console.WriteLine("index :" + _inumerator.Current.Key + " Employee details are:" + _inumerator.Current.Value);
			//	value = _inumerator.MoveNext();
			//	i++;
			//}

			//foreach (var item in sortedlist)
			//{
			//	Console.WriteLine(item.Value);
			//}


			Console.WriteLine("Employee Added Sucessfully");
			_count++;

		}
	}
}
