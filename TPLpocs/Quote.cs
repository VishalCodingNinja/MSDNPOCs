using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TPLpocs
{
	internal class Quote
	{
		public string Name { get; set; }
		public string Symbol { get; set; }
		public double LastTrade { get; set; }
		public static async Task<Quote> GetQuote(string id)
		{
			string url = "http://finance.yahoo.com/d/quotes.csv?s=" + id + "&f=snl1";
			string response = await new WebClient().DownloadStringTaskAsync(url);
			string[] parts = response.Split(',');
			return new Quote
			{
				Symbol = parts[0].Trim('\"'),
				Name = parts[1].Trim('\"'),
				LastTrade = double.Parse(parts[2])
			};
		}

	}
	public class MyAsyncHandler
	{
		public bool IsReusable { get { return false; } }
		//public void ProcessRequest(HttpContext context)
		//{
		//	string symbol = context.Request.QueryString["symbol"];
		//	Quote quote = await Quote.GetQuote(symbol);
		//	var ser = new DataContractJsonSerializer(typeof(Quote));
		//	context.Response.ContentTYpe = "application/json";
		//	ser.WriteObject(context.Response.OutputStream, quote);
		//}
	}
	public class SingleThreadTaskScheduler : TaskScheduler
	{
		private BlockingCollection<Task> _tasks = new BlockingCollection<Task>();
		private Thread _taskThread;
		public SingleThreadTaskScheduler()
		{
			_taskThread = new Thread(ThreadMain);
			_taskThread.Name = "Single Thread Scheduler";
			_taskThread.Start();
		}
		protected override IEnumerable<Task> GetScheduledTasks()
		{
			return _tasks.ToArray();
		}

		protected override void QueueTask(Task task)
		{
			_tasks.Add(task);

		}
		public override int MaximumConcurrencyLevel => 1;
		protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
		{
			if(!taskWasPreviouslyQueued && Thread.CurrentThread==_taskThread)
			{
				return TryExecuteTask(task);
			}
			return false;
		}
		private void ThreadMain()
		{
				while(true)
			{
				Task t = _tasks.Take();
				TryExecuteTask(t);
			}
		}
	}

}