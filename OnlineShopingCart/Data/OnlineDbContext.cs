using CustomerManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagementSystem.Data
{
	public class OnlineDbContext:DbContext
	{
		public OnlineDbContext(DbContextOptions<OnlineDbContext> options) : base(options)
		{

		}
		public DbSet<Customer> Customers { get; set; }
		public DbSet<GoldCustomer> GoldCustomers { get; set; }
		public DbSet<SilverCustomer> SilverCustomers { get; set; }
	}
}
