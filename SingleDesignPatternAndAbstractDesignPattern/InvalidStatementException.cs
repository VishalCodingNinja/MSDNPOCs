using System;
using System.Runtime.Serialization;

namespace SingleDesignPatternAndAbstractDesignPattern
{
	
	internal class InvalidStatementException : Exception
	{
		public InvalidStatementException()
		{
			Console.WriteLine();
		}

		public InvalidStatementException(string message) : base(message)
		{
			Console.WriteLine(message);
		}

		public InvalidStatementException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected InvalidStatementException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}