using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TPLpocs
{
	class Program
	{
		public static object Quote { get; private set; }

		static void Main(string[] args)
		{
			//Concurrent:Several things happening at once
			//mutlithreaded:Mutliple execution contexts
			//parallel:Multiple simultaneous computions::it can be gain using threads
			//Asynchronous:Not having to wait...
			//The Task Class:
			//public class Stream
			//{
			//public Task WriteAsync(byte[] buffer,int offset,int count)
			//		public void Write(byte[] buffer,int offset,int count)
			//		public int Read(byte[] buffer,int offset,int count)
			//		}
			//two task class
			//1.Task
			//2.Task<T> ::generics ,it is return type

			//thread based task



			//Basics();
			//TPLhelp();
			//TruelyAsync();
			//TaskVsOlderAsyncPattensTheory();
			//ErrorHandling();
			//ContinuationAndError();
			//CompositionExample();
			//task constructor take a delegate means it runs on the thread,,
			//TaskCompletionSourceExample();
			//AsyncTPL();
			//AsyncAwaitExample();
			//APM();
			//CancellationModelExample();
			TaskSchedulers();
		}

		private static void TaskSchedulers()
		{
			//we pass TaskSchedular in the API according to our need.
			//various api those take taskScheduler
			//ex:TaskFactory.StartNew
			//TaskFactory constructor
			//Task.Start overload for scheduler
			//Task.RunSynchronously ::you want task to run now..schedular 
			//Task.ContinueWith
			//TaskFactory.ContinueWhenAll
			//TaskFactory.COntiueWhenAny
			//TaskFactory.FromAsync:..thread less task need to call end method

			//Data parallelism:
			//parallelOptions.TaskScheduler
			

			//default:
			//TaskFactory.TaskScheduler
			//TaskScheduler.Current
			//TaskScheduler.Default::Default(Thread Pool) Scheduler

			//TaskSchedular class provide a method:
			//TaskScheduler.FromCurrentSynchronizationCOntext() method to turn the scheduler
			//Abstraction abotu the work need to be done in particular context..
			//some time client side also we need context of particular context..all .net applicaiton 
			//support this context
			//we can write own context
			//can not pass the context


			//Custom Schedulers:
			//not usually necessary
			//we can derived form TaskSchudeler
			//Override abstract methods
			//IEnumerable<Task> GetSchedulerTasks();
			//void QueueTask(Task t)
			//call TryExecuteTask to run the task method :to set up all important things needed
			//bool TryExecuteTaskInLine(Task t,bool wasPreviouslyQueued)
			//it will run the task imediatly 
			
			//optionally override virtuals:
			//bool TryDequeue(Task t)
			//int MaximumConcurrencyLevel{get;}::data palallelism 
			

			//summary:
			//TaskScheduler
			//DefaultScheduler
			//SynchronizationContext
			//Customscheduler
		}

		private static void CancellationModelExample()
		{
			//Consistency
			//Chainability
			//Blocking and asynchronous work
			//Thread based and threadledd work
			//coorative

			//consiquences
			//cancelation is optional.
			//Asynchronous
			//Might not happen
			//

			//CancelationToken
			//Argument for cancellable opeartion
			//single-use
			//Enable recipients to discover cancellation request
			//Polling
			//Notification
			//WaitHandle

			//Does not allow initiation
			//--use Cancellation 

			//CancellationTokenRegistration
			//returned by cancellation Token.Register



			//it also have
			//CancellationToken.Register(callback,state,true)

			//CancellationToken:(struct)--when we pass token it passs by value

			//Tasks and Cancellation:
			//Thread based option to passcencellation token..it taks alseady then 
			//can not do any thing
			//OperationCanceledExaception:when taks is already happen and we request for 
			//cancellation..
			//Wait nad result throw TaskCanceledException

			//Task.WhenAll

			//Continuations not canceled
			//--Pass token to ContinueWith if you want that 

			using (var cts1 = new CancellationTokenSource())
			using (var cts2 = new CancellationTokenSource())
			{
				Action work = () => { Thread.Sleep(500); cts1.Token.ThrowIfCancellationRequested(); };
				var taskSameToken = Task.Factory.StartNew(work, cts1.Token);
				var taskDifferentToken = Task.Factory.StartNew(work, cts2.Token);
				var taskNoTaskToken = Task.Factory.StartNew(work);
				Thread.Sleep(200);
				cts1.Cancel();
				cts2.Cancel();
				Task.WaitAll(
					taskSameToken.ContinueWith(t => { }),
					taskDifferentToken.ContinueWith(t => { }),
					taskNoTaskToken.ContinueWith(t => { })
					);
				Console.WriteLine("Status (same token):"+taskSameToken.Status);
				Console.WriteLine("Status (different tokens):"+taskDifferentToken.Status);
				Console.WriteLine("Status (no task token):"+taskNoTaskToken.Status);
			}



			//Rules for callbacks:
			//run quickly
			//be wary of cancellationTokenRegistration.Dispose
			//dont synchronize the context

			//LInked Tokens:
			//cancelationTokenSource.CreateLinkedTokenSource:
			//takes any numeer of cancellationToken
			//returns cancellatiolTokenSOurce

		  //Summary:
		  //Goals:
		  //Token vs token source:
		  //pooling,notification,and WaitHandle
		  //Tasks::thread based cancellation
		  //
		}

		private static void APM()
		{
			//asynchronous programming model :very old programming model
			//aka IAsyncResult design pattern

		}

		private static void AsyncAwaitExample()
		{
			var task = ShowQuotes(new[] { "MSFT", "GOOG" });  
			task.Wait();

			//COmpilergenerated tasks have at most 1 exception
			//Task.WhenAll can have many
			//await rethrows the 1st
			//tasks wait ,result and exception return everything

			//try
			//{
			//	await compositeTask.ContinueWith(() => { }, TaskContinuationOptions.ExecuteSynchronously);
			//	string[] results = CompositionTask.Result;
			//}
			//catch(AggregateException ax)
			//{
			//	...
			//}

			
			
			//Argument Validation:-
			
			//Immediate vs Deferred
			
			//try
			//{
			//	Task<string> t1 = DoAsync(p1, p2);
			//}
			//catch(Exception ex)
			//{
			//Immediate exceptions caught here
			//}

			//try
			//{
			//	string result = await t1;
			//}
			//catch(Exception x)
			//{
			   //Defereed exception caught here
			//}

			//any exception that is occured in async method will be considered 
			//as defered exception
			//not all await method means that method will wait there

		}

		private async static Task ShowQuotes(IEnumerable<string> symbols)
		{
			foreach (var symbol in symbols)
			{
				Quote q = await GetQuote(symbol);
				Console.WriteLine("{0} ('{1}'):{2}",q.Name,q.Symbol,q.LastTrade);
			}
		}

		private static async Task<Quote> GetQuote(string id)
		{
			//string url = "http://finance.yahoo.com/d/quotes.csv?" + id + "&f=snl1";
			string url = "https://in.finance.yahoo.com/quote/%5EBSESN?p=^BSESN";
			string response = await new WebClient().DownloadStringTaskAsync(url);
			string[] parts = response.Split(',');
			return new Quote
			{
				Symbol = parts[0].Trim('\"'),
				Name = parts[1].Trim('\"'),
				LastTrade = double.Parse(parts[2])

			};
		}

		private static void AsyncTPL()
		{
			//async and await..
			//async :it does not do any this it just enables the async feature,applied to methods
			//await:action alive
			//it probide similer with task continueWith() provide..


			//ex: void Work()
			//{
			//	Task<string> ts = Get();
			//	ts.ContinueWith(t =>
			//	{
			//		string result = t.Result;
			//		Console.WriteLine(result);
			//	})
			//}

			//and 

			//async void work()
			//{
			//	Task<string> ts = Get();
			//	string result = await ts;
			//	Console.WriteLine(result);
			//}
			//these both code are same



			Task<string> title = GetTitleCsAsync("https://www.codeproject.com/");//getTitleCsAsync is good method
			Console.WriteLine(title.Result);


			//Exception Handling::
			//Task<T>.Result throws if Faulted 
			//throws AggregateException

			//await throws origin al exception
			//exception will be happened as like synchronous METHOD so it is very convienient
		}

		private static Task<string> GetTitle(string url)
		{
			var w = new WebClient();
			
				Task<string> contentTask = w.DownloadStringTaskAsync(url);
				return contentTask.ContinueWith(t => 
				{
					string result=ExtractTitle(t.Result);
					w.Dispose();
					return result;
				});
			
		}


		static async Task<string> GetTitleCsAsync(string url)
		{
			using (var w = new WebClient())
			{
				string content = await w.DownloadStringTaskAsync(url);
				return ExtractTitle(content);
			}
			//async method always return Task ..
			//from where task<string> is coming..it depends on TPL
			//compiler will restrict to the method marked to async 
			//alloweable async method return types that marked to async 
			// void
			//Task(that method execute sucessfully...)
			//Task<T>(that method execute suceffuly mo)
			//

			//horrible void method becase the caller would not know that mthod execute or not
			//static async void ShowQuote()
			//{
			//	Quote q = await GetQuote("MSFT");
			//	Console.WriteLine("{0} ('{0}'):{2}",q.Name,q.Symbol,q.LastTrade);
			//}
			//so instead of returning the void we can return the Task now compiler will generate 
			//the code for us...put it into the fault stat if the work ends with an exception

			//but some tinme we need the void return type in case of method maching scenerio
			//ex:eventhandler or XML

		}
		private static string ExtractTitle(string content)
		{
			const string TitleTag = "<title>";
			var comp = StringComparison.InvariantCultureIgnoreCase;
			int titleStart = content.IndexOf(TitleTag, comp);
			if(titleStart<0)
			{
				return null;
			}

			int titleBodyStart = titleStart + TitleTag.Length;
			int titleBodyEnd = content.IndexOf("</title>", titleBodyStart, comp);
			return content.Substring(titleBodyStart, titleBodyEnd - titleBodyStart);
		}

		private static void TaskCompletionSourceExample()
		{
			//it is a generic class so that we can create generic class and control its start
			//Task property:return Task<T>..
			//plain tasks is the class that take some thing but did not return any thing just like void mehtod

			//use TaskCOmpletionSource<object> fro plain task
			//Task statuc initially WaitingForActivation
			//SetResult transitions to RanToCompletion

			string logPath = @"C:\Users\Vishal.singh\Documents\sample.txt";
			var processor = new LogProcessor(logPath);
			Thread.Sleep(5000);

			//it provide 
			//Set Exception
			//-->Single Exception
			//-->IEnumerable<Exception>

			//TCS provides AggregateException
			//SetCanceled


			//Argument Errors:
			//mid-flow (non-argument) errors. vs Immediately errors. 

			//TaskCompletionSource<T>:is an class that represent custom aysnc operation::
			//SetResult completes task completietly sucessult
			//setException : completes the task sucessfully put into faulted state
			//setConcelled: resu
			//Argument:argument completion methods

		} 

		private static void CompositionExample()
		{
			//Task.WaitAll and Task.WaitAny
			//TaskFactory.ContinueWhenAll and TaskFactory.COntinueWhenAny
			//Task.WhenAll and Task>WhenAny 
			//require /NEt>=4.5
			var web = new WebClient();
			var web2 = new WebClient();
			Console.WriteLine("Sytarting work");
			//InnserException we can check in debugger
			var getTask =  web.DownloadStringTaskAsync("http://127.0.0.1:3000/getPosts");
			var getTask2 = web2.DownloadStringTaskAsync("www.microsoft.com ");
			//Task<string[]> getTasks = Task.WhenAll(getTask, getTask2);
			Task.Factory.ContinueWhenAll(new[] { getTask,getTask2},(Task<string>[] tasks)=> {
				foreach(var t in tasks)
				{
					if (t.IsFaulted)
					{
						Console.WriteLine(t.Exception);//count when both task fail..and print out multipe stack traces
					}
					else
					{
						Console.WriteLine(t.Result);
					}
				}
			}).Wait();
			Console.WriteLine("setting up continuation");
			
			GC.Collect();
			Console.WriteLine("sucessfull");
			
			
			//TaskStatus
			
			//:RunToCompleton,faulted,RanToCompletion,canceled
			
			//if we inviked Task class then then task created ..ansyn dont use this way
			//ex: continuationTask is created with continueWith 
			//while other tasks are created with TaskFactory 
			//when task should run?
			//TaskCycles:
			//Created--->WaitingForActivation -->waitingToRun(ready to run and it depends to the scheduler)-->running
			//If task has child then it may be in condition -->WaitingFOrChildrenToComplete
			//after task executed:::::faulted||RanToCompletion||Canceled

			//Summary:
			//Aysnchronous,threadless,vs threaded tasks::tasks are wrapper around the thread pool
			//Task and Task<T>(it deribed form Task)
			//Error handling
			//Continations:
			//Composistion
			//State model 

		
	}

		private static void ContinuationAndError()
		{
			//TaskCOntinuationOptions:::
			//OnlyOnFaulted
			//OnlyOnRanToCompletion
			//OnlyOnCanceled
			//NotOnFaulted
			//NotOnRanToCompletion
			//NotOnCanceled

			//Not Error Reslated:
			//PReferFairness
			//LongRunning
			//ExecuteSynchronously
			//AttachedToParent




		}

		private static void ErrorHandling()
		{
			//if task throw an exception then TPL put it into faulty state
			//Properties in Task
			//IsFaulted
			//Status
			//Exception
			//Result

			//Method
			//Wait methods

			//AggregateException(4.0):rethrow an exception is not a good idea..so it AggregateException
			//in this we can rethrow the exception after .net 4.0 so that we can get the stack trace
			//of all the exceptions 

			//TPL uses GC for failed Task ...UnObserved exception:TPL raises the TaskScheduler.UnobservedTaskException and 
			//if we handle the exception then we are telling the TPL that we handled the exception
			//otherwise the TPL will escalate the exception ..means cuushing the process
			//in .net 5.0 it change if both task fail it abandoned the task
			//if we want to raised the exception for unobserved task excetpion
			//then :
			//<configuration>
			//<runtime>
			//<ThrowUnobservedTaskException enabled="true"/>
			//</runtime>
			//<configuration>

			var web = new WebClient();
			Console.WriteLine("Sytarting work");
			//InnserException we can check in debugger
			Task<string> getTask = web.DownloadStringTaskAsync("https://stackoverflow.com");
			Console.WriteLine("setting up continuation");
			getTask.ContinueWith(t => {
				if(t.IsFaulted)
				{
					Console.WriteLine(t.Exception);// use can make unabsorbed exception true in config file
				}
				else
				{
					Console.WriteLine(t.Result);
				}
			});
		}

		private static void TaskVsOlderAsyncPattensTheory()
		{
			//.Net>=1.0 APM:Async Programming model..to call end();
			// .Net>=2.0 Eap :Event based Async pattern
			//.Net>-4.0 Tasks:TPL:: GEnerics ..easier with tasks,,,Result,,can call many time result,continuations
			//Task:support to schedulers()...composition(can combine multiple tasks)..best Error handling
			//task:Cancellation...Language support..they can consume any api..
		    
		}


		//error
		//async private static void TruelyAsync()
		//{
		//	var web = new WebClient();
		//	Task<string> getTask = Task<string>.Factory.StartNew(() =>//when we use StartNew() on task the new thread created on teh boby of thread pool
		//	{
		//		//error//String result = web.DownloadStringTaskAsync("https://stackoverflow.come");
		//		//return result;
		//	});
		//	Console.WriteLine("Setting up the continuation");
		//	getTask.ContinueWith((t) => { Console.WriteLine(t.Result); });//it will execute when the getTask will complete
		//																  //Console.WriteLine(getTask.Result);//result property will block until result will not come
		//	Console.WriteLine("continuning on main thread");
		//	Thread.Sleep(10000);
		//}

		private static void TPLhelp()
		{
			var web = new WebClient();
			Task<string> getTask = Task<string>.Factory.StartNew(() =>//when we use StartNew() on task the new thread created on teh boby of thread pool
			{
				String result = web.DownloadString("https://stackoverflow.com/questions/17419961/c-sharp-threadpool-queueuserworkitem-use");
				return result;
			});
			Console.WriteLine("Setting up the continuation");
			getTask.ContinueWith((t) => { Console.WriteLine(t.Result); } );//it will execute when the getTask will complete
															   //Console.WriteLine(getTask.Result);//result property will block until result will not come
			Console.WriteLine("continuning on main thread");
			Thread.Sleep(10000);
		}

		private static void Basics()
		{
			//also known as plock api as it block for some time 
			var web = new WebClient();
			String result = web.DownloadString("https://stackoverflow.com/questions/17419961/c-sharp-threadpool-queueuserworkitem-use");
			Console.WriteLine(result);
			//so tpl can hekp us in this 
		}
	}
	
}
