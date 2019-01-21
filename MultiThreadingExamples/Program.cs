using System;
using System.Diagnostics;
using System.Threading;

namespace MultiThreadingExamples
{
	partial class Program
	{
		static int sum = 0;
		static void Main(string[] args)
		{
			//Threads:
			//hasve access to any/alldata within an AppDomain
			//Each thread has its own call stack and copy of the CPU registers
			//--technically a cli emplementation-specific detail
			//a process no threads exits (because it can no longer perform work..)


			//Multi-threading use cases
			//the benefit of levering multithreading include..
			//opportunity tpp scale by parallelizing CPU-bound operation
			//assuming multicore/multiprocessor hardware.

			//Perform CPU nound work while I/O operations are waiting

			//Maintain a responsive user interface
			//a.farming off lenghty and /or blocking operations to a seperate thread
			//using therad priorities to ensure the "UI Thread" has priority


			//price multithreading:
			//the price to pay for mulitthreading includes..
			//slower execution time on single core/processor machines
			//context switching overhead means...
			//1 thread doing N unit of work
			//4 threads each doing 1/4th of N..(scheduler use of CUP ..context switch)

			//Added program complexity
			//1.lines of code
			//2.radability/maintainability
			//debugagability
			//testability..
			//scheduler overhead..

			//Starting Threads
			//threads are started explicitly using System.Threading.Thread
			//Constructor is used to set thread entry point
			//Thread t=new Thread(SayHello);
			//t.Name="Hello";
			//t.Priority=ThreadPriority.BelowNormal;
			//t.Start();//now clr start the thread
			//static void SayHello(){cw("hello")}

			//Console.WriteLine("Processor count"+Environment.ProcessorCount);//8 processor
			//Thread t = new Thread(sayHello);
			//t.Name = "First Thread";
			//t.Priority = ThreadPriority.BelowNormal;
			//t.Start();



			//Thread method
			//Thread entry point methods
			//void EntryPointMehtod()
			//MSDN/ThreadStart
			//void EnterPointMEthod(object stateArg)
			//MSDN/ParameterizedThreadStart
			//method may be instance or static


			//parameterised thread start..
			//Thread t = new Thread(sayHello);
			//t.Start("Heloo everybody");


			//thread lifetime:
			//Execution continues until thread returns from its entry point method...
			//as result of an unhab=ndled exception
			//a. encountered by the thread itself ("Synchronous exception")
			//b. induced by another thread using Interrupt or Abort ("asynchronous exception")
			//IsAlive provides an instanctanous snapshot of thread execution state




			//coording thread shutdown::
			//user definedd mechanism used to request orderly shutdown
			//not so good:pooling IsAlive
			//better:calling Join:the caller will join to the the wating state on which instace we are calling
			//t.join() :here main thread will wait until the instace method will not be called



			//Thread pool:
			//the CLR threads to be bowwowed for relatively brief concurrent operations
			//CLR adds threads to,removes threads from the pool based on demand
			//Allows cost of thread startup and teardown to be amortized over life of app 
			//pooled threads have IsBackground property set to true;
			//Thread t=new Thread(IsIMThread);
			//t.IsBackGround=true;
			//cw(t.IsBackGround);//true

			//three styles of interactions with the thread pool are supported
			//ThreadPool.QueueUserWorkItem
			//Delegate.BeginInvoke(interface)
			//Asynchronous I/O


			//Queues a request for pooled thread to call a given callback
			//1.Optional state argument may be passed to callback with request
			//callback request (and optional argument) are stored in a FIFO queue
			//Multiple reader threads meamns call backs incvocation  order is not guaranteed

			//for (int n = 0; n < 10; n++)
			//{

			//	ThreadPool.QueueUserWorkItem(sayHello, n);
			//	Thread.Sleep(2000);


			//Asynchronous I/O is a scalable I/O-centric interface to the thread pool
			//1.QueueUserWorkItem/Delegates
			//a.dispatch a pooled thread to call a method that may take a long time to complete
			//2.Async I/O
			//a.queue a non-blocking I/O request to a device(BeginRead,BeginWrite,et.al)
			//b.dispatch a pooled thread to call a method notifying you when I/O completes.


			//Summary:
			//Thread are the core concurrent programming construct in .NET
			//System.Threading.Thread
			//Contained within/confined to a single process
			//share access to any/all data within that process/AppDomain

			//Independently prioritized and scheduled for CPU time by the OS...
			//1.when backed by a Win32 thread

			//Multiple techniques provided for leveraging threads
			//1.manual/explicit
			//2.thread pool
			//3.asynchronous I/O



			//Thread Synchronization:
			//Deadlock:
			//most resouces whould not access cuncurrently.




			//}


			//Q3.
			//Thread[] thread = new Thread[10];
			//for(int n=0;n<thread.Length;n++)
			//{
			//	thread[n] = new Thread(AddOne);
			//	thread[n].Start();
			//}
			//for(int n=0;n<thread.Length;n++)
			//{
			//	thread[n].Join();
			//}

			//Console.WriteLine(sum);


			//Q4.
			//AtomicUpdates();

			//DataPartitioning();//problem
			//DataPartitionProblemSolution();//solution
			//WaitBasedSynchronization();
			//System_Threading_Monitor();
			//DeadLock();
			Mutexes();
		}

		private static void Mutexes()
		{
			//A mutex is a Win32 kernel obejct 
			//System.Threading.Mutex;;provides an FCL wrapper for managed code

			//Benefits:Supports timeout limited lock acquisition
			//namable :anabling cross-process(same machine) thread synchronization
			//benefit:we can get the the name and use it in cross process thread synchronization
			//enables deadllock free multiple lock acquisition via WaitHandle.WaitAll
			

			//tradeoff
			//Acquisition and release calls always incur roundtrip to/from kernel mode
			//underlying kernel obejct must be closed when no longer needed
			//handled automatically (but on a delayed basis) by GC/finalizartion mechanics
		}

		private static void DeadLock()
		{
		//Deadlock can occur whenever a hold and wait situation is possible 
		//while holding one lock,a thread attempts to acquire another lock..

			//note that the above id rife with caveats:
			//Deadlock can occus (but wont necessarily occur)
			//requires 2 or more threads competing for the same set of locks

			//deadlock is possible (but not necessarily probable)
			//probability increases as # of threads /processors /cores increases
			
			//probability of deadlock increases when two threads trying to access 
			//one resource

			//Deadlock may only be temporary
			//if timeouts are used in all lock acquisition calls

			//threadX acquire lock protecting resource A and same time thread Y trying to acquire the resource A..now it can be a dead lock



		}

		private static void System_Threading_Monitor()
		{
			//monitor models gated access to a resource
			//Threads agree to enter the monitor before accessing shared resource
			//CLR allows only one thread at a time tpp enter monitor
			//other thereads attempting to enter monitor while in use are blocked
			//may be resursivley entered by same thread


			//Threads agree to exit the monitor once a access to resource is complete
			//a. next thread waiting for entery to monitor(if any) is allowed in
			//b. Resursively entrance operations by same thread require balance exit operations

			//Monitors in the CLR
			//monitor methods operate on object references
			//Every obejct in the heap can potentially be associated with a lock
			//lock is demand initialized by the CLR only if when needed.
			//index/reference to lock is stored within the CLR managed obejct header
			//Therefore,any obejct may effectively be used as a monitor


			//we can achieve that by creating object ,using Monitor.Enter(_lock) when entering and Monitor.Exit(_lock) when
			//  it want to exit from lock  and putting it into the try catch for thread safe

			//in new way we can use lock(_lock) keyword to monitor critical section  

			widget2D wid = new widget2D();
			//Thread t1 = new Thread(wid.MoveBy);

			//Hold and Wait::
			//sometimes a thread needs to wait for something while holding a lock 
			//ex:a resource to be provided or replenished
			//ex:another lock

			//resource replenishment or other condition
			//producer/consumer model for resource handling
			//blocking sematics for consumers when resource(s) not available

			//Multiple lock acquisition:
			//atomic updates of multiple resources,each protected by own lock
           
			//Hold and wait with mon itors:
			//the monitor class supports safe hold and wait operations
			//via the pulse ,pulseAll,Wait methods

		}

		private static void WaitBasedSynchronization()
		{
			//somethimes threads need access to exact same resource--cant partition
			//ex:insert or delete node from a list while other thread(s) are navigating list
			//ex:multiple threads trying to manipulate the same file

			//sometime datadependencies prevent a partitioned approach
			//1.when the output of one thread is required as input to another
			//ex:computing the Fibonacci sequence
			//sequence[0]=sequence[1]=1;
			//sequence[n]=sequence[n-1]+sequence[n-2]

			//such situation require a wait based approach to synchronization
			//i.e thread may have to block until access is allowed

			//wait based synchronization is based on a voluntary protocol
			//A "gentleman's aggreemnt" or "handshake" model
			//elements of the protocol
			//a. a shared resource is identified ("that array over there")
			//b. a synchronization primitive/tool is agreed on (monitor,mutex,..)
			// an agreed upon instance of that primitive is identified.
			// lock X guards file X,lock Y guards file Y,etc
			// any thread wishing to accessing the resource agrees to:
			//1.acquire ownership of the agreed upon synchronization primitive
			//2.access the shared resource only after ownership acquired
			//3.release ownership of the synchronization primitive once access is complete

			//key point:the protocol is voluntary



			//several wait based synchronization premitive available in the CLR
			//all are present in system.Threading namespace
			//monitor
			//mutex
			//ReaderWriteLockSlim
			//ManualResetEvent,AutoResetEvent
			//Semaphore

			//first three sahre the same basic usage model
			//make a function call to acquire ownership of the lock
			//use the shared resource the designated lock is meant to protected
			//make a function call to release lock ownership once no longer needed

			
		}

		private static void DataPartitionProblemSolution()
		{
			//determine how many cores/processors there are on this machine
			int coreCount = Environment.ProcessorCount;
			Console.WriteLine("Process/core count = {0}", coreCount);

			//get some data to work with
			double[] data = GetData();
			Stopwatch sw = Stopwatch.StartNew();
			
			//setup same-sized arrays of references to arraySlice
			//Thread obejcts; one per core/processor

			
			ArrayProcessor[] slices = new ArrayProcessor[coreCount];//thread object pre core
			Thread[] threads = new Thread[coreCount];

			//Divide the work(roughly) evenly among the
			//number of threads we are about to start .the last
			//thread will pickup any leftovers if the data size
			//is not evenly divisible by the core count..
			int indexesPerThread = data.Length / coreCount;
			int leftOverIndexex = data.Length % coreCount;
			for(int n=0;n<coreCount;n++)
			{
				int firstIndex = (n * indexesPerThread);
				int lastIndex = firstIndex + indexesPerThread - 1;
				if(n==(coreCount-1))
				{
					lastIndex += leftOverIndexex;//adding the remaining values to the processors
				}
				ArrayProcessor slice = new ArrayProcessor(data, firstIndex, lastIndex);
				slices[n] = slice;
				threads[n] = new Thread(slice.ComputeSum);
				threads[n].Start();
			}
			double sum = 0;
			for(int n=0;n<coreCount;n++)
			{
				threads[n].Join();//waiting till these thread is not completed
				sum += slices[n].Sum;//adding individual sumed get by each thread
			}

			Console.WriteLine("{0} threads computed{1:n0} in {2:n0} ms",coreCount,sum,sw.ElapsedMilliseconds);

		}

		private static void DataPartitioning()
		{
			//Sometime can partition data to orchestrate multithreaded access
			//depends on the data or resources being operated on
			//Requires problem domain specific programming
			//you work on this while I work on that model
			//eg:directory-based file operations
			//array manupulations
			//logically devide the array 
			int coreCount = Environment.ProcessorCount;
			Console.WriteLine("Process/core count = {0}",coreCount);

			double[] data = GetData();
			Stopwatch sw =Stopwatch.StartNew();


			ArrayProcessor wholeArray = new ArrayProcessor(data, 0, data.Length - 1);
			wholeArray.ComputeSum();
			sw.Stop();
			Console.WriteLine("1 thread computed {0:n0} in {1:n)} ms",wholeArray.Sum,sw.ElapsedMilliseconds);

		}

		private static double[] GetData()
		{
			double[] data = new double[5000];
			for(int n=0;n<data.Length;n++)
			{
				data[n] = n;
			}
			return (data);
		}

		private static void AtomicUpdates()
		{
			Thread[] threads = new Thread[10];
			for(int n=0;n<threads.Length;n++)
			{
				threads[n] = new Thread(AddOne);
				threads[n].Start();
			}

			for (int n = 0; n < threads.Length; n++)
				threads[n].Join();
			Console.WriteLine(
				"[{0}] Sum ={1}",Thread.CurrentThread.ManagedThreadId,sum
				);
		}

		static int i = 0;
		//static void sayHello(object stateArg)
		//{
		//	//for(int i=0;i<1000;i++)
		//	//Console.WriteLine("hello",Thread.CurrentThread.ManagedThreadId);

		//	//string str = stateArg as string;
		//	//Console.WriteLine(str);
			
		//	int n = (int)stateArg;
		//	Console.WriteLine("value is   :"+n);

		//}


		




	}

	
}
