using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
namespace Freak_Solid_Principles
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var context = new SchoolContext())
			{

				//var std = new Student()
				//{
				//	Name = "Sumit c"
				//};

				//context.Students.Add(std);
				//context.SaveChanges();



				var AllStudentsList = context.Students.Where(e => e.Name == "Vishal Singh Sri vastava").ToList();
				foreach (var item in AllStudentsList)
				{
					Console.WriteLine(item.Name);
				}
				
			}


		}
	}
	public class SchoolContext:DbContext
	{
		public DbSet<Student> Students { get; set; }
		public DbSet<Course> Courses { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;");
		}
	}
	public class Student
	{
		public int StudentId { get; set; }
		public string Name { get; set; }
	}

	public class Course
	{
		public int CourseId { get; set; }
		public string CourseName { get; set; }
	}
}
