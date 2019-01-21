using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadingWithAlbahari
{
	public class Fibonacci
	{
		private ManualResetEvent _doneEvent;
		private int v;
		private ManualResetEvent manualResetEvent;

		

		public Fibonacci(int v, ManualResetEvent manualResetEvent)
		{
			this.v = v;
			this.manualResetEvent = manualResetEvent;
		}

		public int N { get; }

		public int FibOfN { get; private set; }

		public void ThreadPoolCallback(Object threadContext)
		{
			int threadIndex = (int)threadContext;
			Console.WriteLine($"Thread {threadIndex} started...");
			FibOfN = Calculate(N);
			Console.WriteLine($"Thread {threadIndex} result calculated...");
			_doneEvent.Set();
		}

		public int Calculate(int n)
		{
			if (n <= 1)
			{
				return n;
			}
			return Calculate(n - 1) + Calculate(n - 2);
		}
	}
	class Example
	{
		private static Mutex _mut = new Mutex();
		private const int _numIterations = 1;
		private const int _numThreads = 3;
        public static void ThreadProc()
		{
			for (int i = 0; i < _numIterations; i++)
			{
				UseResource();
			}
		}

		public static void UseResource()
		{

			Console.WriteLine("{0} is requesting the mutex",Thread.CurrentThread.Name);
			_mut.WaitOne();
			Console.WriteLine("{0} has entered the protected area",Thread.CurrentThread.Name);
			//simulate some work
			Console.WriteLine("{0} is leaving the protected area",Thread.CurrentThread.Name);
			_mut.ReleaseMutex();
			Console.WriteLine("{0} has released the mutex",Thread.CurrentThread.Name);
		}
	}
	public class WidGet2D
	{
		int _x;
		int _y;
		
		public WidGet2D(int x,int y)
		{
			_x = x;
			_y = y;
		}
		public void MoveBy(int deltaX,int deltaY,object _lock)
		{
			Console.WriteLine("values"+_x+"  "+_y);
			Console.WriteLine(Thread.CurrentThread.Name + "    getting the lock of object");
			Monitor.Enter(_lock);
		
			Console.WriteLine(Thread.CurrentThread.Name+  "     performing the operation");
			_x += deltaX;
			_y += deltaY;
			Console.WriteLine(Thread.CurrentThread.Name + "     Exiting from the object");
			Monitor.Exit(_lock);
			
		}
		public void GetPos(out int x,out int y,object _lock)
		{
			Monitor.Enter(_lock);
			x = _x;
			y = _y;
			Monitor.Exit(_lock);
		}

	}
	public class Employee
	{
		readonly Mutex _mutex = new Mutex();
		private int _empId;
		private string _name;
		private string _address;

		public Employee(int empId,string name,string address)
		{
			EmpId = EmpId;
			Name = name;
			Address = address;
		}
		public int EmpId { get { return _empId; } set { _empId = value; } }
		public string Name { get { return _name; } set { _name = value; } }
		public string Address { get { return _address; } set { _address = value; } }

		public void getDetails()
		{
			_mutex.WaitOne();
			Console.WriteLine( Thread.CurrentThread.Name+"    "+ EmpId+" "+Name+"  "+Address);
			_mutex.ReleaseMutex();
		}
	}

}
