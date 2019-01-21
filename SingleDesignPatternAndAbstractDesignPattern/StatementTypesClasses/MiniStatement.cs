using SingleDesignPatternAndAbstractDesignPattern.Interfaces;
using System;

namespace SingleDesignPatternAndAbstractDesignPattern.StatementTypesClasses
{
	public class MiniStatement : StatementType
	{
		public string Print()
		{
			Console.WriteLine("MiniStatement Created");
			return "miniStmt";
		}
	}
}
