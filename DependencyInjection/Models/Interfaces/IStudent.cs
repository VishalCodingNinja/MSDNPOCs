using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.Models.Interfaces
{
	public interface IStudent
	{
		 int Id { get; set; }
		 string Name { get; set; }
		 string Address { get; set; }
		string ObjectName { get; }
	}
}
