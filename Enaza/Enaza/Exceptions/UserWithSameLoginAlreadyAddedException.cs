using System;

namespace Enaza.Exceptions
{
	public class UserWithSameLoginAlreadyAddedException : BaseException
	{
		public UserWithSameLoginAlreadyAddedException(string msg) : base(msg)
		{
		}
	}
}