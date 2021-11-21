using System;

namespace Enaza.Exceptions
{
	public class AdminUserAlreadyAddedException : BaseException
	{
		public AdminUserAlreadyAddedException(string msg) : base(msg)
		{

		}
	}
}