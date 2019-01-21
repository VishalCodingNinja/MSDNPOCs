using LinqExamples;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinqExamples
{
	public static class MyCustomLinq
	{
		public static IEnumerable<T> Filter<T>(this IEnumerable<T> source,Func<T,bool> predicate)
		{
			var result = new List<T>();

			foreach (var item in source)
			{
				if(predicate(item))
				{
					result.Add(item);
				}
			}
			return result;
		}
		public static IEnumerable<T> FilterDefered<T>(this IEnumerable<T> source, Func<T, bool> predicate)
		{
			var result = new List<T>();

			foreach (var item in source)
			{
				if (predicate(item))
				{
					yield return item;	//this keyword gives defered execution
				}
			}
			
		}
	}

}
namespace CustomProjection
{
	public static class CarExtensions
	{
		public static IEnumerable<Car> ToCar(this IEnumerable<string> source )
		{
			foreach (var line in source)
			{
				var columns = line.Split(",");
				yield return new Car
				{
					Year = int.Parse(columns[0]),
					Manufacturer = columns[1],
					Name = columns[2],
					Displacement = double.Parse(columns[3]),
					Cylinders = int.Parse(columns[4]),
					City = int.Parse(columns[5]),
					Highway = int.Parse(columns[6]),
					Combined = int.Parse(columns[7])

				};
			}
		}
	}
}