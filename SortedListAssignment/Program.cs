using MSDNPOCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedListAssignment
{
	class Program
	{
	static int _count=0;
		static void Main(string[] args)
		{
			
			Menu();
			//SortedListExampleTheory();
		}

		private static void Menu()
		{
			var _sortedlist = new SortedList<int, Employee>();
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
						AddObject(_sortedlist);
						break;
					case 2:
						RemoveObject(_sortedlist);
						break;
					case 3:
						ToSeeTheList(_sortedlist);
						break;

					default:
						break;
				}

			} while (_flow != 0);
			Console.Clear();
			Console.WriteLine("Exited");



		}
		

		

		private static void ToSeeTheList(SortedList<int, Employee> sortedlist)
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

		private static void RemoveObject(SortedList<int, Employee> sortedlist)
		{
			foreach (var item in sortedlist)
			{
				Console.WriteLine("index :"+item.Key+" Employee details are:"+item.Value);
			}
			Console.WriteLine("Enter the index of employee you want to delete");
			int i=int.Parse(Console.ReadLine());
			bool _check=sortedlist.Remove(i);
			if(_check)
			Console.WriteLine("Employee remove sucessfully");
			else
				Console.WriteLine("Enter valid index");
		}

		private static void AddObject(SortedList<int, Employee> sortedlist)
		{
			Console.WriteLine("Enter the name of employee");
			string name = Console.ReadLine();
			Console.WriteLine("Enter the address of the employee");
			string address = Console.ReadLine();
			sortedlist.Add(_count, new Employee(name, address));
			Console.Clear();
			Console.WriteLine("Employee Added Sucessfully");
			_count++;
			
		}


		
		private static void SortedListExampleTheory()
		{
			//represent a collection of key/value that are sorted by the keys and are accessible by key and by indexs 		
			//Attribute:[System.Runtime.InteropServices.ComVisible(true)]
			//[Serializable]
			//public class SortedList:ICloeable,System.Collection.IDictionary
			//inheritance Object->SortedList
			//Attributes ComVisibleAttribute,SerializableAttribute
			//implements ICollection,IDictionary,IEnumerable,ICloneable
			//A sortedlist element can be accessed by its keys ,like an element in any IDictionary implementation,or
			//by its index,like an element in any IList implementation

			//as MSDN recommend generic System.Collection.Generic.SOrtedList<TKey,TValue> class.


			//A SortedList internally maintains two array :for key ,for value
			//each element is a kye/value pair that can be accessed as a DIctionaryEntry
			//object .A Key canot be null,but a value can be..

			//the no of element is added then capacity automatically increased 
			//through reallocation

			//capacity can be decrease by calling TrimToSize,or by setting Capacity property

			//for large SortedList object we can increase the maximum capacity to 2 billion elements
			//on 64-bit system by setting the enebled attribute of the configuration element
			//to true in teh run-time environemnt.

			//The elements of the SortedList object are stored by keys either according to a sepecific
			//IComparer implementation specific when the SOrtedList is created 
			//or according to the IComparable implementation provided by the keys 
			//themselves.In either case a SortedList does not allow duplicaties keys

			//the index sequence is based on the sort sequence.When an element is added it is 
			//inserted into SortedList in the correct sort order 
			//and tje indexing adjusts accordingly .WHen an element is removed the indexing also adjusts 
			//accordingly.Therefore the index of a specific key/value pair might
			//change as elements are added or removed from the sortedList object.

			//operation on sorted list is slower than operation on Hashtable because of sorting
			//however the sortedlist offers more flexiblity by alloowing access to the values
			//either through the associated keys or through the indexes.

			//in foreach the returned type is DictionaryEntry

			//SortedList():Initializes a new instance of the sortedlist class that is empty.has teh default initial capacity and is sorted
			//accoring to the IComparable interfcae inmpelented by each key added to teh SortedList object.

			//SortedList(IComparer):Initializes a new instance of the SortedList class that is empty
			//has the default inititla capacity and is sorted according to the specific IComparer interface

			//SortedList(IDictionary):initialize the new instance of teh SOrtedList class that contains copied from teh 
			//specific dictionary ,and sorted according to IComparable interface implementeed by each key

			//SortedList(IDictionary, IComparer):initialize a new instance of the sortedlist class that contains elemtns copied from the soecificd dictionary 
			//has the same initial capacity

			//Properties:
			//Capacity
			//Count
			//IsFixedSize
			//IsReadOnly
			//IsSynchronized
			//Item[Object]
			//Keys
			//SyncRoot:-Gets an object that can be used to synchronize access to a SortedList object.
			//Values:Gets the value in a SortedList Object

			//Methods:
			//Add(object,obejct):add at specific index
			//Clear():remove all elements form SortedList object
			//Clone():creates a shallow copy
			//Contains(Object) :Determine whether a SortedList constains a specific key
			//ContainsKey(Object):Determine whether a sortedlist object contains a specific key
			//ContainsValue(object):Determine whether a sortedlist object contains a specific value
			//CopyTo(Array,int32):comies SortedList elements to a one-dimentional Array object,starting at the 
			//specific index in the array

			//Equals(Object):Determine whether the obejct is equal or not..
			
			//GetBIndex(Int32):get the value from the specific index..
			//GetIEnumerator():returns an IDictionaryEnumerator object that iterate through a sortedlist object
			//GetHashCode() :Serves as teh default hash function 
			//GetKey(int32): gets the key at specific index of teh SOrtedList obejct
			//GetKeyList():Get keys at the specific index of a sortedlist object

			//GetType():Gets the type of the current instance 
			//GetValueList():get the value in a SOrtedList obejct

			//IndexOfKey(Object) :return the index of specific key
			//IndexOfValue(Object):Returns the zero based index of teh specified value
			//in a sortedList obejct
			//MimberwiseClone() :creates a shallow copy of the current obejct

			//Remove(Obejct):Remove the element with the specific index of a SortedLsit
			//obejct

			//RemoveAt(int32,Object):removes the value ar a specific index in a SortedList object

			//Synschonized(SortedList):returnes a synchronized (threadsafe) wrapper for 
			//a sortedList obejct

			//toString() :returns a string that represents the cirrent objlect
			//TrimToSize() :sets the capacity to the actual number of the elemetns in a SortedList obecjt.


			//Explicit interface IMplementations:
			//IEnumerable.GetEnumerator() :returns an IEnumerator that iterates through the sortedList

			//Extension mehtods:
			//cast<Tresult>(IEnumerable) :case the elements of an IEnumerable to the specific type.
			//OfType<TResult>(IEnumerable):Filter teh elements of an IEnumerable based on a specified type
			//AsParallel(IEnumerable):Enables paralletition of a query

		}
	}
	public class Employee
	{
		private string _name;
		private string _address;
		public Employee(string name,string address)
		{
			Name= name;
			Address = address;
		}
		public string Name {
			get { return _name; }
			set { if (_name != null || _name != "") _name = value; }
		}
		public string Address {
			get { return _address; }
			set { if(_address!=null||_address!="")_address = value; }
		}
		public override string ToString()
		{
			return "Name is:" + Name + " Address is" + Address;
		}
	}
}
