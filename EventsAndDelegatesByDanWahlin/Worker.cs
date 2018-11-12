using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegatesByDanWahlin
{
	//public delegate int WorkPerformedHandler(int hours, WorkType workType);//internally it will inherit the multicast delegate campiler generate code when it will find a delegate  keyqord
	//public delegate int WorkPerformedHandler(object sender,WorkPerformedEventArgs e);//.net standard approch

		//now if we want to eliminate delegate entirely then we can thake it like public event EventHandler<WorkPerformedEventArgs> WokPerformed

	public class Worker
	{
		//public event WorkPerformedHandler WorkPerformed;
		public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
		public event EventHandler WorkCompleted;//build in delegate in system namespace;
		public void DoWork(int hours,WorkType workType)
		{
			for(int i=0;i<hours;i++)
			{
				//raise event
				System.Threading.Thread.Sleep(1000);
				OnWorkPerformed(i + 1, workType);//good way to do this is taking a seperate method:
			}
			//raise event
			OnWorkComplete();
		}

		protected virtual void OnWorkPerformed(int hours,WorkType workType)//giving base class an apourtunity to overide an to raise event according to them
		{
			//if (WorkPerformed != null)
			//	WorkPerformed(hours, workType);

			//var del = WorkPerformed as WorkPerformedHandler;
			var del = WorkPerformed as EventHandler<WorkPerformedEventArgs>;
			if (del!=null)
			{
				del(this, new WorkPerformedEventArgs(hours,workType));
			}
		}
		protected virtual void OnWorkComplete()//giving base class an apourtunity to overide an to raise event according to them
		{
			//if (WorkCompleted != null)
			//	WorkCompleted(hours, workType);

			var del = WorkCompleted as EventHandler;
			if (del != null)
			{
				del(this,EventArgs.Empty);//sender is source of the events is current class
			}
		}
	}
}
