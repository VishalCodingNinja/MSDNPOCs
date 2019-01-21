namespace SolidWithBestPrqactices.Services
{
	public interface IGreater
	{
		string GetGreet();
	}
	public class Greeter : IGreater
	{
		public string GetGreet()
		{
			return "Welcome to EuroMonitor International";
		}
	}
}