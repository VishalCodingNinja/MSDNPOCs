using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.Repositories
{
	class Repository<T>:IRepository<T> where T:class
	{
		public Repository()
		{
				
		}
		public bool Add(T t)
		{
			return true;
		}

		public bool Remove(T t)
		{
			throw new NotImplementedException();
		}

		public T Get(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<T> GetAll()
		{
			throw new NotImplementedException();
		}
	}
}
