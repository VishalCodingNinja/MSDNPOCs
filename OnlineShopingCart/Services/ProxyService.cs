using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerManagementSystem.Data;
using CustomerManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagementSystem.Services
{
	public class ProxyService : IProxyService<Customer>
	{
		private readonly OnlineDbContext _context;

		public ProxyService(OnlineDbContext context)
		{
			_context = context;
		}
		public async Task<bool> AddCustomer(Customer customer)
		{
			await _context.Customers.AddAsync(customer);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<IEnumerable<Customer>> GetAllCustomers()
		{
			return await _context.Customers.ToListAsync();
		}

		public async Task<Customer> GetCustomer(int id)
		{
			return await _context.Customers.FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task<Customer> UpdateCustomer(Customer customer)
		{
			_context.Attach(customer).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return await _context.Customers.FirstOrDefaultAsync(c=>c.Id==customer.Id);
		}

		public bool DeleteCustomer(Customer customer)
		{
			_context.Customers.Remove(customer);
			 _context.SaveChanges();
			return true;
		}
	}
}
