using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEventAndDelegatePOC
{
	//public delegate void WorkPerformedHandler(object o, EventArgs e); 
	internal class CustomDelegateWithEventArgs
	{
		public event EventHandler<CustomerPOCO> euromonitorDelegateOnSubscribe;
		public event EventHandler euromonitorDelegateOnUnSubscribe;

		public void RegisterEuromonitorInternational(string name,string address)
		{

			
				
				OnSubscribe(name, address);
			
			
			    OnUnSubscribe(name,address);
		}
		protected virtual void OnSubscribe(string name,string address)
		{
			var del = euromonitorDelegateOnSubscribe as EventHandler<CustomerPOCO>;
			if (del != null)
			{
				del(this, new CustomerPOCO(name,address));
			}
		}
		protected virtual void OnUnSubscribe(string name, string address)
		{
			var del = euromonitorDelegateOnUnSubscribe as EventHandler;
			if (del != null)
			{
				del(this, new CustomerPOCO(name,address));
			}
			
		}

	}

		class CustomerPOCO:EventArgs
		{
		public CustomerPOCO(string name,string address)
		{
			this.Name = name;
			this.Address = address;
		}
			public string Name { get; set; }
			public string Address { get; set; }
		}
}
