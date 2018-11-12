using PocForConst;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace MSDNPOCS
{
	static class MsdnAllPocs
	{
		static void Main(string[] args)
		{
			//RuntimePolyMorphism();
			//RuntimeOverview();
			//HidingBaseClassMembersWithNewMembers();
			//PreventingDerivedClassFromOverridingVirtualMembers();//override ,virttual and new keywirds can also ne applied to properties indexex and events
			//OverrideAndMethodSelection();
			//OverrideANdNEwKeyWord();
			//OverideToStringMethod();
			//AbstractAndSealedClassAndClassMembers();
			//DefiningAbstractProperties();
			//StaticClassExample();
			//MembersInCSharp();
			//AccessModifiersInCSharp();
			//Fields();
			//Constants();
			//PropertiesExample();
			//AccessModifiersOnOverridingAccessors();
			//ExtensionMethod();
			//EqualMethodsInCSharp();
			//LightWeightClassExample();//immputable class
			//Methods();
			//Iterators();
			//LocalFunctions();
			//LocalFunctionsAndExceptions();
			//LocalFunctionWithAsyncFunction();
			//RefReturnAndRefLocals();
			//PassingTheParamaters();
			//PassingTheReferenceParameter();
			//DiffereneBetweenPassingAStructAndPassingAClassReference();
			//ImplicitlyTypedLocalVariable();
			//ExtensionMethodFromMSDN();
			//ImplementAndCallACustomExtensionMethod();
			//NamedAndOptionalArgument();
			//ConsoleApplicationWord();
			//Constructors();
			//Finalizers();
			//ObjectInitilizers();
			//Indexes();
			//DictionaryWithCollection();
			//NestedClass();
			//PartialClass();
			PartialMethod();
		}

		private static void PartialMethod()
		{
			//a partial class or struct may contain method .one part of the class contains the signatures of the method .
			//an optional implementation may be defined in teh same part or another part .if the implementation is not 
			//supplied then the method and all calls to the method  are removed at compile time
			//it has two parts :declaration and defination...

			//partial void onNameChanged();//decclaration
			//partial void onNameChanged()//defination
			//{ }

			//it should return void
			//can use in out ref
			//implicitly private so it cannot be virtual..
			//can not be extern
			//it can have static and unsafe modifier.
			//partial method can be generic.
			//can make a delegate to a partial method that has been defined and implemented ,but not to a partial
			//method that has only been defined..

			//anonymous types typically used in select clause of a query expression to return a subset of teh properties
			//from each object in the source sequence .
			//ex:var productQuery=from prod in products select new{prod.Color,prod.Price};
			//for clr anonymous type is just like reference type..ex:if two anonymous objects have properties and in same order
			//then this clr consider it as two different instance of same type..
			//two instances of the same anonymous type are equal only if their properties are equal



			//how to return subsets of elements properties in a query 
			//var queryHighScores=form student students where student.ExamScores[0]>95 select new {student.FirstName,student.LastName};



		}

		private static void PartialClass()
		{
			//it is possible to split the defination of a class ,a struct ,an interface or a method over two or moew
			//cource files.. Each source file contains a section of the type or method defination ,and all parts are 
			//combined when the applicaiton is compiled..

			//Partial Class:
			//there are several situation when splliting a class defination is desirable:
			//1.when working in large projects ,spreading a class over seperate files enables multiple programmers
			//to work on it at the same time..
			//2.when working with automatically generated source,code can be added to the class without having to recreate the cource file.
			//visual Studio uses this approach when it creates Windows Forms,Web Service,wrapper code,and so on.You can create
			//code that uses these classes without having to modify the file created by Visual Studio..
			//3.to split a class defination use the partial keyword modifier,as shown here...

			//parital keyword is needed for all parts ex:public,priabte and so on...
			//if part is declared as abstract then whole part is considered as abstrct or is sealed whole considered as sealed
			//if any any part declares a base type,then the whole type inherits that class.

			//partial modifier is not available on delegates or enumeration declarations..


			//[SerializableAttribute] partial class Moon { }
			//[ObsoleteAttribute] partial class Moon { }

			//it is equivalent to 
			//[SerializableAttribute] 
			//[ObsoleteAttribute] 
			//class Moon { }

			//following type merged form all the partial-type definations:
			//XML comments,interfaces,generic-type parameter attributes
			//generic-type paramter attributes
			//class attributes
			//members

			EmployeePartial e = new EmployeePartial();
			e.DoWork();
			e.GoToLunch();


			//restrictions:
			//1.all type must be modified with partial
			//2.can only appear before the keywords:class,struct or interface
			//3.nested partial can appear but both should be partial
			//4.must be part of same type and must be defined in same assembly and same module (.exe,dll) partial 
			//definations cannot span multiple moduels
			//5.the class name and generaic type parameters must match on all partial type definations.
			//generic types can be partial .each partial declaration must use the same parametr names in the same order

			//the following keywords on a partial type defination are optional but is present on one partial-type
			//defination ,cannot with the keywords specified on another partial defination for the same type:

			//public,priv



	}

	private static void NestedClass()
		{
			//nested types default to private they are accessible only from their containing type.
			//nested types are always private ,they are accessible only from their ocntaining type.In the previous example,the nested class
			//is inasscessible to extnal types.
			//can give all access modifier however giving teh protected ,protected internal,private protected in nested
			//class inside a sealed class generates compiler warning CS0628  "new protected member declared in sealed class"
			Container.Nested nest = new Container.Nested();
			
		}

		private static void DictionaryWithCollection()
		{
			//
			Dictionary<int, StudentName> students = new Dictionary<int, StudentName>()
			{
				{ 111,new StudentName{FirstName="Sumit",LastName="Kiran Gurav",ID=211} },
				{112,new StudentName{FirstName="Vishal",LastName="singh",ID=317} },
				{113,new StudentName{FirstName="Vamsi",LastName="Krishna",ID=198} }


			};
				
		}

		private static void Indexes()
		{
			RudimintoryMultiValuedDictionary<string, string> rudimentaryMultiValuedDictionary1 = new RudimintoryMultiValuedDictionary<string, string>()
			{
				{ "Group1","Sumit","GUrav","Bareilly"},
				{"Group2","Vishal","singh","kolhapur" },
				{"Group3","Vamsi","krishna","andra" }
			};
			RudimintoryMultiValuedDictionary<string, string> rudimentaryMultiValuedDictionary2 = new RudimintoryMultiValuedDictionary<string, string>()
			{
				["Group1"]=new List<string>() { "Sumit","Gurav","kolhapur"},
				["Group2"]=new List<string>() { "Vishal","singh","braeilly"},
				["Group3"]=new List<string>() { "Vamsi","krishna","andra"}
			};

			Console.WriteLine("Using first multivalude dictionary created with a colleciton initilizer");
			foreach(KeyValuePair<string,List<string>> group in rudimentaryMultiValuedDictionary1)
			{
				foreach(string name in group.Value)
				{
					Console.WriteLine(name);
				}
			}
		}

		private static void ObjectInitilizers()
		{
			//obejct initializers let us assign values to any assible fields or properties of an obejct at creation time without
			//hab=ving to invi=oke a constructor followed by lines of assignmetn statements..
			//parentheses syntax..
			Cat cat=new Cat { Name="pussy cat",Age=10};

			//object initilizers with anonymous types:
			var pet = new { Age = 10, Name = "vishal" };


			//anonymouse types enable the select clause in a LINQ query expression to tramsform objects of teh original 
			//sequence into obejcts whose value and shape may differ from the original .


			//ex:var productInfos=from p in products select new { p.ProductName , p.UnitPrice };



			//Collection initilizers:
			//by uisng colleciton initilizers you do not have to specify multiple calls to the Add method of the class
			//in you source code ,the compiler adds the calls.

			List<int> digits = new List<int> { 0, 1, 2, 3, 4, 5, 6, 78, 9 };//it will call multiple time add method


			//object initilizers
			List<Cat> cats = new List<Cat>
			{
				new Cat{Name="pussy cat",Age=8},
				new Cat{Name="Whiskers",Age=2},
				new Cat{Name="sasha",Age=14},
				null//here we can also pass null
			};

			var numbers = new Dictionary<int, string>
			{
				[7] = "seven",
				[9] = "nine",
				[13] = "thirteen"
			};





			FormattedAddress addressess = new FormattedAddress()
			{
				{ "Sumit","Gurav","kolhapur","maharastra","India","00000"},
				{"vishal","singh","bareilly","uttar pradesh","India","00000" },
				{ "prasobh","alian","noaddress","no state","Jupitor","#####"}
			};
			foreach(var address in addressess)
			{
				Console.WriteLine(address);
			}
		}

		private static void Finalizers()
		{
			//they can not be defined in structs .they are onlky used wiht classes.
			//a class can only have one finilizer
			//finilizers can not be inherited or overloaded
			//finilizers cannot be called.They are invoked automatically .
			//a finilizers does nto take modifiers or have parameter.
			//they can be in expression body
			//finalizer implicitly calls finailze on the base class of the object
			//so finilize method look like this...
			//protected override void Finalize()
			//{

			//	try
			//	{          
			//		// Cleanup statements...      
			//	}      
			//	finally
			//	{
			//		base.Finalize();//so  finilized method called recursively for all instances in teh inheritacne chain 
			//from most derived to least derived 
			//	}

			//} 

			//empty fililizer shoould not be used .when a class contains a finilizers,an entery is created in finilizer
			//queue .when the finilizer is called .the garbage collector is invoked to process the queue .an empty finilizer just
			//causes a needless loss of performance

			//C# does not require as much memory management as is needed when you develop with a locanguage that does not target a runtime grabage collection.
			//this is because the .NEt framework grabage colletor implicitly manages the allocation and release of memory
			//for your objects. however when our application encapsulates unmanaged resources such as windows ,files and network conections
			//we should use finalizers to free those resources .When the object is eligible for finilization,the garbage collector runs the 
			//finilize method of the obejct..


			//Explicit Release of resource:
			//if our applciation using an expansive exteranl resource ,we also recommened that you provide a way to explicitly
			//release the resource before the garbage collector frees the object.
			//we do by applying the Dispose method form the IDispose interface that perform the necessary cleanup for the obejct
			//this can consideribly improve the performance of the applicaiton .Event wiht this explicit control over resources,the
			//finalizer necoms a safeguard to clean up resource if teh call to the Dispose method failed..

			ThirdPoc t = new ThirdPoc();
			Console.ReadKey();



		

			}

		private static void freakExtensionMethod(this int val)
		{
			Console.WriteLine("call me");
		}

		private static void Constructors()
		{
			//whenever a class or struct is created a constructor will be called.
			//if we wont provide the the constructor c# creates one default that instantiates the obejct 
			//asn sets member bariable to teh default values as listed in the defautl values.
			//in struct ctor is porvided by compiler 

			//instance constructors:
			Location l = new Location("India");
			Console.WriteLine(l.Name);

			//static constructors:
			//it is used to initialize the static values:::
			//static ctor can not have the default ctor ...however we can have static ctor with no access modifier
			//base keyword is used to call constructor of the base class ..ctor of base class will be callled first

			//calling the constriuctor on valuetype is of no use 
			freakclass f = new freakclass("bareilly");
			Console.WriteLine(f.name + ""+f.address);
			Console.WriteLine(f.getBase);

			//ex: int i=10 ,string s="vishal" //here we can directly assign the values ..

			double radius = 2.5;
			double height = 3.0;
			CircleCtor ring = new CircleCtor(radius);
			CylinderCtor tube = new CylinderCtor(radius, height);
			Console.WriteLine("area of the circle ={0:F2}",ring.Area());
			Console.WriteLine("aread if the cylinder={0:f2}",tube.Area());




			PrivateConstructors();
			StaticConstructors();
			CopyConstructors();


		}

		private static void CopyConstructors()
		{
			PersonCopyCtor person1 = new PersonCopyCtor("Sumit", 24);
			PersonCopyCtor person2 = new PersonCopyCtor(person1);//making copy of the person1;

			//change the age
			person1.Age = 25;
			person2.Age = 22;
			person2.Name = "Vishal";
			Console.WriteLine("Details:"+person1.Details());
			Console.WriteLine("Details:"+person2.Details());


		}

		private static void StaticConstructors()
		{
			//satic ctor is use to initialize any static data,to perform a particular action that needs to be performed
			//once only.it is called automatically before the first instance is created or any static members are referenced

			//static ctor can not take access modifier
			//it is called automatically when first instance is created

			//static ctor can not be called directly

			//user has no control when static ctro will be called

			//typical use of static ctor is when the class is using a log file and the ctor is used to write 
			//entries to this file

			//it is use full to creating the wrapper classes for unmanaged code,when the ctor can call the 
			// LoadLibrary method

			//if static ctor throws an exception ,the runtime will not invoke it a second time,and the type will
			//remain uninitialized for the lifetime of the application domain in whinh your program is running
			Bus bus1 = new Bus(72);
			Bus bus2 = new Bus(73);
			bus1.Drive();

			//wait for bus2 to warm up
			System.Threading.Thread.Sleep(25);

			//send bus2 on its way
			bus2.Drive();


		}

		private static void PrivateConstructors()
		{
			//private ctor use to prevent creating the instance of the class 
		}

		private static void ConsoleApplicationWord()
		{
			DisplayInWord();
		}

		static void DisplayInWord()
		{
			var wordApp = new Application();
			wordApp.Visible = true;
			//docs is a collection of all the document obejcts currently
			//open in word

			Documents docs = wordApp.Documents;

			//add a document to the collection and name it doc
			Document doc = docs.Add();


			//define a range a contigeous area in the document ,by specifing 
			//a stating and ending character position .Currently,the document
			//is empty..

			Range range = doc.Range(0, 0);

			//use the InsertAfter method to insert a string at the end of the current range..
			range.InsertAfter("testing testing testing .....");

			range.ConvertToTable(Separator: ",",AutoFit:true,NumColumns:1,Format:WdTableFormat.wdTableFormatElegant);

		}
		

		private static void NamedAndOptionalArgument()
		{
			//c# 4 named and optional argumetns.Named arguments enables you to specify an argument for a particular parameter by 
			//associating paarameter by associating the argument with the parameter name rather than  with the paremeter 
			//positiojn in teh parameter list.
			//Optional arumetns enable you to omit argumetns for some parameters .Both techniques can be used with methods ,indexex,
			//constructors  and delegates..

			//when we use the name and optional argumenents,the argumetns are evaluated in the order in which they appear in
			//the arguments list not the parameter lsit

			//Named Arguments::

			//the method can be call in normal way ,by using positional arguments
			PrintOrderDetails("Gift Shop", 31, "Red Mug");


			//PrintOrderDetails(orderNum: 31, productName: "red mug", sellerName: "Gift Shop");

			//named argumetns can be supplied for the paraperters in any order
			PrintOrderDetails(orderNum: 31, productName: "red Mug", sellerName: "Gift Shop");
			PrintOrderDetails(productName: "red Mug", sellerName: "Gift Shop", orderNum: 31);

			//named argument with positional argument are valid
			//as long as they are used in their correct position
			PrintOrderDetails("Gift Shop", 31,productName: "red mug");
			PrintOrderDetails(sellerName: "Gift Shop", 31, productName: "Red Mug");

			//however mixed argumetns are invalid if used out-of-order
			//the following statements will cause a compiler error
			//PrintOrderDetails(productName: "Red Mug", 31, "Gift Shop");//error



			//Optional arguments:
			//the defination of a method,constructor,indexer or delegate can specify that its parameters are required or that they
			//are optional.Any call must provide argumetns for all required paramter,but can omit arguments for optioanl

			//each optional paramter has a default value as part of its defination..If no argument is sent for that paramter
			//the default value is used.A default value must be one of the following types of expression.
			//1.a const expression
			//2.an expression of teh from new ValTYpe() where ValType is a value such as an enum or a struct;
			//3.an expression of teh form default(ValType),where ValType is a value type.

			ExampleClass e = new ExampleClass();
			e.ExampleMethod(1, "one", 1);
			e.ExampleMethod(2, "Two");
			e.ExampleMethod(3);

			ExampleClass anotherExample = new ExampleClass("Provided name");
			anotherExample.ExampleMethod(2, "Two");
			anotherExample.ExampleMethod(3);


			//CE:
			//an angument must be supplied for the first parameter and it must be interger...
			//anotherExample.ExampleMethod("one", 1);
			//anotherExample.ExampleMethod();

			//can not leave the gap between the provided arguments
			//anotherExample.ExampleMethod(3,, 4);
			//anotherExample.ExampleMethod(3, 4);

			//we can use a parameter to make the previous 
			//statement work..
			anotherExample.ExampleMethod(3, optionalist: 4);//it will work 

			//Overload resolution:
			//use of named and optional arguments affects overload resolution in the following ways:
			//1.a emthod ,indexer or constructor is a condidate for execution id each of its parameter either is 
			//optionalor corresponds by name or bhy position,to a single argument in the calling statement and that 
			//argumetn can be converted to teh type of the paramter..
			//2.if more that one candidate is found ,overload resolution rules for preferred conversions are applied to the 
			// argumenets that are explicitly specidied .Ommited arguments for the optional parameters are ignored
			//3.if two condidates are judged to be equally good,prefered goes to a candidate that does not have optioanl
			//parameter for which argumetns were ommited in the call.This is a consequence of a general preference in overload
			//resolution for candidate that have fewer parameters..


 		}

		private static void PrintOrderDetails(string sellerName, int orderNum, string productName)
		{
			if(string.IsNullOrWhiteSpace(sellerName))
			{

				throw new ArgumentException(message: "seller name cannot be null or empty", paramName: nameof(sellerName));
			}
			Console.WriteLine($"seller:{sellerName},Order#:{orderNum},product:{productName}");
			
		}

		private static void ImplementAndCallACustomExtensionMethod()
		{
			string s = "the quick brown fox jumped over the lazy dog";
			int i = s.WordCountExtension();
			Console.WriteLine("WOrd count of s is:{0}",i);
			//extension method present no specific security vulnerabilities.They can never be used to impersonate existing methods on a type
			//itself .Extension methods canot access any private data in the extended class.

			
			//creating a method for enumeration
			Grades g1 = Grades.D;
			Grades g2 = Grades.F;

			Console.WriteLine("First {0} a passing grade",g1.Passing()?"is":"is not");
			Console.WriteLine("Second {0} a passing grade.",g2.Passing()?"is":"is not");

			
		}

		private static void ExtensionMethodFromMSDN()
		{
			//extension method enable us to add methods to existing types without creating a new derived type...
			//recompiling or modifing the original type..
			//extension method is special static method but they are called as if they were the instance methods on the existing types

			//the most common extension methods the LINQ standard query operators taht add query functinality to the 
			//existing System.Collections.IEnumerable and System.Collections.Generic.IEnumerable<T> types.to use
			//the standard query operator first bring then into scope with a using System,LInq directive
			//then any type that implements IEnumerable<T> appeares to have instance methods such as GroupBy,OrederBy,Average and so on..
			// we can see these additional methods in intellise statement completion when we type peroid after instance 
			// of an IEnumerable<T> type such as List<T> or Array

			int[] ints = { 10, 45, 15, 39, 21, 26 };
			var result=ints.OrderBy(g => g);
			foreach(var isd in result)
			{
				Console.WriteLine(isd);
			}
			//they are static method by called on instance method syntax
			//there first parameter specifies which type the method operates on ,and the parameter us preceded
			//by this modifier
			//Extension methods are only in scope when you explictly import the namespace into your source code wiht a using directive

			//extension method called on instance but but Intermediate Language(IL) generated by compiler translate your code into a call on 
			//static method ...Therefore pronciple of encapsulated not violates.in fact extension methods
			//canot access private varibales in the type they are extending

			//an extension method with same name with class or interface will never be called..so overriding is accepted
			//if the extension method have same name as instance mthod of class ..compiler will always bind the instacne method..

			AClass ac = new AClass();
			BCLass bc = new BCLass();
			CCLass cc = new CCLass();

			//ac.MethodA(10);//extension method
			ac.MethodB();//normal method


			//certain guidelines..
			//1.implemetn extension methods sparinglr and only when you have to .
			//2.wheneven possible ....at client side use the inheritance..

			//it will be never be calle if same signature as the method 
			//extension method are brought into scope at the namespce level.ex:if you have static classes thta
			//contain extension method in a dingle namespace named Extensionthey will all be brought into scpe by using Extension deirective

			//freakExtensionMethod();
			int i = 0;
			i.freakExtensionMethod();


		}

		private static void ImplicitlyTypedLocalVariable()//var tels the cokmpiler to infer the type from right hand side
		{
			//local variable can be declared without giving an explictly type.
			//the var kwyword instructs the compiler to infer the type of the variable
			//from the expression on the right side of the initialization statement.

			//it does not mean the variable is loosly typed or late bound or variant..
			//it can be used in for ,foreach,using 
			var val= 100;
			var val1 = "vishal";
			var arr = new []{ 1, 2, 3, 54 };
			foreach(var i  in arr)
			{
				Console.WriteLine(i);
				Console.WriteLine(val+"   "+val1);
			}
			var expr = from c in arr
					   where c == 2
					   select c;
			foreach(var va in expr)
			Console.WriteLine(va);

			//restrictions to var:
			//1.var can not be initialize to null ,declaration and initialization should be in the same line
			//2.var canot be used as field  at class scope
			
			//3.can not be used as initialization expression... 
			// int i=(i=10); //legal 
			// var i=(i=10); //illigal

			//it is usefull as query expression...
			//it is very usefull for nested generic types
			//ex:  IEnumerable<IGrouping<string,Student>>  



			//the query produces a sequence of anonymous types..
			//System.COllections.Generic.IEnumerable<????>

		}

		private static void DiffereneBetweenPassingAStructAndPassingAClassReference()
		{
			TheClass testClass = new TheClass();
			TheStruct testStruct = new TheStruct();
			testClass.wilIChange = "not changed value";
			testStruct.wilIChange = "not changed value";
			ClassTaker(testClass);
			StructTaker(testStruct);
			Console.WriteLine("Class field ={0}",testClass.wilIChange);
			Console.WriteLine("Struct field={0}",testStruct.wilIChange);
		}

		private static void StructTaker(TheStruct testStruct)//here a copy of structre is passed
		{
			testStruct.wilIChange = "you are changed";
		}

		private static void ClassTaker(TheClass testClass)//here address of obejct is passed
		{
			testClass.wilIChange = "you are changed";
		}

		private static void PassingTheReferenceParameter()
		{
			int[] arr = { 1, 2, 3 };
			Console.WriteLine("before sending ");
			//ChangeName(arr);
			ChangeNameUsingReference(ref arr);
			foreach(var i in arr)
			{
				Console.WriteLine(i);
			}

		}

		private static void ChangeNameUsingReference(ref int[] arr)
		{

			arr = new int[5] { 1, 2, 3, 4, 5};//it means only ine instance that is new int[] available in the heap that is this one

		}

		private static void ChangeName(int[] arr)
		{
			arr[0] = 1000;
			arr = new int[5] { -3, -4, -5, -6 ,-89};//in this place we have two array in heap memory one is in the caller and now creating the 
			//new object now..
			//but to restrict this problem we will use the ref so the 
		 	
		}

		private static void PassingTheParamaters()
		{
			//parameter can be passed by value and referecne ..passing by referecne enables function memebrs,method ,properties,indexex,poperator,constructors to cahnge the value 
			//of the paramter and have that change persist in the calling environment.To pass a parameter by reference with the intent to changing
			//the value ,use the ref or out keyword...to pass a parameter by referecnce with the intent 
			//of avoiding copying but nt changing the value use the in modifier...
			int arg;
			//passing by value
			//the value of args  in Main in not changed
			arg = 4;
			squareVal(arg);
			Console.WriteLine("with value"+arg);

			//passing by value
			arg = 4;
			squareRef(ref arg);
			Console.WriteLine("with reference "+arg);

			//poc for in 
			 arg = 100;
			squareIn(arg);//in ussage

			
			
			//Passing value type parameter :
			//passing the value type in the method means sending the copy in the parameters ..time taking the it is local to the mthos only...
			//
		}

		private static void squareIn(in int arg)
		{

			//arg = 100; in can not be modified by caller method

		}

		private static void squareRef(ref int arg)
		{
			arg *= arg;

		}

		private static void squareVal(int arg)
		{
			arg *= arg;
		}

		private static  void RefReturnAndRefLocals()
		{
			//from c# 7.0 supports reference return values ..a reference return value allows a method to return a reference to a varibale ,ratehr than a value back to caller
			//now  caller can choose to treat the returned variable as if it were returned by value or by reference.
			//the caller can create a new variable that is itself a reference to the returned value called a ref local...

			//what is reference return value?
			//when we pass the reference the caller kept on observing the called method any changes made in the object it will be reflecting in the obejct also..
			//it will returned the alias name for that variable(reference or so called the address)

			//restrictions include...

			//1.the return value must have life time that extends beyond the execution of the method.In Other words 
			//it cannot be a local variable in teh method that returns it.it can be an instance or static feld of the class
			//or it can be as argument passed to the method .Attempting to return a local variable generated compiler error CS8168 ,
			//"cannot return a local 'obj' by reference because it is not a ref local"

			//2.the return value canot be a the literal null.Returning null generates compiler error CS8156
			//Note:a method with ref return can return as alias to a variable whose value is currently the null(uninstansiated)
			//value or a nullable types for value type....

			//3.the return value can not be const,an inumeration member,the by value return value form a property ,or method of a class or struct 
			//violitig this rule gives CS8156 :An expression canot be used in this context because it may not be return=ned by reference..

			//ref cannot be returned form async functions..
			//two rules:
			//1.method signature includes ref keyword in front of method return type
			//2.return statement include ref keyword
			//ref Person p=ref contacts.GetContactInformation("brandie","best");//here p is the alias to the ref variable return by the 
			//the method GetCOntactInformation() ..it save the overhead of coping the variable.

			//prior to c# 7.3 now we can reinitialie the ref variable
			//ref veryloagestruct refloacl=ref veryLargestruct;
			//refLocal =ref anotehrVeryLargeStruct;//reassignment ,reflocal refers ro diffee=rent storage..

			var store = new NumebrStore();
			Console.WriteLine($"Original sequence :{store.ToString()}");
			int number = 16;
			ref var value = ref store.FindNumber(number);
			value = 100;//getting the value from the method
			Console.WriteLine($"new Sequence :{store.ToString()}");
		}

		private static void LocalFunctionWithAsyncFunction()
		{
			int result = GetMultipleAsync(6).Result;
			Console.WriteLine($"the returned value is{result:NO}");
		}

		static async Task<int> GetMultipleAsync(int secondsDelay)
		{

			//Task class is single operation that does not return a value that usually not return a 
			//value and that usually executes asynchronously...//task beased asynchronous pattern
			//because the work performed by a task ibejct typically asynchronously on a thread pool rather than 
			//synchronously on the main thread..
			//property:--isCancled,IsCompelted,IsFaulted to determind the status of the task
			//for return valeus we use the Task<TResult>


			//Console.WriteLine("Executing GetMultipleAsync....");
			//if (secondsDelay < 0 || secondsDelay > 5)
			//	throw new ArgumentOutOfRangeException("secondsDelay cannot exceed 5");

			//await Task.Delay(secondsDelay * 1000);
			//	return secondsDelay * new Random().Next(2, 20);//next method will return the value between 2 and 20..

			if (secondsDelay < 0 || secondsDelay > 5)
				throw new ArgumentOutOfRangeException("secondsDelay cannot exceed 5");
			return  await GetValueAsync();
			async Task<int> GetValueAsync()
			{
				Console.WriteLine("Executing GetValueAsync...");
				await System.Threading.Tasks.Task.Delay(secondsDelay * 1000);
				return secondsDelay * new Random().Next(2, 10);

			}


		}
	
		private static void LocalFunctionsAndExceptions()
		{
			//one of the features of local functions is that they can allow exceptions to surface immediately.
			//For method iterator ,exceptions are surface only when the returned sequence is enumerated,
			//and not when the iterator is retrived.For async methods,any exceptions thrown in an async method 
			//are observed when the returned task is awaited ..

			//without iterator function:--
			//IEnumerable<int> ienum = OddSequence(50, 110);
			//Console.WriteLine("Retrived enumerator");
			//foreach(var i in ienum)
			//{
			//	Console.WriteLine($"{i}");
			//}
			IEnumerable<int> ienum = OddSequenceWithLocalFunction(50, 100);
			Console.WriteLine("Retrived enumerator...");
			foreach(var i in ienum)
			{
				Console.WriteLine($"{i}");
			}
		}

		private static IEnumerable<int> OddSequenceWithLocalFunction(int start, int end)
		{
			if (start < 0 || start > 99)
				throw new ArgumentOutOfRangeException("start must be between 0 and 99");
			if (end > 100)
				throw new ArgumentOutOfRangeException("end must be less that or equal to 100");
			if (start >= end)
				throw new ArgumentException("start must be less than end");
			return GetOddSequenceEnumerator();
				IEnumerable<int> GetOddSequenceEnumerator()
			{
				for(int i=start;i<=end;i++)
				{
					if(i%2==1)
						yield return i;
				}
			}
		}

		private static IEnumerable<int> OddSequence(int start, int end)
		{
			
			if (start < 0 || start > 99)
				throw new ArgumentOutOfRangeException("start must be between 0 and 99");
			if (end > 100)
				throw new ArgumentOutOfRangeException("end must be less that or equal to 100");
			if (start >= end)
				throw new ArgumentException("start must be less than end");
			for(int i=start;i<=end;i++)
			{
				if(i%2==1)
					yield return i;
			}

		}

		private static void LocalFunctions()
		{
			//starting with C# supports local functions.Loca functions are private methods of a type are nested in another method 
			//They can only be called from their containing member
			//Local function can be declared in and called from:
			//1.Methods(specially iterator methods and async methods)
			//2.Constructors 
			//3.Property accessors
			//4.Event accessors
			//5.Anonymous methods
			//6.Lamda expressions 
			//7.FInalizers
			//8.otehr local functions..
			//however local functions cant be declared inside an expression-bodied member.

			//Note:in some cases,you can use lamda expression to implement functionality also 
			//supported by a local function .
			//it is not collable only by container method..
			//local function can use async and unsafe modifiers...
			//all variables and parameter of containing method are assicible from local function...
			//access modifier can not be used here in local function not private,not static otherwise we will get CS)106 compiler error..

			Console.WriteLine(localFunction());

			string localFunction()
			{
				return "I am local function";
			}

		}

		private static void Iterators()
		{
			//an iterator perform custom iteration over a collections such as list and array..
			//an iterator uses the yeild return statement to return each element one at a time
			//when a yeild return statemtnt is reached ,the current location in code is remembered.
			//Execution is restarted from that location the iterator is called the next time.

			//we call the iterator from client code using foreeach() statemnet
			//the return type of iteraot is IEnumerable,IEnumerable<T>,IEnumerator<T> or IEnumerator<T>



		}

		private static void Methods()
		{
			//method signature:NameOfTheMethod+NoOfArgumentsOfTheMethod
			//return type is part of method signature only on time campatibility ex:between delegate and the method to which it is pointing to... 

			//passing by reference vs passing by value:
			//by default when we pass the value into the function it is passed by value but if we
			//want to pass the value type then we can use by ref keyword
			//when we pass the object ...it's reference is passed to the function thats it..
			EMPLOYEE e = new EMPLOYEE();
			e.Name = "vishal singh";
			e.ExtensionForEmployee();//earlier name
			changeName(e);
            e.ExtensionForEmployee();//after change
			//we can use the ref keyword while returning the values from methods..to use it we need
			//to use ref keyword
		}

		private static void changeName(EMPLOYEE e)
		{
			e.Name = "Freak Employee";
		}
		private static void ExtensionForEmployee(this EMPLOYEE emp)
		{
			Console.WriteLine(emp.Name);
		}
		private static void LightWeightClassExample()
		{
			string[] names = { "Vishal singh", "Sumit kiran Gurav", "Prasob", "Tejas", "shubham", "Vamsi" };
			string[] address = { "bareilly", "kohlapur", "Wayer", "Ratnagiri", "kashipur", "south" };

			//object creation using select clause using linq namespace 
			var query1 = from i in Enumerable.Range(0, 5)
						 select new Contact(names[i], address[i]);

			//list code cannot be modified by client code 
			var list = query1.ToList();
			foreach(var contact in list)
			{
				Console.WriteLine("{0} ,{1}",contact.Name, contact.Address);
			}

			//create contact2 object by using a static factory method
			var query2 = from i in Enumerable.Range(0, 5)
						 select Contact2.CreateContact(names[i], address[i]);

			//console output is identical to query1
			var list2 = query2.ToList();

			//list elements cannot be modified by client code
			
			//list[0].name="vishal"//compiler error
		}

		private static void AccessModifiersOnOverridingAccessors()
		{
			BaseClassForProp b1 = new BaseClassForProp();
			DerivedClassForProp d1 = new DerivedClassForProp();
			b1.Name = "Vishal";
			d1.Name = "Sumit";

			b1.Id = "vishal123";
			d1.Id = "sumit123";
			Console.WriteLine("Base {0} {1}",b1.Name,b1.Id);
			Console.WriteLine("Derived {0} {1}",d1.Name,d1.Id);

		}

		private static void EqualMethodsInCSharp()
		{
			//== returns true for valueTypes 
			//for reference types it will return if both operands referes to the same object(reference comparision)
			//except string all reference types compare the reference...

			//values types:
			//var val1= DateTime.Now.Date;
			//var val2 = DateTime.Now.Date;
			//Console.WriteLine(val1==val2);//true

			//var sb1 = "vishal";
			//var sb2 = new StringBuilder("vis");
			//sb2.Append("hal");
			//var sb3 = sb2.ToString();
			//Console.WriteLine(sb1==sb3);//true
			//Console.WriteLine(object.ReferenceEquals(sb1,sb2));//false

			var v1 = new Uri("http://vishal.com");
			var v2 = new Uri("http://vishal.com");
			Console.WriteLine(v1==v2);//true..compare the values ...ex:string,uri,version
			Console.WriteLine(object.ReferenceEquals(v1,v2));//false..compare the references 
			Console.WriteLine(v1.Equals(v2));//for dynamic types we use Equals() metod will be used...its an virtual method do it will be called accordingly 
			//var v3 = new Version(1, 2, 3);
			//var v4 = new Version(1, 2, 3);
			//Console.WriteLine(v3==v4);
			//Console.WriteLine(object.ReferenceEquals(v3,v4));

		}

		private static void ExtensionMethod()
		{
			IEmployee e = null;
			e.ExtensionMethod();
			Func<int, string> fun=null;
			Action<int> ac = null;
			ac.ActionFun(10);
			Console.WriteLine(fun.FunctionExtension(19));
		}

		private static void PropertiesExample()
		{
			//properties enable a class to expose a public 
			//way of getting as setting values,while hiding implementation or varification code
			//value is used to define access levels ..
			//read/write or readonly property..
			//private backing field
			//TimePeriod tp = new TimePeriod();
			//tp.Hours = 24;
			//try
			//{
			//	Console.WriteLine("please enter the hours");
			//	tp.Hours = int.Parse(Console.ReadLine());
			//}
			//catch(CustomExceptionForTimePeriod ex)
			//{
			//	Console.WriteLine(ex.StackTrace);
			//}
			//finally {
			//	Console.WriteLine("final block");
   //            }
			//Console.WriteLine($"Time in hours:{tp.Hours}");
			
			//after c# 6.0 we can give define property without body there is no need 
			//to give the return keyword also
			//  public string Name => $"{firstName} {lastName}"; 

			//after c# 7.0 we can give like this..
			//  public string Name 
			//      {      
			//         get => name;
			//         set => name = value;   
			//      }

			//auto implemented property
			// public string Name
			//{ get; set; }
			// var item = new SaleItem{ Name = "Shoes", Price = 19.95m };




			Manager man = new Manager();
			//derived class property
			man.Name = "John";

			//base class property
			((EMPLOYEE)man).Name = "Mary";
			//Console.WriteLine(man.Name);//stack overflow exception
			Console.WriteLine("Name  in the base class is :{0}",((EMPLOYEE)man).Name);

			//abstract property:
			Console.WriteLine("Enter the side : ");
			double side = double.Parse(Console.ReadLine());

			SquarePropPOC s = new SquarePropPOC(side);
			CubePropPOC c = new CubePropPOC(side);

			Console.WriteLine("Area of the square={0:F2}",s.Area);
			Console.WriteLine("Area of the cube={0:F2}",c.Area);

			Console.WriteLine("Area of the square={0:F2}",s.side);
			Console.WriteLine("side of the cude={0:F2}",c.side);


			Console.WriteLine("Enter the number of employees");
			EmployeeProp.numberOfEmployees = int.Parse(Console.ReadLine());
			EmployeeProp e1 = new EmployeeProp();
			Console.WriteLine("Enter the name of the new employee");
			e1.Name = Console.ReadLine();
			Console.WriteLine("The EMployee information");
			Console.WriteLine("Employee number:{0}",e1.Counter);
			Console.WriteLine("Employee name:{0}",e1.Name);

			//restricting accssor accessibility
			//the get and set portions of a property or indexex are called accessors.By default these accessors have the same
			//visibility ,or access level :that of the property or indexex
			//1.can not use accessor modifier on an interface or an explicit interface memeber implementation
			//2.can only use access modifier only if the property or indexex has both set and get accessors.In this case 
			//the modifier is permitted on one only of teh two accessors.
			//3.if override property or index has an override must be more match the accessor of the overriden accessor.
			//4.the accessibility level on the accessor must be more restrictive than the accessibility level on
			//the property or indexer itself


		}

		private static void Constants()
		{
			//consts are build at compile time only can not build it run time 
			//Use caution when you refer to constant values defined in other code such as DLLs.
			//If a new version of the DLL defines a new value for the constant, your program 
			//will still hold the old literal value until it is recompiled against the new version.
			Program p = new Program();
			Console.WriteLine(Program.constVariable);//const are binded at compile time ..once assign can not be change
		}

		private static void Fields()
		{
			//in static fields we create only one field and share that static variable to other instances
			//generally we use fields for varaible that have private or protected accessibility.
			//data that our class exposes to client code should be provided through method ,properties and indexes.
			//by using these constructs for indirect access to interncal foelds we can guard against invalid input values .
			//A private field that stores the data exposed by a public property is called a backing store or backing field.
			CalenderEntry ce = new CalenderEntry();
			ce.SetDate("06-11-2018");
			try
			{
				Console.WriteLine(ce.GetTimeSpan("06-11-2018"));
			}
			catch(CustomException ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
			finally
			{
				Console.WriteLine("Every thing executed sucessfully");
			}
		}

		private static void AccessModifiersInCSharp()
		{
			TriCycle t = new TriCycle();
			Console.WriteLine(t.Wheels);
			Base b = new Base();//private protected example
			//b.M();//private for  this obejct
			D1 d = new D1();
			d.M();//protected helping this class to get the thing across
		}

		private static void MembersInCSharp()
		{
			//field :are variable decalred in the csharp 

			//constants:constants are fields or properties whose calue is set at compile time and cannot de changed.

			//properties: Properties are methods on a class that are accessed as if they were fields on that class .
			//A property can provide protection for a class field to keep it form being changed without the knowledge 
			//of the object

			//Methods: method define the actions that the class perform...

			//Events:Events provides occurences such as button clicks or sucessful complettion of a method ,to other 
			//object ,Events are defined and triggred by using delegates..

			//operators:Overloaded operators are considered class members .When you overload an operator ,you define 
			//it as a public static in a class .the predefined operators (+,*,< and so on)

			//Indexes:Indexers enable an obejct to b e indexed in a manner similar to arrays.

			//constructors:Constructors are methods that are called when the obejct is first created .They 
			//are ofthen used to initialise the data of an object..
			//are ofthen used to initialise the data of an object..


			//Finalizers:Finilizers are used very rarely in C#.They are methods that are called by the runtime 
			//execution engine when the object is about to be removed form memory.

			//NestedTypes:Nested types are types declared within another type .Nested types are often used to 
			//describe objects that use only by the types that contain them..
		}

		private static void StaticClassExample()
		{
			//cantains only static members;
			//cannot be instansiated.
			//is sealed
			//canot contain instance constructors.
			//retains always in the memory first static s things are loaded into the memory
			//static variable is used in sharing some common resource(resourcename,db name password etc) or to count the instance of the class...
			Console.WriteLine("Enter the convertor direction ");
			Console.WriteLine("1. From Celsius to Farenheit.");
			Console.WriteLine("2. From Fahrenheit to celcius");
			Console.WriteLine(":");
			string selection = Console.ReadLine();
			double F, C = 0;
			switch (selection)
			{
				case "1":
					Console.WriteLine("Please enter the celsius temprature");
					F = TempratureConverter.CelsiusToFahrenheit(Console.ReadLine());
					Console.WriteLine("Temprature in fahrenheit :{0:F2}", F);
					break;
				case "2":
					Console.WriteLine("Please enter the fahrenhiet temprature :");
					C = TempratureConverter.FahrenheitToCelsius(Console.ReadLine());
					Console.WriteLine("Temprature in Celcius:{0:F2}", C);
					break;
				default:
					Console.WriteLine("please enter the convertor");
					break;
			}

			Console.WriteLine("Press any key to exit: ");
			Console.ReadKey();

		}

		private static void DefiningAbstractProperties()
		{
			AShape[] shapes =
			{
				new DSquare(55,"Square"),
				new DCircle(33,"Circle"),
				new DRectangle(44,33,"Rectangle")
			};
			foreach(AShape s in shapes)
			{
				Console.WriteLine(s);
			}
		}

		private static void AbstractAndSealedClassAndClassMembers()
		{
			D d = new F();
			d.DoWork(10);
		}

		private static void OverideToStringMethod()
		{
			Student s = new Student();
			s.Name = "Vishal singh";
			s.StudentId = 99;
			Console.WriteLine(s);
		}

		private static void OverrideANdNEwKeyWord()
		{
			//B b = new B();
			//b.Method1();
			//C c = new C();
			//c.Method2();
			//B bcdc = new C();
			//bcdc.Method1();

			//but if we will give method2 in both classes it will show warning that metho2 in derived class d=hides method in base class method2 either use new or rename the method
			//B b = new B();
			//b.Method2();//method 2 form B
			//C c = new C();
			//c.Method2();//method 2 from C
			//B bc = new C();
			//bc.Method2();//method 2 from B ..without using the new keyword it wont hide the method


			//after using new keyword there
			//B b = new B();
			//b.Method2();
			//C c = new C();
			//c.Method2();
			//B bc = new C();
			//bc.Method2();//true method hiding

			//Car c = new Car();
			//c.DescribeCar();//base call method will be called
			//Canvertible can = new Canvertible();
			//can.DescribeCar();//base claa method will be called because of new 
			//Minivan m = new Minivan();
			//m.DescribeCar();//overriden method will be called 

			////runtime polymorphism:
			//var cars = new List<Car> { new Car(), new Canvertible(), new Minivan() };
			//foreach (var car in cars)
			//{
			//	car.DescribeCar();//rutime polymorphism
			//}

			//Car c = new Canvertible();
			//c.DescribeCar();
			
			
		}

		private static void OverrideAndMethodSelection()
		{
			C c = new C();
			c.DoMoreWork(10);//it will call more suitable method ...double can be converted in int implecitly
			B b = (B)c;
			b.DoMoreWork(10);
		}

		private static void PreventingDerivedClassFromOverridingVirtualMembers()
		{
			C c = new C();
			//c.DoWork();
			A a = new C();
			a.DoWork();//here it will call b always beacse we are calling it on a reference so virtual inheritance will be fololowed
		}

		private static void HidingBaseClassMembersWithNewMembers()
		{
			//to stop it froms virtual invocation...now this is seperate method by suign new keyword 
			DerivedClass dc = new DerivedClass();
			dc.DoWork();//calls the new Method

			BaseClass a = (BaseClass)dc;
			a.DoWork();//calls the old method
		}

		private static void RuntimeOverview()
		{
			//fields can not be virtual ,only methods ,properties ,events and indexes can be virtual .when a derived class overrides
			//a virtual member,that member is called even an instance of that class is being accessed as an instance of the base class 
			DerivedClass B = new DerivedClass();
			B.DoWork();
			BaseClass A = (DerivedClass)B;
			A.DoWork();//also call the new method

		}

		private static void RuntimePolyMorphism()
		{

			// Polymorphism at work #1: a Rectangle, Triangle and Circle
			// can all be used whereever a Shape is expected. No cast is        
			// required because an implicit conversion exists from a derived         
			// class to its base class.
			var shapes = new List<Shape>
			{
				new Rectangle(),
				new Triangle(),
				new Circle()
			};
			// Polymorphism at work #2: the virtual method Draw is        
			// invoked on each of the derived classes, not the base class.        
			foreach (var shape in shapes)
			{
				shape.Draw();
			}
			// Keep the console open in debug mode.        
			Console.WriteLine("Press any key to exit.");
			Console.ReadKey();

		}
	}
}
