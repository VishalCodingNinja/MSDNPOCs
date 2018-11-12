using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadingExamples
{
	class Program
	{
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
			Thread t = new Thread(sayHello);
			t.Start("Heloo everybody");


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

			for (int n = 0; n < 10; n++)
			{
				ThreadPool.QueueUserWorkItem(sayHello, n);
				Thread.Sleep(2000);
			}




		}
		static void sayHello(object stateArg)
		{
			//for(int i=0;i<1000;i++)
			//Console.WriteLine("hello",Thread.CurrentThread.ManagedThreadId);

			//string str = stateArg as string;
			//Console.WriteLine(str);

			int n = (int)stateArg;
			Console.WriteLine("value is   :"+n);

		}
	}
}
