using System;

namespace MyEventAndDelegatePOC
{
	public delegate void DelegateObject(int value1, int value2);
	
	class Program
	{
		delegate int lamdaDelegate(int a, int b);
		delegate bool lamdaDelegate1(int a, int b);
		static void Main(string[] args)
		{
			//DelegateObject del = new DelegateObject(EventSubscriber);
			//DelegateObject del2 = new DelegateObject(EventSubscriber);

			//AllFreakEvents obj = new AllFreakEvents();
			//obj._eventPublisherDelegateAnotherNameOnSubscribe += new EventPublisherDeclaration(EventSubscriber);
			//obj.defaultEventByCSharp_OnUnSubscribe += new EventHandler(Method);
			//obj.invoke_ListenerOnSubscribe(45,34);



			//custom delegate with event args:
			CustomDelegateWithEventArgs obj = new CustomDelegateWithEventArgs();
			//obj.euromonitorDelegateOnSubscribe += new EventHandler<CustomerPOCO>(EuromonitorSubscriptionNotification);
			//obj.euromonitorDelegateOnUnSubscribe += new EventHandler(EuromonitorUnSubscriptionNotification);

			//compiler delegate inference
			//obj.euromonitorDelegateOnSubscribe += EuromonitorSubscriptionNotification;
			//obj.euromonitorDelegateOnUnSubscribe += EuromonitorUnSubscriptionNotification;


			//anonymaus method:
			obj.euromonitorDelegateOnSubscribe += delegate (object o, CustomerPOCO e)
			  {
				  Console.WriteLine(e.Name + " sucessfully subscribe you have 10 year free subscription");
				  for (int i = 0; i < 10; i++)
				  {
					  System.Threading.Thread.Sleep(1000);
					  Console.WriteLine("year   :" + i + "  free subscription");


				  }

			  };
			obj.euromonitorDelegateOnUnSubscribe += delegate (object o, EventArgs e)
			  {
				
			Console.WriteLine(" Sucesssfully unsubscribe Euromonitor will be happy to see to again");

			  };

			Console.WriteLine("Register your self with Euromonitor International");
			Console.WriteLine("Enter Your Name");
			string name = Console.ReadLine();
			Console.WriteLine("Enter your Address");
			string address = Console.ReadLine();
			obj.RegisterEuromonitorInternational(name,address);




			//lamda delegate:
			lamdaDelegate d = (a, b) => a + b;
			Console.WriteLine(d(2, 3));
			lamdaDelegate1 _instanceOfDeligate = (a, b) =>
			{
				UpdateDataBase(a,b);
				WriteToEventLog(a,b);

				return true;
			};
			bool _status = _instanceOfDeligate(2, 3);
			Console.WriteLine("UpdateDataBase and Write Operation is sucessfull");



			Action c;
			c = callMeAtSomeNOtification;
			c();
			Func<int, int> fun = (x) => x * x;
			Console.WriteLine(fun(9));
			
		}

		
		private static void callMeAtSomeNOtification()
		{
			Console.WriteLine("notification comes here i Guss");
		}

		private static void WriteToEventLog(int a, int b)
		{
			Console.WriteLine(a+"  "+b+"  log is sucessfully updated");
		}

		private static void UpdateDataBase(int a, int b)
		{
			Console.WriteLine(a+"   "+b+"database sucessfully updated");
		}

		public static void EuromonitorSubscriptionNotification(object sender,CustomerPOCO e)
		{
			Console.WriteLine(e.Name+" sucessfully subscribe you have 10 year free subscription");
			for(int i=0;i<10;i++)
			{
				System.Threading.Thread.Sleep(1000);
				Console.WriteLine("year   :" + i + "  free subscription");
				
				
			}
		}
		public static void EuromonitorUnSubscriptionNotification(object sender,EventArgs e)
		{
			var obj = e as CustomerPOCO;
			Console.WriteLine(obj.Name+" Sucesssfully unsubscribe Euromonitor will be happy to see to again");


		}




		public static void EventSubscriber(int value1, int value2)
		{
			Console.WriteLine($"Event Subscriber{0} and {1}",value1,value2);
		}
		public static void Method(object obj,EventArgs e)
		{
			Console.WriteLine("asdfasdfasdf");
		}
	}

	
}
