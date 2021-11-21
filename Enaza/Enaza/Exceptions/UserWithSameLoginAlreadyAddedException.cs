using System;

namespace Enaza.Exceptions
{
	public class UserWithSameLoginAlreadyAddedException : Exception
	{
		public UserWithSameLoginAlreadyAddedException(string msg) : base(msg)
		{
		}
	}
}