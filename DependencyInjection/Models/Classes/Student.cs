using System;
using System.Collections.Generic;
using System.Text;
using DependencyInjection.Models.Interfaces;

namespace DependencyInjection.Models.Classes
{
	public class Student:IStudent
	{
		private Student _freak;
		private Teacher _jert;
		private Principle _literals;

		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }

		public string ObjectName => "Student";

		public Student(Student freak,Teacher jert,Principle literals)
		{
			_freak = freak;
			_jert = jert;
			_literals = literals;
		}

		public Student()
		{
			Console.WriteLine("I am created");
		}
	}
}
