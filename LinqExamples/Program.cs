using CustomProjection;
using LinqExamples.Linq;
using System;
using System.Collections;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Xml.Linq;
namespace LinqExamples
{
	class Program
	{
		static Employee[] developers = new Employee[]
			{
				new Employee{Name="Vishal Singh",Id=1},
				new Employee{Name="Sumit Saran",Id=2}
			};
		static List<Movie> movies = new List<Movie>
			{
				new Movie{Title="Dil wale dulaniya le jayenge",Rating=9.9f,Year=1994},
				new Movie{Title="Gajni",Rating=9.7f,Year=2008},
				new Movie{Title="Robot",Rating=9.6f,Year=2009},
				new Movie{Title="Krissh",Rating=9.5f,Year=2006}
			};
		static void Main(string[] args)
		{
			//ReadingDirectiesFromWindowsFolder();
		    //HowLinqOperatorsWork();
			//LinqWithLamdaExpressions();
			//FilterWithLinqOperators();
			//DeferedExecutionPOCs();
			//StremingOperators();
			//Filtering_Sorting_Projection();
			//JoiningGroupingAggregating();
			XmlOperations();
			
			
		}

		

		

		private static void XmlOperations()
		{
			var records= ProcesCarsFileWithoutSelect("fuel.csv");
			BasicXml(records);
			MoreAttributeOrientedXmlWrite(records);
			ReadAndQueryXml();
			
		}

		private static void ReadAndQueryXml()
		{
			var document = XDocument.Load("fuelAttributeOriented.xml");
			var query = from element in document.Element("Cars").Elements("Car")//can use Decedents also
						where element.Attribute("Manufacturer")?.Value == "BMW"//if Manufacrurer does not exist then it will return null and null==BMW will return false
						select element.Attribute("Name").Value;

			foreach (var item in query)
			{
				Console.WriteLine(item);
			}
		}

		private static void MoreAttributeOrientedXmlWrite(List<Car> records)
		{
			////linq to xml api constructions
			//var document = new XDocument();
			//var cars = new XElement("Cars");
			//foreach (var record in records)
			//{
			//	//var car = new XElement("Car");
			//	//var name = new XAttribute("Name", record.Name);//linq take it and convert it into string and put it in attributes
			//	//var combined = new XAttribute("Combined", record.Combined);
			//	//car.Add(name);
			//	//car.Add(combined);
			//	//cars.Add(car);

			//	//another approach

			//	var car = new XElement("Car",
			//		new XAttribute("Name", record.Name),
			//		new XAttribute("Combined", record.Combined),
			//		new XAttribute("Manufacturer",record.Manufacturer)
			//		);//here it is doing mapping or projection so we ca do it another way
			//	cars.Add(car);
			//}
			//document.Add(cars);
			//document.Save("fuelAttributeOriented.xml");


			//third approach

			//var document = new XDocument();
			//var cars = new XElement("Cars");
			//var elements = from record in records
			//			   select new XElement("Car", new XAttribute("Name", record.Name),
			//										 new XAttribute("Combined", record.Combined),
			//										 new XAttribute("Manufacturer", record.Manufacturer));
			//document.Add(cars);
			//document.Save("fuelAttributeOriented.xml");


			//forth approach
			var document = new XDocument();
			var cars = new XElement("Cars",
			 from record in records
			 select new XElement("Car", new XAttribute("Name", record.Name),
										new XAttribute("Combined", record.Combined),
										new XAttribute("Manufacturer", record.Manufacturer)));
			document.Add(cars);
			document.Save("fuelAttributeOriented.xml");

		}

		private static void BasicXml(List<Car> records)
		{
			var document = new XDocument();
			var cars = new XElement("Cars");
			foreach (var record in records)
			{
				var car = new XElement("Car");
				var name = new XElement("Name", record.Name);
				var combined = new XElement("Combined", record.Combined);
				car.Add(name);
				car.Add(combined);
				cars.Add(car);
			}
			document.Add(cars);
			document.Save("fuel.xml");//can be stream ,file
		}

		private static void JoiningGroupingAggregating()
		{
			var cars = ProcesCarsFileWithoutSelect("fuel.csv");
			var manufacturers = ProcesManufacturersFile("manufacturers.csv");

			//SimpleJoin(cars,manufacturers);
			//JoinOnTwoPiecesOfInformation(cars, manufacturers);
			//GroupingSimpleData(cars, manufacturers);
			GroupingAndJoiningAggregation(cars, manufacturers);
		}

		private static void GroupingAndJoiningAggregation(List<Car> cars, List<Manufacturer> manufacturers)
		{
			//query syntax
			var query = from manufacturer in manufacturers
						join car in cars on manufacturer.Name equals car.Manufacturer
						 into carGroup
						orderby manufacturer.Name
						select new
						{
							Manufacturer = manufacturer,
							Cars = carGroup
						} into result
						group result by result.Manufacturer.Headquarters;


			var query2 = manufacturers.GroupJoin(cars, m => m.Name,
				c => c.Manufacturer,
				(m, g) =>
					new
					{
						Manufacturer = m,
						Cars = g//the sedcond parameter is grouping
					}).GroupBy(m => m.Manufacturer.Headquarters);
			var query3 = from car in cars
						 group car by car.Manufacturer into carGroup
						 select
						 new
						 {
							 Name = carGroup.Key,
							 Max = carGroup.Max(c => c.Combined)
							 ,
							 Min = carGroup.Min(c => c.Combined),
							 Avg = carGroup.Average(c => c.Combined)
						 } into result
						 orderby result.Max descending
						 select result;

			var query4 = cars.GroupBy(c => c.Manufacturer)
				.Select(g =>
				{
					var results = g.Aggregate(new CarStatistics(),
						(acc, c) => acc.Accumulate(c),
							acc => acc.Compute());
					return new
					{
						Name = g.Key,
						Avg = results.Average,
						Min = results.Min,
						Max = results.Max
					};

				})
				.OrderByDescending(e => e.Max);

			foreach (var item in query4)
			{
				Console.WriteLine($"{item.Name}");
				Console.WriteLine($"\t{item.Max}");
				Console.WriteLine($"\t{item.Min}");
				Console.WriteLine($"\t{item.Avg}");
			}

			//foreach (var item in query3)
			//{
			//	Console.WriteLine($"{item.Name}");
			//	Console.WriteLine($"\t{item.Max}");
			//	Console.WriteLine($"\t{item.Min}");
			//	Console.WriteLine($"\t{item.Avg}");
			//}
			
			//foreach (var group in query2)
			//{
			//	Console.WriteLine($"{group.Key}");
			//	foreach (var car in group.SelectMany(g => g.Cars)
			//							 .OrderByDescending(c => c.Combined)
			//							 .Take(3))
			//	{
			//		Console.WriteLine($"\t{car.Name}:{car.Combined}");
			//	}
			//}
		}

		private static void GroupingSimpleData(List<Car> cars, List<Manufacturer> manufacturers)
		{
			//var query = from car in cars
			//			group car by car.Manufacturer;//after group we can not operate becase we lost car as it grouped 
			//                                          //so solve this callenge we will put this group into some variable


			//Query syntax
			//var query = from car in cars
			//			group car by car.Manufacturer into groupedBucket
			//			orderby groupedBucket.Key
			//			select groupedBucket;

			//method syntax
			var query = cars.GroupBy(c => c.Manufacturer.ToUpper())
							.OrderBy(g => g.Key);

			foreach (var GroupBucket in query)
			{

				Console.WriteLine($"{GroupBucket.Key}");

				foreach (var item in GroupBucket.OrderByDescending(c => c.Combined).Take(10))
				{

					Console.WriteLine($"\t {item.Name}   : {item.Combined}");
				}
			}
		}

		private static void JoinOnTwoPiecesOfInformation(List<Car> cars, List<Manufacturer> manufacturers)
		{
			//it can easily happen on anonymous types

			//Query Syntax:
						var query = from car in cars
						join manufacture in manufacturers
							on new { car.Manufacturer, car.Year } 
							equals
							new { Manufacturer=manufacture.Name, manufacture.Year }
						orderby car.Combined ascending, car.Name
						select new
						{
							manufacture.Headquarters,
							car.Name,
							car.Combined
						};

			//query syntax:
			var query2 = cars.Join(manufacturers,
				c => new { c.Manufacturer, c.Year },
				m => new { Manufacturer = m.Name, m.Year },
				(c, m) => new
				{
					m.Headquarters,
					c.Name,
					c.Combined//i can get object also here
							  //Car = c,
							  //Manufacturer = manufacturers
				});
			foreach (var joinValue in query2.Take(10))
			{
				Console.WriteLine($"Manufacturer:{joinValue.Headquarters}  ,car name:{joinValue.Name}");
			}
		}

		private static void SimpleJoin(List<Car> cars, List<Manufacturer> manufacturers)
		{
			//Query Syntax:
			//var query = from car in cars
			//			join manufacture in manufacturers on car.Manufacturer equals manufacture.Name
			//			orderby car.Combined ascending, car.Name
			//			select new
			//			{
			//				manufacture.Headquarters,
			//				car.Name,
			//				car.Combined
			//			};

			//method syntax
			//always make inner sequence samller then outer sequence ex:manufacturers
			var query = cars.Join(manufacturers, c => c.Manufacturer, m => m.Name, (c, m) => new
			{
				//m.Headquarters,
				//c.Name,
				//c.Combined//i can get object also here
				Car = c,
				Manufacturer = manufacturers
			})
			//.OrderByDescending(c => c.Combined)
			//.ThenBy(c => c.Name);
			.OrderByDescending(c => c.Car.Combined)
			.ThenBy(c => c.Car.Name);

			foreach (var item in query.Take(10))
			{
				Console.WriteLine($"manufacturer {item.Car.Manufacturer} ,Car name {item.Car.Name}");
			}

			//foreach (var joinValue in query.Take(10))
			//{
			//	Console.WriteLine($"Manufacturer:{joinValue.Headquarters}  ,car name:{joinValue.Name} ,Combined {joinValue.Combined}");
			//}
		}

		private static List<Manufacturer> ProcesManufacturersFile(string path)
		{
			var query = File.ReadAllLines(path)
					  .Where(l => l.Length > 1)
					  .Select(l =>
					  {
						  var columns = l.Split(",");
						  return new Manufacturer
						  {
							  Name = columns[0],
							  Headquarters = columns[1],
							  Year = int.Parse(columns[2])
						  };

					  });
			return query.ToList();
		}

		private static void Filtering_Sorting_Projection()
		{
			FilteringAndSorting();
			Projection();
		}

		private static void FilteringAndSorting()
		{
			var cars = ProcesFile("fuel.csv");
			//method() syntax:
			//var topThreeCarsFuelEficient = cars.OrderByDescending(e => e.Combined)
			//								.ThenBy(e=>e.Name);
			////to resort we have to operators..thenBy(),thenByDescending()
			///

			//query syntax:
			var topThreeCarsFuelEficient = from car in cars
										   where car.Manufacturer == "BMW" && car.Year == 2016
										   orderby car.Combined descending, car.Name ascending//ascending is default
										   select car;

			//foreach (var car in topThreeCarsFuelEficient.Take(10))
			//{
			//	Console.WriteLine(car.Name+"    "+car.Combined);
			//}

			var topCarInBMW = cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
								  .OrderByDescending(e => e.Combined)
								  .ThenBy(c => c.Name)
								  .Select(c => c)
								  //.First();//now it will return only one car ..exception when no element present so good to use firstordefault
								  .FirstOrDefault();//then it wont throw any exception

			if (topCarInBMW != null)
			{
				Console.WriteLine(topCarInBMW.Name);
			}

			//not a efficient query because at the end we are filtering it would be good if we already check this at start
			//var topCarInBMW1 = cars
			//					  .OrderByDescending(e => e.Combined)
			//					  .ThenBy(c => c.Name)
			//					  .Select(c => c)
			//					  .First(c => c.Manufacturer == "BMW" && c.Year == 2016);


			//Qunatifying operators

			//var isThere = cars.Any(e=>e.Manufacturer=="BMW");
			var isThere = cars.All(e => e.Manufacturer == "BMW");
			Console.WriteLine(isThere);
		}

		private static void Projection()
		{
			var cars = ProcesCarsFileWithoutSelect("fuel.csv");
			var query = from car in cars
						where car.Manufacturer == "BMW" && car.Year == 2016
						orderby car.Combined descending, car.Name ascending
						select new
						{
							car.Manufacturer,
							car.Name,
							car.Combined
						};
			//foreach (var item in query)
			//{
			//	Console.WriteLine($"Manufacturer: {item.Manufacturer} ,Name: {item.Name} ,Combined :{item.Combined}");
			//}

			var result = cars.Select(c => new { c.Manufacturer, c.Name, c.Combined });


			//selectMany:for sequence of sequence

			var selectMany = cars.SelectMany(c => c.Name)//it will drill into one level
								 .OrderBy(c => c) ;
				foreach (var item in selectMany)
			{
				Console.WriteLine(item);
			}
		}

		private static List<Car> ProcesCarsFileWithoutSelect(string path)
		{
			var query = File.ReadAllLines(path)
				.Skip(1)
				.Where(l => l.Length > 1)
				.ToCar();//extension method for parsing the string to car obejct for every string it will be called

			return query.ToList();
		}

		private static List<Car> ProcesFile(string path)
		{
			//return File.ReadAllLines(path)
			//	.Skip(1)
			//	.Where(e => e.Length > 1)
			//	.Select(Car.ParseFromCSV)//now Transform method will invoke for every row/line
			//	.ToList();//convert it into list ..imidiate execution 

			var query = from line in File.ReadAllLines(path).Skip(1)
						where line.Length > 1
						select Car.ParseFromCSV(line);
			return query.ToList();

		}
		
		private static void StremingOperators()
		{
			//streming operators and non streming operators:

			//where is streming operator:streaming operator only read through source data
			//like sequence of movies,where() method is streaming operator will search the result 
			//and print it

			//orderbydesending() method is non streaming operaotor, it will read all the data and then 
			//it will print the result..just like the ToList() ,but even then it is defered execution
			//once the orderby() start the execution it will go through all the list..even 
			//then it will be like defered execution
			//orderby() method will look in all the collection to it ois good to 
			//filter the data before the orderin
			var _query = movies.Where(m => m.Year > 2000).OrderByDescending(e=>e.Rating);
			Console.WriteLine(_query.Count());
			foreach (var item in _query)
			{
				Console.WriteLine(item.Title);
			}

		}

		private static void DeferedExecutionPOCs()
		{
			//DeferedExecutionWithCustomOperator();
			PitfallsOfDeferedExecution();
		}

		private static void PitfallsOfDeferedExecution()
		{
			CountProblemInDeferedExecution();
			
		}

		private static void CountProblemInDeferedExecution()
		{
			//if we are having the Count(),then we use where operator..it will increase the amount of work
			//becase count() execute imidiately and where is defered exection,so query execute twice..
			//so we need to turn off defered execution..that is imidiately execute the query and put into concreet result
			//quite of few operators turn off derered execution ex:ToArray(),ToList() ,ToDictionary();
			//by using Tolist() operator we already execute the query now we dont need to execute it again
			var _query = movies.FilterDefered(m => m.Year > 2000).ToList();
			Console.WriteLine(_query.Count());
			foreach (var item in _query)
			{
				Console.WriteLine(item.Title);
			}

		}

		

		private static void DeferedExecutionWithCustomOperator()
		{
			//defered execution is given by yeild operator..linq as lazy as possible
			var _query = movies.FilterDefered(m => m.Year > 2000)//not it wont execute here it will execute when we try to pull out something from ienumerable
							   .Take(1);//using take here it will take only first and would not take more element

			IEnumerator<Movie> _inumerator = _query.GetEnumerator();

			while (_inumerator.MoveNext())//here the query start executions
			{
				Console.WriteLine(_inumerator.Current.Title);
			}
		}

		private static void FilterWithLinqOperators()
		{
		//	BuiltOperatorWhere();
			//CustomOperatorFilter();
			
			
		}

		private static void CustomOperatorFilter()
		{
			var _query = movies.Filter(m => m.Year > 2000);//it will executed here only
			foreach (var item in _query)
			{
				Console.WriteLine(item.Title);
			}
			//note:our custom filter operator will call each time the getter property of year in mmovie
			//it will filer all movies and then print at the end
		}

		private static void BuiltOperatorWhere()
		{
			
			var _query = movies.Where(m => m.Year > 2000);//it will not execute here 
			foreach (var item in _query)
			{
				Console.WriteLine(item.Title);
			}
			//note:it will filter then print..again filter again print
		}

		private static void LinqWithLamdaExpressions()
		{
			//LinqOperatorsWithNamedExpressions();
			LinqOperatorsWithAnonymousMethods();
			LinqOPeratorsWithLamdaExpressions();
		}

		private static void LinqOPeratorsWithLamdaExpressions()
		{
			//Method syntax
			IEnumerable<Employee> _filteredList = developers.Where(e => e.Name.Length>3).OrderBy(e=>e.Name);//no need of select there

			//query syntax
			IEnumerable<Employee> _filteredList2 = from employee in developers
												   where employee.Name.Length > 3
												   orderby employee.Name
												   select employee;

			foreach (var item in _filteredList2)
			{
				Console.WriteLine(item.Name);
			}

			//note:behind the sceen c# compiler convert the keywords into the 
			//extension method calls and map the lamda expression
			//count(),take(),skip() operators not present in the query syntax
			
		}

		private static void LinqOperatorsWithAnonymousMethods()//anonymous method c#
		{
			IEnumerable<Employee> _filteredList = developers.Where(delegate (Employee e) { return e.Name.Contains("V"); });
			//it was not convinent for c# developers so C# guys introduce lamda expressions
			foreach (var item in _filteredList)
			{
				Console.WriteLine(item.Name);
			}
		}

		private static void LinqOperatorsWithNamedExpressions()
		{
			IEnumerable<Employee> _filteredList = developers.Where(StartWithLetterV);
			foreach (var item in _filteredList)
			{
				Console.WriteLine(item.Name);
			}
		}

		private static bool StartWithLetterV(Employee arg)
		{
			return arg.Name.Contains("V");
		}

		private static void HowLinqOperatorsWork()
		{
			
			List<Employee> sales = new List<Employee>
			{
				new Employee{Id=3,Name="Mantu"},
				new Employee{Id=4,Name="Raghav"}
			};
			foreach (var developer in developers)
			{
				Console.WriteLine(developer.Name);	
			}
			IEnumerator<Employee> _inumerator = sales.GetEnumerator();
			while (_inumerator.MoveNext())
			{
				Console.WriteLine(_inumerator.Current);
				
			}

			//note:so all of the method ,operator of linq can work 
			//on IEnumerator and all these methods are extension methods
			//extension methods follow open close principle 


			//Console.WriteLine(developers.Count());//extension method in LinqExamples.Linq
			//note:thats y system.linq namespace is important
			//like this count()  extension method we have created in linq all the methods 
			//are extension methods
		}

		private static void ReadingDirectiesFromWindowsFolder()
		{
			string path = @"C:\Windows";
			ShowLargeFilesWithoutLinq(path);
			ShowLargeFilesWithLinq(path);
		}

		private static void ShowLargeFilesWithLinq(string path)
		{
			//query Syntax
			//var _query = from file in new DirectoryInfo(path).GetFiles()
			//			 orderby file.Length descending
			//			 select file;

			//method syntax
			var _query = new DirectoryInfo(path).GetFiles()
				.OrderByDescending(file => file.Length)
				.Take(5);
			foreach (var file in _query.Take(5))
			{
				Console.WriteLine($"{file.Name} {file.Length}");
			}

			//so using linq we find that we write less code 
			//compile time checks..no need to write a new class
			//easy to use
		}

		private static void ShowLargeFilesWithoutLinq(string path)
		{
			DirectoryInfo _directory = new DirectoryInfo(path);
			FileInfo[] _files = _directory.GetFiles();

			//to sort the file we need the Array class
			//before linq we need to use the comparer to compare the file 
			Array.Sort(_files, new FileInfoComparer());
			//foreach (var item in _files)
			//{
			//	Console.WriteLine($"{item.Name}   :    {item.Length} ");
			//}

			//if i want only top five files then
			for (int i = 0; i < 5; i++)
			{
				FileInfo file = _files[i];
				Console.WriteLine($"{file.Name} {file.Length}");
			}
		}
	}
	public class FileInfoComparer : IComparer<FileInfo>
	{
		public int Compare(FileInfo x, FileInfo y)
		{
			return y.Length.CompareTo(x.Length);
		}
	}

	
}
