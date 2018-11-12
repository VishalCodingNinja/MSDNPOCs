using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegatesByDanWahlin
{
	class ProcessData
	{
		public void Process(int x,int y,BizRulesDelegate del)
		{
			var result=del(x, y);
			Console.WriteLine(result);
		}
		public void ProcessAction(int x,int y,Action<int,int> action)
		{
			action(x, y);
			Console.WriteLine("action executed sucessfully");
		}
		public void ProcessFunc(int x,int y,Func<int,int,int> func)
		{
			func(x, y);
			Console.WriteLine("func executed sucessfully");
		}
	}
}
