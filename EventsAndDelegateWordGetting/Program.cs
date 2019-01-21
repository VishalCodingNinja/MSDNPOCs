using System;

namespace EventsAndDelegateWordGetting
{
	class Program
	{
		
		static private readonly MyWordClass _instance = new MyWordClass();
		 static void Main(string[] args)
		{
			
			GetTheSentanceAndPutItIntoTheObjectIndexers();
			 
			_instance.eventPallindrome += CheckPallindrome;

			_instance.CheckPallindrome(_instance[1]);
			
			
		}

		private static void GetTheSentanceAndPutItIntoTheObjectIndexers()
		{
			Console.WriteLine("Enter any sentance");
			string str = Console.ReadLine();
			
			int i = 0;
			string[] arr= str.Split(' ');
			
			foreach(string sen in arr)
			{
				_instance[i] = sen;
				i++;
			}
			

		}
		public static void CheckPallindrome(object sender,StringClass e)
		{
			
			if (e != null)
			{
				string oldString = e.CheckStr;
				char[] ch = e.CheckStr.ToCharArray();
				Array.Reverse(ch);
				string newString = new string(ch);

				if (oldString != newString) {
					Console.WriteLine("{0} :::Its not a  pallindrome",oldString);
				}
				else
				{
					Console.WriteLine("{0} :::::is an pallindrom string at 1 index",oldString);
				}
			}
		}
	}
}
