using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enaza.Models
{
	public class UserGroupModel
	{
		[Key]
		public int UserGroupId { get; private set; }

		[Column(TypeName = "nvarchar(max)")]
		public UserGroup Code { get; set; }

		public string Description { get; set; }
		public ICollection<UserModel> Users { get; set; }
	}
}