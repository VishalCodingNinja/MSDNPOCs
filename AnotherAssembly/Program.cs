using MSDNPOCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherAssembly
{

	class Program
	{
		static void Main(string[] args)
		{
			DerivedMobile d = new DerivedMobile();
	 		Console.WriteLine(typeof (Mobile).AssemblyQualifiedName);
			Console.WriteLine(typeof (Program).AssemblyQualifiedName);
		}
	}
	public class DerivedMobile : Mobile
	{

		
	}
}
