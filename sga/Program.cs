using System;

namespace sga
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
			Game window = new Game (640, 480);
			window.Run ();

		}
	}
}
