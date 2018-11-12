using System;

namespace MyEventAndDelegatePOC
{
	//full class for exposing and Raising an event
	public delegate void EventPublisherDeclaration(int value1, int value2);
	class AllFreakEvents
	{
		public event EventPublisherDeclaration _eventPublisherDelegateAnotherNameOnSubscribe;
		public event EventHandler defaultEventByCSharp_OnUnSubscribe;
		
		public void invoke_ListenerOnSubscribe(int value1,int value2)
		{
			Console.WriteLine("handler is calleing");
			on_Event_InvokeOnSubscribe(3, 4);
			invoke_ListenerOnUnSubscribe(9, 10);
		}
		public virtual void on_Event_InvokeOnSubscribe(int value1,int value2)
		{
			EventPublisherDeclaration delegateInstance = _eventPublisherDelegateAnotherNameOnSubscribe as EventPublisherDeclaration;
			delegateInstance(23, 34);	
		}
		public virtual void invoke_ListenerOnUnSubscribe(int value1,int value2)
		{

			EventHandler delegateInstance = defaultEventByCSharp_OnUnSubscribe as EventHandler;
			delegateInstance(23, EventArgs.Empty);
		}
	}
	
}
