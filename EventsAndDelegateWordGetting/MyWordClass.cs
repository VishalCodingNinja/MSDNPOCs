using System;
using System.Collections.Generic;
using System.Text;

namespace EventsAndDelegateWordGetting
{

	public class MyWordClass
	{
		public event EventHandler<StringClass> eventPallindrome;
		static public int size = 10;
		private string[] namelist = new string[size];
		public void CheckPallindrome(string _suspectstring)
		{

			if (eventPallindrome is EventHandler<StringClass> del)
			{
				del(this, new StringClass(_suspectstring));
			}
		}
		public string this[int index]
		{
			get
			{

				string tmp = namelist[index];
				
				return (tmp);
				
			}
			set
			{
				namelist[index] = value;
				
				
			}
		}
	}

		public class StringClass : EventArgs
		{
		 
			
		    public StringClass(string _name)
	     	{
			    CheckStr = _name;
		    }
			public string CheckStr { get; set; }

		}

	}

