using System;
using System.Data.Entity;
using System.Linq;

namespace FreakEntity
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter your name");
			string name = Console.ReadLine();
			Console.WriteLine("Enter your address");
			string address = Console.ReadLine();
			Employee employee = new Employee(name, address);
			Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DbEmployee>());
			DbEmployee db = new DbEmployee();
			db.Employees.Add(employee);
			db.SaveChanges();
			var _employee = from emp in db.Employees
							orderby emp.Name descending
							select emp.Name;
			foreach (var item in _employee)
			{
				Console.WriteLine(item);
			}

		}
	}
	class DbEmployee:DbContext
	{
		public DbSet<Employee> Employees { get; set; }
	}
	public class Employee 
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public Employee(string name, string address)
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

}
