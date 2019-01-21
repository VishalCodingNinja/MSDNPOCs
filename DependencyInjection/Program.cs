using System;
using System.Reflection;
using DependencyInjection.Container;
using DependencyInjection.Models.Classes;
using DependencyInjection.Models.Interfaces;

namespace DependencyInjection
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(new Container<IStudent, Student>().GetTransientInstance.ObjectName);
			Console.WriteLine(new Container<IStudent, Student>().GetSingletonInstance.Value.ObjectName);
			Type ti = typeof(Student);
			ConstructorInfo[] info= ti.GetConstructors();
			var ctor = info[0];
			foreach (var tor in ctor.GetParameters())
			{
				string name = tor.ToString();
				string[] arr = name.Split(" ");
				Type ty=Type.GetType(arr[0]);
				var instance=Activator.CreateInstance(ty);

				Console.WriteLine(instance);

				//Activator.CreateInstance(tor);
			}

		}

		public static   void FreakOperations()
		{
			Type ti = typeof(Student);
			ConstructorInfo[] info = ti.GetConstructors();
			var ctor = info[0];
			object instance;
			foreach (var tor in ctor.GetParameters())
			{
				string name = tor.ToString();
				string[] arr = name.Split(" ");
				Type ty = Type.GetType(arr[0]);
				instance= Activator.CreateInstance(ty);

				

			}

			
		}
	}
	
}
