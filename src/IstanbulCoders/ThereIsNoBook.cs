using System;

namespace IstanbulCoders
{
	public class ThereIsNoBook : Exception
	{
		private static string MESSSAGE = "There is no book !";

		public ThereIsNoBook()
			: base(MESSSAGE)
		{
		}
	}
}