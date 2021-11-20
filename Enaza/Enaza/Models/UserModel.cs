using System;
using System.ComponentModel.DataAnnotations;

namespace Enaza.Models
{
	public class UserModel
	{
		[Key]
		public int UserId { get; set; }
		public string Login { get; set; }
		public DateTime CreatedDate { get; set; }
		public int UserGroupId { get; set; }
		public int UserStateId { get; set; }
	}
}