using System;
using System.Collections.Generic;

namespace DependencyInjection.Services
{
	class Service<T>:IService<T> where T:class
	{
		public Service()
		{
			
		}
		public bool Add(T t)
		{
			throw new NotImplementedException();
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
