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




		}
	}
}
