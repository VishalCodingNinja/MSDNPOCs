using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.Repositories
{
	public interface IRepository<T> where T:class
	{
		bool Add(T t);
		bool Remove(T t);
		T Get(int id);
		IEnumerable<T> GetAll();
	}
}
