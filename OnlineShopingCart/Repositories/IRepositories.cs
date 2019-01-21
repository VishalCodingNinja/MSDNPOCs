using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagementSystem.Repositories
{
	public interface IRepositories<T> where T:class
	{
		Task<bool> Add(T t);
		Task<bool> Update(T t);
		bool Delete(T t);
		Task<T> Get(int id);
		Task<IEnumerable<T>> GetAll();
	}
}
