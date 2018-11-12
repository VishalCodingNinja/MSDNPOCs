using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegatesByDanWahlin
{
	public delegate int BizRulesDelegate(int x, int y);

	class Program
	{

		
		static void Main(string[] args)
		{
			//BizRulesDelegate addDel = (x, y) => x + y;
			//BizRulesDelegate multiplyDel = (x, y) => x * y;

			//var data = new ProcessData();
			//data.Process(2, 3,addDel);
			//data.Process(3, 4, multiplyDel);


			//build in delegate...
			var data = new ProcessData();
			Action<int, int> action = (x, y) => { Console.WriteLine("Exectuting action here"); };
			data.ProcessAction(1, 2, action);

			Func<int, int, int> funcAddDel = (x, y) => x + y;

			data.ProcessFunc(1, 2, funcAddDel);

			var custs = new List<Customer>
			{
				new Customer{City="KolhaPur",FirstName="Sumit Kumar",LastName="Gurav",ID=1},
				new Customer{City="Bareilly",FirstName="Vishal",LastName="Singh",ID=2},
				new Customer{City="unKnown",FirstName="Prosob",LastName="C......",ID=3},
				new Customer{City="unKnown",FirstName="Vamsi",LastName="a....",ID=4}
			};
			var phxCusts = custs
						  .Where(c => c.City == "unKnown")
						  .OrderBy(c=>c.FirstName);

			foreach (var cust in phxCusts)
			{
				Console.WriteLine("FirstName  :"+cust.FirstName+" LastName   :"+cust.LastName+" Id :"+cust.ID+" City: "+cust.City);
			}
			//---------------------------------------------------------//


			//WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);//first pipe line dumps data here
			//WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);//second pipe line dumps data here
			////del1(5, WorkType.GenerateReports);
			////del2(10, WorkType.GenerateReports);
			////DoWork(del2);


			//                          del1 += del2;//having one kind of reference to invoke mulitple subscribers
			//int finalHours=del1(10, WorkType.GenerateReports);
			//Console.WriteLine(finalHours);

			//var worker = new Worker();
			//worker.DoWork();
			//worker.WorkPerformed +=new  EventHandler<WorkPerformedEventArgs>(Worker_WorkPerformed);
			//worker.WorkCompleted += new EventHandler(Worker_WorkCompleted);
//			worker.WorkPerformed += Worker_WorkPerformed;
//			worker.WorkCompleted += Worker_WorkCompleted;
//			worker.WorkPerformed += delegate (object o, WorkPerformedEventArgs e)
//			  {
//				  Console.WriteLine("anonymous method"+e.Hours.ToString());
//			  };
//			worker.WorkCompleted -=Worker_WorkCompleted;//removing
			
//worker.DoWork(8, WorkType.GenerateReports);

		}

		private static void Worker_WorkCompleted(object sender, EventArgs e)
		{
			Console.WriteLine("Work is done prefectly");
		}

		static void Worker_WorkPerformed(object sender,WorkPerformedEventArgs e)
		{
			Console.WriteLine(e.Hours+""+e.WorkType);
		}

		//static void DoWork(WorkPerformedHandler del)
		//{
		//	del(12, WorkType.Golf);//we are delegating the funcanality 

		//}
		//static int WorkPerformed1(int hours,WorkType workType)
		//{
		//	Console.WriteLine("WorkPerformed1 called");
		//	return hours+1;
		//}
		//static int WorkPerformed2(int hours, WorkType workType)
		//{
		//	Console.WriteLine("WorkPerformed1 called");
		//	return hours + 2;
		//}
	}
	public enum WorkType
	{
		GoToMeetings,
		Golf,
		GenerateReports
	}
}
