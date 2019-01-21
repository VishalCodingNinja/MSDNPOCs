using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsExample
{
	class Program
	{
		static void Main(string[] args)
		{
			//Array CLass
			
			//System.Array all static methods
			//IndexOf()
			//string[] colorOption = { "Red", "green", "yellow", "White" };
			////Array.Sort(); static methods
			//var brownIndex = Array.IndexOf(colorOption,"Red");

			////instance methods...
			//colorOption.SetValue("Magenta", 3);
			//foreach(var value in colorOption)
			//{
			//	Console.WriteLine(value);
			//}

			//Q1.when is it appropriate to use an array?
			//Ans.when working with a list whose length is defined at design time..

			//Q2.diff betwn foreach and for ?
			//Ans.syntax difference and in for loop the iterated elements are updatable..



			//Generics:
			//c# is strongly type language so when give generic class we define the type at 
			//the time of object creation 
			//ex: var operationResult=new OperationResult<bool>(sucess,orderText);
			var random = new Random();
			var variable = random.Next(1, 10);
			
			bool sucess = false;
			var orderTest = "unsucessfull";
			if (variable > 5)
			{ 
				sucess = true;
				orderTest = "sucessfull";
				OperationResult<bool,string> operationResult = new OperationResult<bool,string>(sucess, orderTest);//this instance of OperationResult class is of bool time

			}
			else
			{
				string sucess_Status = "false";
				bool order_Text_Status = false;

				OperationResult<string,bool> operationResult = new OperationResult<string,bool>(sucess_Status, order_Text_Status);//this instance of OperationResult class is of bool time

			}
			//use the generics to build reusable type neutral methods..

			//use T as the type paramter for methods with one type
			//paramter

			//prefix descriptive type paramter names with T
			//public TReturn RetValue<TReturn,TParameter>(string sql,TParamter sqlParameter)

			//define the type parameter on the method signature.

			//limit the type to certain type..
			//generic constraint 
			//where T:struct     //it is for values types
			//where T:class      //for Reference type
			//where T:new()      //type with paramterless constructor,default constructors.
			//where T:Vendor     //Be or derive from Vendor 
			//where T:IVendor    //Be or implement the IVendor interface



			//GenericConstraints();










			//public class OperationResult<T> where T:struct 

			//public T Populate<T>(string sql) where T:class,new()
			//{
			//	T _instance = new T();
			//	return _instance;
			//}

			//public T RetriveValue<T,V>(string sql,V parameter) 
			//													where T:struct
			//													where V : struct
			//{

			//}

			//now it we need to use the value type and reference type then we need to 
			//overload those methods.


			//what are generics ?
			//a technique for defining a data type using a variable

			//what are the benifit of generics ?
			//with generics we can write generalized reusablle code that is type safe yet works 
			//with any data type.

			//what is a generic type parameter?
			//a plcaeholder for the specific type 
			//ex: public class OperationResult<T>

			//where is a generic type paramter defined?
			//as part of a class signature
			//ex:public class OperationResult<T>
			//or as part of a method signature
			//ex:public T RetrieveValue<T>(string sql,T defaultValue)

			//how to define the actual type for T?
			//while creatig instance of the class..
			//public class OperationResult<T>
			//var operationResult=new OperationResult<decimal>();
			//var operationResult=new OperationResult<bool>();




			//generic list
			//GenericList();
			//GenericDictionary();
			//GenericCollectionInterfaces();
			//LinqExamples();
			ADO_NET_POCs();

		}

		private static void ADO_NET_POCs()
		{
			//what is ADO.NET?
			//ADO.NET can be considered as a collction of class libraries(framework)
			//for interacting with any database or XML documents from any .NET
			//application developed using any language that targets the .NET
			//ex:web applicaiton want to intect to the database then we need ADP.net(ActiveX data objects for .net)

			//model
			//Disconected Model
			//connection oriented Model

			//ado.net disconnected model..
			//whenever we use this model to interact with the database then the connectivity between
			//the application and database is not required while performing any navigations or 
			//manipulations on the data..
			//in this model applicaiton never directly interacts with the database directly we need someone in between
			//managed data providers for diconnected model are:connection(it will istableshes the physical connectivity 
			//with the data source   ),DataAdaptor(the data adapter uses the connection object of the .net framework
			//data provider to connect to data souce and it uses the commend obejct to reteieve the form data source)
			//so data adapter cant interact with the data adapter directly  ..so we take a dataset and pass data from 
			//DataAdapter to the DataSet..now application can use the data present in the DataSet..and perform any
			//navigation or manipulation....when ever data has to be filtered then DataView can be used 

			//when ever any changes has to happen then it has to reconnectred to the database


			//Connection:
			//The connection object is the first obejct in the ADO.NET
			// it sets a conneciton between the database and .netApplication
			//connection object establishes the physical connectivity between the application and
			//the database with the support of connection string

			//DataAdapter:
			//Data Adapter can be considered as a collection of command obejcts which acts like 
			//an interface or brigde between the Database and the dataset for transfaring the data
			//DataAdapter Commands:
			//SelectCommand
			//TableMappings 
			//insertCommand
			//updatecommand
			//deleteCommand


			//DataSet
			//DataSet can be considered as an in-memory representation of the data at the client system
			//it can also be considered as collection of dataTables,Datarelations,XMLschema..where datatable
			//is teh collection of columns and datarows and constraints

			//DataView:
			//represent a databindable,customised view of a DataTable
			//dataview can be used in searching ,filtering ,nevigating..on the data.



			//ADO.NET connection oriented model
			//Whenever we use this model then the connectivity between the application and the database has to be 
			//maintained constinuously as long as the application interacts with the database.


			//Command Object:
			//used to store SQL statement that need to be executed against a data source
			//it has following properties
			//Connection
			//CommandType==commandType(Text,StoredProcedure,TableDirect(want to fetch the table without writing the table name))
			//CommandText::used to specify the Sql statement we want to execute
			//Transaction:use to associate the transaction object to command object so that changes
			//made to the database with the command obejct  can be commited or rollback
			//iT HAS FOLLOWING important methods();
			//1.  ExecuteNonQuery() ::use other then select query it returns the int
			//2.ExecuteScalar():use to execute the select statement which returns  the single value and if 
			//the value return is more than one the it will return the first row first column data .it returns the obejct 
			//3.ExecuteReader():it is used to return any valid select statement---return type of this is datareader 

			//DataReader:
			//it is stream based read only and forward .records which maintain the record retrived by the obejct
			//it can only be used to read the data..in forward only deirection 
			//it can not be used for manipulcaiton 
			//it can not be define directly it can be defied wiht the help of support executeReader() method of command obejct
			//

			//when ever we want to connect to the database we need to conect to the database using System.Data.SqlClient
			//namespace which provides teh Classes like SqlConnection,SqlCommand,SqlDataReader,SqlDataAdapter

			//for oracle:System.Data.OracleClient


			//for excel:
			//we can use the OleDB providers...System.Data.OleDB(OleDBConnection,OleDBCommand,OleDBDataReader,OleDBDataAdapter)
			//oleDb(Object Linking and Embedding Database)
			//ODBC(Open Database COnnectivity Drivers)

			//DataSet and DataView remains common for all the methods and resides on System.Data namesapce

			//the importance of COnnection string..
			//Connection Object -->Connection String---->database(sql,oracle,MySql)
			//

			//A connection string consist of a series of keywords value pairs seperated by semicolons;
			//key1=value1,key2=value2,key3=value3
			//The basic information which is required to generate the connection string are:
			//1. "Data Source =Server name;"+
			//2.  "initial Catalog=DatabaseName;"+
			//3.  "Used Id=UserName;"+
			//4.  "Password=Secret;";

			//Connection string:
			//connectionString to interact with the SQL Server Database
			//Provider=SQLOLEDB;Data Source=ServerName;Initial Catalog=DataBaseName;User Id=username;password=secret

			//when ever we use sql class to connect to teh sql database ,and oracle class for oracle database ,
			//we dont need provider	 in conneciton string
  


		}

		private static void LinqExamples()
		{
			//LINQ:language integrated query
			//a way to express queries against a data source directly from a .NET language ,such as C#
			//Linq to Objects::
			//Linq to SQL:works with sql
			//Linq to Entities:it works with entities
			//Linq to XML:used with XML


			//to type  syntax LINQ had:

			//query sentax:
			//ex: var vendorQuery=from v in vendors 
			//					   where v.CompanyName.Contains("Toy")
			//					   orderby v.CompanyName
			//					   select v;

			//method syntax:
			//var vendorQuery=vendors  //vendors is datasource here 
			//				   .where(v=>v.CompanyName.Contains("Toy"))//where is lamda expression 
			//					.OrderBy(v=>v.CompanyName);

			//Linq having many extension methods
			//in query syntax it will internally calls the extension methods..so insted of that 
			//we can call it directly using method way as above

			//a method addres to an exesting type without modifying the original type

			//a delegate is a type:-it is a type that represents a reference to a method with a
			//specific parameter list and return type
			//used to pass methods as argumetns to other methods

			//vendors.Where(Func<vendor,bool> predicate)
			//we can pass the name of the function here as it it an extensiokn method 
			//and it take function name

			//ex:
			//private bool FIlterCompanies(Vendor v)
			//{
			//	return v.CompanyName.Contains("Toy");
			//}


			//lamda expression:
			//vendors.Where(v=>v.CompanyName.Contains("Toy"))

			var _dictionary=new Dictionary<string,SortedList<string,List<Employee>>>();
			var _engineers = new SortedList<string, List<Employee>>();
			var _tranieeSoftwareEngineers = new List<Employee>();
			_tranieeSoftwareEngineers.Add(new Employee("Vishal", "Bareilly"));
			_tranieeSoftwareEngineers.Add(new Employee("Sumit", "Kolhapur"));
			_tranieeSoftwareEngineers.Add(new Employee("Ankur", "haldawni"));
			_tranieeSoftwareEngineers.Add(new Employee("Prashob", "wayanad"));

			
			var _listDataScientist = new List<Employee>();
			_listDataScientist.Add(new Employee("Shiva", "Kerala"));
			_listDataScientist.Add(new Employee("ShrutiAggrawal", "Bareilly"));
			_listDataScientist.Add(new Employee("Genious Sharma", "Surtiygya"));
			_listDataScientist.Add(new Employee("Ramiya", "Sityrya"));

			
			var _listManager = new List<Employee>();
			_listManager.Add(new Employee("Ashok Sahu", "Bangalore"));
			_engineers.Add("Priorityc", _tranieeSoftwareEngineers);
			
			_engineers.Add("PriorityB", _listDataScientist);
			_engineers.Add("PriorityA", _listManager);

			_dictionary.Add("EuromonitorInternational", _engineers);
			
			foreach (var items in _dictionary)
			{
				Console.WriteLine(items.Key);
				Console.WriteLine("=====================================");
				foreach (var item in items.Value)
				{
					Console.WriteLine(":"+item.Key+":");
					foreach (var i in item.Value)
					{
						Console.WriteLine(i.Name+"   "+i.Address);
					}
					Console.WriteLine("---------------------------------");
				}
				
			}


			Console.WriteLine("Linq Example");
			var linqExample = from list in _engineers
							  where _engineers.Keys.Contains("PriorityA")
							  select list.Value;
			foreach (var item in linqExample)
			{
				foreach (var i in item)
				{
					Console.WriteLine(i);
				}
			}
			Console.WriteLine("LInqWithMethodExample");
			var LinqWithMethod = _engineers
								 .Where(e => e.Key.Contains("PriorityA"))
								 .OrderBy(e => e.Value);

			foreach (var item in LinqWithMethod)
			{
				foreach (var i in item.Value)
				{
					Console.WriteLine(i);
				}
			}
			
			

			//_dictionar.y.Add("EuromonitorInternational", new SortedList<string, Employee>().Add("Manager",new Employee("Ashok","Address")) );
			
		  //building a linq Query :Method syntax:
		  //var vendorQuery=vendors.Where(delegate)
		  //                       .OrderBy(delegate)
		  //private bool FilterCOmpanies(vendor v)=>v.CompanyName.Contains("Toy");
		  //private string OrderCompaniresByName(vendor v)=>v.CompanyName;
		  //var vendorQuery=vendors.Where(FilterCompanes).OrderBy(OrderCompaniesByName)



			
		}

		private static void GenericCollectionInterfaces()
		{
			//Generic interfaces
			//Interface:A specification identifying a related set of properties and methods
			//A class commits to supporting the specification by implementing the interface

			//Use the interface as a data type to work with any class that implements the interface

			//public interface ICollection<T>:IEnumerable<T>
			//{
			//	int Count{ Get; }
			//	void Agg(T item);
			//	void Clear();
			//	bool COntains(T item);
			//	bool Remove(T item)
			//}


			//List<T> implements ICollection<T>::: so list class give implementation 
			//for each properties

			//built-in Interfaces--generic collection interfaces


			//IEnumerable<T> (its is base for all generic colleciton)-->GetEnumerable(for each statement call this method)
			//ICollection<T> implements IEnumerable interafce and have three properties,methods..Count,Add Remove
			//IList<T> interface implements ICollection interface and have INdexOf,insert,RemoveAt
			//IDictionary<T,V> also extends the interface IColleciton and have Keys,Values,TryGetValue

			//Ex:Array implements IEnumerable<T>,ICollection<T>,IList<T>
			//Ex:List<T> implements IEnumerable<T>,ICollection<T>,IList<T> 
			//Ex:Dictionary<T,V> implements IEnumerable<T>,ICollection<T>,IList<T>


			//Using Interface :
			//paramter:The calling code can pass in an instance of any collection class that implements the
			//interface
			//return type:the calling code can cast the returned value to any colleciton class that implements
			//the interface
			//Class:a custom collection class implements the interface


			//Using an interface as a parameter:try to use IEnumerable<T> 
			//public List<sting> SendList(List<Vendor> vendors,string message)
			//{
			//
			//}
			//public List<sting> SendList(ICOllection<Vendor> vendors,string message)
			//{
			//now it can take Array of vendors Vendors[] ,List<Vendor>,Dictionary<string,vendors>
			//}

			//return type:
			//ICollection<Vendor>

			IEnumerableExamples();
		}

		private static void IEnumerableExamples()
		{
			//IEnumerable<T> -->GetEnumerator() ---(it will be called when we use foreach )
			//consider returning an IEnumerable<T> to provide an immutable collection..it can not add
			//or remove it can only iterate over collection

			//Consider returning IEnumerable<T> when the calling code use cases are unknown 

			//Consider returning IQueryable<T> when working with a query provider,such as LINQ to sql or
			//Entity framework

			//defining an iterator with yeild(there is the case where we want to return the collection one at a time)
			//public IEnumerable<int> Fibonacci(int x)
			//{
			//	int _prev = -1;
			//	int _next = 1;
			//	for (int i = 0; i < x; i++)
			//	{
			//		int _sum = _prev + _next;
			//		_prev = _next;
			//		_next = _sum;
			//		yield return _sum;//iterator with yeild keyword...return one element at a time..return type of that function IEnumerable 
			//	}//defered execution ..means it will be executed only when it is required
			//use iterator when one element has to return at a time ..also known as Lazy Evaluation..
			//
			//}
			//interface:we can write more generlise code

			//Features:
			//IEnumerable<T>:the ability to iterate through a collection using foreach 
			//ICollection<T>:the ability to work with collection ex:add,remove ,count
			//IList<T>:the ability to work with index:locate items by index or insert at a specific
			//index


			//return IEnumerable<T> ::returns read only collection we can cast it:ex Tolist()
			//can return yield 

			//return IList<T> or ICollection<T> :flixible updatable collection
			//List<T>,Array[] of Dictionary<T,V> :specific updateable collection

		}

		enum EmpCatogoryEnum
		{
			TraineeSoftWareEngineer,
			SoftwareEngineer,
			TeamLead,
			Manager,
			CountryManager

		}
		private static void GenericDictionary()
		{
			//Generic Dictionary:
			//A strongly typed collection of keys and values
			//Keys:Must ne unique ,Must be unique,cannot be null

			//Generic Dictionary:
			//Dictionary<TKey,TValue>
			//Dictionary<int,int>
			//DIctionary<int,string>
			//Dictionary<string,string>
			//Dictionary<int,Product>

			var _employees = new Dictionary<string, List<Employee>>();
			var _list = new List<Employee>()
			{
				new Employee(){Name="Vishal",Address="Bareilly"},
				new Employee(){Name="sumit",Address="kolhapur"},
				new Employee(){Name="ankur",Address="Haldwani"},
				new Employee(){Name="Prasob",Address="Kerala"}
			};
			_employees.Add("TraineeSoftWareEngineer", _list);
			_employees.Add("SoftwareEngineer", new List<Employee>()
			{
				new Employee(){Name="Shiva B",Address="kerala"},
				new Employee(){Name="Akshey Kumar",Address="Bangalore"}
			});
			_employees.Add("TeamLead", new List<Employee>()
			{
				new Employee(){Name="Sanath Shetty",Address="Bangalore"},
				new Employee(){Name="Hemant",Address="Bangalore"}
			});
			_employees.Add("Manager", new List<Employee>()
			{
				new Employee(){Name="Ashok sahu",Address="Bangalore"}
			});
			_employees.Add("CountryManager", new List<Employee>()
			{
				new Employee(){Name="Urgan",Address="South Aferica"}
			});


			if (_employees != null)
			if (_employees.Keys != null && _employees.Values != null)
			foreach (var item in _employees)
			{
				
				if (item.Key == "TraineeSoftWareEngineer")
				{
					Console.WriteLine("TraineeSoftWareEngineer");
					foreach (var _emp in item.Value)
					{
						Console.WriteLine(_emp);
					}
				}
				if (item.Key == "SoftwareEngineer")
				{
					Console.WriteLine("SoftwareEngineer");
					foreach (var _emp in item.Value)
					{
						Console.WriteLine(_emp);
					}
				}
				if (item.Key == "TeamLead")
				{
					Console.WriteLine("TeamLead");
					foreach (var _emp in item.Value)
					{
						Console.WriteLine(_emp);
					}
				}
				if (item.Key == "Manager")
				{
					Console.WriteLine("Manager");
					foreach (var _emp in item.Value)
					{
						Console.WriteLine(_emp);
					}
				}
				if (item.Key == "CountryManager")
				{
					Console.WriteLine("CountryManager");
					foreach (var _emp in item.Value)
					{
						Console.WriteLine(_emp);
					}
				}
			}
			//we can loops througn Elements,Keys,Values

			//Dictionary present in cSharp
			//System.Collections(.NET);//they should not be used

			//System.Collections.Generic
			//-->Dictionary<TKey,TValue>:Used more often,Not Sorted
			//-->SortedList<TKey,TValue>:sorted by key,faster when populating from sorted data
			//-->SortedDictionary<TKey,TValue>:sorted by key,faster when populating from unsorted data..

			//Threre are more dictionary are present in System.Collections.ObjectModel::
			//Appropriate for a resuable library
			
			//ReadOnlyDictionary
			
			//KEyedCollection

			//System.Collection.Specialized
			//Speciality collections
			//OrderedDictionary
			//System.Collections.Concurrent:Thread-safe dictionary classes


			

		}


		private static void GenericList()
		{

			//Array us Strongly typed:

			//Generic List
			//List<T>
			//add("value"),insert(index,"value"),remove("value")

			List<Employee> list = new List<Employee>()
			{

				new Employee("vishal Singh","bareilly uttar pradesh"),
				new Employee(){Name="sumit",Address="Kolhapur uttra khad"},
				new Employee(){Name="prasob",Address="kerala"}
			};
			list.Add(new Employee() { Name = "ankur", Address = "Uttra khand" });
			list.Insert(0, new Employee() { Name = "Narendra", Address = "Unknown place" });
			foreach (var item in list)
			{
				Console.WriteLine(item);
			}
			list.Remove(new Employee() { Name = "prasob", Address = "kerala" });//it will call equals method
			foreach (var item in list)
			{
				Console.WriteLine(item.Name);
			}


			//System-->Array
			//System.Collecitons(.NET 1)-->ArrayList(it should not be used it is obsolete)
			//System.Collections.Generic(.net 2+)//-->List<T>-->ListedList<T>-->Queue<T>-->Stack<T>

			//array:multiple dimensions...
			//list<T>:::now most of time
			
			//System.Collections.ObjectModel
			//Appropriate for a reuable library
			//readonlyCollection
			//ObservableCollection

			//System.Collections.Specialized
			//Speciality collections
			//Stringcollection

			//System.collections.COncurrent
			//Thread-safe list classes


			//foreach loop obejct is not editable but its properties are editable


		}

		private static void GenericConstraints()
		{
			//ValueTypeExample();
			//ReferenceType();
			//ReferenceTypeWithReturnType();
			//GenericsForBaseClass();
			//GenericsForInterface();
			
		}

		private static void GenericsForInterface()
		{
			var _instance = new GenericsForInterface<SoftwareEngineer>();
			var _obj=_instance.GetClassObject<SoftwareEngineer>();
			_obj.Name = "Vishal Singh";
			_obj.Address = "Braeilly Uttar Pradesh";
			Console.WriteLine(_obj);
		}

		private static void GenericsForBaseClass()
		{
			var _instance = new GenericsForBaseClass<SoftwareEngineer>();
			var obj=_instance.GetClassObject<SoftwareEngineer>();
			obj.Name = "Vishal";
			obj.Address = "Bareilly";
			Console.WriteLine(obj);

		}

		private static void ReferenceTypeWithReturnType()
		{
			var _instance = new GenericForReferenceWithReturnType<Employee>();
			var _employee = _instance.getObject<Employee>();
			_employee.Name = "Vishal Singh";
			_employee.Address = "Bareilly UP";
			Console.WriteLine(_employee);

		}

		private static void ReferenceType()
		{
			var _instance = new GenericForReferenceType<string>();
			_instance.SomeReferenceType = "Vishal Singh";
			var _instance2 = new GenericForReferenceType<Employee>();
			_instance2.SomeReferenceType = new Employee("vishal", "bareilly");
			Console.WriteLine(_instance2.SomeReferenceType.Name);
			Console.WriteLine(_instance2.SomeReferenceType.Address);
			
		}

		private static void ValueTypeExample()
		{
			var _instance = new GenericClassExampleForStruct<char>() { SomeValueType = 'v' };
			Console.WriteLine(_instance.SomeValueType);
			var _instance2 = new GenericClassExampleForStruct<EmployeeStruct>() { SomeValueType = new EmployeeStruct("vishal", "bareilly") };
			Console.WriteLine(_instance2.SomeValueType.Name);
		}
	} 
	public struct EmployeeStruct
	{
		public string Name { get; set; }
		public string Address { get; set; }

		public EmployeeStruct(string name,string address)
		{

			Name = name;
			Address= address;
		}
		

	}
	public interface IEmployee
	{
      
	}
	public class Employee:IEmployee
	{
		public string Name { get; set; }
		public string Address { get; set; }
		public Employee(string name,string address)
		{
			Name = name;
			Address = address;
		}
		public Employee()
		{

		}


		public override string ToString()
		{
			
			return "Name :" + Name + "  Address" + Address;
		}
	}
	class SoftwareEngineer:Employee
	{
		
		public SoftwareEngineer(string name,string address):base(name,address)
		{

		}
		public SoftwareEngineer()
		{

		}
	}
}
