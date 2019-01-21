using SingleDesignPatternAndAbstractDesignPattern.Interfaces;
using SingleDesignPatternAndAbstractDesignPattern.StatementTypesClasses;
using System;

namespace SingleDesignPatternAndAbstractDesignPattern
{
	public class StatementFactory: AbstractFactoryDesignClass
	{
		private static readonly Lazy<StatementFactory> lazy = new Lazy<StatementFactory>(() => new StatementFactory(),true);
		private StatementFactory()
		{

		}
		public static StatementFactory GetUniqueInstance
		{
			get
            {
				return lazy.Value;
			}
		}
		override public StatementType CreateStatements(string selection)
		{
			if(selection== "detailedStmt")
			{
				return new DetailedStatement();
			}
			else if(selection== "miniStmt")
			{
				return new MiniStatement();
			}
			throw new InvalidStatementException("Invalid Statement");
		}

		
	}
}
