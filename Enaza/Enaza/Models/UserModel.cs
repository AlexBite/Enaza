using System;

namespace Enaza.Models
{
	public class UserModel
	{
		public int UserId { get; set; }
		public string Login { get; set; }
		public DateTime CreatedDate { get; set; }
		public int UserGroupId { get; set; }
		public int UserStateId { get; set; }
	}
}