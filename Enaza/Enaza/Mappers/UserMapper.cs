using Enaza.DTO;
using Enaza.Models;

namespace Enaza.Mappers
{
	public class UserMapper : IUserMapper
	{
		public UserDto MapModelToDto(UserModel user)
		{
			return new UserDto
			{
				Id = user.UserId,
				Login = user.Login,
				CreatedDate = user.CreatedDate,
				UserGroup = null,
				UserState = null
			};
		}
	}
}