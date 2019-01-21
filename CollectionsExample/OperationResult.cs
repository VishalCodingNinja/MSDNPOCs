using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsExample
{
	public class OperationResult<T,V>//generic class
	{
		public OperationResult()
		{

		}
		public OperationResult(T result,V message):this()
		{
			this.Result =result;
			this.Message = message;
			Console.WriteLine(result);
		}
		public T Result { get; set; }
		public V Message { get; set; }
	}
	public class GenericClassExampleForStruct<T> where T : struct
	{
		public T SomeValueType { get; set; }
	}
	public class GenericForReferenceType<T> where T:class
	{
		public T SomeReferenceType { get; set; }
		

	}
	public class GenericForReferenceWithReturnType<T> where T:class,new()
	{
		public T getObject<T>() where T : class, new()
		{
			T _instance = new T();
			return _instance;
		}
	}
	public class GenericsForBaseClass<T> where T:Employee,new()
	{
		public T GetClassObject<T>() where T:Employee,new()
		{
			T _emp = new T();
			return _emp;
		}
	}
	public class GenericsForInterface<T> where T:IEmployee
										 
	{
		public T GetClassObject<T>() where T : IEmployee,new()
			                           
		{
			T _emp = new T();
			return _emp;
		}
	}
	public class ListCust<T>:ICollection<T>
	{
		private T[] _items;
		private int _size;
		public int Count
		{
			get
			{
				return _size;
			}
		}

		public bool IsReadOnly => throw new NotImplementedException();

		public void Add(T item)
		{
			//if (_size == _items.Length) EnsureCapacity(_size + 1);
			//_items[_size++] = item;
		}

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public bool Contains(T item)
		{
			throw new NotImplementedException();
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		public IEnumerator<T> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		public bool Remove(T item)
		{
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}
