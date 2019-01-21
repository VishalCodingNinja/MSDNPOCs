using System;

namespace SolidPrinciplesPOCs
{
	public interface ILogger
	{
		void Handle(string stackTrace);
	}
	public class FileLogger : ILogger
	{
		public void Handle(string stackTrace)
		{
			System.IO.File.WriteAllText(@"C:\Users\Public\TestFolder\WriteText.txt", stackTrace);
		}
	}
	public class DataBaseLogger : ILogger
	{
		public string Exception { get; set; }
		public void Handle(string stackTrace)
		{
			Console.WriteLine("DataBase Logger");
		}
	}
	public class EmailLogger : ILogger
	{
		public void Handle(string stackTrace)
		{
			Console.WriteLine("email logger");
		}
	}

}