using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerManagementSystem.Services;

namespace CustomerManagementSystem.Repositories
{
	internal class Repositories<T> : IRepositories<T> where T:class
	{
		private readonly IProxyService<T> _proxyService;

		public Repositories(IProxyService<T> proxyService)
		{
			_proxyService = proxyService;
		}
		public async Task<bool> Add(T t)
		{
			await _proxyService.AddCustomer(t);
			return true;
		}

		public async Task<bool> Update(T t)
		{
			await _proxyService.UpdateCustomer(t);
			return true;
		}

		public async Task<T> Get(int id)
		{
			return  await _proxyService.GetCustomer(id);
		}

		public async Task<IEnumerable<T>> GetAll()
		{
			return await _proxyService.GetAllCustomers();
		}

		public bool Delete(T t)
		{
			return  _proxyService.DeleteCustomer(t);
		}
	}
}
