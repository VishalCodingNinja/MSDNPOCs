using System;

namespace SolidPrinciplesPOCs
{
	interface IServiceLayer
	{
		bool RegisterUser();
	}
	internal class ServiceLayer:IServiceLayer
	{
		
		public bool RegisterUser()
		{
			int choice = 1;
			do
			{
				Console.WriteLine("Enter your choice");
				Console.WriteLine("1. for gold customer ");
				Console.WriteLine("2. for silver customer");
				Console.WriteLine("3. for Enquiry");
				Console.WriteLine("4. for Admin");
				Console.WriteLine("0 for exit");
				choice = int.Parse(Console.ReadLine());
				switch (choice)
				{
					case 1:
					case 2:
					case 3:
					case 4:
			       DataLayer.RegisterUserWithMenu();
						break;

					default:
						break;
				}
			} while (choice != 0);
			return true;
		}

		
	}
}
