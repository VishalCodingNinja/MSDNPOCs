using Microsoft.EntityFrameworkCore;

namespace SolidPrinciplesPOCs
{
	public class CustomersContext:DbContext
	{
		public DbSet<CustomerPOCO> Customers { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=CustomersSolidPOC;Trusted_Connection=True;");
		}
		public DbSet<Item> Items { get; set; }

	}
}
