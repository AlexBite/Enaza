using System;

namespace Enaza.Exceptions
{
	public class UserWithSameLoginAlreadyAddedException : Exception
	{
		public override string Message { get; } = "User with same login already exists in database";
	}
}