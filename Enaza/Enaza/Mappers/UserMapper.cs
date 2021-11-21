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
				UserGroup = new UserGroupDto
				{
					Id = user.UserGroup.UserGroupId,
					Code = user.UserGroup.Code.ToString(),
					Description = user.UserGroup.Description
				},
				UserState = new UserStateDto
				{
					Id = user.UserState.UserStateId,
					Code = user.UserState.Code.ToString(),
					Description = user.UserState.Description
				}
			};
		}
	}
}