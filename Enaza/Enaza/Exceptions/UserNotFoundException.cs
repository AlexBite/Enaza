using System;

namespace Enaza.Exceptions
{
	public class UserNotFoundException : BaseException
	{
		public UserNotFoundException(string msg) : base(msg)
		{
		}
	}
}