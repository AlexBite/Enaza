using System;
using System.ComponentModel.DataAnnotations;

namespace Enaza.Models
{
	public class UserModel
	{
		[Key]
		public int UserId { get; private set; }

		public string Login { get; set; }
		public string Password { get; set; }
		public DateTime CreatedDate { get; set; }
		public int UserGroupId { get; set; }
		public UserGroupModel UserGroup { get; set; }
		public int UserStateId { get; set; }
		public UserStateModel UserState { get; set; }
	}
}