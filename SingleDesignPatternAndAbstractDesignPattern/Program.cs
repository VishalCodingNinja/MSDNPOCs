using SingleDesignPatternAndAbstractDesignPattern.Interfaces;
using System;

namespace SingleDesignPatternAndAbstractDesignPattern
{

	class Client
	{
		static void Main(string[] args)
		{
			AbstractFactoryDesignClass factory = StatementFactory.GetUniqueInstance;
			GetOptions(factory);
		}

		private static void GetOptions(AbstractFactoryDesignClass factory)
		{
			Console.WriteLine("Enter Your selection");
			StatementType _obj = null;
			int choice;
			do
			{
				Console.WriteLine("1 for Ministatement");
				Console.WriteLine("2 for Detail Statement");
				Console.WriteLine("0 to abort the transaction");
				choice = int.Parse(Console.ReadLine());
				switch (choice)
				{
					case 1:
						Console.Clear();
						try
						{
							_obj = factory.CreateStatements("miniStmt");
							_obj.Print();
							Console.WriteLine("\n \n \n \n");
						}
						catch (InvalidStatementException ex)
						{

							Console.WriteLine(ex.StackTrace);
						}
						break;
					case 2:
						try
						{
							_obj = factory.CreateStatements("detailedStmt");
							_obj.Print();
						}
						catch (InvalidStatementException ex)
						{

							Console.WriteLine(ex.StackTrace);
						}
						break;
					default:
						Console.WriteLine("Please Enter valid Input");
						break;
				}
			} while (choice != 0);
		}
	}
	
	
}
