using System;
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
}
