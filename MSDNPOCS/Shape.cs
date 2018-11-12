using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDNPOCS
{
	public class Shape
	{
		public int X { get; private set; }
		public int Y { get; private set; }
		public int Height { get; set; }
		public int Width { get; set; }

		//virtual method
		public virtual void Draw()
		{
			Console.WriteLine("Performing base class drawing tasks");
		}
	}
	public class Circle:Shape
	{
		public override void Draw()
		{
			Console.WriteLine("Drawing a circle");
			base.Draw();
		}
	  
	}
	public class Rectangle : Shape {
		public override void Draw()
		{
			Console.WriteLine("Drawing a circle");
			base.Draw();
		}
	}
	public class Triangle : Shape
	{
		public override void Draw()
		{
			Console.WriteLine("Drawing the triangle");
			base.Draw();
		}

	}
}
