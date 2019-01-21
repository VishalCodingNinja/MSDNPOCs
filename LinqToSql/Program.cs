using LinqToSql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace LinqToSql
{
	class Program
	{
		static string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["LinqToSql.Properties.Settings.LinqDataBaseConnectionString"].ToString();

		static DataClasses1DataContext db = new DataClasses1DataContext(connectString);

		static void Main(string[] args)
		{
			//SaveCarsIntoDataBase();
			//SaveManufactureresIntoDatabase();
			//SelectingTopThreeCars();
			//SelectingTopCarInBMW();
			
		}

		

		private static void SelectingTopCarInBMW()
		{
			var topCarInBMW = db.Cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
								  .OrderByDescending(e => e.Combined)
								  .ThenBy(c => c.Name)
								  .Select(c => c)
								  //.First();//now it will return only one car ..exception when no element present so good to use firstordefault
								  .FirstOrDefault();//then it wont throw any exception

			if (topCarInBMW != null)
			{
				Console.WriteLine(topCarInBMW.Name);
			}


		}

		private static void SelectingTopThreeCars()
		{
			var topThreeCarsFuelEficient = (from car in db.Cars
										   where car.Manufacturer == "BMW" && car.Year == 2016
										   orderby car.Combined descending, car.Name ascending//ascending is default
										   select car);
			
			
			foreach (var item in topThreeCarsFuelEficient)
			{
				
				//Console.WriteLine(item.Name +"      "+item.Combined);

			}

			



		}

		private static void SaveManufactureresIntoDatabase()
		{
			var records = ProcesManufacturersFile("manufacturers.csv");

			foreach (var item in records)
			{
				Manufacturer manufacturer = new Manufacturer();
				manufacturer.Headquarters = item.Headquarters;
				manufacturer.Name = item.Name;
				manufacturer.Year = item.Year;
				db.Manufacturers.InsertOnSubmit(manufacturer);
				db.SubmitChanges();

			}
		}
		private static List<Manufacturer> ProcesManufacturersFile(string path)
		{
			var query = File.ReadAllLines(path)
					  .Where(l => l.Length > 1)
					  .Select(l =>
					  {
						  var columns = l.Split(new string[] { ","}, StringSplitOptions.None);
						  return new Manufacturer
						  {
							  Name = columns[0],
							  Headquarters = columns[1],
							  Year = int.Parse(columns[2])
						  };

					  });
			return query.ToList();
		}


		private static void SaveCarsIntoDataBase()
		{
			var records = ProcesFile("fuel.csv");


			
			
			foreach (var item in records)
			{
				Car _car = new Car();

				_car.Name = item.Name;
				_car.Highway = item.Highway;
				_car.Manufacturer = item.Manufacturer;
				_car.Year = item.Year;
				_car.City = item.City;
				_car.Combined = item.Combined;
				_car.Displacement = item.Displacement;
				_car.Cylinders = item.Cylinders;
				db.Cars.InsertOnSubmit(_car);
				db.SubmitChanges();

			}
		}
	
		private static List<Car> ProcesFile(string path)
		{
			
			var query = (from line in File.ReadAllLines(path).Skip(1)
						where line.Length > 1
						select Car.ParseFromCSV(line)).ToList();
			return query;

		}

	}
	
}


