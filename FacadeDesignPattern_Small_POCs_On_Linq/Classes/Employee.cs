using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{

	public interface IEmployee
	{
		 int Age { get; set; }
		 int Income { get; set; }
		 string FavoriteCafe { get; set; }
		 string Name { get; set; }
	}
	public class SoftwareEngineer:IEmployee
	{
		private int _age;
		private int _income;
		private string _favoritecafe;
		private string _name;
		
		public int Age
		{
			get { return _age; }
			set { _age = value; }
		}
		public int Income
		{
			get { return _income; }
			set { _income = value; }
		}
		public string FavoriteCafe
		{
			get { return _favoritecafe; }
			set { _favoritecafe = value; }
		}
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		

		
	}
	public class ProjectManager : IEmployee
	{
		private int _age;
		private int _income;
		private string _favoritecafe;
		private string _name;
		private Project _project;

		public ProjectManager()
		{
		}

		public int Age
		{
			get { return _age; }
			set { _age = value; }
		}
		public int Income
		{
			get { return _income; }
			set { _income = value; }
		}
		public string FavoriteCafe
		{
			get { return _favoritecafe; }
			set { _favoritecafe = value; }
		}
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		

		public Project ProjectM
		{
			get { return _project; }
			set { _project=value; }
		}
	}
	public class Project
	{
		public string ProjectName { get; set; }
		public string StartDate { get; set; }
		public string DueDate { get; set; }
		public Project(string projectname,string Start,string duedate)
		{
			ProjectName = projectname;
			StartDate = Start;
			DueDate = duedate;
		}
	}
	public class HR:IEmployee
	{
		private int _age;
		private int _income;
		private string _favoritecafe;
		private string _name;
		
		public int Age
		{
			get { return _age; }
			set { _age = value; }
		}
		public int Income
		{
			get { return _income; }
			set { _income = value; }
		}
		public string FavoriteCafe
		{
			get { return _favoritecafe; }
			set { _favoritecafe = value; }
		}
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		
	}
}
