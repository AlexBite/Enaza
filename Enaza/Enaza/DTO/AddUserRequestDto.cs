using Enaza.Models;

namespace Enaza.DTO
{
	public class AddUserRequestDto
	{
		public string Login { get; set; }
		public string Password { get; set; }
		public UserGroup UserGroup { get; set; }
	}
}