using CustomerManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagementSystem.Services
{
	public interface IProxyService<T> where T:class
	{
		Task<IEnumerable<T>> GetAllCustomers();
		Task<T> GetCustomer(int id);
		Task<bool> AddCustomer(T customer);
		Task<T> UpdateCustomer(T customer);
		bool DeleteCustomer(T customer);
	}
}
