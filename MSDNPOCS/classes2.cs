using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MSDNPOCS
{
	//public class BaseClass
	//{
	//	public virtual void DoWork() { }
	//	public virtual int WorkProperty
	//	{
	//		get { return 0; }
	//	}
	//}
	//public class DerivedClass : BaseClass
	//{
	//	public override void DoWork() { }
	//	public override int WorkProperty
	//	{
	//		get { return 0; }
	//	}
	//}


	public class BaseClass
	{
		public void DoWork() {
			Console.WriteLine("base class do work method");
		}
		public int WorkField;
		public int WorkProperty
		{
			get { return 0; }
		}
	}
	public class DerivedClass : BaseClass
	{
		public new void DoWork() {
			Console.WriteLine("Derived class new Keyword");
		}
		public new int WorkField;
		public new int WorkProperty
		{
			get { return 0; }
		}
	}

	public class A
	{
		public virtual void DoWork() {
			Console.WriteLine("a");
		}

	}
	public class B : A
	{
		public sealed override void DoWork()
		{
			Console.WriteLine("b");
		}
		public virtual void DoMoreWork(int i)
		{
			Console.WriteLine("B do more work");
		}
		public void Method1()
		{
			Console.WriteLine("Method1 B");
		}
		public void Method2()//virtual after using virtual also same output will be
		{
			Console.WriteLine("method 2 form B");
		}
	}
	public class C : B
	{
		//now we can not override here..
		//sealed mthod can be replaced by derived classes by using new keyword ,as following example shows...
		public new void DoWork()//it will remove compilerworning also
		{
			Console.WriteLine("sealed method replaced by using new keyword");
		}

		public override void DoMoreWork(int i)
		{
			Console.WriteLine("C overriden method do more work");
		}
		public void DoMoreWork(double i)
		{
			Console.WriteLine("c not overridedn method");
		}
		public new void Method2()//if we use here the override it will show this emthod only 
		{
			Console.WriteLine("method2 from C");
		}

	}
	class Car
	{
		public void DescribeCar()
		{

			Console.WriteLine("four wheel and an engine");
			ShowDetails();
		}
		public virtual void ShowDetails()
		{
			Console.WriteLine("details from car");
		}
	}
	class Canvertible : Car
	{
		public new void ShowDetails()
		{
			Console.WriteLine("show details car");
		}
	}

	class Minivan : Car {
		public override void ShowDetails()
		{
			Console.WriteLine("details from minivan");
		}
	}

	class Student
	{
		public String Name { get; set; }
		public int StudentId { get; set; }
		public override string ToString()
		{
			return "Name is:  " + this.Name + "   Student Id:" + this.StudentId;
		}
	}
	public class D
	{
		public virtual void DoWork(int i)
		{
			Console.WriteLine("Original Implementation");
		}

	}
	public abstract class E : D
	{
		public abstract override void DoWork(int i);
	}
	public sealed class F : E//now no other class can inherit it
	{
		public override void DoWork(int i)
		{
			Console.WriteLine("new implementation ");

		}
	}
	public abstract class AShape
	{
		private string name;
		public AShape(string id)
		{
			Id = id;
		}
		public string Id {
			get {
				return name;
			}
			set {
				name = value;

			}
		}
		public abstract double Area//read only property
		{
			get;
		}
		public override string ToString()
		{
			return Id + "Area=" + string.Format("{0:F2}", Area);
		}
	}
	public class DSquare : AShape
	{
		private int side;
		public DSquare(int side, string id) : base(id)
		{
			this.side = side;
		}
		public override double Area
		{
			get
			{
				//given radious return the area of the circle
				return side * side;
			}
		}
	}
	public class DCircle : AShape
	{
		private int radius;
		public DCircle(int radius, string id) : base(id)
		{
			this.radius = radius;
		}
		public override double Area
		{
			get
			{
				//given the radius,return the area of a circle..
				return radius * radius * System.Math.PI;
			}
		}
	}
	public class DRectangle : AShape
	{
		private int width;
		private int height;
		public DRectangle(int width, int height, string id) : base(id)
		{
			this.width = width;
			this.height = height;

		}
		public override double Area
		{
			get
			{
				return width * height;
			}
		}
	}
	public static class TempratureConverter
	{
		public static double CelsiusToFahrenheit(string tempratureCelsius)
		{
			double celsius = Double.Parse(tempratureCelsius);
			double fahrenheit = (celsius * 9 / 5) + 32;
			return fahrenheit;
		}

		public static double FahrenheitToCelsius(string tempratureFarenheit)
		{
			double farenheit = Double.Parse(tempratureFarenheit);
			double celsius = (farenheit - 32) * 5 / 9;
			return celsius;
		}
		public static int WordCountExtension(this string str)
		{
			return str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
		}
		public static Grades minPassing = Grades.D;
		public static bool Passing(this Grades grade)
		{
			return grade >= minPassing;
	     }

		
	}

	public enum Grades { F = 0, D = 1, C = 2, B = 3, A = 4 };
	public class CalenderEntry
	{
		/// <summary>
		/// date is private field
		/// </summary>
		private DateTime date;

		public DateTime Date
		{
			get
			{
				return date;
			}
			set
			{
				if (value.Year > 1990 && value.Year <= DateTime.Today.Year)
				{
					date = value;
				}
				else
				{
					throw new CustomException();
				}
			}
		}

		public void SetDate(string dateString)
		{
			DateTime dt = Convert.ToDateTime(dateString);

			if (dt.Year > 1990 && dt.Year <= DateTime.Today.Year)
			{
				date = dt;
			}
			else
				throw new CustomException();
		}

		public TimeSpan GetTimeSpan(string dateString)
		{
			DateTime dt = Convert.ToDateTime(dateString);
			if (dt != null && dt.Ticks < date.Ticks)
			{
				return date - dt;
			}
			else
				throw new CustomException();
		}

	}
	class CustomException : Exception
	{
		public CustomException()
		{
			Console.WriteLine(" log the exception somewhere ");
		}
	}
	public static class ConstClassExample
	{
		const string variable = "pocforConstant";

	}

	class TimePeriod
	{
		private double seconds;
		public double Hours
		{
			get
			{
				return seconds / 3600;
			}
			set
			{
				if (value < 0 || value > 24)
				{

					throw new CustomExceptionForTimePeriod($"{nameof(value)} must be between 0 and 24.");
				}
				seconds = value * 3600;
			}
		}
	}
	internal class CustomExceptionForTimePeriod : Exception
	{
		public CustomExceptionForTimePeriod(string errorString)
		{
			Console.WriteLine("log the error in error log file   :" + errorString);
		}

	}
	public class Base
	{
		protected private void M()
		{
			Console.WriteLine("From base.M()");
		}
	}
	public class D1 : Base
	{
		new public void M()
		{
			Console.WriteLine("from D1.M()");
			base.M();
		}
	}
	interface IEmployee
	{
		void getName();
	}
	static class Employee
	{
		public static void ExtensionMethod(this IEmployee emp)
		{
			Console.WriteLine("Extension method works");
		}
		public static int FunctionExtension(this Func<int, string> func, int i)
		{
			return i;
		}
		public static void ActionFun(this Action<int> ac, int i)
		{
			Console.WriteLine("Printing the values" + i);
		}
	}
	public class EMPLOYEE
	{
		public static int NumberOfEmployees;
		private static int counter;
		private string name;
		public string Name {
			get { return name; }
			set { name = value; }
		}
		public EMPLOYEE()
		{
			counter = ++NumberOfEmployees;
		}

	}
	public class Manager : EMPLOYEE
	{
		private string name;
		public new string Name
		{
			get { return Name; }
			set { name = value + ",Manager"; }
		}


	}
	abstract class ShapePropPOC
	{
		public abstract double Area
		{ get; set; }
	}
	class SquarePropPOC : ShapePropPOC
	{
		public double side;
		public SquarePropPOC(double s)//constructor
		{
			side = s;
		}
		public override double Area {
			get { return side * side; }
			set { side = Math.Sqrt(value); }
		}
	}
	class CubePropPOC : ShapePropPOC
	{
		public double side;
		public CubePropPOC(double s)
		{
			side = s;
		}
		public override double Area {
			get { return 6 * side * side; }
			set { side = Math.Sqrt(value / 6); }
		}
	}
	interface IEmployeePropPOC
	{
		string Name
		{
			get;
			set;
		}
		int Counter
		{
			get;
		}
	}
	public class EmployeeProp : IEmployeePropPOC
	{
		public static int numberOfEmployees;
		private string name;
		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}
		private int counter;
		public int Counter//readonly instance property
		{
			get
			{
				return counter;
			}
		}
		public EmployeeProp()
		{
			counter = ++numberOfEmployees;
		}
	}
	class Parent
	{
		public virtual int TestProperty
		{
			//notice the accessor assessibility level
			protected set { }
			get { return 0; }
		}

	}
	class Child : Parent
	{
		public override int TestProperty
		{
			get { return 0; }//can not use access modifier here
			protected set { }//use the sane accessibility level as in the overrideen accessor
		}
	}
	class Kid : Parent
	{
		public override int TestProperty
		{
			get { return 0; }

			protected set { }
		}
	}
	class BaseClassForProp
	{
		private string name = "Name-BaseClass";
		private string id = "ID-BaseClass";
		public string Name
		{
			get { return name; }
			set { }
		}
		public string Id
		{
			get { return id; }
			set { }
		}
	}

	class DerivedClassForProp : BaseClassForProp
	{
		private string name = "Name-DerivedClass";
		private string id = "ID-DerivedClass";
		public string freakVaribale { get; set; } = "Random kalisthan";//after c# 6.0
		new public string Name//warning using new does not hide the base implementaion of the Name Property
		{
			get { return name; }
			set { name = value; }
		}
		new private string Id
		{
			get
			{
				return id;
			}
			set
			{
				id = value;

			}
		}
	}
	class Contact
	{
		//readonly properties..
		public string Name { get; }
		public string Address { get; private set; }

		//public constructor
		public Contact(string contactName, string contactAddress)
		{
			Name = contactName;
			Address = contactAddress;
		}
	}
	class Contact2
	{
		//readonly properties
		public string Name { get; private set; }
		public string Address { get; }

		//private constructor
		public Contact2(string contactName, string contactAddress)
		{
			Name = contactName;
			Address = contactAddress;
		}

		//public factory Method 
		public static Contact2 CreateContact(string name, string address)
		{
			return new Contact2(name, address);
		}
	}
	//public partial class MainWindow:Window
	//{
	//	private async void StartButton_Click(object sender,RoutedEventArgs e)
	//	{
	//		int contentLength = await AccessTheWebAsync();
	//		resultsTextBox.Text += String.Format("length of the downloaded string:{0}", contentLength);
	//	}

	//	async private Task<int> AccessTheWebAsync()
	//	{
	//		HttpClient client = new HttpClient();
	//		Task<string> getStringTask = client.GetStringAsync("https://msdn.microsoft.com");
	//		DoIndependentWork();
	//		string urlContents = await getStringTask;
	//		return urlContents.Length;
	//	}
	//	void DoIndependentWork()
	//	{
	//		resultsTextBox.text += "Working . . . . . . . . ";
	//	}

	class NumebrStore
	{
		int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
		public ref int FindNumber(int target)
		{
			for (int ctr = 0; ctr < numbers.Length; ctr++)
			{
				if (numbers[ctr] >= target)
					return ref numbers[ctr];
			}
			return ref numbers[0];
		}
		public override string ToString()
		{
			return string.Join(" , ", numbers);
		}
	}

	//	private void DoIndependentWork()
	//	{
	//		throw new NotImplementedException();
	//	}
	//}
	class TheClass
	{
		public string wilIChange;
	}

	struct TheStruct
	{
		public string wilIChange;
	}

	public interface IMyInterface
	{
		void MethodB();
	}
	public static class Extension
		{
		public static void MethodA(this IMyInterface myInterface,int i)
		{
			Console.WriteLine("Extension.MethodA(this IMyInterface myInterface,int i)");
		}
		public static void MethodA(this IMyInterface myInterface,string s)
		{
			Console.WriteLine("Extension.Mehtod(this IMyInterface myInterface,string s)");
		}

		//this mthod is never called in ExtensionMethodDempo1 ,because each of the three classes A,B,C implements
		//a method named methodb 
		//that has a metching signature

		public static void MethodB(this IMyInterface myInterface)
		{
			Console.WriteLine("Extension.MethodB(this IMyInterface myInterface)");
		}
		}


	class AClass:IMyInterface
	{
		public void MethodB() { Console.WriteLine("A.MEthodB()"); }
	}
	class BCLass : IMyInterface
	{
		public void MethodB() { Console.WriteLine("B.Method()"); }
		public void MethodA(int i) { Console.WriteLine("B.MethodA()"); }
	}
	class CCLass:IMyInterface
	{
		public void MethodB() { Console.WriteLine("C.Method()"); }
		public void MethodA(object obj) { Console.WriteLine("C.Method(object obj)"); }
	}

	class ExampleClass
	{
		private string _name;
		//because the parameter for the constructor ,name,has a default
		//to it .it is optional.
		public ExampleClass(string name="Default Name")
		{
			_name = name;
		}

		//the first parametrer ,required ,has no default value assigned
		//to it.Therefore,it is not optional .Both optional str and
		//optioanl int have default values assigned to them.They as optional...

		public void ExampleMethod(int required,string optionalstr="default string",int optionalist=10)
		{
			Console.WriteLine("{0},{1},and {3}",_name,required,optionalist);
		}
	}
	public class Person
	{
		private string last;
		private string first;
		public Person(string lastName,string firstName)
		{
			last = lastName;
			first = firstName;
		}
	}
	
	public class Location
	{
		private string _locationName;
		public Location(string name) => Name = name;
		public string Name
		{
			get => _locationName;
			set => _locationName = value;
		}
	}
	public class Adult:Person
	{
		private static int _minimumAge;
		public Adult(string lastName,string firstName):base(lastName,firstName)
		{

		}
		static Adult()
		{
			_minimumAge = 18;
		}
		//remaining implementation of adult class...
	}
	public class ChildCtor : Person
	{
		private static int _maximumAge;
		public ChildCtor(string lastName,string firstName):base(lastName,firstName)
		{

		}
		static ChildCtor() => _maximumAge = 18;//expression body

		//remaining implementation of child class
	}
	 class freakclass
	{
		public string name;
		public string address;
		private Base b;
		public freakclass()
		{
			b = new Base();
		}
		public freakclass(string address):this()
		{
			address = address;	
		}
		public Base getBase { get { return b; } }//read only property
	}

	abstract class ShapeCtor
	{
		public const double pi = Math.PI;
		protected double x, y;
		public ShapeCtor(double x,double y)
		{
			this.x = x;
			this.y = y;
		}
		public abstract double Area();
	}
	class CircleCtor : ShapeCtor
	{
		public CircleCtor(double radius) : base(radius, 0)
		{

		}
		public override double Area()
		{
			return pi * x * x;
		}

	}
	class CylinderCtor : CircleCtor
	{
		public CylinderCtor(double radius,double height):base(radius)
		{
			y = height;
		}
		public override double Area()
		{
			return (2 * base.Area()) + (2 * pi * x * y);
		}
	}

	public class Bus
	{
		//static variable will be used 
		protected static readonly DateTime globalStartTime;

		protected int ROuteNumber { get; set; }

		static Bus()
		{
			globalStartTime = DateTime.Now;
			Console.WriteLine("static ctor set global start time to {0}"+globalStartTime.ToLongDateString());
		}

		public Bus(int routeNum)
		{
			ROuteNumber = routeNum;
			Console.WriteLine("Bus #{0} is created."+ROuteNumber);
		}

		//instance method
		public void Drive()
		{
			TimeSpan elapsedTime = DateTime.Now - globalStartTime;
			Console.WriteLine("{0} is starting its route {1:N2} minutes after gloabl start tim {2}",this.ROuteNumber,elapsedTime.TotalMilliseconds,globalStartTime.ToShortTimeString());
		}
	}
	class PersonCopyCtor
	{
		public int Age { get; set; }
		public string Name { get; set; }
		public PersonCopyCtor(PersonCopyCtor previousPerson):this(previousPerson.Name,previousPerson.Age)
		{
			Name = previousPerson.Name;
			Age = previousPerson.Age;
		}
		public PersonCopyCtor(string name,int age)
		{
			Name = name;
			Age = age;
		}
		public string Details()
		{
			return Name + "is " + Age.ToString();
		}
	}
	class FirstPoc
	{
		~FirstPoc()
		{
			Console.WriteLine("First's destructor is called.");
		}
	}
	class SecondPoc : FirstPoc
	{
		~SecondPoc()
		{
			Console.WriteLine("Second's destrcutor is called.");
		}
	}
	class ThirdPoc : SecondPoc
	{
		~ThirdPoc()
		{
			Console.WriteLine("Third's destructor is called");
		}
	}
	class Cat
	{
		public int Age { get; set; }
		public string Name{ get; set; }

	}


	class FormattedAddress:IEnumerable<string>
	{
		private List<string> internalList = new List<string>();

		public IEnumerator<string> GetEnumerator()
		{
			Console.WriteLine("i am getting called"+this);
			return internalList.GetEnumerator();

		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			
			return  internalList.GetEnumerator();
		}
		public void Add(string firstname, string lastname, string street, string city, string state, string zipcode) => internalList.Add($@"{firstname} , {lastname} , {street} , {city} , {state} , {zipcode}");
		public override string ToString()
		{
			string values = "";
			foreach(var i in internalList)
			{
				values += " \n"+i;	
			}
			return values;
		}
	}

	class RudimintoryMultiValuedDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, List<TValue>>>
	{
		private Dictionary<TKey, List<TValue>> internalDIctionary = new Dictionary<TKey, List<TValue>>();

		public IEnumerator<KeyValuePair<TKey, List<TValue>>> GetEnumerator()
		{
			return internalDIctionary.GetEnumerator();
		}

		
		IEnumerator IEnumerable.GetEnumerator()
		{
			return internalDIctionary.GetEnumerator();
		}
		public List<TValue> this[TKey key]
		{
			get => internalDIctionary[key];
			set =>Add(key, value);
		}
		public void Add(TKey key,params TValue[] values)
		{
			Add(key, (IEnumerable<TValue>)values);
		}
		public void Add(TKey key,IEnumerable<TValue> values)
		{
			if (!internalDIctionary.TryGetValue(key, out List<TValue> storedValues))
				internalDIctionary.Add(key, storedValues = new List<TValue>());
			storedValues.AddRange(values);
		}
	}
	class StudentName
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int ID { get; set; }
	}

	class Container
	{
		public class Nested
		{
			private Container _parent;
			public Nested()
			{
				Console.WriteLine("I am nested class");
			}
			public Nested(Container parent)
			{
				this._parent = parent;
			}
		}
	}

	public partial class EmployeePartial
	{
		public void DoWork()
		{
			Console.WriteLine("First Partial class");
		}
	}
	public partial class EmployeePartial
	{
		public void GoToLunch()
		{
			Console.WriteLine("Second Pratial Class");
		}
	}
}
