using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace DependencyInjection.Container
{
	public class Container<TInterfaceType, TImplementationType>
		where TInterfaceType : class
		where TImplementationType:new()
	{
		private Type GetNameOfInterface => typeof(TInterfaceType);
		private Type GetNameOfImplementation => typeof(TImplementationType);

		public  TInterfaceType GetTransientInstance => (TInterfaceType)Activator.CreateInstance(GetNameOfImplementation);

		public Lazy<TImplementationType> GetSingletonInstance { get; } = new Lazy<TImplementationType>(() => new TImplementationType(), true);

		
	}
}
