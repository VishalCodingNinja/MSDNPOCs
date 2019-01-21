using System;
using System.Collections.Generic;
using System.Text;

namespace LinqExamples
{
	public class Manufacturer
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Headquarters { get; set; }
		public int Year { get; set; }
	}
	public class CarStatistics
	{
		public CarStatistics()
		{
			Max = Int32.MinValue;
			Min = Int32.MaxValue;
		}
		
		public CarStatistics Accumulate(Car car)
		{
			Count += 1;
			Total += car.Combined;
			Max = Math.Max(Max, car.Combined);
			Min = Math.Min(Min, car.Combined);
			return this;
		}
		public int Max { get; set; }
		public int Min { get; set; }
		public double Average { get; set; }
		public int Total { get; set; }
		public int Count { get; set; }

		public CarStatistics Compute()
		{
			Average = Total / Count;
			return this;
		}
	}
}
