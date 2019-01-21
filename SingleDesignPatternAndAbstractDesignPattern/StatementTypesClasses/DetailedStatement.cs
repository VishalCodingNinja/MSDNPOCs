using SingleDesignPatternAndAbstractDesignPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleDesignPatternAndAbstractDesignPattern.StatementTypesClasses
{
	public class DetailedStatement : StatementType
	{
		public string Print()
		{
			Console.WriteLine("Detailed Statement Created");
			return "detailedStmt";
		}
	}
}
