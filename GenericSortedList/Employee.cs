using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSortedList
{
	public class Employee:IComparable<Employee>
	{
		private string _name;
		private string _address;
		public Employee(string name, string address) 
		{
			Name = name;
			Address = address;
		}
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}
		public string Address
		{
			get { return _address; }
			set { _address = value; }
		}

		public int CompareTo(Employee obj) 
		{

			return this.Name.CompareTo(obj.Name);
		}

		public override string ToString()
		{
			return "Name is:" + Name + " Address is" + Address;
		}
	}
}
