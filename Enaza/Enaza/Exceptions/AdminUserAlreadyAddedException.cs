using System;

namespace Enaza.Exceptions
{
	public class AdminUserAlreadyAddedException : Exception
	{
		public AdminUserAlreadyAddedException(string msg) : base(msg)
		{

		}
	}
}