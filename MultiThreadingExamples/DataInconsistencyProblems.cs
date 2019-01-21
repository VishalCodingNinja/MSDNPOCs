using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadingExamples
{
	partial class Program
	{
		
		static public void AddOne()
		{
			Console.WriteLine("[{0}] AddOne Called",Thread.CurrentThread.ManagedThreadId);
			//its a bug
			//int temp = sum;
			//temp++;
			//Thread.Sleep(1);
			//sum = temp;

			//solving this problem
			Interlocked.Increment(ref sum);
		}
	}
	public class ArrayProcessor
	{
		double[] _data;
		int _firstIndex;
		int _lastIndex;
		double _sum;
		public ArrayProcessor(double[] data,int firstIndex,int lastIndex)
		{

			_data = data;
			_firstIndex = firstIndex;
			_lastIndex = lastIndex;

		}

		public void ComputeSum()
		{
			_sum = 0;
			for(int n=_firstIndex;n<=+_lastIndex;n++)
			{
				_sum += _data[n];
				Thread.Sleep(1);
			}
		}
		public double Sum
		{
			get { return (_sum); }

		}
	}

	public class widget2D
	{
		int _x;
		int _y;
		object _lock = new object();
		public void MoveBy(int deltaX,int deltaY)
		{
			lock(_lock)
			{
				_x += deltaX;
				_y += deltaY;

			}
		}
		public void GetPos(out int x,out int y )
		{
			lock(_lock)
			{
				x = _x;
				y = _y;
			}
		}
	}

	//public class Bakery
	//{
	//	Queue<Donut> _donutTray = new Queue<Donut>();

	//	public Donut GetDonut()//consumers
	//	{
	//		lock(_donutTray)
	//		{
	//			if(_donutTray.Count==0)
	//			{
	//				//wait for producers to refill
	//				while(_donutTray)
	//				{
	//					Monitor.Wait(_donutTray);//it just not block the calling thread,put it into sleep, it also go up the owner ship of the lock that was 
	//					//with the thread and other method also came and wait here					}

	//			}
	//			return _donutTray.Dequeue();
	//		}
	//	}

	//	public void RefillTray(Donut[] freshDonuts)//producers
	//	{
	//		lock(_donutTray)
	//		{
	//			foreach(Donut d in freshDonuts)
	//			{
	//				_donutTray.Enqueue(d);
	//			}
	//			//unblock waiting consumers(if any)
	//			Monitor.PulseAll(_donutTray); //it will call all sleeping thread onto work
	//		}
	//	}

	//}

}
