using System;

namespace sil
{
	class Program
	{
		static void Main(string[] args)
		{
			mehmet a = new mehmet();
			mehmet b = new mehmet(100);

			Console.WriteLine(a._duration);
			Console.WriteLine(b._duration);
		}
	}
	public class mehmet
	{
		public int _duration;
		public mehmet()
		{
			_duration = 15;
		}
		public mehmet(int duration=40)
		{
			_duration = duration;
		}
	} 
}
