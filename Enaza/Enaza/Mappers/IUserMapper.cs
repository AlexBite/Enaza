using Enaza.DTO;
using Enaza.Models;

namespace Enaza.Mappers
{
	public interface IUserMapper
	{
		UserDto MapModelToDto(UserModel user);
	}
}