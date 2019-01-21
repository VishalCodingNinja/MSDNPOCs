using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingWithAlbahari
{
	class Program
	{
		//bool done;
		static bool done;
		static int sum = 0;
		static readonly object _locker = new object();
		
		static void Main(string[] args)
		{
			//Introduction();
			//AnotherWayOfCreatingThread();
			//ThreadShareDataIfTheyHaveCommonReferenceToSameObject();
			//ExclusiveLock();
			//JoinSleepYeild();
			//ThreadClassDelegate();
			//AnonymousMethodInThread();
			//NamingThread();
			//ForeGroundAndBackGroundThread();
			//ThreadPooling();//divide-and-conquer...ThreadPool.QueueUserWorkItem is the non generic 
			//GetInPoolingUsingTaskLibrary();
			//AsyncDelegates();

			//MutexClassExample();
			//MonitorExample();
			SemaphoreExample();
		}

		// A semaphore that simulates a limited resource pool.
		//
		private static Semaphore _pool;

		// A padding interval to make the output more orderly.
		private static int _padding;

		private static void SemaphoreExample()
		{
			// Create a semaphore that can satisfy up to three
			// concurrent requests. Use an initial count of zero,
			// so that the entire semaphore count is initially
			// owned by the main program thread.
			//
			_pool = new Semaphore(0, 3);

			// Create and start five numbered threads. 
			//
			for (int i = 1; i <= 5; i++)
			{
				Thread t = new Thread(new ParameterizedThreadStart(Worker));

				// Start the thread, passing the number.
				//
				t.Start(i);

			}
			Thread.Sleep(500);

			// The main thread starts out holding the entire
			// semaphore count. Calling Release(3) brings the 
			// semaphore count back to its maximum value, and
			// allows the waiting threads to enter the semaphore,
			// up to three at a time.
			//
			Console.WriteLine("Main thread calls Release(3).");
			_pool.Release(3);

			Console.WriteLine("Main thread exits.");

		}

		private static void Worker(object num)
		{
			// Each worker thread begins by requesting the
			// semaphore.
			Console.WriteLine("Thread {0} begins " +
				"and waits for the semaphore.", num);
			_pool.WaitOne();

			// A padding interval to make the output more orderly.
			int padding = Interlocked.Add(ref _padding, 100);

			Console.WriteLine("Thread {0} enters the semaphore.", num);

			// The thread's "work" consists of sleeping for 
			// about a second. Each thread "works" a little 
			// longer, just to make the output more orderly.
			//
			Thread.Sleep(1000 + padding);

			Console.WriteLine("Thread {0} releases the semaphore.", num);
			Console.WriteLine("Thread {0} previous semaphore count: {1}",
				num, _pool.Release());
		}


		//static List<Student> s = null;
		private static readonly Employee _instanceEmp = new Employee(1,"Vishal SIngh","bareilly");
		private static void MutexClassExample()
		{

			Thread t = new Thread(getEmployeeDetails);
			t.Name = "1";
			t.Start();
			Thread t2 = new Thread(getEmployeeDetails);
			t2.Name = "2";
			t2.Start();
			Thread t3 = new Thread(getEmployeeDetails);
			t3.Name = "3";
			t3.Start();
		}

		private static void getEmployeeDetails()
		{
			Thread.Sleep(1000);
			_instanceEmp.getDetails();
		}

		static WidGet2D _instance = new WidGet2D(0, 0);
		static int _x = 0;
		static int _y = 0;
		static object _lock = new object();
		private static void MonitorExample()
		{

			Thread[] thread = new Thread[10];
			for (int i = 0; i < 10; i++)
			{
				thread[i] = new Thread(MoveUp);
				thread[i].Name = "" + i + "  Thread";
				thread[i].Start();
				_x = _y = i;
				
			}
		}

		private static void MoveUp(object __lock)
		{
			__lock = _lock;
			
				_instance.MoveBy(_x,_y,__lock);
			 
			
			
		}

		private static void AsyncDelegates()
		{
			//ThreadPool>queueUserWorkItem doesnt provide an easy mechanism for getting return values
			//back to thread after it ahs finished executing.Asynchronous delegate inc=vokations 
			//Asynchronous delegates for shot solve this..
			//unhandled exception thrown on teh asynchronous delegates are conveniently rethrown on the original 
			//thread ie.the thhread that calls EndInvoke

			Func<string, int> method = Work;
			method.BeginInvoke("test", Done, null);




		}
		static int Work(string s) { return s.Length; }
		static void Done(IAsyncResult cookie)
		{
			var target = (Func<string, int>)cookie.AsyncState;
			int result = target.EndInvoke(cookie);
			Console.WriteLine("String length is: " + result);
		}

		private static void GetInPoolingUsingTaskLibrary()
		{
			//Task.Factory.StartNew(GoWithTheFlow);//Task.Factory.StartNew returns a Task object, which you can then use to 
			//monitor the task — for instance, you can wait for it to complete by calling its Wait method.

			Go();//we can do work in parellel
			
			// Start the task executing:
			Task<string> task = Task.Factory.StartNew<string>
			  (() => DownloadString("http://www.linqpad.net"));
			string result = task.Result;
			Console.WriteLine(result);
		}

		private static string DownloadString(string uri)
		{
			using (var wc = new WebClient())
				return wc.DownloadString(uri);
		}

		private static void GoWithTheFlow()
		{
			Console.WriteLine("Task Pool");
		}

		private static void ThreadPooling()
		{

			const int FibonacciCalculations = 5;

			var doneEvents = new ManualResetEvent[FibonacciCalculations];
			var fibArray = new Fibonacci[FibonacciCalculations];
			var rand = new Random();

			Console.WriteLine($"Launching {FibonacciCalculations} tasks...");
			for (int i = 0; i < FibonacciCalculations; i++)
			{
				doneEvents[i] = new ManualResetEvent(false);
				var f = new Fibonacci(rand.Next(20, 40), doneEvents[i]);
				fibArray[i] = f;
				ThreadPool.QueueUserWorkItem(f.ThreadPoolCallback, i);
			}

			WaitHandle.WaitAll(doneEvents);
			Console.WriteLine("All calculations are complete.");

			for (int i = 0; i < FibonacciCalculations; i++)
			{
				Fibonacci f = fibArray[i];
				Console.WriteLine($"Fibonacci({f.N}) = {f.FibOfN}");
			}

		}

		private static void GoForPool(object state)
		{
			for (int i = 0; i < 1000000; i++)
			{
				Console.WriteLine("child",Thread.CurrentThread.Name);
			}
		}

		private static void ForeGroundAndBackGroundThread()
		{
			//By default, threads you create explicitly are foreground threads
			//IsBackGround is the property
			//Thread Priority:enum ThreadPriority { Lowest, BelowNormal, Normal, AboveNormal, Highest }
			//

		}

		private static void NamingThread()
		{
			Thread.CurrentThread.Name = "Main";
			Thread worker = new Thread(GoMethodForName);
			worker.Name = "Worker";
			worker.Start();
			GoMethodForName();
		}

		private static void GoMethodForName()
		{
			Console.WriteLine("Hello from " + Thread.CurrentThread.Name);
		}

		private static void AnonymousMethodInThread()
		{
			//There are two predifined delegates 
			//public delegate void ThreadStart();
			//public delegate void ParameterizedThreadStart(obejct obj);
			Thread t = new Thread(() => 
			{
				for (int i = 0; i < 10; i++)
				{
					Console.WriteLine("child");
					Thread.Yield();
				}
				});
			t.Start();
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine("main");
				
			}
		}

		private static void ThreadClassDelegate()
		{
			Thread t = new Thread(new ThreadStart(Go));
			
			t.Start();
			Go();

		}

		private static void JoinSleepYeild()
		{
			Thread t = new Thread(Go);
			t.Start();
			t.Join();
			Console.WriteLine("Thread t has ended!");
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine("main");
				Thread.Sleep(100);
				Thread.Yield();//cause to called thread to yeild for some time and give chance to another thread that is waiting

				
			}
		}

		private static void ExclusiveLock()
		{
			//Exclusive lock
			//while reading and writing to the common field
			new Thread(GoLock).Start();
			GoLock();
		}

		private static void GoLock()
		{
			//sum++;
			//Console.WriteLine(sum);//without lock output 2 1 that is inconsistent
			lock(_locker)
			{
				sum++;
				Console.WriteLine(sum);//consistent data 1 2 ..as we know when il processed that all code go to the processor 
				//that time all memory go to the rigisters assebly mov king of that time of we are not using lock one have that variable same time 
				//some other thread increase that variable
			}
		}

		private static void ThreadShareDataIfTheyHaveCommonReferenceToSameObject()
		{
			Program p = new Program();
			new Thread(p.GoThread).Start();
			p.GoThread();//now another concept that is thread safty
			
			
		}
		private void GoThread()
		{
			for (int i = 0; i < 10; i++)
			{
				if (!done)
				{
					done = true;
					Console.WriteLine(done);
				}
				else
				{
					done = false;
					Console.WriteLine(done);
				}

			}
			
		}
		private static void AnotherWayOfCreatingThread()
		{

			new Thread(Go).Start();
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine("Main");
			}
		}

		private static void Introduction()
		{
			//once started a thread IsAlive property returns true,until the point the thread ends
			//thread ends when the delegate passed to the Thread’s constructor finishes executing
			//The CLR assigns each thread its own memory stack so that local variables are kept separate

			Thread t = new Thread(WriteY);
			t.Start();
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine("Main");
			}

			
		}

		private static void Go()
		{
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine("child Thread");
				Thread.Yield();
			}
		}

		static void WriteY()
		{
			for(int i=0;i<10;i++)
				Console.WriteLine("y");
		}
	}
}
