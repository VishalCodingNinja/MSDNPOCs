namespace MSDNPOCS
{

	internal class TriCycle
	{
		protected void Pedal() { }
		private int wheels = 3;
		protected internal int Wheels//it means either protected or internal 
		{
			get
			{
				return wheels;
			}
		}
	}
}
